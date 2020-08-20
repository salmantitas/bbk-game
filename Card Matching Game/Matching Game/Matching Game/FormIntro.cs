using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Matching_Game
{
    public partial class FormIntro : Form
    {
        RadioButton[] radGameMode;

        public FormIntro()
        {
            InitializeComponent();
        }

        private void lblStartGame_Click(object sender, EventArgs e)
        {
            if (GameModeSeleted())
            {
                FormGame formGame = new FormGame();
                this.Hide();
                formGame.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Select game mode", Text);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormIntro_Load(object sender, EventArgs e)
        {
            StartUp.Run();
            radGameMode=new RadioButton[4];
            lblMessage.Text = StartUp.ErrorMessage;

            const int radGameMode_LEFT=7;
            const int radGameMode_STARTING_TOP=20;
            const int radGameMode_INCREMENT =22;

            for(int x=0;x<4;x++)
            {
                radGameMode[x] = new RadioButton();
                radGameMode[x].Text = Shared.GameMode[x].Name;
                radGameMode[x].Left = radGameMode_LEFT;
                radGameMode[x].Top = radGameMode_STARTING_TOP + radGameMode_INCREMENT * x;
                radGameMode[x].Width = 150;
                grpOption.Controls.Add(radGameMode[x]);
            }
        }

        private bool GameModeSeleted()
        {
            int gameModeSelected=-1;
            for (int x = 0; x < 4; x++)
            {
                if (radGameMode[x].Checked)
                {
                    gameModeSelected = x;
                }
            }
            if (gameModeSelected != -1)
            {
                Shared.GameModeSelected = gameModeSelected;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Shared.LOGO_MESSAGE, Text);
        }

        private void lblHighScore_Click(object sender, EventArgs e)
        {
            FormHighScore formHighScore;
            if (GameModeSeleted())
            {
                formHighScore = new FormHighScore(Shared.GameMode[Shared.GameModeSelected].HighScoreID);
            }
            else
            {
                formHighScore = new FormHighScore();
            }

            this.Hide();
            formHighScore.ShowDialog();
            this.Show();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }
    }
}
