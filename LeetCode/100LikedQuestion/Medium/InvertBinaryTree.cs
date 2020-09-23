using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class InvertBinaryTree :BaseClass
    {
        public override void Run()
        {
            base.Run();

            var root = new TreeNode(4);
            //root.left = new TreeNode(7);
            //root.left.left = new TreeNode(9);
            //root.left.right = new TreeNode(6);
            root.right = new TreeNode(2);
            root.right.left = new TreeNode(3); 
            root.right.right = new TreeNode(1);
            var output = InvertTree(root);
        }

        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return null;
            var temp = InvertTree(root.left);
            root.left = InvertTree(root.right);
            root.right = temp;
            return root;
        }

      
    }
}
