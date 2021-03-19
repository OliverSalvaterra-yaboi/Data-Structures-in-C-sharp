using System;
using System.Collections.Generic;
using System.Text;

namespace GRAPHsofpolynomials
{
    class Vertex<T> where T : IComparable<T>
    {
        public T Value;
        public List<Vertex<T>> neighbors = new List<Vertex<T>>();

        public Vertex(T Value)
        {
            this.Value = Value;
        }
    }
}
