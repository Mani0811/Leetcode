using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class PathSum3 : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var root = new TreeNode(1000000000);
            root.left = new TreeNode(1000000000);
            root.right =null;
            root.left.left = new TreeNode(294967296);
            root.left.right =null;
            root.right.left = new TreeNode(1000000000);
            root.left.left.left = new TreeNode(1000000000);
            root.left.left.right = null;
           // root.right.left.left = new TreeNode(1000000000);
            var solu = PathSum(root, -1);
           
        }
        public int PathSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            return IsMatchingSum(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
        }
        public static int IsMatchingSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            int count = 0;
            if (root.val == sum)
                count = 1;
            var newsum = sum - root.val;
            count+= IsMatchingSum(root.left, newsum);
            count += IsMatchingSum(root.right, newsum);
            
            return count;
        }

    }
}
