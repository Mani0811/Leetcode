using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class LongestPalindromicSubstringSolu : BaseClass
    {
        public override void Run()
        {
            var result = LongestPalindrome("babad");
             result = LongestPalindrome("abcba");
        }
        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length<1) return string.Empty;
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExplandFromMiddele(s, i, i);
                int len2 = ExplandFromMiddele(s, i, i+1);
                var len = Math.Max(len1, len2);
                if(len>end-start)
                {
                    start = i - ((len - 1) / 2);
                    end = i + (len / 2);
                }
            }
            return s.Substring(start, end-start + 1);
        }

        public int ExplandFromMiddele(string s, int left, int right)
        {
            if (s == null || left > right) return 0;
            while (left >= 0 && right < s.Length && s[left] == s[right])
            {
                left--;
                right++;
            }
            return right - left -1 ;

        }
    }
}
