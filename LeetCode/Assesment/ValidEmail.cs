using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Assesment
{
    class ValidEmail : BaseClass
    {
        public override void Run()
        {
            var chars = "Mani";
            var cf = chars.ToCharArray().ToDictionary(key => key, value => value);
            //  var output = IsPowerOfTwo(536870912);

            //var output = NumUniqueEmails(new string[] { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" });
            var output = TotalFruit(new int[] {1, 0, 1, 4, 1, 4, 1, 2, 3 });
        }
        private readonly char[] Separators = new char[] { ' ', '!', '?', ',', ';', '.', '\'' };
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var dict = new Dictionary<string, int>();
            foreach (var word in paragraph.Split(Separators, StringSplitOptions.RemoveEmptyEntries))
            {
                var lower = word.ToLower();
                if (!dict.TryAdd(lower, 1))
                    dict[lower]++;
            }

            for (int i = 0; i < banned.Length; i++)
                dict.Remove(banned[i]);

            return dict.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }

        const int NUM_OF_BASKETS = 2;
        public int TotalFruit(int[] tree)
        {
            var max = -1;
            var left = 0;
            var fruitFrequency = new Dictionary<int, int>();
            for (var right = 0; right < tree.Length; ++right)
            {
                var rightFruit = tree[right];
                if (fruitFrequency.ContainsKey(rightFruit))
                    fruitFrequency[rightFruit]++;
                else
                    fruitFrequency[rightFruit] = 1;

                while (fruitFrequency.Count() > NUM_OF_BASKETS)
                {
                    var leftFruit = tree[left];
                    if (fruitFrequency[leftFruit] == 1)
                        fruitFrequency.Remove(leftFruit);
                    else
                        fruitFrequency[leftFruit]--;

                    left++;
                }

                max = Math.Max(max, right - left + 1);
                
            }

            return max;
        }
        public int NumUniqueEmails(string[] emails)
        {

            var set = new HashSet<string>();
            for (int i = 0; i < emails.Length; i++)
            {
                var cur = emails[i].Split('@');
                var fName = string.Empty;
                for (int j = 0; j < cur[0].Length; j++)
                {

                    var fn = cur[0][j];
                    if (fn == '.')
                    {
                        continue;
                    }
                    else if (fn == '+')
                    {
                        break;
                    }
                    fName += fn.ToString();
                }
                Console.Write(i);
                set.Add(fName + "@" + cur[1]);
            }
            return set.Count;




        }
    }
}
