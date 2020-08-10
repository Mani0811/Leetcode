
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DataStructure
{
    class TopologicalSet : BaseClass
    {
        public sealed override void Run()
        {
            base.Run();
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
            var eadges = graph.adj[i];

            for (int j = 0; j < eadges.Count; j++)
            {
                var vert = eadges[j];
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

        // Adjacency List as ArrayList 
        // of ArrayList's  
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
        private bool IsCyclic(int n, Graph graph)
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
        private void AddEdge(int sou, int dest)
        {
            adj[sou].Add(dest);
        }
    }
}
