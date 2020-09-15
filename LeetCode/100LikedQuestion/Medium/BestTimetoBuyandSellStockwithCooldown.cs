using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class BestTimetoBuyandSellStockwithCooldown :BaseClass
    {
        public override void Run()
        {
            base.Run();

           var profit1 = MaxProfit1(new int[] { 7, 1, 5, 3, 6, 4,1,3 });
            var profit = MaxProfit(new int[] { 7, 1, 5, 3, 6, 4,1,3 });
        }
        /*
         * buy[i]  = max(rest[i-1]-price, buy[i-1]) 
        sell[i] = max(buy[i-1]+price, sell[i-1])
        rest[i] = max(sell[i-1], buy[i-1], rest[i-1])
        */
        public int MaxProfit(int[] prices)
        {
            int b0 = -prices[0], b1 = b0;
            int s0 = 0, s1 = 0, s2 = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                b0 = Math.Max(b1, s2 - prices[i]);
                s0 = Math.Max(s1, b1 + prices[i]);
                b1 = b0; s2 = s1; s1 = s0;
            }
            return s0;
        }

        public int MaxProfit1(int[] prices)
        {
            int n = prices.Length; 
            int[] buy = new int[n];
            int[] sell = new int[n];
            buy[0] = -prices[0];
            sell[0] = 0;
            sell[1] = Math.Max(buy[0] + prices[1],sell[0]);
            buy[1] = Math.Max(buy[0],-prices[1]);//cooldown
            for (int i = 2; i < prices.Length; i++)
            {

                buy[i] = Math.Max(buy[i - 1], sell[i - 2] - prices[i]);
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
            }
            return Math.Max(buy[n-1],sell[n-1]);
        }
    }
}
