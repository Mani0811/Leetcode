using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class IncreasingBSTSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var root = new TreeNode(5);
            root.right = new TreeNode(6);
            root.right.right = new TreeNode(8);
            root.right.right.right = new TreeNode(9);
            root.right.right.left = new TreeNode(7);
            root.left = new TreeNode(3);
            root.left.left = new TreeNode(2);
            root.left.left.left = new TreeNode(2);
            root.left.right = new TreeNode(4);
            var outputNode = IncreasingBST(root);
        }
        TreeNode rr = null;
        TreeNode parent = null;
        public TreeNode IncreasingBST(TreeNode root)
        {
            Helper(root);

            return rr;

        }

        public void Helper(TreeNode root)
        {
            if (root == null) return;
            IncreasingBST(root.left);
            if (parent == null)
            {
                rr = new TreeNode(root.val);
                parent = rr;
            }
            else
            {
                parent.right = new TreeNode(root.val);
                parent = parent.right;
            }
            IncreasingBST(root.right);
        }
    }
}
