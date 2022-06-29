using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class FindPeakElementII : BaseClass
    {
        public override void Run()
        {
            base.Run();

            var mat = new int[][]
            {
                new int[]{1,4},
                new int[]{ 3,2},
            };
            var output = FindPeakGrid(mat);
        }

        public int[] FindPeakGrid(int[][] mat)
        {

            return Search(mat, 0, 0, mat.Length - 1);

        }
        int[] Search(int[][] mat, int cur, int s, int e)
        {

            if (s == e)
                return new int[] { s, cur };
            var mid = s + (e - s) / 2;
            var list = LinerSearch(mat, mid, 0, e);
            foreach (int item in list)
            {
                if (mat[mid][item] > mat[mid + 1][item])
                    return Search(mat, item, s, mid);
                return Search(mat, item, mid + 1, e);
            }
            return new int[] { };
        }


        List<int> LinerSearch(int[][] nums, int ind, int s, int e)
        {
            var list = new List<int>();
            int n = nums[ind].Length;
            for (int i = 0; i < n; i++)
            {
                if (i == 0 && n >= 1  )
                {
                    if(nums[ind][0] > nums[ind][1])
                    list.Add(i);
                    continue;
                }
                if (i == n - 1  )
                {
                    if(nums[ind][n - 1] > nums[ind][n - 2])
                    list.Add(i);
                    continue;
                }
                if (nums[ind][i] > nums[ind][i - 1] && nums[ind][i] > nums[ind][i + 1])
                    list.Add(i);
            }
            return list;
        }

        //public int[] FindPeakGrid(int[][] mat)
        //{

        //    for (int i = 0; i < mat.Length; i++)
        //    {
        //        var list = new List<int>();
        //        var j = Search(mat, i, 0, mat[0].Length-1, list);
        //        Console.WriteLine(i + " " + j);
        //        if ((i <=0  || mat[i][j] > mat[i - 1][j]) && (i + 1 >=mat.Length || mat[i][j] > mat[i + 1][j]))
        //            return new int[] { i, j };
        //    }
        //    return new int[] { };
        //}

        //int Search(int[][] nums, int ind, int s, int e, List<int> list)
        //{
        //    if (e < s)
        //        return 0;
        //    if (s == e)
        //        list.Add(s);
        //    var mid = s + (e - s) / 2;
        //    if (nums[ind][mid] > nums[ind][mid + 1])
        //    {
        //        return Search(nums, ind, s, mid, list);
        //    }
        //    return Search(nums, ind, mid + 1, e,list);
        //}
    }
}
