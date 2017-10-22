using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Contains methods which do some job with numbers
    /// </summary>
    public class NumericMethods
    {
        /// <summary>
        /// Inserts j bits from numberIn in numberSource in positions form i to j
        /// </summary>
        /// <param name="numberSource">Number in which bits will be inserted</param>
        /// <param name="numberIn">Number from which bits will be taken</param>
        /// <param name="i">Starting position of bits</param>
        /// <param name="j">End position of bits</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Returns number obtained by inserting bits from numberIn to numberSource</returns>
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            if (i > j)
                throw new ArgumentOutOfRangeException("i should be <= j");
            if (i < 0)
                throw new ArgumentOutOfRangeException("Positions shoud be >= 0");
            if (j > 31)
                throw new ArgumentOutOfRangeException("Number has only 32 bits!");

            int[] result = new int[1];
            var bitSource = new BitArray(new int[] { numberSource });
            var bitIn = new BitArray(new int[] { numberIn });
            for (int k = 0; i <= j; i++, k++)
                bitSource[i] = bitIn[k];
            bitSource.CopyTo(result, 0);
            return result[0];
        }

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

        /// <summary>
        /// Calculates the nth root of the real number by the Newton method
        /// </summary>
        /// <param name="number">A real number</param>
        /// <param name="n">Power</param>
        /// <param name="accuracy"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The nth root of number</returns>
        public static double FindNthRoot(double number, int n, double accuracy)
        {
            if (n % 2 == 0 && number < 0)
                throw new ArgumentException("It's impossoble to calulate a real root " +
                    "of even degree for negative number.");
            if (accuracy < 0 || accuracy > 1)
                throw new ArgumentOutOfRangeException("Accuracy must be from 0 to 1");

            double x = 0, result = 1;
            do
            {
                x = result;
                result = ((n - 1) * x + number / Math.Pow(x, n - 1)) / n;

            } while (Math.Abs(x - result) > accuracy);
            return result;
        }
    }
}
