using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC_Functions;
using NUnit.Framework;

namespace BC_FunctionsTest
{
    [TestFixture]
    public class ConverterTest
    {
        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void TimeConverterTestMidnight()
        {
            Assert.AreEqual("12AM",Converter.Time24To12(0));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void TimeConverterTestMorning()
        {
            Assert.AreEqual("8AM", Converter.Time24To12(8));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void TimeConverterTestNoon()
        {
            Assert.AreEqual("12PM", Converter.Time24To12(12));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void TimeConverterTestAfternoon()
        {
            Assert.AreEqual("3PM", Converter.Time24To12(15));
        }

        [Test, Timeout(Shared.BASIC_TIMEOUT),ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TimeConverterTestOutOfBounds()
        {
            Converter.Time24To12(30);
        }
    }
}
