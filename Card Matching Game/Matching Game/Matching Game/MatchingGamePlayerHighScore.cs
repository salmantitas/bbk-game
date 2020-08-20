//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using BC_Functions;
//using MatchingGameFrameworks;

//namespace Matching_Game
//{
//    class MatchingGamePlayerHighScore : MatchingGamePlayerScore
//    {
//        public override int Points
//        {
//            get
//            {
//                return BasePoints;
//            }
//            set
//            {
//                BasePoints = value;
//            }
//        }

//        private byte gameID;

//        public byte GameID
//        {
//            get { return gameID; }
//            set { gameID = value; }
//        }

//        public MatchingGamePlayerHighScore()
//        {
//        }

//        public MatchingGamePlayerHighScore(MatchingGamePlayerScore player)
//        {
//            this.Name = player.Name;
//            this.MisMatchCount = player.MisMatchCount;
//            this.ScoreRule = player.ScoreRule;
//            this.Points = player.Points;
//            this.ID = player.ID;
//            this.Seconds = player.Seconds;
//            this.SuccessfulMatchCount = player.SuccessfulMatchCount;
//            if (player is MatchingGamePlayerHighScore)
//            {
//                MatchingGamePlayerHighScore mgphs = (MatchingGamePlayerHighScore)player;
//                this.GameID = mgphs.GameID;
//            }
//            else
//            {
//                this.GameID = 0;
//            }
//        }
//    }
//}
