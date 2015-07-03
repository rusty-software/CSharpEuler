using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    [TestClass]
    public class PrimeCalculatorTests
    {
        [TestMethod]
        public void PrimeFactors_600851475143_ReturnsValues()
        {
            var expected = new List<long> { 71, 839, 1471, 6857 };
            var factors = PrimeCalculator.FactorsOf(600851475143);
            CollectionAssert.AreEqual(expected, factors);
        }

        [TestMethod]
        public void PrimeFactors_13195_ReturnsValues()
        {
            var expected = new List<long> { 5, 7, 13, 29 };
            var actual = PrimeCalculator.FactorsOf(13195);
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsPrime_1_IsFalse()
        {
            Assert.IsFalse(PrimeCalculator.IsPrime(1));
        }

        [TestMethod]
        public void IsPrime_2_IsTrue()
        {
            Assert.IsTrue(PrimeCalculator.IsPrime(2));
        }

        [TestMethod]
        public void IsPrime_Primes_IsAllTrue()
        {
            var primes = new List<long> { 2, 3, 5, 7, 101, 103, 107, 109, 991, 997 };
            Assert.IsTrue(primes.All(p => PrimeCalculator.IsPrime(p)));
        }

        [TestMethod]
        public void IsPrime_NonPrimes_IsAllFalse()
        {
            var nonPrimes = new List<long> { 4, 6, 8, 10, 21, 27, 33, 39, 49, 100, 1000 };
            Assert.IsFalse(nonPrimes.Any(np => PrimeCalculator.IsPrime(np)));
        }
    }
}
