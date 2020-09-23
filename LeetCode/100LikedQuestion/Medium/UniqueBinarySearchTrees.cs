using LeetCode._100LikedQuestion.Medium;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Channels;

namespace LeetCode
{
    class UniqueBinarySearchTrees : BaseClass
    {
        const char startPranthesis = '(';
        const char endPranthesis = ')';
        List<string> output = new List<string>();
        public override void Run()
        {
            base.Run();
            var output1 = GenerateParenthesis(3);
            // var output = NumTrees(3);
        }

        //public int NumTrees(int n)
        //{
        //    int[] dp = new int[n + 1];
        //    dp[0] = 1;
        //    dp[1] = 1;
        //    for (int i = 2; i <= n; i++)
        //    {
        //        for (int j = 0; j < i; j++)
        //        {
        //            dp[i] += dp[j] * dp[i - j - 1];
        //        }

        //    }

        //    return dp[n];
        //}


        public IList<string> GenerateParenthesis(int n)
        {
            if (n == 0) return null;
            StringBuilder input = new StringBuilder();
            input.Append(startPranthesis);
            int open = 1;
            int close = 0;

            Helpers(input, open, close, n);

            return output;
        }

        private void Helpers(StringBuilder s, int open, int close, int n)
        {
            if (open < close || open > n || close > n)
                return;
            if (open + close == 2 * n && open == n)
            {
                output.Add(s.ToString());
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    s.Append(endPranthesis);
                    Helpers(s, open, close + 1, n);
                }
                else
                {
                    s.Append(startPranthesis);
                    Helpers(s, open + 1, close, n);
                }

                s.Remove(s.Length - 1, 1);
            }
        }

        public bool IsValid(string s)
        {

            Stack<char> charStack = new Stack<char>();
            foreach (var item in s.ToCharArray())
            {
                if (item == startPranthesis)
                {
                    charStack.Push(item);
                    continue;
                }
                if (charStack.Count > 0 && item == endPranthesis)
                {
                    charStack.Pop();
                    continue;
                }
                return false;
            }
            return charStack.Count == 0;
        }
    }
}
