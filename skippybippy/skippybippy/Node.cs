using System;
using System.Collections.Generic;
using System.Text;

namespace skippybippy
{
    class Node<T> where T : IComparable//, ICollection<T>
    {
        public T Key;
        public int height;
        public Node<T> child;
        public List<Node<T>> childrens;

        public Node(T Key, int height, List<Node<T>> childrens)
        {
            this.Key = Key;
            this.height = height; 
            this.childrens = childrens;
        }

        public Node(T Key, int height, Node<T> child)
        {
            this.Key = Key;
            this.height = height;
            this.child = child;
        }
    }
}
