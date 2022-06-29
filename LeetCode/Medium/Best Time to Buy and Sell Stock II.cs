using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Best_Time_to_Buy_and_Sell_Stock_II:BaseClass
    {
        public override void Run()
        {
            base.Run();
        }

        public int MaxProfit(int[] prices)
        {
            int profit = 0;
            int n = prices.Length;
            for (int i = 1; i < n; i++)
            {
                if (prices[i] > prices[i - 1])
                    profit += prices[i] - prices[i - 1];
            }
            return profit;
        }
    }
}
