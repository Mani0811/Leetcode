using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class SearchInRotatedSortedArraySolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var result = Search(new int[] {4,5,6,7,0,1,2}, 0);

        }
        int[] Nums;
        public int Search(int[] nums, int target)
        {
            Nums = nums;

            return BinarySerach(0, nums.Length-1, target);   
        }
        public int BinarySerach(int start, int end, int target)
        {
            if (end < start) return -1;
            if (end == start)
            {
               if( Nums[end] ==target) return start;
                return -1;
            }
            var mid = (start+ end )/ 2;
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
