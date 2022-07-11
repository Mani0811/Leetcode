using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Jump_Game_II : BaseClass
    {
        public override void Run()
        {
            base.Run();

            var output = Jump1(new int[] { 2, 3, 1, 1, 4 });
        }

        public int Jump1(int[] A)
        {
            int jumps = 0, curEnd = 0, curFarthest = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                curFarthest = Math.Max(curFarthest, i + A[i]);
                if (i == curEnd)
                {
                    jumps++;
                    curEnd = curFarthest;
                }
            }
            return jumps;
        }
        public int Jump(int[] nums)
        {
            var n = nums.Length;

            int count = 0;
            if (n <= 1) return count;
            int last = n - 1, j = n - 1;
            while (j >= 0)
            {
                Console.WriteLine(j);
                last = j;
                for (int i = j; i >= 0; i--)
                {
                    if (nums[i] + i >= j)
                    {
                        last = i;
                    }
                }

                j = last;
                Console.WriteLine(count);
                count++;
                if (j == 0) break;
            }
            return count;

        }
    }
}
