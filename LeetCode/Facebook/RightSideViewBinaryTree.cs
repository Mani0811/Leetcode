using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class RightSideViewBinaryTree : BaseClass
    {

        public override void Run()
        {
            var input = new List<List<int>>()
            {
                new List<int>{3,4 },
                new List<int>{ 2,3},
                new List<int>{2,2 },
            };
            var x = finalState(input);
            var r = new TreeNode(1);
            r.left = new TreeNode(2);
            r.right = new TreeNode(3);
            r.left.right = new TreeNode(4);
            r.left.right = new TreeNode(5);
            var xr = RightSideView1(r);
        }

        public static long finalState(List<List<int>> operations)
        {
            var outl = new List<int>();
            foreach (var state in operations)
            {
                var sP = state[0];
                var eP = state[1];
                if (outl.Count == 0)
                {
                    for (int i = 0; i <sP; i++)
                    {
                        outl.Add(0);
                    }
                }
                for (int i = sP; i <= eP; i++)
                {

                    if (i > 0 && i <= outl.Count)
                    {
                        if (outl[i - 1] == 0)
                        {
                            outl[i - 1] = 1;
                        }
                        else
                        {
                            outl[i - 1] = 0;
                        }
                    }
                    else
                    {
                        outl.Add(1);
                    }
                }
            }
            int sum = 0;
            for (int i = 0; i < outl.Count; i++)
            {
                if (outl[i] == 1)
                    sum = sum + i + 1;
            }
            return (long)sum;
        }

        public IList<int> RightSideView1(TreeNode root)
        {
            var list = new List<int>();
            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            TreeNode prev = null;
            while (q.Count != 0)
            {
                int len = q.Count;
                while (len > 0)
                {
                    var n = q.Dequeue();

                    if (n.left != null)
                        q.Enqueue(n.left);
                    if (n.right != null)
                        q.Enqueue(n.right);
                    prev = n;
                    len--;
                }
                if (len == 0)
                {
                    list.Add(prev.val);
                }
            }

            return list;

        }

        public List<int> RightSideView(TreeNode root)
        {
            Dictionary<int, int> rightmostValueAtDepth = new Dictionary<int, int>();
            int max_depth = -1;

            /* These two stacks are always synchronized, providing an implicit
             * association values with the same offset on each stack. */
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();
            Stack<int> depthStack = new Stack<int>();
            nodeStack.Push(root);
            depthStack.Push(0);

            while (nodeStack.Count != 0)
            {
                TreeNode node = nodeStack.Pop();
                int depth = depthStack.Pop();

                if (node != null)
                {
                    max_depth = Math.Max(max_depth, depth);

                    /* The first node that we encounter at a particular depth contains
                    * the correct value. */
                    if (!rightmostValueAtDepth.ContainsKey(depth))
                    {
                        rightmostValueAtDepth.Add(depth, node.val);
                    }

                    nodeStack.Push(node.left);
                    nodeStack.Push(node.right);
                    depthStack.Push(depth + 1);
                    depthStack.Push(depth + 1);
                }
            }

            /* Construct the solution based on the values that we end up with at the
             * end. */
            List<int> rightView = new List<int>();
            for (int depth = 0; depth <= max_depth; depth++)
            {
                rightView.Add(rightmostValueAtDepth[depth]);
            }

            return rightView;
        }
    }
}

