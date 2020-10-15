using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class MountainArray
    {
        int[] A;
        public MountainArray(int[] a)
        {
            A = a;
        }
        public int Get(int index) 
        { 
            return A[index]; 
        }
        public int Length() { return A.Length; }
    }
    class FindInMountainArraySolu : BaseClass
    {
        public override void Run()
        {
            var output = PeakIndexInMountainArray(3, new MountainArray(new  int[] { 1, 2, 3, 4, 5, 3, 1 }));
        }
        
        public int PeakIndexInMountainArray(int target, MountainArray A)
        {
            int n = A.Length(), l, r, m, peak = 0;
            // find index of peak
            l = 0;
            r = n - 1;
            while (l < r)
            {
                m = (l + r) / 2;
                if (A.Get(m) < A.Get(m + 1))
                    l = peak = m + 1;
                else
                    r = m;
            }
            // find target in the left of peak
            l = 0;
            r = peak;
            while (l <= r)
            {
                m = (l + r) / 2;
                if (A.Get(m) < target)
                    l = m + 1;
                else if (A.Get(m) > target)
                    r = m - 1;
                else
                    return m;
            }
            // find target in the right of peak
            l = peak;
            r = n - 1;
            while (l <= r)
            {
                m = (l + r) / 2;
                if (A.Get(m) > target)
                    l = m + 1;
                else if (A.Get(m) < target)
                    r = m - 1;
                else
                    return m;
            }
            return -1;
        }

    }
}
