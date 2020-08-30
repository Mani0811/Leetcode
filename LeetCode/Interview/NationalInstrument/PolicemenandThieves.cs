using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode.Interview.NationalInstrument
{
    class PolicemenandThieves :BaseClass
    {
        public override void Run()
        {
            PrintMaxNoTheives();

        }
        void PrintMaxNoTheives()
        {
            int t = int.Parse(Console.ReadLine());
            for (int l = 0; l < t; l++)
            {
            var a = Console.ReadLine().Split(' ').Select(m=>int.Parse(m)).ToArray();
            var n = a[0];
            var k = a[1];
                char[,]= new char[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        char[i,j] = 
                    }
                }
             
                
            }
        }


    }
}
