using NUnit.Framework;

namespace Solutions.Tests
{
    public class BROKENTests
    {
        [TestCase(0, "", 0)]
        [TestCase(0, "a", 0)]
        [TestCase(1, "", 0)]
        [TestCase(1, "a", 1)]
        [TestCase(1, "aa", 2)]
        [TestCase(1, "aba", 1)]
        [TestCase(1, "Mississippi", 2)]
        [TestCase(5, "This can't be solved by brute force.", 7)]
        public void Inputs(int keysStillWorking, string textToType, int expectedSubstringLength)
        {
            var actualSubstringLength = BROKEN.Test.GetLargestSubstringLength(keysStillWorking, textToType);
            Assert.That(actualSubstringLength, Is.EqualTo(expectedSubstringLength));
        }
    }
}