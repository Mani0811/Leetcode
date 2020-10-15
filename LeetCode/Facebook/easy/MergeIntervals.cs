using LeetCode._100LikedQuestion.Medium;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace LeetCode.Facebook
{
    class MergeIntervals : BaseClass
    {
        public override void Run()
        {
            var input = new int[][]
            {
              new int[]{2, 3 },
              new int[]{2, 5},
              new int[]{3, 4},
              new int[]{1, 3},
              new int[]{5, 7},
              new int[]{2, 2},
              new int[]{4, 6},
            };
            var result = Merge(input);
            base.Run();
        }
        public int[][] Merge(int[][] intervals)
        {
            var output = new List<int[]>();
            if (intervals.Length <= 1) return intervals;
            Array.Sort(intervals, new ArrayComparater());
            for (int i = 0; i < intervals.Length;)
            {
                var min = intervals[i][0];
                var max = intervals[i][1];
                while (intervals[i][0] <= max)
                {
                    i++;
                    max = Math.Max(intervals[i][0], max);
                }
                output.Add(new int[] { min, max });
                i++;

            }
            return null;
        }

        public class ArrayComparater : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                if (x.Length != y.Length) return -1;
                return x[0] < y[0] ? -1 : x[0] == y[0] ? x[1] < y[1] ? -1 : 1 : 1;
            }
        }
    }
}
