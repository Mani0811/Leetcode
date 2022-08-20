using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode
{
    class CoinChange : BaseClass
    {
        public override void Run()
        {

            int total = 11;
            int[] coins = { 5, 1, 2 };
            int bottomUpValue = CoinChangenew2(total, coins);
            var map = new Dictionary<int, int>();
            var topDownValue = minimumCoinTopDown(total, coins, map);
            Console.WriteLine($"Bottom up and top down result {bottomUpValue} and {topDownValue}");
        }

        public int CoinChangenew2(int a, int[] coins)
        {
            int[] dp = new int[a + 1];
            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = dp.Length;
                for (int j = 0; j < coins.Length; j++)
                {
                    if (i >= coins[j]) dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                }
            }
            return dp[a] == dp.Length ? -1 : dp[a];
        }

    
        public int CoinChangenew( int a, int[] coins)
        {
            Array.Sort(coins);
            var n = coins.Length;
            var dp = new int[n + 1, a + 1];
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= a; j++)
                {
                    dp[i, j] = int.MaxValue - 1;
                }
            }
            for (int i = 0; i <= n; i++)
            {
                dp[i, 0] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= a; j++)
                {
                    if (j < coins[i - 1])
                        dp[i, j] = dp[i - 1, j];
                    else
                    {
                        if (dp[i, j - coins[i - 1]] != int.MaxValue)
                        {
                            var take = 1 + dp[i, j - coins[i - 1]];
                            var leave = dp[i - 1, j];

                            dp[i, j] = Math.Min(take, leave);
                        }

                    }
                }
            }

            return dp[n, a] == int.MaxValue - 1 ? -1 : dp[n, a];
        }


        public int minimumCoinTopDown(int total, int[] coins, Dictionary<int, int> map)
        {

            //if total is 0 then there is nothing to do. return 0.
            if (total == 0)
            {
                return 0;
            }

            //if map contains the result means we calculated it before. Lets return that value.
            if (map.ContainsKey(total))
            {
                return map[total];
            }

            //iterate through all coins and see which one gives best result.
            int min = int.MaxValue;
            for (int i = 0; i < coins.Length; i++)
            {
                //if value of coin is greater than total we are looking for just continue.
                if (coins[i] > total)
                {
                    continue;
                }
                //recurse with total - coins[i] as new total
                int val = minimumCoinTopDown(total - coins[i], coins, map);

                //if val we get from picking coins[i] as first coin for current total is less
                // than value found so far make it minimum.
                if (val < min)
                {
                    min = val;
                }
            }

            //if min is MAX_VAL dont change it. Just result it as is. Otherwise add 1 to it.
            min = (min == int.MaxValue ? min : min + 1);

            //memoize the minimum for current total.
            map.Add(total, min);
            return min;
        }

        public int MinimumCoinBottomUp(int total, int[] coins)
        {
            int[] T = new int[total + 1];
            int[] R = new int[total + 1];
            T[0] = 0;
            for (int i = 1; i <= total; i++)
            {
                T[i] = int.MaxValue - 1;
                R[i] = -1;
            }
            for (int j = 0; j < coins.Length; j++)
            {
                for (int i = 1; i <= total; i++)
                {
                    if (i >= coins[j])
                    {
                        var x = T[i - coins[j]];
                        if (x + 1 < T[i])
                        {
                            T[i] = 1 + x;
                            R[i] = j;
                        }
                    }
                }
            }
            printCoinCombination(R, coins);
            return T[total];
        }

        private void printCoinCombination(int[] R, int[] coins)
        {
            if (R[R.Length - 1] == -1)
            {
                Console.WriteLine("No solution is possible");
                return;
            }
            int start = R.Length - 1;
            Console.WriteLine("Coins used to form total ");
            while (start != 0)
            {
                int j = R[start];
                Console.WriteLine(coins[j] + " ");
                start = start - coins[j];
            }
            Console.WriteLine("\n");
        }

    }
}
