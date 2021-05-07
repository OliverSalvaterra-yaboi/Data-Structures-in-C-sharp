using System;
using System.Collections.Generic;

namespace LRUchashu
{
    class LRUCache<T, U>
    {
        public int lim { get; private set; }
        private LinkedList<KeyValuePair<T, U>> list;
        private Dictionary<T, LinkedListNode<KeyValuePair<T, U>>> map;

        public LRUCache(int lim)
        {
            this.lim = lim;
            list = new LinkedList<KeyValuePair<T, U>>();
            map = new Dictionary<T, LinkedListNode<KeyValuePair<T, U>>>();
        }


        public bool TryGetValue(T key, out U value)
        {
            if (!map.ContainsKey(key))
            {
                value = default;
                return false;
            }

            value = map[key].Value.Value;
            return true;
        }

        public void Put(T key, U value)
        {
            bool contains = map.ContainsKey(key);
            LinkedListNode<KeyValuePair<T, U>> node = new LinkedListNode<KeyValuePair<T, U>>(new KeyValuePair<T,U>(key, value));

            if (!contains)
            {
                map.Add(key, node);
            }

            if (contains)
            {
                list.Remove(map[key]);
                map[key] = node;
            }

            if (list.Count > lim) 
            {
                map.Remove(list.Last.Value.Key);
                list.Remove(list.Last);
            }

            list.AddFirst(node);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String rtrn = "";
            LRUCache<string, string> cash = new LRUCache<string, string>(12);

            for(int i = 0; i < cash.lim; i++)
            {
                cash.Put("node: " + i, Math.Pow(i, 2).ToString());
            }

            cash.Put("node: 4", "over 9000");

            for(int i = 0; i < cash.lim; i++)
            {
                cash.TryGetValue("node: " + i, out rtrn);
                Console.WriteLine("node: " + i + ", " + rtrn);
            }
        }
    }
}
