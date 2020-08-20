using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using MatchingGameFrameworks;
using MatchingGameFrameworks.Exceptions;
using NUnit.Framework;

namespace MatchingGameFrameworksTest
{
    [TestFixture]
    class HighScoreTest
    {
        HighScore highScore;
        MatchingGamePlayerHighScore player1;
        MatchingGamePlayerHighScore player2;
        const string TEST_FILE = "C:\\Test\\Matching Game High Score Test.txt";
        const int TIME_OUT_TIMER = 3 * 1000;

        [SetUp, Test, Timeout(TIME_OUT_TIMER *10)]
        public void SetUp()
        {
            highScore = new HighScore("Name",TEST_FILE);
            highScore.ResetScore();
            highScore.LoadHighScore();

            player1 = new MatchingGamePlayerHighScore();
            player1.Name = "Brian";
            player1.Points = 50;
            player1.MisMatchCount = 512;
            player1.Seconds = 1800;
            player1.GameID = 0;

            player2 = new MatchingGamePlayerHighScore();
            player2.Name = "Loser";
            player2.Points = 0;
            player2.MisMatchCount = 2048;
            player2.Seconds = 3700;
            player2.GameID = 0;
        }



        [Test, Timeout(TIME_OUT_TIMER)]
        public void set_score_test()
        {
            highScore.SetScore(player1);

            HighScore highScore2 = new HighScore(TEST_FILE);
            highScore2.LoadHighScore();
            Assert.AreEqual("Brian", highScore2.PlayerHighScore[0].Name);
            Assert.AreEqual("Brian", highScore.PlayerHighScore[0].Name);
        }

        [Test, Timeout(TIME_OUT_TIMER), ExpectedException(typeof(NoHighScoreException))]
        public void set_score_error_test()
        {
            highScore.SetScore(player2);
        }

        [Test, Timeout(TIME_OUT_TIMER)]
        public void made_high_score_test_positive()
        {
            Assert.IsTrue(highScore.MadeHighScore(player1));
        }

        [Test, Timeout(TIME_OUT_TIMER)]
        public void made_high_score_test_negitive()
        {
            Assert.IsFalse(highScore.MadeHighScore(player2));
        }

        [Test, Timeout(TIME_OUT_TIMER), ExpectedException(typeof(NotImplementedException))]
        public void attempt_to_reset_player_score()
        {
            highScore.PlayerHighScore[0].ResetPoints();
        }

        [Test, Timeout(TIME_OUT_TIMER)]
        public void reset_high_score()
        {
            highScore.SetScore(player1);
            Assert.AreEqual("Brian", highScore.PlayerHighScore[0].Name);
            highScore.ResetScore();
            Assert.AreEqual("???", highScore.PlayerHighScore[0].Name);
        }

        [Test, Timeout(TIME_OUT_TIMER)]
        public void name_test()
        {
            Assert.AreEqual("Name", highScore.Name);
        }

        [TearDown]
        public void TearDown()
        {
            System.IO.File.Delete(TEST_FILE);
        }
    }
}
