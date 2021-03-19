using System;
using System.Collections.Generic;
using System.Text;

namespace AVLT_REE
{
    class Node<T> where T : IComparable<T>
    {
        public T key;
        public Node<T> parent;
        public Node<T> rchild;
        public Node<T> lchild;

        public Node(T key, Node<T> parent, Node<T> rchild, Node<T> lchild)
        {
            this.key = key;
            this.parent = parent;
            this.rchild = rchild;
            this.lchild = lchild;
        }
        public Node(T key)
        {
            this.key = key;
        }
    }
}
