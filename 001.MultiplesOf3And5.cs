using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    [TestClass]
    public class MultiplesOf3And5Tests
    {
        [TestMethod]
        public void SumAllMultiplesBelow_10_Returns23()
        {
            Assert.AreEqual(23, MultiplesOf3And5.SumAllMultiplesBelow(10));
        }

        [TestMethod]
        public void SumAllMultiplesBelow_1000_SolvesProblem()
        {
            var sum = MultiplesOf3And5.SumAllMultiplesBelow(1000);
            Assert.AreEqual(233168, sum);
        }
    }

    public static class MultiplesOf3And5
    {
        /// <summary>
        /// If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. 
        /// The sum of these multiples is 23.
        ///
        /// Find the sum of all the multiples of 3 or 5 below 1000.
        /// </summary>
        /// <returns></returns>
        public static int SumAllMultiplesBelow(int upperBound)
        {
            var sum = 0;

            for (var i = 1; i < upperBound; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }
    }
}
