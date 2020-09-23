using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace LeetCode
{
    class WildcardMatching : BaseClass
    {
        public override void Run()
        {
            var match = IsMatch("a", "a*");
            match = IsMatch("abefcdgiescdfimde", "ab*cd?i*de");
            match = IsMatch("", "*");
            match = IsMatch("aaaa", "***a");
            match = IsMatch("aa", "*");
            match = IsMatch("cb", "?a");
            match = IsMatch("adce", "*a*b");
            match = IsMatch("acdcb", "a*c?b");
            match = IsMatch("aa", "*");

        }




        public bool IsMatch(string s, string p)
        {
            int m = s.Length;
            int n = p.Length;
            int i = 0;
            int j = 0, asterick = -1, match = 0;


            while (i < m)
            {
                if (j < n && p[j] == '*')
                {
                    match = i;
                    asterick = j++;
                }
                else if (j < n && (s[i] == p[j] || p[j] == '?'))
                {
                    i++;
                    j++;
                }
                else if (asterick >= 0)
                {
                    i = ++match;
                    j = asterick + 1;
                }
                else return false;
            }
            while (j < n && p[j] == '*') j++;
            return j == n;
        }
    }
}







