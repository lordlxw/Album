using Album_App.Services.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Album_App.Services.Instances
{
    public class Deduplicate : IDeduplicate
    {
        private Image img;

        public int ReadImageThreadCount { get ; set; }=default(int);
        public int AnalyzeImageThreadCount { get; set; } = default(int);

        public float GetAbs(int firstNum, int secondNum)
        {
            float abs = Math.Abs((float)firstNum - (float)secondNum);
            float result = Math.Max(firstNum, secondNum);
            if (result == 0)
                result = 1;
            return abs / result;
        }

        public int[] GetHisogram(Bitmap img)
        {
            BitmapData data = img.LockBits(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int[] histogram = new int[256];

            unsafe
            {
                byte* ptr = (byte*)data.Scan0;
                int remain = data.Stride - data.Width * 3;
                for (int i = 0; i < histogram.Length; i++)
                {
                    histogram[i] = 0;
                }

                for (int i = 0; i < data.Height; i++)
                {
                    for (int j = 0; j < data.Width; j++)
                    {
                        int mean = ptr[0] + ptr[1] + ptr[2];
                        mean /= 3;
                        histogram[mean]++;
                        ptr += 3;
                    }
                    ptr += remain;
                }
            }
            img.UnlockBits(data);
            return histogram;
        }

        public float GetResult(int[] firstNum, int[] scondNum)
        {
            if (firstNum.Length != scondNum.Length)
            {
                return 0;
            }
            else
            {
                float result = 0;
                int j = firstNum.Length;
                for (int i = 0; i < j; i++)
                {
                    result += 1 - GetAbs(firstNum[i], scondNum[i]);
                }
                return result / j;
            }
        }

        public Bitmap Resize(string imageFile, string newImageFile)
        {
            img = Image.FromFile(imageFile);
            Bitmap imgOutput = new Bitmap(img, 256, 256);
            imgOutput.Save(newImageFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            imgOutput.Dispose();
            return (Bitmap)Image.FromFile(newImageFile);
        }

    }
}
