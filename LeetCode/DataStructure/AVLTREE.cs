using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class AVLTREE : BaseClass
    {
        public override void Run()
        {
            /* Constructing tree given in the above figure */
            root = insert(root, 10);
            root = insert(root, 20);
            root = insert(root, 30);
            root = insert(root, 40);
            root = insert(root, 50);
            root = insert(root, 25);

            /* The constructed AVL Tree would be  
                30  
                / \  
            20 40  
            / \ \  
            10 25 50  
            */
            Console.Write("Preorder traversal" +
                            " of constructed tree is : ");

        }

        Node root;

        int height(Node N)
        {
            if (N == null)
                return 0;

            return N.height;
        }
        int getBalance(Node N)
        {
            if (N == null)
                return 0;

            return height(N.left) - height(N.right);
        }

        // A utility function to right  
        // rotate sub rooted with y  
        // See the diagram given above.  
        Node rightRotate(Node y)
        {
            Node x = y.left;
            Node T2 = x.right;

            // Perform rotation  
            x.right = y;
            y.left = T2;

            // Update heights  
            y.height = Math.Max(height(y.left),
                        height(y.right)) + 1;
            x.height = Math.Max(height(x.left),
                        height(x.right)) + 1;

            // Return new root  
            return x;
        }

        // A utility function to left 
        // rotate subtree rooted with x  
        // See the diagram given above.  
        Node leftRotate(Node x)
        {
            Node y = x.right;
            Node T2 = y.left;

            // Perform rotation  
            y.left = x;
            x.right = T2;

            // Update heights  
            x.height = Math.Max(height(x.left),
                        height(x.right)) + 1;
            y.height = Math.Max(height(y.left),
                        height(y.right)) + 1;

            // Return new root  
            return y;
        }

        Node insert(Node node, int key)
        {

            /* 1. Perform the normal BST insertion */
            if (node == null)
                return (new Node(key));

            if (key < node.key)
                node.left = insert(node.left, key);
            else if (key > node.key)
                node.right = insert(node.right, key);
            else // Duplicate keys not allowed  
                return node;
            /* 2. Update height of this ancestor node */
            node.height = 1 + Math.Max(height(node.left),
                                height(node.right));

            /* 3. Get the balance factor of this ancestor  
            node to check whether this node became  
            unbalanced */
            int balance = getBalance(node);

            // If this node becomes unbalanced, then there  
            // are 4 cases Left Left Case  
            if (balance > 1 && key < node.left.key)
                return rightRotate(node);
            // Right Right Case  
            if (balance < -1 && key > node.right.key)
                return leftRotate(node);

            // Right Right Case  
            if (balance < -1 && key > node.right.key)
                return leftRotate(node);

            // Left Right Case  
            if (balance > 1 && key > node.left.key)
            {
                node.left = leftRotate(node.left);
                return rightRotate(node);
            }

            // Right Left Case  
            if (balance < -1 && key < node.right.key)
            {
                node.right = rightRotate(node.right);
                return leftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }
        internal class Node
        {
            public int key, height;
            public Node left, right;

            public Node(int d)
            {
                key = d;
                height = 1;
            }
        }
    }

   
}
