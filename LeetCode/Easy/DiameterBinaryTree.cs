using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class DiameterBinaryTree : BaseClass
    {
        public override void Run()
        {
            var TreeNode = new TreeNode(1);
            TreeNode.left = new TreeNode(2);
            TreeNode.right = new TreeNode(3);
            TreeNode.left.left = new TreeNode(4);
            TreeNode.left.right = new TreeNode(5);

            var output = DiameterOfBinaryTree(TreeNode);
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            maxlength = 0;
            Dfs(root);
            return maxlength;
        }
        int maxlength = 0;
        int Dfs(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var left = Dfs(root.left);
            var right = Dfs(root.right);
            maxlength = Math.Max(maxlength, left + right);
            return Math.Max(left,right)+1;
        }
    }
}
