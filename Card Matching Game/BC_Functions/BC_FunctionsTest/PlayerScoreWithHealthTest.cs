using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using NUnit.Framework;

namespace BC_FunctionsTest
{
    [TestFixture]
    class PlayerScoreWithHealthTest
    {
        PlayerScoreWithHealth[] pswh;

        [SetUp]
        public void SetUp()
        {
            pswh = new PlayerScoreWithHealth[3];
            pswh[0] = new PlayerScoreWithHealth();
            pswh[1] = new PlayerScoreWithHealth(500);
            pswh[1].Health = 200;
            pswh[2] = new PlayerScoreWithHealth(300, 3);
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void setting_up_varible_with_no_pram()
        {
            Assert.AreEqual(100,pswh[0].Health);
            Assert.AreEqual(100,pswh[0].MaxHealth);
            Assert.AreEqual(100,pswh[0].StartingHealth);
            Assert.AreEqual(1,pswh[0].StartingLife);
            Assert.AreEqual(1,pswh[0].Life);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void setting_up_varible_with_1_pram()
        {
            Assert.AreEqual(200, pswh[1].Health);
            Assert.AreEqual(500, pswh[1].MaxHealth);
            Assert.AreEqual(500, pswh[1].StartingHealth);
            Assert.AreEqual(1, pswh[1].StartingLife);
            Assert.AreEqual(1, pswh[1].Life);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void setting_up_varible_with_2_pram()
        {
            Assert.AreEqual(300, pswh[2].Health);
            Assert.AreEqual(300, pswh[2].MaxHealth);
            Assert.AreEqual(300, pswh[2].StartingHealth);
            Assert.AreEqual(3, pswh[2].StartingLife);
            Assert.AreEqual(3, pswh[2].Life);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void change_starting_health()
        {
            pswh[0].StartingHealth = 50;
            Assert.IsFalse(pswh[0].MaxHealthIsStartingHealth);
            Assert.AreEqual(50,pswh[0].StartingHealth);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void take_damage()
        {
            pswh[0].TakeDamage(30);
            Assert.AreEqual(70, pswh[0].Health);
            Assert.IsFalse(pswh[0].IsDead);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void take_too_much_damage()
        {
            pswh[0].TakeDamage(125);
            Assert.AreEqual(0, pswh[0].Health);
            Assert.IsTrue(pswh[0].IsDead);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void heal_partial()
        {
            pswh[1].Heal(100);
            Assert.AreEqual(300, pswh[1].Health);
            Assert.IsFalse(pswh[0].IsDead);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void heal_too_much()
        {
            pswh[1].Heal(400);
            Assert.AreEqual(500, pswh[1].Health);
            Assert.IsFalse(pswh[0].IsDead);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void heal_full()
        {
            pswh[1].Heal();
            Assert.AreEqual(500, pswh[1].Health);
            Assert.IsFalse(pswh[0].IsDead);
        }
    }
}
