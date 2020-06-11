using System;

namespace LeetCode._100LikedQuestion.Medium
{
    class JumpGameSolu : BaseClass
    {
        public override void Run()
        {

            var output = CanJump(new int[] { 1, 1,1, 1, 2, 0 });
            var output1 = CanJump(new int[] { 1, 0, 1, 0});
            var output2 = CanJump(new int[] { 2, 3, 1, 1, 4 });
            var output3 = CanJump(new int[] { 3, 2, 1, 0, 4 });
            var output4 = CanJump(new int[] { 1, 0, 2, 2, 0 });
            base.Run();
        }
     
        public bool CanJump(int[] nums)
        {
            int max =0;
            if ((nums[0] == 1 || nums[0] == 0) && nums.Length == 1) return true;
            if (nums[0] == 0) return false;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] == 0) continue;
                if (nums[i] + i >= nums.Length - 1 && max >= i)
                    return true;
                max = Math.Max(i + nums[i], max);
            }
            return false;
        }
    }
}
