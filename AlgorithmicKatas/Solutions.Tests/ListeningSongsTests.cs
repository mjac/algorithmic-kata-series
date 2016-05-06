using NUnit.Framework;
using Solutions.ListeningSongs;

namespace Solutions.Tests
{
    class ListeningSongsTests
    {
        [TestCase(new int[0], new int[0], 0, 0, 0)]
        [TestCase(new[] { 1 }, new int[0], 0, 0, 0)]
        [TestCase(new[] { 1 }, new int[0], 1, 0, 1)]
        [TestCase(new[] { 1 }, new[] { 1 }, 2, 0, 2)]
        [TestCase(new[] { 300, 200, 100 }, new[] { 400, 500, 600 }, 17, 1, 4)]
        [TestCase(new[] { 300, 200, 100 }, new[] { 400, 500, 600 }, 10, 1, 2)]
        [TestCase(new[] { 60, 60, 60 }, new[] { 60, 60, 60 }, 5, 2, 5)]
        [TestCase(new[] { 120, 120, 120, 120, 120 }, new[] { 60, 60, 60, 60, 60, 60 }, 10, 3, 7)]
        [TestCase(new[] { 196, 147, 201, 106, 239, 332, 165, 130, 205, 221, 248, 108, 60 }, new[] { 280, 164, 206, 95, 81, 383, 96, 255, 260, 244, 60, 313, 101 }, 60, 3, 22)]
        [TestCase(new[] { 100, 200, 300 }, new[] { 100, 200, 300 }, 2, 1, -1)]
        [TestCase(new[] { 100, 200, 300, 400, 500, 600 }, new[] { 100, 200 }, 1000, 3, -1)]
        public void test(int[] durations1, int[] durations2, int minutes, int T, int expectedMaxSongs)
        {
            var maxSongs = Problem.GetMaxSongs(durations1, durations2, minutes, T);
            Assert.That(maxSongs, Is.EqualTo(expectedMaxSongs));

            var maxSongs2 = Problem.GetMaxSongs(durations2, durations1, minutes, T);
            Assert.That(maxSongs2, Is.EqualTo(expectedMaxSongs));
        }
    }
}
