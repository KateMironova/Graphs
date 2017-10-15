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
            public List<Edge> edges = new List<Edge>();
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

        private List<Vertex> graph = new List<Vertex>();
        
        #region Add
        public void AddVertex(string name)
        {
            if (graph.FirstOrDefault((x) => x.name == name) == null)
            {
                graph.Add(new Vertex(name));
            }
        }

        public void AddEdge(string from, string to, int val)
        {
            Vertex vFrom = graph.FirstOrDefault((x) => x.name == from);
            Vertex vTo = graph.FirstOrDefault((x) => x.name == to);
                        
            if (vFrom == null)
            {
                AddVertex(from);
                vFrom = graph.FirstOrDefault((x) => x.name == from);
            }
            if (vTo == null)
            {
                AddVertex(to);
                vTo = graph.FirstOrDefault((x) => x.name == to);
            }
            // ! проверка на наличие edge между этими пунктами
            if (GetEdgeRef(from, to) == null)
            {
                Edge newEdge = new Edge(vFrom, vTo, val);
                vFrom.edges.Add(newEdge);
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
            foreach (var v in graph)
            {
                v.edges.RemoveAll((x) => x.to == vertex);
            }
        }
        
        public int DelEdge(string from, string to)
        {
            Edge edge = GetEdgeRef(from, to);
            if (edge == null)
                throw new KeyNotFoundException();

            int w = edge.distance;
            edge.from.edges.Remove(edge);
            return w;
        }
        
        #endregion

        public void Print()
        {
            foreach (var vertex in graph)
            {
                Console.WriteLine("From {0}:", vertex.name);
                foreach (var edge in vertex.edges)
                {
                    Console.WriteLine("\t to {0}: {1}", edge.to.name, edge.distance);
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
            Vertex vertex = graph.FirstOrDefault((x) => x.name == name);
           
            return vertex;
        }
        private Edge GetEdgeRef(string from, string to)
        {
            Edge edgeRef = null;
            Vertex vFrom = GetVertexRef(from);
            Vertex vTo = GetVertexRef(to);

            if (vFrom == null || vTo == null)
                return null;

            foreach (var edge in vFrom.edges)
            {
                if (edge.to == vTo)
                {
                    edgeRef = edge;
                }
            }

            return edgeRef;
        }
        #endregion

        #region Count of Vertices and Edges
        public int Vertices()
        {
            return graph.Count();
        }
        public int Edges()
        {
            int count = 0;
            
            foreach (var vertex in graph)
            {
                foreach (var edge in vertex.edges)
                {
                    count++;
                }
            }
            return count;
        }

        #endregion

        #region Input and Output of Edges and Vertices
        public int GetInputEdgeCount(string city)
        {
            return GetInputVertexNames(city).Count;
        }

        public int GetOutputEdgeCount(string city)
        {
            return GetOutputVertexNames(city).Count;
        }
        public List<string> GetInputVertexNames(string city)
        {
            Vertex vertex = GetVertexRef(city);
            if (vertex == null)
                throw new KeyNotFoundException();

            List<string> list = new List<string>();
            foreach (Vertex v in graph)
            {
                foreach (Edge edge in v.edges)
                {
                    if (edge.to.name == city)
                        list.Add(edge.from.name);
                }
            }
            return list;
        }

        public List<string> GetOutputVertexNames(string city)
        {
            Vertex vertex = GetVertexRef(city);
            if (vertex == null)
                throw new KeyNotFoundException();

            List<string> list = new List<string>();
            foreach (Edge edge in vertex.edges)
            {
                list.Add(edge.to.name);
            }
            return list;
        }

        #endregion

        #region The Shortest Path 
        public List<string> ShortestPath(string from, string to)
        {
            throw new NotImplementedException();
        }

        public List<string> Dijkstra(string from, string to)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }     
}
