using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace heftyGraph
{
    class Program
    {
        struct Connection
        {
            public Point A { get; set; }
            public Point B { get; set; }
            public int Weight { get; set; }
        }

        struct GraphInfo
        {
            public List<Point> Vertices { get; set; }
            public List<Connection> Connections { get; set; }
        }

        static void Main(string[] args)
        {
            Graph<string> gg = new Graph<string>();
            Graph<Point> maze = new Graph<Point>();
            Random rnd = new Random();
            Astar Asearch = new Astar();

            string[] file = File.ReadAllLines("../../../AirportProblem.txt");

            var graphInfoSerialized = File.ReadAllText("graphInfo.json");
            var graphInfo = JsonSerializer.Deserialize<GraphInfo>(graphInfoSerialized);

            for (int i = int.Parse(file[0]) + 1; i < file.Length; i++)
            {
                string[] temp = file[i].Split(',');
                for(int j = 0; j < temp.Length; j++)
                {
                    if(j < 2)
                    {
                        if(gg.search(temp[j]) == null)
                        {
                            gg.addV(temp[j]);
                        }
                    }
                    else
                    {
                        gg.addE(gg.search(temp[0]), gg.search(temp[1]), double.Parse(temp[j]));
                    }
                }
            }

            foreach(Point p in graphInfo.Vertices)
            {
                maze.addV(p);
            }

            foreach(Connection c in graphInfo.Connections)
            {
                maze.addE(maze.search(c.A), maze.search(c.B), c.Weight);
            }

            List<string> path = gg.DFS("LAX", "SAN");

            List<string> otherPath = gg.BFS("SAN", "DTW");


            List<string> otherotherpath = gg.Dijkstras("PHL", "IND");
            //var heap = new HeapsonHeaps.Heap<int>();
            //heap.

            List<Vertex<Point>> Apath = Asearch.A(maze, new Point (2, 0), new Point (1, 2));

            maze.BellFord();
        }
    }
}
