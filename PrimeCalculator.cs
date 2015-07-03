using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    internal static class PrimeCalculator
    {
        private static bool[] MakeSieve(long max)
        {
            // Make an array indicating whether numbers are prime.
            bool[] isPrime = new bool[max + 1];
            for (long i = 2; i <= max; i++)
            {
                isPrime[i] = true;
            }

            // Cross out multiples.
            for (long i = 2; i <= max; i++)
            {
                // See if i is prime.
                if (isPrime[i])
                {
                    // Knock out multiples of i.
                    for (long j = i * 2; j <= max; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            return isPrime;
        }

        private static List<long> primes = new List<long> { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        internal static List<long> PrimesBelow(long num)
        {
            var primes = new List<long>();
            var isPrimeAt = MakeSieve(num);
            for (var i = 2; i < num; i++)
            {
                if (isPrimeAt[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }

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
