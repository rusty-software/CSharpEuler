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

            for (var i = primes.Last() + 1; i <= num; i++)
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
