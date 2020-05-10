using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion
{
    public class LongestSubstringWithoutRepeatingCharactersSolu : BaseClass
    {
        public override void Run()
        {
            var resut = LengthOfLongestSubstring("dvdf");
            base.Run();
        }
        public int LengthOfLongestSubstring(string s)
        {
            int[] postionArray = new int[128];
            for (int i = 0; i < 128; i++)
            {
                postionArray[i] = -1;
            }
            int currLen = 0, maxlen = 0;
            int j = 0;
            for (int i = 0; i < s.Length;)
            {
                var cha = (int)s[i];
                if (postionArray[cha] == -1)
                {
                    postionArray[cha] = i;
                    currLen += 1;
                    i = i + 1;
                }
                else
                {
                    var temp = postionArray[cha] + 1;
                    maxlen = Math.Max(maxlen, currLen);
                    for (int k = j; k < temp; k++)
                    {
                        postionArray[(int)s[k]] = -1;
                        currLen -= 1;
                    }
                    j = temp;
                    postionArray[cha] = i;
                    currLen += 1;
                    i = i + 1;
                }
            }
            return Math.Max(maxlen, currLen);
        }

    }
}
