using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Facebook
{
    class MinimumRemovetoMakeValidParentheses :BaseClass
    {
        public override void Run()
        {
            base.Run();
            var output = MinRemoveToMakeValid("))((");
        }
        StringBuilder sb = new StringBuilder();
        Stack<(char ch, int ind)> st = new Stack<(char ch, int ind)>();
        public string MinRemoveToMakeValid(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                    st.Push(('(', i));
                else if (s[i] == ')')
                {
                    if (st.Count > 0 && st.Peek().ch == '(')
                        st.Pop();
                    else
                        st.Push((')', i));
                }
            }

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (st.Count > 0 && st.Peek().ind == i)
                {
                    st.Pop();
                    continue;
                }
                sb.Append(s[i]);
            }

            return new string(sb.ToString().Reverse().ToArray());
        }
        public string MinRemoveToMakeValid1(string s)
        {
            Stack<char> stack = new Stack<char>();
            string output = "";
            int sc = 0;
            int ec = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char iChar = s[i];
                if (!(IsValid(iChar))) continue;
                if (iChar == '(') sc++;
                if (iChar == ')')
                {
                    if (ec + 1 > sc) continue;
                    sc--;
                }
                stack.Push(iChar);

            }

            while (stack.Count != 0)
            {
                var rc = stack.Pop();
                if (rc == '(' && sc > ec)
                {
                    sc--;
                    continue;
                }
                output = rc + output;
            }
            return output;
        }

        bool IsValid(char c)
        {
            if (c == '(' || c == ')' || (c >= 'a' && c <= 'z')) return true;
            return false;
        }
    }
}
