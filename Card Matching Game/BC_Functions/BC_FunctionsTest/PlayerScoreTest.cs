using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using NUnit.Framework;

namespace BC_FunctionsTest
{
    class PlayerScoreTest
    {
        PlayerScore player1;
        PlayerScoreWithLife player2;

        [SetUp]
        public void SetUp()
        {
            player1 = new PlayerScore(1, "Brian");
            player2 = new PlayerScoreWithLife(2, "Chaves", 5);

            player1.Points = 500;
            player2.Points = 300;
        }

        [Test,Timeout(Shared.BASIC_TIMEOUT)]
        public void add_points()
        {
            player1.AddPoints(200);
            player2.AddPoints(800);
            Assert.AreEqual(700, player1.Points);
            Assert.AreEqual(1100, player2.Points);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void player_name()
        {
            player1.Name = "";
            Assert.AreEqual("Player 1", player1.Name);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void lose_points()
        {
            player1.LosePoints(400);
            player2.LosePoints(100);
            Assert.AreEqual(100, player1.Points);
            Assert.AreEqual(200, player2.Points);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void reset_points()
        {
            player1.ResetPoints();
            player2.ResetPoints();
            Assert.AreEqual(0, player1.Points);
            Assert.AreEqual(0, player2.Points);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void points_lowest()
        {
            player1.LosePoints(800);
            player2.Points = -800;
            Assert.AreEqual(0, player1.Points);
            Assert.AreEqual(0, player2.Points);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void points_negitives()
        {
            player1.AllowNegatives = true;
            player2.AllowNegatives = true;
            player1.LosePoints(800);
            player2.Points = -800;
            Assert.AreEqual(-300, player1.Points);
            Assert.AreEqual(-800, player2.Points);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void add_life()
        {
            player2.AddLife();
            Assert.AreEqual(6, player2.Life);
            Assert.IsFalse(player2.GameOver);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void add_muliple_lives()
        {
            player2.AddLife(3);
            Assert.AreEqual(8, player2.Life);
            Assert.IsFalse(player2.GameOver);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void lose_life()
        {
            player2.LoseLife();
            Assert.AreEqual(4, player2.Life);
            Assert.IsFalse(player2.GameOver);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void lose_muliple_lives()
        {
            player2.LoseLife(3);
            Assert.AreEqual(2, player2.Life);
            Assert.IsFalse(player2.GameOver);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void life_boundary()
        {
            player2.LoseLife(10);
            Assert.AreEqual(0, player2.Life);
            Assert.IsTrue(player2.GameOver);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void modify_game_over()
        {
            player2.GameOver = true;
            Assert.AreEqual(0, player2.Life);
            player2.GameOver = false;
            Assert.AreEqual(1, player2.Life);
        }
        [Test, Timeout(Shared.BASIC_TIMEOUT)]
        public void reset_life()
        {
            player2.AddLife();
            player2.ResetPoints();
            Assert.AreEqual(0, player2.Points);
            Assert.AreEqual(5, player2.Life);
        }

    }
}
