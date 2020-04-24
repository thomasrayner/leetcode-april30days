using System;
using System.Collections.Generic;

namespace day24
{
    class Program
    {
        static void Main(string[] args)
        {
            LRUCache cache = new LRUCache(2 /* capacity */ );

            cache.Put(1, 1);
            cache.Put(2, 2);
            Console.WriteLine("Returns 1: " + cache.Get(1));       // returns 1
            cache.Put(3, 3);    // evicts key 2
            Console.WriteLine("Returns -1: " + cache.Get(2));       // returns -1 (not found)
            cache.Put(4, 4);    // evicts key 1
            Console.WriteLine("Returns -1: " + cache.Get(1));       // returns -1 (not found)
            Console.WriteLine("Returns 3: " + cache.Get(3));       // returns 3
            Console.WriteLine("Returns 4: " + cache.Get(4));       // returns 4
        }
    }

    public class LRUCache
    {
        private class LRUCacheItem
        {
            public int CacheKey { get; set; }
            public int CacheValue { get; set; }
        }

        private int Size;
        private LinkedList<LRUCacheItem> CacheList = new LinkedList<LRUCacheItem>();           // For keeping things in order
        private Dictionary<int,LRUCacheItem> CacheDict = new Dictionary<int, LRUCacheItem>();  // For quicker lookups

        public LRUCache(int capacity)
        {
            Size = capacity;
        }

        public int Get(int key)
        {
            // return -1 if we don't have anything with this key
            if (!CacheDict.ContainsKey(key))
            {
                return -1;
            }

            // Move this item to the end of the linked list, most recently used, return the cachevalue
            CacheList.Remove(CacheDict[key]);
            CacheList.AddLast(CacheDict[key]);
            return CacheDict[key].CacheValue;
        }

        public void Put(int key, int value)
        {
            // If we have this one already, update it, move it to the end, most recently used
            if (CacheDict.ContainsKey(key))
            {
                CacheDict[key].CacheValue = value;
                CacheList.Remove(CacheDict[key]);
                CacheList.AddLast(CacheDict[key]);
                return; // no size change so skip all that
            }

            // We don't have this one already, so add it to the dict and linked list
            CacheDict.Add(key, new LRUCacheItem() {CacheKey = key, CacheValue = value});
            CacheList.AddLast(CacheDict[key]);

            // Trim the collections if we're over sized now
            if (CacheDict.Count > Size)
            {
                CacheDict.Remove(CacheList.First.Value.CacheKey);
                CacheList.RemoveFirst();
            }
        }
    }

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
