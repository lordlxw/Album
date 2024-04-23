using Album_App.Controls.Base;
using Album_App.Controls.Navigation.Models;
using Album_App.Core;
using Album_App.Modules.ModuleName.Views;
using Album_App.Services.Instances;
using Album_App.Services.Interfaces.Interfaces;
using Album_App.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using PhotoView = Album_App.Modules.ModuleName.Views.PhotoView;
using PicFormatterView = Album_App.Modules.ModuleName.Views.PicFormatterView;

namespace Album_App.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private string _title = "純愛Album";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private List<string> IndexUriList_;
        public List<string> IndexUriList { get { return IndexUriList_; } set { IndexUriList_ = value; RaisePropertyChanged(); } }

        private double _progress;
        public double Progress
        {
            get { return _progress; }
            set
            {
                if (_progress != value)
                {
                    _progress = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<NavigationItemModel> NavigationItems { get; set; }
        private NavigationItemModel NavSelectedItem_;
        public NavigationItemModel NavSelectedItem
        {
            get { return NavSelectedItem_; }
            set { NavSelectedItem_ = value; RaisePropertyChanged(); }
        }
        public DelegateCommand<NavigationItemModel> ViewCommand { get; set; }

        public ICaptureVideoImage _captureVideoImage;

        public DelegateCommand CaptureImagesCommand { get; set; }
        public MainWindowViewModel(IRegionManager regionManager, ICaptureVideoImage captureVideoImage)
        {
            _regionManager = regionManager;
            NavigationItems = new System.Collections.ObjectModel.ObservableCollection<Controls.Navigation.Models.NavigationItemModel>();
            ViewCommand = new DelegateCommand<NavigationItemModel>(o =>
            {
                NavSelectedItem = o;
                _regionManager.RequestNavigate(RegionNames.ContentRegion, o.Uri);
            });
            InitNavigation();// 导航条初始化

            Progress = 100;
            _captureVideoImage = captureVideoImage;

            CaptureImagesCommand = new DelegateCommand(async () =>
            {
                if (_captureVideoImage != null)
                {
                    // 这里可以访问 _captureVideoImage
                    // 例如：
                    var ffmpegProcess = await  _captureVideoImage.CaptureImagesFromVideo("C:\\Users\\admin\\Desktop\\Album\\视频素材\\zc.mp4", "C:\\Users\\admin\\Desktop\\Album\\图片保存");
                    int totalFrames = ffmpegProcess.Item2;
                    ffmpegProcess.Item1.OutputDataReceived += (sender, e) =>
                    {
                        if (!string.IsNullOrEmpty(e.Data))
                        {
                            // 解析 ffmpeg 输出，更新帧数
                            // 例如，你可以在输出中查找关键字，如 "frame="，并从中提取帧数信息
                            // 更新当前帧数，然后计算进度并更新进度条
                            // 示例如下，仅供参考
                            if (e.Data.Contains("frame="))
                            {
                                var match = Regex.Match(e.Data, @"frame=\s*(\d+)");
                                if (match.Success)
                                {
                                    int currentFrame = int.Parse(match.Groups[1].Value);
                                    double progress = (double)currentFrame / totalFrames * 100.0;
                                    UpdateProgressBar(progress);
                                }
                            }
                        }
                    };
                }
            });
        }

        private void UpdateProgressBar(double progress)
        {
            // 在此更新进度条的方法，可以通过调用 UI 线程来更新界面上的进度条
           this.Progress= progress;
        }
        private void InitNavigation()
        {
            IndexUriList = new List<string>();

            NavigationItems.Add(new Controls.Navigation.Models.NavigationItemModel()
            {
                UnSelectedIcon = Controls.Base.IconTypes.Home,
                SelectedIcon = IconTypes.HomeSolid,
                Title = "概览",
                Uri = nameof(PhotoView),
                ID = 1

            });
            NavigationItems.Add(new Controls.Navigation.Models.NavigationItemModel()
            {
                UnSelectedIcon = Controls.Base.IconTypes.ZeroBars,
                SelectedIcon = IconTypes.FourBars,
                Title = "图片转换",
                ID = 2,
                Uri = nameof(PicFormatterView),
            });
            NavigationItems.Add(new Controls.Navigation.Models.NavigationItemModel()
            {
                UnSelectedIcon = Controls.Base.IconTypes.ImageExport,
                SelectedIcon = IconTypes.ImportAllMirrored,
                Title = "图片去重",
                ID =3,
                Uri = nameof(DeduplicationView),
            });
            NavSelectedItem = NavigationItems[0];
            //_regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(PicFormatterView)); //初始化到概览页面
        }
    }
}
