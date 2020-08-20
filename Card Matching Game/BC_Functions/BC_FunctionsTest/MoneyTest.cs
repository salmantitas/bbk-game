using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using NUnit.Framework;

namespace BC_FunctionsTest
{
    [TestFixture]
    class MoneyTest
    {
        Money money;

        [SetUp]
        public void SetUp()
        {
            money = new Money(5m);
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void check_money()
        {
            Assert.AreEqual(5m, money.Dollars);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void add_money()
        {
            money.AddMoney(1m);
            Assert.AreEqual(6m, money.Dollars);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void remove_money()
        {
            money.RemoveMoney(2m);
            Assert.AreEqual(3m, money.Dollars);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void money_dollars_to_string()
        {
            Assert.AreEqual("$5.00", money.ToString());
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void money_cents_to_string()
        {
            money.Dollars = 0.69m;
            Assert.AreEqual("69¢", money.ToString());
        }
    }
}
