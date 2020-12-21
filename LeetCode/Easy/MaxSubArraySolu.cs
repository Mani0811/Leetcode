using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class MaxSubArraySolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var res = MaxSubArray(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 });
        }

        public int MaxSubArray(int[] a)
        {
            int maxSum = a[0], currentSum = a[0];
            int len = a.Length;
            for (int i = 1; i < a.Length; i++)
            {
                currentSum = Math.Max(a[i], currentSum + a[i]);
                if (maxSum < currentSum)
                {
                    maxSum = currentSum;
                }
            }
            return maxSum;
            //int len = nums.Length;
            //int sum = 0;
            //int maxSum = int.MinValue;
            //int pre = 0;
            //for (int i = pre; i < len; i++)
            //{
            //    sum += nums[i];
            //    maxSum = Math.Max(sum, maxSum);
            //    if (sum < 0)
            //    {
            //        i = pre;
            //        pre = i;
            //        sum = 0;
            //    }
            //}

            //return maxSum;
        }
    }
}
