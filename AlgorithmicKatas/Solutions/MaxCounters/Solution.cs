using System;
using System.Linq;

namespace Solutions.MaxCounters
{
    public class Solution
    {
        public int[] solution(int N, int[] A)
        {
            if (N < 1)
            {
                return new int[0];
            }

            int overallMax = 0;
            int maxCounterMax = 0;

            var counters = new int[N];

            foreach (var a in A)
            {
                if (a == N + 1)
                {
                    maxCounterMax = overallMax;
                }
                else
                {
                    counters[a - 1] = Math.Max(counters[a - 1], maxCounterMax);
                    counters[a - 1]++;
                    overallMax = Math.Max(counters[a - 1], overallMax);
                }
            }

            return counters.Select(x => Math.Max(maxCounterMax, x)).ToArray();
        }
    }
}
