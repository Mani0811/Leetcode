using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    internal class Recover_Binary_Search_Tree : BaseClass
    {
        public override void Run()
        {
            base.Run();
            var root = new TreeNode(3);
            root.left = new TreeNode(1);
            root.right = new TreeNode(4);
            root.left.left = null;
            root.left.right = null;
            root.right.right = new TreeNode(2);

            new Solution().RecoverTree(root);

        }
        public class Solution
        {
            TreeNode firstElement = null;
            TreeNode secondElement = null;
            // The reason for this initialization is to avoid null pointer exception in the first comparison when prevElement has not been initialized
            TreeNode prevElement = new TreeNode(int.MinValue);
            public void RecoverTree(TreeNode root)
            {

                // In order traversal to find the two elements
                traverse(root);

                // Swap the values of the two nodes
                int temp = firstElement.val;
                firstElement.val = secondElement.val;
                secondElement.val = temp;
            }


            private void traverse(TreeNode root)
            {

                if (root == null)
                    return;

                traverse(root.left);


                if (firstElement == null && prevElement.val > root.val)
                {
                   firstElement = prevElement;
                    Console.WriteLine("P" + prevElement.val);
                }

                // If first element is found, assign the second element to the root (refer to 2 in the example above)
                if (firstElement != null && prevElement.val > root.val)
                {
                    secondElement = root;
                    Console.WriteLine("s" + secondElement.val);
                }
                prevElement = root;

                // End of "do some business"

                traverse(root.right);
            }
        }
    }
}
