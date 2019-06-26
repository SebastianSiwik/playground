namespace BitmapApplication
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hueLabel = new System.Windows.Forms.Label();
            this.hueTrackBar = new System.Windows.Forms.TrackBar();
            this.hueNumber = new System.Windows.Forms.Label();
            this.thresholdingLabel = new System.Windows.Forms.Label();
            this.thresholdingTrackBar = new System.Windows.Forms.TrackBar();
            this.thresholdingNumber = new System.Windows.Forms.Label();
            this.edgeDetectionButton = new System.Windows.Forms.Button();
            this.sharpenLabel = new System.Windows.Forms.Label();
            this.sharpenTrackBar = new System.Windows.Forms.TrackBar();
            this.sharpenNumber = new System.Windows.Forms.Label();
            this.blurLabel = new System.Windows.Forms.Label();
            this.blurTrackBar = new System.Windows.Forms.TrackBar();
            this.blurNumber = new System.Windows.Forms.Label();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.brightnessTrackBar = new System.Windows.Forms.TrackBar();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.brightnessNumber = new System.Windows.Forms.Label();
            this.contrastNumber = new System.Windows.Forms.Label();
            this.negativeButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.saturationLabel = new System.Windows.Forms.Label();
            this.saturationTrackBar = new System.Windows.Forms.TrackBar();
            this.saturationNumber = new System.Windows.Forms.Label();
            this.histogramButton = new System.Windows.Forms.Button();
            this.histogramPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdingTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharpenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "JPEG File|*.jpg|GIF File|*.gif|PNG File|*.png|BMP File|*.bmp";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "JPEG File|*.jpg|GIF File|*.gif|PNG File|*.png|BMP File|*.bmp";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.mainPictureBox);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 345);
            this.panel1.TabIndex = 0;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Location = new System.Drawing.Point(3, 3);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(100, 50);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.histogramPictureBox);
            this.panel2.Controls.Add(this.histogramButton);
            this.panel2.Controls.Add(this.saturationLabel);
            this.panel2.Controls.Add(this.saturationTrackBar);
            this.panel2.Controls.Add(this.saturationNumber);
            this.panel2.Controls.Add(this.hueLabel);
            this.panel2.Controls.Add(this.hueTrackBar);
            this.panel2.Controls.Add(this.hueNumber);
            this.panel2.Controls.Add(this.thresholdingLabel);
            this.panel2.Controls.Add(this.thresholdingTrackBar);
            this.panel2.Controls.Add(this.thresholdingNumber);
            this.panel2.Controls.Add(this.edgeDetectionButton);
            this.panel2.Controls.Add(this.sharpenLabel);
            this.panel2.Controls.Add(this.sharpenTrackBar);
            this.panel2.Controls.Add(this.sharpenNumber);
            this.panel2.Controls.Add(this.blurLabel);
            this.panel2.Controls.Add(this.blurTrackBar);
            this.panel2.Controls.Add(this.blurNumber);
            this.panel2.Controls.Add(this.brightnessLabel);
            this.panel2.Controls.Add(this.contrastLabel);
            this.panel2.Controls.Add(this.brightnessTrackBar);
            this.panel2.Controls.Add(this.contrastTrackBar);
            this.panel2.Controls.Add(this.brightnessNumber);
            this.panel2.Controls.Add(this.contrastNumber);
            this.panel2.Controls.Add(this.negativeButton);
            this.panel2.Location = new System.Drawing.Point(427, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(421, 423);
            this.panel2.TabIndex = 1;
            // 
            // hueLabel
            // 
            this.hueLabel.AutoSize = true;
            this.hueLabel.Location = new System.Drawing.Point(74, 311);
            this.hueLabel.Name = "hueLabel";
            this.hueLabel.Size = new System.Drawing.Size(34, 17);
            this.hueLabel.TabIndex = 18;
            this.hueLabel.Text = "Hue";
            // 
            // hueTrackBar
            // 
            this.hueTrackBar.Enabled = false;
            this.hueTrackBar.LargeChange = 1;
            this.hueTrackBar.Location = new System.Drawing.Point(4, 330);
            this.hueTrackBar.Maximum = 360;
            this.hueTrackBar.Name = "hueTrackBar";
            this.hueTrackBar.Size = new System.Drawing.Size(168, 56);
            this.hueTrackBar.TabIndex = 17;
            this.hueTrackBar.Scroll += new System.EventHandler(this.HueTrackBar_Scroll);
            // 
            // hueNumber
            // 
            this.hueNumber.AutoSize = true;
            this.hueNumber.Location = new System.Drawing.Point(178, 330);
            this.hueNumber.Name = "hueNumber";
            this.hueNumber.Size = new System.Drawing.Size(16, 17);
            this.hueNumber.TabIndex = 19;
            this.hueNumber.Text = "0";
            // 
            // thresholdingLabel
            // 
            this.thresholdingLabel.AutoSize = true;
            this.thresholdingLabel.Location = new System.Drawing.Point(50, 248);
            this.thresholdingLabel.Name = "thresholdingLabel";
            this.thresholdingLabel.Size = new System.Drawing.Size(91, 17);
            this.thresholdingLabel.TabIndex = 15;
            this.thresholdingLabel.Text = "Thresholding";
            // 
            // thresholdingTrackBar
            // 
            this.thresholdingTrackBar.Enabled = false;
            this.thresholdingTrackBar.LargeChange = 1;
            this.thresholdingTrackBar.Location = new System.Drawing.Point(4, 268);
            this.thresholdingTrackBar.Maximum = 255;
            this.thresholdingTrackBar.Name = "thresholdingTrackBar";
            this.thresholdingTrackBar.Size = new System.Drawing.Size(168, 56);
            this.thresholdingTrackBar.TabIndex = 14;
            this.thresholdingTrackBar.Scroll += new System.EventHandler(this.ThresholdingTrackBar_Scroll);
            // 
            // thresholdingNumber
            // 
            this.thresholdingNumber.AutoSize = true;
            this.thresholdingNumber.Location = new System.Drawing.Point(178, 268);
            this.thresholdingNumber.Name = "thresholdingNumber";
            this.thresholdingNumber.Size = new System.Drawing.Size(16, 17);
            this.thresholdingNumber.TabIndex = 16;
            this.thresholdingNumber.Text = "0";
            // 
            // edgeDetectionButton
            // 
            this.edgeDetectionButton.Enabled = false;
            this.edgeDetectionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.edgeDetectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.edgeDetectionButton.Location = new System.Drawing.Point(251, 38);
            this.edgeDetectionButton.Name = "edgeDetectionButton";
            this.edgeDetectionButton.Size = new System.Drawing.Size(126, 30);
            this.edgeDetectionButton.TabIndex = 13;
            this.edgeDetectionButton.Text = "Edge detection";
            this.edgeDetectionButton.UseVisualStyleBackColor = true;
            this.edgeDetectionButton.Click += new System.EventHandler(this.EdgeDetectionButton_Click);
            // 
            // sharpenLabel
            // 
            this.sharpenLabel.AutoSize = true;
            this.sharpenLabel.Location = new System.Drawing.Point(64, 186);
            this.sharpenLabel.Name = "sharpenLabel";
            this.sharpenLabel.Size = new System.Drawing.Size(62, 17);
            this.sharpenLabel.TabIndex = 11;
            this.sharpenLabel.Text = "Sharpen";
            // 
            // sharpenTrackBar
            // 
            this.sharpenTrackBar.Enabled = false;
            this.sharpenTrackBar.LargeChange = 1;
            this.sharpenTrackBar.Location = new System.Drawing.Point(4, 206);
            this.sharpenTrackBar.Name = "sharpenTrackBar";
            this.sharpenTrackBar.Size = new System.Drawing.Size(168, 56);
            this.sharpenTrackBar.TabIndex = 10;
            this.sharpenTrackBar.Scroll += new System.EventHandler(this.SharpenTrackBar_Scroll);
            // 
            // sharpenNumber
            // 
            this.sharpenNumber.AutoSize = true;
            this.sharpenNumber.Location = new System.Drawing.Point(178, 206);
            this.sharpenNumber.Name = "sharpenNumber";
            this.sharpenNumber.Size = new System.Drawing.Size(16, 17);
            this.sharpenNumber.TabIndex = 12;
            this.sharpenNumber.Text = "0";
            // 
            // blurLabel
            // 
            this.blurLabel.AutoSize = true;
            this.blurLabel.Location = new System.Drawing.Point(69, 124);
            this.blurLabel.Name = "blurLabel";
            this.blurLabel.Size = new System.Drawing.Size(33, 17);
            this.blurLabel.TabIndex = 8;
            this.blurLabel.Text = "Blur";
            // 
            // blurTrackBar
            // 
            this.blurTrackBar.Enabled = false;
            this.blurTrackBar.LargeChange = 1;
            this.blurTrackBar.Location = new System.Drawing.Point(4, 144);
            this.blurTrackBar.Name = "blurTrackBar";
            this.blurTrackBar.Size = new System.Drawing.Size(168, 56);
            this.blurTrackBar.TabIndex = 7;
            this.blurTrackBar.Scroll += new System.EventHandler(this.BlurTrackBar_Scroll);
            // 
            // blurNumber
            // 
            this.blurNumber.AutoSize = true;
            this.blurNumber.Location = new System.Drawing.Point(178, 144);
            this.blurNumber.Name = "blurNumber";
            this.blurNumber.Size = new System.Drawing.Size(16, 17);
            this.blurNumber.TabIndex = 9;
            this.blurNumber.Text = "0";
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.AutoSize = true;
            this.brightnessLabel.Location = new System.Drawing.Point(53, 65);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(75, 17);
            this.brightnessLabel.TabIndex = 5;
            this.brightnessLabel.Text = "Brightness";
            // 
            // contrastLabel
            // 
            this.contrastLabel.AutoSize = true;
            this.contrastLabel.Location = new System.Drawing.Point(57, 3);
            this.contrastLabel.Name = "contrastLabel";
            this.contrastLabel.Size = new System.Drawing.Size(61, 17);
            this.contrastLabel.TabIndex = 4;
            this.contrastLabel.Text = "Contrast";
            // 
            // brightnessTrackBar
            // 
            this.brightnessTrackBar.Enabled = false;
            this.brightnessTrackBar.Location = new System.Drawing.Point(4, 85);
            this.brightnessTrackBar.Maximum = 100;
            this.brightnessTrackBar.Minimum = -100;
            this.brightnessTrackBar.Name = "brightnessTrackBar";
            this.brightnessTrackBar.Size = new System.Drawing.Size(168, 56);
            this.brightnessTrackBar.TabIndex = 2;
            this.brightnessTrackBar.Scroll += new System.EventHandler(this.BrightnessTrackBar_Scroll);
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Enabled = false;
            this.contrastTrackBar.Location = new System.Drawing.Point(4, 23);
            this.contrastTrackBar.Maximum = 259;
            this.contrastTrackBar.Minimum = -259;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(168, 56);
            this.contrastTrackBar.TabIndex = 1;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.ContrastTrackBar_Scroll);
            // 
            // brightnessNumber
            // 
            this.brightnessNumber.AutoSize = true;
            this.brightnessNumber.Location = new System.Drawing.Point(178, 85);
            this.brightnessNumber.Name = "brightnessNumber";
            this.brightnessNumber.Size = new System.Drawing.Size(16, 17);
            this.brightnessNumber.TabIndex = 6;
            this.brightnessNumber.Text = "0";
            // 
            // contrastNumber
            // 
            this.contrastNumber.AutoSize = true;
            this.contrastNumber.Location = new System.Drawing.Point(178, 23);
            this.contrastNumber.Name = "contrastNumber";
            this.contrastNumber.Size = new System.Drawing.Size(16, 17);
            this.contrastNumber.TabIndex = 3;
            this.contrastNumber.Text = "0";
            // 
            // negativeButton
            // 
            this.negativeButton.Enabled = false;
            this.negativeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.negativeButton.Location = new System.Drawing.Point(251, 2);
            this.negativeButton.Name = "negativeButton";
            this.negativeButton.Size = new System.Drawing.Size(126, 30);
            this.negativeButton.TabIndex = 0;
            this.negativeButton.Text = "Negative";
            this.negativeButton.UseVisualStyleBackColor = true;
            this.negativeButton.Click += new System.EventHandler(this.NegativeButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click_1);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(117, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.Enabled = false;
            this.zoomTrackBar.Location = new System.Drawing.Point(12, 382);
            this.zoomTrackBar.Maximum = 25;
            this.zoomTrackBar.Minimum = -25;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(409, 56);
            this.zoomTrackBar.TabIndex = 3;
            this.zoomTrackBar.Visible = false;
            this.zoomTrackBar.Scroll += new System.EventHandler(this.ZoomTrackBar_Scroll);
            // 
            // saturationLabel
            // 
            this.saturationLabel.AutoSize = true;
            this.saturationLabel.Location = new System.Drawing.Point(263, 311);
            this.saturationLabel.Name = "saturationLabel";
            this.saturationLabel.Size = new System.Drawing.Size(73, 17);
            this.saturationLabel.TabIndex = 21;
            this.saturationLabel.Text = "Saturation";
            // 
            // saturationTrackBar
            // 
            this.saturationTrackBar.Enabled = false;
            this.saturationTrackBar.LargeChange = 1;
            this.saturationTrackBar.Location = new System.Drawing.Point(209, 330);
            this.saturationTrackBar.Maximum = 100;
            this.saturationTrackBar.Name = "saturationTrackBar";
            this.saturationTrackBar.Size = new System.Drawing.Size(168, 56);
            this.saturationTrackBar.TabIndex = 20;
            this.saturationTrackBar.Scroll += new System.EventHandler(this.SaturationTrackBar_Scroll);
            // 
            // saturationNumber
            // 
            this.saturationNumber.AutoSize = true;
            this.saturationNumber.Location = new System.Drawing.Point(383, 330);
            this.saturationNumber.Name = "saturationNumber";
            this.saturationNumber.Size = new System.Drawing.Size(16, 17);
            this.saturationNumber.TabIndex = 22;
            this.saturationNumber.Text = "0";
            // 
            // histogramButton
            // 
            this.histogramButton.Enabled = false;
            this.histogramButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.histogramButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.histogramButton.Location = new System.Drawing.Point(251, 74);
            this.histogramButton.Name = "histogramButton";
            this.histogramButton.Size = new System.Drawing.Size(126, 30);
            this.histogramButton.TabIndex = 23;
            this.histogramButton.Text = "Histogram";
            this.histogramButton.UseVisualStyleBackColor = true;
            this.histogramButton.Click += new System.EventHandler(this.HistogramButton_Click);
            // 
            // histogramPictureBox
            // 
            this.histogramPictureBox.Location = new System.Drawing.Point(209, 144);
            this.histogramPictureBox.Name = "histogramPictureBox";
            this.histogramPictureBox.Size = new System.Drawing.Size(200, 100);
            this.histogramPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histogramPictureBox.TabIndex = 1;
            this.histogramPictureBox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 450);
            this.Controls.Add(this.zoomTrackBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "BitSamurai";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdingTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharpenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saturationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.Button negativeButton;
        private System.Windows.Forms.TrackBar contrastTrackBar;
        private System.Windows.Forms.TrackBar brightnessTrackBar;
        private System.Windows.Forms.Label contrastNumber;
        private System.Windows.Forms.Label contrastLabel;
        private System.Windows.Forms.Label brightnessNumber;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Label blurLabel;
        private System.Windows.Forms.TrackBar blurTrackBar;
        private System.Windows.Forms.Label blurNumber;
        private System.Windows.Forms.Label sharpenLabel;
        private System.Windows.Forms.TrackBar sharpenTrackBar;
        private System.Windows.Forms.Label sharpenNumber;
        private System.Windows.Forms.Button edgeDetectionButton;
        private System.Windows.Forms.Label thresholdingLabel;
        private System.Windows.Forms.TrackBar thresholdingTrackBar;
        private System.Windows.Forms.Label thresholdingNumber;
        private System.Windows.Forms.Label hueLabel;
        private System.Windows.Forms.TrackBar hueTrackBar;
        private System.Windows.Forms.Label hueNumber;
        private System.Windows.Forms.Label saturationLabel;
        private System.Windows.Forms.TrackBar saturationTrackBar;
        private System.Windows.Forms.Label saturationNumber;
        private System.Windows.Forms.PictureBox histogramPictureBox;
        private System.Windows.Forms.Button histogramButton;
    }
}

