using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    [TestClass]
    public class SumPrimesTests
    {
        [TestMethod]
        public void PrimesBelow_10_ReturnsList()
        {
            var expected = new List<long> { 2, 3, 5, 7 };
            CollectionAssert.AreEqual(expected, PrimeCalculator.PrimesBelow(10));
        }

        [TestMethod]
        public void SumPrimesBelow_2M_ReturnsCorrectValue()
        {
            var primes = PrimeCalculator.PrimesBelow(2000000);
            Assert.AreEqual(0, primes.Sum());
        }
    }
}
