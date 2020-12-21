using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Tiles :BaseClass
    {

        public override void Run()
        {
            base.Run();
            var output = NumTilePossibilities("ABC");
        }

        List<List<char>> output;
        int len;
        int res;
        public int NumTilePossibilities(string tiles)
        {
            output = new List<List<char>>();
            len = tiles.Length;
            res = 0;
            BackTrack(tiles.ToCharArray(), new List<char>(), 0);
            return res;

        }

        void BackTrack(char[] ta, List<char> list, int start)
        {
            if (list.Count > 0)
            {
                var tempList = new List<char>();
                tempList.AddRange(list);
                var sl = list.Count;
                var map = new Dictionary<char, int>();
                for (int i = 0; i < sl; i++)
                {
                    if (!map.ContainsKey(list[i]))
                        map.Add(list[i], 1);
                    else
                        map[list[i]] += 1;

                }
                var res = Factorial(len);
                foreach (var entity in map)
                {
                    if (entity.Value == 1) continue;
                    res = Factorial(entity.Value);
                }
                output.Add(list);
            }

            for (int i = start; i < len; i++)
            {
                var ca = ta[i];
                list.Add(ca);
                BackTrack(ta, list, i + 1);
                list.RemoveAt(list.Count - 1);
            }
        }

        int Factorial(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * Factorial(n - 1);
        }
    }
}
