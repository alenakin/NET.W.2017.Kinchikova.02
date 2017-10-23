using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    public class FilterListsMethodsTests
    {
        #region TestCases
        static object[] FilterDigitCases =
        {
            new object[] { new List<int> { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 }, 7, new List<int> { 7, 70, 17 } },
            new object[] { new List<int> { 1, 1, 1, 4, 5, 6, 7 }, 0, new List<int> () },
        };
        #endregion

        #region Tests for FilerDigit method
        [TestCaseSource("FilterDigitCases")]
        public void FilterDigit_Param_ShouldBeEqualToResult(List<int> numbers, int digit, List<int> result)
        {
            var r = FilterListsMethods.FilterDigit(numbers, digit);

            CollectionAssert.AreEqual(result, r);
        }

        [Test]
        public void FilterDigit_ListNull_Exeption()
        {
            Assert.Throws<ArgumentNullException>(() => FilterListsMethods.FilterDigit(null, 1));
        }

        [Test]
        public void FilterDigit_EmptyList_EmptyList()
        {
            var numbers = new List<int>();
            var r = FilterListsMethods.FilterDigit(numbers, 1);

            CollectionAssert.AreEqual(numbers, r);
        }

        [Test]
        public void FilterDigit_DigitLowerZero_Exception()
        {
            var numbers = new List<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => FilterListsMethods.FilterDigit(numbers, -1));
        }

        [Test]
        public void FilterDigit_DigitGreater9_Exception()
        {
            var numbers = new List<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() => FilterListsMethods.FilterDigit(numbers, 11));
        }
        #endregion
    }
}
