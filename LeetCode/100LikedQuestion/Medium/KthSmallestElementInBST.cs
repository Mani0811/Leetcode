using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class KthSmallestElementInBST : BaseClass
    {
        static int count = 0;
        public override void Run()
        {
            base.Run();
            var root = new TreeNode(5);
            root.left = new TreeNode(3);
            root.right = new TreeNode(6);
            root.left.right = new TreeNode(4);
            root.left.left = new TreeNode(2);
            root.left.left.left = new TreeNode(1);
            var result = KthSmallest(root, 3);
        }

        public int KthSmallest(TreeNode root, int k)
        {
           var resu = POT(root, k);
            return resu.val;


        }

         TreeNode POT(TreeNode node, int k)
        {
            if (node == null) return  null;
            
            //search in left subtree
           var left = POT(node.left, k);
            if (left != null) return left;
            count++;
            if (count == k)
                return node;

            return POT(node.right, k);
        }

    }
}
