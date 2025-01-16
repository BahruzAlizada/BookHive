

namespace BookHive.Application.Abstracts.Caching
{
    public interface ICacheService
    {
        public void Set<T>(string key, T value, int slidingExpirationMinutes, int AbsoluteExpirationRelativeToNowMinutes);
        T? Get<T>(string key);
        void Remove(string key);
    }
}
