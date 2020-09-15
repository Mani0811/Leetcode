using System;

namespace LeetCode
{
    class BestTimetoBuyandSellStockIV :BaseClass    
    {
        public override void Run()
        {
            base.Run();
        }

        public int MaxProfit(int k, int[] prices)
        {
            int n = prices.Length;
            int[] buy = new int[n];
            int[] sell = new int[n];
            buy[0] = -prices[0];
            sell[0] = 0;
            if (n == 1)
                return 0;

            for (int i = 1; i < prices.Length; i++)
            {

                buy[i] = Math.Max(buy[i - 1], sell[i - 1] - prices[i]);
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
            }
            return Math.Max(buy[n - 1], sell[n - 1]);

        }
    }
}
