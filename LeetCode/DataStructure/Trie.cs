using LeetCode.common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Trie : BaseClass  
    {   
        public sealed override void Run()
        {
            base.Run();
        }

        TrieNode root;
        public Trie()
        {
            root = new TrieNode();

        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                TrieNode node = current.Children[ch];
                if (node == null)
                {
                    node = new TrieNode();
                    current.Children.Add(ch, node);
                }
                current = node;
            }
            //mark the current nodes endOfWord as true
            current.EndOfWord = true;
        }

        /**
         * Recursive implementation of insert into trie
         */
        public void InsertRecursive(String word)
        {
            InsertRecursive(root, word, 0);
        }

        private void InsertRecursive(TrieNode current, string word, int indx)
        {
            if (indx == word.Length - 1) 
            {
                current.EndOfWord = true;
                return;
            }
            char ch= word[indx];
            current.Children.TryGetValue(ch,out TrieNode node);
            if (node == null)
            {
                node = new TrieNode();
                current.Children.Add(ch, node);
            }
            current.Children.Add(ch, node);
            InsertRecursive(node, word, indx + 1);
        }



        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                current.Children.TryGetValue(ch, out TrieNode node);
                //if node does not exist for given char then return false
                if (node == null)
                {
                    return false;
                }
                current = node;
            }
            //return true of current's endOfWord is true else return false.
            return current.EndOfWord;

        }

        public bool StartsWith(string prefix)
        {
            TrieNode current = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char ch = prefix[i];
                current.Children.TryGetValue(ch, out TrieNode node);
                //if node does not exist for given char then return false
                if (node == null)
                {
                    return false;
                }
                current = node;
            }
            //return true of current's endOfWord is true else return false.
            return true;
        }
    }
}
