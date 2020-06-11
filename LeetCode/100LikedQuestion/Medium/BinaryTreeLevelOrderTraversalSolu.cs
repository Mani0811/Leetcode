using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class BinaryTreeLevelOrderTraversalSolu : BaseClass
    {
        public override void Run()
        {
            var root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            var resu = LevelOrder(root);
            base.Run();
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var list = new List<IList<int>>();
            if (root == null) return list;
            var dummpNode = new TreeNode(0);
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(dummpNode);
            List<int> levlList = new List<int>();
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                
                if (node == dummpNode)
                {
                    list.Add(levlList);
                    levlList = new List<int>();
                    if (queue.Count > 0)
                        queue.Enqueue(dummpNode);
                    continue;
                }
                else
                {
                    levlList.Add(node.val);
                }

                if (node.left != null)
                    queue.Enqueue(node.left);
                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            return list;

        }
    }
}
