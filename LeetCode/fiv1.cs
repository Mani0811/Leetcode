using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class fiv1 : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var output = getSubsequenceCountDp("Gks", "GeeksforGeeks");
        }
        public static long getSubsequenceCount(string s1, string s2)
        {
            var ls1 = count(s2, s1, s2.Length, s1.Length);
            return (long)ls1;
        }

        private static long count(string a, string b, int m, int n)
        {
            if ((m == 0 && n == 0) || n == 0)
                return 1;

            if (m == 0)
                return 0;
            if (a[m - 1] == b[n - 1])
                return count(a, b, m - 1, n - 1) +
                       count(a, b, m - 1, n);
            else
                // If last characters are different,   
                // ignore last char of first string  
                // and recur for  remaining string 
                return count(a, b, m - 1, n);
        }

        public static long getSubsequenceCountDp(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;
            int[,] map = new int[m + 1, n + 1];
            
            for (int i = 0; i <= m; i++)
            {
                map[i, 0] = 0;
            }
            for (int i = 0; i <= n; i++)
            {
                map[0, i] = 1;
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s[i - 1] == t[j - 1])
                        map[i, j] = map[i - 1, j - 1] + map[i, j - 1];
                    else
                        map[i, j] = map[i, j - 1];
                }
            }
            return map[m, n];
        }
    }
}
