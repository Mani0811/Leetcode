using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class CountSortedVowelStringsSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var x = CountVowelStrings(2);
        }
        public int CountVowelStrings1(int n)
        {
            int ans = 0;
            for (int j = 1; j <= (n + 1); j++)
            {
                int sum = 0;
                for (int i = 1; i <= j; i++)
                {
                    sum += i;
                    ans += sum;
                }
            }
            return ans;

        }

        public int CountVowelStrings(int n)
        {
            var list = new List<int>(6);
            list.Add(0);
            for (int i = 1; i < 6; i++)
            {
                list.Add(1);
            }
            for (int k = 1; k <= n; k++)
            {
                for (int i = 1; i <= 5; i++)
                {
                    int sum = 0;
                    sum = list[i - 1] + list[1];
                    list[i] = sum;
                }
            }
            int res = 0;
            for (int i = 1; i <= 5; i++)
            {
                res += list[i];
            }
            return res;
        }
    }
}
