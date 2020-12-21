using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Medium
{
    class FindAllSubsetBackTrack : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var res = Subsets(new int[] { 1, 2, 3 });
        }

        List<IList<int>> res;
        public IList<IList<int>> Subsets(int[] nums)
        {
            // 0 to 7 with 1
            //bcak track
            res = new List<IList<int>>();
            BackTrack(new List<int>(), nums, 0);
            return res;            
        }

        public void Backtrack(List<int> tempList, int[] nums, int start)
        {
            var x = new List<int>();
            x.AddRange(tempList);
            res.Add(x);
            for(int i=start; i<nums.Length;i++)
            {
                tempList.Add(nums[i]);
                Backtrack(tempList, nums, i + 1);
                tempList.Remove(nums[i]);
            }

        }

        public void BackTrack(List<int> tempList, int[] nums, int start)
        {
            var list = new List<int>();
            list.AddRange(tempList);
            res.Add(list);
            for (int i = start; i < nums.Length; i++)
            {
                if (i> start && nums[i- 1] == nums[i]) continue;
                tempList.Add(nums[i]);
                BackTrack(tempList, nums, i + 1);
                tempList.Remove(nums[i]);
            }
        }

        
    }
}
