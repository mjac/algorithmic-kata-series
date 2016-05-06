using NUnit.Framework;
using Solutions.KingdomAndTrees;

namespace Solutions.Tests
{
    class KingdomAndTreesTests
    {
        [TestCase(new[] { 1 }, 0)]
        [TestCase(new[] { 1, 1 }, 1)]
        [TestCase(new[] { 1, 2 }, 0)]
        [TestCase(new[] { 2, 1 }, 1)]
        [TestCase(new[] { 3, 2, 1 }, 2)]

        [TestCase(new[] { 9, 5, 11 }, 3)]
        [TestCase(new[] { 5, 8 }, 0)]
        [TestCase(new[] { 1, 1, 1, 1, 1 }, 4)]
        [TestCase(new[] { 548, 47, 58, 250, 2012 }, 251)]

        [TestCase(new[] { 1000000000, 1 }, 500000000)]
        [TestCase(new[] { 1000000000, 3 }, 499999999)]
        public void CorrectHeightReturned(int[] heights, int expectedMinHeight)
        {
            var minHeight = Problem.GetMinLevel(heights);
            Assert.That(minHeight, Is.EqualTo(expectedMinHeight));
        }
    }
}
