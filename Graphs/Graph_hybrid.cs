using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph_hybrid : IGraph
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



        public void AddEdge(string from, string to, int val)
        {
            throw new NotImplementedException();
        }

        public void AddVertex(string name)
        {
            throw new NotImplementedException();
        }

        public int DelEdge(string from, string to)
        {
            throw new NotImplementedException();
        }

        public void DelVertex(string name)
        {
            throw new NotImplementedException();
        }

        public int GetEdge(string from, string to)
        {
            throw new NotImplementedException();
        }

        public void Print()
        {
            throw new NotImplementedException();
        }

        public void SetEdge(string from, string to, int val)
        {
            throw new NotImplementedException();
        }

        public int Vertexes()
        {
            throw new NotImplementedException();
        }

        public int Edges()
        {
            throw new NotImplementedException();
        }

        public int GetInputEdgeCount(string city)
        {
            throw new NotImplementedException();
        }

        public int GetOutputEdgeCount(string city)
        {
            throw new NotImplementedException();
        }

        public List<string> GetInputVertexNames(string city)
        {
            throw new NotImplementedException();
        }

        public List<string> GetOutputVertexNames(string city)
        {
            throw new NotImplementedException();
        }
    }
}
