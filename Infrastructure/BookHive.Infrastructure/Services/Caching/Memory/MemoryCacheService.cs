using BookHive.Application.Abstracts.Caching;
using Microsoft.Extensions.Caching.Memory;

namespace BookHive.Infrastructure.Services.Caching.Memory
{
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache memoryCache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }


        public T? Get<T>(string key)
        {
            if (memoryCache.TryGetValue(key, out T value))
            {
                return value;
            }
            return default;
        }

        public void Remove(string key)
        {
            memoryCache.Remove(key);
        }

        public void Set<T>(string key, T value, int slidingExpirationMinutes, int AbsoluteExpirationRelativeToNowMinutes)
        {
            memoryCache.Set(key, value, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(slidingExpirationMinutes),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(AbsoluteExpirationRelativeToNowMinutes)
            });
        }
    }
}
