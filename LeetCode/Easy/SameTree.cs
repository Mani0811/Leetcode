using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class SameTree : BaseClass
    {
        public override void Run()
        {
            var TreeNode = new TreeNode(1);
            TreeNode.left = new TreeNode(2);
            TreeNode.right = new TreeNode(3);
            TreeNode.left.left = new TreeNode(4);
            TreeNode.left.right = new TreeNode(5);
        }
        //1:28
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if((p==null && q!=null)||(q!=null && p==null))return false;
            if (p.val != q.val) return false;
            return IsSameTree(p.left, q.left) && IsSameTree(q.right, p.right);
        }
    }
}
