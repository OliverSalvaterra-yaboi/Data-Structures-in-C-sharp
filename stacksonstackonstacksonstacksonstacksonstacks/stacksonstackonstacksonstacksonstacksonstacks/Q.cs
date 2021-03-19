using System;
using System.Collections.Generic;
using System.Text;

namespace stacksonstackonstacksonstacksonstacksonstacks
{
    class Q<T>
    {
        public int count { get; set; }
        private LinkedList<T> thingys;

        public void enq(T Value)
        {
            LinkedListNode<T> thing = new LinkedListNode<T>(Value);
            thingys.AddFirst(thing);
        }

        public T dq()
        {
            T value = thingys.Last.Value;
            thingys.RemoveLast();
            return value;
        }

        public T peek()
        {
            return thingys.Last.Value;
        }

        public void clear()
        {
            thingys.Clear();
        }

        public bool isEmpty()
        {
            if (thingys == null)
            {
                return true;
            }
            return false;
        }
    }
}
