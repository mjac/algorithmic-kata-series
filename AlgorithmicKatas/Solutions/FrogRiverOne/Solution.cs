using System.Collections.Generic;
using System.Linq;

namespace Solutions.FrogRiverOne
{
    public class Solution
    {
        public int solution(int X, int[] A)
        {
            var remainingPositions = new HashSet<int>(Enumerable.Range(1, X));

            for (int timeIndex = 0; timeIndex < A.Length; timeIndex++)
            {
                var positionAtTime = A[timeIndex];
                if (remainingPositions.Contains(positionAtTime))
                {
                    remainingPositions.Remove(positionAtTime);
                    if (remainingPositions.Count == 0)
                    {
                        return timeIndex;
                    }
                }
            }

            return -1;
        }
    }
}
