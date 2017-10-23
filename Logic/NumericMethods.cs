using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        /// Finds the smallest number that is greater than number and has the same set of digits
        /// </summary>
        /// <param name="number">Positive number</param>
        /// <param name="time">Variable to return the time spent on finding the number</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The smallest number that is greater than number and has the same set of digits</returns>
        public static int FindNextBiggerNumber(int number, out long time)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("Number must be positive");

            Stopwatch s = new Stopwatch();
            s.Start();
            int result, i;
            int[] digits = GetDigits(number);
            int size = digits.Length;
            int previousDigit = digits[size - 1];
            for (i = size - 2; i >= 0; i--)
            {
                if (digits[i] < previousDigit)
                {
                    ChangeDigits(digits, i);
                    break;
                }
                previousDigit = digits[i];
            }
            if (i < 0)
                result = -1;
            else
                result = GetNumber(digits);
            s.Stop();
            time = s.ElapsedMilliseconds;
            return result;
        }

        private static void ChangeDigits(int[] digits, int currentDigitIdx)
        {
            int minMoreThanCurrent = digits[currentDigitIdx + 1];
            int minIdx = currentDigitIdx + 1;
            int size = digits.Length;
            for (int j = currentDigitIdx + 1; j < size; j++)
                if (digits[j] < minMoreThanCurrent && digits[j] > digits[currentDigitIdx])
                {
                    minMoreThanCurrent = digits[j];
                    Console.WriteLine(j);
                    minIdx = j;
                }
            Swap(ref digits[currentDigitIdx], ref digits[minIdx]);
            Array.Sort(digits, currentDigitIdx + 1, size - currentDigitIdx - 1);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static int GetNumber(int[] digits)
        {
            int result = 0;
            foreach (int i in digits)
            {
                result += i;
                result *= 10;
            }
            return result / 10;
        }

        private static int[] GetDigits(int number)
        {
            var result = new List<int>();
            int currentDigit = 0;
            while (number != 0)
            {
                currentDigit = number % 10;
                result.Add(currentDigit);
                number -= currentDigit;
                number /= 10;
            }
            result.Reverse();
            return result.ToArray();
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
