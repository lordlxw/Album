using Album_App.Services.Instances;
using Album_App.Services.Interfaces.Interfaces;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album_App.Modules.ModuleName.ViewModels
{
    public class DeduplicationViewModel:BindableBase
    {
        #region 依赖属性
        /// <summary>
        /// 图片总数
        /// </summary>
        private int allImageCount=0;

        public int AllImageCount
        {
            get { return allImageCount; }
            set { allImageCount = value;RaisePropertyChanged(); }
        }


        /// <summary>
        /// 已比较图片数量
        /// </summary>
        private int comparedImageCount=0;

        public int ComparedImageCount
        {
            get { return comparedImageCount; }
            set { comparedImageCount = value; RaisePropertyChanged(); }
        }
        #endregion
        #region 命令
        public DelegateCommand ImportDataCommand { get; set; } //导入图片文件夹命令

        #endregion

        #region 构造函数
        private IDeduplicate _deduplicate;
        public DeduplicationViewModel(IDeduplicate deduplicate)
        {
            _deduplicate = deduplicate;
            ImportDataCommand = new DelegateCommand(ImportOnlyImageData);

            ChoseImageCommand = new DelegateCommand<string>(ChoseImage);
        }

 
        #endregion

        #region 具体方法
        public void ImportOnlyImageData()
        {
            // 创建 CommonOpenFileDialog 对象
            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                // 设置 CommonOpenFileDialog 的属性
                dialog.IsFolderPicker = true;
                dialog.Title = "请选择包含图片的文件夹";

                // 如果用户点击了 "确定" 按钮
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    // 获取用户选择的文件夹路径
                    string folderPath = dialog.FileName;

                    // 使用 DirectoryInfo 类获取文件夹信息
                    DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

                    // 获取文件夹中的所有图片文件
                    FileInfo[] imageFiles = directoryInfo.GetFiles()
                        .Where(file => IsImageFile(file.FullName))
                        .ToArray();


                    this.AllImageCount = imageFiles.Length;
                    // 处理图片文件
                    ProcessImage(imageFiles);
                    //foreach (FileInfo imageFile in imageFiles)
                    //{
                    //    // 这里可以调用你的处理方法，比如显示图片、保存图片信息等
                    //    // 示例代码：处理图片文件的方法
                    //    ProcessImage(imageFile.FullName);
                    //}
                }
            }
        }
        // 示例方法：处理图片文件的方法
        private async Task ProcessImage(FileInfo[] imageFiles)
        {
            foreach (FileInfo imageFile in imageFiles)
            {
                // 调用 Deduplicate 类中的方法处理图片文件
                await Task.Run(() => _deduplicate.Resize(imageFile.FullName, "new_" + imageFile.FullName));
            }
        }


        // 示例方法：判断文件是否为图片文件
        private bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif";
        }
        #endregion


        #region 测试比较相似度
        private string image1;

        public string Image1
        {
            get { return image1; }
            set { image1 = value;RaisePropertyChanged(); }
        }

        private string image2;

        public string Image2
        {
            get { return image2; }
            set { image2 = value; RaisePropertyChanged(); }
        }

        public DelegateCommand<string> ChoseImageCommand { get; set; }

        private void ChoseImage(string obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg;*.gif)|*.png;*.jpg;*.jpeg;*.gif|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                if (obj == "1")
                {
                    Image1 = openFileDialog.FileName;
                }
                else
                {
                    Image2 = openFileDialog.FileName;
                }


            }
        }
        #endregion
    }
}
