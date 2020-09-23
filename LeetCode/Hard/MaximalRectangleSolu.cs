using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeetCode
{
    class MaximalRectangleSolu : BaseClass
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
                new char[]{'1'},
           };
            var output = MaximalRectangle(input);
        }

        public int MaximalRectangle(char[][] matrix)
        {
            var dp = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                dp[i] = new int[matrix[i].Length];
                if (i == 0)
                {
                    for (int j = 0; j < dp[0].Length; j++)
                    {
                        dp[0][j] = int.Parse(matrix[i][j].ToString());
                    }
                }
                dp[i][0] = int.Parse(matrix[i][0].ToString());
            }
            for (int i = 1; i < matrix.Length; i++)
            {
                for (int j = 1; j < matrix[i].Length; j++)
                {
                    dp[i][j] = int.Parse(matrix[i - 1][j].ToString()) + int.Parse(matrix[i][j].ToString());
                }
            }
            for (int i = 1; i < matrix.Length; i++)
            {
                CalculateMaximumAreaForRow(i, dp);
            }
            return maxArea;
        }
        int maxArea = 0;
        private void CalculateMaximumAreaForRow(int i, int[][] dp)
        {
            Stack<int> stack = new Stack<int>();
            int j = 0;
            for (j = 0; j < dp[i].Length;)
            {
                if (stack.Count == 0 || dp[i][stack.Peek()] <= dp[i][j])
                    stack.Push(j++);
                else
                {
                    CaculateArea(i, dp, stack,j);
                }
            }
            while (stack.Count > 0)
                CaculateArea(i, dp, stack,j);

        }

        private void CaculateArea(int i, int[][] dp, Stack<int> stack, int j)
        {
            int top = stack.Pop();
            int area;
            if (stack.Count == 0)
                area = dp[i][top] * j;
            else
                area = dp[i][top] * (j-stack.Peek()-1);
            maxArea = Math.Max(maxArea, area);
        }
    }
}
