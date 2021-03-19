using System;
using System.Collections.Generic;
using System.Text;

namespace linkthelist
{
    class node<T> where T : IComparable<T>
    {
        public T Value;
        public node<T> Next;

        public node (T Value)
        {
            this.Value = Value;
        }

        public node (T Value, node<T> Next)
        {
            this.Value = Value;
            this.Next = Next;
        }
    }    
}
