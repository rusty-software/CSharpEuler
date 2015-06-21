using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Euler
{
    [TestClass]
    public class SquareSumsTests
    {
        [TestMethod]
        public void SumOfSquares_1And10_Returns385()
        {
            Assert.AreEqual(385, SquareSums.SumOfSquares(1, 10));
        }

        [TestMethod]
        public void SquareOfSums_1And10_Returns3025()
        {
            Assert.AreEqual(3025, SquareSums.SquareOfSums(1, 10));
        }

        [TestMethod]
        public void SumAndSquareDifference_1And10_Returns2640()
        {
            Assert.AreEqual(2640, SquareSums.SumAndSquareDifference(1, 10));
        }
    }

    internal static class SquareSums
    {
        internal static long SumAndSquareDifference(int lowerBound, int upperBound)
        {
            return SquareOfSums(1, 10) - SumOfSquares(1, 10);
        }

        internal static long SumOfSquares(int lowerBound, int upperBound)
        {
            var range = Enumerable.Range(lowerBound, upperBound);
            var squares = new List<long>();
            foreach(var i in range)
            {
                squares.Add(i * i);
            }
            return squares.Sum();
        }

        internal static long SquareOfSums(int lowerBound, int upperBound)
        {
            var range = Enumerable.Range(lowerBound, upperBound);
            var sum = range.Sum();
            return sum * sum;
        }
    }
}
