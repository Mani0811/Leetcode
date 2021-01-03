using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class RotateMatrix :BaseClass
    {
        public override void Run()
        {
            base.Run();
             int[][] A = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9},
            };
            Rotate(A);
        }

        public void Rotate(int[][] mat)
        {
            int N = mat.Length;
            for (int x = 0; x < N / 2; x++)
            {
                // Consider elements in group 
                // of 4 in current square 
                for (int y = x; y < N - x - 1; y++)
                {
                    // Store current cell in 
                    // temp variable 
                    int temp = mat[x][y];

                    // Move values from right to top 
                    mat[x][y] = mat[y][N - 1 - x];

                    // Move values from bottom to right 
                    mat[y][N - 1 - x]
                        = mat[N - 1 - x][N - 1 - y];

                    // Move values from left to bottom 
                    mat[N - 1 - x][N - 1 - y]
                        = mat[N - 1 - y][x];

                    // Assign temp to left 
                    mat[N - 1 - y][x] = temp;
                }
            }

        }
    }
}

