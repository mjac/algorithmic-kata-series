﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Solutions.PaintingFence
{
    public class Solution
    {
        public int solution(int N, int[] A)
        {
            return countStrokes(A);
        }

        private int countStrokes(ICollection<int> postHeights)
        {
            var width = postHeights.Count;
            if (width == 1)
            {
                return 1;
            }

            var height = postHeights.Max();
            if (width < height)
            {
                // We can paint every fence vertically faster in this case
                // < instead of <= because of 1 1 3 case where it is faster to paint the bottom row
                return width;
            }

            var horizontalStrokes = postHeights.Min();

            var remainingPosts = getRemainingPosts(postHeights.Select(a => a - horizontalStrokes));
            return horizontalStrokes + remainingPosts.Sum(A => countStrokes(A));
        }

        private static List<List<int>> getRemainingPosts(IEnumerable<int> posts)
        {
            var postSections = new List<List<int>>();

            var newSectionRequired = true;
            foreach (var post in posts)
            {
                if (post == 0)
                {
                    newSectionRequired = true;
                }
                else
                {
                    if (newSectionRequired)
                    {
                        postSections.Add(new List<int>());
                        newSectionRequired = false;
                    }
                    postSections.Last().Add(post);
                }
            }

            return postSections;
        }

        public static void Main()
        {
            string postCountLine;
            while ((postCountLine = Console.ReadLine()) != null)
            {
                int N;
                if (int.TryParse(postCountLine, out N))
                {
                    if (N == 0)
                    {
                        return;
                    }

                    var postHeightLine = Console.ReadLine();

                    var A = postHeightLine.Split(new char[] { ' ' }).Select(int.Parse).ToArray();
                    var writeText = new Solution().solution(N, A);

                    Console.WriteLine(writeText);
                }
            }
        }
    }
}
