//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace LeetCode.Medium
//{
//    class MinimumFallingPathSum : BaseClass
//    {

//        public override void Run()
//        {
//            base.Run();
//            var solu = new Solution();
//            var resu = solu.MinFallingPathSum(new int[][]
//            {
//                new int[] {2,1,3 },
//                new int[] { 6,5,4},
//                new int[] { 7,8,9}
//            }
//            );
//        }


//        public class Solution
//        {
//            //47-23 
//            int m = 0;
//            int n = 0;
//            int minsum = int.MaxValue;
//            int[] rc = new int[] { 1, 1, 1 };
//            int[] cc = new int[] { -1, 0, 1 };
//            bool[,] visited;

           
//            }
//            public int MinFallingPathSum(int[][] matrix)
//            {


//                m = matrix.Length;
//                n = matrix[0].Length;


//                for (int i = 0; i < m; i++)
//                {
//                    for (int j = 0; j < n; j++)
//                    {
//                        visited = new bool[m, n];
//                        Helper(matrix, i, j, matrix[i][j]);
//                    }
//                }
//                return minsum;
//            }

//            public void Helper(int[][] matrix, int i, int j, int sum)
//            {
//                int r = i;
//                int c = j;


//                for (int k = 0; k < 3; k++)
//                {
//                    visited[r, c] = true;

//                    int rt = r + rc[k];
//                    int ct = c + cc[k];

//                    if (IsValid(rt, ct) && !visited[rt, ct] && matrix[rt][ct] > matrix[r][c])
//                    {
//                        sum = sum + matrix[rt][rt];
//                        Helper(matrix, rt, ct, sum);
//                        minsum = Math.Min(sum, minsum);
//                    }
//                }
//                return;
//            }

//            public bool IsValid(int i, int j)
//            {
//                return (i >= 0 && i < m && j >= 0 && j < n);
//            }


//        }
//    }
//}