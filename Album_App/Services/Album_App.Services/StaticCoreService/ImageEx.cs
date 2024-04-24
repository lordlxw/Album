using Album_App.Services.StaticCoreService;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Album_App.Services.Instances.StaticCoreService
{
    //public static class ImageEx
    //{
    //    public static Image GetThumbnail(Image OriginalImage, int Height, int Width, ZoomMode zm)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    Bitmap bitmap;
    //                    while (true)
    //                    {
    //                        int num = 0;
    //                        int num2 = 0;
    //                        int width = OriginalImage.Width;
    //                        int height = OriginalImage.Height;
    //                        int num3 = 3;
    //                        while (true)
    //                        {
    //                            Graphics graphics;
    //                            switch (num3)
    //                            {
    //                                case 0:
    //                                    goto IL_1F8;
    //                                case 1:
    //                                    goto IL_18E;
    //                                case 2:
    //                                    num3 = 9;
    //                                    continue;
    //                                case 3:
    //                                    if (zm == ZoomMode.Normal)
    //                                    {
    //                                        num3 = 10;
    //                                        continue;
    //                                    }
    //                                    goto IL_16A;
    //                                case 4:
    //                                    if (width * Height > height * Width)
    //                                    {
    //                                        num3 = 6;
    //                                        continue;
    //                                    }
    //                                    num2 = Height;
    //                                    num = (int)Math.Ceiling((double)width * Height / height);
    //                                    num3 = 1;
    //                                    continue;
    //                                case 5:
    //                                    goto IL_1F8;
    //                                case 6:
    //                                    num = Width;
    //                                    num2 = (int)Math.Ceiling((double)Width * height / width);
    //                                    num3 = 11;
    //                                    continue;
    //                                case 7:
    //                                    if (height > Height)
    //                                    {
    //                                        num3 = 2;
    //                                        continue;
    //                                    }
    //                                    goto IL_9E;
    //                                case 8:
    //                                    try
    //                                    {
    //                                        graphics.Clear(Color.Transparent);
    //                                        graphics.CompositingQuality = CompositingQuality.HighQuality;
    //                                        graphics.SmoothingMode = SmoothingMode.HighQuality;
    //                                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
    //                                        graphics.DrawImage(OriginalImage, new Rectangle((Width - num) / 2, (Height - num2) / 2, num, num2), 0, 0, width, height, GraphicsUnit.Pixel);
    //                                        graphics.Dispose();
    //                                        goto IL_27A;
    //                                    }
    //                                    finally
    //                                    {
    //                                        num3 = 1;
    //                                        while (true)
    //                                        {
    //                                            switch (num3)
    //                                            {
    //                                                case 0:
    //                                                    ((IDisposable)graphics).Dispose();
    //                                                    num3 = 2;
    //                                                    continue;
    //                                                case 2:
    //                                                    goto IL_167;
    //                                            }
    //                                            if (graphics == null)
    //                                            {
    //                                                break;
    //                                            }
    //                                            num3 = 0;
    //                                        }
    //                                    IL_167:;
    //                                    }
    //                                    goto IL_16A;
    //                                case 9:
    //                                    if (width > Width)
    //                                    {
    //                                        num3 = 13;
    //                                        continue;
    //                                    }
    //                                    goto IL_9E;
    //                                case 10:
    //                                    num = Width;
    //                                    num2 = Height;
    //                                    num3 = 5;
    //                                    continue;
    //                                case 11:
    //                                    goto IL_18E;
    //                                case 12:
    //                                    Height = num2;
    //                                    Width = num;
    //                                    num3 = 0;
    //                                    continue;
    //                                case 13:
    //                                    num3 = 4;
    //                                    continue;
    //                                case 14:
    //                                    goto IL_18E;
    //                                case 15:
    //                                    if (zm == ZoomMode.Stretch)
    //                                    {
    //                                        num3 = 12;
    //                                        continue;
    //                                    }
    //                                    goto IL_1F8;
    //                            }
    //                            break;
    //                        IL_9E:
    //                            num2 = Height;
    //                            num = Width;
    //                            if (true)
    //                            {
    //                            }
    //                            num3 = 14;
    //                            continue;
    //                        IL_16A:
    //                            num3 = 7;
    //                            continue;
    //                        IL_18E:
    //                            num3 = 15;
    //                            continue;
    //                        IL_1F8:
    //                            bitmap = new Bitmap(Width, Height);
    //                            graphics = Graphics.FromImage(bitmap);
    //                            num3 = 8;
    //                        }
    //                    }
    //                IL_27A:
    //                    OriginalImage.Dispose();
    //                    return bitmap;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public static Bitmap ToGray(Bitmap bmp)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //            IL_0E:
    //                while (true)
    //                {
    //                    int num = 0;
    //                    int num2 = 2;
    //                    while (true)
    //                    {
    //                        switch (num2)
    //                        {
    //                            case 0:
    //                                goto IL_85;
    //                            case 1:
    //                                {
    //                                    if (num >= bmp.Height)
    //                                    {
    //                                        num2 = 5;
    //                                        continue;
    //                                    }
                           
    //                                    num2 = 6;
    //                                    continue;
    //                                }
    //                            case 2:
    //                                goto IL_85;
    //                            case 3:
    //                                {
    //                                    int num3 = 0;
    //                                    if (num3 >= bmp.Width)
    //                                    {
    //                                        num2 = 7;
    //                                        continue;
    //                                    }
    //                                    Color pixel = bmp.GetPixel(num3, num);
    //                                    int expr_E7 = (int)((double)pixel.R * 0.299 + (double)pixel.G * 0.587 + (double)pixel.B * 0.114);
    //                                    Color color = Color.FromArgb(expr_E7, expr_E7, expr_E7);
    //                                    bmp.SetPixel(num3, num, color);
    //                                    num3++;
    //                                    num2 = 4;
    //                                    continue;
    //                                }
    //                            case 4:
    //                                goto IL_5B;
    //                            case 5:
    //                                return bmp;
    //                            case 6:
    //                                goto IL_5B;
    //                            case 7:
    //                                num++;
    //                                if (true)
    //                                {
    //                                }
    //                                num2 = 0;
    //                                continue;
    //                        }
    //                        break;
    //                    IL_5B:
    //                        num2 = 3;
    //                        continue;
    //                    IL_85:
    //                        num2 = 1;
    //                    }
    //                }
    //                return bmp;
    //        }
    //        goto IL_0E;
    //    }

    //    public static Bitmap ToGray2(Bitmap bmp)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    BitmapData bitmapData;
    //                    IntPtr scan;
    //                    int num;
    //                    byte[] array;
    //                    while (true)
    //                    {
    //                        bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    //                        scan = bitmapData.Scan0;
    //                        num = bitmapData.Stride * bitmapData.Height;
    //                        array = new byte[num];
    //                        Marshal.Copy(scan, array, 0, num);
    //                        int num2 = 0;
    //                        int num3 = 4;
    //                        while (true)
    //                        {
    //                            switch (num3)
    //                            {
    //                                case 0:
    //                                    goto IL_111;
    //                                case 1:
    //                                    num2++;
    //                                    num3 = 5;
    //                                    continue;
    //                                case 2:
    //                                    {
    //                                        if (num2 >= bitmapData.Height)
    //                                        {
    //                                            num3 = 0;
    //                                            continue;
    //                                        }
    //                                        int num4 = 0;
    //                                        num3 = 7;
    //                                        continue;
    //                                    }
    //                                case 3:
    //                                    {
    //                                        int num4;
    //                                        if (num4 >= bitmapData.Width * 3)
    //                                        {
    //                                            num3 = 1;
    //                                            continue;
    //                                        }
    //                                        double num5 = (double)array[num2 * bitmapData.Stride + num4 + 2] * 0.299 + (double)array[num2 * bitmapData.Stride + num4 + 1] * 0.587 + (double)array[num2 * bitmapData.Stride + num4] * 0.114;
    //                                        array[num2 * bitmapData.Stride + num4 + 2] = (array[num2 * bitmapData.Stride + num4 + 1] = (array[num2 * bitmapData.Stride + num4] = (byte)num5));
    //                                        num4 += 3;
    //                                        num3 = 6;
    //                                        continue;
    //                                    }
    //                                case 4:
    //                                    goto IL_EC;
    //                                case 5:
    //                                    goto IL_EC;
    //                                case 6:
    //                                    goto IL_AF;
    //                                case 7:
    //                                    goto IL_AF;
    //                            }
    //                            break;
    //                        IL_AF:
    //                            num3 = 3;
    //                            continue;
    //                        IL_EC:
    //                            num3 = 2;
    //                        }
    //                    }
    //                IL_111:
    //                    if (true)
    //                    {
    //                    }
    //                    Marshal.Copy(array, 0, scan, num);
    //                    bmp.UnlockBits(bitmapData);
    //                    return bmp;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public unsafe static Bitmap ToGray3(Bitmap bmp)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    BitmapData bitmapData;
    //                    while (true)
    //                    {
    //                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    //                        bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    //                        int num = bitmapData.Stride - bitmapData.Width * 3;
    //                        byte* ptr = (byte*)((void*)bitmapData.Scan0);
    //                        int num2 = 0;
    //                        int num3 = 1;
    //                        while (true)
    //                        {
    //                            switch (num3)
    //                            {
    //                                case 0:
    //                                    goto IL_9F;
    //                                case 1:
    //                                    goto IL_D4;
    //                                case 2:
    //                                    goto IL_9F;
    //                                case 3:
    //                                    goto IL_F6;
    //                                case 4:
    //                                    {
    //                                        if (num2 >= bitmapData.Height)
    //                                        {
    //                                            num3 = 3;
    //                                            continue;
    //                                        }
    //                                        int num4 = 0;
    //                                        num3 = 0;
    //                                        continue;
    //                                    }
    //                                case 5:
    //                                    {
    //                                        int num4;
    //                                        if (num4 >= bitmapData.Width)
    //                                        {
    //                                            num3 = 6;
    //                                            continue;
    //                                        }
    //                                        if (true)
    //                                        {
    //                                        }
    //                                        byte b = (byte)(0.299 * (double)ptr[2] + 0.587 * (double)ptr[1] + 0.114 * (double)(*ptr));
    //                                        *ptr = (ptr[1] = (ptr[2] = b));
    //                                        ptr += 3;
    //                                        num4++;
    //                                        num3 = 2;
    //                                        continue;
    //                                    }
    //                                case 6:
    //                                    ptr += num;
    //                                    num2++;
    //                                    num3 = 7;
    //                                    continue;
    //                                case 7:
    //                                    goto IL_D4;
    //                            }
    //                            break;
    //                        IL_9F:
    //                            num3 = 5;
    //                            continue;
    //                        IL_D4:
    //                            num3 = 4;
    //                        }
    //                    }
    //                IL_F6:
    //                    bmp.UnlockBits(bitmapData);
    //                    return bmp;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public unsafe static Bitmap ToGray3(Bitmap bmp, out int GrayAverage)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    int num;
    //                    BitmapData bitmapData;
    //                    while (true)
    //                    {
    //                        num = 0;
    //                        GrayAverage = 0;
    //                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    //                        bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    //                        int num2 = bitmapData.Stride - bitmapData.Width * 3;
    //                        byte* ptr = (byte*)((void*)bitmapData.Scan0);
    //                        int num3 = 0;
    //                        int num4 = 4;
    //                        while (true)
    //                        {
    //                            switch (num4)
    //                            {
    //                                case 0:
    //                                    {
    //                                        if (num3 >= bitmapData.Height)
    //                                        {
    //                                            num4 = 5;
    //                                            continue;
    //                                        }
    //                                        int num5 = 0;
    //                                        num4 = 7;
    //                                        continue;
    //                                    }
    //                                case 1:
    //                                    goto IL_A6;
    //                                case 2:
    //                                    goto IL_DB;
    //                                case 3:
    //                                    ptr += num2;
    //                                    num3++;
    //                                    num4 = 2;
    //                                    continue;
    //                                case 4:
    //                                    goto IL_DB;
    //                                case 5:
    //                                    goto IL_108;
    //                                case 6:
    //                                    {
    //                                        int num5;
    //                                        if (num5 >= bitmapData.Width)
    //                                        {
    //                                            num4 = 3;
    //                                            continue;
    //                                        }
    //                                        byte b = (byte)(0.299 * (double)ptr[2] + 0.587 * (double)ptr[1] + 0.114 * (double)(*ptr));
    //                                        *ptr = (ptr[1] = (ptr[2] = b));
    //                                        ptr += 3;
    //                                        GrayAverage += (int)b;
    //                                        num++;
    //                                        num5++;
    //                                        num4 = 1;
    //                                        continue;
    //                                    }
    //                                case 7:
    //                                    goto IL_A6;
    //                            }
    //                            break;
    //                        IL_A6:
    //                            num4 = 6;
    //                            continue;
    //                        IL_DB:
    //                            if (true)
    //                            {
    //                            }
    //                            num4 = 0;
    //                        }
    //                    }
    //                IL_108:
    //                    bmp.UnlockBits(bitmapData);
    //                    GrayAverage /= num;
    //                    return bmp;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public unsafe static ulong GetdHash(Image image, out string HashStr)
    //    {
    //        int a_ = 10;
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_17:
    //                    if (true)
    //                    {
    //                    }
    //                    HashStr = "";
    //                    int num = 8;
    //                    Image thumbnail = ImageEx.GetThumbnail(image, num, num + 1, ZoomMode.Normal);
    //                    ulong result;
    //                    try
    //                    {
    //                        while (true)
    //                        {
    //                            Bitmap bitmap = ImageEx.ToGray3(new Bitmap(thumbnail));
    //                            ulong num2 = 0uL;
    //                            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
    //                            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    //                            int num3 = bitmapData.Stride - bitmapData.Width * 3;
    //                            byte* ptr = (byte*)((void*)bitmapData.Scan0);
    //                            int num4 = 0;
    //                            int num5 = 4;
    //                            while (true)
    //                            {
    //                                int num6;
    //                                switch (num5)
    //                                {
    //                                    case 0:
    //                                        if (num4 >= num)
    //                                        {
    //                                            num5 = 2;
    //                                            continue;
    //                                        }
    //                                        num6 = 0;
    //                                        num5 = 12;
    //                                        continue;
    //                                    case 1:
    //                                        goto IL_1F5;
    //                                    case 2:
    //                                        bitmap.UnlockBits(bitmapData);
    //                                        result = num2;
    //                                        num5 = 11;
    //                                        continue;
    //                                    case 3:
    //                                        if (num6 >= num)
    //                                        {
    //                                            num5 = 5;
    //                                            continue;
    //                                        }
    //                                        num5 = 6;
    //                                        continue;
    //                                    case 4:
    //                                        goto IL_175;
    //                                    case 5:
    //                                        ptr += Math.Abs(bitmapData.Width - num) * 3;
    //                                        ptr += num3;
    //                                        num4++;
    //                                        num5 = 10;
    //                                        continue;
    //                                    case 6:
    //                                        if (Math.Abs((short)(*ptr)) > Math.Abs((short)ptr[3]))
    //                                        {
    //                                            num5 = 8;
    //                                            continue;
    //                                        }
    //                                        HashStr += ImageEx.b("㼎", a_);
    //                                        num5 = 1;
    //                                        continue;
    //                                    case 7:
    //                                        goto IL_1F5;
    //                                    case 8:
    //                                        {
    //                                            int num7 = num4 * num + num6;
    //                                            num2 |= 1uL << num7;
    //                                            HashStr += ImageEx.b("㸎", a_);
    //                                            num5 = 7;
    //                                            continue;
    //                                        }
    //                                    case 9:
    //                                        goto IL_153;
    //                                    case 10:
    //                                        goto IL_175;
    //                                    case 11:
    //                                        goto IL_229;
    //                                    case 12:
    //                                        goto IL_153;
    //                                }
    //                                break;
    //                            IL_153:
    //                                num5 = 3;
    //                                continue;
    //                            IL_175:
    //                                num5 = 0;
    //                                continue;
    //                            IL_1F5:
    //                                ptr += 3;
    //                                num6++;
    //                                num5 = 9;
    //                            }
    //                        }
    //                    IL_229:;
    //                    }
    //                    finally
    //                    {
    //                        int num5 = 0;
    //                        while (true)
    //                        {
    //                            switch (num5)
    //                            {
    //                                case 1:
    //                                    goto IL_266;
    //                                case 2:
    //                                    ((IDisposable)thumbnail).Dispose();
    //                                    num5 = 1;
    //                                    continue;
    //                            }
    //                            if (thumbnail == null)
    //                            {
    //                                break;
    //                            }
    //                            num5 = 2;
    //                        }
    //                    IL_266:;
    //                    }
    //                    return result;
    //                }
    //        }
    //        goto IL_17;
    //    }

    //    private static double[,] ᜀ(double[,] A_0, int A_1)
    //    {
    //        double[,] array;
    //        while (true)
    //        {
    //            array = new double[A_1, A_1];
    //            int num = 0;
    //            int num2 = 3;
    //            while (true)
    //            {
    //                switch (num2)
    //                {
    //                    case 0:
    //                        {
    //                            int num3;
    //                            if (num3 >= A_1)
    //                            {
    //                                num2 = 6;
    //                                continue;
    //                            }
    //                            array[num, num3] = A_0[num3, num];
    //                            num3++;
    //                            num2 = 5;
    //                            continue;
    //                        }
    //                    case 1:
    //                        goto IL_52;
    //                    case 2:
    //                        {
    //                            if (num >= A_1)
    //                            {
    //                                num2 = 7;
    //                                continue;
    //                            }
    //                            int num3 = 0;
    //                            num2 = 1;
    //                            continue;
    //                        }
    //                    case 3:
    //                        goto IL_74;
    //                    case 4:
    //                        goto IL_74;
    //                    case 5:
    //                        goto IL_52;
    //                    case 6:
    //                        num++;
    //                        if (true)
    //                        {
    //                        }
    //                        num2 = 4;
    //                        continue;
    //                    case 7:
    //                        return array;
    //                }
    //                break;
    //            IL_52:
    //                num2 = 0;
    //                continue;
    //            IL_74:
    //                num2 = 2;
    //            }
    //        }
    //        return array;
    //    }

    //    private static double[,] ᜀ(int A_0)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    double[,] array;
    //                    while (true)
    //                    {
    //                        array = new double[A_0, A_0];
    //                        double num = 1.0 / Math.Sqrt((double)A_0);
    //                        int num2 = 0;
    //                        int num3 = 0;
    //                        while (true)
    //                        {
    //                            switch (num3)
    //                            {
    //                                case 0:
    //                                    goto IL_DB;
    //                                case 1:
    //                                    goto IL_F9;
    //                                case 2:
    //                                    if (num2 >= A_0)
    //                                    {
    //                                        num3 = 4;
    //                                        continue;
    //                                    }
    //                                    array[0, num2] = num;
    //                                    num2++;
    //                                    num3 = 11;
    //                                    continue;
    //                                case 3:
    //                                    goto IL_6E;
    //                                case 4:
    //                                    {
    //                                        int num4 = 1;
    //                                        num3 = 1;
    //                                        continue;
    //                                    }
    //                                case 5:
    //                                    {
    //                                        int num4;
    //                                        if (num4 >= A_0)
    //                                        {
    //                                            num3 = 7;
    //                                            continue;
    //                                        }
    //                                        int num5 = 0;
    //                                        num3 = 3;
    //                                        continue;
    //                                    }
    //                                case 6:
    //                                    goto IL_6E;
    //                                case 7:
    //                                    goto IL_115;
    //                                case 8:
    //                                    goto IL_F9;
    //                                case 9:
    //                                    {
    //                                        int num4;
    //                                        num4++;
    //                                        num3 = 8;
    //                                        continue;
    //                                    }
    //                                case 10:
    //                                    {
    //                                        int num5;
    //                                        if (num5 >= A_0)
    //                                        {
    //                                            num3 = 9;
    //                                            continue;
    //                                        }
    //                                        int num4;
    //                                        array[num4, num5] = Math.Sqrt(2.0 / (double)A_0) * Math.Cos((double)num4 * 3.1415926535897931 * ((double)num5 + 0.5) / (double)A_0);
    //                                        num5++;
    //                                        num3 = 6;
    //                                        continue;
    //                                    }
    //                                case 11:
    //                                    goto IL_DB;
    //                            }
    //                            break;
    //                        IL_6E:
    //                            num3 = 10;
    //                            continue;
    //                        IL_DB:
    //                            num3 = 2;
    //                            continue;
    //                        IL_F9:
    //                            num3 = 5;
    //                        }
    //                    }
    //                IL_115:
    //                    if (true)
    //                    {
    //                    }
    //                    return array;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    private static double[,] ᜀ(double[,] A_0, double[,] A_1, int A_2)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    double[,] array;
    //                    while (true)
    //                    {
    //                        array = new double[A_2, A_2];
    //                        double num = 0.0;
    //                        int num2 = 0;
    //                        int num3 = 3;
    //                        while (true)
    //                        {
    //                            switch (num3)
    //                            {
    //                                case 0:
    //                                    goto IL_FF;
    //                                case 1:
    //                                    {
    //                                        if (num2 >= A_2)
    //                                        {
    //                                            num3 = 11;
    //                                            continue;
    //                                        }
    //                                        int num4 = 0;
    //                                        num3 = 4;
    //                                        continue;
    //                                    }
    //                                case 2:
    //                                    goto IL_FF;
    //                                case 3:
    //                                    goto IL_BC;
    //                                case 4:
    //                                    goto IL_66;
    //                                case 5:
    //                                    {
    //                                        int num4;
    //                                        if (num4 >= A_2)
    //                                        {
    //                                            if (true)
    //                                            {
    //                                            }
    //                                            num3 = 6;
    //                                            continue;
    //                                        }
    //                                        num = 0.0;
    //                                        int num5 = 0;
    //                                        num3 = 0;
    //                                        continue;
    //                                    }
    //                                case 6:
    //                                    num2++;
    //                                    num3 = 7;
    //                                    continue;
    //                                case 7:
    //                                    goto IL_BC;
    //                                case 8:
    //                                    {
    //                                        int num5;
    //                                        if (num5 >= A_2)
    //                                        {
    //                                            num3 = 9;
    //                                            continue;
    //                                        }
    //                                        int num4;
    //                                        num += A_0[num2, num5] * A_1[num5, num4];
    //                                        num5++;
    //                                        num3 = 2;
    //                                        continue;
    //                                    }
    //                                case 9:
    //                                    {
    //                                        int num4;
    //                                        array[num2, num4] = num;
    //                                        num4++;
    //                                        num3 = 10;
    //                                        continue;
    //                                    }
    //                                case 10:
    //                                    goto IL_66;
    //                                case 11:
    //                                    return array;
    //                            }
    //                            break;
    //                        IL_66:
    //                            num3 = 5;
    //                            continue;
    //                        IL_BC:
    //                            num3 = 1;
    //                            continue;
    //                        IL_FF:
    //                            num3 = 8;
    //                        }
    //                    }
    //                    return array;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public static int[] DCT(int[] pix, int n)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    int[] array2;
    //                    while (true)
    //                    {
    //                        double[,] array = new double[n, n];
    //                        int num = 0;
    //                        int num2 = 4;
    //                        while (true)
    //                        {
    //                            switch (num2)
    //                            {
    //                                case 0:
    //                                    {
    //                                        double[,] expr_A0 = ImageEx.ᜀ(n);
    //                                        double[,] a_ = ImageEx.ᜀ(expr_A0, n);
    //                                        new double[n, n];
    //                                        array = ImageEx.ᜀ(ImageEx.ᜀ(expr_A0, array, n), a_, n);
    //                                        array2 = new int[n * n];
    //                                        int num3 = 0;
    //                                        num2 = 1;
    //                                        continue;
    //                                    }
    //                                case 1:
    //                                    goto IL_149;
    //                                case 2:
    //                                    goto IL_127;
    //                                case 3:
    //                                    {
    //                                        int num3;
    //                                        if (num3 >= n)
    //                                        {
    //                                            num2 = 8;
    //                                            continue;
    //                                        }
    //                                        int num4 = 0;
    //                                        num2 = 12;
    //                                        continue;
    //                                    }
    //                                case 4:
    //                                    goto IL_168;
    //                                case 5:
    //                                    goto IL_189;
    //                                case 6:
    //                                    {
    //                                        int num3;
    //                                        num3++;
    //                                        num2 = 7;
    //                                        continue;
    //                                    }
    //                                case 7:
    //                                    goto IL_149;
    //                                case 8:
    //                                    return array2;
    //                                case 9:
    //                                    {
    //                                        int num5;
    //                                        if (num5 >= n)
    //                                        {
    //                                            if (true)
    //                                            {
    //                                            }
    //                                            num2 = 11;
    //                                            continue;
    //                                        }
    //                                        array[num, num5] = (double)pix[num * n + num5];
    //                                        num5++;
    //                                        num2 = 5;
    //                                        continue;
    //                                    }
    //                                case 10:
    //                                    {
    //                                        if (num >= n)
    //                                        {
    //                                            num2 = 0;
    //                                            continue;
    //                                        }
    //                                        int num5 = 0;
    //                                        num2 = 14;
    //                                        continue;
    //                                    }
    //                                case 11:
    //                                    num++;
    //                                    num2 = 15;
    //                                    continue;
    //                                case 12:
    //                                    goto IL_127;
    //                                case 13:
    //                                    {
    //                                        int num4;
    //                                        if (num4 >= n)
    //                                        {
    //                                            num2 = 6;
    //                                            continue;
    //                                        }
    //                                        int num3;
    //                                        array2[num3 * n + num4] = (int)array[num3, num4];
    //                                        num4++;
    //                                        num2 = 2;
    //                                        continue;
    //                                    }
    //                                case 14:
    //                                    goto IL_189;
    //                                case 15:
    //                                    goto IL_168;
    //                            }
    //                            break;
    //                        IL_127:
    //                            num2 = 13;
    //                            continue;
    //                        IL_149:
    //                            num2 = 3;
    //                            continue;
    //                        IL_168:
    //                            num2 = 10;
    //                            continue;
    //                        IL_189:
    //                            num2 = 9;
    //                        }
    //                    }
    //                    return array2;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public unsafe static int[] GetGrayArray(Bitmap bmp)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    if (true)
    //                    {
    //                    }
    //                    int[] array;
    //                    BitmapData bitmapData;
    //                    while (true)
    //                    {
    //                        array = new int[1024];
    //                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    //                        bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    //                        int num = bitmapData.Stride - bitmapData.Width * 3;
    //                        int num2 = 0;
    //                        byte* ptr = (byte*)((void*)bitmapData.Scan0);
    //                        int num3 = 0;
    //                        int num4 = 3;
    //                        while (true)
    //                        {
    //                            switch (num4)
    //                            {
    //                                case 0:
    //                                    {
    //                                        if (num3 >= bitmapData.Height)
    //                                        {
    //                                            num4 = 5;
    //                                            continue;
    //                                        }
    //                                        int num5 = 0;
    //                                        num4 = 6;
    //                                        continue;
    //                                    }
    //                                case 1:
    //                                    goto IL_B8;
    //                                case 2:
    //                                    goto IL_ED;
    //                                case 3:
    //                                    goto IL_ED;
    //                                case 4:
    //                                    {
    //                                        int num5;
    //                                        if (num5 >= bitmapData.Width)
    //                                        {
    //                                            num4 = 7;
    //                                            continue;
    //                                        }
    //                                        array[num2] = (int)((byte)(0.299 * (double)ptr[2] + 0.587 * (double)ptr[1] + 0.114 * (double)(*ptr)));
    //                                        ptr += 3;
    //                                        num2++;
    //                                        num5++;
    //                                        num4 = 1;
    //                                        continue;
    //                                    }
    //                                case 5:
    //                                    goto IL_10F;
    //                                case 6:
    //                                    goto IL_B8;
    //                                case 7:
    //                                    ptr += num;
    //                                    num3++;
    //                                    num4 = 2;
    //                                    continue;
    //                            }
    //                            break;
    //                        IL_B8:
    //                            num4 = 4;
    //                            continue;
    //                        IL_ED:
    //                            num4 = 0;
    //                        }
    //                    }
    //                IL_10F:
    //                    bmp.UnlockBits(bitmapData);
    //                    return array;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public static ulong GetpHash(Image image)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    if (true)
    //                    {
    //                    }
    //                    int num = 32;
    //                    Image thumbnail = ImageEx.GetThumbnail(image, num, num, ZoomMode.Normal);
    //                    ulong result;
    //                    try
    //                    {
    //                        while (true)
    //                        {
    //                            int[] array = ImageEx.DCT(ImageEx.GetGrayArray(new Bitmap(thumbnail)), 8);
    //                            int num2 = 0;
    //                            int num3 = 0;
    //                            int[] array2 = array;
    //                            int num4 = 0;
    //                            int num5 = 10;
    //                            while (true)
    //                            {
    //                                int num8;
    //                                switch (num5)
    //                                {
    //                                    case 0:
    //                                        goto IL_86;
    //                                    case 1:
    //                                        {
    //                                            if (num4 >= array2.Length)
    //                                            {
    //                                                num5 = 5;
    //                                                continue;
    //                                            }
    //                                            int num6 = array2[num4];
    //                                            num2 += num6;
    //                                            num4++;
    //                                            num5 = 0;
    //                                            continue;
    //                                        }
    //                                    case 2:
    //                                        {
    //                                            ulong num7;
    //                                            result = num7;
    //                                            num5 = 4;
    //                                            continue;
    //                                        }
    //                                    case 3:
    //                                        if (array[num8] > num3)
    //                                        {
    //                                            num5 = 7;
    //                                            continue;
    //                                        }
    //                                        goto IL_A5;
    //                                    case 4:
    //                                        goto IL_167;
    //                                    case 5:
    //                                        {
    //                                            num3 = num2 / 64;
    //                                            ulong num7 = 0uL;
    //                                            num8 = 0;
    //                                            num5 = 9;
    //                                            continue;
    //                                        }
    //                                    case 6:
    //                                        goto IL_F4;
    //                                    case 7:
    //                                        {
    //                                            ulong num7;
    //                                            num7 |= 1uL << num8;
    //                                            num5 = 8;
    //                                            continue;
    //                                        }
    //                                    case 8:
    //                                        goto IL_A5;
    //                                    case 9:
    //                                        goto IL_F4;
    //                                    case 10:
    //                                        goto IL_86;
    //                                    case 11:
    //                                        if (num8 >= array.Length)
    //                                        {
    //                                            num5 = 2;
    //                                            continue;
    //                                        }
    //                                        num5 = 3;
    //                                        continue;
    //                                }
    //                                break;
    //                            IL_86:
    //                                num5 = 1;
    //                                continue;
    //                            IL_A5:
    //                                num8++;
    //                                num5 = 6;
    //                                continue;
    //                            IL_F4:
    //                                num5 = 11;
    //                            }
    //                        }
    //                    IL_167:;
    //                    }
    //                    finally
    //                    {
    //                        int num5 = 1;
    //                        while (true)
    //                        {
    //                            switch (num5)
    //                            {
    //                                case 0:
    //                                    goto IL_1A4;
    //                                case 2:
    //                                    ((IDisposable)thumbnail).Dispose();
    //                                    num5 = 0;
    //                                    continue;
    //                            }
    //                            if (thumbnail == null)
    //                            {
    //                                break;
    //                            }
    //                            num5 = 2;
    //                        }
    //                    IL_1A4:;
    //                    }
    //                    return result;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public unsafe static int[] GetHistogram(Bitmap bmp)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    int[] array;
    //                    BitmapData bitmapData;
    //                    while (true)
    //                    {
    //                        array = new int[256];
    //                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    //                        bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    //                        byte* ptr = (byte*)((void*)bitmapData.Scan0);
    //                        int num = 0;
    //                        int num2 = 1;
    //                        while (true)
    //                        {
    //                            switch (num2)
    //                            {
    //                                case 0:
    //                                    {
    //                                        if (num >= bitmapData.Width)
    //                                        {
    //                                            num2 = 6;
    //                                            continue;
    //                                        }
    //                                        int num3 = 0;
    //                                        num2 = 7;
    //                                        continue;
    //                                    }
    //                                case 1:
    //                                    goto IL_E2;
    //                                case 2:
    //                                    goto IL_AD;
    //                                case 3:
    //                                    goto IL_E2;
    //                                case 4:
    //                                    if (true)
    //                                    {
    //                                    }
    //                                    ptr += bitmapData.Stride - bitmapData.Width * 3;
    //                                    num++;
    //                                    num2 = 3;
    //                                    continue;
    //                                case 5:
    //                                    {
    //                                        int num3;
    //                                        if (num3 >= bitmapData.Height)
    //                                        {
    //                                            num2 = 4;
    //                                            continue;
    //                                        }
    //                                        array[(int)(*ptr)]++;
    //                                        ptr += 3;
    //                                        num3++;
    //                                        num2 = 2;
    //                                        continue;
    //                                    }
    //                                case 6:
    //                                    goto IL_104;
    //                                case 7:
    //                                    goto IL_AD;
    //                            }
    //                            break;
    //                        IL_AD:
    //                            num2 = 5;
    //                            continue;
    //                        IL_E2:
    //                            num2 = 0;
    //                        }
    //                    }
    //                IL_104:
    //                    bmp.UnlockBits(bitmapData);
    //                    return array;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public unsafe static Bitmap Binarization(Bitmap bmp, int GrayAverage)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    BitmapData bitmapData;
    //                    while (true)
    //                    {
    //                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    //                        bitmapData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    //                        byte* ptr = (byte*)((void*)bitmapData.Scan0);
    //                        int num = 0;
    //                        int num2 = 10;
    //                        while (true)
    //                        {
    //                            int num3;
    //                            switch (num2)
    //                            {
    //                                case 0:
    //                                    ptr += bitmapData.Stride - bitmapData.Width * 3;
    //                                    num++;
    //                                    num2 = 1;
    //                                    continue;
    //                                case 1:
    //                                    goto IL_E6;
    //                                case 2:
    //                                    goto IL_A4;
    //                                case 3:
    //                                    goto IL_83;
    //                                case 4:
    //                                    if (num >= bitmapData.Width)
    //                                    {
    //                                        num2 = 6;
    //                                        continue;
    //                                    }
    //                                    num3 = 0;
    //                                    num2 = 7;
    //                                    continue;
    //                                case 5:
    //                                    goto IL_A4;
    //                                case 6:
    //                                    goto IL_107;
    //                                case 7:
    //                                    goto IL_83;
    //                                case 8:
    //                                    if ((int)(*ptr) > GrayAverage)
    //                                    {
    //                                        num2 = 9;
    //                                        continue;
    //                                    }
    //                                    *ptr = (ptr[1] = (ptr[2] = 0));
    //                                    num2 = 2;
    //                                    continue;
    //                                case 9:
    //                                    *ptr = (ptr[1] = (ptr[2] = 255));
    //                                    num2 = 5;
    //                                    continue;
    //                                case 10:
    //                                    goto IL_E6;
    //                                case 11:
    //                                    if (num3 >= bitmapData.Height)
    //                                    {
    //                                        num2 = 0;
    //                                        continue;
    //                                    }
    //                                    num2 = 8;
    //                                    continue;
    //                            }
    //                            break;
    //                        IL_83:
    //                            num2 = 11;
    //                            continue;
    //                        IL_A4:
    //                            if (true)
    //                            {
    //                            }
    //                            ptr += 3;
    //                            num3++;
    //                            num2 = 3;
    //                            continue;
    //                        IL_E6:
    //                            num2 = 4;
    //                        }
    //                    }
    //                IL_107:
    //                    bmp.UnlockBits(bitmapData);
    //                    return bmp;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public unsafe static int[] GetBinarizationArray(Bitmap bmp, int GrayAverage)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    int[] array;
    //                    BitmapData bitmapData;
    //                    while (true)
    //                    {
    //                        int num = 0;
    //                        array = new int[bmp.Height * bmp.Width];
    //                        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
    //                        bitmapData = bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    //                        byte* ptr = (byte*)((void*)bitmapData.Scan0);
    //                        int num2 = 0;
    //                        int num3 = 7;
    //                        while (true)
    //                        {
    //                            int num4;
    //                            switch (num3)
    //                            {
    //                                case 0:
    //                                    ptr += bitmapData.Stride - bitmapData.Width * 3;
    //                                    num2++;
    //                                    num3 = 5;
    //                                    continue;
    //                                case 1:
    //                                    goto IL_C4;
    //                                case 2:
    //                                    if ((int)(*ptr) > GrayAverage)
    //                                    {
    //                                        if (true)
    //                                        {
    //                                        }
    //                                        num3 = 8;
    //                                        continue;
    //                                    }
    //                                    array[num] = 0;
    //                                    num3 = 11;
    //                                    continue;
    //                                case 3:
    //                                    goto IL_9D;
    //                                case 4:
    //                                    goto IL_9D;
    //                                case 5:
    //                                    goto IL_10A;
    //                                case 6:
    //                                    if (num4 >= bitmapData.Height)
    //                                    {
    //                                        num3 = 0;
    //                                        continue;
    //                                    }
    //                                    num3 = 2;
    //                                    continue;
    //                                case 7:
    //                                    goto IL_10A;
    //                                case 8:
    //                                    array[num] = 1;
    //                                    num3 = 1;
    //                                    continue;
    //                                case 9:
    //                                    if (num2 >= bitmapData.Width)
    //                                    {
    //                                        num3 = 10;
    //                                        continue;
    //                                    }
    //                                    num4 = 0;
    //                                    num3 = 3;
    //                                    continue;
    //                                case 10:
    //                                    goto IL_12C;
    //                                case 11:
    //                                    goto IL_C4;
    //                            }
    //                            break;
    //                        IL_9D:
    //                            num3 = 6;
    //                            continue;
    //                        IL_C4:
    //                            num++;
    //                            ptr += 3;
    //                            num4++;
    //                            num3 = 4;
    //                            continue;
    //                        IL_10A:
    //                            num3 = 9;
    //                        }
    //                    }
    //                IL_12C:
    //                    bmp.UnlockBits(bitmapData);
    //                    return array;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    public static double calSimilarity(Image SourceImg, Image TargetImg)
    //    {
    //        switch (0)
    //        {
    //            case 0:
    //                {
    //                IL_0E:
    //                    if (true)
    //                    {
    //                    }
    //                    int num;
    //                    while (true)
    //                    {
    //                        Image arg_40_0 = ImageEx.GetThumbnail(SourceImg, 32, 32, ZoomMode.Normal);
    //                        int grayAverage = 0;
    //                        int[] binarizationArray = ImageEx.GetBinarizationArray(ImageEx.ToGray3(new Bitmap(arg_40_0), out grayAverage), grayAverage);
    //                        Image arg_60_0 = ImageEx.GetThumbnail(TargetImg, 32, 32, ZoomMode.Normal);
    //                        int grayAverage2 = 0;
    //                        int[] binarizationArray2 = ImageEx.GetBinarizationArray(ImageEx.ToGray3(new Bitmap(arg_60_0), out grayAverage2), grayAverage2);
    //                        num = 0;
    //                        int num2 = 0;
    //                        int num3 = 2;
    //                        while (true)
    //                        {
    //                            switch (num3)
    //                            {
    //                                case 0:
    //                                    goto IL_D7;
    //                                case 1:
    //                                    goto IL_B8;
    //                                case 2:
    //                                    goto IL_B8;
    //                                case 3:
    //                                    num += ((binarizationArray[num2] == binarizationArray2[num2]) ? 0 : 1);
    //                                    num2++;
    //                                    num3 = 1;
    //                                    continue;
    //                                case 4:
    //                                    if (num2 >= binarizationArray.Length)
    //                                    {
    //                                        num3 = 0;
    //                                        continue;
    //                                    }
    //                                    num3 = 3;
    //                                    continue;
    //                            }
    //                            break;
    //                        IL_B8:
    //                            num3 = 4;
    //                        }
    //                    }
    //                IL_D7:
    //                    return Math.Pow((double)(1024 - num) / 1024.0, 2.0) * 100.0;
    //                }
    //        }
    //        goto IL_0E;
    //    }

    //    internal static string b(string A_0, int A_1)
    //    {
    //        char[] array = A_0.ToCharArray();
    //        int num = 1685736452 + A_1;
    //        int arg_47_0;
    //        int arg_14_0;
    //        if ((arg_14_0 = (arg_47_0 = 0)) < 1)
    //        {
    //            goto IL_47;
    //        }
    //    IL_14:
    //        int num2;
    //        int expr_14 = num2 = arg_14_0;
    //        char[] arg_44_0 = array;
    //        int arg_44_1 = num2;
    //        char expr_1B = array[num2];
    //        byte b = (byte)((int)(expr_1B & 'ÿ') ^ num++);
    //        byte b2 = (byte)((int)(expr_1B >> 8) ^ num++);
    //        byte arg_3C_0 = b2;
    //        b2 = b;
    //        b = arg_3C_0;
    //        arg_44_0[arg_44_1] = (ushort)((int)b2 << 8 | (int)b);
    //        arg_47_0 = expr_14 + 1;
    //    IL_47:
    //        if ((arg_14_0 = arg_47_0) >= array.Length)
    //        {
    //            return string.Intern(new string(array));
    //        }
    //        goto IL_14;
    //    }
    //}
}
