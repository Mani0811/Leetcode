using LeetCode.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace LeetCode
{
    class AllNodesDistanceKinBinaryTree : BaseClass
    {

        public override void Run()
        {
            base.Run();

            var root = new TreeNode(3);
            root.left = new TreeNode(5);
            root.right = new TreeNode(1);
            root.left.left = new TreeNode(6);
            root.left.right = new TreeNode(2);
            root.left.right.left = new TreeNode(7);
            root.left.right.right = new TreeNode(4);
            root.right.left = new TreeNode(0);
            root.right.right = new TreeNode(0);
            var result = DistanceK(root, root.left, 2);

        }
        List<int> output;
        Dictionary<TreeNode, TreeNode> parent;
        HashSet<TreeNode> set;
        Queue<TreeNode> queue;
        public IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            parent = new Dictionary<TreeNode, TreeNode>();
            output = new List<int>();
            set = new HashSet<TreeNode>();
            queue = new Queue<TreeNode>();
            dfs(root, null);
            ////////
            queue.Enqueue(null);
            queue.Enqueue(target);

            int level = 0;
            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();
                set.Add(curr);
                if (curr == null)
                {
                    if (level == K)
                    {

                        while (queue.Count > 0)
                        {
                            output.Add(queue.Dequeue().val);
                        }
                        break;
                    }
                    level++;
                    queue.Enqueue(null);
                }
                else
                {

                    if (!set.Contains(curr.left) && curr.left != null)
                        queue.Enqueue(curr.left);
                    if (!set.Contains(curr.right) && curr.right != null)
                        queue.Enqueue(curr.right);
                    if (!set.Contains(parent[curr]) && parent[curr] != null)
                        queue.Enqueue(parent[curr]);

                }
            }
            ///
            return output;
        }
        private void dfs(TreeNode node, TreeNode par)
        {
            if (node != null)
            {
                parent.Add(node, par);
                dfs(node.left, node);
                dfs(node.right, node);
            }
        }
    }
}
