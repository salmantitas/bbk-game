namespace ManualTest
{
    partial class FormColorTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scrlColorValue = new System.Windows.Forms.NumericUpDown();
            this.picColor = new System.Windows.Forms.PictureBox();
            this.grpCOlorType = new System.Windows.Forms.GroupBox();
            this.radRedGreen = new System.Windows.Forms.RadioButton();
            this.radHeatColor = new System.Windows.Forms.RadioButton();
            this.chkFastScroll = new System.Windows.Forms.CheckBox();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.radRedDarkGreen = new System.Windows.Forms.RadioButton();
            this.radBlackWhite = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.scrlColorValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).BeginInit();
            this.grpCOlorType.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrlColorValue
            // 
            this.scrlColorValue.Location = new System.Drawing.Point(13, 13);
            this.scrlColorValue.Name = "scrlColorValue";
            this.scrlColorValue.Size = new System.Drawing.Size(120, 20);
            this.scrlColorValue.TabIndex = 0;
            this.scrlColorValue.ValueChanged += new System.EventHandler(this.scrlColorValue_ValueChanged);
            // 
            // picColor
            // 
            this.picColor.BackColor = System.Drawing.Color.Black;
            this.picColor.Location = new System.Drawing.Point(13, 40);
            this.picColor.Name = "picColor";
            this.picColor.Size = new System.Drawing.Size(259, 209);
            this.picColor.TabIndex = 1;
            this.picColor.TabStop = false;
            // 
            // grpCOlorType
            // 
            this.grpCOlorType.Controls.Add(this.radBlackWhite);
            this.grpCOlorType.Controls.Add(this.radRedDarkGreen);
            this.grpCOlorType.Controls.Add(this.radRedGreen);
            this.grpCOlorType.Controls.Add(this.radHeatColor);
            this.grpCOlorType.Location = new System.Drawing.Point(300, 13);
            this.grpCOlorType.Name = "grpCOlorType";
            this.grpCOlorType.Size = new System.Drawing.Size(274, 187);
            this.grpCOlorType.TabIndex = 3;
            this.grpCOlorType.TabStop = false;
            this.grpCOlorType.Text = "Color Type";
            // 
            // radRedGreen
            // 
            this.radRedGreen.AutoSize = true;
            this.radRedGreen.Location = new System.Drawing.Point(7, 44);
            this.radRedGreen.Name = "radRedGreen";
            this.radRedGreen.Size = new System.Drawing.Size(77, 17);
            this.radRedGreen.TabIndex = 1;
            this.radRedGreen.Text = "Red-Green";
            this.radRedGreen.UseVisualStyleBackColor = true;
            this.radRedGreen.CheckedChanged += new System.EventHandler(this.radRedGreen_CheckedChanged);
            // 
            // radHeatColor
            // 
            this.radHeatColor.AutoSize = true;
            this.radHeatColor.Checked = true;
            this.radHeatColor.Location = new System.Drawing.Point(7, 20);
            this.radHeatColor.Name = "radHeatColor";
            this.radHeatColor.Size = new System.Drawing.Size(75, 17);
            this.radHeatColor.TabIndex = 0;
            this.radHeatColor.TabStop = true;
            this.radHeatColor.Text = "Heat Color";
            this.radHeatColor.UseVisualStyleBackColor = true;
            this.radHeatColor.CheckedChanged += new System.EventHandler(this.radHeatColor_CheckedChanged);
            // 
            // chkFastScroll
            // 
            this.chkFastScroll.AutoSize = true;
            this.chkFastScroll.Location = new System.Drawing.Point(140, 13);
            this.chkFastScroll.Name = "chkFastScroll";
            this.chkFastScroll.Size = new System.Drawing.Size(75, 17);
            this.chkFastScroll.TabIndex = 4;
            this.chkFastScroll.Text = "Fast Scroll";
            this.chkFastScroll.UseVisualStyleBackColor = true;
            this.chkFastScroll.CheckedChanged += new System.EventHandler(this.chkFastScroll_CheckedChanged);
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(300, 207);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(29, 13);
            this.lblErrorMessage.TabIndex = 5;
            this.lblErrorMessage.Text = "Error";
            // 
            // radRedDarkGreen
            // 
            this.radRedDarkGreen.AutoSize = true;
            this.radRedDarkGreen.Location = new System.Drawing.Point(7, 68);
            this.radRedDarkGreen.Name = "radRedDarkGreen";
            this.radRedDarkGreen.Size = new System.Drawing.Size(103, 17);
            this.radRedDarkGreen.TabIndex = 2;
            this.radRedDarkGreen.TabStop = true;
            this.radRedDarkGreen.Text = "Red-Dark Green";
            this.radRedDarkGreen.UseVisualStyleBackColor = true;
            this.radRedDarkGreen.CheckedChanged += new System.EventHandler(this.radRedDarkGreen_CheckedChanged);
            // 
            // radBlackWhite
            // 
            this.radBlackWhite.AutoSize = true;
            this.radBlackWhite.Location = new System.Drawing.Point(7, 92);
            this.radBlackWhite.Name = "radBlackWhite";
            this.radBlackWhite.Size = new System.Drawing.Size(104, 17);
            this.radBlackWhite.TabIndex = 3;
            this.radBlackWhite.TabStop = true;
            this.radBlackWhite.Text = "Black and White";
            this.radBlackWhite.UseVisualStyleBackColor = true;
            this.radBlackWhite.CheckedChanged += new System.EventHandler(this.radBlackWhite_CheckedChanged);
            // 
            // FormColorTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 255);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.chkFastScroll);
            this.Controls.Add(this.grpCOlorType);
            this.Controls.Add(this.picColor);
            this.Controls.Add(this.scrlColorValue);
            this.Name = "FormColorTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Test";
            this.Load += new System.EventHandler(this.FormColorTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scrlColorValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picColor)).EndInit();
            this.grpCOlorType.ResumeLayout(false);
            this.grpCOlorType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown scrlColorValue;
        private System.Windows.Forms.PictureBox picColor;
        private System.Windows.Forms.GroupBox grpCOlorType;
        private System.Windows.Forms.RadioButton radRedGreen;
        private System.Windows.Forms.RadioButton radHeatColor;
        private System.Windows.Forms.CheckBox chkFastScroll;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.RadioButton radRedDarkGreen;
        private System.Windows.Forms.RadioButton radBlackWhite;
    }
}