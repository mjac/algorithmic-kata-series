using NUnit.Framework;
using Solutions.FlowerGarden;

namespace Solutions.Tests
{
    class FlowerGardenTests
    {
        [TestCase(new[] { 1 }, new[] { 1 }, new[] { 365 }, new[] { 1 }, TestName = "Single flower")]
        [TestCase(new[] { 2, 1 }, new[] { 1, 1 }, new[] { 365, 365 }, new[] { 1, 2 }, TestName = "Two flowers same period")]
        [TestCase(new[] { 1, 2 }, new[] { 1, 1 }, new[] { 365, 365 }, new[] { 1, 2 }, TestName = "Two flowers same period reverse input")]
        [TestCase(new[] { 1, 2 }, new[] { 1, 3 }, new[] { 2, 4 }, new[] { 2, 1 }, TestName = "Two flowers different period")]

        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 1, 1 }, new[] { 365, 365, 365 }, new[] { 1, 2, 3 }, TestName = "Three flowers same period")]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3, 5 }, new[] { 2, 4, 6 }, new[] { 3, 2, 1 }, TestName = "Three flowers different period")]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 4 }, new[] { 2, 3, 5 }, new[] { 3, 1, 2 }, TestName = "Three flowers one overlay period")]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 3, 4 }, new[] { 2, 4, 5 }, new[] { 2, 3, 1 }, TestName = "Three flowers another overlay period")]
        [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 }, new[] { 2, 3, 4 }, new[] { 1, 2, 3 }, TestName = "Three flowers another overlay period")]

        [TestCase(new[] { 689, 929, 976, 79, 630, 835, 721, 386, 492, 767, 787, 387, 193, 547, 906, 642, 3, 920, 306, 735, 889, 663, 295, 892, 575, 349, 683, 699, 584, 149, 410, 710, 459, 277, 965, 112, 146, 352, 408, 432 }, new[] { 4, 123, 356, 50, 57, 307, 148, 213, 269, 164, 324, 211, 249, 355, 110, 280, 211, 106, 277, 303, 63, 326, 285, 285, 269, 144, 331, 15, 296, 319, 89, 243, 254, 159, 185, 158, 81, 270, 219, 26 }, new[] { 312, 158, 360, 314, 323, 343, 267, 220, 347, 197, 327, 334, 250, 360, 350, 323, 291, 323, 315, 320, 355, 334, 286, 293, 362, 181, 360, 328, 322, 344, 173, 248, 284, 301, 215, 230, 226, 331, 355, 81 }, new[] { 149, 3, 79, 193, 112, 146, 432, 277, 386, 349, 410, 295, 306, 352, 387, 408, 547, 459, 492, 575, 663, 683, 976, 584, 630, 642, 689, 699, 787, 735, 835, 710, 721, 767, 889, 892, 906, 920, 965, 929 }, TestName="Crazy acceptance test")]
        public void FlowerGardenTest(int[] height, int[] bloom, int[] wilt, int[] expectedOrdering)
        {
            var actualOrdering = Solution.getOrdering(height, bloom, wilt);
            CollectionAssert.AreEqual(expectedOrdering, actualOrdering);
        }
    }
}
