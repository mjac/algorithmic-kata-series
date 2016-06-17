using NUnit.Framework;

namespace Solutions.Tests
{
    class MaxCountersTests
    {
        [TestCase(0, new int[0], new int[0])]
        [TestCase(1, new int[0], new[] { 0 })]
        [TestCase(1, new[] { 1 }, new[] { 1 })]
        [TestCase(1, new[] { 1, 1 }, new[] { 2 })]
        [TestCase(2, new[] { 1, 2 }, new[] { 1, 1 })]
        [TestCase(5, new[] { 3, 4, 4, 6, 1, 4, 4 }, new[] { 3, 2, 2, 4, 2 })]
        public void SolutionCorrect(int N, int[] A, int[] expectedCounters)
        {
            var actualCounters = new MaxCounters.Solution().solution(N, A);
            Assert.That(actualCounters, Is.EqualTo(expectedCounters));
        }
    }
}
