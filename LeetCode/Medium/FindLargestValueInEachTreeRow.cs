using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{

    class FindLargestValueInEachTreeRow : BaseClass
    {
        public override void Run()
        {
            base.Run();

            var root = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5),
                    right = new TreeNode(3)
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(9)
                }
            };

            var result = LargestValues(root);
        }
        public IList<int> LargestValues(TreeNode root)
        {
            List<int> res = new List<int>();
            helper(root, res, 0);
            return res;
        }

        private void helper(TreeNode root, List<int> res, int d)
        {
            if (root == null)
            {
                return;
            }
            //expand list size
            if (d == res.Count)    
            {
                res.Add(root.val);
            }
            else
            {
                //or set value
               // res.Add(d, Math.Max(res(d), root.val));
            }
            helper(root.left, res, d + 1);
            helper(root.right, res, d + 1);
        }
    }
}
