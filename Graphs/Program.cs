using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
                       
            //Graph_AdjList graph = new Graph_AdjList();
            Graph_AdjMatrix graph = new Graph_AdjMatrix();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");

            graph.AddEdge("A", "B", 1);
            graph.AddEdge("A", "C", 55);
            graph.AddEdge("B", "C", 2);
            graph.AddEdge("C", "D", 3);
            graph.AddEdge("D", "A", 4);
            graph.AddEdge("A", "D", 5);

            graph.Print();
            
            //Console.WriteLine(graph.GetInputEdgeCount("A"));
            //Console.WriteLine(graph.GetOutputEdgeCount("A"));

            //graph.DelVertex("C");
            //graph.Print();

            //int a = graph.DelEdge("A", "B");
            //graph.Print();
            //Console.WriteLine("delEdge = {0}", a);

            //int c = graph.GetEdge("D", "A");
            //Console.WriteLine("edge = {0}", c);

            //graph.SetEdge("B", "C", 1001);
            //Console.WriteLine("-------------------------");
            //graph.Print();

            //int e = graph.Edges();
            //Console.WriteLine("edges = {0}", e);

            //int v = graph.Vertices();
            //Console.WriteLine("edges = {0}", v);

            Console.ReadKey();


        }
    }
}
