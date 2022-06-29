using System.Collections.Generic;

namespace LeetCode.Hard
{
    class BasicCalculator : BaseClass
    {
        public override void Run()
        {
            base.Run();

            var output = Calculate("-(3 +(4-5))");
        }



        public int Calculate(string s)
        {
            int n = s.Length;
            int sum = 0;
            var stack = new Stack<string>();
            var cint = 0;
            char sign = '+';
            for (int i = 0; i < n; i++)
            {
                var cval = s[i];
                if (cval == ' ')
                    continue;
                if (cval == '+')
                {
                    sign = '+';
                    continue;
                }
                if (cval == '-')
                {
                    sign = '-';
                    continue;
                }
                if (char.IsDigit(cval))
                {
                    int si = i;
                    i= i + 1;
                    while (i<s.Length && char.IsDigit(s[i]))
                    {
                        i++;
                    }
                    var ints = s.Substring(si, i  - si);
                    cint = int.Parse(ints);
                    i--;
                }
                if (cval == '(')
                {
                    stack.Push(sum.ToString());
                    stack.Push(sign.ToString());
                    sum = 0;
                    sign = '+';
                    continue;
                }

                if (cval == ')')
                {
                    sign = stack.Pop()[0];
                    cint = sum;
                        sum =int.Parse(stack.Pop());
                }
                
                if (sign == '+')
                {
                    sign = '+';
                    sum = cint+ sum;
                }
                if (sign == '-')
                {
                    sign = '-';
                    sum =  sum-cint;
                }
                
            }
            return sum;
        }

    }
}
