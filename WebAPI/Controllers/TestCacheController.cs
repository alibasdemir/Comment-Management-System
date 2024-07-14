using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestCacheController : BaseController
    {
        private readonly IDistributedCache _cache;

        public TestCacheController(IDistributedCache cache)
        {
            _cache = cache;
        }

        [HttpGet("set/{key}/{value}")]
        public async Task<IActionResult> SetCache(string key, string value)
        {
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(5));

            await _cache.SetStringAsync(key, value, options);
            return Ok("Value set in cache.");
        }

        [HttpGet("get/{key}")]
        public async Task<IActionResult> GetCache(string key)
        {
            var value = await _cache.GetStringAsync(key);
            if (value == null)
                return NotFound("Value not found in cache.");

            return Ok(value);
        }
    }
}
