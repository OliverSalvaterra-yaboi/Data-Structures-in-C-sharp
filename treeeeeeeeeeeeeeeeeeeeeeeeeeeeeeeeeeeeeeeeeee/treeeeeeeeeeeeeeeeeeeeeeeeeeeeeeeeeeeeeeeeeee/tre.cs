using System;
using System.Collections.Generic;
using System.Text;

namespace treeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
{
    class tre<T> where T : IComparable<T>
    {
        public kiwinode<T> root;
        public int count { get; set; }
        public T rootkey => root.key;

        public void insert(T value)
        {

            count++;
            kiwinode<T> current = root;

            if(root == null)
            {
                root = new kiwinode<T>(null, null, value, null);
            }


            while(current != null)
            {
                if(value.CompareTo(current.key) < 0)
                {
                    if(current.childl == null)
                    {
                        current.childl = new kiwinode<T>(null, null, value, current);
                        break;
                    }
                    current = current.childl;
                }
                else
                {
                    if(current.childr == null)
                    {
                        current.childr = new kiwinode<T>(null, null, value, current);
                        break;
                    }
                    current = current.childr;
                }
            }
        }

        private kiwinode<T> finder(T key)
        {
            kiwinode<T> current = root;

            while(current != null)
            {
                int comp = key.CompareTo(current.key);

                if(comp < 0)
                {
                    current = current.childl;
                }
                if(comp > 0)
                {
                    current = current.childr;
                }
                if(comp == 0)
                {
                    return current;
                }
            }

            return null;
        }

        public bool contains(T val)
        {
            return finder(val) != null;
        }

        private kiwinode<T> min(kiwinode<T> node)
        {
            while(node.childl != null)
            {
                node = node.childl;
            }

            return node;
        }

        private kiwinode<T> max(kiwinode<T> node)
        {
            while(node.childr != null)
            {
                node = node.childr;
            }

            return node;
        }

        private void delete(kiwinode<T> node)
        {
            if(node.childcount() == 2)
            {
                kiwinode<T> candy = min(node.childr);
                node.key = candy.key;
                node = candy;
            }

            if(node.childcount() == 1)
            {
                kiwinode<T> child;
                if(node.childl == null)
                {
                    child = node.childr;
                }
                else
                {
                    child = node.childl;
                }

                if(node == root)
                {
                    root = child;
                }
                else if(node.ischildr())
                {
                    node.parent.childr = child;
                }
                else if(!node.ischildr())
                {
                    node.parent.childl = child;
                }
            }

            if(node.childcount() == 0)
            {
                if(node == root)
                {
                    root = null;
                }
                else if(node.ischildr())
                {
                    node.parent.childr = null;
                }
                else if(!node.ischildr())
                {
                    node.parent.childl = null;
                }
            }
        }

        public bool deletion(T val)
        {
            kiwinode<T> todel = finder(val);
            if(todel == null)
            {
                return false;
            }

            delete(todel);
            count--;
            return true;
        }

        public IEnumerable<T> preorder()
        {
            LinkedList<T> nodes = new LinkedList<T>();
            bool finished = false;
            bool same;

            while(true)
            {
                kiwinode<T> current = root;
                same = false;

                for(int i = 0; i < nodes.Count; i++)
                {
                    LinkedListNode<T> node = nodes.First;
                    if (node.Value.CompareTo(current.key) == 0)
                    {
                        same = true;
                    }
                }

                if(current.childl != null && !same)
                {
                    nodes.AddLast(current.key);
                    current = current.childl;
                }
                else if(current.childr != null && !same)
                {
                    nodes.AddLast(current.key);
                    current = current.childr;
                }
                else if(current.parent == null)
                {
                    break;
                }
                else
                {
                    current = current.parent;
                }
            }

            return nodes;
        }

        public IEnumerable<T> inorder()
        {
            Queue<T> nodes = new Queue<T>();

            inorder(root);

            return nodes;

            void inorder(kiwinode<T> cur)
            {
                if(cur.childl != null)
                {
                    cur = cur.childl;
                }

                nodes.Enqueue(cur.key);

                if(cur.childr != null)
                {
                    cur = cur.childr;
                }
            }
        }

        public IEnumerable<T> postorder()
        {
            Queue<T> nodes = new Queue<T>();

            postorder(root);

            return nodes;

            void postorder(kiwinode<T> cur)
            {
                if (cur.childl != null)
                {
                    cur = cur.childl;
                }

                if (cur.childr != null)
                {
                    cur = cur.childr;
                }

                nodes.Enqueue(cur.key);
            }
        }
    }
}
