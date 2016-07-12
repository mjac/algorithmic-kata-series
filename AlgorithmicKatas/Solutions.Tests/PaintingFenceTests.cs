using NUnit.Framework;

namespace Solutions.Tests
{
    class PaintingFenceTests
    {
        [TestCase(new[] { 1 }, 1, TestName = "Single post of height one")]
        [TestCase(new[] { 2 }, 1, TestName = "Single post of height two")]
        [TestCase(new[] { 5 }, 1, TestName = "Single post of height five")]
        [TestCase(new[] { 1, 1 }, 1, TestName = "Two posts of height one")]
        [TestCase(new[] { 5, 5 }, 2, TestName = "Two posts of height five")]
        [TestCase(new[] { 2, 1, 1 }, 2, TestName = "Three posts with left edge two and rest one")]
        [TestCase(new[] { 1, 1, 2 }, 2, TestName = "Three posts with right edge two and rest one")]
        [TestCase(new[] { 1, 2, 1 }, 2, TestName = "Three posts with middle two and edges one")]
        [TestCase(new[] { 2, 1, 2 }, 3, TestName = "Three posts with outer edges two and middle one")]
        [TestCase(new[] { 3, 1, 1 }, 2, TestName = "Three posts with left edge three and rest one")]
        [TestCase(new[] { 4, 1, 1 }, 2, TestName = "Three posts with left edge four and rest one")]
        [TestCase(new[] { 1, 1, 3 }, 2, TestName = "Three posts with right edge three and rest one")]
        [TestCase(new[] { 2, 2, 1, 2, 1 }, 3, TestName = "22121")]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, 1, TestName = "One long horizontal stroke")]
        [TestCase(new[] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }, 2, TestName = "Two long horizontal strokes")]
        public void SolutionCorrect(int[] A, int expectedStrokes)
        {
            var N = A.Length;
            var actualStrokes = new PaintingFence.Solution().solution(N, A);
            Assert.That(actualStrokes, Is.EqualTo(expectedStrokes));
        }

        //[Test]
        public void SolutionCorrect([Range(1,5)] int a1, [Range(1, 5)] int a2, [Range(1, 5)] int a3)
        {
            var A = new[] { a1, a2, a3 };
            var N = A.Length;
            var actualStrokes = new PaintingFence.Solution().solution(N, A);
            Assert.That(actualStrokes, Is.EqualTo(1));
        }
    }
}