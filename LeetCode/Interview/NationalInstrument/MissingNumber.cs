using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Interview.NationalInstrument
{
    class MissingNumber :BaseClass
    {
        public override void Run()
        {
            PrintMissingNumber();

        }

        void PrintMissingNumber()
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var a = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
                Array.Sort(a);
                int k = 2;
                for (int j = 0; j < n; j++)
                {
                    if(a[j]>=k)
                    {
                        a[j] = k;
                        k += 2;
                    }
                }
            }
        }
    }
}
 