using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class EggDrop : BaseClass
    {

        public override void Run()
        {
            base.Run();
            var result = TwoEggDropDP(100);
        }
        public int TwoEggDropDP(int n)
        {

            int eggs = 2;
            int[,] dp = new int[eggs + 1, n + 1];
            int c = 0;

            for (int i = 0; i <= n; i++)
            {
                dp[1, i] = i;
            }

            for (int f = 1; f <= n; f++)
            {
                dp[2, f] = Int32.MaxValue;
                for (int k = 1; k <= f; k++)
                {
                    c = 1 + Math.Max(dp[1, k - 1], dp[2, f - k]); //the egg breaks on current floor or the egg dosen't break on the current floor. Take the worst case
                    if (c < dp[2, f])
                        dp[2, f] = c;
                }
            }
            return dp[eggs, n];
        }
        public int TwoEggDrop(int n)
        {

            var ans = 0;
            var inc = 1;

            while (n > 0)
            {
                n -= inc;
                ans++;
                inc++;
            }

            return ans;
        }
        int eggDrop(int n, int k)
        {
            // If there are no floors, then
            // no trials needed. OR if there
            // is one floor, one trial needed.
            if (k == 1 || k == 0)
                return k;

            // We need k trials for one egg
            // and k floors
            if (n == 1)
                return k;

            int min = int.MaxValue;
            int x, res;

            // Consider all droppings from
            // 1st floor to kth floor and
            // return the minimum of these
            // values plus 1.
            for (x = 1; x <= k; x++)
            {
                res = Math.Max(eggDrop(n - 1, x - 1),
                               eggDrop(n, k - x));
                if (res < min)
                    min = res;
            }

            return min + 1;
        }
    }
}
