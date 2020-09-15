using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode.Interview.NationalInstrument
{
    class PolicemenandThieves : BaseClass
    {
        public override void Run()
        {
            PrintMaxNoTheives();

        }
        void PrintMaxNoTheives()
        {
            int t = int.Parse(Console.ReadLine());
            for (int l = 0; l < t; l++)
            {
                var a = Console.ReadLine().Split(' ').Select(m => int.Parse(m)).ToArray();
                var n = a[0];
                var k = a[1];
                char[][] inp = new char[n][];
                for (int i = 0; i < n; i++)
                {
                    inp[i]= Console.ReadLine().Split(' ').Select(c=>char.Parse(c)).ToArray();
                }
                solution(inp, k);

            }
        }

        static int solution(char[][] A, int K)
        {
            var sb = new List<char>(K + 1);
            int count = 0;
            for (int r = 0; r < A.Length; r++)
            {
                for (int col = 0; col < A[r].Length; col++)
                {
                    // var line = Console.ReadLine().Split(' ');
                    var c = A[r][col];
                    if (sb.Count == K + 1) sb.RemoveAt(0);

                    while (sb.Count > 0 && sb[0] == 'X')
                    {
                        sb.RemoveAt(0);
                    }
                    if (sb.Count == 0)
                    {
                        sb.Add(c);
                        continue;
                    }
                    if (sb[0] == 'P')
                    {
                        if (c == 'T')
                        {
                            count += 1;
                            sb.Add('X');
                            sb.RemoveAt(0);
                            continue;
                        }
                        else
                            sb.Add(c);

                    }
                    else
                    {
                        if (c == 'P')
                        {
                            count += 1;
                            sb.Add('X');
                            sb.RemoveAt(0);
                            continue;
                        }
                        else
                            sb.Add(c);
                    }
                }
                sb.Clear();
            }

            return count;


        }


    }
}
