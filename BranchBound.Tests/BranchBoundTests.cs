using NUnit.Framework;

namespace BranchBound.Tests
{
    public class BranchBoundTests
    {
        [Test]
        [TestCase(7, new int[] { 10, 11, 5, 13, 15, 7, 1, 18, 12, 16, 17 })]
        [TestCase(12, new int[] { 25, 31, 19, 17, 4, 10, 37, 42, 35, 15, 43, 45, 30, 39, 9, 21, 33, 25, 3, 47, 41, 50, 18, 11, 26, 28 })]
        [TestCase(12, new int[] { 10, 5, 6, 4, 7, 3, 8, 2, 9, 1, 10 })]
        [TestCase(14, new int[] { 50, 5, 24, 84, 58, 21, 57, 98, 51, 6, 16, 75, 95, 11, 23, 92, 85, 29, 56, 45, 55, 73, 20, 4, 34, 76, 96, 63, 30, 93, 2, 19, 39, 14, 71, 80, 40, 69, 54, 62, 42, 1, 10, 35, 8, 22, 70, 67, 15, 27, 38 })]
        public void Test(int expected, int[] trainCars)
        {
            int result = Program.Process(trainCars);

            Assert.AreEqual(expected, result);
        }
    }
}
