using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    class NumerOfLikesAndDislikes : BaseClass
    {
        public override void Run()
        {
            base.Run();
            Console.WriteLine(NoOfLikesAndDisLikes());
        }

        public int NoOfLikesAndDisLikes()
        {
            string a = Console.ReadLine();
            string p = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == p[i])
                    count++;
            }
            return count;
        }
    }
}
