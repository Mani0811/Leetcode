using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class IslandPerimeterSolu : BaseClass
    {
        public override void Run()
        {
            var input = new int[][]
            {
             new int[] {0, 1, 0, 0 },
             new int[] {1, 1, 1, 0 },
             new int[]{0, 1, 0, 0},
             new int[]{1, 1, 0, 0 }
            };
            var output = IslandPerimeter(input);
        }

        public int IslandPerimeter(int[][] grid)
        {
            int n = grid.Length;
            int[][] negibours = new int[grid.Length][];
            int total = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                var k = grid[i].Length;
                negibours[i] = new int[grid[i].Length];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != 1) continue;
                    var count = 0;
                    if (IsValid(grid, i - 1, j, k))
                        count++;
                    if (IsValid(grid, i + 1, j, k))
                        count++;
                    if (IsValid(grid, i, j - 1, k))
                        count++;
                    if (IsValid(grid, i, j + 1, k))
                        count++;
                    negibours[i][j] = 4 - count;
                    total += negibours[i][j];
                }
            }
            return total;
        }
        static bool IsValid(int[][] grid, int i, int j, int k)
        {
            if (i >= 0 && i < grid.Length && j >= 0 && j < k && grid[i][j] == 1)
                return true;
            return false;
        }
    }
}
