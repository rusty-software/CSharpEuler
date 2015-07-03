using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    [TestClass]
    public class NthPrimeTests
    {
        [TestMethod]
        public void Nth_6_Is13()
        {
            Assert.AreEqual(13, NthPrime.Offset(6));
        }

        [TestMethod]
        public void Nth_25_Is97()
        {
            Assert.AreEqual(97, NthPrime.Offset(25));
        }

        [TestMethod]
        public void Nth_10001_IsCorrect()
        {
            Assert.AreEqual(104743, NthPrime.Offset(10001));
        }
    }

    internal static class NthPrime
    {
        internal static long Offset(int n)
        {
            if (n == 1)
            {
                return 2;
            }

            var candidate = 3;
            var counter = 2;
            while (counter < n)
            {
                candidate += 2;
                if (PrimeCalculator.IsPrime(candidate))
                {
                    counter++;
                }
            }
            return candidate;
        }
    }
}
