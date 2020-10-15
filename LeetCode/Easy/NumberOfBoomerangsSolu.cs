using System;
using System.Collections.Generic;

namespace LeetCode
{
    class NumberOfBoomerangsSolu : BaseClass
    {
        public override void Run()
        {
            var input = new int[][]
            {
               new int[] {0,0 },
               new int[]{1, 0 },
               new int[]{2, 0 }
            };
            var output = NumberOfBoomerangs(input);
        }

        public int NumberOfBoomerangs(int[][] points)
        {
            int count = 0;
            int n = points.Length;
            for (int i = 0; i < n; i++)
            {
                Dictionary<double, int> map = new Dictionary<double, int>();
                for (int j = 0; j <n; j++)
                {
                    var area = GetDistance(i, j, points);
                    if (!map.ContainsKey(area))
                        map.Add(area, 1);
                    else
                        map[area] += 1;
                }
                foreach (var item in map)
                {
                    if (item.Value == 1) continue;
                    count += item.Value * (item.Value - 1);
                }
                
            }

            return count;
        }

        private double GetDistance(int i, int j , int[][] points)
        {
           return Math.Sqrt(Math.Pow(points[j][0] - points[i][0], 2) + Math.Pow(points[j][1] - points[i][1], 2));
        }
    }
}
