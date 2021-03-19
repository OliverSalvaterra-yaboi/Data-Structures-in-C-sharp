using System;
using System.Collections.Generic;
using System.Text;

using HeapsonHeaps;

namespace heftyGraph
{
    class Edge<T> 
    {
        public Vertex<T> start { get; set; }
        public Vertex<T> end { get; set; }
        public double heft { get; set; }

        public Edge(Vertex<T> start, Vertex<T> end, double heft)
        {
            this.start = start;
            this.end = end;
            this.heft = heft;
        }
    }

    class Vertex<T> 
    {
        public List<Edge<T>> edges { get; set; }
        public T key { get; set; }
        public int count { get; set; }
        public bool visited { get; set; }
        public double total { get; set; }
        public bool closed { get; set; }
        public double finalD { get; set; }
        public (int x, int y) xy { get; set; }

        public Vertex(T key)
        {
            edges = new List<Edge<T>>();
            count = 0;
            this.key = key;
            visited = false;
            total = 0;
            finalD = 0;
            closed = false;
        }

        public override string ToString()
        {
            return $"Val: {key}";
        }
    }

    class Graph<T>
    {
        public List<Vertex<T>> vertices = new List<Vertex<T>>();

        public IReadOnlyList<Edge<T>> Edges 
        { 
            get 
            {
                List<Edge<T>> rtrn = new List<Edge<T>>();
                foreach(Vertex<T> vert in vertices)
                {
                    foreach(Edge<T> ed in vert.edges)
                    {
                        rtrn.Add(ed);
                    }
                }

                return rtrn;
            } 
        }


        public Graph() { }

        public void addV(T val)
        {
            Vertex<T> vert = new Vertex<T>(val);
            if(vert != null && vert.edges.Count == 0 && vertices.Contains(vert) == false)
            {
                vertices.Add(vert);
            }
            else
            {
                throw new Exception("Vertex cannot be added");
            }
        }

        public bool removeV(Vertex<T> vert)
        {
            if(vert != null)
            {
                IReadOnlyList<Edge<T>> temp = Edges;
                for (int i = 0; i < temp.Count; i++)
                {
                    if(temp[i].end == vert)
                    {
                        removE(temp[i].start, temp[i].end);
                    }
                }
                vertices.Remove(vert);
                return true;
            }
            return false;
        }

        public bool addE(Vertex<T> start, Vertex<T> end, double heft)
        {
            List<Edge<T>> eds = (List<Edge<T>>)Edges;
            if(vertices.Contains(start) && vertices.Contains(end))
            {
                foreach(Edge<T> ed in eds)
                {
                    if(ed.start == start && ed.end == end)
                    {
                        return false;
                    }
                }
                Edge<T> eddy = new Edge<T>(start, end, heft);
                start.edges.Add(eddy);
                return true;
            }
            return false;
        }

        public bool removE(Vertex<T> a, Vertex<T> b)
        {
            if (a != null && b != null && vertices.Contains(a) && vertices.Contains(b))
            {
                for(int i = 0; i < a.edges.Count; i++)
                {
                    if(a.edges[i].end == b)
                    {
                        a.edges.RemoveAt(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public Vertex<T> search(T val)
        {
            for(int i = 0; i < vertices.Count; i++)
            {
                if(vertices[i].key.Equals(val))
                {
                    return vertices[i];
                }
            }
            return null;
        }

        public Edge<T> getEdge(Vertex<T> a, Vertex<T> b)
        {
            if(a != null && b != null)
            {
                for(int i = 0; i < a.edges.Count; i++)
                {
                    if(a.edges[i].end == b)
                    {
                        return a.edges[i];
                    }
                }
            }
            return null;
        }

        public List<T> DFS(T start, T end)
        {
            var startNode = search(start);
            var endNode = search(end);
            List<T> rtrn = new List<T>();


            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
            if (startNode == null || endNode == null) return rtrn;

            Stack<Vertex<T>> stack = new Stack<Vertex<T>>();
            stack.Push(startNode);
            Vertex<T> curr;

            while(stack.Count > 0)
            {
                curr = stack.Pop();
                
                if(curr == endNode)
                {
                    rtrn.Add(curr.key);
                    return rtrn;
                }

                if(visited.Contains(curr) == false)
                {
                    visited.Add(curr);

                    rtrn.Add(curr.key);

                    for(int i = 0; i < curr.edges.Count; i++)
                    {
                        stack.Push(curr.edges[i].end);
                    }
                }   
            }

            return new List<T>();
        }

        public List<T> BFS(T start, T end)
        {
            var startNode = search(start);
            var endNode = search(end);
            List<T> rtrn = new List<T>();

            Dictionary<Vertex<T>, Vertex<T>> pair = new Dictionary<Vertex<T>, Vertex<T>>();
            HashSet<Vertex<T>> visited = new HashSet<Vertex<T>>();
            if (startNode == null || endNode == null) return rtrn;

            Queue<Vertex<T>> q = new Queue<Vertex<T>>();
            q.Enqueue(startNode);
            visited.Add(startNode);
            pair[startNode] = null;
            Vertex<T> curr;
            Vertex<T> prev = null;

            while(q.Count > 0)
            {
                var temp = q.Dequeue();

                //rtrn.Add(temp.key);

                if (temp == endNode)
                {
                    break;
                }

                foreach (var edge in temp.edges)
                {
                    if (!visited.Contains(edge.end))
                    {
                        visited.Add(edge.end);
                        q.Enqueue(edge.end);
                        pair[edge.end] = temp;
                    }

                }
            }

            curr = endNode;
            while(pair[curr] != null)
            {
                rtrn.Add(curr.key);
                curr = pair[curr];
            }
            rtrn.Add(curr.key);
            rtrn.Reverse();

            return rtrn;

            //while (q.Count > 0)
            //{
                
            //    curr = q.Dequeue();

            //    if (curr == endNode)
            //    {
            //        //pair.Add(curr, prev);
            //        //while(pair[curr] != null)
            //        //{
            //        //    rtrn.Add(curr.key);
            //        //    curr = pair[curr]; 
            //        //}
            //        rtrn.Add(curr.key);
            //        rtrn.Reverse();

            //        return rtrn;
            //    }

            //    if (visited.Contains(curr) == false)
            //    {
            //        visited.Add(curr);
            //        //pair.Add(curr, prev);

            //        for (int i = 0; i < curr.edges.Count; i++)
            //        {
            //            q.Enqueue(curr.edges[i].end);

            //        }
            //    }
                
            //    prev = curr;
            //}
        }

        public bool BellFord()
        {
            Dictionary<Vertex<T>, (Vertex<T> parent, double cost)> vs = new Dictionary<Vertex<T>, (Vertex<T> parent, double cost)>();
            //Heap<double> heap = new Heap<double>(Comparer<double>.Create((a, b) => a.CompareTo(b)));

            var heap = new Heap<Vertex<T>>(Comparer<Vertex<T>>.Create((a, b) => a.total.CompareTo(b.total)));

            for (int i = 0; i < vertices.Count; i++)
            {
                vertices[i].visited = false;
                vs.Add(vertices[i], (null, double.MaxValue));
            }

            foreach(Vertex<T> v in vertices)
            {
                heap.Insert(v);
            }

            while (heap.Count > 0)
            {
                var current = heap.Pop();

                if (!current.visited && !current.closed)
                {
                    current.visited = true;

                    foreach (var edge in current.edges)
                    {
                        var neigh = edge.end;

                        double t = vs[current].cost + edge.heft;

                        if(t < vs[current].cost)
                        {
                            return true;
                        }

                        if (t < vs[neigh].cost)
                        {
                            vs[neigh] = (current, t);
                        }

                        heap.Insert(neigh);
                    }
                }
            }
            return false;
        }

        public List<T> Dijkstras(T start, T end)
        {
            Vertex<T> s = search(start);
            Vertex<T> e = search(end);
            List<T> rtrn = new List<T>();

            if (s.closed || e.closed) { return rtrn; }

            Dictionary<Vertex<T>, (Vertex<T> parent, double cost)> vs = new Dictionary<Vertex<T>, (Vertex<T> parent, double cost)>();
            //Heap<double> heap = new Heap<double>(Comparer<double>.Create((a, b) => a.CompareTo(b)));

            var heap = new Heap<Vertex<T>>(Comparer<Vertex<T>>.Create((a,b) => a.total.CompareTo(b.total)));

            for(int i = 0; i < vertices.Count; i++)
            {
                vertices[i].visited = false;
                vs.Add(vertices[i], (null, double.MaxValue));
            }

            vs[s] = (null, 0);

            heap.Insert(s);

            while(heap.Count > 0)
            {
                var current = heap.Pop();

                if(current == e)
                {
                    break;
                }

                if (!current.visited && !current.closed)
                {
                    current.visited = true;

                    foreach(var edge in current.edges)
                    {
                        var neigh = edge.end;


                        double t = vs[current].cost + edge.heft;

                        if(t < vs[neigh].cost)
                        {
                            vs[neigh] = (current, t);
                        }

                        heap.Insert(neigh);
                    }
                } 
            }

            if(vs[e].parent == null)
            {
                return rtrn;
            }

            var cur = new KeyValuePair<Vertex<T>, (Vertex<T> parent, double cost)>(e, (vs[e].parent, vs[e].cost));

            while (cur.Key != s)
            {
                rtrn.Add(cur.Key.key);

                if(cur.Value.parent == null)
                {
                    break;
                }

                cur = new KeyValuePair<Vertex<T>, (Vertex<T> parent, double cost)>(cur.Value.parent, (vs[cur.Value.parent].parent, vs[cur.Value.parent].cost));
            }

            rtrn.Add(s.key);

            rtrn.Reverse();

            return rtrn;
        }
    }
}
