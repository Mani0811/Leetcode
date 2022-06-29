using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LeetCode.Assesment
{
    class HeightChecker : BaseClass
    {
        public override void Run()
        {
            //  var output = IsPowerOfTwo(536870912);

            var output = CommonChars(new string[] { "bella", "label", "roller" });
        }

        public IList<string> CommonChars(string[] words)
        {

            var n = words.Length;
            var ListDict = new List<Dictionary<char, int>>();

            for (int i = 0; i < n; i++)
            {
                var dic = new Dictionary<char, int>();
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (dic.TryGetValue(words[i][j], out int freq))
                    {
                        dic[words[i][j]] += 1;
                    }
                    else
                    {
                        dic.Add(words[i][j], 1);
                    }
                }
                ListDict.Add(dic);
            }
            var output = new List<string>();
            int aAsci = (int)'a';
            for (int i = aAsci; i < aAsci + 26; i++)
            {
                int min = int.MaxValue;
                char key = (char)i;
                bool flag = false;
                int procItemCount = 0;
                foreach (var item in ListDict)
                {
                    if (!item.ContainsKey(key))
                        break;
                    min = Math.Min(min, item[key]);
                    procItemCount++;
                    if (procItemCount == ListDict.Count)
                        flag = true;
                }
                if (flag)
                {
                    for (int j = 1; j <= min; j++)
                    {
                        output.Add(key.ToString());
                    }
                }
            }


            return output;
        }

        public bool IsPowerOfTwo(int n)
        {
            var x = Math.Log(n, 2);
            Console.WriteLine(x);
            var i = (int)x;
            Console.WriteLine(i);
            var z = x - i;
            Console.WriteLine(z);
            if (z == 0)
                return true;
            else
                return false;
        }

        public bool IsLongPressedName(string name, string typed)
        {
            var nameDict = new Dictionary<char, int>();
            for (int i = 0; i < name.Length; i++)
            {
                if (nameDict.TryGetValue(name[i], out int count))
                {
                    nameDict[name[i]] += 1;
                }
                else
                {
                    nameDict.Add(name[i], 1);
                }
            }
            var typeDict = new Dictionary<char, int>();

            for (int i = 0; i < typed.Length; i++)
            {
                if (typeDict.TryGetValue(typed[i], out int count))
                {
                    typeDict[typed[i]] += 1;
                }
                else
                {
                    typeDict.Add(typed[i], 1);
                }
            }
            if (typeDict.Count != typeDict.Count) return false;

            for (int i = 0; i < typeDict.Count; i++)
            {
                var key = nameDict.ElementAt(i).Key;
                var nv = nameDict.ElementAt(i).Value;
                var tkey = typeDict.ElementAt(i).Key;
                var tval = typeDict.ElementAt(i).Value;
                if (key != tkey) return false;
                if (tval < nv) return false;
            }
            return true;
        }

        public int HeightCheckerRUN(int[] heights)
        {
            var newHeg = new int[heights.Length];
            for (int i = 0; i < heights.Length; i++)
            {

                newHeg[i] = heights[i];
                Console.WriteLine(newHeg[i]);
            }
            Array.Sort(newHeg);
            for (int i = 0; i < newHeg.Length; i++)
            {
                Console.WriteLine(newHeg[i]);
            }

            int count = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (newHeg[i] != newHeg[i])
                    count++;
            }
            return count;
        }
    }
}
