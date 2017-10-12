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
            Graph_AdjList graph = new Graph_AdjList();
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("D");

            graph.AddEdge("A", "B", 1);
            graph.AddEdge("A", "C", 55);
            graph.AddEdge("B", "C", 2);
            graph.AddEdge("C", "D", 3);
            graph.AddEdge("D", "A", 4);

            graph.Print();


            int a = graph.DelEdge("A", "B");

            graph.Print();

            Console.WriteLine("a = {0}", a);

            Console.ReadKey();
        }
    }
}
