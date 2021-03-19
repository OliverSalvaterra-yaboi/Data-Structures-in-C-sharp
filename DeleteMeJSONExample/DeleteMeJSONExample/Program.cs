using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.Json;

namespace DeleteMeJSONExample
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

    class Program
    {
        static void Main(string[] args)
        {
            var graphInfoSerialized = File.ReadAllText("graphInfo.json");
            var graphInfo = JsonSerializer.Deserialize<GraphInfo>(graphInfoSerialized);

            ;


            //var graphInfo = new GraphInfo()
            //{
            //    Vertices = new List<Point>()
            //    {
            //        new Point(1, 1),
            //        new Point(1, 2),
            //        new Point(2, 1)
            //    },
            //    Connections = new List<Connection>()
            //    {
            //        new Connection()
            //        {
            //            A = new Point(1, 1),
            //            B = new Point(1, 2),
            //            Weight = 1
            //        },
            //        new Connection()
            //        {
            //            A = new Point(1, 1),
            //            B = new Point(2, 1),
            //            Weight = 3
            //        }
            //    }
            //};


            //var graphInfoSerialized = JsonSerializer.Serialize(graphInfo);
            //File.WriteAllText("graphInfo.json", graphInfoSerialized);
        }
    }
}
