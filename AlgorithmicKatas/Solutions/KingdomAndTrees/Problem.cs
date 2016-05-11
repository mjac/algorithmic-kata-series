using System;
using System.Linq;

namespace Solutions.KingdomAndTrees
{
    public static class Problem
    {
        private const int MaxHeight = 1000000000;

        private const int MinX = 0;
        private const int MaxX = MaxHeight;

        public static int GetMinLevel(int[] heights)
        {
            if (heights.Length < 2)
            {
                return 0;
            }

            return BinarySearch(MinX, MaxX, heights);
        }

        public static int BinarySearch(int minX, int maxX, int[] heights)
        {
            if (minX == maxX)
            {
                return minX;
            }

            var X = (minX + maxX) / 2;
            if (HasSolution(X, heights))
            {
                return BinarySearch(minX, X, heights);
            }

            return BinarySearch(X + 1, maxX, heights);
        }

        private static bool HasSolution(int X, int[] heights)
        {
            int lastHeight = 0;

            foreach (var height in heights)
            {
                if (height + X > lastHeight)
                {
                    // In the first loop, the height must be at least 1
                    // In subsequent loops, the height must be at least 1 + lastHeight
                    // In both cases we want to reduce it as much as possible
                    // using the spell X
                    lastHeight = Math.Max(height - X, lastHeight + 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// This is an alternate binary search approach (unused)
        /// </summary>
        private static int BinarySearchLoop(int minX, int maxX, int[] heights)
        {
            while (minX != maxX)
            {
                var X = (minX + maxX) / 2;
                if (HasSolution(X, heights))
                {
                    maxX = X;
                }
                else
                {
                    minX = X + 1;
                }
            }

            return minX;
        }
    }
}
