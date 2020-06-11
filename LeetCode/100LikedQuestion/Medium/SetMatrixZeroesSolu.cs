using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class SetMatrixZeroesSolu : BaseClass

    {
        public override void Run()
        {
            var input = new int[3][]
            {
               new int[]  {0,1,2,0 },
               new int[] { 3, 4, 5, 2 },
               new int[]{ 1, 3, 1, 5}
            };
            var input1 = new int[1][]
            {
               new int[]  {0,1},
               
            };
            SetZeroes(input1);
            base.Run();
        }

        public void SetZeroes(int[][] matrix)
        {
            var rows = new HashSet<int>();
            var cloums = new HashSet<int>();
            for (int i = 0; i < matrix.Length; i++)
            {
                var item = matrix[i];
                for (int j = 0; j < item.Length ; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cloums.Add(j);
                    }

                }

            }
            for (int i = 0; i < matrix.Length; i++)
            {
                var item = matrix[i];

                for (int j = 0; j < item.Length; j++)
                {
                    if (rows.Contains(i)|| cloums.Contains(j))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
            
        }
    }
}
