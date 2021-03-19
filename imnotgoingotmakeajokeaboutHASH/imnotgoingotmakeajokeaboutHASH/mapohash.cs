using System;
using System.Collections.Generic;
using System.Text;

namespace imnotgoingotmakeajokeaboutHASH
{
    public class mapohash<TKey, TValue> where TKey : IComparable<TKey>
    {
        //hash code: (index 0)squared * index 1, + other chars indexes (1-24) (abdicate = 44, doge = 72, you = 396, hello = 79, good = 124)
        public LinkedList<pair<TKey, TValue>>[] lists = new LinkedList<pair<TKey, TValue>>[1];

        public TValue this[TKey key]
        {
            get
            {
                int index = hash(key.ToString()) % lists.Length;
                LinkedListNode<pair<TKey, TValue>> node = lists[index].First;
                for (int i = 0; i < lists[index].Count; i++)
                {
                    if (node.Value.Key.CompareTo(key) == 0)
                    {
                        return node.Value.Value;
                    }
                    else
                    {
                        node = node.Next;
                    }
                }
                throw new KeyNotFoundException("really dude");
            }
            set
            {
                return;
            }
        }

        public int hash(string word)
        {
            word = word.ToLower();
            int hashcode = (((int)word[0] - 96) ^ 2) * ((int)word[1] - 96);
            for (int i = 2; i < word.Length - 3; i++)
            {
                hashcode += (int)word[i] - 96;
            }
            return hashcode;
        }

        public void rehash()
        {
            int count = 0;
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    count += lists[i].Count;
                }
            }

            if (count == lists.Length)
            {
                LinkedList<pair<TKey, TValue>>[] listss = new LinkedList<pair<TKey, TValue>>[lists.Length * 2];
                for (int i = 0; i < count; i++)
                {
                    int index = hash(lists[i].First.Value.Key.ToString()) % listss.Length;
                    if (listss[index] == null)
                    {
                        listss[index] = new LinkedList<pair<TKey, TValue>>();
                    }
                    listss[index].AddFirst(lists[i].First.Value);
                }

                lists = listss;
            }
        }

        public bool add(TKey key, TValue value)
        {
            LinkedListNode<pair<TKey, TValue>> newnode = new LinkedListNode<pair<TKey, TValue>>(new pair<TKey, TValue>(key, value));
            int index = hash(key.ToString()) % lists.Length;
            if (lists[index] == null)
            {
                lists[index] = new LinkedList<pair<TKey, TValue>>();
                lists[index].AddLast(newnode);

                rehash();
                return true;
            }
            else
            {
                LinkedListNode<pair<TKey, TValue>> node = lists[index].First;
                for (int i = 0; i < lists[index].Count; i++)
                {
                    if (node == newnode)
                    {
                        return false;
                    }
                    else
                    {
                        node = node.Next;
                    }
                }
                lists[index].AddFirst(newnode);

                rehash();
                return true;
            }
        }

        public bool remove(TKey key)
        {
            int index = hash(key.ToString()) % lists.Length;
            LinkedListNode<pair<TKey, TValue>> node = lists[index].First;
            for (int i = 0; i < lists[index].Count; i++)
            {
                if (node.Value.Key.CompareTo(key) == 0)
                {
                    node = null;
                }
                else
                {
                    node = node.Next;
                }
            }

            return true;
        }

        public LinkedList<pair<TKey, TValue>> enumer()
        {
            LinkedList<pair<TKey, TValue>> liste = new LinkedList<pair<TKey, TValue>>();
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] != null)
                {
                    LinkedListNode<pair<TKey, TValue>> smol = lists[i].First;
                    for (int j = 0; j < lists[i].Count; j++)
                    {
                        liste.AddFirst(new LinkedListNode<pair<TKey, TValue>>(smol.Value));
                        smol = smol.Next;
                    }
                }

            }
            return liste;
        }
    }
}
