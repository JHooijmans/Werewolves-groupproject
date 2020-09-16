using System;
using NUnit.Framework;

namespace Domain
{
    [TestFixture]
    class Test
    {

        [TestCase(10, -2, 8)]
        public void Should_Return_Sum_Given_Ints(int x, int y, int z)
        {
            var result = Program.AddInts(x, y);
            Assert.AreEqual(z, result);
        }
    }

}