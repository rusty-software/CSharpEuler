using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Euler
{
    [TestClass]
    public class PrimeCalculatorTests
    {
        [TestMethod]
        public void PrimeFactors_13195_ReturnsValues()
        {
            var expected = new List<int> { 5, 7, 13, 29 };
            CollectionAssert.AreEqual(expected, PrimeCalculator.FactorsOf(13195));
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
            var primes = new List<int> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47 };
            Assert.IsTrue(primes.All(p => PrimeCalculator.IsPrime(p)));
        }

        [TestMethod]
        public void IsPrime_NonPrimes_IsAllFalse()
        {
            var nonPrimes = new List<int> { 4, 6, 8, 10, 21, 27, 33, 39, 49, 100, 1000 };
            Assert.IsFalse(nonPrimes.Any(np => PrimeCalculator.IsPrime(np)));
        }
    }

    internal static class PrimeCalculator
    {
        private static List<int> primes = new List<int> { 2 };

        internal static List<int> FactorsOf(int num)
        {
            var factors = new List<int>();
            if (num <= 1)
            {
                return factors;
            }

            for (var i = 2; i <= num; i++)
            {
                if (IsPrime(i) && num % i == 0)
                {
                    factors.Add(i);
                }
            }

            return factors;
        }

        internal static bool IsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }

            if (primes.Contains(num))
            {
                return true;
            }

            for (var i = 2; i <= num; i++)
            {
                if (num % i == 0 && num != i)
                {
                    return false;
                }
            }

            primes.Add(num);
            return true;
        }
    }
}
