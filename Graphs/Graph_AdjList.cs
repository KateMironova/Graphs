using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph_AdjgrList : IGraph
    {
        public class Vertex
        {
            public string name;
            public Vertex(string name)
            {
                this.name = name;
            }
        }
        public class Edge
        {
            public Vertex from;
            public Vertex to;
            public int distance;
            public Edge(Vertex from, Vertex to, int distance)
            {
                this.from = from;
                this.to = to;
                this.distance = distance;
            }
        }

        private Dictionary<Vertex, List<KeyValuePair<Vertex, Edge>>> grList = new Dictionary<Vertex, List<KeyValuePair<Vertex, Edge>>>();

        public void AddVertex(string name)
        {
            if (grList.Keys.FirstOrDefault((x) => x.name == name) == null)
            {
                grList.Add(new Vertex(name), new List<KeyValuePair<Vertex, Edge>>());
            }
        }

        public void AddEdge(string from, string to, int val)
        {
            Vertex vFrom = grList.Keys.First((x) => x.name == from);
            Vertex vTo = grList.Keys.FirstOrDefault((x) => x.name == to);
            
            if (vFrom == null)
            {
                AddVertex(from);
                vFrom = grList.Keys.First((x) => x.name == from);
            }
            if (vTo == null)
            {
                AddVertex(to);
                vTo = grList.Keys.FirstOrDefault((x) => x.name == to);
            }
            grList[vFrom].Add(new KeyValuePair<Vertex, Edge>(vTo, new Edge(vFrom, vTo, val)));

        }
        public void DelVertex(string name)
        {
            Vertex vDel = grList.Keys.First((x) => x.name == name);
            grList.Remove(vDel);
        }

        public int DelEdge(string from, string to)
        {

            throw new NotImplementedException();
        }

        public void Print()
        {
            foreach (var keyValuePair in grList)
            {
                Console.WriteLine("From {0}:", keyValuePair.Key.name);
                foreach (var item in keyValuePair.Value)
                {
                    Console.WriteLine("\t to {0}: {1}", item.Key.name, item.Value.distance);
                }
            }
        }

        public int GetEdge(string from, string to)
        {
            throw new NotImplementedException();
        }

        public void SetEdge(string from, string to)
        {
            throw new NotImplementedException();
        }
    }
}
