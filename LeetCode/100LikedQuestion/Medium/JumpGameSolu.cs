using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class JumpGameSolu : BaseClass
    {
        public override void Run()
        {
            var output = CanJump(new int[] {1,0,2});
            base.Run(); 
        }

        public bool CanJump(int[] nums)
        {
            int max = -1;
            for (int i = 0; i < nums.Length; i++)
            { 

                if (i == 0 && nums[i] == 1) return true;
                max = Math.Max(max, nums[i]);
                if (nums[i] + i == nums.Length - 1 && max>=i)
                    return true;
            }
            return false;

        }
    }
}
