using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GRAPHsofpolynomials
{
    class Graph<T> where T: IComparable<T>
    {
        public List<Vertex<T>> Vertices = new List<Vertex<T>>();

        public Vertex<T> search(T Value)
        {
            for(int i = 0; i < Vertices.Count; i++)
            {
                if(Value.CompareTo(Vertices[i].Value) == 0)
                {
                    return Vertices[i];
                }
            }
            return null;
        }

        public int indexOf(T Value)
        {
            int ind = default;
            for(int i = 0; i < Vertices.Count; i++)
            {
                if(Value.CompareTo(Vertices[i].Value) == 0)
                {
                    ind = i;
                    break;
                }
            }
            return ind;
        }

        public bool AddVer(T Value)
        {
            if(search(Value) != null)
            {
                return false;
            }
            else
            {
                Vertex<T> vert = new Vertex<T>(Value);
                Vertices.Add(vert);
                return true;
            }
        }

        public bool RemoveEd(T Vala, T Valb)
        {
            Vertex<T> A = search(Vala);
            Vertex<T> B = search(Valb);

            if (A == null || B == null) { return false; }

            else
            {
                if (!A.neighbors.Contains(B) || !B.neighbors.Contains(A)) { return false; }
                else { A.neighbors.Remove(B); B.neighbors.Remove(A); return true; }
            }
        }

        public bool RemoveVer(T Value)
        {
            if (search(Value) == null) { return false; }
            else
            {
                for(int i = 0; i < Vertices.Count; i++)
                {
                    RemoveEd(Value, Vertices[i].Value);
                }
                Vertices.Remove(Vertices[indexOf(Value)]);
                return true;
            }
        }

        public bool AddEd(T Vala, T Valb)
        {
            Vertex<T> A = search(Vala);
            Vertex<T> B = search(Valb);
            if (A == null || B == null) { return false; }

            if (A.neighbors.Contains(B)) { return false; }

            else { A.neighbors.Add(B); B.neighbors.Add(A); return true; }
        }

        public Stack<Vertex<T>> intoTheDepths()
        {
            Stack<Vertex<T>> poppy = new Stack<Vertex<T>>();
            bool[] visited = new bool[Vertices.Count];
            for(int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }

            int count = 0;
            while(true)
            {
                poppy.Push(Vertices[count]);
                visited[count] = true;
                for(int i = 0; i < Vertices[count].neighbors.Count; i++)
                {
                    if(visited[indexOf(Vertices[count].neighbors[i].Value)] == false)
                    {
                        count = indexOf(Vertices[count].neighbors[i].Value);
                        break;
                    }
                }

                bool traversed = false;
                for(int i = 0; i < visited.Length; i++)
                {
                    if (visited[i] == false) { traversed = false; break; }
                    else { traversed = true; }
                }
                if (traversed == true) { break; }

                count++;
            }

            return poppy;
        }

        public void Q()
        {
            Queue<Vertex<T>> qu = new Queue<Vertex<T>>();
            bool[] visited = new bool[Vertices.Count];
            for(int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            int count = 0;

            qu.Enqueue(Vertices[0]);
            visited[0] = true;
            while(true)
            {
                for(int i = 0; i < Vertices[count].neighbors.Count; i++)
                {
                    if(visited[indexOf(Vertices[count].neighbors[i].Value)] == false)
                    {
                        qu.Enqueue(Vertices[count].neighbors[i]);
                        visited[indexOf(Vertices[count].neighbors[i].Value)] = true;
                    }
                }
                qu.Dequeue();

                if(qu == null)
                {
                    break;
                }
            }
        }
    }
}
