using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class KClosestPointstoOrigin : BaseClass
    {
        public override void Run()
        {
            var res = Search(new int[]{4, 5, 6, 7, 0,1,2},3);
            var points = new int[][]
            {
                new int[]{-5,4},
new int[]{-3,2},
new int[]{0,1},
new int[]{-3,7},
new int[]{-2,0},
new int[]{-4,-6}
            };

            var x = KClosest(points, 4);
        }


        int[] nums = null;
        public int Search(int[] n, int target)
        {
            nums = n;
            return BS(0, nums.Length - 1, target);
        }

        int BS(int s, int e, int t)
        {
            if (e < s) return -1;
            if (e == s)
            {
                if (nums[e] == t) return s;
                return -1;
            }
            if (e >= s)
            {
                var m = s + (e - s) / 2;
                if (nums[m] == t) return m;

                if( nums[m]>nums[s])
                {
                    if (nums[s] <= t && t <= nums[m - 1])
                        return BS(s, m - 1, t);
                    else
                        return BS(m + 1, e, t);
                }
                else
                {
                    if (nums[m + 1] <= t && t <= nums[e])
                        return BS(m + 1, e, t);
                    else
                        return BS(s, m - 1, t);
                }


            }
            return -1;
        }

        public int[][] KClosest(int[][] points, int k)
        {

            int n = points.Length;
            var dists = new double[n];
            MaxHeap heap = new MaxHeap(k);


            for (int i = 0; i < n; i++)
            {
                dists[i] = Math.Sqrt(points[i][0] * points[i][0] + points[i][1] * points[i][1]);
                if (heap.Add(dists[i]))
                {
                    continue;
                }
                else if (heap.GetMax() > dists[i])
                {
                    heap.ExtractMax();
                    heap.Add(dists[i]);
                }
            }
            var disk = heap.GetMax();
            int[][] ans = new int[k][];
            int t = 0;
            for (int i = 0; i < n; i++)
            {
                var dis = Math.Sqrt(points[i][0] * points[i][0] + points[i][1] * points[i][1]);
                if (dis <= disk )
                {
                    ans[t++] = points[i];
                }
            }
            return ans;
        }

        public class MaxHeap
        {
            double[] heapArray;
            int curr;
            double capacity;

            public MaxHeap(int n)
            {
                heapArray = new double[n];
                capacity = n;
            }

            public bool Add(double i)
            {
                if (curr == capacity)
                {
                    // heap is full 
                    return false;
                }
                heapArray[curr] = i;
                HeapifyUp();
                curr++;
                return true;
            }
            public double GetMax()
            {
                return heapArray[0];
            }

            public double ExtractMax()
            {
                if (curr <= 0)
                {
                    return double.MinValue;
                }
                if (curr == 1)
                {
                    curr--;
                    return heapArray[0];
                }
                var max = heapArray[0];
                heapArray[0] = heapArray[curr-1];
                curr--;
                HeapifyDown(0);
                return max;

            }
            public void HeapifyDown(int indx)
            {
                int left = Left(indx);
                int right = Right(indx);
                int max = indx;
                if (left<curr && heapArray[left] > heapArray[max])
                    max = left;

                if (right<curr && heapArray[right] > heapArray[max])
                    max = right;
                if (max != indx)
                {
                    swap(max, indx);
                    HeapifyDown(max);
                }


            }

            public void deleteRoot()
            {
                heapArray[0] = int.MaxValue;
                curr--;
                HeapifyDown(0);

            }
            int Left(int i)
            {
                return 2*i+1;
            }
            int Right(int i)
            {
                return 2*i+2;
            }
            public void HeapifyUp()
            {
                var curridx = curr;
                var par = Parent(curr);
                while (curridx != 0 && heapArray[curridx] > heapArray[par])
                {
                    swap(curridx, par);
                    curridx = par;
                    par = Parent(curridx);
                }

            }

            int Parent(int i)
            {
                return (i - 1) / 2;
            }

            void swap(int i, int j)
            {
                var temp = heapArray[i];
                heapArray[i] = heapArray[j];
                heapArray[j] = temp;
            }
        }
    }
}
