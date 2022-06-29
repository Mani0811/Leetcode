using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Google
{
    public class Nextsmallestpalindrome : BaseClass
    {
        public override void Run()
        {
            base.Run();
            GenerateNextPalindromeUtil(new int[] {2,3,5,4,5 },5);
            GenerateNextPalindromeUtil(new int[] { 2, 3, 5, 2, 5 }, 5);
        }
        //6:48: half solu 30 min
        /// 2 3 5 4 5->2 3 6 3 2- m =2 l=1,if(m-l>m+l) l=0>
        /// 2 3 5 2 5-> 2 3 5 3 2
        /// 2 3 5 3 1 -> 2 3 5 3 2-m =2 l=2
        /// 2 4 5 4 2
        void GenerateNextPalindromeUtil(int[] num, int n)
        {
            int mid = n / 2;
            if(n/2!=0)
            {
                int l = 1;
                if (num[mid + l] > num[mid - l])
                {
                    num[mid] += 1;
                    while(mid - l>=0)
                    {
                        num[mid + l] = num[mid - l];
                        l++;
                    }
                }
                else if (num[mid + l] <num[mid - l])
                {
                    while (mid - l >= 0)
                    {
                        num[mid + l] = num[mid - l];
                        l++;
                    }
                }
                else
                {
                    while (mid - l>=0 && num[mid + l] == num[mid - l])
                    {
                        l++;
                    }
                    //l==2
                    l = l - 1;
                    if(l==mid)
                    {
                        num[mid + 1] += 1;
                        num[mid - 1] += 1;
                    }
                    else
                    {
                        if (num[mid + l] > num[mid - l])
                        {
                            num[mid] += 1;
                            while (mid - l >= 0)
                            {
                                num[mid + l] = num[mid - l];
                                l++;
                            }
                        }
                        else if (num[mid + l] < num[mid - l])
                        {
                            while (mid - l >= 0)
                            {
                                num[mid + l] = num[mid - l];
                                l++;
                            }
                        }
                    }
                }

            }

        }
    }
}
