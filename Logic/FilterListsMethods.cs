using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Contains methods which filter lists by some criterion
    /// </summary>
    public class FilterListsMethods
    {
        #region FilterDigit method
        /// <summary>
        /// Filter list and return only numbers containing digit
        /// </summary>
        /// <param name="numbers">List of numbers</param>
        /// <param name="digit">Digit using in filtering</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <returns>List containig only numbers with digit</returns>
        public static List<int> FilterDigit(List<int> numbers, int digit)
        {
            if (numbers == null)
                throw new ArgumentNullException();
            if (digit < 0 || digit > 9)
                throw new ArgumentOutOfRangeException("Digit must be from 0 to 9");

            var result = new List<int>();
            foreach (var n in numbers)
                if (ContainDigit(n, digit))
                    result.Add(n);
            return result;
        }
        #endregion

        #region Helper method for FilterDigit method
        private static bool ContainDigit(int number, int digit)
        {
            int currentDigit = 0;
            while (number != 0)
            {
                currentDigit = number % 10;
                if (currentDigit == digit)
                    return true;
                number -= currentDigit;
                number /= 10;
            }
            return false;
        }
        #endregion
    }
}
