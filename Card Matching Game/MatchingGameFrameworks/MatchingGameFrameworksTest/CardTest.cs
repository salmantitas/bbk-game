using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MatchingGameFrameworks;
using MatchingGameFrameworks.Exceptions;

namespace MatchingGameFrameworksTest
{
    [TestFixture]
    class CardTest
    {
        Card card1;
        Card card2;
        Card card3;

        [SetUp]
        public void SetUp()
        {
            card1 = new Card();
            card2 = new Card();
            card3 = new Card();
            card1.ID = 1;
            card2.ID = 2;
            card3.ID = 1;
        }
        [Test,Timeout(3000)]
        public void flippping()
        {
            card1.Flip();
            Assert.IsTrue(card1.Flipped, "card did not flip");
            card1.Flip();
            Assert.IsFalse(card1.Flipped, "card did not flip back");
        }
        [Test, Timeout(3000)]
        public void remove()
        {
            card1.Remove();
            Assert.IsTrue(card1.Removed);
        }
        [Test, Timeout(3000)]
        public void match_positive()
        {
            Assert.IsTrue(card1.IsMatch(card3));
        }
        [Test, Timeout(3000)]
        public void match_negitive()
        {
            Assert.IsFalse(card1.IsMatch(card2));
        }
        [Test, Timeout(3000)]
        public void match_self_exception_off()
        {
            Assert.IsFalse(card1.IsMatch(card1,false));
        }
        [Test, Timeout(3000),ExpectedException(typeof(CompareToSelfException))]
        public void match_self_exception_on()
        {
            Assert.IsFalse(card1.IsMatch(card1));
        }
    }
}
