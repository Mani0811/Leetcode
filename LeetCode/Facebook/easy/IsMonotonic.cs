using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class IsMonotonicSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();

            var output = IsMonotonic(new int[] { 1,3,2});
        }
        public bool IsMonotonic(int[] A)
        {
            return (Helper(A, true) || Helper(A, false));
        }

        bool Helper(int[] A, bool falg)
        {
            for (int i = 0; i < A.Length - 1; i++)
            {
                int j = i + 1;
                if (falg)
                {
                    if(!(A[i]<= A[j]))
                        return false;
                }
                else
                {
                    if (!( A[i]>= A[j]))
                        return false;
                }

            }
            return true;
        }
    }


}
