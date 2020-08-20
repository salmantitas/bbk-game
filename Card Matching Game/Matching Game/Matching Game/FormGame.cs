/*
 * Briasn Chaves
 * July 2013
 * Matching Game
 * Game form
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BC_Functions;
using MatchingGameFrameworks;

namespace Matching_Game
{
    public partial class FormGame : Form
    {
        const int BOX_SIZE = 100;
        const int MARGIN = 5;
        const int TOP_SPACE = 20;
        const int LEFT_SPACE = 20;
        const int BOTTOM_SPACE = 50;
        const int RIGHT_SPACE = 50;
        const int txtStatus_WIDTH = 200;
        const int txtStatus_HIGHT = 250;
        const int BUTTON_WIDTH = 75;
        const int BUTTON_HEIGHT = 25;
        const int SHOW_CARD_TIMER = 60 * 2;

        PictureBox[,] picCard;
        Game game;
        ScoreRule scoreRule;
        int showCardTimer;
        bool timerStarted;
        bool gameComplete;

        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            CreateGame();
        }

        public void CreateGame()
        {
            txtStatus.Size = new Size(txtStatus_WIDTH, txtStatus_HIGHT);
            txtStatus.Left = LEFT_SPACE + (BOX_SIZE + MARGIN) * Shared.ColumnCount + MARGIN;
            txtStatus.Top = TOP_SPACE;
            game = new Game(Shared.ColumnCount, Shared.RowCount);
            game.Shuffle(Shared.CARD_SHUFFLE_COUNT);
            timerStarted = false;

            btnQuit.Left = txtStatus.Left;
            btnRefresh.Left = txtStatus.Left;
            btnReset.Left = txtStatus.Left;

            scoreRule = new ScoreRule(Shared.StartingPoints, Shared.MatchPoints, Shared.MisMatchPenalty, Shared.TimePenalty);
            game.Player = new MatchingGamePlayerScore(scoreRule);

            picCard = new PictureBox[Shared.ColumnCount, Shared.RowCount];

            for (int x = 0; x < Shared.ColumnCount; x++)
            {
                for (int y = 0; y < Shared.RowCount; y++)
                {
                    picCard[x, y] = new PictureBox();
                    picCard[x, y].Left = LEFT_SPACE + (BOX_SIZE + MARGIN) * x;
                    picCard[x, y].Top = TOP_SPACE + (BOX_SIZE + MARGIN) * y;
                    picCard[x, y].Width = BOX_SIZE;
                    picCard[x, y].Height = BOX_SIZE;
                    picCard[x, y].SizeMode = PictureBoxSizeMode.Zoom;
                    picCard[x, y].BackColor = Color.White;


                    this.Controls.Add(picCard[x, y]);
                    picCard[x, y].Click += new EventHandler(picCard_Click);
                }

            }
            game.SetImage(Shared.Path + "\\image", Shared.ImageNameDatabase);

            this.Height = TOP_SPACE + (BOX_SIZE + MARGIN) * Shared.RowCount + BOTTOM_SPACE;
            this.Width = LEFT_SPACE + (BOX_SIZE + MARGIN) * Shared.ColumnCount + MARGIN + txtStatus_WIDTH + RIGHT_SPACE;
            this.CenterToScreen();

            picLogo.Left = this.Width - picLogo.Width - RIGHT_SPACE;
            picLogo.Top = this.Height - picLogo.Height - BOTTOM_SPACE;

            gameComplete = false;
            game.BackOfCardImageLocation = Shared.BackOfCardImageLocation;
            UpdateGame();
        }
        public void picCard_Click(object sender, EventArgs e)
        {
            int X = 0;
            int Y = 0;
            FindSender(sender, out X, out Y);

            if (game.FlipedCardsCount == 2)
            {
                CheckForMatchingCards();
            }
            showCardTimer = SHOW_CARD_TIMER;
            game.Cards[X, Y].Flipped = true;
            if (game.FlipedCardsMatch)
            {
                game.Player.SuccessfulMatchCount++;
            }
            else if (game.FlipedCardsCount == 2)
            {
                game.Player.MisMatchCount++;
            }
            timerStarted = true;
            UpdateGame();
        }

        public void FindSender(Object sender, out int X, out int Y)
        {
            X = -1;
            Y = -1;

            for (int x = 0; x < Shared.ColumnCount; x++)
            {
                for (int y = 0; y < Shared.RowCount; y++)
                {
                    if (sender.Equals(picCard[x, y]))
                    {
                        X = x;
                        Y = y;
                    }
                }
            }
        }

        public void UpdateGame(bool forceReloadImage = false)
        {
            for (int x = 0; x < Shared.ColumnCount; x++)
            {
                for (int y = 0; y < Shared.RowCount; y++)
                {
                    if (game.Cards[x, y].Removed)
                    {
                        picCard[x, y].Visible = false;
                    }
                    else
                    {
                        picCard[x, y].Visible = true;
                        if (picCard[x, y].ImageLocation != game.GetImage(x, y) || forceReloadImage)
                        {
                            picCard[x, y].ImageLocation = game.GetImage(x, y);
                        }
                    }
                }

            }

            txtStatus.Text = "Time : " + Time.SecondsToString(game.Player.Seconds) + "\r\n" +
                "Score :" + game.Player.Points.ToString("n0") + "\r\n" +
                "Successful Matches: " + game.Player.SuccessfulMatchCount.ToString() + "\r\n" +
                "Wrong Matches: " + game.Player.MisMatchCount.ToString();
            if (game.GameComplete)
            {
                timerStarted = false;
                if (game.CardsRemain == 0 && !gameComplete)
                {
                    GameComplete();
                }
            }
        }

        private void GameComplete()
        {
            //MessageBox.Show("Game complete");
            if (Shared.GameHighScore.MadeHighScore(game.Player))
            {
                DialogHighScore dialogHighScore = new DialogHighScore(
                    "You have made high score, enter your name");
                dialogHighScore.ShowDialog();
                if (!dialogHighScore.Canceled)
                {
                    game.Player.Name = dialogHighScore.PlayerName;
                }
                else
                {
                    game.Player.Name = "???";
                }
                Shared.GameHighScore.SetScore(game.Player, Shared.GameModeSelected);
                FormHighScore formHighScore = new FormHighScore(Shared.GameMode[Shared.GameModeSelected].HighScoreID);
                formHighScore.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have completed the game", Text);
            }
            gameComplete = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (game != null && game.FlipedCardsCount == 2)
            {
                showCardTimer--;
                if (showCardTimer <= 0)
                {
                    CheckForMatchingCards();
                }
            }
            if (timerStarted)
            {
                game.Player.Seconds += (1m / 60m);
                UpdateGame();
            }
        }

        private void CheckForMatchingCards()
        {
            if (game.FlipedCardsMatch)
            {
                game.RemoveFlipedCards();
            }
            else
            {
                game.HideAllCards();
            }
            UpdateGame();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Shared.LOGO_MESSAGE, Text);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to reset the game",
                Text, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                game.ResetGame();
                game.Player.ResetPoints();
                game.Shuffle(Shared.CARD_SHUFFLE_COUNT);
                UpdateGame();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateGame(true);
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit to menu",
                Text, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
