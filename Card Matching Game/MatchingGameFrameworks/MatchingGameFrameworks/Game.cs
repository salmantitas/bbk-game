using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using MatchingGameFrameworks.Exceptions;

namespace MatchingGameFrameworks
{
    public class Game
    {
        private const int MINIMUM_CARD_IN_A_ROW = 2;

        private Card[,] cards;

        public Card[,] Cards
        {
            get { return (Card[,])cards.Clone(); }
        }

        private Position2D cardSize;

        public Position2D CardSize
        {
            get { return new Position2D(cardSize); }
            set
            {
                cardSize = new Position2D(value);

                if (cardSize.X < MINIMUM_CARD_IN_A_ROW)
                {
                    throw new BelowMinimumException(MINIMUM_CARD_IN_A_ROW, cardSize.X);
                }

                if (cardSize.Y < MINIMUM_CARD_IN_A_ROW)
                {
                    throw new BelowMinimumException(MINIMUM_CARD_IN_A_ROW, cardSize.Y);
                }

                if (TotalCardCount % 2 == 1)
                {
                    throw new OddNumberException();
                }

                cards = new Card[cardSize.X, cardSize.Y];
                for (int x = 0; x < cardSize.X; x++)
                {
                    for (int y = 0; y < cardSize.Y; y++)
                    {
                        cards[x, y] = new Card();
                        cards[x, y].ID = x + (y * cardSize.X);
                        if (cards[x, y].ID >= UniqueCardCount)
                        {
                            cards[x, y].ID -= UniqueCardCount;
                        }
                    }
                }
            }
        }

        private MatchingGamePlayerScore player;

        public MatchingGamePlayerScore Player
        {
            get { return player; }
            set { player = value; }
        }


        private string backOfCardImageLocation;

        public string BackOfCardImageLocation
        {
            get { return backOfCardImageLocation; }
            set { backOfCardImageLocation = value; }
        }

        public Game(int columnsCount, int rowCount)
        {
            CardSize = new Position2D(columnsCount, rowCount);
        }

        public int TotalCardCount
        {
            get
            {
                return cardSize.Area;
            }
        }

        public int UniqueCardCount
        {
            get
            {
                return cardSize.Area / 2;
            }
        }


        public void ResetGame()
        {
            for (int x = 0; x < cardSize.X; x++)
            {
                for (int y = 0; y < cardSize.Y; y++)
                {
                    cards[x, y].Reset();
                }
            }
        }

        public void SwitchSpots(ref Card card1, ref Card card2, bool throwCompareToSelfException = true)
        {
            if (card1 != card2)
            {
                Card temp = card1;
                card1 = card2;
                card2 = temp;
            }
            else if (throwCompareToSelfException)
            {
                throw new CompareToSelfException();
            }
        }

        //public void Shuffle()
        //{
        //    Shuffle(1);
        //}

        public void Shuffle(int numberOfShuffles = 1)
        {
            if (numberOfShuffles < 1)
            {
                throw new BelowMinimumException(1, numberOfShuffles);
            }

            Random random = new Random();
            for (int z = 0; z < numberOfShuffles; z++)
            {
                for (int x = 0; x < cardSize.X; x++)
                {
                    for (int y = 0; y < cardSize.Y; y++)
                    {
                        int X = random.Next(cardSize.X);
                        int Y = random.Next(cardSize.Y);
                        SwitchSpots(ref cards[x, y], ref cards[X, Y], false);
                    }
                }
            }
        }

        public void SetImage(string path, ImageNameDatabase imageNameDatabase)
        {
            for (int x = 0; x < cardSize.X; x++)
            {
                for (int y = 0; y < cardSize.Y; y++)
                {
                    //try
                    //{
                    //    cards[x, y].ImageLocation =
                    //        path + "\\" + imageNameDatabase.ImageName[cards[x, y].ID];
                    //}
                    //catch
                    //{
                    //    cards[x, y].ImageLocation = "N/A";
                    //}

                    if (cards[x, y].ID >= imageNameDatabase.ImageName.Length)
                    {
                        cards[x, y].ImageLocation = "N/A";
                    }
                    else
                    {
                        cards[x, y].ImageLocation =
                            path + "\\" + imageNameDatabase.ImageName[cards[x, y].ID];
                    }
                }
            }
        }

        public string GetImage(int column, int row)
        {
            if (cards[column, row].Flipped)
            {
                return cards[column, row].ImageLocation;
            }
            else
            {
                return backOfCardImageLocation;
            }
        }

        public void HideAllCards()
        {
            for (int x = 0; x < cardSize.X; x++)
            {
                for (int y = 0; y < cardSize.Y; y++)
                {
                    cards[x, y].Flipped = false;
                }
            }
        }

        public int FlipedCardsCount
        {
            get
            {
                int flipCardsCount = 0;
                for (int x = 0; x < cardSize.X; x++)
                {
                    for (int y = 0; y < cardSize.Y; y++)
                    {
                        if (cards[x, y].Flipped)
                        {
                            flipCardsCount++;
                        }
                    }
                }
                return flipCardsCount;
            }
        }

        int test;

        public int Test
        {
            get { return test; }
            set { test = value; }
        }


        public int RemovedCardsCount
        {
            get
            {
                int removedCardsCount = 0;
                for (int x = 0; x < cardSize.X; x++)
                {
                    for (int y = 0; y < cardSize.Y; y++)
                    {
                        if (cards[x, y].Removed)
                        {
                            removedCardsCount++;
                        }
                    }
                }
                return removedCardsCount;
            }
        }

        public bool FlipedCardsMatch
        {
            get
            {
                if (FlipedCardsCount != 2)
                {
                    return false;
                }
                Card card1 = null;
                Card card2 = null;
                for (int x = 0; x < cardSize.X; x++)
                {
                    for (int y = 0; y < cardSize.Y; y++)
                    {
                        if (cards[x, y].Flipped)
                        {
                            if (card1 == null)
                            {
                                card1 = cards[x, y];
                            }
                            else
                            {
                                card2 = cards[x, y];
                            }
                        }
                    }//next y
                }//next x
                return card1.IsMatch(card2);
            }

        }

        public void RemoveFlipedCards()
        {
            for (int x = 0; x < cardSize.X; x++)
            {
                for (int y = 0; y < cardSize.Y; y++)
                {
                    if (cards[x, y].Flipped)
                    {
                        cards[x, y].Removed = true; ;
                    }
                }//next y
            }//next x
        }

        public bool GameComplete
        {
            get
            {
                //for (int x = 0; x < cardSize.X; x++)
                //{
                //    for (int y = 0; y < cardSize.Y; y++)
                //    {
                //        if (!cards[x, y].Removed)
                //        {
                //            return false;
                //        }
                //    }
                //}
                //return true;
                return HiddenCardCount == 0;
            }
        }

        public int CardsRemain
        {
            get
            {
                int cardsRemain = 0;
                for (int x = 0; x < cardSize.X; x++)
                {
                    for (int y = 0; y < cardSize.Y; y++)
                    {
                        if (!cards[x, y].Removed)
                        {
                            cardsRemain++;
                        }
                    }
                }

                return cardsRemain;
            }
        }

        public int HiddenCardCount
        {
            get
            {
                int hiddenCardsCount = 0;
                for (int x = 0; x < cardSize.X; x++)
                {
                    for (int y = 0; y < cardSize.Y; y++)
                    {
                        if (!(cards[x, y].Flipped || cards[x, y].Removed))
                        {
                            hiddenCardsCount++;
                        }
                    }
                }
                return hiddenCardsCount;
            }
        }

    }
}
