using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class SpiraLMatrix : BaseClass
    {
        public override void Run()
        {
            base.Run();

        }
        List<int> res;
        int[][] Matrix;
        public IList<int> SpiralOrder(int[][] matrix)
        {
            res = new List<int>();
            Matrix = matrix;
            int n = matrix.Length;
            int rowBegin = 0;
            int rowEnd = matrix.Length - 1;
            int colBegin = 0;
            int colEnd = matrix[0].Length - 1;
            while (rowBegin <= rowEnd && colBegin <= colEnd)
            {
                //Traverse Right
                for (int j = colBegin; j <= colEnd; j++)
                {
                    res.Add(matrix[rowBegin][j]);
                }
                rowBegin++;

                // Traverse Down
                for (int j = rowBegin; j <= rowEnd; j++)
                {
                    res.Add(matrix[j][colEnd]);
                }
                rowEnd--;
                if (rowBegin <= rowEnd)
                {
                    // Traverse Left
                    for (int j = colEnd; j >= colBegin; j--)
                    {
                        res.Add(matrix[rowEnd][j]);
                    }
                }
                rowBegin--;
                if (colBegin <= colEnd)
                {
                    // Traver Up
                    for (int j = rowEnd; j >= rowBegin; j--)
                    {
                        res.Add(matrix[j][colBegin]);
                    }
                }
                colBegin++;
            }
            return res;
        }
       
    }
}
