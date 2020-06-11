using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class ValidateBinarySearchTreeSolu : BaseClass
    {
        public override void Run()
        {
            var root = new TreeNode(5);
            root.left = new TreeNode(1);
            root.right = new TreeNode(4);
            root.right.left = new TreeNode(3);
            root.right.right = new TreeNode(6);
            var resu = IsValidBST(root);
            base.Run();
        }
        public bool IsValidBST(TreeNode root)
        {
           return IsValidBSTUtil(root, null, null);
        }

        private bool IsValidBSTUtil(TreeNode root, int? min, int? max)
        {
            if (root == null) return true;

            int val = root.val;
            if (min != null && val <= min) return false;
            if (max != null && val >= max) return false;

            if (!IsValidBSTUtil(root.right, val, max)) return false;
            if (!IsValidBSTUtil(root.left, min, val)) return false;
            return true;
        }

    }
}


