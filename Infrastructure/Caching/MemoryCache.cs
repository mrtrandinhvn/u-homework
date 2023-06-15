using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching
{
    public class MemoryCache : IDataAccessCache
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public Task<bool> DeleteAsync(string key)
        {
            try
            {
                _memoryCache.Remove(key);
            }
            catch (Exception ex)
            {
                return Task.FromException<bool>(ex);
            }

            return Task.FromResult(true);
        }

        public Task<T?> GetAsync<T>(string key)
        {
            try
            {
                T? data = _memoryCache.Get<T?>(key);
                return Task.FromResult(data);
            }
            catch (Exception ex)
            {
                return Task.FromException<T?>(ex);
            }
        }

        public Task<bool> SetAsync(string key, object value, TimeSpan? timeout = null)
        {
            timeout ??= TimeSpan.FromMinutes(30);
            try
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(timeout.Value);
                _memoryCache.Set(key, value, cacheEntryOptions);
            }
            catch (Exception ex)
            {
                return Task.FromException<bool>(ex);
            }

            return Task.FromResult(true);
        }
    }
}
