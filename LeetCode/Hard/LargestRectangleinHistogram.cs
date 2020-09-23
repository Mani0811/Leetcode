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
