﻿using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Core.Application.Pipelines.Caching
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ICachableRequest
    {
        private readonly IDistributedCache _cache;
        private readonly CacheSettings _cacheSettings;
        private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;

        public CachingBehavior(IDistributedCache cache, ILogger<CachingBehavior<TRequest, TResponse>> logger, IConfiguration configuration)
        {
            _cache = cache;
            _cacheSettings = configuration.GetSection("CacheSettings").Get<CacheSettings>() ?? throw new InvalidOperationException();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (request.BypassCache)
                return await next();

            TResponse response;
            byte[]? cachedResponse = await _cache.GetAsync(request.CacheKey, cancellationToken);
            if (cachedResponse != null)
            {
                response = JsonSerializer.Deserialize<TResponse>(Encoding.Default.GetString(cachedResponse))!;
                _logger.LogInformation($"Fetched from Cache -> {request.CacheKey}");
            }
            else
            {
                response = await getResponseAndAddToCache(request, next, cancellationToken);
            }

            return response;
        }
        private async Task<TResponse> getResponseAndAddToCache(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
        {
            TResponse response = await next();

            TimeSpan? slidingExpiration = request.SlidingExpiration ?? TimeSpan.FromMinutes(_cacheSettings.SlidingExpiration);
            DistributedCacheEntryOptions cacheOptions = new() { SlidingExpiration = slidingExpiration };
            _logger.LogInformation($"Expiration Time -> {slidingExpiration}");

            byte[] serializeData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response));
            await _cache.SetAsync(request.CacheKey, serializeData, cacheOptions, cancellationToken);
            _logger.LogInformation($"Added to Cache -> {request.CacheKey}");

            if (request.CacheGroupKey != null)
            {
                byte[]? cachedGroup = await _cache.GetAsync(request.CacheGroupKey, cancellationToken);
                HashSet<string> keysInGroup;
                if (cachedGroup != null)
                {
                    keysInGroup = JsonSerializer.Deserialize<HashSet<string>>(Encoding.Default.GetString(cachedGroup))!;
                    if (!keysInGroup.Contains(request.CacheKey))
                        keysInGroup.Add(request.CacheKey);
                }
                else
                {
                    keysInGroup = new HashSet<string>(new[] { request.CacheKey });
                }

                byte[] serializeGroupData = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(keysInGroup));
                await _cache.SetAsync(request.CacheGroupKey, serializeGroupData, cacheOptions, cancellationToken);
                _logger.LogInformation($"Added to Cache -> {request.CacheGroupKey}");
            }

            return response;
        }
    }
}
