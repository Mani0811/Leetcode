using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class ConstructBinaryTreefromPreorderandInorderTraversalSolu : BaseClass
    {
        public override void Run()
        {
            int[] preorder = new int[] { 3, 9, 20, 15, 7 };
            int[] inorder = new int[] { 9, 3, 15, 20, 7 };
            var result = BuildTree(inorder, preorder);
            base.Run();
        }
        int[] _inorder, _preorder;
        int preOrderIndx = 0;
        public TreeNode BuildTree(int[] inorder, int[] preorder)
        {
            _inorder = inorder;
            _preorder = preorder;
            preOrderIndx = 0;
            return BuildTreeUtil(0, inorder.Length - 1);
        }

        public TreeNode BuildTreeUtil(int inorderStart, int inorderMax)
        {
           
            if (inorderMax < inorderStart) return null;

            var rootNode = new TreeNode(_preorder[preOrderIndx++]);

            if (inorderStart == inorderMax) return rootNode;

            int indx = 0;
            for (int j = inorderStart; j <= inorderMax; j++)
            {
                if (_inorder[j] == rootNode.val)
                {
                    indx = j;
                    break;
                }
            }
            rootNode.left = BuildTreeUtil( inorderStart, indx - 1);
            rootNode.right = BuildTreeUtil( indx + 1, inorderMax);
            return rootNode;

        }
       
    }
}