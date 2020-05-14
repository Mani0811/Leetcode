using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class ContainerWithMostWaterSolu : BaseClass
    {
        public override void Run()
        {
            var result = MaxArea(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 });
            base.Run();

        }

        public int MaxArea1(int[] height)
        {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r)
            {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }

        public int MaxArea(int[] height)
        {
            Dictionary<int, int> leftValue = new Dictionary<int, int>();
            Dictionary<int, int> rightValue = new Dictionary<int, int>();
            int lastleft = 0, lastright = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (!leftValue.ContainsKey(i) && i > 0 && leftValue[lastleft] >= height[i])
                    continue;
                else
                {
                    lastleft = i;
                    leftValue.Add(i, height[i]);
                }
            }

            for (int i = height.Length - 1; i > 0; i--)
            {
                if (!rightValue.ContainsKey(i) && i < height.Length - 1 && rightValue[lastright] >= height[i])
                    continue;
                else
                {
                    lastright = i;
                    rightValue.Add(i, height[i]);
                }
            }
            int MaxArea = 0;
            foreach(var litem in leftValue)
            {
                foreach (var ritem in rightValue)
                {
                    if (ritem.Key > litem.Key)
                        MaxArea=Math.Max(MaxArea, Math.Min(ritem.Value, litem.Value) * (ritem.Key - litem.Key));
                    else
                        break;

                }
            }
            return MaxArea;
        }
    }
}
