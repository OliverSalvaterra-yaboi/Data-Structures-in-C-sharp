using System;
using System.Collections.Generic;
using System.Text;

namespace imnotgoingotmakeajokeaboutHASH
{
    public class pair<TKey, TValue> where TKey : IComparable<TKey>
    {
        public TKey Key;
        public TValue Value;

        public pair(TKey Key, TValue Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
}
