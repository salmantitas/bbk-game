namespace Matching_Game
{
    partial class FormHighScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHighScore));
            this.rtxtHighScore = new System.Windows.Forms.RichTextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnResetScore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtxtHighScore
            // 
            this.rtxtHighScore.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtHighScore.Location = new System.Drawing.Point(35, 29);
            this.rtxtHighScore.Name = "rtxtHighScore";
            this.rtxtHighScore.ReadOnly = true;
            this.rtxtHighScore.Size = new System.Drawing.Size(618, 460);
            this.rtxtHighScore.TabIndex = 0;
            this.rtxtHighScore.Text = "";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(35, 495);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            // 
            // btnResetScore
            // 
            this.btnResetScore.Location = new System.Drawing.Point(174, 495);
            this.btnResetScore.Name = "btnResetScore";
            this.btnResetScore.Size = new System.Drawing.Size(75, 23);
            this.btnResetScore.TabIndex = 2;
            this.btnResetScore.Text = "Reset Score";
            this.btnResetScore.UseVisualStyleBackColor = true;
            this.btnResetScore.Click += new System.EventHandler(this.btnResetScore_Click);
            // 
            // FormHighScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 582);
            this.Controls.Add(this.btnResetScore);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rtxtHighScore);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHighScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHL Matching Game - High Scores";
            this.Load += new System.EventHandler(this.FormHighScore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtHighScore;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnResetScore;
    }
}