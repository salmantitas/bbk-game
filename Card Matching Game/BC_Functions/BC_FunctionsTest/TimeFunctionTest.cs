using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using NUnit.Framework;

namespace BC_FunctionsTest
{
    [TestFixture]
    class TimeFunctionTest
    {
        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void _15_seconds()
        {
            Assert.AreEqual("0:15",TimeFunction.SecondsToString(15));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _45_seconds()
        {
            Assert.AreEqual("0:45", TimeFunction.SecondsToString(45));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _75_seconds()
        {
            Assert.AreEqual("1:15", TimeFunction.SecondsToString(75));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _65_seconds()
        {
            Assert.AreEqual("1:05", TimeFunction.SecondsToString(65));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void _105_seconds()
        {
            Assert.AreEqual("1:45", TimeFunction.SecondsToString(105));
        }
        
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void time_with_decimal()
        {
            Assert.AreEqual("1:06.67", TimeFunction.SecondsToString(66.666m,2));
        }
    }
}
