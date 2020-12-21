using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class ProductofArrayExceptSelf : BaseClass
    {
        public override void Run()
        {
            base.Run();

            var x = ProductExceptSelf(new int[] { 1, 2, 3, 4 });
        }
        public int[] ProductExceptSelf(int[] nums)
        {
            int mult = 1;
            var output = new int[nums.Length];
            int zeroCount = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    zeroCount++;
                    continue;
                }
                mult = nums[i] * mult;
            }
            for (int i = 0; i < nums.Length; i++)
            {

                if (zeroCount > 1)
                {
                    output[i] = 0;
                    continue;
                }
                if (nums[i] == 0)
                {
                    output[i] = mult;
                }
                output[i] = mult / nums[i];
            }

            return output;
        }
    }
}
