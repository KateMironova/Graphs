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

        #region Add
        public void AddVertex(string name)
        {            
            if (graph.Keys.FirstOrDefault((x) => x.name == name) == null)
            {
                graph.Add(new Vertex(name), new Dictionary<Vertex, Edge>());
            }
        }

        public void AddEdge(string from, string to, int val)
        {
            Vertex vFrom = graph.Keys.First((x) => x.name == from);
            Vertex vTo = graph.Keys.FirstOrDefault((x) => x.name == to);
                        
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
            // ! проверка на наличие edge между этими пунктами
            if (GetEdgeRef(from, to) == null)
            {
                Edge newEdge = new Edge(vFrom, vTo, val);
                graph[vFrom].Add(vTo, newEdge);
                graph[vTo].Add(vFrom, newEdge);
            }
        }
        #endregion

        #region Delete
        public void DelVertex(string name)
        {
            Vertex vertex = GetVertexRef(name);
            if (vertex == null)
                throw new KeyNotFoundException();

            graph.Remove(vertex);
            foreach (var item in graph)
            {
                item.Value.Remove(vertex);
            }
        }
        
        public int DelEdge(string from, string to)
        {
            Edge edge = GetEdgeRef(from, to);
            if (edge == null)
                throw new KeyNotFoundException();

            int w = edge.distance;
            graph[edge.from].Remove(edge.to);
            graph[edge.to].Remove(edge.from);
            return w;
        }
        
        #endregion

        public void Print()
        {
            foreach (var pair in graph)
            {
                Console.WriteLine("From {0}:", pair.Key.name);
                foreach (var item in pair.Value)
                {
                    Console.WriteLine("\t to {0}: {1}", item.Key.name, item.Value.distance);
                }
            }
        }

        #region Get_Set_Edge
       
        public int GetEdge(string from, string to)
        {
            Edge edge = GetEdgeRef(from, to);
            if (edge == null)
                throw new KeyNotFoundException();

            return edge.distance;
        }

        public void SetEdge(string from, string to, int val)
        {
            Edge edge = GetEdgeRef(from, to);
            if (edge == null)
                throw new KeyNotFoundException();

            edge.distance = val;
        }
        #endregion

        #region Get/Set_Ref function
        private Vertex GetVertexRef(string name)
        {
            Vertex vertex = null;
            foreach (var item in graph)
            {
                if (item.Key.name == name)
                    vertex = item.Key;
            }
            return vertex;
        }
        private Edge GetEdgeRef(string from, string to)
        {
            Edge edge = null;
            foreach (var pair in graph)
            {
                if (pair.Key.name == from)
                {
                    foreach (var pair2 in pair.Value)
                    {
                        if (pair2.Key.name == to)
                            edge = pair2.Value;
                    }
                }
            }
            return edge;
        }
        #endregion

        public int Vertexes()
        {
            return graph.Count();
        }
        public int Edges()
        {
            int count = 0;

            foreach (var item in graph)
            {
                foreach (var item2 in item.Value)
                {
                    if (GetEdgeRef(item.Key.name, item2.Key.name) != null)
                        count++;
                }
            }
            return count/2;
        }
    }     
}
