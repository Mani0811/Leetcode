using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    /*
     * Say you have an array prices for which the ith element is the price of a given stock on day i.
     * Design an algorithm to find the maximum profit. You may complete as many transactions as you like 
     * (i.e., buy one and sell one share of the stock multiple times).
     * Note: You may not engage in multiple transactions at the same time (i.e., you must sell the stock before you buy again).
     * Example 1: Input: [7,1,5,3,6,4] Output: 7
     * Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
     * Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
     */
    class BestTimetoBuyandSellStock_II : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var profit1 = MaxProfit(new int[] { 7, 1, 5, 3, 6, 4});
        }

        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int[] buy = new int[n];
            int[] sell = new int[n];
            buy[0] = -prices[0];
            sell[0] = 0;
            if(n==1)
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
