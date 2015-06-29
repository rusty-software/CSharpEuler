using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Euler
{
    [TestClass]
    public class DigitAnalyzerTests
    {
        [TestMethod]
        public void LargestProductFromConsecutive_1234567890And4_Returns3024()
        {
            var number = 1234567890d;
            Assert.AreEqual(3024, DigitAnalyzer.LargestProductFromConsecutive(number, 4));
        }
    }

    internal static class DigitAnalyzer
    {
        internal static double LargestProductFromConsecutive(double number, int count)
        {
            var digits = number.ToString().ToCharArray().Select(c => (int)char.GetNumericValue(c)).ToList();
            var largestProduct = 0d;
            var upperBound = digits.Count() - count;
            for (var i = 0; i < upperBound; i++)
            {
                var product = Convert.ToDouble(digits.GetRange(i, count).Aggregate((total, next) => total * next));
                largestProduct = product > largestProduct ? product : largestProduct;
            }
            return largestProduct;
        }
    }
}
