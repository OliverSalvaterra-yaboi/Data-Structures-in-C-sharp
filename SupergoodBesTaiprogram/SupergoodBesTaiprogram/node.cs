using System;
using System.Collections.Generic;
using System.Text;

namespace SupergoodBesTaiprogram
{
    class Node<T> where T : IComparable<T>
    {
        public T value;
        public Node<T> lchild;
        public Node<T> rchild;
        public Node<T> parent;
        public int height;
        public int balance;

        public Node(T value, Node<T> lchild, Node<T> rchild, Node<T> parent)
        {
            this.value = value;
            this.lchild = lchild;
            this.rchild = rchild;
            this.parent = parent;
        }

        public int childs(Node<T> node)
        {
            if(lchild != null && rchild != null)
            {
                return 2;
            }
            else if(lchild != null || rchild != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
