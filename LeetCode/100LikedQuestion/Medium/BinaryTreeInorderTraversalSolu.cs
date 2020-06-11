using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
   public  class BinaryTreeInorderTraversalSolu:BaseClass
    {
        public override void Run()
        {
            var root = new TreeNode(1);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3);
            var resu = InorderTraversal(root);
            base.Run();
        }
        public IList<int> InorderTraversal(TreeNode root)
        {
            var list = new List<int>();
            InorderTraversalUtil(root, list);
            return list;
        }

        private void InorderTraversalUtil(TreeNode node, List<int> list)
        {
            if (node == null) return;
            InorderTraversalUtil(node.left,list);
            list.Add(node.val);
            InorderTraversalUtil(node.right,list);
        }
    }
}
