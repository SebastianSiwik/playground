using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BitmapApplication
{
    public class BitmapEditor
    {
        private readonly Bitmap bmp;
        private BitmapData bmpData = null;
        private readonly Rectangle area;
        private IntPtr dataBegin;
        private readonly int numberOfBytes;
        private readonly byte[] RGBvalues;
        private readonly short[] HSVvalues;

        public BitmapEditor(Bitmap bitmap)
        {
            bmp = bitmap;
            area = new Rectangle(0, 0, bmp.Width, bmp.Height);
            numberOfBytes = bmp.Width * bmp.Height * 3;
            RGBvalues = new byte[numberOfBytes];
            HSVvalues = new short[numberOfBytes];

            
        }
        public Bitmap ToNegative()
        {
            bmpData = bmp.LockBits(area, ImageLockMode.ReadWrite,
                                        PixelFormat.Format24bppRgb);
            dataBegin = bmpData.Scan0;
            Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

            for (int i = 0; i < RGBvalues.Length; i++)
            {
                RGBvalues[i] = (byte)(255 - RGBvalues[i]);
            }

            Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
            bmp.UnlockBits(bmpData);
            return bmp;
        }
        public Bitmap ChangeContrast(double value)
        {
            bmpData = bmp.LockBits(area, ImageLockMode.ReadWrite,
                                        PixelFormat.Format24bppRgb);
            dataBegin = bmpData.Scan0;
            Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

            byte[] rgb = new byte[numberOfBytes];
            RGBvalues.CopyTo(rgb, 0);

            var factor = (259.0 * (value + 255.0)) / (255.0 * (259.0 - value));

            for (int i = 0; i < rgb.Length; i++)
            {
                rgb[i] = Truncate((int)(factor * (rgb[i] - 128.0) + 128.0));
            }
            Marshal.Copy(rgb, 0, dataBegin, numberOfBytes);
            bmp.UnlockBits(bmpData);
            return bmp;
        }
        public Bitmap ChangeBrightness(double brightness)
        {
            bmpData = bmp.LockBits(area, ImageLockMode.ReadWrite,
                                        PixelFormat.Format24bppRgb);
            dataBegin = bmpData.Scan0;
            Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

            byte[] rgb = new byte[numberOfBytes];
            RGBvalues.CopyTo(rgb, 0);

            for (int i = 0; i < rgb.Length; i++)
            {
                rgb[i] += (byte)Truncate(255 * (brightness / 100));
            }

            Marshal.Copy(rgb, 0, dataBegin, numberOfBytes);
            bmp.UnlockBits(bmpData);
            return bmp;
        }
        private short GetHue(byte R, byte G, byte B)
        {
            short hue = 0;
            byte max = Utility.Max(R, G, B);
            byte min = Utility.Min(R, G, B);

            try
            {
                if (G == max) hue = (short)(60 * (B - R) / (max - min) + 120);
                if (B == max) hue = (short)(60 * (R - G) / (max - min) + 240);
                if (R == max) hue = (short)(60 * (G - B) / (max - min));
            }
            catch (DivideByZeroException)
            {
                hue = 0;
            }

            if (hue < 0) hue += 360;
            return hue;

        }
        private void SetHSV()
        {
            short hue;
            byte saturation;
            byte value;

            byte min, max;

            for (int i = 0; i < RGBvalues.Length; i += 3)
            {
                max = Utility.Max(RGBvalues[i], RGBvalues[i + 1], RGBvalues[i + 2]);
                min = Utility.Min(RGBvalues[i], RGBvalues[i + 1], RGBvalues[i + 2]);

                hue = GetHue(RGBvalues[i], RGBvalues[i + 1], RGBvalues[i + 2]);
                saturation = (byte)(max == 0 ? 0 : ((max - min) / max));
                value = max;

                HSVvalues[i] = hue; 
                HSVvalues[i + 1] = saturation; 
                HSVvalues[i + 2] = value;
            }
            
        }
        private byte Truncate(double color)
        {
            if (color > 255) return 255;
            else if (color < 0) return 0;
            else return (byte)color;
        }
    }
}
