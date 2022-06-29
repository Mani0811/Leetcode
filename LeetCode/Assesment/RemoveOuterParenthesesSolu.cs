
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Assesment
{
    class RemoveOuterParenthesesSolu :BaseClass
    {

        public override void Run()
        {
            //  var output = IsPowerOfTwo(536870912);

            RemoveOuterParentheses("(()())(())");
        }

        public string RemoveOuterParentheses(string s)
        {
            var list = new List<string>();
            int start = 0;
            int end = start;

            for (; end < s.Length; )
            {
                var cStack = new Stack<char>();
                cStack.Push(s[start]);
                while(cStack.Count>0 && end+1 < s.Length)
                {
                    end++;
                    if (s[end] == ')')
                        cStack.Pop();
                    else if (s[end] == '(')
                    {
                        cStack.Push(s[end]);
                        
                    }
                }
                list.Add(s.Substring(start, end - start+1));
                start = ++end; 

            }
            var output = string.Empty;
            foreach (var item in list)
            {
                output += item.Substring(1,item.Length-1);
            }
            return output;
        }
    }
}
