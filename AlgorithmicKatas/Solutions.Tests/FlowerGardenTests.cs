using NUnit.Framework;
using Solutions.FlowerGarden;

namespace Solutions.Tests
{
    class FlowerGardenTests
    {
        [TestCase(new[] { 1 }, new[] { 1 }, new[] { 365 }, new[] { 1 })]
        public void FlowerGardenTest(int[] height, int[] bloom, int[] wilt, int[] expectedOrdering)
        {
            var actualOrdering = Solution.getOrdering(height, bloom, wilt);
            CollectionAssert.AreEqual(expectedOrdering, actualOrdering);
        }
    }
}
