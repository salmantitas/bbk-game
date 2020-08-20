using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MatchingGameFrameworks;
using BC_Functions;

namespace MatchingGameFrameworksTest
{
    [TestFixture]
    class MatchingGamePlayerScoreTest
    {
        MatchingGamePlayerScore player;
        ScoreRule scoreRule;

        [SetUp]
        public void SetUp()
        {
            scoreRule = new ScoreRule(500,1000,25,3.5m);
            player = new MatchingGamePlayerScore(scoreRule);
            player.Seconds = 10m;
            player.SuccessfulMatchCount = 2;
            player.MisMatchCount = 5;
        }

        [Test, Timeout(3000)]
        public void score()
        {
            Assert.AreEqual(2340,player.Points);
        }
    

    }
}
