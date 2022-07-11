using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Easy
{
    class Last_Stone_Weight : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var output = LastStoneWeightBS(new int[]{ 9,3,2,10});
        }

        // sorted array
        public int LastStoneWeight(int[] stones)
        {
            var n = stones.Length;
            for (int i = 1; i < n; i++)
            {
                Array.Sort(stones);
                if (stones[n - 1] == stones[n - 2])
                    stones[n - 1] = stones[n - 2] = 0;
                else
                {
                    var num = Math.Abs(stones[n - 1] - stones[n - 2]);
                    stones[n - 1] = num;
                    stones[n - 2] = 0;
                }
            }

            return stones[n - 1];
        }
        public int LastStoneWeightBS(int[] stones)
        {
            if (stones.Length == 2)
            {
                return Math.Abs(stones[1] - stones[0]);
            }

            Array.Sort(stones);
            List<int> s = new List<int>(stones);

            while (s.Count > 1)
            {
                int first = s[s.Count - 1];
                int second = s[s.Count - 2];
                int smash = first - second;
                s.RemoveAt(s.Count - 1);
                s.RemoveAt(s.Count - 1);

                if (smash != 0)
                {
                    int index = s.BinarySearch(smash);
                    if (index < 0)
                    {
                        index = ~index;
                    }
                    s.Insert(index, smash);
                }
            }
            if(s.Count>0)
            return s[0];
            return 0;
        }

        // PriorityQueue

        //public int LastStoneWeight(int[] stones)
        //{
        //    var q = new PriorityQueue<int, int>(stones.Select(x => (x, -x)));

        //    while (q.Count > 1)
        //    {
        //        int a = q.Dequeue() - q.Dequeue();
        //        if (a != 0) q.Enqueue(a, -a);
        //    }

        //    return (q.Count == 0) ? 0 : q.Peek();
        //}
    }
}
