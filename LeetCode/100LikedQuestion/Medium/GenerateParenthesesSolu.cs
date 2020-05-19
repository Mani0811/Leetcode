using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class GenerateParenthesesSolu : BaseClass
    {
        public override void Run()
        {
            var output = GenerateParenthesis(3);
            base.Run();
        }



        const string open = "(";
        const string close = ")";
        int N = 0;
        /// <summary>
        ///  First soluation
        /// </summary>
        HashSet<string> output = new HashSet<string>();
        public IList<string> GenerateParenthesis(int n)
        {
            N = n;
            //return GenerateAllPermutation(n);
            Permute(open, 1, 0);
            return output.ToList();
        }
        
       

        public void Permute(string str, int lc, int rc)
        {
            if (lc <rc || lc>N|| rc>N) return;
            {

            }
            if (lc + rc == 2 * N && lc==rc)
            {
                output.Add(str);
                return;
            }

            Permute(str + open, lc + 1, rc);
            Permute(str + close, lc, rc + 1);
        }

        /// <summary>
        /// second soluation
        /// return GenerateAllPermutation(n);
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private IList<string> GenerateAllPermutation(int n)
        {
            var list = new List<char>();
            string input = string.Empty;
            for (int i = 0; i < n; i++)
            {
                input += open + close;
            }

            PermutationUtil(input, 0, input.Length);
            return output.ToList();
        }
        private string Swap(string input, int j, int i)
        {
            var inputArray = input.ToCharArray();
            var temp = inputArray[i];
            inputArray[j] = inputArray[i];
            inputArray[j] = temp;
            string s = new string(inputArray);
            return s;
        }

        private void PermutationUtil(string input, int l, int r)
        {
            if (l == r)
            {
                if (IsValideParenthesis(input))
                    output.Add(input);
            }
            for (int i = l; i < r; i++)
            {
                var str = Swap(input, l, i);
                PermutationUtil(str, l + 1, r);
                str = Swap(input, l, i);
            }

        }

        private bool IsValideParenthesis(string input)
        {
            var stack = new Stack<char>();
            foreach (var item in input)
            {
                if (item.ToString() == close)
                {
                    if (stack.Count <= 0) return false;
                    stack.Pop();
                }
                else
                    stack.Push(item);

            }
            if (stack.Count > 0) return false;
            return true;
        }
    }
}
