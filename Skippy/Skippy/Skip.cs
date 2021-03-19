using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;

namespace Skippy
{
    class DuplicateItemException : Exception
    {
        public DuplicateItemException(string msg) : base(msg)
        {

        }
    }
    class Node<T> where T : IComparable<T>
    {
        public Node<T>[] nodes;
        public int height = 1;
        public T key;

        public Node(T key, int height)
        {
            this.key = key;
            this.height = height;
            nodes = new Node<T>[height];
        }

        public void increment()
        {
            var newnodes = new Node<T>[nodes.Length + 1];

            for (int i = 0; i < nodes.Length; i++)
            {
                newnodes[i] = nodes[i];
            }

            nodes = newnodes;
            height++;
        }
    }

    class Skip<T> : IEnumerable<T> where T : IComparable<T>
    {
        
        int count = 0;
        Node<T> head = new Node<T>(default, 1);
        Random rnd = new Random();

        public int getheight(int max)
        {
            int height = 1;
            while (rnd.Next(0, 2) > 0 && height <= max)
            {
                height++;
            }

            return height;
        }

        public void add(T val)
        {
            int h = head.height - 1;

            //Generate height here

            Node<T> cur = head;
            Node<T> node = new Node<T>(val, getheight(head.height));

            if (node.height > h + 1)
            {
                head.increment();
            }


            while (h >= 0)
            {
                int comp = cur.nodes[h] == null ? 1 : cur.nodes[h].key.CompareTo(node.key);
                if (comp < 0)
                {
                    cur = cur.nodes[h];
                }
                else if (comp > 0)
                {
                    if (node.height > h)
                    {
                        node.nodes[h] = cur.nodes[h];
                        cur.nodes[h] = node;
                    }
                    h--;
                }
                else if (comp == 0)
                {
                    throw new DuplicateItemException($"{val} already exists.");
                }
            }
            count++;
        }

        public bool remove(T val)
        {
            int h = head.height - 1;
            bool rtrn = false;

            Node<T> cur = head;

            while (h >= 0)
            {
                int comp = cur.nodes[h] == null ? 1 : cur.nodes[h].key.CompareTo(val);
                
                if (comp > 0)
                {
                    h--;
                }
                else if (comp < 0)
                {
                    cur = cur.nodes[h];
                }
                else if (comp == 0)
                {
                    cur.nodes[h] = cur.nodes[h].nodes[h];
                    h--;
                    rtrn = true;
                }
            }

            if (rtrn) count--;
            return rtrn;
        }

        public bool search(T val)
        {
            int h = head.height - 1;

            Node<T> cur = head;

            while (h >= 0)
            {
                int comp = cur.nodes[h] == null ? 1 : cur.nodes[h].key.CompareTo(val);
                if (comp == 0)
                {
                    return true;
                }
                else if (comp < 0)
                {
                    cur = cur.nodes[h];
                }
                else
                {
                    h--;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> dud = head;
            for(int i = 0; i < count; i++)
            {
                dud = dud.nodes[0];
                yield return dud.key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
