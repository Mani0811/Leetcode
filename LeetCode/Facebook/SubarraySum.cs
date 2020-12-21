using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class SubarraySumSOlu : BaseClass
    {
        public override void Run()
        {
            var output = SubarraySum(new int[] {-1,1,-1 }, 0);
        }

        public int SubarraySum(int[] nums, int k)
        {
            if (nums.Length == 0) return 0;

            int j = 0;
            int sum = 0;
            int count = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (!map.ContainsKey(i)) map.Add(i, sum);
                if (sum == k)
                {
                    count++;

                }
                if (nums[i] == k)
                {
                    count++;
                }
                while (j < i)
                {
                    var sumIJ = map[i] - map[j-1];
                    if (sumIJ == k)
                    {
                        count++;
                    }
                    j++;
                }

            }

            return count;
        }
    }
}
