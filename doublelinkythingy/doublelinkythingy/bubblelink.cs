using System;
using System.Collections.Generic;
using System.Text;

namespace doublelinkythingy
{
    class bubblelink<T> where T : IComparable<T>
    {
        public bubblylinknode<T> head;
        public bubblylinknode<T> tail;
        public int count { get; private set; }

        public void addfirst(T Value)
        {
            if(head == null)
            {
                head = new bubblylinknode<T>(Value);
            }
            else
            {
                bubblylinknode<T> newnode = new bubblylinknode<T>(Value, head, null);
                head = newnode;
            }
        }

        public void addlast(T Value)
        {
            if(tail == null)
            {
                tail = new bubblylinknode<T>(Value);
            }
            else
            {
                bubblylinknode<T> newnode = new bubblylinknode<T>(Value, null, tail);
                tail = newnode;
            }
        }

        public bool addbefore(bubblylinknode<T> node, T Value)
        {
            bubblylinknode<T> beforenode = head;

            while(node != beforenode || beforenode == null)
            {
                beforenode = beforenode.Next;
            }

            if(beforenode == null)
            {
                return false;
            }
            else
            {
                beforenode.Previous = new bubblylinknode<T>(Value, beforenode, beforenode.Previous);
                beforenode.Previous.Previous.Next = beforenode.Previous;
                return true;
            }
        }

        public bool addafter(bubblylinknode<T> node, T Value)
        {
            bubblylinknode<T> afternode = head;

            while(node != afternode || afternode == node)
            {
                afternode = afternode.Next;
            }

            if (afternode == null)
            {
                return false;
            }
            else
            {
                afternode.Next = new bubblylinknode<T>(Value, afternode.Next, afternode);
                afternode.Next.Next.Previous = afternode.Next;
                return true;
            }
        }

        public bool removefirst()
        {
            if(head == null)
            {
                return false;
            }
            else
            {
                head.Next = head;
                return true;
            }
        }

        public bool removelast()
        {
            if(tail == null)
            {
                return false;
            }
            else
            {
                tail.Previous = tail;
                return true;
            }
        }

        public bool remove(T Value)
        {
            bubblylinknode<T> node = head;
            while(!node.Value.Equals(Value) || node == null)
            {
                node = node.Next;
            }

            if(node == null)
            {
                return false;
            }
            else
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                return true;
            }
        }

        public bool isempty()
        {
            if(count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
