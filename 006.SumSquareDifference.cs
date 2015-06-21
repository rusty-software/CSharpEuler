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
    }

    internal static class SquareSums
    {
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
    }
}
