using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BC_Functions;

namespace ManualTest
{
    public partial class FormColorTest : Form
    {
        const int FAST_SCROLL_VALUE=10;
        const int SLOW_SCROOL_VALUE=1;

        public FormColorTest()
        {
            InitializeComponent();
        }

        private void scrlColorValue_ValueChanged(object sender, EventArgs e)
        {
            ChangeColor();
        }
            
        private void ChangeColor()
        {
            if(chkFastScroll.Checked)
            {
                scrlColorValue.Increment = FAST_SCROLL_VALUE;
            }
            else
            {
                scrlColorValue.Increment = SLOW_SCROOL_VALUE;
            }

            try
            {
                if (radHeatColor.Checked)
                {
                    picColor.BackColor = ColorClass.HeatColor(scrlColorValue.Value);
                }
                else if (radRedGreen.Checked)
                {
                    picColor.BackColor = ColorClass.RedGreen(scrlColorValue.Value);
                }
                else if(radRedDarkGreen.Checked)
                {
                    picColor.BackColor = ColorClass.RedDarkGreen(scrlColorValue.Value);
                }
                else if (radBlackWhite.Checked)
                {
                    picColor.BackColor = ColorClass.BlackWhite(scrlColorValue.Value);
                }
                else
                {
                    throw new Exception("No color mode selected");
                }
                lblErrorMessage.Text = "";
            }
            catch(Exception ex)
            {
                picColor.BackColor = Color.Black;
                lblErrorMessage.Text = "Falid  to load color \r\n"+
                    ex.Message;
            }
        }

        private void FormColorTest_Load(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void radHeatColor_CheckedChanged(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void radRedGreen_CheckedChanged(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void chkFastScroll_CheckedChanged(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void radRedDarkGreen_CheckedChanged(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void radBlackWhite_CheckedChanged(object sender, EventArgs e)
        {
            ChangeColor();
        }
        
    }
}
