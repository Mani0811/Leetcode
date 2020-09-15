using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class DecodeWays : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var result = NumDecodings("12241");
        }

        public int NumDecodings(string s)
        {
                if (s == null || s.Length == 0)
                {
                    return 0;
                }
                int n = s.Length;
                int[] dp = new int[n + 1];
                dp[0] = 1;
                dp[1] = s[0] != '0' ? 1 : 0;
                for (int i = 2; i <= n; i++)
                {
                    int first = int.Parse(s.Substring(i - 1, 1));
                    int second = int.Parse(s.Substring(i - 2, 2));
                    if (first >= 1 && first <= 9)
                    {
                        dp[i] += dp[i - 1];
                    }
                    if (second >= 10 && second <= 26)
                    {
                        dp[i] += dp[i - 2];
                    }
                }
                return dp[n];
            }
    }
}
