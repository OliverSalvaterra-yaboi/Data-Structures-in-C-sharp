using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using HeapsonHeaps;

namespace heftyGraph
{
    class Astar
    {
        public double Euclidian(Vertex<Point> s, Vertex<Point> e)
        {
            double dx = Math.Abs(e.key.X - s.key.X);
            double dy = Math.Abs(e.key.Y - s.key.Y);

            return Math.Sqrt(dx * dx + dy * dy);
        }

        public List<Vertex<Point>> A(Graph<Point> g, Point start, Point end)
        {
            Vertex<Point> s = g.search(start);
            Vertex<Point> e = g.search(end);

            List<Vertex<Point>> rtrn = new List<Vertex<Point>>();

            if (s.closed || e.closed) { return rtrn; }

            Dictionary<Vertex<Point>, (Vertex<Point> parent, double cost)> vs = new Dictionary<Vertex<Point>, (Vertex<Point> parent, double cost)>();
            //Heap<double> heap = new Heap<double>(Comparer<double>.Create((a, b) => a.CompareTo(b)));

            var heap = new Heap<Vertex<Point>>(Comparer<Vertex<Point>>.Create((a, b) => a.finalD.CompareTo(b.finalD)));

            for (int i = 0; i < g.vertices.Count; i++)
            {
                g.vertices[i].visited = false;
                vs.Add(g.vertices[i], (null, double.MaxValue));
            }

            vs[s] = (null, Euclidian(s, e));

            heap.Insert(s);

            while (heap.Count > 0)
            {
                var current = heap.Pop();

                if (current == e)
                {
                    break;
                }

                if (!current.visited && !current.closed)
                {
                    current.visited = true;

                    foreach (var edge in current.edges)
                    {
                        var neigh = edge.end;


                        double t = vs[current].cost + edge.heft + Euclidian(neigh, e);

                        if (t < vs[neigh].cost)
                        {
                            vs[neigh] = (current, t);
                        }

                        heap.Insert(neigh);
                    }
                }
            }

            if (vs[e].parent == null)
            {
                return rtrn;
            }

            var cur = new KeyValuePair<Vertex<Point>, (Vertex<Point> parent, double cost)>(e, (vs[e].parent, vs[e].cost));

            while (cur.Key != s)
            {
                rtrn.Add(cur.Key);

                if (cur.Value.parent == null)
                {
                    break;
                }

                cur = new KeyValuePair<Vertex<Point>, (Vertex<Point> parent, double cost)>(cur.Value.parent, (vs[cur.Value.parent].parent, vs[cur.Value.parent].cost));
            }

            rtrn.Add(s);

            rtrn.Reverse();

            return rtrn;
        }
    }
}
