using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.DsQuestion
{
    class LongestIncreasingSubsequence: BaseClass
    {
        public override void Run()
        {
            base.Run();
            var output = LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3});
        }

        public int LengthOfLIS(int[] nums)
        {
            int n = nums.Length;

            int[] dp = new int[n];
            int max = int.MinValue;
            for (int j = 0; j < n; j++)
            {
                dp[j] = 1;

            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[i] < nums[j])
                        dp[j] =Math.Max(dp[i]+ 1,dp[j]);
                    max = Math.Max(max, dp[j]);
                }
            }

            return max;
        }
    }
}
