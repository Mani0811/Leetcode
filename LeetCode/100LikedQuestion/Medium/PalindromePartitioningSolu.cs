using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class PalindromePartitioningSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
          var result =  Partition("aab");
        }
        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            if (s == null || s.Length == 0)
            {
                return result;
            }
            var pallindrom = new List<string>();
            Helper(s, 0, pallindrom, result);

            return result;
        }

        private void Helper(string s, int start, List<string> pallindrom, List<IList<string>> result)
        {
            if (start == s.Length)
            {
                var temp = new List<string>();
                foreach (var item in pallindrom)
                {
                    temp.Add(item);
                }
                result.Add(temp);
                return;
            }

            for (int len = 1; len <= s.Length - start; len++)
            {
                var str = s.Substring(start, len);
                if (!IsPalindrom(str))
                {
                    continue;
                }

                pallindrom.Add(str);
                Helper(s, start + len, pallindrom, result);
                pallindrom.RemoveAt(pallindrom.Count - 1);
            }
        }


        private bool IsPalindrom(string str)
        {
            if (str.Length == 1)
            {
                return true;
            }

            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                if (str[i] != str[j])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
