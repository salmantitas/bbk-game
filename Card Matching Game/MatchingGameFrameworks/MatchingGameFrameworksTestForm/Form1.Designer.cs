namespace MatchingGameFrameworksTestForm
{
    partial class TestForm
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
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.btnTestResetHighScore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDisplay.Location = new System.Drawing.Point(187, 123);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(338, 236);
            this.txtDisplay.TabIndex = 0;
            // 
            // btnTestResetHighScore
            // 
            this.btnTestResetHighScore.Location = new System.Drawing.Point(652, 402);
            this.btnTestResetHighScore.Name = "btnTestResetHighScore";
            this.btnTestResetHighScore.Size = new System.Drawing.Size(75, 34);
            this.btnTestResetHighScore.TabIndex = 1;
            this.btnTestResetHighScore.Text = "Test Reset High Score";
            this.btnTestResetHighScore.UseVisualStyleBackColor = true;
            this.btnTestResetHighScore.Click += new System.EventHandler(this.btnTestResetHighScore_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 484);
            this.Controls.Add(this.btnTestResetHighScore);
            this.Controls.Add(this.txtDisplay);
            this.Name = "TestForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.Button btnTestResetHighScore;
    }
}

