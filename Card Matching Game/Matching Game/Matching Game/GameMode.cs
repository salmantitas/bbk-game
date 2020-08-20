using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using MatchingGameFrameworks;

namespace Matching_Game
{
    internal class GameMode
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string pictureFileText;

        public string PictureFileText
        {
            get { return pictureFileText; }
            set { pictureFileText = value; }
        }
        private ScoreRule scoreRules;

        public ScoreRule ScoreRules
        {
            get { return scoreRules; }
            set { scoreRules = value; }
        }
        private Position2D squareCount;

        public Position2D SquareCount
        {
            get { return new Position2D(squareCount); }
            set { squareCount = new Position2D(value); }
        }

        private string backOfCardImageLocation;

        public string BackOfCardImageLocation
        {
            get { return backOfCardImageLocation; }
            set { backOfCardImageLocation = value; }
        }

        private int highScoreID;

        public int HighScoreID
        {
            get { return highScoreID; }
            set { highScoreID = value; }
        }

        public GameMode(
            int id,
            string name,
            string pictureFileText,
            ScoreRule scoreRules,
            Position2D squareCount,
            string backOfCardImageLocation,
            int highScoreID)
        {
            this.id = id;
            this.name = name;
            this.pictureFileText = pictureFileText;
            this.scoreRules = scoreRules;
            this.squareCount = squareCount;
            this.backOfCardImageLocation = backOfCardImageLocation;
            this.highScoreID = highScoreID;
        }
    }
}
