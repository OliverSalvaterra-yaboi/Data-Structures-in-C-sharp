using System;
using System.Collections.Generic;
using System.Text;

namespace treeeeeeeeeeeeeeeeeeeeeeeeeeees
{
    class kiwinode <T> where T : IComparable<T>
    {
        public kiwinode<T> child;
        public kiwinode<T> childl;
        public kiwinode<T> childr;
        public kiwinode<T> parent;
        public int direction;
        public int D;
        public T key;
        
        public kiwinode (T key, kiwinode<T> childl, kiwinode<T> childr, kiwinode<T> parent)
        {
            this.key = key;
            this.childl = childl;
            this.childr = childr;
            this.parent = parent;            
        }

        public int childcount()
        {
            if(childl == null && childr == null)
            {
                return 0;
            }
            else if(childl == null || childr == null)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public bool isright()
        {
            if (parent.childr == this)
            {
                return true;
            }

            return false;
        }
    }
}
