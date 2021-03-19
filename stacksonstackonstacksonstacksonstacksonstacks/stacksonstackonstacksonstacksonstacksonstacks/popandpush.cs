using System;
using System.Collections.Generic;
using System.Text;

namespace stacksonstackonstacksonstacksonstacksonstacks
{
    class popandpush<T>
    {
        public int count { get; set; }
        private LinkedList<T> thingys;
        T Val;

        public void push(T Value)
        {
            LinkedListNode<T> thingy = new LinkedListNode<T>(Value);
            thingys.AddFirst(thingy);
        }

        public T pop()
        {
            T valu = thingys.First.Value;
            thingys.RemoveFirst();
            return valu;
        }

        public T peek()
        {
            return thingys.First.Value;
        }

        public void clear()
        {
            thingys.Clear();
        }

        public bool isEmpty()
        {
            if(thingys == null)
            {
                return true;
            }
            return false;
        }
    }
}
