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
        static object[] InsertNumberCases =
        {
            new object[] { 15, 15, 0, 0, 15 },
            new object[] { 8, 15, 0, 0, 9 },
            new object[] { 8, 15, 3, 8, 120 }
        };

        [TestCaseSource("InsertNumberCases")]
        public void InsertNumer_Param_ShouldBeEqualToResult(int numberSource, int numberIn, int i, int j, int r)
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

        static object[] FilterDigitCases =
        {
            new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, new List<int> { 7, 70, 17 } },
            new object[] { new List<int> { 1, 1, 1, 4, 5, 6, 7 }, 0, new List<int> () },
        };

        [TestCaseSource("FilterDigitCases")]
        public void FilterDigit_Param_ShouldBeEqualToResult(List<int> numbers, int digit, List<int> result)
        {
            var r = NumericMethods.FilterDigit(numbers, digit);

            CollectionAssert.AreEqual(result, r);
        }

        [Test]
        public void FilterDigit_ListNull_Exeption()
        {
            Assert.Throws<ArgumentNullException>(() => NumericMethods.FilterDigit(null, 1));
        }

        [Test]
        public void FilterDigit_EmptyList_EmptyList()
        {
            var numbers = new List<int>();
            var r = NumericMethods.FilterDigit(numbers, 1);

            CollectionAssert.AreEqual(numbers, r);
        }

        [Test]
        public void FilterDigit_DigitLowerZero_Exception()
        {
            var numbers = new List<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => NumericMethods.FilterDigit(numbers, -1));
        }

        [Test]
        public void FilterDigit_DigitGreater9_Exception()
        {
            var numbers = new List<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => NumericMethods.FilterDigit(numbers, 11));
        }

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
    }
}
