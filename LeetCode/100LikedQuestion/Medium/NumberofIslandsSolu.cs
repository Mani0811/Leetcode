using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class NumberofIslandsSolu : BaseClass
    {
        public override void Run()
        {
            var grid = new char[][]
            {
                new char[]{'1','1','1','1','0'},
                new char[] {'1','1','0','1','0' },
                new char[]{'1','1','0','0','0'},
                new char[] { '0', '0', '0', '0', '0'}
            };
           var count  = NumIslands(grid);
            base.Run();

        }
        int[] x = new int[] { -1, 1, 0, 0 };
        int[] y = new int[] { 0, 0, 1, -1 };
        public int NumIslands(char[][] grid)
        {

            bool[][] visited = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
            {
                visited[i] = new bool[grid[0].Length];
            }
            int count = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    var value = grid[i][j];

                    if (!visited[i][j] && value == '1')
                    {
                        DFSUtil(i, j, visited, grid);
                        count = count + 1;
                    }

                }

            }
            return count;
        }

        private void DFSUtil(int i, int j, bool[][] visited, char[][] grid)
        {
            if (visited[i][j]) return;
            visited[i][j] = true;
            for (int k = 0; k < 4; k++)
            {
                var newi = x[k] + i;
                var newj = y[k] + j;

                if (!isValid(newi, newj, grid) || grid[i][j] != '1') continue;
                DFSUtil(newi, newj, visited, grid);
            }
        }


        private bool isValid(int newi, int newj, char[][] grid)
        {
            if (newi < grid.Length && newi >= 0 && newj < grid[newi].Length && newj >= 0)
                return true;
            return false;
        }
    }
}
