using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class NumericMethodsTests
    {
        #region TestCases
        static object[] InsertNumberCases =
        {
            new object[] { 15, 15, 0, 0, 15 },
            new object[] { 8, 15, 0, 0, 9 },
            new object[] { 8, 15, 3, 8, 120 }
        };

        static object[] FindNextBiggerNumberCases =
        {
            new object[] { 12, 21 },
            new object[] { 2017, 2071 },
            new object[] { 414, 441 },
            new object[] { 144, 414 },
            new object[] { 1234321, 1241233 },
            new object[] { 1234126, 1234162 },
            new object[] { 3456432, 3462345 },
            new object[] { 10, -1 },
            new object[] { 20, -1 },
        };
        #endregion

        #region Tests for InsertNumber method
        [TestCaseSource("InsertNumberCases")]
        public void InsertNumber_Param_ShouldBeEqualToResult(int numberSource, int numberIn, int i, int j, int r)
        {
            int result = NumericMethods.InsertNumber(numberSource, numberIn, i, j);
            Assert.AreEqual(r, result);
        }

        [Test]
        public void InsertNumber_IGreaterThanJ_Exception()
        {
            int i = 8, j = 3;
            int numberSource = 5, numberIn = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => NumericMethods.InsertNumber(numberSource, numberIn, i, j));
        }

        [Test]
        public void InsertNumber_ILowerThanZero_Exception()
        {
            int i = -4, j = 3;
            int numberSource = 5, numberIn = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => NumericMethods.InsertNumber(numberSource, numberIn, i, j));
        }

        [Test]
        public void InsertNumber_JGreaterThan31_Exception()
        {
            int i = 10, j = 34;
            int numberSource = 5, numberIn = 10;

            Assert.Throws<ArgumentOutOfRangeException>(() => NumericMethods.InsertNumber(numberSource, numberIn, i, j));
        }
        #endregion

        #region Tests for FindNthRoot method
        [Test]
        public void FindNthRoot_EvenPowerAndNegativeNumber_Exception()
        {
            Assert.Throws<ArgumentException>(() => NumericMethods.FindNthRoot(-1, 2, 0.1));
        }

        [Test]
        public void FindNthRoot_AccuracyLowerZero_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumericMethods.FindNthRoot(1, 2, -0.1));
        }

        [Test]
        public void FindNthRoot_AccuracyGreaterThanOne_Exception()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumericMethods.FindNthRoot(1, 2, 1.1));
        }
        #endregion

        #region Tests for NextBiggerNumber
        [TestCaseSource("FindNextBiggerNumberCases")]
        public void NextBiggerNumber_Params_EqualToResult(int number, int result)
        {
            int r = NumericMethods.FindNextBiggerNumber(number, out _);
            Assert.AreEqual(result, r);
        }

        [Test]
        public void NextBiggerNumber_NegativeNumber_Excepion()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => NumericMethods.FindNextBiggerNumber(-23, out _));
        }
        #endregion
    }
}
