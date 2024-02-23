using Album_App.Controls.Base;
using Album_App.Controls.Navigation.Models;
using Album_App.Core;
using Album_App.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

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

        public ObservableCollection<NavigationItemModel> NavigationItems { get; set; }
        private NavigationItemModel NavSelectedItem_;
        public NavigationItemModel NavSelectedItem
        {
            get { return NavSelectedItem_; }
            set { NavSelectedItem_ = value; RaisePropertyChanged(); }
        }
        public DelegateCommand<NavigationItemModel> ViewCommand {  get; set; }

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigationItems = new System.Collections.ObjectModel.ObservableCollection<Controls.Navigation.Models.NavigationItemModel>();
            ViewCommand = new DelegateCommand<NavigationItemModel>(o =>
            {
                NavSelectedItem = o;
                _regionManager.RequestNavigate(RegionNames.ContentRegion, o.Uri);
            });
            InitNavigation();// 导航条初始化
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

            NavSelectedItem = NavigationItems[0];
            //_regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(PicFormatterView)); //初始化到概览页面
        }
    }
}
