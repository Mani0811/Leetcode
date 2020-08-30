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
            var a = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
            Array.Sort(a);
            int i = 0; // first position
            int j = n - 1; // last position
                           // sort using quick sort
            long sum = 0;
            while (i < j)
            {
                sum += Math.Abs(a[i] - a[j]); // calculate the strength of the sequence by summing the difference between adjacent integers
                ++i; // increase i
                if (i >= j) // when i meets j, break loop
                    break;
                sum += Math.Abs(a[i] - a[j]);
                --j;
            }
            sum += Math.Abs(a[0] - a[j]);
            //Permuatation(input, 0, n - 1);
            Console.WriteLine(sum);
            
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
