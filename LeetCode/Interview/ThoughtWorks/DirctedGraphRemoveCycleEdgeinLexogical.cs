using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class DirctedGraphRemoveCycleEdgeinLexogical : BaseClass
    {
        public override void Run()
        {

            var g2 = new UnDirectedGraph(3);
            g2.AddEdge(0, 1);
            g2.AddEdge(1, 2);
            g2.AddEdge(2, 0);

            var result = g2.isCyclic();


        }

        internal class UnDirectedGraph
        {
            int V;
            List<int>[] adj;
            public UnDirectedGraph(int v)
            {
                V = v;
                adj = new List<int>[V];
                for (int i = 0; i < v; i++)
                {
                    adj[i] = new List<int>();
                }

            }

            internal void AddEdge(int s, int d)
            {
                adj[s].Add(d);
                adj[d].Add(s);
            }

            internal bool isCyclic()
            {
                bool[] visited = new bool[V];
                for (int u = 0; u < V; u++)
                    if (!visited[u])
                        if (isCyclicUtil(u, visited, -1))
                            return true;

                return false;
            }

            bool isCyclicUtil(int v, bool[] visited,
                         int parent)
            {
                visited[v] = true;

                foreach (int i in adj[v])
                {
                    if (!visited[i])
                    {
                        if (isCyclicUtil(i, visited, v))
                            return true;
                    }

                    // If an adjacent is visited and  
                    // not parent of current vertex, 
                    // then there is a cycle. 
                    else if (i != parent)
                        return true;
                }
                return false;
            }
        }
    }
}
