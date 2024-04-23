using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Album_App.Services.Interfaces.Interfaces
{
    /// <summary>
    /// 图片去重接口
    /// </summary>
    public interface IDeduplicate
    {
        /// <summary>
        /// 默认读取线程数
        /// </summary>
        public int ReadImageThreadCount { get; set; } 

        /// <summary>
        /// 分析图片线程数
        /// </summary>
        public int AnalyzeImageThreadCount { get; set; }

        /// <summary>
        /// 图像转为相同大小
        /// </summary>
        /// <param name="imageFile"></param>
        /// <param name="newImageFile"></param>
        /// <returns></returns>
        public Bitmap Resize(string imageFile, string newImageFile);

        /// <summary>
        /// 计算图像直方图
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public int[] GetHisogram(Bitmap img);

        /// <summary>
        /// 计算相减后的绝对值
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="secondNum"></param>
        /// <returns></returns>
        public float GetAbs(int firstNum, int secondNum);

        /// <summary>
        /// 最终计算结果
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="scondNum"></param>
        /// <returns></returns>
        public float GetResult(int[] firstNum, int[] scondNum);
    }
}
