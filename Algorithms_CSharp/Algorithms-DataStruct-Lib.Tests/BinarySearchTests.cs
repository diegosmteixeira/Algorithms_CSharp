using NUnit.Framework;

namespace Algorithms_DataStruct_Lib.Tests
{
    [TestFixture]
    public class BinarySearchTests
    {
        [Test]
        public void BinarySearch_SortedInput_ReturnsCorrectIndex()
        {
            int[] input = { 0, 3, 4, 7, 8, 12, 15, 22 };

            Assert.AreEqual(2, BinarySearch.Searching(input, 4));
            Assert.AreEqual(4, BinarySearch.Searching(input, 8));
            Assert.AreEqual(6, BinarySearch.Searching(input, 15));
            Assert.AreEqual(7, BinarySearch.Searching(input, 22));

            Assert.AreEqual(2, BinarySearch.RecursiveBinarySearch(input, 4));
            Assert.AreEqual(4, BinarySearch.RecursiveBinarySearch(input, 8));
            Assert.AreEqual(6, BinarySearch.RecursiveBinarySearch(input, 15));
            Assert.AreEqual(7, BinarySearch.RecursiveBinarySearch(input, 22));
        }
    }
}