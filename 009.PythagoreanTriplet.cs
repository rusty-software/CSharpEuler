using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Euler
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Triplet_SumOf25_Returns345()
        {
            var sum = 3 + 4 + 5;
            var expected = new Tuple<int, int, int>(3, 4, 5);
            Assert.AreEqual(expected, Pythagoras.Triplet(sum));
        }
    }

    internal static class Pythagoras
    {
        internal static Tuple<int, int, int> Triplet(int memberSum)
        {
            var maxA = memberSum - 2;
            var maxB = maxA + 1;
            var maxC = memberSum;
            for (var a = 1; a <= maxA; a++)
            {
                for (var b = a + 1; b <= maxB; b++)
                {
                    for (var c = b + 1; c <= maxC; c++)
                    {
                        if ((a + b + c) == memberSum && (a*a + b*b == c*c))
                        {
                            return new Tuple<int, int, int>(a, b, c);
                        }
                    }
                }
            }
            return new Tuple<int, int, int>(0, 0, 0);
        }
    }
}
