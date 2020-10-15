using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Facebook
{
    class CountandSaySolu : BaseClass
    {
        Dictionary<int, string> map;    
        public override void Run()
        {
            base.Run();
           
            for (int i = 1; i <= 5; i++)
            {
                var s = CountAndSay(i);
                
                Console.WriteLine(s);
            }
        }

        public string CountAndSay(int n)
        {
            string s = "1";
            if (n == 1) return s;
            for (int i = 2; i <= n; i++)
            {
                int count = 0;
                string temp = "";
                int j = 0;
                for (; j < s.Length; j++)
                {
                    if (j > 0 && s[j - 1] != s[j])
                    {
                        temp += count + s[j - 1].ToString();
                        count = 0;
                    }
                    count++;
                }

                if (count>0)
                {
                    temp += count + s[j - 1].ToString();
                }

                s = temp;
            }

            return s;
        }

        public string CountAndSa1y(int n)
        {
            
            string pre = "1";
          
            if (n == 0) return pre;
            for (int i = 2; i <= n; i++)
            {
                string temp = "";
                int oneCount = 0;
                int twoCount = 0;
                int j = pre.Length - 1;
                while (j>= 0)
                {
                    while (j>=0 && pre[j] == '1')
                    {
                        oneCount++;
                        j--;
                    }
                    if(oneCount>0)
                    temp = oneCount + "1" + temp;
                    oneCount = 0;
                    while (j>=0 && pre[j] == '2')
                    {
                        twoCount++;
                        j--;
                    }
                    if(twoCount>0)
                    temp = twoCount + "2" + temp;
                    twoCount = 0;
                }
                pre = temp;
            }
            return pre;
        }
    }
}
