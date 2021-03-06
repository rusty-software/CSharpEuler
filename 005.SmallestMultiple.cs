﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Euler
{
    [TestClass]
    public class SmallestMultipleTests
    {
        [TestMethod]
        public void Between_1And10_Returns2520()
        {
            var product = SmallestMultiple.Between(1, 10);

            Assert.AreEqual(2520, product);
        }

        [TestMethod]
        public void Between_1And20_ReturnsValue()
        {
            var product = SmallestMultiple.Between(1, 20);

            Assert.AreEqual(232792560, product);
        }
    }

    internal static class SmallestMultiple
    {
        internal static long Between(int lowerBound, int upperBound)
        {
            var range = Enumerable.Range(lowerBound, upperBound);
            var increment = upperBound;
            while (true)
            {
                if (range.All(n => increment % n == 0))
                {
                    return increment;
                }
                increment += upperBound;
            }
        }
    }
}
