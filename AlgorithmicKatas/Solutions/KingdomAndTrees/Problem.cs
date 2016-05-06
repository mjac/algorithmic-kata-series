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

            return BinarySearch(MinX, (MinX + MaxX) / 2, MaxX, heights);
        }

        public static int BinarySearch(int minX, int X, int maxX, int[] heights)
        {
            if (minX == maxX)
            {
                return minX;
            }

            if (HasSolution(X, heights))
            {
                return BinarySearch(minX, (minX + X) / 2, X, heights);
            }

            return BinarySearch(X + 1, (X + 1 + maxX) / 2, maxX, heights);
        }

        private static bool HasSolution(int X, int[] heights)
        {
            int lastHeight = Math.Max(heights[0] - X, 1);

            foreach (var height in heights.Skip(1))
            {
                if (height + X > lastHeight)
                {
                    lastHeight = Math.Max(height - X, lastHeight + 1);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
