using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class WordSearchSolu : BaseClass
    {
        public override void Run()
        {
            var board = new Char[][]
   {

  new char[] {'A', 'B', 'C', 'E' },

  new char[] {'S', 'F', 'C', 'S' },

  new char[] {'A', 'D', 'E', 'E' }

  };
            board = new Char[][]
   {

  new char[] {'C', 'A', 'A'},

  new char[] {'A', 'A', 'A' },

  new char[] {'B', 'C', 'D' }

  };    




            var output = Exist(board, "AAB");

            base.Run();
        }

        int[] X = new int[] { 1, 0, - 1, 0 };
        int[] Y = new int[] { 0, 1, 0, -1 };

        int M, N;
        public bool Exist(char[][] board, string word)
        {
            M = board.Length;
            int wCounter = 0;
            var visited = new bool[board.Length][];
            for (int i = 0; i < visited.Length; i++)
            {
                var len = board[i].Length;
                visited[i] = new bool[len];
            }
            for (int i = 0; i < M; i++)
            {
                N = board[i].Length;
                for (int k = 0; k < N; k++)
                {
                    visited[i][k] = true;
                    if (board[i][k] == word[wCounter] && ExistUtil(i, k, board, word, wCounter + 1,visited))
                    {
                        return true;
                    }
                    visited[i][k] = false;
                }
            }
            return false;
        }

        bool ExistUtil(int x, int y, char[][] board, string word, int wCounter, bool[][] visited)
        {
            if (wCounter == word.Length)
            {
                return true;
            }

            for (int k = 0; k < 4; k++)
            {
                var xCurr = x + X[k];
                var yCurr = y + Y[k];
                if (IsValid(xCurr, yCurr) && board[xCurr][yCurr] == word[wCounter]&& !visited[xCurr][yCurr])
                {
                    visited[xCurr][yCurr] = true;
                  if (ExistUtil(xCurr, yCurr, board, word, wCounter + 1, visited))
                        return true;
                }
            }
            visited[x][y] = false;
            return false;
        }
        public bool IsValid(int x, int y)
        {
            if (x < M && x >= 0 && y < N && y >= 0) return true;
            return false;
        }
    }
}


