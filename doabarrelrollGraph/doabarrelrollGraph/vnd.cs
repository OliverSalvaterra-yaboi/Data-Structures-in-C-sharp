using System;
using System.Collections.Generic;
using System.Text;

namespace doabarrelrollGraph
{
    class vnd<T> where T : IComparable<T>
    {
        public Vertex<T> v;
        public double distance = default;

        public vnd(Vertex<T> v, double distance)
        {
            this.v = v;
            this.distance = distance;
        }
    }
}
