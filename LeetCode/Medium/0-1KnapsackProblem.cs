using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Medium
{
    class _0_1KnapsackProblem : BaseClass
    {
        public override void Run()
        {
            base.Run();
            int[] val = new int[] { 6, 10, 12 };
            int[] wt = new int[] { 1, 2, 3 };
            int W = 5;
            int n = val.Length;
            var output = KnapSackDPSpaceOptimized(val, wt, W);
            output = KnapSackDP(W, wt, val, n);
        }

        public int KnapSack(int w, int[] wt,
                        int[] val, int n)
        {

            if (n == 0 || w == 0) return 0;

            if (wt[n - 1] > w) return KnapSack(w, wt, val, n - 1);
            else
                return Math.Max(val[n - 1] + KnapSack(w - wt[n - 1], wt, val, n - 1), KnapSack(w - wt[n - 1], wt, val, n - 1));

        }

        /// <summary>
        /// Bonus exercise: below algorithm is not suitable for large weights.
        /// Consider small number of items (N <= 100) but huge capacacity (10 ^ 9) and 
        /// max value (V <= 10 ^ 3), how will modify algorith
        /// [Note: For 32bit integer use long instead of int.]
        /// </summary>
        /// <param name="w"></param>
        /// <param name="wt"></param>
        /// <param name="val"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public int KnapSackDP(int w, int[] wt,
                        int[] val, int n)
        {
            var len = wt.Length;
            var dp = new int[len + 1, w + 1];
            for (int i = 1; i <= len; i++)
            {
                for (int j = 1; j <= w; j++)
                {
                    if (wt[i - 1] <= j)
                    {
                        // Exclude or include
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 1, j - wt[i - 1]] + val[i - 1]);
                    }

                    else
                    {
                        // Exclude
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            return dp[len, w];
        }

        static int KnapSackDPSpaceOptimized(int[] profits, int[] weights, int capacity)
        {
            // basic checks
            if (capacity <= 0 || profits.Length == 0 || weights.Length != profits.Length)
                return 0;

            int n = profits.Length;
            // we only need one previous row to find the optimal solution, overall we need '2' rows
            // the above solution is similar to the previous solution, the only difference is that 
            // we use `i%2` instead if `i` and `(i-1)%2` instead if `i-1`
            int[,] dp = new int[2, capacity + 1];

            // if we have only one weight, we w
            // ill take it if it is not more than the capacity
            for (int c = 0; c <= capacity; c++)
            {
                if (weights[0] <= c)
                    dp[0, c] = dp[1, c] = profits[0];
            }

            // process all sub-arrays for all the capacities
            for (int i = 1; i < n; i++)
            {
                for (int c = 0; c <= capacity; c++)
                {
                    int profit1 = 0, profit2 = 0;
                    // include the item, if it is not more than the capacity
                    if (weights[i] <= c)
                        profit1 = profits[i] + dp[(i - 1) % 2, c - weights[i]];
                    // exclude the item
                    profit2 = dp[(i - 1) % 2, c];
                    // take maximum
                    dp[i % 2, c] = Math.Max(profit1, profit2);
                }
            }

            return dp[(n - 1) % 2, capacity];
        }
    }
}
