using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace LeetCode.Interview.NationalInstrument
{
    class CrazyNumbers : BaseClass
    {
        public override void Run()
        {
            NoOfCrazyNumbers();
        }

        public void NoOfCrazyNumbers()
        {
            var t = int.Parse(Console.ReadLine());
             const int M = 1000000007;
            for (int k = 0; k < t; k++)
            {
                var n = int.Parse(Console.ReadLine());
                if (n == 0)
                {
                    Console.WriteLine(0);
                    continue;
                }
                else if (n==1)
                {
                    Console.WriteLine(10);
                    continue;
                }

                long[,] A = new long[n, 12];

                for (int i = 0; i < n; i++)
                {
                    A[i, 0] = 0;
                    A[i, 11] = 0;
                }

                A[0,1] = 1;
                A[0,2] = 1;
                A[0,3] = 2;
                A[0,4] = 2;
                A[0,5] = 2;
                A[0,6] = 2;
                A[0,7] = 2;
                A[0,8] = 2;
                A[0,9] = 2;
                A[0,10] = 1;

                for (int i = 1; i < n; i++)
                {
                    for (int j = 1; j <= 10; j++)
                    {
                        A[i,j] = (A[i - 1,j - 1]%M + A[i - 1,j + 1]%M)%M;
                    }
                }

                long sum = 0;
                for (int i = 1; i <= 10; i++)
                {
                    sum = ((sum%M)+ A[n - 2,i]%M)%M;
                }

                Console.WriteLine(sum);
            }
        }
    }
}
