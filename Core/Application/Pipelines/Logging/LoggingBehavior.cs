using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Text.Json;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ILoggableRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly LoggerServiceBase _loggerServiceBase;

        public LoggingBehavior(IHttpContextAccessor httpContextAccessor, LoggerServiceBase loggerServiceBase)
        {
            _httpContextAccessor = httpContextAccessor;
            _loggerServiceBase = loggerServiceBase;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> logParameters = new();
            logParameters.Add(new LogParameter { Type = request.GetType().Name, Value = request, Name = request.GetType().Name });

            LogDetail logDetail =
                new()
                {
                    MethodName = next.Method.Name,
                    Parameters = logParameters,
                    User = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.Email)?.Value ?? "Bilinmiyor",
                    FullName = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(i => i.Type == "fullname")?.Value ?? "?"
                };

            _loggerServiceBase.Info(JsonSerializer.Serialize(logDetail));
            return await next();
        }
    }
}
