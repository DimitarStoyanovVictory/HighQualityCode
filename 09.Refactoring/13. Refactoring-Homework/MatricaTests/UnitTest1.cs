using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdTask;

namespace MatricaTests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Verification()
        {
            int[,] matrix = new int[3, 3];

            bool checkVerification = WalkInMatrica.Verification(matrix, 0, 0);

            // All numbers of the matrix are zero
            Assert.AreEqual(checkVerification, true);
        }
    }
}
