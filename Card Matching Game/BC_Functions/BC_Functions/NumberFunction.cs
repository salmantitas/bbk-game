using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC_Functions
{
    public static class NumberFunction
    {
        /// <summary>
        /// Checks to see if a value is between 2 numbers
        /// </summary>
        /// <param name="value">value to test</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>True or false</returns>
        public static bool IsBetween(int value, int min, int max)
        {
            if (min > max)
            {
                throw new InvalidDataException();
            }

            if (value >= min && value <= max)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Checks to see if a value is between 2 numbers
        /// </summary>
        /// <param name="value">value to test</param>
        /// <param name="min">Minimum value</param>
        /// <param name="max">Maximum value</param>
        /// <returns>True or false</returns>
        public static bool IsBetween(decimal value, decimal min, decimal max)
        {
            if (min > max)
            {
                throw new InvalidDataException();
            }

            if (value >= min && value <= max)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// This method will get the summary of number array
        /// </summary>
        /// <param name="values">number array</param>
        /// <param name="min">the losest number</param>
        /// <param name="max">the highest number</param>
        /// <param name="sum">the sum of the array</param>
        /// <param name="average">the average of the array</param>
        public static void ArrayValues(int[] values, out int min, out int max, out int sum, out decimal average)
        {
            min = Min(values);
            max = Max(values);
            sum = Sum(values);
            average = Average(values);
        }

        /// <summary>
        /// This method will get the summary of number array
        /// </summary>
        /// <param name="values">number array</param>
        /// <param name="min">the losest number</param>
        /// <param name="max">the highest number</param>
        /// <param name="sum">the sum of the array</param>
        /// <param name="average">the average of the array</param>
        public static void ArrayValues(decimal[] values, out decimal min, out decimal max, out decimal sum, out decimal average)
        {
            min = Min(values);
            max = Max(values);
            sum = Sum(values);
            average = Average(values);
        }

        /// <summary>
        /// gets the highest number from an array of numbers
        /// </summary>
        /// <param name="values">array list</param>
        /// <returns>highest number</returns>
        public static int Max(int[] values)
        {
            int max = values[0];
            for (int x = 0; x < values.Count(); x++)
            {
                if (max < values[x])
                {
                    max = values[x];
                }
            }
            return max;
        }

        /// <summary>
        /// gets the highest number from an array of numbers
        /// </summary>
        /// <param name="values">array list</param>
        /// <returns>highest number</returns>
        public static decimal Max(decimal[] values)
        {
            decimal max = values[0];
            for (int x = 0; x < values.Count(); x++)
            {
                if (max < values[x])
                {
                    max = values[x];
                }
            }
            return max;
        }

        /// <summary>
        /// gets the lowest number from an array of numbers
        /// </summary>
        /// <param name="values">array list</param>
        /// <returns>lowest number</returns>
        public static int Min(int[] values)
        {
            int min = values[0];
            for (int x = 0; x < values.Count(); x++)
            {
                if (min > values[x])
                {
                    min = values[x];
                }
            }
            return min;
        }

        /// <summary>
        /// gets the lowest number from an array of numbers
        /// </summary>
        /// <param name="values">array list</param>
        /// <returns>lowest number</returns>
        public static decimal Min(decimal[] values)
        {
            decimal min = values[0];
            for (int x = 0; x < values.Count(); x++)
            {
                if (min > values[x])
                {
                    min = values[x];
                }
            }
            return min;
        }

        /// <summary>
        /// This method will get the sum of all the numbers in an array
        /// </summary>
        /// <param name="values">arraylist of numbers</param>
        /// <returns>the sum of numbers</returns>
        public static int Sum(int[] values)
        {
            int sum = 0;
            for (int x = 0; x < values.Count(); x++)
            {
                sum += values[x];
            }
            return sum;
        }

        /// <summary>
        /// This method will get the sum of all the numbers in an array
        /// </summary>
        /// <param name="values">arraylist of numbers</param>
        /// <returns>the sum of numbers</returns>
        public static decimal Sum(decimal[] values)
        {
            decimal sum = 0;
            for (int x = 0; x < values.Count(); x++)
            {
                sum += values[x];
            }
            return sum;
        }

        /// <summary>
        /// Gets the average of the numbers in an array
        /// </summary>
        /// <param name="values">number array</param>
        /// <returns>The average</returns>
        public static decimal Average(int[] values)
        {
            decimal average = 0;
            average = Sum(values) / values.Count();
            return average;
        }

        /// <summary>
        /// Gets the average of the numbers in an array
        /// </summary>
        /// <param name="values">number array</param>
        /// <returns>The average</returns>
        public static decimal Average(decimal[] values)
        {
            decimal average = 0;
            average = Sum(values) / values.Count();
            return average;
        }

        /// <summary>
        /// This method will ensure the number will not go any lower then
        /// the value
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="minimum">minimum value</param>
        public static void SetMinimum(ref int value, int minimum)
        {
            if (value < minimum)
            {
                value = minimum;
            }
        }

        /// <summary>
        /// This will ensue the value does not go higher then the maximum value
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="maximum">maximum value</param>
        public static void SetMaximum(ref int value, int maximum)
        {
            if (value > maximum)
            {
                value = maximum;
            }
        }

        /// <summary>
        /// This will ensure the value stays between the boundarys
        /// </summary>
        /// <param name="value">the value to set</param>
        /// <param name="minimum">minimum value</param>
        /// <param name="maximum">maximum value</param>
        public static void SetBetween(ref int value, int minimum, int maximum)
        {
            if (minimum > maximum)
            {
                throw new InvalidDataException();
            }
            if (value < minimum)
            {
                value = minimum;
            }
            if (value > maximum)
            {
                value = maximum;
            }
        }

        /// <summary>
        /// This method will ensure the number will not go any lower then
        /// the value
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="minimum">minimum value</param>
        public static void SetMinimum(ref decimal value, decimal minimum)
        {
            if (value < minimum)
            {
                value = minimum;
            }
        }

        /// <summary>
        /// This will ensue the value does not go higher then the maximum value
        /// </summary>
        /// <param name="value">value</param>
        /// <param name="maximum">maximum value</param>
        public static void SetMaximum(ref decimal value, decimal maximum)
        {
            if (value > maximum)
            {
                value = maximum;
            }
        }

        /// <summary>
        /// This will ensure the value stays between the boundarys
        /// </summary>
        /// <param name="value">the value to set</param>
        /// <param name="minimum">minimum value</param>
        /// <param name="maximum">maximum value</param>
        public static void SetBetween(ref decimal value, decimal minimum, decimal maximum)
        {
            if (minimum > maximum)
            {
                throw new InvalidDataException();
            }
            if (value < minimum)
            {
                value = minimum;
            }
            if (value > maximum)
            {
                value = maximum;
            }
        }
    }
}
