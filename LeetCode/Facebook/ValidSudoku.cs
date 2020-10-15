using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class ValidSudoku : BaseClass
    {
        public override void Run()
        {
            base.Run();

            char[][] board = new char[][]
          {
new char[]{'.','.','4','.','.','.','6','3','.'},
new char[]{'.','.','.','.','.','.','.','.','.'},
new char[]{'5','.','.','.','.','.','.','9','.'},
new char[]{'.','.','.','5','6','.','.','.','.'},
new char[]{'4','.','3','.','.','.','.','.','1'},
new char[]{'.','.','.','7','.','.','.','.','.'},
new char[]{'.','.','.','5','.','.','.','.','.'},
new char[]{'.','.','.','.','.','.','.','.','.'},
new char[]{'.','.','.','8','.','.','8','.','.'}};
            var output = IsValidSudoku(board);
        }
        char[][] Board;
        bool[] row;
        bool[] col;
        public bool IsValidSudoku(char[][] board)
        {
            Board = board;
            int m = board.Length;
            for (int i = 0; i < m; i++)
            {
                int n = board[0].Length;
            }
            row = new bool[8];
            col = new bool[8];
            for (int k = 0; k < 9;)
            {
                for (int l = 0; l < 9;)
                {
                    HashSet<char> set = new HashSet<char>();
                    for (int i = k; i < k + 3; i++)
                    {

                        for (int j = l; j < l + 3; j++)
                        {
                            if (Board[i][j] == '.') continue;
                            if (!(IsValidRow(i) && IsValidCol(j))) return false;
                            if (char.GetNumericValue(Board[i][j]) >= 1 && char.GetNumericValue(Board[i][j]) <= 9 && set.Add(Board[i][j])) continue;
                            return false;
                        }
                    }
                    l = l + 3;
                }
                k = k + 3;
            }

            return true;
        }
        bool IsValidRow(int r)
        {
            if (row[r]) return true;
            HashSet<char> set = new HashSet<char>();
            for (int j = 0; j < 9; j++)
            {
                if (Board[r][j] == '.') continue;

                if (char.GetNumericValue(Board[r][j]) >= 1 && char.GetNumericValue(Board[r][j]) <= 9 && set.Add(Board[r][j]))
                    continue;
                return false;

            }

            row[r] = true;
            return true;
        }

        bool IsValidCol(int c)
        {
            if (col[c]) return true;
            HashSet<char> set = new HashSet<char>();
            for (int j = 0; j < 9; j++)
            {
                if (Board[j][c] == '.') continue;
                if (char.GetNumericValue(Board[j][c]) >= 1 && char.GetNumericValue(Board[j][c]) <= 9 && set.Add(Board[j][c]))
                    continue;
                return false;

            }
            col[c] = true;
            return true;
        }
    }
}
