using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.VMware
{
    class TicTocToe : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var m = new int[][] { new int[] { 1, 1 }, new int[] { 0, 1 } };
            CountSquares(m);
            var output1 = Generate(5);
            var x = new int[][] {
                new int[]{0, 0 },new int[]{1, 1 }, new int[] { 0, 1 }, new int[] { 0, 2 },
                new int[] { 1, 0 }, new int[] { 2, 0 }//, new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 2, 2 }
                                                      };
            var output = Tictactoe(x);
        }

        public int CountSquares(int[][] matrix)
        {
            int count = 0;
            int n = matrix.Length;

            int m = matrix[0].Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] >= 1)
                    {
                        count++;
                        if (j - 1 >= 0 && i - 1 >= 0 && i >= 0 && j >= 0 && matrix[i - 1][j] == matrix[i][j - 1] && matrix[i][j - 1] == matrix[i - 1][j - 1])
                            matrix[i][j] += 1;
                        count++;
                    }
                }
            }
            return count;
        }


        public string Tictactoe(int[][] moves)
        {

            int[] rowsp1 = new int[3];
            int[] colsp1 = new int[3];

            int[] rowsp2 = new int[3];
            int[] colsp2 = new int[3];

            int dia = 0;
            int anti = 0;

            int diab = 0;
            int antib = 0;
            for (int i = 0; i < moves.Length; i++)
            {

                var r = moves[i][0];
                var c = moves[i][1];
                if (i % 2 == 0)
                {

                    if (++rowsp1[r] == 3 || ++colsp1[c] == 3 || r == c && ++dia == 3 || r + c == 2 && ++anti == 3) return "A";
                    Console.WriteLine(dia);
                }
                else
                {
                    if (++rowsp2[r] == 3 || ++colsp2[c] == 3 || r == c && ++diab == 3 || r + c == 2 && ++antib == 3) return "B";
                }
            }
            return moves.Length == 9 ? "Draw" : "Pending";

        }

        public IList<IList<int>> Generate(int numRows)
        {

            var output = new List<IList<int>>(numRows);

            for (int i = 1; i <= numRows; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < i; j++)
                {
                    if (j == 0 || j == i-1) list.Add(1);
                    else
                    {
                        list.Add(output[i - 2][j - 1] + output[i - 2][j]);
                    }
                }
                output.Add(list);

            }
            return output;
        }


    }
}
