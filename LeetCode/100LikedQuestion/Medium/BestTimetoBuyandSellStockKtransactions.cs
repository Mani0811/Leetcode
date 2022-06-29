using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class BestTimetoBuyandSellStockKtransactions : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var r = solution("abcdabcdabcd");
            var prices = new int[] { 1, 2, 3, 4, 5 };
            var resu1 = MaxProfit(2, prices);
            var resu2 = MaxProfit(prices);
        }



        public int solution(string S)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            var dic = new Dictionary<char, List<int>>();
            for (int i = 0; i < S.Length; i++)
            {
                if (!dic.ContainsKey(S[i]))
                {
                    dic.Add(S[i], new List<int>() { i });
                }
                else
                {
                    dic[S[i]].Add(i);
                }
            }
            int diff = 0;
            foreach (var item in dic)
            {
                if(item.Value.Count>1)
                {
                    diff = Math.Max(diff, item.Value[item.Value.Count - 1] - item.Value[0]+1);
                }
            }
            return S.Length - diff;
        }
        public int MaxProfit(int k, int[] prices)
        {
            int n = prices.Length;
            int[,] dp = new int[k + 1,n];
            for (int i = 1; i <= k; i++)
            {
                int localMax = dp[i - 1,0] - prices[0];
                for (int j = 1; j < n; j++)
                {
                    dp[i,j] = Math.Max(dp[i,j- 1], prices[j] + localMax);
                    localMax = Math.Max(localMax, dp[i - 1,j] - prices[j]);
                }
            }
            return dp[k,n - 1];
        }

        //Best Time to Buy and Sell Stock III
        public int MaxProfit(int[] prices)
        {

            int n = prices.Length;
            int[,] dp = new int[3, n+1];

            for (int k = 1; k < 3; k++)
            {
                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j < i; j++)
                    {
                         dp[k, i] = Math.Max(dp[k, i - 1], prices[i] - prices[j] + dp[k - 1, j - 1]);
                    }
                }
            }
            return dp[2, n - 1];

        }
    }
}
