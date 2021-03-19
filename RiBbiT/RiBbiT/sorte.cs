using System;
using System.Collections.Generic;
using System.Text;

namespace RiBbiT
{
    class sorte<T> where T : IComparable<T>
    {
        public tree<T> tree;
        public List<T> list;
        bool done = false;
        public sorte(tree<T> tree, List<T> list)
        {
            this.tree = tree;
            this.list = list;
        }

        public void add(T val)
        {
            tree.insert(val);
        }
    
        public void delete(T val)
        {
            tree.delete(val);
        }

        public void compile()
        {
            Node<T> placebnode = tree.root;
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(placebnode);
            while(queue.Count != 0)
            {
                for(int i = 0; i < queue.Count; i++)
                {
                    list.Add(queue.Peek().val);

                    if(queue.Peek().lchild != null)
                    {
                        queue.Enqueue(queue.Peek().lchild);
                    }
                    if (queue.Peek().rchild != null)
                    {
                        queue.Enqueue(queue.Peek().rchild);
                    }

                    queue.Dequeue();
                }
            }
        }
    }
}
