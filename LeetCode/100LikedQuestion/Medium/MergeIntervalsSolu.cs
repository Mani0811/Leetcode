using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class MergeIntervalsSolu : BaseClass
    {
        public override void Run()
        {
            var input = new int[][]
            {
              new int[]{2, 3 },
              new int[]{2, 2},
               new int[]{3, 3},
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
            if (intervals.Length <= 1) return intervals;
            //ArraySort(intervals);
            Array.Sort(intervals, new ArrayComparater());
            var list = new List<int[]>();
            int min = intervals[0][0];
            int max = intervals[0][1];
            list.Add(new int[] { min, max });
            for (int i = 1; i < intervals.Length; i++)
            {
                var start = intervals[i][0];
                var end = intervals[i][1];
                if (start <= max)
                {
                    start = min;
                    end = Math.Max(max, end);
                    list.RemoveAt(list.Count - 1);
                    list.Add(new int[] { start, end });
                    min = Math.Min(min, start);
                    max = Math.Max(max, end);
                    continue;
                }
                list.Add(new int[] { start, end });
                min = start;
                max = end;
            }
            return list.ToArray();
        }

        private void ArraySort(int[][] intervals)
        {
            for (int i = 0; i < intervals.Length; i++)
            {
                for (int j = 0; j < intervals.Length - i - 1; j++)
                {
                    var l1 = intervals[j][0];
                    var l2 = intervals[j + 1][0];
                    if (l1 > l2 || (l1 == l2 && intervals[j][1] > intervals[j + 1][1]))
                    {
                        Swap(j, j + 1, intervals);
                    }
                }
            }
        }

        private void Swap(int i, int j, int[][] intervals)
        {
            var temp = intervals[j];
            intervals[j] = intervals[i];
            intervals[i] = temp;

        }
    }

    public class ArrayComparater : IComparer<int[]>
    {
        public int Compare(int[] a, int[] b)
        {
            return a[0] < b[0] ? -1 : a[0] == b[0] ? a[1]<b[1]?-1:1: 1;
        }
    }
}