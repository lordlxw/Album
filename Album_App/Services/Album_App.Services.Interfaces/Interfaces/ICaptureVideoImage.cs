using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Album_App.Services.Interfaces.Interfaces
{
   public  interface  ICaptureVideoImage
    {
        // 定时捕获视频图像并保存到指定路径
         Task<Tuple<Process, int>> CaptureImagesFromVideo(string videoPath,string savePath, int interval = 5);
    }
}
