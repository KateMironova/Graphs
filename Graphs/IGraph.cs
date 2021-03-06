﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public interface IGraph
    {
        void AddVertex(string name);
        void AddEdge(string from, string to, int val);
        void DelVertex(string name);
        int DelEdge(string from, string to);
        void Print();
        int GetEdge(string from, string to);
        void SetEdge(string from, string to, int val);
        int Vertices();
        int Edges();
        int GetInputEdgeCount(string city);
        int GetOutputEdgeCount(string city);
        List<string> GetInputVertexNames(string city);
        List<string> GetOutputVertexNames(string city);
        List<string> ShortestPath(string from, string to);
    }
}
