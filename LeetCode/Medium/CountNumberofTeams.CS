using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class CountNumberofTeams :BaseClass
    {
        public  override void Run()
        {
            var res = NumTeams(new int[] { 2, 5, 3, 4, 1 });
        }

        public int NumTeams(int[] rating)
        {

            if (rating == null || rating.Length == 0)
            {
                return 0;
            }

            int len = rating.Length;
            int[] dpl = new int[len];
            int count = 0;

            // first <r[i] <r[j] <r[k] order
            for (int i = 1; i < len; i++)
            {
                count = 0;
                for (int j = 0; j <i; j++)
                {
                    if (rating[i] > rating[j])
                    {
                        count += 1;

                    }
                   
                }
                dpl[i] = count;
            }

            int[] dpr = new int[len];
            count = 0;

            // first <r[i] <r[j] <r[k] order
            for (int i = len - 2; i >= 0; i--)
            {
                count = 0;
                for (int j = len - 1; i< j; j--)
                {
                    if (rating[i] > rating[j])
                    {
                        count += 1;

                    }
                   
                }
                dpr[i] = count;
            }

            int res = 0;

            for (int i = 1; i < len; i++)
            {
                count = 0;
                for (int j = 0; j < i; j++)
                {
                    if (rating[i] > rating[j])
                    {
                        res += dpl[j];

                    }

                }
                
            }


            for (int i = len - 2; i >= 0; i--)
            {
                for (int j = len - 1; i < j; j--)
                {
                    if (rating[i] > rating[j])
                    {

                        res += dpr[j];

                    }

                }
            }
            //System.out.println(count);


            return res;
        }
    }
}
