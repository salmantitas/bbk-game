using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using BC_Functions;
using MatchingGameFrameworks;

namespace Matching_Game
{
    internal static class Shared
    {
        internal static string Path
        {
            get
            {
                string path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = path.Substring(6);
                return path;
            }
        }

        //internal const int MATCHING_POINTS = 1000;
        //internal const int STARTING_POINTS = 500;
        //internal const int MIS_MATCH_PENALTY = 40;
        //internal const decimal TIME_PENALTY = 2.5m;

        internal static int MatchPoints
        {
            get
            {
                return gameMode[gameModeSelected].ScoreRules.SuccessfulMatchPointValue;
            }
        }
        internal static int StartingPoints
        {
            get
            {
                return gameMode[gameModeSelected].ScoreRules.StartingPoints;
            }
        }
        internal static int MisMatchPenalty
        {
            get
            {
                return gameMode[gameModeSelected].ScoreRules.MisMatchPenalty;
            }
        }
        internal static decimal TimePenalty
        {
            get
            {
                return gameMode[gameModeSelected].ScoreRules.TimePenalty;
            }
        }

        internal static int ColumnCount
        {
            get
            {
                return gameMode[gameModeSelected].SquareCount.X;
            }
        }

        internal static int RowCount
        {
            get
            {
                return gameMode[gameModeSelected].SquareCount.Y;
            }
        }

        private static GameMode[] gameMode;
        //private static List<GameMode> gameMode;

        internal static GameMode[] GameMode
        //internal static List<GameMode> GameMode
        {
            get { return gameMode; }
            set { gameMode = value; }
        }
        private static ScoreRule[] scoreRule;
        //private static List<ScoreRule> scoreRule;

        internal static ScoreRule[] ScoreRule
        //internal static List<ScoreRule> ScoreRule
        {
            get { return scoreRule; }
            set { scoreRule = value; }
        }

        //enum GameMode
        //{
        //    EastConference,
        //    WestConference,
        //    Leauge,
        //    AllTeams
        //}

        private static int gameModeSelected;

        internal static int GameModeSelected
        {
            get { return gameModeSelected; }
            set { gameModeSelected = value; }
        }

        internal static ImageNameDatabase ImageNameDatabase
        {
            get
            {
                ImageNameDatabase imageNameDatabase = new ImageNameDatabase();
                imageNameDatabase.LoadList(Path + "\\" + gameMode[gameModeSelected].PictureFileText);
                return imageNameDatabase;
            }
        }

        internal static string BackOfCardImageLocation
        {
            get
            {
                return Path + "\\image\\" + gameMode[gameModeSelected].BackOfCardImageLocation;
            }
        }

        internal const string LOGO_MESSAGE =
            "Created by Brian Chaves \r\n" +
            "August 2013 \r\n" +
            "NHL Matching Game\r\n"+
            "Version 1.0";

        internal const int CARD_SHUFFLE_COUNT = 5;

        //internal const int HIGH_SCORE_COUNT = 30;

        private static HighScore[] highScore;

        public static HighScore[] HighScore
        {
            get { return highScore; }
            set { highScore = value; }
        }

        internal static HighScore GameHighScore
        {
            get
            {
                return HighScore[gameMode[gameModeSelected].HighScoreID];
            }
        }

        internal static string GameModeName(int gameModeID)
        {
            try
            {
                return gameMode[gameModeID].Name;
            }
            catch
            {
                return "N/A";
            }
        }

        internal static string GameModeName()
        {
            return GameModeName(gameModeSelected);
        }

        internal static void ResetHighScore()
        {
            for (int x = 0; x < highScore.Length; x++)
            {
                highScore[x].ResetScore();
            }
        }
    }
}
