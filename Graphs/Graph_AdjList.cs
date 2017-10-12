using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph_AdjList : IGraph
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

        private Dictionary<Vertex, Dictionary<Vertex, Edge>> graph = new Dictionary<Vertex, Dictionary<Vertex, Edge>>();

        public void AddVertex(string name) //+
        {
            if (graph.Keys.FirstOrDefault((x) => x.name == name) == null)
            {
                graph.Add(new Vertex(name), new Dictionary<Vertex, Edge>());
            }
        }

        public void AddEdge(string from, string to, int val) //+ check!!
        {
            Vertex vFrom = graph.Keys.First((x) => x.name == from);
            Vertex vTo = graph.Keys.FirstOrDefault((x) => x.name == to);
            Edge newEdge = new Edge(vFrom, vTo, val);
            
            if (vFrom == null)
            {
                AddVertex(from);
                vFrom = graph.Keys.First((x) => x.name == from);
            }
            if (vTo == null)
            {
                AddVertex(to);
                vTo = graph.Keys.FirstOrDefault((x) => x.name == to);
            }
            // ! проверка на наличие edge меджу этими пунктами
            
            graph[vFrom].Add(vTo, newEdge);

        }
        public void DelVertex(string name) //-
        {
            Vertex vDel = graph.Keys.First((x) => x.name == name);
            graph.Remove(vDel);
        }

        public int DelEdge(string from, string to) //+
        {
           
            Vertex vFrom = graph.Keys.First((x) => x.name == from);
            Vertex vTo = graph.Keys.FirstOrDefault((x) => x.name == to);
            Edge delEdge = new Edge(vFrom, vTo, 0);

            if (vFrom != null && vTo != null)
            {
                if (graph[vFrom].FirstOrDefault(x => x.Key.name == to).Key != null)
                {
                    delEdge.distance = GetEdge(from, to);
                    Vertex Del = graph[vFrom].FirstOrDefault(x => x.Key.name == to).Key;
                    //graph[vFrom].Remove(GetLinkedVertexByName(from, to));
                    graph[vFrom].Remove(graph[vFrom].FirstOrDefault(x => x.Key.name == to).Key);
                }
            }
            return delEdge.distance;
        }
        
        //private Vertex GetLinkedVertexByName(string from, string to)
        //{
        //    Vertex vFrom = graph.FirstOrDefault(x => x.Key.name == from).Key;
        //    return graph[vFrom].FirstOrDefault(x => x.Key.name == to).Key;
        //}
        //private Vertex GetVertex(string name)
        //{
        //    return graph.FirstOrDefault(x => x.Key.name == name).Key;
        //}



        public void Print() //+
        {
            foreach (var keyValuePair in graph)
            {
                Console.WriteLine("From {0}:", keyValuePair.Key.name);
                foreach (var item in keyValuePair.Value)
                {
                    Console.WriteLine("\t to {0}: {1}", item.Key.name, item.Value.distance);
                }
            }
        }

        public int GetEdge(string from, string to) //+
        {
            int edge = 0;
            Vertex vFrom = graph.Keys.First((x) => x.name == from);
            Vertex vTo = graph.Keys.FirstOrDefault((x) => x.name == to);

            if (vFrom != null && vTo != null)
            {
                if (graph[vFrom].FirstOrDefault(x => x.Key.name == to).Key != null)
                {
                    edge = graph[vFrom].FirstOrDefault(x => x.Key.name == to).Value.distance;
                }
            }
            return edge;
        }

        public void SetEdge(string from, string to, int val)
        {
            throw new NotImplementedException();
        }
    }
}
