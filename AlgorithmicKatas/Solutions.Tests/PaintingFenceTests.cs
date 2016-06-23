using NUnit.Framework;

namespace Solutions.Tests
{
    class PaintingFenceTests
    {
        [TestCase(new[] { 1 }, 1, TestName = "Single post of height one")]
        [TestCase(new[] { 2 }, 1, TestName = "Single post of height two")]
        [TestCase(new[] { 1, 1 }, 1, TestName = "Two posts of height one")]
        [TestCase(new[] { 1, 2, 1 }, 2, TestName = "Three posts with middle two and edges one")]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1, TestName = "One long horizontal stroke")]
        [TestCase(new[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, 2, TestName = "Two long horizontal strokes")]
        public void SolutionCorrect(int[] A, int expectedStrokes)
        {
            var N = A.Length;
            var actualStrokes = new PaintingFence.Solution().solution(N, A);
            Assert.That(actualStrokes, Is.EqualTo(expectedStrokes));
        }
    }
}