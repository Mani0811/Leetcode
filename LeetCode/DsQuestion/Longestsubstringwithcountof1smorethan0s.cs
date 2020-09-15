using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class Longestsubstringwithcountof1smorethan0s : BaseClass
    {
        public override void Run()
        {
            FindLongestSub("00110000");
        }

        static int FindLongestSub(String bin)
        {
            int len = bin.Length;

            Dictionary<int, int> prevSum = new Dictionary<int, int>();
            int maxlen = 0;
            int currlen = 0;

            int sum = 0;
            for (int i = 0; i < len; i++)
            {
                if (bin[i] == '1')
                    sum += 1;
                else
                    sum -= 1;
                if (sum > 0)
                {
                    maxlen = i + 1;
                }
                else if (sum <= 0)
                {
                    if (prevSum.ContainsKey(sum - 1))
                    {
                        currlen = i - (prevSum[sum - 1] == 0 ? 1 :
                                       prevSum[sum - 1]);
                        maxlen = Math.Max(maxlen, currlen);

                    }
                    

                }
                if (!prevSum.ContainsKey(sum))
                        prevSum.Add(sum, i);
            }
            return maxlen;
        }
    }
}