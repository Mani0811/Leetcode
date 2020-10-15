using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class MergeSortedArray : BaseClass
    {
        public override void Run()
        {
            base.Run();
            Merge(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3);

        }

        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {

            var res = new int[m + n];
            int f = 0;
            int s = 0;
            int r = 0;
            while (f < m && s < n)
            {
                if (nums1[f] <= nums2[s])
                {
                    res[r] = nums1[f];
                    f++;
                    r++;
                }
                else
                {
                    res[r] = nums2[s];
                    s++;
                    r++;
                }
            }
            int rl = f == m ? n : m;
            int sl = f == m ? s : f;
            for (int i = sl; i < rl; i++)
            {
                if (f < m)
                {
                    res[r++] = nums1[i];
                }
                else
                    res[r++] = nums2[i];

            }
            nums1 = res;

        }

    }
}
