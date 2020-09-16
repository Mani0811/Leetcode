using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class FindtheDuplicateNumber : BaseClass
    {
        public override void Run()
        {
            base.Run();
           var output = FindDuplicate(new int[] { 1, 3, 4, 2, 2 });
        }

        public int FindDuplicate(int[] nums)
        {
            int slow = 0;
            int fast = 0;
            int finder = 0;

            while (true)
            {
                slow = nums[slow];
                fast = nums[nums[fast]];

                if (slow == fast)
                    break;
            }
            while (true)
            {
                slow = nums[slow];
                finder = nums[finder];
                if (slow == finder)
                    return slow;
            }
        }

        // valid if one number modified.
        //public int FindDuplicate(int[] nums)
        //{
        //    int n = nums.Length;
        //    var expectedSum = n * (n + 1) / 2;
        //    var expectedSqureSum = n * (n + 1) * (2 * n + 1) / 6;
          
        //    var actualSum = 0;
        //    var actualSquareSum = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        actualSum += nums[i];
        //        actualSquareSum += nums[i]* nums[i];
        //    }

        //    var aMinusb = expectedSum - actualSum;
        //    var aplusb = (expectedSqureSum - actualSquareSum) / aMinusb;
        //    var b = (aMinusb + aplusb) / 2;
        //    var a = aplusb - b;
        //    return aMinusb < 0 ? Math.Max(a, b) : Math.Min(a, b);

        //}
    }
}
