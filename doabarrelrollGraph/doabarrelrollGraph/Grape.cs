using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace doabarrelrollGraph
{
    class Grape<T> where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices = new List<Vertex<T>>();
        public List<Edgy<T>> Edges = new List<Edgy<T>>();
        public Random rnd = new Random();

        public int indexof(Vertex<T> v)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i] == v)
                {
                    return i;
                }
            }
            return default;
        }

        public bool addVert(Vertex<T> vert)
        {
            if (Vertices.Contains(vert)) { return false; }
            else { Vertices.Add(vert); return true; }
        }

        public bool reVert(Vertex<T> vert)
        {
            if (!Vertices.Contains(vert)) { return false; }
            else { Vertices.Remove(vert); return true; }
        }

        public bool addEd(Vertex<T> a, Vertex<T> b)
        {
            if (!Vertices.Contains(a) || !Vertices.Contains(b))
            {
                return false;
            }

            for (int i = 0; i < Vertices[indexof(a)].neighbors.Count; i++)
            {
                if (Vertices[indexof(a)].neighbors[i].b == b)
                {
                    return false;
                }
            }
            Edgy<T> ed = new Edgy<T>(a, b, rnd.Next(1, 10));
            Edges.Add(ed);
            Vertices[indexof(a)].neighbors.Add(ed);
            return true;
        }

        public bool removEd(Vertex<T> a, Vertex<T> b)
        {
            if (Vertices.Contains(a) && Vertices.Contains(b))
            {
                for (int i = 0; i < Vertices[indexof(a)].neighbors.Count; i++)
                {
                    if (Vertices[indexof(a)].neighbors[i].b == b)
                    {
                        Edgy<T> ed = Vertices[indexof(a)].neighbors[i];
                        Edges.Remove(ed);
                        Vertices[indexof(a)].neighbors.Remove(ed);
                        Vertices[indexof(b)].neighbors.Remove(ed);
                        return true;
                    }
                }
                return false;
            }
            else { return false; }
        }

        public int search(T Value)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].Value.CompareTo(Value) == 0)
                {
                    return i;
                }
            }
            return default;
        }

        public Edgy<T> geted(Vertex<T> a, Vertex<T> b)
        {
            if (Vertices.Contains(a) && Vertices.Contains(b))
            {
                for (int i = 0; i < Vertices[indexof(a)].neighbors.Count; i++)
                {
                    if (Vertices[indexof(a)].neighbors[i].b == b)
                    {
                        return Vertices[indexof(a)].neighbors[i];
                    }
                }
                return null;
            }
            else { return null; }
        }

        public double depth(Vertex<T> a, Vertex<T> b)
        {
            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            stack.Push(a);
            List<Vertex<T>> visited = new List<Vertex<T>>();
            Dictionary<Vertex<T>, Vertex<T>> diction = new Dictionary<Vertex<T>, Vertex<T>>();
            diction.Add(a, null);
            bool broken = false;

            while (!broken)
            {
                if (stack.Count == 0) { throw new Exception("Path not found, you imbicile"); }
                Vertex<T> I = stack.Pop();
                visited.Add(I);

                for (int i = 0; i < I.neighbors.Count; i++)
                {
                    if (!visited.Contains(I.neighbors[i].b) && I.neighbors[i].b != b)
                    {
                        stack.Push(I.neighbors[i].b);
                        diction.Add(I.neighbors[i].b, I);
                    }
                    else
                    {
                        diction.Add(b, I);
                        broken = true;
                    }
                }
            }

            double length = 0;
            Vertex<T> parent = b;
            while (true)
            {
                if (diction[parent] != null) { length += geted(diction[parent], parent).weight; parent = diction[parent]; }
                else { break; }
            }

            return length;
        }

        public double bread(Vertex<T> a, Vertex<T> b)
        {
            Queue<Vertex<T>> q = new Queue<Vertex<T>>();
            q.Enqueue(a);
            List<Vertex<T>> visitors = new List<Vertex<T>>();
            Dictionary<Vertex<T>, Vertex<T>> diction = new Dictionary<Vertex<T>, Vertex<T>>();
            diction.Add(a, null);
            bool broken = false;

            while (!broken)
            {
                if (q.Count == 0) { throw new Exception("seasons change but you're not running in circles"); }
                Vertex<T> V = q.Dequeue();
                visitors.Add(V);

                for (int i = 0; i < V.neighbors.Count; i++)
                {
                    if (!visitors.Contains(V.neighbors[i].b) && V.neighbors[i].b == b)
                    {
                        q.Enqueue(V.neighbors[i].b);
                        diction.Add(V.neighbors[i].b, V);
                    }
                    else
                    {
                        diction.Add(b, V);
                        broken = true;
                    }
                }
            }

            double length = 0;
            Vertex<T> parent = b;
            while (true)
            {
                if (diction[parent] != null) { length += geted(diction[parent], parent).weight; parent = diction[parent]; }
                else { break; }
            }

            return length;
        }

        public List<Vertex<T>> Dijkstra(Vertex<T> start, Vertex<T> end)
        {
            Vertices[indexof(start)].distance = 0;
            bool found = false;
            List<vnd<T>> priority = new List<vnd<T>>();
            vnd<T> init = new vnd<T>(start, start.distance);
            priority.Add(init);
            while(!found)
            {
                for(int i = 0; i < priority[0].v.neighbors.Count; i++)
                {
                    if(priority[0].v.neighbors[i].b.visited == false)
                    {
                        priority[0].v.neighbors[i].b.founder = priority[0].v;
                        priority[0].v.neighbors[i].b.distance = priority[0].v.neighbors[i].b.founder.distance + priority[0].v.neighbors[i].weight;
                        vnd<T> pair = new vnd<T>(priority[0].v.neighbors[i].b, priority[0].v.neighbors[i].b.distance);
                        priority.Add(pair);

                        if (priority[0].v.neighbors[i].b == end)
                        {
                            found = true;
                        }
                    }
                    priority[0].v.visited = true;
                    priority.Remove(priority[0]);
                    priority = priority.OrderBy( x => x.distance).ToList();
                }
            }

            List<Vertex<T>> path = new List<Vertex<T>>();
            Vertex<T> x = end;
            while(true)
            {
                path.Add(x);
                x = x.founder;

                if(x == null)
                {
                    break;
                }
            }

            path.Reverse();
            return path;
        }
    }
}
