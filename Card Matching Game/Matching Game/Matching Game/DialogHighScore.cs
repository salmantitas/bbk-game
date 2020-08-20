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
    public partial class DialogHighScore : Form
    {
        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                lblMessage.Text = message;
            }
        }

        private string playerName;

        public string PlayerName
        {
            get
            {
                if (canceled)
                {
                    return "";
                }
                else
                {
                    return playerName;
                }
            }
        }

        private bool canceled;

        public bool Canceled
        {
            get { return canceled; }
        }


        public DialogHighScore(string message)
        {
            InitializeComponent();

            this.message = message;
            lblMessage.Text = message;
            playerName = "";
            canceled = false;
        }


        private void DialogHighScore_Load(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            playerName = txtPlayerName.Text;
            Close();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            canceled = true;
            Close();
        }
    }
}
