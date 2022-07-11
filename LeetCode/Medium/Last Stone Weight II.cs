using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Last_Stone_Weight_II : BaseClass
    {
        public override void Run()
        {
            base.Run();
           var output = LastStoneWeightII(new int[] { 31, 26, 33, 21, 40});
        }

        public int LastStoneWeightII(int[] stones)
        {
            Array.Sort(stones);
            int S = 0;
            int n = stones.Length;
            for (int i = 0; i < n; i++)
            {
                S += stones[i];
            }



            int[,] dp = new int[n + 1, S + 1];

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= S / 2; j++)
                {
                    if (stones[i - 1] <= j)
                        dp[i, j] = Math.Max(dp[i - 1, j], stones[i - 1] + dp[i - 1, j - stones[i - 1]]);
                    else
                        dp[i, j] = dp[i - 1, j];
                }


            return S - 2 * dp[n, S / 2];
        }
    }

}
