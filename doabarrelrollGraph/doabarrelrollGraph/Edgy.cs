using System;
using System.Collections.Generic;
using System.Text;

namespace doabarrelrollGraph
{
    class Edgy<T> where T : IComparable<T>
    {
        public Vertex<T> a;
        public Vertex<T> b;
        public double weight;

        public Edgy(Vertex<T> a, Vertex<T> b, double weight)
        {
            this.a = a;
            this.b = b;
            this.weight = weight;
        }
    }
}
