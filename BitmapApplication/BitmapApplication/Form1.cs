using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap bmp;
        private BitmapEditor bitmapEditor;

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Text = "BitSamurai | " + openFileDialog1.FileName.ClearDirectory();
                bmp = Bitmap.FromFile(openFileDialog1.FileName) as Bitmap;
                mainPictureBox.Image = bmp;
                mainPictureBox.Width = bmp.Width;
                mainPictureBox.Height = bmp.Height;

                ResetControls();

                bitmapEditor = new BitmapEditor(bmp);
            }
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Text.ClearProgramName();
            saveFileDialog1.ShowDialog();

            FileStream fileStream = (FileStream)saveFileDialog1.OpenFile();
            switch (saveFileDialog1.FilterIndex)
            {
                case 1:
                    mainPictureBox.Image.Save(fileStream, ImageFormat.Jpeg);
                    break;
                case 2:
                    mainPictureBox.Image.Save(fileStream, ImageFormat.Gif);
                    break;
                case 3:
                    mainPictureBox.Image.Save(fileStream, ImageFormat.Png);
                    break;
                case 4:
                    mainPictureBox.Image.Save(fileStream, ImageFormat.Bmp);
                    break;
            }
            fileStream.Close();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ZoomTrackBar_Scroll(object sender, EventArgs e)
        {
            mainPictureBox.Width = (int)(bmp.Width * Math.Pow(2, zoomTrackBar.Value * 0.1));
            mainPictureBox.Height = (int)(bmp.Height * Math.Pow(2, zoomTrackBar.Value * 0.1));
        }

        private void NegativeButton_Click(object sender, EventArgs e)
        {
            bmp = bitmapEditor.ToNegative();
            mainPictureBox.Image = bmp;
        }

        private void ContrastTrackBar_Scroll(object sender, EventArgs e)
        {
            bmp = bitmapEditor.ChangeContrast(contrastTrackBar.Value);
            mainPictureBox.Image = bmp;

            contrastNumber.Text = contrastTrackBar.Value.ToString();
        }

        private void BrightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            bmp = bitmapEditor.ChangeBrightness(brightnessTrackBar.Value);
            mainPictureBox.Image = bmp;

            brightnessNumber.Text = brightnessTrackBar.Value.ToString();

        }

        private void BlurTrackBar_Scroll(object sender, EventArgs e)
        {
            bmp = bitmapEditor.Blur(blurTrackBar.Value);
            mainPictureBox.Image = bmp;

            blurNumber.Text = blurTrackBar.Value.ToString();
        }

        private void SharpenTrackBar_Scroll(object sender, EventArgs e)
        {
            bmp = bitmapEditor.Sharpen(sharpenTrackBar.Value);
            mainPictureBox.Image = bmp;

            sharpenNumber.Text = sharpenTrackBar.Value.ToString();
        }

        private void EdgeDetectionButton_Click(object sender, EventArgs e)
        {
            bmp = bitmapEditor.EdgeDetection();
            mainPictureBox.Image = bmp;
        }

        private void ThresholdingTrackBar_Scroll(object sender, EventArgs e)
        {
            bmp = bitmapEditor.Thresholding(thresholdingTrackBar.Value);
            mainPictureBox.Image = bmp;

            thresholdingNumber.Text = thresholdingTrackBar.Value.ToString();
        }

        private void HueTrackBar_Scroll(object sender, EventArgs e)
        {
            bmp = bitmapEditor.ChangeHue(hueTrackBar.Value);
            mainPictureBox.Image = bmp;

            hueNumber.Text = hueTrackBar.Value.ToString();
        }

        private void SaturationTrackBar_Scroll(object sender, EventArgs e)
        {
            bmp = bitmapEditor.ChangeSaturation(saturationTrackBar.Value);
            mainPictureBox.Image = bmp;

            saturationNumber.Text = saturationTrackBar.Value.ToString();
        }

        private void HistogramButton_Click(object sender, EventArgs e)
        {
            if (histogramPictureBox.Image is null)
                histogramPictureBox.Image = bitmapEditor.DisplayHistogram();
            else histogramPictureBox.Image = null;
        }

        public void ResetControls()
        {
            histogramPictureBox.Image = null;
            saveToolStripMenuItem.Enabled = true;
            zoomTrackBar.Enabled = true;
            zoomTrackBar.Visible = true;
            contrastTrackBar.Enabled = true;
            brightnessTrackBar.Enabled = true;
            blurTrackBar.Enabled = true;
            sharpenTrackBar.Enabled = true;
            thresholdingTrackBar.Enabled = true;
            hueTrackBar.Enabled = true;
            saturationTrackBar.Enabled = true;
            negativeButton.Enabled = true;
            edgeDetectionButton.Enabled = true;
            histogramButton.Enabled = true;
            zoomTrackBar.Value = 0;
            contrastTrackBar.Value = 0;
            blurTrackBar.Value = 0;
            sharpenTrackBar.Value = 0;
            thresholdingTrackBar.Value = 0;
            saturationTrackBar.Value = 0;
            hueTrackBar.Value = 0;
            brightnessNumber.Text = "0";
            contrastNumber.Text = "0";
            blurNumber.Text = "0";
            sharpenNumber.Text = "0";
            thresholdingNumber.Text = "0";
            hueNumber.Text = "0";
            saturationNumber.Text = "0";
        }
    }
}
