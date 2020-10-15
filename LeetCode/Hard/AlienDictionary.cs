using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class AlienDictionary : BaseClass
    {

        public override void Run()
        {

        }
        public char[] GetDictonary(string[] list)
        {
            return null;
        }

        private void CreateTrie(List<string> list)
        {
            var charList1 = new List<char>();
            foreach (var item in list)
            {
                charList1.Add(item[0]);

            }
            
        }

        class TrieTreeNode
        {
            public Dictionary<char,TrieTreeNode> Children { get; set; }
            char Value { get; set; }

            public TrieTreeNode(char v)
            {
                Value = v;
                Children = new Dictionary<char, TrieTreeNode>();
            }

        }
    }


}
