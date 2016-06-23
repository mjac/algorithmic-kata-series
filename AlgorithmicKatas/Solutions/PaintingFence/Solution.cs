using System;
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

        private int countStrokes(ICollection<int> a)
        {
            var width = a.Count;
            if (width == 1)
            {
                return 1;
            }

            var height = a.Max();
            if (width <= height)
            {
                // We can paint every fence vertically faster in this case
                return width;
            }

            var horizontalStrokes = a.Min();

            var remainingPosts = GetRemainingPosts(a.Select(o => o - horizontalStrokes));
            return horizontalStrokes + remainingPosts.Sum(o => countStrokes(o));
        }

        private static List<List<int>> GetRemainingPosts(IEnumerable<int> posts)
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
    }
}
