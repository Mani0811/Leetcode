using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class Insert_IntervalSolu : BaseClass
    {
        public override void Run()
        {
            var intervals = new int[][]
            {
                new int[]{1, 5 },
                //new int[]{3, 5 },
                //new int[]{6, 7 },
                //new int[]{8, 10 },
                //new int[]{12, 16 }
            };
            var nint = new int[] { 2,3 };
            var output = Insert(intervals, nint);
              
        }
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {

            List<int[]> result = new List<int[]>();
            foreach (var interval in intervals)
            {
                if (newInterval[0] > interval[1])
                {
                    result.Add(interval);
                }

                else if (newInterval[1] < interval[0])
                {
                    result.Add(newInterval);
                    newInterval = interval;
                }

                else
                {
                    newInterval[0] = Math.Min(interval[0], newInterval[0]);
                    newInterval[1] = Math.Max(interval[1], newInterval[1]);
                }
            }

            result.Add(newInterval);
            return result.ToArray();
        }
    }
}
