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
    }
}
