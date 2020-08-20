using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BC_Functions;

namespace BC_FunctionsTest
{
    [TestFixture]
    public class TimeTest
    {
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _15_seconds()
        {
            Assert.AreEqual("0:15", Time.SecondsToString(15));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _45_seconds()
        {
            Assert.AreEqual("0:45", Time.SecondsToString(45));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _75_seconds()
        {
            Assert.AreEqual("1:15", Time.SecondsToString(75));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _65_seconds()
        {
            Assert.AreEqual("1:05", Time.SecondsToString(65));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _105_seconds()
        {
            Assert.AreEqual("1:45", Time.SecondsToString(105));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void time_with_decimal()
        {
            Assert.AreEqual("1:06.67", Time.SecondsToString(66.666m, 2));
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void leapYearTestPositive()
        {
            Assert.IsTrue(Time.IsLeapYear(1996));
            Assert.IsTrue(Time.IsLeapYear(2012));
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void leapYearTestNegitive()
        {
            Assert.IsFalse(Time.IsLeapYear(1997));
            Assert.IsFalse(Time.IsLeapYear(2011));
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void leapYearTest100_Years()
        {
            Assert.IsFalse(Time.IsLeapYear(1900));
            Assert.IsFalse(Time.IsLeapYear(2100));
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void leapYearTest400_Years()
        {
            Assert.IsTrue(Time.IsLeapYear(2000));
            Assert.IsTrue(Time.IsLeapYear(2400));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void GetMonthNameTest()
        {
            Assert.AreEqual("January", Time.MonthName(1));
            Assert.AreEqual("February", Time.MonthName(2));
            Assert.AreEqual("March", Time.MonthName(3));
            Assert.AreEqual("April", Time.MonthName(4));
            Assert.AreEqual("May", Time.MonthName(5));
            Assert.AreEqual("June", Time.MonthName(6));
            Assert.AreEqual("July", Time.MonthName(7));
            Assert.AreEqual("August", Time.MonthName(8));
            Assert.AreEqual("September", Time.MonthName(9));
            Assert.AreEqual("October", Time.MonthName(10));
            Assert.AreEqual("November", Time.MonthName(11));
            Assert.AreEqual("December", Time.MonthName(12));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT),ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetMonthNameTest_error()
        {
            Time.MonthName(13);
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void GetMonthDayCountTest()
        {
            Assert.AreEqual(31,Time.MonthDayCount(1));
            Assert.AreEqual(28, Time.MonthDayCount(2));
            Assert.AreEqual(30, Time.MonthDayCount(4));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT),ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetMonthDayCountTest_error()
        {
            Assert.AreEqual(31, Time.MonthDayCount(13));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void GetMonthDayCountTestLeapYear()
        {
            Assert.AreEqual(31, Time.MonthDayCount(1,true));
            Assert.AreEqual(29, Time.MonthDayCount(2,true));
            Assert.AreEqual(30, Time.MonthDayCount(4,true));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void GetMonthDayCountTestWithYearNonLeap()
        {
            Assert.AreEqual(31, Time.MonthDayCount(1,2013));
            Assert.AreEqual(28, Time.MonthDayCount(2, 2013));
            Assert.AreEqual(30, Time.MonthDayCount(4, 2013));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void GetMonthDayCountTestWithYearLeap()
        {
            Assert.AreEqual(31, Time.MonthDayCount(1, 2012));
            Assert.AreEqual(29, Time.MonthDayCount(2, 2012));
            Assert.AreEqual(30, Time.MonthDayCount(4, 2012));
        }
    }
}
