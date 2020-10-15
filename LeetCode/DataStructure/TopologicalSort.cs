
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructure
{
    class TopologicalSet : BaseClass
    {
        public sealed override void Run()
        {

            var g = new Graph(5);

            g.AddEdge(1, 0);
            g.AddEdge(0, 2);
            g.AddEdge(2, 0);
            g.AddEdge(0, 3);
            g.AddEdge(3, 4);

            if (g.IsCyclic(5,g))
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't contains cycle");

            var g2 = new Graph(3);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            if (g2.IsCyclic(3,g2))
                Console.WriteLine("Graph contains cycle");
            else
                Console.WriteLine("Graph doesn't contains cycle");
        }

        // DFS with stack.
        int[] Topological_Sort(int n, int[][] adj)
        {
            // Time Complexity O(v+e)


            var graph = new Graph(n);
            for (int i = 0; i < adj.Length; i++)
            {
                graph.adj[adj[i][0]].Add(adj[i][1]);
            }

          
            var topoList = new Stack<int>();
            var visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    DFS(i, graph, visited, topoList);
                }
            }
            return topoList.ToArray();
        }

        private void DFS(int i, Graph graph, bool[] visited, Stack<int> topoList)
        {
            var edges = graph.adj[i];

            for (int j = 0; j < edges.Count; j++)
            {
                var vert = edges[j];
                if (visited[vert]) continue;
                DFS(vert, graph, visited, topoList);
                topoList.Push(vert);
            }
        }
    }

    // using adjacency list representation  
    internal class Graph
    {

        // No. of vertices  
        public int V;
 
        public List<List<int>> adj;

        //Constructor  
        internal Graph(int v)
        {
            V = v;
            adj = new List<List<int>>(v);
            for (int i = 0; i < v; i++)
                adj.Add(new List<int>());
        }

        private bool IsCyclicUtil(int i, bool[] visited, bool[] recStack)
        {
            if (recStack[i])
                return true;

            if (visited[i])
                return false;

            visited[i] = true;

            recStack[i] = true;
            List<int> children = adj[i];

            foreach (int c in children)
                if (IsCyclicUtil(c, visited, recStack))
                    return true;

            recStack[i] = false;

            return false;
        }
        internal bool IsCyclic(int n, Graph graph)
        {

            bool[] visited = new bool[n];
            bool[] recStack = new bool[n];


            // Call the recursive helper function to 
            // detect cycle in different DFS trees 
            for (int i = 0; i < n; i++)
                if (IsCyclicUtil(i, visited, recStack))
                    return true;

            return false;

        }
        internal void AddEdge(int sou, int dest)
        {
            adj[sou].Add(dest);
        }
    }
}
