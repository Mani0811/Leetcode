using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class RotateImageSolu : BaseClass
    {
        public override void Run()
        {
            var input = new int[3][]
            {
               new int[]  { 1, 2, 3 },
               new int[] { 4, 5, 6 },
               new int[]{ 7, 8, 9}
            };
            base.Run();
        }

        public void Rotate(int[][] matrix)
        {
            var length = matrix.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    var temp = matrix[i][j];
                   

                }

            }
        }
    }
}
