using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class TopologicalSortKhansAlgo : BaseClass
    {
        public override void Run()
        {
            var g = new Graph(6);
            g.addEdge(5, 2);
            g.addEdge(5, 0);
            g.addEdge(4, 0);
            g.addEdge(4, 1);
            g.addEdge(2, 3);
            g.addEdge(3, 1);
            g.topologicalSort();
        }

        internal class Graph
        {

            // No. of vertices  
            internal int V;

            // Adjacency List as ArrayList 
            // of ArrayList's  
            internal List<int>[] adj;

            internal Graph(int v)
            {
                V = v;
                adj = new List<int>[v];
                for (int i = 0; i < v; i++)
                    adj[i] = new List<int>();
            }

            internal void addEdge(int s, int d)
            {
                adj[s].Add(d);
            }

            public bool topologicalSort()
            {
                int[] indegree = new int[V];

                //this step takes O(v+e) time 
                for (int i = 0; i < V; i++)
                {
                    var childern = adj[i];
                    foreach (var node in childern)
                    {
                        indegree[node]++;
                    }
                }

                Queue<int> zeroInOrderNodeQueue = new Queue<int>();
                for (int i = 0; i < V; i++)
                {
                    if (indegree[i] == 0)
                        zeroInOrderNodeQueue.Enqueue(i);
                }

                int cnt = 0;

                var topologicalOrder = new List<int>();
                while (zeroInOrderNodeQueue.Count > 0)
                {
                    int u = zeroInOrderNodeQueue.Dequeue();
                    topologicalOrder.Add(u);

                    var childern = adj[u];
                    foreach (var node in childern)
                    {
                        if (--indegree[node] == 0)
                        {
                            zeroInOrderNodeQueue.Enqueue(node);
                        }
                    }
                    cnt++;
                }

                if (cnt != V)
                {

                    return false;
                }

                return true;


            }
        }
    }
}
