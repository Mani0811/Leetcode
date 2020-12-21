using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LeetCode.Easy
{
    class MinCostClimbing : BaseClass
    {
        public override void Run()
        {
            int[] c = new int[] { 10, 15, 20 };
            var res = MinCostClimbingStairs(c);

        }
        public int MinCostClimbingStairsDP(int[] cost)
        {
            var len = cost.Length;
            int[] dp = new int[len];
            for (int i = 0; i < len ; i++)
            {
                if (i < 2)
                    dp[i] = cost[0];
                else
                    dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);
            }
            return Math.Min(dp[len - 1], dp[len - 2]);
        }

        public int MinCostClimbingStairsDP1(int[] cost)
        {
            var len = cost.Length;
            int prv1 = cost[0];
            int prv2 = cost[1];
            if (len < 2)
                return Math.Min(prv1, prv2);
            for (int i = 2; i < len; i++)
            {
                var  ccost   = cost[i] + Math.Min(prv1, prv2);
                prv1 = prv2;
                prv2 = ccost;

            }
            return Math.Min(prv1, prv2);
        }
        public int MinCostClimbingStairs(int[] cost)
        {
           var len = cost.Length;
           var mincost = Math.Min(Helper(cost, len-1), Helper(cost, len - 2));
            return mincost;

        }

        public int Helper(int[] cost,int n)
        {
            if (n < 0) return 0;
            if (n == 0 || n == 1) return cost[n];
            return cost[n] + Math.Min(Helper(cost, n - 1), Helper(cost, n - 2));
        }
    }
}
