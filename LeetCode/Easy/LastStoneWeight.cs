using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class LastStoneWeightSOLU : BaseClass
    {
        public override void Run()
        {
            var output = LastStoneWeight(new int[] { 7, 6, 7, 6, 9 });
        }


        public int LastStoneWeight(int[] stones)
        {
            var list = stones.ToList<int>();
            list = list.OrderBy(x => x).ToList();
            while (list.Count >= 2)
            {
                int n = list.Count;
                var max1 = list[n - 1];
                var max2 = list[n - 2];
                var diff = max1 - max2;
                list.RemoveAt(list.Count - 1);
                list.RemoveAt(list.Count - 1);
                var idx = list.BinarySearch(diff);
                if (idx > 0)
                {
                    list.Insert(idx + 1, diff);
                }
                else
                {
                    string s = "100";
                    int x =(int)char.GetNumericValue(s[0]);
                    CharUnicodeInfo.GetDecimalDigitValue('1');
                    if (list.Count == 1)
                    {
                        if (list[0] <= diff)
                            list.Add(diff);
                        else
                            list.Insert(0, diff);
                    }
                    else
                    {
                        if (-idx >= list.Count)
                            list.Add(diff);
                        else
                            list.Insert(-idx, diff);
                    }
                }
            }

            return list[0];
        }




        public int BinarySearch(int[] a, int s, int e, int key)
        {

            var mid = s + (e - s) / 2;
            if (a[mid] == key) return mid;
            if (s > e) return -(s);
            if (a[mid] > key)
                s = mid + 1;
            else
                e = mid - 1;
            return BinarySearch(a, s, e, key);
        }


    }
}
