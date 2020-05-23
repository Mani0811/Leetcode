using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class PermutationsSolu : BaseClass
    {
        public override void Run()
        {
            var result = Permute(new int[] { 1, 2, 3 });
            base.Run();
        }
        int[] Nums;
        int length;
        IList<IList<int>> output = new List<IList<int>>();

        public IList<IList<int>> Permute(int[] nums)
        {
            Nums = nums;
            length = Nums.Length;
            Permute(nums, 0);
            return output;
        }

        public void Permute(int[] inp, int n)
        {
            if (n == length)
            {
                output.Add(inp.ToList());
            }

            for (int i = n; i < length; i++)
            {
                var array = Swap(inp,n,i);
                Permute(array, n + 1);
                array = Swap(inp,i,n);
            }
        }

        private int[] Swap(int[] numms, int i, int j)
        {
            var temp = numms[i];
            numms[i] = numms[j];
            numms[j] = temp;
            return numms;
        }


    }
}

