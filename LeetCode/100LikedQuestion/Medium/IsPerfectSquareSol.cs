using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode._100LikedQuestion.Medium
{
    public class IsPerfectSquareSol : BaseClass
    {
        public override void Run()
        {
            var result = IsPerfectSquare(2);
            result = IsPerfectSquare(13);
            base.Run();
        }
        public bool IsPerfectSquare(int num)
        {
            if (num == 1) return true;
            for (int i = 1; i <= num/2; i++)
            {
                if ((num / i) == i && num % i == 0) return true;
            }
            return false;
        }
    }

}
