using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Graph_AdjMatrix : IGraph
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

        private static int size = 25;
        private List<Vertex> vertices = new List<Vertex>();
        private Edge[,] matrix = new Edge[size, size];

        #region Add
        public void AddVertex(string name)
        {
            if (GetVertexRef(name) != null)
                return;

            vertices.Add(new Vertex(name));
        }

        public void AddEdge(string from, string to, int val)
        {
            Vertex vFrom = GetVertexRef(from);
            Vertex vTo = GetVertexRef(to);

            if (vFrom == null)
            {
                AddVertex(from);
                vFrom = GetVertexRef(from);
            }
            if (vTo == null)
            {
                AddVertex(to);
                vTo = GetVertexRef(to);
            }

            matrix[vertices.IndexOf(vFrom), vertices.IndexOf(vTo)] = new Edge(vFrom, vTo, val);
        }
        #endregion

        #region Delete
        public void DelVertex(string name)
        {
            Vertex vertex = GetVertexRef(name);
            if (vertex == null)
                throw new KeyNotFoundException();

            for (int i = 0; i <= size; i++)
            {
                matrix[vertices.IndexOf(vertex), i] = null;
                matrix[i, vertices.IndexOf(vertex)] = null;
            }
            vertices.Remove(vertex);
        }

        public int DelEdge(string from, string to)
        {
            Vertex vFrom = GetVertexRef(from);
            Vertex vTo = GetVertexRef(to);
            
            if (vFrom == null || vTo == null)
                throw new KeyNotFoundException();

            int w = matrix[vertices.IndexOf(vFrom), vertices.IndexOf(vTo)].distance;
            matrix[vertices.IndexOf(vFrom), vertices.IndexOf(vTo)] = null;
            return w;
        }

        #endregion

        public void Print()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] != null)
                        Console.WriteLine("From {0} to {1}: {2}", vertices[i].name, vertices[j].name, matrix[i, j].distance);
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
            Vertex vertex = vertices.FirstOrDefault((x) => x.name == name);

            return vertex;
        }
        private Edge GetEdgeRef(string from, string to)
        {
            Edge edgeRef = null;
            Vertex vFrom = GetVertexRef(from);
            Vertex vTo = GetVertexRef(to);

            if (vFrom == null || vTo == null)
                return null;

            edgeRef = matrix[vertices.IndexOf(vFrom), vertices.IndexOf(vTo)];

            return edgeRef;
        }
        #endregion

        #region Count of Vertices and Edges
        public int Vertices()
        {
            return vertices.Count();
        }
        public int Edges()
        {
            int count = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrix[i, j] != null)
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
            for (int i = 0; i < size; i++)
            {
                if (matrix[i, vertices.IndexOf(vertex)] != null)
                    list.Add(matrix[i, vertices.IndexOf(vertex)].to.name);
            }
            return list;
        }

        public List<string> GetOutputVertexNames(string city)
        {
            Vertex vertex = GetVertexRef(city);
            if (vertex == null)
                throw new KeyNotFoundException();

            List<string> list = new List<string>();
            for (int i = 0; i < size; i++)
            {
                if (matrix[vertices.IndexOf(vertex), i] != null)
                    list.Add(matrix[vertices.IndexOf(vertex), i].to.name);
            }
            return list;
        }
        #endregion
    }
}
