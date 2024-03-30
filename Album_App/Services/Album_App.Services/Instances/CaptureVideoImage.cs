using Album_App.Services.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using FFMpegCore;
using System.Diagnostics;
using FFMpegCore.Enums;
using FFMpegCore.Pipes;
using System.Text.RegularExpressions;

namespace Album_App.Services.Instances
{


    public class CaptureVideoImage : ICaptureVideoImage
    {
        public async Task<Tuple<Process,int>> CaptureImagesFromVideo(string videoPath, string savePath, int interval = 5)
        {
            try
            {
                // 创建保存图片的文件夹
                Directory.CreateDirectory(savePath);

                // 设置 FFmpeg 的路径
                string Path = @"C:\Users\admin\Desktop\Album\视频素材\ffmpeg-master-latest-win64-gpl\bin\";

                //videoPath = @"C:\Users\admin\Desktop\Album\视频素材\video.avi";
                // GlobalFFOptions.Configure(new FFOptions { BinaryFolder = Path });
                // 使用 FFmpegCore 打开视频文件
                var mediaInfo = await FFProbe.AnalyseAsync(videoPath); //1

                // 获取视频的总帧数和帧率
        
                if (mediaInfo.VideoStreams.Count < 1) //2
                {
                    Console.WriteLine("获取视频信息失败");
                    Console.ReadKey();
                }
                // 获取视频的帧速率
                var frameRate = mediaInfo.VideoStreams[0].FrameRate;

                // 计算间隔帧数
                var intervalFrames = (int)Math.Round(frameRate * interval);


                var totalFrames = (int)(mediaInfo.Duration.TotalSeconds* frameRate);
                // 使用 FFmpegCore 获取视频帧
                var ffmpegProcess = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "ffmpeg",
                        Arguments = $"-i \"{videoPath}\" -vf fps={frameRate / interval} \"{savePath}\\frame_%d.jpg\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true
                    }
                };
                ffmpegProcess.Start();

                // 开始异步读取 ffmpeg 输出
                ffmpegProcess.BeginOutputReadLine();
                ffmpegProcess.WaitForExit();
                return Tuple.Create(ffmpegProcess, totalFrames);

             
                //使用 FFmpegCore 获取视频帧并保存为图像
                // 使用 FFmpegCore 获取视频帧并保存为图像
                //           await FFMpegArguments
                //    .FromFileInput(videoPath, options => options
                //.WithVideoFilters(filterOptions => filterOptions.Transpose($"fps={frameRate}")) // 设置输出帧率
                //    .OutputToFile($"{savePath}\\frame_%d.jpg", false)
                //    .ProcessAsynchronously();
                // 使用 FFmpegCore 获取视频帧并保存为图像


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error capturing video frames: {ex.Message}");
                return null;
            }
        }
        //public async Task CaptureImagesFromVideo(string videoPath, string savePath, int interval = 5)
        //{
        //    try
        //    {
        //        // 设置 FFmpeg 的路径
        //        FFmpegLoader.FFmpegPath = @"C:\Users\admin\Desktop\Album\视频素材\ffmpeg-master-latest-win64-gpl\bin\";

        //        // 创建保存图片的文件夹
        //        Directory.CreateDirectory(savePath);

        //        using (var video = MediaFile.Open(videoPath))
        //        {
        //            // 获取视频的帧速率
        //            var frameRate = video.Video.Info.AvgFrameRate;

        //            // 计算间隔帧数
        //            //var intervalFrames = (int)Math.Round(frameRate * interval);
        //            TimeSpan intervalFrames = TimeSpan.FromSeconds(frameRate * interval); // 计算帧之间的时间间隔

        //            TimeSpan frameNumber = TimeSpan.FromSeconds(0);
        //            while (true)
        //            {
        //                // 获取指定帧数的视频帧
        //                await Task.Run(() =>
        //                {
        //                    ImageData frame = video.Video.GetFrame(frameNumber);
        //                    // 处理视频帧
        //                    // 如果视频帧为空，则表示视频已经播放完毕
        //                    // 如果视频帧为空，则表示视频已经播放完毕，退出循环
        //                    if (frame.Data.IsEmpty)
        //                        return;



        //                    // 保存视频帧为图片
        //                    string filePath = Path.Combine(savePath, $"frame_{frameNumber}.jpg");
        //                    using (Bitmap bitmap = new Bitmap(frame.ImageSize.Width, frame.ImageSize.Height, PixelFormat.Format24bppRgb))
        //                    {
        //                        bitmap.Save(filePath);
        //                    }

        //                    // 更新帧数，以获取下一个间隔的视频帧
        //                    frameNumber += TimeSpan.FromSeconds(interval);
        //                    //// 更新帧数，以获取下一个间隔的视频帧
        //                    //frameNumber += intervalFrames;
        //                });


        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error capturing video frames: {ex.Message}");
        //    }
        //}
    }
}
