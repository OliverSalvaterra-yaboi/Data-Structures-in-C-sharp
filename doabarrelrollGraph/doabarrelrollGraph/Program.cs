using System;

namespace doabarrelrollGraph
{
    class Program
    {

        static void edge(Grape<int> graph, int a, int b)
        {
            graph.addEd(graph.Vertices[a], graph.Vertices[b]);
        }

        static void Main(string[] args)
        {
            Grape<int> graph = new Grape<int>(); 

            Random rnd = new Random();

            for(int i = 0; i < 5; i++)
            {
                Vertex<int> vert = new Vertex<int>(i);
                graph.addVert(vert);
            }

            edge(graph, 0, 1);
            edge(graph, 0, 2);
            edge(graph, 1, 3);
            edge(graph, 2, 4);
            edge(graph, 4, 3);
            edge(graph, 1, 2);

            Console.WriteLine(graph.depth(graph.Vertices[0], graph.Vertices[4]));
            Console.WriteLine(graph.depth(graph.Vertices[0], graph.Vertices[4]));


            Console.ReadKey();
        }
    }
}
