using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class KthLargestElementiInAnArray : BaseClass
    {
        public override void Run()
        {
            base.Run();
        }

        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length-k];
        }

        
    }
}
