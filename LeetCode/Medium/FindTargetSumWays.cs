using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class FindTargetSumWays : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var output = FindTargetSumWaysSoluDP(new int[] { 1, 1, 1, 1, 1 }, 3);
             output = FindTargetSumWaysSolu(new int[] { 1, 1, 1, 1, 1 }, 3);
        }

        public int FindTargetSumWaysSolu(int[] nums, int target)
        {
            return Loop(nums, target, nums.Length - 1);
        }

        int[] sign = new int[] { -1, 1 };
        int Loop(int[] nums, int s, int i)
        {
            if (i == -1)
            {
                if (s == 0) return 1;
                else
                    return 0;
            }
            int count = 0;

            for (int k = 0; k < 2; k++)
            {
                count += Loop(nums, s - sign[k] * nums[i], i - 1);

            }
            return count;
        }

        public int FindTargetSumWaysSoluDP(int[] nums, int target)
        {
            
            var total = nums.Sum();
            var dp = new int[nums.Length , 2 * total + 1];
            dp[0,nums[0] + total] = 1;
            dp[0,-nums[0] + total] = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                for (int sum = -total; sum <= total; sum++)
                {
                    if(dp[i-1,sum+total]>0)
                    {
                            dp[i,sum + nums[i] + total] += dp[i - 1,sum + total];
                            dp[i,sum - nums[i] + total] += dp[i - 1,sum + total];
                    }
                }

            }
            return Math.Abs(target) > total ? 0 : dp[nums.Length - 1,target + total];
        }
    }
}
