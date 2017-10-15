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

        #region The Shortest Path 
        public List<string> ShortestPath(string from, string to)
        {
            return null;
        }
        private List<string> Dijkstra(string from, string to)
        {
            List<string> path = new List<string>();

            Vertex vFrom = GetVertexRef(from);
            Vertex vTo = GetVertexRef(to);

            string[] dist = new string[Vertices()]; // массив найденных кратчайших путей, индексы - вершины графа
            string[] prev = new string[Vertices()];//вершины предшествующие i-й вершине на кратчайшем пути
            bool[] visited = new bool[Vertices()];
            string InfStr = "INF";

            for (int i = 0; i < Vertices(); i++)
            {
                dist[i] = InfStr; // массив путей инициализируется бесконечностью
                visited[i] = true;
            }
            dist[0] = "";
            string minindex = "";
            string min = "";
            //do
            //{ // исполнение алгоритма 
            //    minindex = InfStr;
            //    min = InfStr;
            //    for (int i = 0; i < Vertices(); i++)
            //    {
            //        if ((visited[i] == true) && (dist[i] != min))
            //        {
            //            min = dist[i];
            //            minindex = i.ToString();
            //        }
            //    }
            //    if (minindex != InfStr)
            //    {
            //        for (int i = 0; i < Vertices(); i++)
            //        {
            //            if (a[minindex, i] > 0)
            //            {
            //                int temp = min + a[minindex][i];
            //                if (temp < dist[i])
            //                    dist[i] = temp;
            //            }
            //        }
            //        visited[minindex] = 0;
            //    }
            //} while (minindex < int.MaxValue);

            return path;
        }
        #endregion
    }
}
