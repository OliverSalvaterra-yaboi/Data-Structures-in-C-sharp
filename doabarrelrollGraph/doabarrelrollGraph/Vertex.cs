using System;
using System.Collections.Generic;
using System.Text;

namespace doabarrelrollGraph
{
    class Vertex<T> where T : IComparable<T>
    {
        public T Value;
        public List<Edgy<T>> neighbors = new List<Edgy<T>>();
        public double distance = default;
        public Vertex<T> founder = null;
        public bool visited = false;

        public Vertex(T Value)
        {
            this.Value = Value;
        }
    }
}
