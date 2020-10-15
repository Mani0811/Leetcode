using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class PeakIndexina_MountainArraySolu :BaseClass
    {
        public override void Run()
        {
            var output = PeakIndexInMountainArray(new int[] { 1, 3, 2, 3, 4 });
        }

        public int PeakIndexInMountainArray(int[] arr)
        {
            return search(arr, 0, arr.Length - 1);
        }
        public int search(int[] nums, int l, int r)
        {
            if (l == r)
                return l;
            int mid = (l + r) / 2;
            if (nums[mid] > nums[mid + 1])
                return search(nums, l, mid);
            return search(nums, mid + 1, r);
        }
    }
}
