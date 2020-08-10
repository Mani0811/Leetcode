using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }
        public bool EndOfWord { get; set; }
        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }
    }
}
