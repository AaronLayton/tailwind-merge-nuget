using System.Collections.Generic;

namespace TailwindMerge
{
    public class LruCache
    {
        private Dictionary<string, string> cache = new Dictionary<string, string>();
        private Dictionary<string, string> previousCache = new Dictionary<string, string>();
        private int cacheSize = 0;

        public LruCache(int maxCacheSize)
        {
            MaxCacheSize = maxCacheSize;
        }

        public int MaxCacheSize { get; }

        public string? Get(string key)
        {
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }

            if (previousCache.ContainsKey(key))
            {
                string value = previousCache[key];
                Update(key, value);
                return value;
            }

            return null;
        }

        public LruCache Set(string key, string value)
        {
            if (cache.ContainsKey(key))
            {
                cache[key] = value;
            }
            else
            {
                Update(key, value);
            }

            return this;
        }

        private void Update(string key, string value)
        {
            cache[key] = value;
            cacheSize++;

            if (cacheSize > MaxCacheSize)
            {
                cacheSize = 0;
                previousCache = new Dictionary<string, string>(cache);
                cache.Clear();
            }
        }
    }
}
