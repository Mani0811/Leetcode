using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class House_Robber_III : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var root = new TreeNode(3);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.right = new TreeNode(3);
            root.right.right = new TreeNode(1);

            var solu = PathSum(root,8);
        }

        int count = 0;
        public int PathSum(TreeNode root, int t)
        {
            if (root == null) return 0;
            Helper(root, t, 0);
            PathSum(root?.left, t);
            PathSum(root?.right, t);
            return count;
        }

        public void Helper(TreeNode root, int t, int sum)
        {
            if (root == null) return;

            sum += root.val;
            if (sum == t)
            {
                count++;
                return;
            }

            if (root.left != null)
                Helper(root.left, t, sum);
            if (root.right != null)
                Helper(root.right, t, sum);
        }
        public class Solution
        {
            public int Rob(TreeNode root)
            {

                var list = new List<int>();
                bool flag = false;
                if (root == null) return 0;

                var queue = new Queue<TreeNode>();
                queue.Enqueue(root);
                var count = queue.Count;

                while (queue.Count > 0)
                {
                    int sum = 0;

                    for (int i = 0; i < count; i++)
                    {
                        var node = queue.Dequeue();
                        sum += node.val;

                        if (node.left != null)
                            queue.Enqueue(node.left);
                        if (node.right != null)
                            queue.Enqueue(node.right);
                    }
                    count = queue.Count;
                    list.Add(sum);
                }

                count = list.Count;
                var nlist = new int[count+1];
                nlist[0]=0;
                nlist[1]=list[0];
                for (int i = 2; i < count+1; i++)
                {
                    nlist[i] = Math.Max(nlist[i - 2] + list[i-1], nlist[i - 1]);
                }

                return nlist[nlist.Length - 1];
            }
        }
    }
}
