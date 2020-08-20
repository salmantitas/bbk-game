using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using BC_Functions;

namespace BC_FunctionsTest
{
    [TestFixture]
    public class NumberFunctionTest
    {
        int[] intValues;
        decimal[] decValues;

        [SetUp]
        public void SetUp()
        {
            intValues = new int[] {81,86,55,3,39,
                            24,45,75,54,88};
            decValues = new decimal[] {0.539m,	0.023m,
                            0.782m,	0.351m,
                            0.279m,	0.419m,
                            0.642m,	0.250m,
                            0.208m,	0.296m};
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void max_int()
        {
            Assert.AreEqual(88, NumberFunction.Max(intValues));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void max_decimal()
        {
            Assert.AreEqual(0.782m, NumberFunction.Max(decValues));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void min_int()
        {
            Assert.AreEqual(3, NumberFunction.Min(intValues));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void min_decimal()
        {
            Assert.AreEqual(0.023m, NumberFunction.Min(decValues));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void sum_int()
        {
            Assert.AreEqual(550, NumberFunction.Sum(intValues));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void sum_decimal()
        {
            Assert.AreEqual(3.789m, NumberFunction.Sum(decValues));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void average_int()
        {
            Assert.AreEqual(55m, NumberFunction.Average(intValues));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void average_decimal()
        {
            Assert.AreEqual(0.3789m, NumberFunction.Average(decValues));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void array_values_int()
        {
            int max = 0;
            int min = 0;
            int sum = 0;
            decimal average = 0;
            NumberFunction.ArrayValues(intValues, out min, out max, out sum, out average);
            Assert.AreEqual(88, max);
            Assert.AreEqual(3, min);
            Assert.AreEqual(550, sum);
            Assert.AreEqual(55m, average);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void array_values_decimal()
        {
            decimal max = 0;
            decimal min = 0;
            decimal sum = 0;
            decimal average = 0;
            NumberFunction.ArrayValues(decValues, out min, out max, out sum, out average);
            Assert.AreEqual(0.782m, max);
            Assert.AreEqual(0.023m, min);
            Assert.AreEqual(3.789m, sum);
            Assert.AreEqual(0.3789m, average);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_below_int()
        {
            Assert.IsFalse(NumberFunction.IsBetween(1, 2, 5));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_above_int()
        {
            Assert.IsFalse(NumberFunction.IsBetween(7, 2, 5));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_in_int()
        {
            Assert.IsTrue(NumberFunction.IsBetween(3, 2, 5));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_min_int()
        {
            Assert.IsTrue(NumberFunction.IsBetween(2, 2, 5));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_max_int()
        {
            Assert.IsTrue(NumberFunction.IsBetween(5, 2, 5));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_below_decimal()
        {
            Assert.IsFalse(NumberFunction.IsBetween(0.123m, 0.124m, 0.2m));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_above_decimal()
        {
            Assert.IsFalse(NumberFunction.IsBetween(456.234m, 0.1m, 0.2m));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_in_decimal()
        {
            Assert.IsTrue(NumberFunction.IsBetween(0.15m, 0.1m, 0.2m));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_min_decimal()
        {
            Assert.IsTrue(NumberFunction.IsBetween(1.1m, 1.1m, 2.2m));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void is_between_max_decimal()
        {
            Assert.IsTrue(NumberFunction.IsBetween(5476.542m, 0.5m, 5476.542m));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT), ExpectedException(typeof(InvalidDataException))]
        public void is_between_error_int()
        {
            bool flag;
            flag = NumberFunction.IsBetween(5, 8, 4);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT), ExpectedException(typeof(InvalidDataException))]
        public void is_between_error_decimal()
        {
            bool flag;
            flag = NumberFunction.IsBetween(0.4234m, 0.9234234m, 0.234235m);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_minimum_value_int()
        {
            int value = 10;
            NumberFunction.SetMinimum(ref value, 15);
            Assert.AreEqual(15, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_minimum_value_decimal()
        {
            decimal value = 1.23m;
            NumberFunction.SetMinimum(ref value, 1.24m);
            Assert.AreEqual(1.24m, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_maximum_value_int()
        {
            int value = 15;
            NumberFunction.SetMaximum(ref value, 10);
            Assert.AreEqual(10, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_maximum_value_decimal()
        {
            decimal value = 1.23m;
            NumberFunction.SetMaximum(ref value, 1.21m);
            Assert.AreEqual(1.21m, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void dont_set_minimum_value_int()
        {
            int value = 20;
            NumberFunction.SetMinimum(ref value, 15);
            Assert.AreEqual(20, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void dont_set_minimum_value_decimal()
        {
            decimal value = 1.25m;
            NumberFunction.SetMinimum(ref value, 1.24m);
            Assert.AreEqual(1.25m, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void dont_set_maximum_value_int()
        {
            int value = 8;
            NumberFunction.SetMaximum(ref value, 10);
            Assert.AreEqual(8, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void dont_set_maximum_value_decimal()
        {
            decimal value = 0.93m;
            NumberFunction.SetMaximum(ref value, 1.21m);
            Assert.AreEqual(0.93m, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_between_function_below_int()
        {
            int value = 15;
            NumberFunction.SetBetween(ref value, 20, 30);
            Assert.AreEqual(20, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_between_function_above_int()
        {
            int value = 35;
            NumberFunction.SetBetween(ref value, 20, 30);
            Assert.AreEqual(30, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_between_function_on_int()
        {
            int value = 25;
            NumberFunction.SetBetween(ref value, 20, 30);
            Assert.AreEqual(25, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_between_function_below_decimal()
        {
            decimal value = 2.2m;
            NumberFunction.SetBetween(ref value, 2.5m, 3.5m);
            Assert.AreEqual(2.5m, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_between_function_above_decimal()
        {
            decimal value = 6.8m;
            NumberFunction.SetBetween(ref value, 2.5m, 3.5m);
            Assert.AreEqual(3.5m, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void set_between_function_on_decimal()
        {
            decimal value = 2.8m;
            NumberFunction.SetBetween(ref value, 2.5m, 3.5m);
            Assert.AreEqual(2.8m, value);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT), ExpectedException(typeof(InvalidDataException))]
        public void set_between_invalid_data_int()
        {
            int value = 10;
            NumberFunction.SetBetween(ref value, 20, 18);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT), ExpectedException(typeof(InvalidDataException))]
        public void set_between_invalid_data_decimal()
        {
            decimal value = 2.5m;
            NumberFunction.SetBetween(ref value, 45.6m, 32.7m);
        }
    }
}
