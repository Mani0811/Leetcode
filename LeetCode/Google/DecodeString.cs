using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode
{
    class DecodeStringSolu : BaseClass
    {
        public override void Run()
        {
            var output = DecodeString("abc3[cd]xyz");
        }
        public string DecodeString(String s)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == ']')
                {
                    List<char> decodedString = new List<char>();
                    // get the encoded string
                    while (stack.Peek() != '[')
                    {
                        decodedString.Add(stack.Pop());
                    }
                    // pop [ from the stack
                    stack.Pop();
                    int baseNumber = 1;
                    int k = 0;
                    // get the number k
                    while (stack.Count != 0 && int.TryParse(stack.Peek().ToString(), out int dig))
                    {
                        k = k + (stack.Pop() - '0') * baseNumber;
                        baseNumber *= 10;
                    }
                    // decode k[decodedString], by pushing decodedString k times into stack
                    while (k != 0)
                    {
                        for (int j = decodedString.Count - 1; j >= 0; j--)
                        {
                            stack.Push(decodedString[j]);
                        }
                        k--;
                    }
                }
                // push the current character to stack
                else
                {
                    stack.Push(s[i]);
                }
            }
            // get the result from stack
            char[] result = new char[stack.Count];
            for (int i = result.Length - 1; i >= 0; i--)
            {
                result[i] = stack.Pop();
            }
            return new String(result);
        }

    }
}
