using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class PrtitionArrayforMaximumSum : BaseClass
    {
        private int j;

        public override void Run()
        {
            base.Run();
            var s = MaxSumAfterPartitioning(new int[] { 1, 15, 7, 9, 2, 5, 10 }, 3);
        }
        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            var arr2 = new int[arr.Length];
            var dp = new int[arr.Length];
            int result = 0;
            if (k > arr.Length)
            {
                for (int i = 0; i < k; i++)
                {
                    result += arr[i];
                }
                return result;
            }
            int max = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < i + k && i + k < arr.Length; j++)
                {
                    max = Math.Max(max, arr[j]);
                }
                for(int j =i; j < i + k && i + k < arr.Length; j++)
                dp[j] = max;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                result += arr[i];
            }
            return result;
        }
    }
}
