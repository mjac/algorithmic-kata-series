using NUnit.Framework;

namespace Solutions.Tests
{
    public class FrogRiverOneTests
    {
        [TestCase(1, new[] { 1 }, 0)]
        [TestCase(2, new[] { 1 }, -1)]
        [TestCase(2, new[] { 1, 2 }, 1)]
        [TestCase(5, new[] { 1, 3, 1, 4, 2, 3, 5, 4 }, 6)]
        public void Inputs(int X, int[] A, int K)
        {
            var frogRiverOne = new FrogRiverOne.Solution();
            var solution = frogRiverOne.solution(X, A);
            Assert.That(solution, Is.EqualTo(K));
        }
    }
}
