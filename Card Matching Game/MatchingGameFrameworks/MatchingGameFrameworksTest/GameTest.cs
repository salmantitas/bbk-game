using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MatchingGameFrameworks;
using NUnit.Framework;
using MatchingGameFrameworks.Exceptions;

namespace MatchingGameFrameworksTest
{
    [TestFixture]
    class GameTest
    {
        Game game;
        ImageNameDatabase ind;

        [SetUp]
        public void SetUp()
        {
            game = new Game(6, 5);
            ind = new ImageNameDatabase(new string[] 
                {"image 1","image2","Pic 3","guieortu","trew",
                "what","image 7","why","How","evil",
                "drunkmaster", "master","13","drunk","but why"});
        }

        [Test, Timeout(3000)]
        public void setting_up()
        {
            Assert.Pass();
        }

        [Test, Timeout(3000), ExpectedException(typeof(BelowMinimumException))]
        public void shuffle_with_negitive_number()
        {
            game.Shuffle(-1);
        }

        [Test, Timeout(3000)]
        public void card_count()
        {
            Assert.AreEqual(30, game.TotalCardCount);
        }
        [Test, Timeout(3000)]
        public void unique_card_count()
        {
            Assert.AreEqual(15, game.UniqueCardCount);
        }
        [Test, Timeout(3000)]
        public void Reset_game()
        {
            game.Cards[0, 1].Flipped = true;
            game.Cards[2, 1].Removed = true;
            game.ResetGame();
            Assert.IsFalse(game.Cards[0, 1].Flipped,"did not flip cards back");
            Assert.IsFalse(game.Cards[2, 1].Removed,"did not add the card back");
        }

        [Test, Timeout(3000)]
        public void set_image()
        {
            game.SetImage("C:", ind);
            Assert.AreEqual("C:\\image 1",game.Cards[0,0].ImageLocation);
        }

        [Test, Timeout(3000)]
        public void get_image()
        {
            game.SetImage("C:", ind);
            game.BackOfCardImageLocation = "C:\\back.jpg";
            Assert.AreEqual("C:\\back.jpg", game.GetImage(0, 0));
            game.Cards[0,0].Flip();
            Assert.AreEqual("C:\\image 1", game.GetImage(0, 0));
        }

        [Test, Timeout(3000)]
        public void hide_all_cards()
        {
            game.Cards[0, 1].Flipped = true;
            game.Cards[2, 1].Removed = true;
            game.HideAllCards();
            Assert.IsFalse(game.Cards[0, 1].Flipped, "did not flip cards back");
            Assert.IsTrue(game.Cards[2, 1].Removed, "card wasn suppost to remain removed");
        }
        [Test, Timeout(3000)]
        public void fliped_card_count()
        {
            Assert.AreEqual(0, game.FlipedCardsCount);
            game.Cards[0, 1].Flip();
            game.Cards[2, 1].Flip();
            Assert.AreEqual(2, game.FlipedCardsCount);
        }
        [Test, Timeout(3000)]
        public void removed_card_count()
        {
            Assert.AreEqual(0, game.RemovedCardsCount);
            game.Cards[0, 1].Remove();
            game.Cards[1, 1].Remove();
            game.Cards[2, 1].Remove();
            game.Cards[3, 1].Remove();
            game.Cards[0, 2].Remove();
            game.Cards[0, 3].Remove();
            Assert.AreEqual(6, game.RemovedCardsCount);

        }
        [Test, Timeout(3000)]
        public void remove_fliped_cards()
        {
            game.Cards[0, 1].Flip();
            game.RemoveFlipedCards();
            Assert.IsTrue(game.Cards[0, 1].Removed,"did not remove card");
            Assert.IsFalse(game.Cards[2, 1].Removed,"removed too many cards");
        }
        [Test, Timeout(3000)]
        public void flip_cards_match_positive()
        {
            game.Cards[0, 1].Flip();
            game.Cards[3, 3].Flip();
            Assert.IsTrue(game.FlipedCardsMatch);
        }
        [Test, Timeout(3000)]
        public void flip_cards_match_negitive()
        {
            game.Cards[0, 1].Flip();
            game.Cards[4, 1].Flip();
            Assert.IsFalse(game.FlipedCardsMatch);
        }
        [Test, Timeout(3000)]
        public void flip_cards_match_too_many()
        {
            game.Cards[0, 1].Flip();
            game.Cards[3, 3].Flip();
            game.Cards[4, 1].Flip();
            Assert.IsFalse(game.FlipedCardsMatch);
        }

        [Test, Timeout(3000)]
        public void flip_cards_match_only_one()
        {
            game.Cards[0, 1].Flip();
            Assert.IsFalse(game.FlipedCardsMatch);
        }

        [Test, Timeout(3000)]
        public void game_is_complete_positive()
        {
            for (int x = 0; x < game.CardSize.X; x++)
            {
                for (int y = 0; y < game.CardSize.Y; y++)
                {
                    game.Cards[x, y].Removed = true;
                }
            }
            Assert.IsTrue(game.GameComplete);
        }

        [Test, Timeout(3000)]
        public void game_is_complete_negitive()
        {
            for (int x = 0; x < game.CardSize.X; x++)
            {
                for (int y = 0; y < game.CardSize.Y; y++)
                {
                    game.Cards[x, y].Removed = true;
                }
            }
            game.Cards[2, 3].Removed = false;
            Assert.IsFalse(game.GameComplete);
        }

        [Test, Timeout(3000)]
        public void card_remain()
        {
            Assert.AreEqual(30, game.CardsRemain);
            game.Cards[0, 1].Flipped = true;
            game.Cards[2, 1].Removed = true;
            game.Cards[2, 2].Removed = true;
            Assert.AreEqual(28, game.CardsRemain);
        }

        [Test, Timeout(3000)]
        public void hidden_cards_count()
        {
            Assert.AreEqual(30, game.HiddenCardCount);
            game.Cards[0, 1].Flipped = true;
            game.Cards[2, 1].Removed = true;
            Assert.AreEqual(28, game.HiddenCardCount);
        }
    }
}
