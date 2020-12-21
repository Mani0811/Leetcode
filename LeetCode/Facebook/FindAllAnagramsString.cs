using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LeetCode.Facebook
{
    class FindAllAnagramsString : BaseClass
    {
        public override void Run()
        {
            var resu = FindAnagrams("cbaebabacd",
"abc");
        }

        public IList<int> FindAnagrams_1(string s, string p)
        {

            var result = new List<int>();
            if (p.Length > s.Length) return result;
            var pa = p.ToCharArray();
            Array.Sort(pa);
            p = new string(pa);
            var set = new HashSet<char>();
            for (int i = 0; i < p.Length; i++)
            {
                set.Add(p[i]);
            }
            var sb = new StringBuilder();
            int end = 0;
            for (int i = 0; i < s.Length && end < s.Length; i++)
            {

                var c = s[end];
                if (!set.Contains(c))
                {
                    sb = new StringBuilder();
                    i = end;
                    end++;
                    continue;
                }
                while (sb.Length < p.Length && end < s.Length)
                {
                    if (set.Contains(s[end]))
                    {
                        sb.Append(s[end]);
                        end++;
                        continue;
                    }
                    else
                    {
                        sb = new StringBuilder();
                        i = end;
                        break;
                    }
                }

                if (sb.Length == p.Length)
                {
                    var curs = sb.ToString().ToCharArray();
                    Array.Sort(curs);
                    if (new string(curs) == p)
                    {
                        if (i < s.Length)
                        {
                            result.Add(i);
                        }

                        sb.Remove(0, 1);
                    }
                    else
                    {
                        sb.Remove(0, 1);
                    }
                }
            }
            return result;
        }

        public List<int> FindAnagrams(string s, string t)
        {
            List<int> result = new List<int>();
            if (t.Length > s.Length) return result;
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < t.Length; i++)
            {
                var c = t[i];
                map.TryGetValue(c, out int count);
                map.TryAdd(c, count + 1);
            }
            int counter = map.Count;

            int begin = 0, end = 0;
            int len = int.MaxValue;


            while (end < s.Length)
            {
                char c = s[end];
                if (map.ContainsKey(c))
                {
                    map.TryGetValue(c, out int count);
                    map[c] = count - 1;
                    if (count - 1 == 0) counter--;
                }
                end++;

                while (counter == 0)
                {
                    char tempc = s[begin];
                    if (map.ContainsKey(tempc))
                    {
                        map[tempc]= map[tempc] + 1;
                        if (map[tempc] > 0)
                        {
                            counter++;
                        }
                    }
                    if (end - begin == t.Length)
                    {
                        result.Add(begin);
                    }
                    begin++;
                }

            }
            return result;
        }
    }
}
