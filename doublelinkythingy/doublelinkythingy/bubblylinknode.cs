using System;
using System.Collections.Generic;
using System.Text;

namespace doublelinkythingy
{
    class bubblylinknode<T> where T : IComparable<T>
    {
        public T Value;
        public bubblylinknode<T> Next;
        public bubblylinknode<T> Previous;
        public bubblylinknode(T Value, bubblylinknode<T> Next, bubblylinknode<T> Previous)
        {
            this.Value = Value;
            this.Next = Next;
            this.Previous = Previous;
        }

        public bubblylinknode(T Value)
        {
            this.Value = Value;
        }
    }
}
