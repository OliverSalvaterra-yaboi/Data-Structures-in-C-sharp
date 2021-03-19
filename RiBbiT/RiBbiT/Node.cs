using System;
using System.Collections.Generic;
using System.Text;

namespace RiBbiT
{
    class Node<T> where T : IComparable<T>
    {
        public T val;
        public Node<T> lchild;
        public Node<T> rchild;
        public Node<T> parent;
        public bool color;
        public Node<T> prev;
        public Node<T> next;

        public Node(T val, Node<T> lchild, Node<T> rchild, Node<T> parent, bool color)
        {
            this.val = val;
            this.lchild = lchild;
            this.rchild = rchild;
            this.parent = parent;
            this.color = color;
        }

        public Node(T val)
        {
            this.val = val;
        }

        public Node(T val, Node<T> prev, Node<T> next)
        {
            this.val = val;
            this.prev = prev;
            this.next = next;

        }
    }
}
