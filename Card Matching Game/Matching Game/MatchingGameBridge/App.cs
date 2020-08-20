using BC_Functions;
using Bridge;
using MatchingGameFrameworks;
using Newtonsoft.Json;
using System;

namespace MatchingGameBridge
{
	public class App
	{
		public static void Main()
		{
			// Write a message to the Console
			Console.WriteLine("Welcome to Bridge.NET");
			Card card = new Card(0, "image.gif");
			Console.WriteLine(card);
			// After building (Ctrl + Shift + B) this project, 
			// browse to the /bin/Debug or /bin/Release folder.

			// A new bridge/ folder has been created and
			// contains your projects JavaScript files. 

			// Open the bridge/index.html file in a browser by
			// Right-Click > Open With..., then choose a
			// web browser from the list

			// This application will then run in the browser.
		}
	}
}
namespace MatchingGameFrameworks
{
	public class Card
	{
		private int id;

		/// <summary>
		/// ID
		/// </summary>
		public int ID
		{
			get { return id; }
			set { id = value; }
		}
		private string imageLocation;

		/// <summary>
		/// Image Location
		/// </summary>
		public string ImageLocation
		{
			get { return imageLocation; }
			set { imageLocation = value; }
		}
		private bool flipped;

		/// <summary>
		/// card is fliped or not
		/// </summary>
		public bool Flipped
		{
			get
			{
				if (removed)
				{
					return false;
				}
				return flipped;
			}
			set { flipped = value; }
		}

		private bool removed;

		/// <summary>
		/// card is removed
		/// </summary>
		public bool Removed
		{
			get
			{
				if (imageLocation == "N/A")
				{
					return true;
				}
				return removed;
			}
			set { removed = value; }
		}

		public Card()
		{
			flipped = false;
			removed = false;
		}

		public Card(int id, string imageLocation)
		{
			this.id = id;
			this.imageLocation = imageLocation;
			flipped = false;
			removed = false;
		}

		public bool IsMatch(Card otherCard, bool throwCompareToSelfException = true)
		{
			if (otherCard == this)
			{
				return false;
			}

			if (this.ID == otherCard.ID)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Flip()
		{
			flipped = !flipped;
		}

		public void Remove()
		{
			removed = true;
		}

		public void Reset()
		{
			flipped = false;
			removed = false;
		}
	}
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
					throw new Exception("Below minimum size");
				}

				if (cardSize.Y < MINIMUM_CARD_IN_A_ROW)
				{
					throw new Exception("Below minimum size");
				}

				if (TotalCardCount % 2 == 1)
				{
					throw new Exception("Odd number of cards");
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

		//private MatchingGamePlayerScore player;

		//public MatchingGamePlayerScore Player
		//{
		//	get { return player; }
		//	set { player = value; }
		//}


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
		}

		public void Shuffle(int numberOfShuffles = 1)
		{
			if (numberOfShuffles < 1)
			{
				throw new Exception("Below Minimum");
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

		//public void SetImage(string path, ImageNameDatabase imageNameDatabase)
		//{
		//	for (int x = 0; x < cardSize.X; x++)
		//	{
		//		for (int y = 0; y < cardSize.Y; y++)
		//		{
		//			if (cards[x, y].ID >= imageNameDatabase.ImageName.Length)
		//			{
		//				cards[x, y].ImageLocation = "N/A";
		//			}
		//			else
		//			{
		//				cards[x, y].ImageLocation =
		//					path + "\\" + imageNameDatabase.ImageName[cards[x, y].ID];
		//			}
		//		}
		//	}
		//}

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
namespace BC_Functions
{
	public class Position2D
	{
		private int x;

		public int X
		{
			get { return x; }
			set { x = value; }
		}
		private int y;

		public int Y
		{
			get { return y; }
			set { y = value; }
		}

		public Position2D()
		{
			x = 0;
			x = 0;
		}

		public Position2D
			(int position)
		{
			x = position;
			y = position;
		}
		public Position2D
			(int x,
			int y)
		{
			this.x = x;
			this.y = y;
		}
		public Position2D(Position2D position)
		{
			this.x = position.x;
			this.y = position.y;
		}

		public virtual void SetPosition(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public override string ToString()
		{
			return "(" + X.ToString() + "," + Y.ToString() + ")";
		}

		public virtual void SetPosition(int position)
		{
			x = position;
			y = position;
		}

		public virtual void SetPosition(Position2D position)
		{
			SetPosition(position.X, position.Y);
		}

		public virtual int Area
		{
			get
			{
				return x * y;
			}
		}

		public static Position2D operator +(Position2D a, Position2D b)
		{
			return new Position2D(a.x + b.x, a.y + b.y);
		}

		public static Position2D operator -(Position2D a, Position2D b)
		{
			return new Position2D(a.x - b.x, a.y - b.y);
		}

		public static Position2D operator *(Position2D pos, int value)
		{
			return new Position2D(pos.x * value, pos.y * value);
		}

	}
}