using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BC_Functions;
using System.IO;
using MatchingGameFrameworks.Exceptions;

namespace MatchingGameFrameworks
{
    public class HighScore
    {
        private const int DEFAULT_HIGH_SCORE_COUNT = 30;

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int highScoreCount;

        public int HighScoreCount
        {
            get { return highScoreCount; }
            set
            {
                highScoreCount = value;
                playerHighScore = new MatchingGamePlayerHighScore[highScoreCount];
            }
        }

        private bool showGameMode;

        public bool ShowGameMode
        {
            get { return showGameMode; }
            set { showGameMode = value; }
        }

        private MatchingGamePlayerHighScore[] playerHighScore;

        public MatchingGamePlayerHighScore[] PlayerHighScore
        {
            get
            {
                //LoadHighScore();
                return playerHighScore;
            }
            set { playerHighScore = value; }
        }

        public HighScore(string fileName, int highScoreCount = DEFAULT_HIGH_SCORE_COUNT)
        {
            this.fileName = fileName;
            this.highScoreCount = highScoreCount;
            playerHighScore = new MatchingGamePlayerHighScore[highScoreCount];
            showGameMode = false;
        }

        public HighScore(string name, string fileName, int highScoreCount = DEFAULT_HIGH_SCORE_COUNT)
            : this(fileName, highScoreCount)
        {
            this.name = name;
            //this.fileName = fileName;
            //this.highScoreCount = highScoreCount;
            //playerHighScore = new MatchingGamePlayerHighScore[highScoreCount];
        }

        public void LoadHighScore(bool forceLoad = false)
        {
            if (playerHighScore == null || playerHighScore[0] == null || forceLoad)
            {
                StreamReader reader = null;
                try
                {
                    reader = new StreamReader(fileName);
                    playerHighScore = new MatchingGamePlayerHighScore[highScoreCount];
                    for (int x = 0; x < highScoreCount; x++)
                    {
                        playerHighScore[x] = new MatchingGamePlayerHighScore();
                        playerHighScore[x].Name = reader.ReadLine();
                        playerHighScore[x].MisMatchCount = int.Parse(reader.ReadLine());
                        playerHighScore[x].Seconds = decimal.Parse(reader.ReadLine());
                        playerHighScore[x].Points = int.Parse(reader.ReadLine());
                        playerHighScore[x].GameID = sbyte.Parse(reader.ReadLine());
                    }
                }
                catch (Exception exception)
                {
                    //throw new FailToLoadException(exception);
                    throw exception;
                }
                finally
                {
                    reader.Close();
                }
            }
        }

        public bool MadeHighScore(MatchingGamePlayerScore player)
        {
            return MadeHighScore(player.Points);
        }

        public bool MadeHighScore(int score)
        {
            try
            {
                LoadHighScore();
                return (score > playerHighScore[highScoreCount - 1].Points);
            }
            catch
            {
                return false;
            }

        }

        public int HighScorePosition(int score)
        {
            throw new NotImplementedException();
        }

        public int HighScorePosition(MatchingGamePlayerScore player)
        {
            return HighScorePosition(player.Points);
        }

        public void SetScore(MatchingGamePlayerScore player, int gameModeID = -1)
        {
            StreamWriter writer = new StreamWriter(fileName);
            try
            {
                LoadHighScore();
                if (!MadeHighScore(player))
                {
                    throw new NoHighScoreException();
                }

                int position = highScoreCount - 1;
                while (player.Points > playerHighScore[position].Points && position > 0)
                {
                    position--;
                }

                if (player.Points < playerHighScore[0].Points)
                {
                    position++;
                }

                if (position < highScoreCount)
                {
                    HighScore newHighScore = new HighScore(name, fileName);
                    for (int x = 0; x < highScoreCount; x++)
                    {
                        if (position > x)
                        {
                            newHighScore.PlayerHighScore[x] = this.PlayerHighScore[x];
                        }
                        else if (position == x)
                        {
                            newHighScore.playerHighScore[x] = new MatchingGamePlayerHighScore(player);
                            newHighScore.playerHighScore[x].GameID = gameModeID;
                        }
                        else
                        {
                            newHighScore.playerHighScore[x] = this.playerHighScore[x - 1];
                        }
                    }

                    for (int x = 0; x < highScoreCount; x++)
                    {
                        this.playerHighScore[x] = newHighScore.playerHighScore[x];
                    }
                }

                for (int x = 0; x < highScoreCount; x++)
                {
                    writer.WriteLine(playerHighScore[x].Name);
                    writer.WriteLine(playerHighScore[x].MisMatchCount);
                    writer.WriteLine(playerHighScore[x].Seconds);
                    writer.WriteLine(playerHighScore[x].Points);
                    writer.WriteLine(playerHighScore[x].GameID);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                writer.Close();
            }
        }

        public void ResetScore()
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName);
                for (int x = 0; x < highScoreCount; x++)
                {
                    writer.WriteLine("???");
                    writer.WriteLine(1024);
                    writer.WriteLine(60 * 60);
                    writer.WriteLine(highScoreCount - x);
                    writer.WriteLine(-1);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                writer.Close();
                LoadHighScore(true);
            }
        }

    }
}
