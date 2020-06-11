using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LeetCode._100LikedQuestion.Medium
{
    class UniquePathsSolu : BaseClass
    {
        public override void Run()
        {
            var output = UniquePathsDP(3, 2);
            base.Run();
        }

        public int UniquePathsDP(int m, int n)
        {
            int[,] path = new int[m, n];
            for (int i=0;i<m;i++)
            {
                path[i, 0] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                path[0, i] = 1;
            }
            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    path[i, j] = path[i, j-1] + path[i - 1,j];
                }
            }
            return path[m - 1, n - 1];
        }

        int[] X = new int[] { +1 ,0};


        int[] Y = new int[] { +0, 1 };

        int M;
        int N;
        public int UniquePaths(int m, int n)
        {
            M = m;
            N = n;
            int count=0;
           return BFS(0, 0, count);
        }
        
        

        private int BFS(int x, int y, int count)
        {
            if (x == M - 1 && y == N - 1)
                count += 1;
            for (int i = 0; i < X.Length; i++)
            {
                var xnew = x + X[i];
                var ynew = y + Y[i];
                if (IsValid(xnew, ynew))
                {

                    count= BFS(xnew, ynew, count);
                }
            }
            return count;
        }

        public bool IsValid(int x, int y)
        {
            if (x < M && x >= 0 && y < N && y >=0) return true;
            return false;
        }

        /// <summary>
        /// 2nd soluation
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        static int UniquePathsRec(int m, int n)
        {
            // If either given row number is first or 
            // given column number is first 
            if (m == 1 || n == 1)
                return 1;

            // If diagonal movements are allowed then 
            // the last addition is required. 
           
            return UniquePathsRec(m-1, n) + UniquePathsRec(m, n -1);
            // + numberOfPaths(m-1, n-1); 
        }


    }
}
