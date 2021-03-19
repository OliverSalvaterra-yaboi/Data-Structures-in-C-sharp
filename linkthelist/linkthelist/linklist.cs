using System;
using System.Collections.Generic;
using System.Text;

namespace linkthelist
{
    class linklist<T> where T : IComparable<T>
    {
        public node<T> head;
        public int count { get; private set; }

        public void addfirst(T value)
        {
            if (head == null)
            {
                head = new node<T>(value);
            }
            else
            {
                node<T> newNode = new node<T>(value, head);
                head = newNode;
            }
        }

        public void addlast(T value)
        {
            node<T> lastNode = head;
            while (lastNode.Next == null)
            {
                lastNode = lastNode.Next;
            }

            lastNode.Next = new node<T>(value);
        }

        public void addAfter(node<T> Node, T Value)
        {
            node<T> nextNode = head;
            while (nextNode != Node)
            {
                nextNode = nextNode.Next;
            }
            nextNode.Next = new node<T>(Value, nextNode.Next);
        }

        public void addBefore(node<T> Node, T Value)
        {
            node<T> prevNode = head;
            while (prevNode.Next != Node)
            {
                prevNode = prevNode.Next;
            }
            prevNode.Next = new node<T>(Value, prevNode.Next);
        }

        public bool removeFirst()
        {
            if (head == null)
            {
                return false;
            }
            else
            {
                head = head.Next;
                return true;
            }
        }

        public bool removeLast()
        {
            if (head == null)
            {
                return false;
            }
            else
            {
                node<T> lastNode = head;
                while (lastNode.Next.Next != null)
                {
                    lastNode = lastNode.Next;
                }

                lastNode.Next = null;
                return true;
            }
        }

        public bool remove(T Value)
        {
            //0 is equal
            //1 is greater
            //-1 is less
            node<T> remove = head;
            while (!remove.Next.Value.Equals(Value) || remove == null)
            {
                remove = remove.Next;
            }

            if (remove == null)
            {
                return false;
            }

            remove.Next = remove.Next.Next;
            return true;
        }

        public void clear()
        {
            head = null;
            count = 0;
        }

        public bool contains(T Value)
        {
            node<T> container = head;
            while(!container.Value.Equals(Value) || container == null)
            {
                container = container.Next;
            }

            if(container == null)
            {
                return false;
            }
            return true;
        }
    }
}
