using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class FindFirstandLastPositionofElementinSortedArraySolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var result = SearchRange(new int[] {1 }, 1);
        }
        int[] Nums;
        public int[] SearchRange(int[] nums, int target)
        {
            Nums = nums;
            int pos = Array.BinarySearch(nums, target);
            if (pos<0 ) return new int[] { -1, -1 };
            int j = pos, k = pos;
            while (j< nums.Length-1 && nums[j + 1] == target)
            {
                j++;
            }
            while (k > 0 && nums[k-1] == target )
            {
                k--;
            }
            return new int[] { k, j };
        }

        public int BinarySerach(int start, int end, int target)
        {
            if (end < start) return -1;
            if (end == start)
            {
                if (Nums[end] == target) return start;
                return -1;
            }
            var mid = (start + end) / 2;
            if (Nums[mid] == target) return mid;
            if (Nums[mid] > Nums[start])
            {
                if (target >= Nums[start] && target <= Nums[mid - 1])
                    return BinarySerach(start, mid - 1, target);
                else
                    return BinarySerach(mid + 1, end, target);
            }
            else
            {
                if (target >= Nums[mid + 1] && target <= Nums[end])
                    return BinarySerach(mid + 1, end, target);
                else
                    return BinarySerach(start, mid - 1, target);
            }
        }
    }
}
