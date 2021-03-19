using System;
using System.Collections.Generic;
using System.Text;

namespace treeeeeeeeeeeeeeeeeeeeeeeeeeees
{
    class tre<T> where T : IComparable<T>
    {
        public kiwinode<T> root;
        public int count { get; set; }
        public T rootkey => root.key;


    }
}
