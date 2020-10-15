using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class LongestHarmoniousSubsequence : BaseClass
    {
        public override void Run()
        {
            var output = FindLHS(new int[] { 1, 3, 2, 2, 5, 2, 3, 7 });
        }

        public int FindLHS(int[] nums)
        {

            Dictionary<int, int> map = new Dictionary<int, int>();
            int count = 0;

            for (int j = 0; j < nums.Length; j++)
            {
                if (!map.ContainsKey(nums[j]))
                    map.Add(nums[j], 1);
                else
                    map[nums[j]] += 1;
            }
            foreach (var item in map)
            {
                var cur = item.Key;
                int currCount = 0;
                int currCount1 = 0;
                map.TryGetValue(cur + 1, out currCount);
                map.TryGetValue(cur - 1, out currCount1);

                count = Math.Max(count, Math.Max(currCount+item.Value , currCount1+item.Value));
            }
            return count;
        }
    }
}
