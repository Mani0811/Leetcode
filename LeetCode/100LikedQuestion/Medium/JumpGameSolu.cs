using System;

namespace LeetCode._100LikedQuestion.Medium
{
    class JumpGameSolu : BaseClass
    {
        public override void Run()
        {

            var output = CanJump(new int[] { 2, 1,0,0 });
            var output1 = CanJump(new int[] { 1, 2, 3, 4});
            var output2 = CanJump(new int[] { 2, 3, 1, 1, 4 });
            var output3 = CanJump(new int[] { 3, 2, 1, 0, 4 });
            var output4 = CanJump(new int[] { 1, 0, 2, 2, 0 });
            base.Run();
        }
        public bool CanJump(int[] nums)
        {

            int n = nums.Length;
            if (n == 1) return true;
            var dp = new bool[n];
            dp[0] = true;
            for (int i = 1; i < n; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (dp[j] && j + nums[j] >= i)
                    
                    {
                        dp[i] = true;
                        
                        break;
                        
                    }
                }
            }

            return dp[n - 1];
        }

        //public bool CanJump(int[] nums)
        //{
        //    //Sliding Window
        //    int left = 0;
        //    int right = 0;

        //    while (right < nums.Length && right >= left)
        //    {

        //        right = Math.Max(left + nums[left], right);
        //        left++;
        //    }
        //    if (right < nums.Length - 1)
        //        return false;
        //    return true;
        //}

    }
}
