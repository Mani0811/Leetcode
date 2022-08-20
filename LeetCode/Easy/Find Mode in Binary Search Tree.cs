using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Easy
{
    internal class Find_Mode_in_Binary_Search_Tree : BaseClass
    {
        public override void Run()
        {
            base.Run();
        }

        Dictionary<int,int> map = new Dictionary<int, int>();
        public int[] FindMode(TreeNode root)
        {

            if (root == null) return null;
            FindMode(root.left);
            if (map.ContainsKey(root.val))
                map[root.val] += 1;
            else
                map.Add(root.val, 1);
            FindMode(root.right);

            int maxvalue = 0;
            foreach (var item in map)
            {
                maxvalue = Math.Max(maxvalue, item.Value);
            }
            var list = new List<int>();
            foreach (var item in map)
            {
                if(item.Value == maxvalue)
                 list.Add(item.Value);
            }
            return list.ToArray();
        }
    }
}
