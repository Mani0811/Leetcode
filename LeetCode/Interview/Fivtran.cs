using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Interview
{
    class Fivtran : BaseClass
    {
        public static KeyValuePair<string, int>[] romanSet = null;
        public override void Run()
        {
            var input = new List<string>() { "Steven XL", "Steven XL", "David IX", "Mary XV", "Masy XIII", "Masy XX" };
            var output = sortRoman(input);

        }

        public static List<string> sortRoman(List<string> names)
        {
            var result = new List<string>();
            romanSet = new KeyValuePair<string, int>[]{
            new KeyValuePair<string, int>("I", 1),    // 0
            new KeyValuePair<string, int>("IV",4),
            new KeyValuePair<string, int>("V", 5),
            new KeyValuePair<string, int>("IX",9),
            new KeyValuePair<string, int>("X", 10),
            new KeyValuePair<string, int>("XL",40),   // 5
            new KeyValuePair<string, int>("L", 50),
            };
            var map = new Dictionary<string, List<int>>();
            foreach (var name in names)
            {
                var nameArray = name.Split(' ');
                var fn = nameArray[0];
                var sn = nameArray[1];
                if(map.ContainsKey(fn))
                {
                    map[fn].Add(RomanToDecimal(sn));
                }
                else
                {
                    var list = new List<int>() { RomanToDecimal(sn) };
                    map.Add(fn, list);
                }
            }
            foreach (var item in map.OrderBy(i => i.Key))
            {
                item.Value.Sort();
                foreach (var sn in item.Value)
                {
                    result.Add(item.Key + " " + IntToRoman(sn));
                }
            }
            return result;
        }

        public static int RomanToDecimal(string str)
        {
            // Initialize result
            int res = 0;

            for (int i = 0; i < str.Length; i++)
            {
                int s1 = value(str[i]);

                if (i + 1 < str.Length)
                {
                    int s2 = value(str[i + 1]);

                    if (s1 >= s2)
                    {
                        res = res + s1;
                    }
                    else
                    {
                        res = res + s2 - s1;
                        i++; 
                    }
                }
                else
                {
                    res = res + s1;
                    i++;
                }
            }

            return res;
        }

        public static int value(char r)
        {
            if (r == 'I')
                return 1;
            if (r == 'V')
                return 5;
            if (r == 'X')
                return 10;
            if (r == 'L')
                return 50;
            return -1;
        }

        public static string IntToRoman(int num)
        {
            if (num <= 0) return "";
            string result = "";
            int currIndex = romanSet.Length-1;
            while (num > 0)
            {
                while (num >= romanSet[currIndex].Value)
                {
                    result += romanSet[currIndex].Key;
                    num -= romanSet[currIndex].Value;
                }
                currIndex--;
            }
            return result;
        }
    }
}
