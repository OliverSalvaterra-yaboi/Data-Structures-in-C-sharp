using System;
using System.Collections.Generic;
using System.Text;

namespace treeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
{
    class kiwinode<T> where T : IComparable<T>
    {
        public kiwinode<T> childl;
        public kiwinode<T> childr;
        public T key;
        public kiwinode<T> parent;

        public kiwinode (kiwinode<T> childl, kiwinode<T> childr, T key, kiwinode<T> parent)
        {
            this.childl = childl;
            this.childr = childr;
            this.key = key;
            this.parent = parent;
        }
 
        public bool ischildr()
        {
            if(parent.key.CompareTo(this.key) > 0)
            {
                return true;
            }
            return false;
        }

        public int childcount()
        {
            if(this.childl == null && this.childr == null)
            {
                return 0;
            }
            else if(this.childl == null || this.childr == null)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}
