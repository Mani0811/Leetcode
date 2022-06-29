using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Assesment
{
    public class HammingDistance
    {
        public int NumUniqueEmails(string[] emails)
        {

            var set = new HashSet<string>();
            for (int i = 0; i < emails.Length; i++)
            {
                var cur = emails[i].Split('@');
                var fName = string.Empty;
                for (int j = 0; j < cur[1].Length; j++)
                {
                    var fn = cur[1][j];
                    if(fn=='.')
                    {
                        continue;
                    }
                    else if(fn=='+')
                    {
                        break;
                    }
                    fName += fn.ToString();
                }
                set.Add(fName + "@" + cur[2]);
            }
            return set.Count;



        }

       
    }
}
