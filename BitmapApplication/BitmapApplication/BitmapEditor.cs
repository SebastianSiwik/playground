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
            area = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            numberOfBytes = bitmap.Width * bitmap.Height * 3;
            bmp = bitmap.Clone(area, PixelFormat.Format24bppRgb);
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
            var bitmap = (Bitmap)bmp.Clone();

            bmpData = bitmap.LockBits(area, ImageLockMode.ReadWrite,
                                        PixelFormat.Format24bppRgb);
            dataBegin = bmpData.Scan0;
            Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

            var factor = (259.0 * (value + 255.0)) / (255.0 * (259.0 - value));

            for (int i = 0; i < RGBvalues.Length; i++)
            {
                RGBvalues[i] = Truncate((int)(factor * (RGBvalues[i] - 128.0) + 128.0));
            }
            Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }
        public Bitmap ChangeBrightness(double value)
        {
            var bitmap = (Bitmap)bmp.Clone();

            bmpData = bitmap.LockBits(area, ImageLockMode.ReadWrite,
                                        PixelFormat.Format24bppRgb);
            dataBegin = bmpData.Scan0;
            Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

            double brightness = 255 * (value / 100);

            for (int i = 0; i < RGBvalues.Length; i++)
            {
                if (RGBvalues[i] + brightness > 255) RGBvalues[i] = 255;
                else if (RGBvalues[i] + brightness < 0) RGBvalues[i] = 0;
                else RGBvalues[i] += (byte)brightness;
            }

            Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }
        public Bitmap Blur(int value)
        {
            value++;

            Bitmap blurred = new Bitmap(bmp.Width, bmp.Height);

            // make an exact copy of the bitmap provided
            using (Graphics graphics = Graphics.FromImage(blurred))
                graphics.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height),
                    new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);

            // look at every pixel in the blur rectangle
            for (int xx = area.X; xx < area.X + area.Width; xx++)
            {
                for (int yy = area.Y; yy < area.Y + area.Height; yy++)
                {
                    int avgR = 0, avgG = 0, avgB = 0;
                    int blurPixelCount = 0;

                    // average the color of the red, green and blue for each pixel in the
                    // blur size while making sure you don't go outside the image bounds
                    for (int x = xx; (x < xx + value && x < bmp.Width); x++)
                    {
                        for (int y = yy; (y < yy + value && y < bmp.Height); y++)
                        {
                            Color pixel = blurred.GetPixel(x, y);

                            avgR += pixel.R;
                            avgG += pixel.G;
                            avgB += pixel.B;

                            blurPixelCount++;
                        }
                    }

                    avgR = avgR / blurPixelCount;
                    avgG = avgG / blurPixelCount;
                    avgB = avgB / blurPixelCount;

                    // now that we know the average for the blur size, set each pixel to that color
                    for (int x = xx; x < xx + value && x < bmp.Width && x < area.Width; x++)
                        for (int y = yy; y < yy + value && y < bmp.Height && y < area.Height; y++)
                            blurred.SetPixel(x, y, Color.FromArgb(avgR, avgG, avgB));
                }
            }

            return blurred;
        }
        //public Bitmap Sharpen()
        //{
        //    //value++;
        ////To display an image sharpening effect
        //    int Height = bmp.Height;
        //    int Width = bmp.Width;
        //    Bitmap newBitmap = new Bitmap(Width, Height);
        //    Color pixel;
        //    //Laplasse template
        //    int[] Laplacian = { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
        //    for (int x = 1; x < Width - 1; x++)
        //        for (int y = 1; y < Height - 1; y++)
        //        {
        //            int r = 0, g = 0, b = 0;
        //            int Index = 0;
        //            for (int col = -1; col <= 1; col++)
        //                for (int row = -1; row <= 1; row++)
        //                {
        //                    pixel = bmp.GetPixel(x + row, y + col); r += pixel.R * Laplacian[Index];
        //                    g += pixel.G * Laplacian[Index];
        //                    b += pixel.B * Laplacian[Index];
        //                    Index++;
        //                }
        //            //Color value overflow
        //            r = r > 255 ? 255 : r;
        //            r = r < 0 ? 0 : r;
        //            g = g > 255 ? 255 : g;
        //            g = g < 0 ? 0 : g;
        //            b = b > 255 ? 255 : b;
        //            b = b < 0 ? 0 : b;
        //            newBitmap.SetPixel(x - 1, y - 1, Color.FromArgb(r, g, b));
        //        }
        //    return newBitmap;
        //}
        public Bitmap Sharpen(double value)
        {
            value++;

            var sharpenImage = (Bitmap)bmp.Clone();

            int width = bmp.Width;
            int height = bmp.Height;

            const int filterSize = 5;

            var sharpeningFilter = new double[,]
                {
            {-1, -1, -1, -1, -1},
            {-1,  2,  2,  2, -1},
            {-1,  2, 16,  2, -1},
            {-1,  2,  2,  2, -1},
            {-1, -1, -1, -1, -1}
                };

            double bias = 1.0 - value;
            double factor = value / 16.0;

            const int s = filterSize / 2;

            var result = new Color[bmp.Width, bmp.Height];

            if (sharpenImage != null)
            {
                BitmapData pbits = sharpenImage.LockBits(new Rectangle(0, 0, width, height),
                                                            ImageLockMode.ReadWrite,
                                                            PixelFormat.Format24bppRgb);

                int bytes = pbits.Stride * height;
                var rgbValues = new byte[bytes];

                Marshal.Copy(pbits.Scan0, rgbValues, 0, bytes);

                int rgb;
                for (int x = s; x < width - s; x++)
                {
                    for (int y = s; y < height - s; y++)
                    {
                        double red = 0.0, green = 0.0, blue = 0.0;

                        for (int filterX = 0; filterX < filterSize; filterX++)
                        {
                            for (int filterY = 0; filterY < filterSize; filterY++)
                            {
                                int imageX = (x - s + filterX + width) % width;
                                int imageY = (y - s + filterY + height) % height;

                                rgb = imageY * pbits.Stride + 3 * imageX;

                                red += rgbValues[rgb + 2] * sharpeningFilter[filterX, filterY];
                                green += rgbValues[rgb + 1] * sharpeningFilter[filterX, filterY];
                                blue += rgbValues[rgb + 0] * sharpeningFilter[filterX, filterY];
                            }

                            rgb = y * pbits.Stride + 3 * x;

                            int r = Math.Min(Math.Max((int)(factor * red + (bias * rgbValues[rgb + 2])), 0), 255);
                            int g = Math.Min(Math.Max((int)(factor * green + (bias * rgbValues[rgb + 1])), 0), 255);
                            int b = Math.Min(Math.Max((int)(factor * blue + (bias * rgbValues[rgb + 0])), 0), 255);

                            result[x, y] = Color.FromArgb(r, g, b);
                        }
                    }
                }

                for (int x = s; x < width - s; x++)
                {
                    for (int y = s; y < height - s; y++)
                    {
                        rgb = y * pbits.Stride + 3 * x;

                        rgbValues[rgb + 2] = result[x, y].R;
                        rgbValues[rgb + 1] = result[x, y].G;
                        rgbValues[rgb + 0] = result[x, y].B;
                    }
                }
                Marshal.Copy(rgbValues, 0, pbits.Scan0, bytes);
                sharpenImage.UnlockBits(pbits);
            }

            return sharpenImage;
        }
        public Bitmap EdgeDetection()
        {
            double[,] filterMatrix = new double[,]
            {   { -1, -1, -1, -1, -1, },
                { -1, -1, -1, -1, -1, },
                { -1, -1, 24, -1, -1, },
                { -1, -1, -1, -1, -1, },
                { -1, -1, -1, -1, -1  }
            };
            

        double factor = 1;
            int bias = 0;

            BitmapData sourceData =
                   bmp.LockBits(new Rectangle(0, 0,
                   bmp.Width, bmp.Height),
                                     ImageLockMode.ReadOnly,
                                PixelFormat.Format32bppArgb);




            byte[] pixelBuffer = new byte[sourceData.Stride *
                                          sourceData.Height];


            byte[] resultBuffer = new byte[sourceData.Stride *
                                           sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                                       pixelBuffer.Length);


            bmp.UnlockBits(sourceData);

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;


            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);


            int filterOffset = (filterWidth - 1) / 2;
            int calcOffset = 0;


            int byteOffset = 0;


            for (int offsetY = filterOffset; offsetY <
                bmp.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    bmp.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;


                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;


                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {


                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);


                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset,
                                                 filterX + filterOffset];


                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset,
                                                  filterX + filterOffset];


                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset,
                                                filterX + filterOffset];
                        }
                    }


                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;


                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }


                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }


                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }


                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }


            Bitmap resultBitmap = new Bitmap(bmp.Width,
                                            bmp.Height);


            BitmapData resultData =
                       resultBitmap.LockBits(new Rectangle(0, 0,
                       resultBitmap.Width, resultBitmap.Height),
                                        ImageLockMode.WriteOnly,
                                    PixelFormat.Format32bppArgb);


            Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                                       resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }
        public Bitmap Thresholding(int value)
        {
            var bitmap = (Bitmap)bmp.Clone();

            bmpData = bitmap.LockBits(area, ImageLockMode.ReadWrite,
                                        PixelFormat.Format24bppRgb);
            dataBegin = bmpData.Scan0;
            Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

            double brightness;
            byte color = 0;

            for (int i = 0; i < RGBvalues.Length; i += 3)
            {
                brightness = 0.299 * RGBvalues[i] + 0.587 * RGBvalues[i + 1] + 0.114 * RGBvalues[i + 2];

                if (brightness > value) color = 0;
                else color = 255;
                
                RGBvalues[i] = color;
                RGBvalues[i + 1] = color;
                RGBvalues[i + 2] = color;
            }

            Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }
        public Bitmap ChangeHue(int value)
        {
            var bitmap = (Bitmap)bmp.Clone();

            bmpData = bitmap.LockBits(area, ImageLockMode.ReadWrite,
                                        PixelFormat.Format24bppRgb);
            dataBegin = bmpData.Scan0;
            Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

            SetHSV();

            for (int i = 0; i < HSVvalues.Length; i += 3)
            {
                for(int j = 0; j < value; j++)
                {
                    //HSVvalues[i] = (short)((HSVvalues[i] + 5f) % 360f);
                    HSVvalues[i] = (short)value;
                }
            }

            SetRGB();

            Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }
        public Bitmap ChangeSaturation(int value)
        {
            var bitmap = (Bitmap)bmp.Clone();

            bmpData = bitmap.LockBits(area, ImageLockMode.ReadWrite,
                                        PixelFormat.Format24bppRgb);
            dataBegin = bmpData.Scan0;
            Marshal.Copy(dataBegin, RGBvalues, 0, numberOfBytes);

            SetHSV();

            for (int i = 0; i < HSVvalues.Length; i += 3)
            {
                for (int j = 0; j < value; j++)
                {
                    HSVvalues[i + 1] = (short)(value);
                }
            }

            SetRGB();

            Marshal.Copy(RGBvalues, 0, dataBegin, numberOfBytes);
            bitmap.UnlockBits(bmpData);
            return bitmap;
        }
        public Bitmap DisplayHistogram()
        {
            int[] histogram_r = new int[256];
            float max = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    int redValue = bmp.GetPixel(i, j).R;
                    histogram_r[redValue]++;
                    if (max < histogram_r[redValue])
                        max = histogram_r[redValue];
                }
            }

            int histHeight = 128;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram_r.Length; i++)
                {
                    float pct = histogram_r[i] / max;   // What percentage of the max is this value?
                    g.DrawLine(Pens.Black,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }
            return img;
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
            if (hue > 360) hue -= 360;
            return hue;

        }
        private byte GetSaturation(byte min, byte max)
        {
            byte saturation = 0;

            if(max != 0)
            {
                saturation = (byte)(max == 0 ? 0 : ((double)(max - min) / max) * 100);

                if (saturation < 0) saturation = 0;
                if (saturation > 100) saturation = 100;
            }

            return saturation;
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
                saturation = GetSaturation(min, max);
                value = max;

                HSVvalues[i] = hue; 
                HSVvalues[i + 1] = saturation; 
                HSVvalues[i + 2] = value;
            }
            
        }
        private void SetRGB()
        {
            int r, f, a, b, c;

            for(int i = 0; i < HSVvalues.Length; i += 3)
            {
                if(HSVvalues[i + 1] == 0)
                {
                    RGBvalues[i] = (byte)HSVvalues[i + 2];
                    RGBvalues[i + 1] = (byte)HSVvalues[i + 2];
                    RGBvalues[i + 2] = (byte)HSVvalues[i + 2];
                }
                else
                {
                    if (HSVvalues[i] == 360) HSVvalues[i] = 0;
                    else HSVvalues[i] /= 60;

                    r = (int)Math.Truncate((double)HSVvalues[i]);
                    f = HSVvalues[i] - r;
                    a = HSVvalues[i + 2] * (1 - HSVvalues[i + 1]);
                    b = HSVvalues[i + 2] * (1 - HSVvalues[i + 1] * f);
                    c = HSVvalues[i + 2] * (1 - HSVvalues[i + 1] * (1 - f));

                    switch (r)
                    {
                        case 0:
                            RGBvalues[i] = (byte)HSVvalues[i + 2];
                            RGBvalues[i + 1] = (byte)c;
                            RGBvalues[i + 2] = (byte)a;
                            break;
                        case 1:
                            RGBvalues[i] = (byte)b;
                            RGBvalues[i + 1] = (byte)HSVvalues[i + 2];
                            RGBvalues[i + 2] = (byte)a;
                            break;
                        case 2:
                            RGBvalues[i] = (byte)a;
                            RGBvalues[i + 1] = (byte)HSVvalues[i + 2];
                            RGBvalues[i + 2] = (byte)c;
                            break;
                        case 3:
                            RGBvalues[i] = (byte)a;
                            RGBvalues[i + 1] = (byte)b;
                            RGBvalues[i + 2] = (byte)HSVvalues[i + 2];
                            break;
                        case 4:
                            RGBvalues[i] = (byte)c;
                            RGBvalues[i + 1] = (byte)a;
                            RGBvalues[i + 2] = (byte)HSVvalues[i + 2];
                            break;
                        case 5:
                            RGBvalues[i] = (byte)HSVvalues[i + 2];
                            RGBvalues[i + 1] = (byte)a;
                            RGBvalues[i + 2] = (byte)b;
                            break;
                    }
                }
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
