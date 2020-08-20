using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MatchingGameFrameworks;
using BC_Functions;

namespace Matching_Game
{
    public partial class FormHighScore : Form
    {
        int startingHighScoreID;
        public FormHighScore(int startingHighScoreID=0)
        {
            InitializeComponent();
            this.startingHighScoreID = startingHighScoreID;
        }

        RadioButton[] radHighScore;
        int radHighScoreTop
        {
            get
            {
                return rtxtHighScore.Top + rtxtHighScore.Height + rtxtHighScoreTOP;
            }
        }

        const int rtxtHighScoreTOP = 12;
        const int radHighScoreMARGIN = 6;
        const int BOTTOM_SPACE = 25;
        const int radHighScoreHEIGHT = 17;

        private void FormHighScore_Load(object sender, EventArgs e)
        {
            radHighScore = new RadioButton[Shared.HighScore.Length];
            for (int x = 0; x < Shared.HighScore.Length; x++)
            {
                radHighScore[x] = new RadioButton();
                radHighScore[x].Top = radHighScoreTop + (radHighScoreMARGIN + radHighScoreHEIGHT) * x;
                radHighScore[x].Left = rtxtHighScore.Left;
                radHighScore[x].Text = Shared.HighScore[x].Name;
                radHighScore[x].Click += new EventHandler(radHighScore_Click);
                radHighScore[x].Height = radHighScoreHEIGHT;

                Controls.Add(radHighScore[x]);
            }
            radHighScore[startingHighScoreID].Checked = true;
            LoadHighScore(startingHighScoreID);
        }

        private void radHighScore_Click(object sender, EventArgs e)
        {
            int highScoreID;
            highScoreID = FindSender(sender);
            LoadHighScore(highScoreID);
        }

        private void LoadHighScore(int highScoreID)
        {
            rtxtHighScore.Text = "Loading";
            string highscore;
            highscore =
                "Pos".PadRight(5) +
                "Name".PadRight(30) +
                "Score".PadRight(10) +
                "Mis match".PadRight(10) +
                "Time".PadRight(10);
            if (Shared.HighScore[highScoreID].ShowGameMode)
            {
                highscore += "Game Mode".PadRight(20);
            }
            try
            {
                for (int x = 0; x < Shared.HighScore[highScoreID].
                    PlayerHighScore.Length; x++)
                {
                    highscore += "\r\n";
                    MatchingGamePlayerHighScore player = Shared.HighScore[highScoreID].PlayerHighScore[x];
                    highscore +=
                        (x + 1).ToString().PadRight(5) +
                        player.Name.PadRight(30) +
                        player.Points.ToString("n0").PadRight(10) +
                        player.MisMatchCount.ToString("n0").PadRight(10) +
                        Time.SecondsToString(player.Seconds, 2).PadRight(10);//.ToString("n2").PadRight(10);
                    if (Shared.HighScore[highScoreID].ShowGameMode)
                    {
                        highscore += Shared.GameModeName(player.GameID).PadRight(20);
                    }
                }
                rtxtHighScore.Text = highscore;
            }
            catch (Exception exception)
            {
                rtxtHighScore.Text = "Failed to load high Score\r\n" + exception.Message;
            }
        }

        private int FindSender(object sender)
        {
            for (int x = 0; x < Shared.HighScore.Length; x++)
            {
                if (sender == radHighScore[x])
                {
                    return x;
                }
            }
            return -1;
        }

        private void btnResetScore_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset high scores",
                Text, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Shared.ResetHighScore();
            }
            for (int x = 0; x < Shared.HighScore.Length; x++)
            {
                if (radHighScore[x].Checked)
                {
                    LoadHighScore(x);
                }
            }
        }
    }
}
