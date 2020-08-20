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

namespace MatchingGameFrameworksTestForm
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            Game game = new Game(6, 5);
            //game.Shuffle();
            for (int y = 0;y < game.CardSize.Y; y++)
            {
                for (int x = 0;x< game.CardSize.X; x++)
                {
                    txtDisplay.Text += game.Cards[x, y].ID + " ";
                }
                txtDisplay.Text += "\r\n";
            }
        }

        private void btnTestResetHighScore_Click(object sender, EventArgs e)
        {
            HighScore highScore = new HighScore("C:\\Test\\Matching Game High Score Test.txt");
            highScore.ResetScore();
        }
    }
}
