using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class _3sum : BaseClass
    {
        public override void Run()
        {
            var output = ThreeSum(new int[] { -1, 0, 1, 2, -1, -4 });
            output = findTriplets(new int[] { -1, 0, 1, 2, -1, -4 });

        }

        public List<IList<int>> threeSum(int[] nums)
        {
            var output = new List<IList<int>>();
            if (nums.Length < 3) return output; // if nums less than 3 element
            Array.Sort(nums); // sort array
            var set = new HashSet<List<int>>();
            for (int i = 0; i < nums.Length - 2; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0) output.Add(new List<int> { nums[i], nums[j++], nums[k--] });
                    else if (sum > 0) k--;
                    else if (sum < 0) j++;
                }

            }

            return output;
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
           
            var output = new HashSet<IList<int>>();
            if (nums.Length < 3) return output.ToList();
            HashSet<int> set = new HashSet<int>();
            int n = nums.Length;
            n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int sum = nums[i] + nums[j];
                    if (set.Contains(-sum) && -sum != nums[i] && nums[j] != -sum)
                        output.Add(new List<int> { -sum, nums[i], nums[j] });
                    else
                        set.Add(nums[j]);
                }
            }

            return output.ToList();
        }

        static IList<IList<int>> findTriplets(int[] nums)
        {
            var output = new List<IList<int>>();
            if (nums.Length < 3)
                return output;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip same result
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (sum == 0)
                    {
                        output.Add(new List<int>() { nums[i], nums[j], nums[k] });
                        ++j; --k;

                        // Skip same result
                        while (j < k && nums[j] == nums[j - 1]) ++j;
                        while (j < k && nums[k] == nums[k + 1]) --k;
                    }
                    else
                    {
                        if (sum > 0)
                            --k;
                        else
                            ++j;
                    }
                }
            }
            return output;
        }

    }
}
