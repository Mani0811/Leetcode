using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class CloneGraphSolu : BaseClass
    {
        public override void Run()
        {
            base.Run();
        }

        Dictionary<int, Node> map = new Dictionary<int, Node>();
        public Node CloneGraph(Node node)
        {
          return  Clone(node);
          
        }
        public Node Clone(Node node)
        {
            if (node == null) return null;
            if (map.ContainsKey(node.val))
               return map[node.val];
            Node newNode = new Node(node.val, new List<Node>());
            map.Add(node.val, newNode);
            foreach (var item in node.neighbors)
            {
                newNode.neighbors.Add(Clone(item));
            }
            return newNode;
        }

        internal class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

    }
}




