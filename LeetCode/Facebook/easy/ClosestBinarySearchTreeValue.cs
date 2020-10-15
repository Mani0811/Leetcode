using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class ClosestBinarySearchTreeValue : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var root = new TreeNode(4);
            root.right = new TreeNode(5);

            root.left = new TreeNode(2);
            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(3);
            var outputNode = ClosestValue(root, 3.714286);
        }

        double min= double.MaxValue;
        TreeNode mn;
        double Target;
        public int ClosestValue(TreeNode root, double target)
        {
            Target = target;
            Helper(root);
            return mn.val;

        }
        public void Helper(TreeNode root)
        {
            if (root == null) return;
            Helper(root.left);

            var diff = Math.Abs(root.val - Target);
            if (diff<min)
            {
                min = diff;
                mn = root;
            }



            Helper(root.right);
        }
    }
}
