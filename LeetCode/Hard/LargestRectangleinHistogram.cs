using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class LargestRectangleinHistogram : BaseClass
    {
        public override void Run()
        {
            var area = LargestRectangleArea(new int[] { 2, 1, 5, 6, 2, 3 });
             area = LargestRectangleAreaDP(new int[] { 2, 1, 5});
        }

        public int LargestRectangleAreaDP(int[] height)
        {

            if (height == null || height.Length == 0)
            {
                return 0;
            }
            var lessFromLeft = new int[height.Length]; // idx of the first bar the left that is lower than current
            var lessFromRight = new int[height.Length]; // idx of the first bar the right that is lower than current
            lessFromRight[height.Length - 1] = height.Length;
            lessFromLeft[0] = -1;

            for (int i = 1; i < height.Length; i++)
            {
                int p = i - 1;

                while (p >= 0 && height[p] >= height[i])
                {
                    p = lessFromLeft[p];
                }
                lessFromLeft[i] = p;
            }

            for (int i = height.Length - 2; i >= 0; i--)
            {
                int p = i + 1;

                while (p < height.Length && height[p] >= height[i])
                {
                    p = lessFromRight[p];
                }
                lessFromRight[i] = p;
            }

            int maxArea = 0;
            for (int i = 0; i < height.Length; i++)
            {
                maxArea = Math.Max(maxArea, height[i] * (lessFromRight[i] - lessFromLeft[i] - 1));
            }

            return maxArea;

        }


        int maxArea;
        public int LargestRectangleArea(int[] heights)
        {
            maxArea = 0;
            var stack = new Stack<int>();
            int i = 0;
            for (i = 0; i < heights.Length;)
            {
                if (stack.Count == 0 || heights[stack.Peek()] <= heights[i])
                    stack.Push(i++);
                else
                {
                    UpdateArea(heights, stack, i);
                }
            }
            while (stack.Count > 0)
                UpdateArea(heights, stack, i);
            return maxArea;
        }

        private void UpdateArea(int[] heights, Stack<int> stack, int i)
        {
            int area;
            var top = stack.Pop();
            if (stack.Count == 0)
                area = heights[top] * i;
            else
                area = heights[top] * (i - stack.Peek() - 1);
            maxArea = Math.Max(maxArea, area);
        }
    }
}
