using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class MinimumCostTreeFromLeafValues : BaseClass
    {
        private int _sum = 0;
        public override void Run()
        {
            base.Run();
            var result = MctFromLeafValues(new int[] {6, 2,4 });
         }

        public int MctFromLeafValues(int[] arr)
        {
            Helper(arr, 0, arr.Length - 1);
            return _sum;
        }
        private int Helper(int[] arr, int s, int e)
        {
            if (s > e)
            {
                return 0;
            }
            if (s == e)
            {
                return arr[s];
            }
            int max = s;
            for (int i = s + 1; i <= e; i++)
            {
                if (arr[i] > arr[max])
                {
                    max = i;
                }
            }
            int left = Helper(arr, s, max - 1);
            int right = Helper(arr, max + 1, e);

            _sum += arr[max] * (left + right);
            return arr[max];
        }
    }
}
