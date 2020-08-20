//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using BC_Functions;
//using MatchingGameFrameworks;
//using System.IO;

//namespace Matching_Game
//{
//    public class HighScore
//    {
//        private string fileName;

//        public string FileName
//        {
//            get { return fileName; }
//            set { fileName = value; }
//        }

//        private string name;

//        public string Name
//        {
//            get { return name; }
//            set { name = value; }
//        }

//        private bool showGameMode;

//        public bool ShowGameMode
//        {
//            get { return showGameMode; }
//            set { showGameMode = value; }
//        }

//        private MatchingGamePlayerHighScore[] playerHighScore;

//        internal MatchingGamePlayerHighScore[] PlayerHighScore
//        {
//            get { return playerHighScore; }
//            set { playerHighScore = value; }
//        }

//        public HighScore(string fileName)
//        {
//            this.fileName = fileName;
//            playerHighScore = new MatchingGamePlayerHighScore[Shared.HIGH_SCORE_COUNT];
//        }

//        public HighScore(string name, string fileName)
//        {
//            this.name = name;
//            this.fileName = fileName;
//        }

//        public void LoadHighScore()
//        {
//            StreamReader reader = new StreamReader(fileName);
//            try
//            {
//                for (int x = 0; x < Shared.HIGH_SCORE_COUNT; x++)
//                {
//                    playerHighScore[x] = new MatchingGamePlayerHighScore();
//                    playerHighScore[x].Name = reader.ReadLine();
//                    playerHighScore[x].MisMatchCount = int.Parse(reader.ReadLine());
//                    playerHighScore[x].Seconds = decimal.Parse(reader.ReadLine());
//                    playerHighScore[x].Points = int.Parse(reader.ReadLine());
//                }
//            }
//            catch(Exception exception)
//            {
//                throw exception;
//            }
//            finally
//            {
//                reader.Close();
//            }
//        }

//        public bool MadeHighScore(MatchingGamePlayerScore player)
//        {
//            return MadeHighScore(player.Points);
//        }

//        public bool MadeHighScore(int score)
//        {
//            try
//            {
//                if (playerHighScore == null)
//                {
//                    LoadHighScore();
//                }

//                return (score > playerHighScore[Shared.HIGH_SCORE_COUNT - 1].Points);
//            }
//            catch
//            {
//                return false;
//            }

//        }

//        public void SetScore(MatchingGamePlayerScore player)
//        {
//            StreamWriter writer=new StreamWriter(fileName);
//            try
//            {
//                if(!MadeHighScore(player))
//                {
//                    throw new Exception("Did not make highScore");
//                }
//                int position = Shared.HIGH_SCORE_COUNT - 1;
//                while (player.Points > playerHighScore[position].Points && position > 0)
//                {
//                    position--;
//                }

//                if (player.Points < playerHighScore[0].Points)
//                {
//                    position++;
//                }

//                if (position < Shared.HIGH_SCORE_COUNT)
//                {
//                    HighScore newHighScore = new HighScore(name, fileName);
//                    for (int x = 0; x < Shared.HIGH_SCORE_COUNT; x++)
//                    {
//                        if (position > x)
//                        {
//                            newHighScore.PlayerHighScore[x] = this.PlayerHighScore[x];
//                        }
//                        else if (position == x)
//                        {
//                            newHighScore.playerHighScore[x] = new MatchingGamePlayerHighScore(player);
//                        }
//                        else
//                        {
//                            newHighScore.playerHighScore[x] = this.playerHighScore[x - 1];
//                        }
//                    }
//                }

//                for (int x = 0; x < Shared.HIGH_SCORE_COUNT; x++)
//                {
//                    writer.WriteLine(playerHighScore[x]);
//                    writer.WriteLine(playerHighScore[x].Name);
//                    writer.WriteLine(playerHighScore[x].MisMatchCount);
//                    writer.WriteLine(playerHighScore[x].Seconds);
//                    writer.WriteLine(playerHighScore[x].Points);
//                }
//            }
//            catch(Exception exception)
//            {
//                throw exception;
//            }
//            finally
//            {
//                writer.Close();
//            }
//        }

//    }
//}
