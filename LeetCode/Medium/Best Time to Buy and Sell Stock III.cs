using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Best_Time_to_Buy_and_Sell_Stock_III: BaseClass
    {
        public override void Run()
        {
            base.Run();

            var output = MaxProfit(new int[] { 1, 2, 3, 4, 5 });
        }

        public int MaxProfit(int[] prices)
        {

            if (prices is null || prices.Length < 2) return 0;
            int[,] dp = new int[prices.Length, 3]; //row - day, column - allowed sells, value - max possible profit
            for (int sells = 1; sells <= 2; sells++)
            {
                int bp = prices[0];
                for (int day = 1; day < prices.Length; day++)
                {
                    dp[day, sells] = Math.Max(dp[day - 1, sells], prices[day] - bp);
                    bp = Math.Min(bp, prices[day] - dp[day - 1, sells - 1]);
                }
            }
            return dp[prices.Length - 1, 2];
        }
    }
}
