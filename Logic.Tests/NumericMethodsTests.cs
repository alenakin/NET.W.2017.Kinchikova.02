using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Logic.Tests
{
    [TestClass]
    public class NumericMethodsTests
    {
        [DataTestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        public void InsertNumber_Parameters_EqualToResult(int numberSource, int numberIn, int i, int j, int r)
        {
            int result = NumericMethods.InsertNumber(numberSource, numberIn, i, j);
            Assert.AreEqual(r, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_IGreaterThanJ_Exception()
        {
            int i = 8, j = 3;
            int numberSource = 5, numberIn = 10;

            NumericMethods.InsertNumber(numberSource, numberIn, i, j);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_ILowerThanZero_Exception()
        {
            int i = -4, j = 3;
            int numberSource = 5, numberIn = 10;

            NumericMethods.InsertNumber(numberSource, numberIn, i, j);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_JGreaterThan31_Exception()
        {
            int i = 10, j = 34;
            int numberSource = 5, numberIn = 10;

            NumericMethods.InsertNumber(numberSource, numberIn, i, j);
        }
    }
}
