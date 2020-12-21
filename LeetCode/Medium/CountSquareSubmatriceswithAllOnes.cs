using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class CountSquareSubmatriceswithAllOnes : BaseClass
    {
        public override void Run()
        {
            int[][] inp = new int[][]
            {
                new int[]{0, 1, 1, 1 },
                new int[]{1, 1, 1, 1 },
                new int[]{0, 1, 1, 1 }
            };
            var c = CountSquares(inp);
        }

        public int CountSquares(int[][] matrix)
        {
            var n = matrix.Length;
            int[][] dp = new int[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new int[n];
            }
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        if (i != 0 && j != 0)
                        {
                            var cv = Math.Min(Math.Min(dp[i - 1][j], dp[i][j - 1]), dp[i - 1][j - 1]);
                            res += cv;
                            dp[i][j] = cv;
                        }
                        else

                            res += 1;
                    }
                }
            }
            return res;
        }
    }
}
