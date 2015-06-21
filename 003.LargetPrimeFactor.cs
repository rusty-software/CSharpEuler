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

    internal static class PrimeCalculator
    {
        private static List<long> primes = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        internal static List<long> FactorsOf(long num)
        {
            var factors = new List<long>();
            if (num <= 1)
            {
                return factors;
            }

            var treeEntry = FactorOf(num);
            while (treeEntry.Divisor != 1)
            {
                factors.Add(treeEntry.Divisor);
                treeEntry = FactorOf(treeEntry.Dividend);
            }

            return factors;
        }

        internal struct PrimeFactorTreeEntry
        {
            internal long Divisor;
            internal long Dividend;
        }

        internal static PrimeFactorTreeEntry FactorOf(long num)
        {
            for (var i = 2; i <= num; i++)
            {
                if (IsPrime(i) && num % i == 0)
                {
                    return new PrimeFactorTreeEntry { Divisor = i, Dividend = num / i };
                }
            }
            return new PrimeFactorTreeEntry { Divisor = 1, Dividend = num };
        } 

        internal static bool IsPrime(long num)
        {
            if (num <= 1)
            {
                return false;
            }

            if (primes.Contains(num))
            {
                return true;
            }

            var sqrt = Math.Ceiling(Math.Sqrt(num));
            for (var i = 2; i <= sqrt; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            primes.Add(num);
            return true;
        }
    }
}
