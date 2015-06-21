using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    [TestClass]
    public class PalindromeProducerTests
    {
        [TestMethod]
        public void TwoDigitProductPalindromes_Returns9009()
        {
            var nums = PalindromeProducer.TwoDigitProductPalindromes();
            Assert.AreEqual(9009, nums.Max());
        }

        [TestMethod]
        public void ThreeDigitProductPalindromes_ReturnsValue()
        {
            var nums = PalindromeProducer.ThreeDigitProductPalindromes();
            Assert.AreEqual(906609, nums.Max());
        }
    }

    internal static class PalindromeProducer
    {
        internal static List<int> ThreeDigitProductPalindromes()
        {
            return ProductPalindromesFrom(100, 999);
        }

        internal static List<int> TwoDigitProductPalindromes()
        {
            return ProductPalindromesFrom(10, 99);
        }

        private static List<int> ProductPalindromesFrom(int lowerBound, int upperBound)
        {
            var nums = new List<int>();
            for (var i = lowerBound; i <= upperBound; i++)
            {
                for (var j = lowerBound; j <= upperBound; j++)
                {
                    var product = i * j;
                    var s = product.ToString();
                    var sr = new string(s.Reverse().ToArray());
                    if (s == sr)
                    {
                        nums.Add(product);
                    }
                }
            }

            return nums.Distinct().ToList();
        }
    }
}
