using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace LeetCode.Interview.NationalInstrument
{
    public class Class1 : BaseClass
    {
        public override void Run()
        {
            base.Run();
            solve(6,7,new string[] { "***.*.*", "..*.*.*", "*.*.*.*", "*.*.*.*", "..*...*", "*******" });
        }

        //static void solve(int N, int M, int [] squads)
        //{
        //    Console.WriteLine("Ram");
        //}

        static void solve(int n, int k, string[] arr)
        {
            char[][] h = new char[n][];
            for (int i = 0; i < n; i++)
            {
                h[i] = arr[i].ToCharArray();
            }
            int[] dx = new int[] { -1, 0, 0, 1, 1, 0, 0, -1 };
            int[] dy = new int[] { 0, 1, 1, 0, 0, -1, -1, 0 };

            Queue<int> X = new Queue<int>();
            Queue<int> Y = new Queue<int>();
            bool[][] vis = new bool[n][];
            for (int i = 0; i <n; i++)
            {
                vis[i] = new bool[k];
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    if (h[i][j] == '.' && !vis[i][j])
                    {
                        X.Enqueue(i);
                        Y.Enqueue(j);
                        while (X.Count != 0)
                        {
                            int curX = X.Dequeue();
                            int curY = Y.Dequeue();
                            vis[curX][curY] = true;

                            for (int m = 0; m < 8; m += 2)
                            {
                                int cntStar = 0;
                                int pX = 0;
                                int pY = 0;
                                bool flag = false;
                                for (int l = m; l <= m + 1; l++)
                                {
                                    for (int d = m; d <= m + 1; d++)
                                    {
                                        int x = curX + dx[l];
                                        int y = curY + dy[d];
                                        if (x < 0 || x >= n || y < 0 || y >= k)
                                        {
                                            flag = true;
                                            break;
                                        }
                                        if (h[x][y] == '*')
                                        {
                                            cntStar++;
                                            pX = x;
                                            pY = y;
                                        }

                                    }
                                }
                                if (!flag && cntStar == 1)
                                {
                                    h[pX][pY] = '.';
                                    X.Enqueue(pX);
                                    Y.Enqueue(pY);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
             Console.WriteLine(new string(h[i]));
            }

        }
    }
}
