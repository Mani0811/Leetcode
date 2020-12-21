using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.VMware
{
    class LongestStringChain :BaseClass
    {
        public override void Run()
        {
            base.Run();
            var len = LongestStrChain(new string[] {"ksqvsyq", "ks", "kss", "czvh", "zczpzvdhx", "zczpzvh", "zczpzvhx", "zcpzvh", "zczvh", "gr", "grukmj", "ksqvsq", "gruj", "kssq", "ksqsq", "grukkmj", "grukj", "zczpzfvdhx", "gru" });
        }
        Dictionary<int, HashSet<string>> map = new Dictionary<int, HashSet<string>>();
        int maxLen = 0;
        public int LongestStrChain(string[] words)
        {
            Array.Sort(words, (x, y) => x.Length.CompareTo(y.Length));
            int n = words.Length;
            for (int i = 0; i < n; i++)
            {
                var str = words[i];
                var len = words[i].Length;

                if (map.ContainsKey(len))
                {
                    map[len].Add(str);
                }
                else
                {
                    var hashmap = new HashSet<string>();
                    hashmap.Add(str);
                    map.Add(len, hashmap);

                }
            }
            for (int i = 0; i < n; i++)
            {
                var count = Helper(words[i], 1);
                maxLen = Math.Max(count, maxLen);
            }
            return maxLen;
        }

        public int Helper(string s, int count)
        {
            int len = s.Length;
            if (!map.ContainsKey(len + 1))
            {
                return count;
            }
            var listMap = map[len + 1];
            foreach (var mapstr in listMap)
            {
                if (!isVailidString(s, mapstr)) continue;
                return Helper(mapstr, count + 1);
            }
            return count;
        }

        public bool isVailidString(string s, string mapstr)
        {
            var map = new HashSet<char>();
            for (int i = 0; i < mapstr.Length; i++)
            {
                map.Add(mapstr[i]);
            }
            for (int i = 0; i < s.Length; i++)
            {
                map.Remove(s[i]);
            }
            return map.Count == 1;
        }
    }
}
