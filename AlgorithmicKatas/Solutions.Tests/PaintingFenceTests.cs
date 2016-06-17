using NUnit.Framework;

namespace Solutions.Tests
{
    class PaintingFenceTests
    {
        [TestCase(1, new[] { 1 }, 1)]
        [TestCase(2, new[] { 1, 1 }, 1)]
        [TestCase(3, new[] { 1, 2, 1 }, 2)]
        public void SolutionCorrect(int N, int[] A, int expectedStrokes)
        {
            var actualStrokes = new PaintingFence.Solution().solution(N, A);
            Assert.That(actualStrokes, Is.EqualTo(expectedStrokes));
        }
    }
}