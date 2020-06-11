using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class SortColorsSolu:BaseClass
    {
        public override void Run()
        {
            SortColors(new int[] { 2, 0, 2, 1, 1, 0 });
            base.Run(); 
        }

        public void SortColors(int[] nums)
        {
            Array.Sort(nums);
        }
    }
}
