using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LeetCode.Medium
{
    class IsSubsequenceSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var res = IsSubsequenceCountDP("abc", "aahbgdcbc");
        }
        public int IsSubsequenceCountDP(string s, string t)
        {
            int m = s.Length;
            int n = t.Length;


            int[,] dp= new int[m+1, n+1];
            for (int i = 0; i <= s.Length; i++)
            {
                dp[i, 0] = 0;
            }
            for (int i = 0; i <= s.Length; i++)
            {
                dp[0, i] = 1;
            }
            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= t.Length; j++)
                {
                    if (s[i-1] == t[j-1])
                        dp[i, j] = dp[i-1, j-1] + dp[i, j - 1];
                    else
                        dp[i, j] = dp[i, j-1];
                }
            }
            return dp[m, n];
        }
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0) return true;
            if (t.Length == 0) return false;
            int i = 0;
            var sc = s[i];
            for (int j = 0; j < t.Length; j++)
            {
                if (sc == t[j])
                {
                    if (i == s.Length - 1) return true;
                    sc = s[++i];
                }
            }
            return false;
        }
        /// <summary>
        /// get susequance Count
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public int IsSubsequenceCount(string s, string t)
        {
            Helper(t);
            int pre = 0;
            int count = 0;
            for (int k = 1; k <= indexList[s[0]].Count;k++)
            {
                pre = indexList[s[0]][k-1];
                for (int i = 0; i < s.Length; i++)
                {
                    var indx = s[i];
                    var list = indexList[indx];
                    if (list.Count <= 0) return count;
                    var j = list.BinarySearch(pre);
                    if (j < 0) j = -j - 1;
                    if (j == list.Count) return count;
                    pre = list[j] + 1;

                }
                count++;
            }
            return count;
        }
        /*
         * If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, 
         * and you want to check one by one to see if T has its subsequence. 
         * In this scenario, how would you change your code?
         */
        public bool IsSubsequenceFForMS(string s, string t)
        {
            Helper(t);
            int pre = 0;
            for (int i = 0; i <s.Length ; i++)
            {
                var indx = s[i];

                var list = indexList[indx];
                if (list.Count <=0) return false;
                var j = list.BinarySearch(pre);
                if (j < 0) j = -j - 1;
                if (j == list.Count) return false;
                pre = list[j]+1;

            }
            return true;
        }
        List<int>[] indexList;
        void Helper(string t)
        {
            indexList = new List<int>[256];
            for (int i = 0; i < 256; i++)
            {
                indexList[i] = new List<int>();
            }
            for (int i = 0; i < t.Length; i++)
            {
                int indx = t[i];
                indexList[indx].Add(i);
            }


        }
    }
}
