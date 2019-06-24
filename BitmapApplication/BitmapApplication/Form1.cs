using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                pictureBox1.Image = bmp;
                pictureBox1.Width = bmp.Width;
                pictureBox1.Height = bmp.Height;

                saveToolStripMenuItem.Enabled = true;
                zoomTrackBar.Enabled = true;
                zoomTrackBar.Visible = true;
                zoomTrackBar.Value = 0;
                contrastTrackBar.Value = 0;
            }
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = Text.ClearProgramName();
            saveFileDialog1.ShowDialog();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ZoomTrackBar_Scroll(object sender, EventArgs e)
        {
            pictureBox1.Width = (int)(bmp.Width * Math.Pow(2, zoomTrackBar.Value * 0.1));
            pictureBox1.Height = (int)(bmp.Height * Math.Pow(2, zoomTrackBar.Value * 0.1));
        }

        private void ButtonNegative_Click(object sender, EventArgs e)
        {
            if(bitmapEditor is null) bitmapEditor = new BitmapEditor(bmp);
            bmp = bitmapEditor.ToNegative();
            pictureBox1.Image = bmp;
        }

        private void ContrastTrackBar_Scroll(object sender, EventArgs e)
        {
            if(bitmapEditor is null) bitmapEditor = new BitmapEditor(bmp);
            bmp = bitmapEditor.ChangeContrast(contrastTrackBar.Value);
            pictureBox1.Image = bmp;
        }

        private void BrightnessTrackBar_Scroll(object sender, EventArgs e)
        {
            if (bitmapEditor is null) bitmapEditor = new BitmapEditor(bmp);
            bmp = bitmapEditor.ChangeBrightness(brightnessTrackBar.Value);
            pictureBox1.Image = bmp;
        }
    }
}
