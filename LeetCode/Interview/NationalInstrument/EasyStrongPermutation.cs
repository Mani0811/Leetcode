using LeetCode._100LikedQuestion.Medium;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;

namespace LeetCode.Interview.NationalInstrument
{
    class EasyStrongPermutation : BaseClass
    {
        static int maxSum ;
        public override void Run()
        {
            base.Run();
            PrintEasyStrongPermutation();
        }

        public static void PrintEasyStrongPermutation()
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
            Permuatation(input, 0, n - 1);
            Console.WriteLine(maxSum);
            
        }

        static void   Permuatation(int[] a, int l, int r)
        {
            if (l == r)
            {
                maxSum = Math.Max(maxSum, ClalauteValue(a));
            }
            else
            {
                for (int k = l; k <=r; k++)
                {
                    swap(a,l, k);
                    Permuatation(a, l + 1, r);
                    //backtrack 
                    swap(a, l, k);
                }
            }
        }

        private static int ClalauteValue(int[] a)
        {
            var sum = 0;
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                if (i != n-1)
                {
                    sum += Math.Abs(a[i] - a[i + 1]);
                }
                else
                {
                    sum += Math.Abs(a[i] - a[0]);
                }
            }
            return sum;
        }

        private static void swap(int[] a,int l, int i)
        {
            int temp = a[l];
            a[l] = a[i];
            a[i] = temp;
        }
    }
}
