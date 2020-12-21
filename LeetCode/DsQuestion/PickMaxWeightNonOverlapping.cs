using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode

{
    public class PickMaxWeightNonOverlapping : BaseClass
    {

        public override void Run()
        {
            base.Run();
            var startTime = new int[] { 24, 24, 7, 2, 1, 13, 6, 14, 18, 24 };
            var endTime = new int[] { 27, 27, 20, 7, 14, 22, 20, 24, 19, 27 };
            var profit = new int[] { 6, 1, 4, 2, 3, 6, 5, 6, 9, 8 };
            var result = JobScheduling(startTime, endTime, profit);
            var mat = new int[,]
            { { 1, 1, 1, 1, 0 },
                    { 0, 1, 0, 1, 1 },
                    { 1, 0, 0, 0, 1 },
                    { 0, 1, 0, 1, 0 },
                    { 0, 1, 0, 0, 1 } };

            var output = minimunMoves(5, 5, mat);
        }

        static int minimunMoves(int r, int c, int[,] mat)
        {
            int totalCount = 0;
            var midC = (c) / 2;
            for (int j = 0; j < r; j++)
            {
                int count =0;
                for (int i = 0; i < midC; i++)
                {
                    if (mat[j, i] == mat[j, c - 1 - i]) continue;
                    count++;
                }
                totalCount += count/2+count%2;
            }
            return totalCount;
        }

        /*
    * Sort the jobs by finish time.
    * For every job find the first job which does not overlap with this job
    * and see if this job profit plus profit till last non overlapping job is greater
    * than profit till last job.
    * @param jobs
    * @return
    */
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            Job[] jobs = new Job[startTime.Length];

            for (int i = 0; i < startTime.Length; i++)
            {
                jobs[i] = new Job(startTime[i], endTime[i], profit[i]);
            }


            jobs = jobs.OrderBy(j => j.end).ThenBy(i=>i.profit).ToArray();
            endTime = jobs.Select(i => i.end).ToArray();
            profit = jobs.Select(i => i.profit).ToArray();
            int n = startTime.Length;
            int[] dp = new int[n];
            dp[0] = profit[0];
            for (int i = 1; i < n; i++)
            {
                int idx = binarySearch(endTime, jobs[i].start, 0, i - 1);
                int prevValue = 0;
                if (idx != -1)
                    prevValue = dp[idx];
                dp[i] = Math.Max(prevValue + jobs[i].profit, dp[i - 1]);
            }
            return dp[n - 1];
        }

        public int binarySearch(int[] endTime, int value, int si, int ei)
        {
            if (si > ei)
                return si - 1;
            int mid = (si + ei) / 2;

            if (value < endTime[mid])
            {
                return binarySearch(endTime, value, si, mid - 1);
            }
            return binarySearch(endTime, value, mid + 1, ei);
        }

        public class Job
        {
            public int start;
            public int end;
            public int profit;
            public Job(int start, int end, int profit)
            {
                this.start = start;
                this.end = end;
                this.profit = profit;
            }
        }
    }
}
