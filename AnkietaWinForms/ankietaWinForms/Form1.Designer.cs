namespace ankietaWinForms
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelQuestion = new System.Windows.Forms.Label();
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.labelAnswer = new System.Windows.Forms.Label();
            this.colorTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerBack = new System.Windows.Forms.Timer(this.components);
            this.buttonChoice2 = new System.Windows.Forms.Button();
            this.buttonChoice1 = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.escToQuit = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("ISOCTEUR", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelQuestion.Location = new System.Drawing.Point(105, 72);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(1073, 54);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Did you eat breakfast this morning?";
            // 
            // buttonYes
            // 
            this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYes.Font = new System.Drawing.Font("Lato", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonYes.Location = new System.Drawing.Point(174, 182);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(600, 240);
            this.buttonYes.TabIndex = 1;
            this.buttonYes.TabStop = false;
            this.buttonYes.Text = "YES";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.anyButton_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNo.Font = new System.Drawing.Font("Lato", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNo.Location = new System.Drawing.Point(524, 182);
            this.buttonNo.MinimumSize = new System.Drawing.Size(1, 1);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(600, 240);
            this.buttonNo.TabIndex = 2;
            this.buttonNo.TabStop = false;
            this.buttonNo.Text = "NO";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.anyButton_Click);
            // 
            // labelAnswer
            // 
            this.labelAnswer.AutoSize = true;
            this.labelAnswer.Font = new System.Drawing.Font("ISOCTEUR", 25.8F);
            this.labelAnswer.Location = new System.Drawing.Point(6, 110);
            this.labelAnswer.Name = "labelAnswer";
            this.labelAnswer.Size = new System.Drawing.Size(713, 54);
            this.labelAnswer.TabIndex = 3;
            this.labelAnswer.Text = "The result is: You are ";
            // 
            // colorTimer
            // 
            this.colorTimer.Enabled = true;
            this.colorTimer.Tick += new System.EventHandler(this.colorTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerBack
            // 
            this.timerBack.Interval = 1;
            this.timerBack.Tick += new System.EventHandler(this.timerBack_Tick);
            // 
            // buttonChoice2
            // 
            this.buttonChoice2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChoice2.Font = new System.Drawing.Font("Lato", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonChoice2.Location = new System.Drawing.Point(524, 447);
            this.buttonChoice2.MinimumSize = new System.Drawing.Size(4, 4);
            this.buttonChoice2.Name = "buttonChoice2";
            this.buttonChoice2.Size = new System.Drawing.Size(600, 240);
            this.buttonChoice2.TabIndex = 6;
            this.buttonChoice2.TabStop = false;
            this.buttonChoice2.Text = "GOOD";
            this.buttonChoice2.UseVisualStyleBackColor = true;
            this.buttonChoice2.Visible = false;
            this.buttonChoice2.Click += new System.EventHandler(this.anyButton_Click);
            // 
            // buttonChoice1
            // 
            this.buttonChoice1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChoice1.Font = new System.Drawing.Font("Lato", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonChoice1.Location = new System.Drawing.Point(174, 447);
            this.buttonChoice1.MinimumSize = new System.Drawing.Size(2, 2);
            this.buttonChoice1.Name = "buttonChoice1";
            this.buttonChoice1.Size = new System.Drawing.Size(600, 240);
            this.buttonChoice1.TabIndex = 5;
            this.buttonChoice1.TabStop = false;
            this.buttonChoice1.Text = "BAD";
            this.buttonChoice1.UseVisualStyleBackColor = true;
            this.buttonChoice1.Visible = false;
            this.buttonChoice1.Click += new System.EventHandler(this.anyButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Enabled = false;
            this.pictureBox.Location = new System.Drawing.Point(645, -7);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1300, 100);
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // escToQuit
            // 
            this.escToQuit.AutoSize = true;
            this.escToQuit.Location = new System.Drawing.Point(2, 2);
            this.escToQuit.Name = "escToQuit";
            this.escToQuit.Size = new System.Drawing.Size(78, 17);
            this.escToQuit.TabIndex = 8;
            this.escToQuit.Text = "ESC to quit";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1060, 519);
            this.Controls.Add(this.escToQuit);
            this.Controls.Add(this.labelAnswer);
            this.Controls.Add(this.buttonChoice2);
            this.Controls.Add(this.buttonChoice1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.labelQuestion);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Miernik nastroju";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Label labelAnswer;
        private System.Windows.Forms.Timer colorTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer timerBack;
        private System.Windows.Forms.Button buttonChoice2;
        private System.Windows.Forms.Button buttonChoice1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label escToQuit;
    }
}

