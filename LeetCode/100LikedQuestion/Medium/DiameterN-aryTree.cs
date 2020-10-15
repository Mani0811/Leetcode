using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{

    class DiameterN_aryTree : BaseClass
    {
        public class TreeNode
        {
            public int Val;
            public List<TreeNode> Children;

            public TreeNode(int v)
            {
                Val = v;
                Children = new List<TreeNode>();
            }

        };
        int maxlength = 0;
        public override void Run()
        {
            maxlength = 0;
            var TreeNode = new TreeNode(1);
            TreeNode.Children.Add(new TreeNode(2));
            TreeNode.Children.Add(new TreeNode(3));
            TreeNode.Children[0].Children.Add(new TreeNode(4));
            TreeNode.Children[0].Children.Add(new TreeNode(5));

            var output = DepthOfTree(TreeNode);
        }
        
        public int DepthOfTree(TreeNode root)
        {
             Dfs(root);
            return maxlength;
        }
        
        int Dfs(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int h1 = 0; int h2 = 0;
            int tempmax=0;

            foreach (var item in root.Children)
            {
                int h = Dfs(item);
                if (h > h1)
                {
                    h2 = h1;
                    h1 = h;
                }
                else if (h > h2)
                    h2 = h;
                tempmax = Math.Max(tempmax, h);
            }
            
            maxlength = Math.Max(maxlength, h2+h1);
            return tempmax + 1; ;
        }
    }
}
