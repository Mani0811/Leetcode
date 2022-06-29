using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Assesment
{
    class CutOffTreesforGolfEvent : BaseClass
    {
        public override void Run()
        {
            base.Run();
        }

        public int CutOffTree(IList<IList<int>> forest)
        {
            if (forest[0][0] == 0)
                return -1;

            List<int[]> trees = new List<int[]>();

            for (int i = 0; i < forest.Count; i++)
            {
                for (int j = 0; j < forest[0].Count; j++)
                {
                    if (forest[i][j] > 1)
                        trees.Add(new int[] { i, j, forest[i][j] });
                }
            }

            trees.Sort((x, y) => x[2].CompareTo(y[2]));
            int minWalks = 0;
            int sr = 0;
            int sc = 0;

            foreach (var tree in trees)
            {
                int dis = Bfs(forest, sr, sc, tree[0], tree[1]);

                if (dis < 0)
                    return -1;

                minWalks += dis;
                sr = tree[0];
                sc = tree[1];
            }


            return minWalks;
        }

        private int Bfs(IList<IList<int>> forest, int sr, int sc, int dr, int dc)
        {
            int[,] visited = new int[forest.Count, forest[0].Count];
            Queue<(int x, int y)> qu = new Queue<(int x, int y)>();
            qu.Enqueue((sr, sc));
            visited[sr, sc] = 1;
            int minWalks = 0;
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            while (qu.Count > 0)
            {
                int cnt = qu.Count;

                for (int i = 0; i < cnt; i++)
                {
                    var cur = qu.Dequeue();

                    if (cur.x == dr && cur.y == dc)
                    {
                        return minWalks;
                    }

                    for (int d = 0; d < 4; d++)
                    {
                        int x = cur.x + dx[d];
                        int y = cur.y + dy[d];

                        if (IsValid(forest, x, y) && forest[x][y] > 0 && visited[x, y] == 0)
                        {
                            visited[x, y] = 1;
                            qu.Enqueue((x, y));
                        }
                    }
                }
                minWalks++;
            }
            return -1;
        }

        private bool IsValid(IList<IList<int>> forest, int x, int y)
        {
            if (x < 0 || x >= forest.Count || y < 0 || y >= forest[0].Count)
                return false;
            return true;
        }
    }
}
