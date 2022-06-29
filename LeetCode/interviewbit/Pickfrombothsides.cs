using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.interviewbit
{
    public class Pickfrombothsides :BaseClass  
    {
        public override void Run()
        { 
            var a = new List<int>() { -533, -666, -500, 169, 724, 478, 358, -38, -536, 705, -855, 281, -173, 961, -509, -5, 942, -173, 436, -609, -396, 902, -847, -708, -618, 421, -284, 718, 895, 447, 726, -229, 538, 869, 912, 667, -701, 35, 894, -297, 811, 322, -667, 673, -336, 141, 711, -747, -132, 547, 644, -338, -243, -963, -141, -277, 741, 529, -222, -684, 35  };
            var b = 48;
            var result = solve(a, b);
            base.Run();
        }

        public int solve(List<int> A, int B)
        {
            int n = A.Count;
            int sum = 0;
            int maxsum = 0;

            for (int j = 0; j < B; j++)
            {
                sum = 0;
                for (int i = 0; i < B - j; i++)
                {
                    sum += A[i];

                }
                for (int i = n - 1; i > n - 1 - j; i--)
                {
                    sum += A[i];
                }
                Console.WriteLine(sum);
                maxsum = Math.Max(maxsum, sum);
            }

            

            return maxsum;
        }
    }
}
