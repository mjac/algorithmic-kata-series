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

            var counters = new int[N];

            foreach (var a in A)
            {
                if (a == N + 1)
                {
                    var element = counters.Max();
                    counters = Enumerable.Repeat(element, N).ToArray();
                }
                else
                {
                    counters[a - 1]++;
                }
            }

            return counters;
        }
    }
}
