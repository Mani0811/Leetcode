using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class MaximalSquareSolu : BaseClass
    {
        public override void Run()
        {
            var input = new char[][]
            {
            new char[]{'1' ,'0', '1', '0', '0'},
            new char[]{'1','0', '1','1', '1'},
            new char[]{'1' ,'1' ,'1', '1', '1'},
            new char[]{'1', '0', '0', '1', '0'},

            };
             input = new char[][]
            {

            };
            var output = MaximalSquare(input);
        }

        public int MaximalSquare(char[][] matrix)
        {
            int[][] dp = new int[matrix.Length + 1][];
            int output= int.MinValue;
            if (matrix.Length == 0) return 0;
            for (int i = 0; i <= matrix.Length; i++)
            {
                dp[i] = new int[matrix[0].Length + 1];
                if (i == 0)
                {
                    for (int j = 0; j < matrix[0].Length; j++)
                    {
                        dp[0][j] = 0;
                    }
                }
                else
                    dp[i][0] = 0;
              
            }
            for (int i = 1; i <= matrix.GetLength(0); i++)
            {
                for (int j = 1; j <= matrix[0].Length; j++)
                {
                    var item = matrix[i - 1][j - 1];
                    if (item == '1')
                        dp[i][j] = Math.Min(Math.Min(dp[i - 1][j - 1], dp[i][j - 1]), dp[i - 1][j]) + 1;
                    else
                        dp[i][j] = 0;
                    output = Math.Max(output, dp[i][j]);
                }

            }
            return output* output;
        }
    }
}
