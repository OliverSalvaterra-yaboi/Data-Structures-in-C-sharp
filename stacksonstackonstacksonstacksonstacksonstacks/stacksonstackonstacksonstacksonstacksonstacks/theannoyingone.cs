using System;
using System.Collections.Generic;
using System.Text;

namespace stacksonstackonstacksonstacksonstacksonstacks
{
    class theannoyingone<T>
    {
        public int count { get; set; }
        private T[] thingys;

        public theannoyingone(int capacity)
        {
            thingys = new T[capacity];
        }

        public void Q(T Value)
        {
            T[] morethingys = new T[thingys.Length + 1];
            for(int i = 1; i < morethingys.Length; i++)
            {
                morethingys[i-1] = thingys[i];
            }
            morethingys[0] = Value;
            thingys = morethingys;
        }

        public T dq()
        {
            T thing = thingys[thingys.Length - 1];
            T[] morethingys = new T[thingys.Length - 1];
            for (int i = 0; i < morethingys.Length; i++)
            {
                morethingys[i] = thingys[i];
            }                    
            thingys = morethingys;
            return thing;
        }

        public T peek()
        {
            return thingys[0];
        }

        public void clear()
        {
            T[] snap = new T[0];
            thingys = snap;
        }

        public bool isEmpty()
        {
            if(thingys.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}
