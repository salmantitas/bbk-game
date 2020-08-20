using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using MatchingGameFrameworks;
using System.IO;

namespace Matching_Game
{
    internal static class StartUp
    {
        internal static void Run()
        {
            errorMessage = "";
            Shared.GameModeSelected = 0;
            SetUpScoreRules();
            SetUpHighScore();
            SetUpGameMode();
        }

        private static void SetUpScoreRules()
        {
            //Shared.ScoreRule = new ScoreRule[3];
            //Shared.ScoreRule[0] = new ScoreRule(500, 1000, 50, 3.5m);
            //Shared.ScoreRule[1] = new ScoreRule(1000, 600, 15, 1.3m);
            //Shared.ScoreRule[2] = new ScoreRule(1000, 500, 12, 1.15m); 

            List<ScoreRule> scoreRule = new List<ScoreRule>();
            //scoreRule = new List<ScoreRule>();
            scoreRule.Add(new ScoreRule(500, 1000, 50, 3.5m));
            scoreRule.Add( new ScoreRule(1000, 600, 15, 1.3m));
            scoreRule.Add( new ScoreRule(1000, 500, 12, 1.15m));

            Shared.ScoreRule = scoreRule.ToArray();
        }

        private static void SetUpHighScore()
        {
            //Shared.HighScore = new HighScore[3];
            //Shared.HighScore[0] = new HighScore("Conference", Shared.Path + "\\Conference High Score");
            //Shared.HighScore[0].ShowGameMode = true;
            //Shared.HighScore[1] = new HighScore("Leauge", Shared.Path + "\\Leauge High Score", 15);
            //Shared.HighScore[2] = new HighScore("Extra Cards", Shared.Path + "\\Extra Cards High Score", 10);

            List<HighScore> highScore = new List<HighScore>();
            highScore.Add( new HighScore("Conference", Shared.Path + "\\Conference High Score"));
            highScore[highScore.Count-1].ShowGameMode = true;
            highScore.Add( new HighScore("Leauge", Shared.Path + "\\Leauge High Score", 15));
            highScore.Add( new HighScore("Extra Cards", Shared.Path + "\\Extra Cards High Score", 10));

            Shared.HighScore = highScore.ToArray();

            for (int x = 0; x < Shared.HighScore.Length; x++)
            {
                if (File.Exists(Shared.HighScore[x].FileName))
                {
                    try
                    {
                        Shared.HighScore[x].LoadHighScore(true);
                    }
                    catch (Exception exception)
                    {
                        errorMessage += "Failed to load high score for " + Shared.HighScore[x].Name + "\r\n" + exception.Message + "\r\n";
                    }
                }
                else
                {
                    Shared.HighScore[x].ResetScore();
                }
            }
        }

        private static void SetUpGameMode()
        {
            //Shared.GameMode = new GameMode[4];
            //Shared.GameMode[0] = new GameMode(1, "East Conference", "East Conference.txt", Shared.ScoreRule[0], new Position2D(6, 5), "EAST.jpg", 0);
            //Shared.GameMode[1] = new GameMode(2, "West Conference", "West Conference.txt", Shared.ScoreRule[0], new Position2D(6, 5), "WEST.jpg", 0);
            //Shared.GameMode[2] = new GameMode(3, "Leauge", "Leauge.txt", Shared.ScoreRule[1], new Position2D(10, 6), "NHL_logo.jpg", 1);
            //Shared.GameMode[3] = new GameMode(4, "Extra Cards", "All Teams.txt", Shared.ScoreRule[2], new Position2D(12, 7), "NHL_logo.jpg", 2);

            List<GameMode> gameMode = new List<GameMode> ();
            gameMode.Add( new GameMode(1, "East Conference", "East Conference.txt", Shared.ScoreRule[0], new Position2D(6, 5), "EAST.jpg", 0));
            gameMode.Add( new GameMode(2, "West Conference", "West Conference.txt", Shared.ScoreRule[0], new Position2D(6, 5), "WEST.jpg", 0));
            gameMode.Add( new GameMode(3, "Leauge", "Leauge.txt", Shared.ScoreRule[1], new Position2D(10, 6), "NHL_logo.jpg", 1));
            gameMode.Add( new GameMode(4, "Extra Cards", "All Teams.txt", Shared.ScoreRule[2], new Position2D(12, 7), "NHL_logo.jpg", 2));

            Shared.GameMode = gameMode.ToArray();
        }

        private static string errorMessage;

        internal static string ErrorMessage
        {
            get { return errorMessage; }
        }
    }
}
