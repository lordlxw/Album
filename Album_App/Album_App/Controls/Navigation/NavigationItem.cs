using Album_App.Controls.Base;
using Album_App.Core;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Album_App.Controls.Navigation
{
    /// <summary>
    /// 导航条
    /// </summary>
    public class NavigationItem:Control
    {
        #region 依赖属性
        public int ID
        {
            get { return (int)GetValue(IDProperty); }
            set { SetValue(IDProperty, value); }
        }
        public static readonly DependencyProperty IDProperty =
            DependencyProperty.Register("ID",
                typeof(int),
                typeof(NavigationItem));

        public IconTypes Icon
        {
            get { return (IconTypes)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon",
                typeof(IconTypes),
                typeof(NavigationItem), new PropertyMetadata(IconTypes.None));

        public static readonly DependencyProperty TextInfoProperty =
            DependencyProperty.Register("TextInfo", typeof(string), typeof(NavigationItem));

        public string TextInfo
        {
            get { return (string)GetValue(TextInfoProperty); }
            set { SetValue(TextInfoProperty, value); }
        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected",
                typeof(bool),
                typeof(NavigationItem), new PropertyMetadata(false));
        #endregion


        #region 导航命令
        public ICommand NavigateCommand
        {
            get { return (ICommand)GetValue(NavigateCommandProperty); }
            set { SetValue(NavigateCommandProperty, value); }
        }

        public static readonly DependencyProperty NavigateCommandProperty =
        DependencyProperty.Register("NavigateCommand", typeof(ICommand), typeof(NavigationItem));


        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter",
                typeof(object),
                typeof(NavigationItem));
        #endregion

        #region 方法
        private void OnNavigate(Type pageType)
        {
            var s = this;
            if (pageType != null)
            {
                var regionManager = RegionManager.GetRegionManager(this);
                regionManager.RequestNavigate(RegionNames.ContentRegion, pageType.Name);
            }
        }

        #endregion

        #region 构造函数
        public NavigationItem()
        {
            DefaultStyleKey = typeof(NavigationItem);
        }
        #endregion

        #region 鼠标事件
        public delegate void NavigationEventHandler(object sender, MouseButtonEventArgs e);
        public event NavigationEventHandler MouseUp;

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            MouseUp?.Invoke(this, e);
            if (e.ChangedButton == MouseButton.Left)
            {
                NavigateCommand?.Execute(CommandParameter);
            }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            VisualStateManager.GoToState(this, "MouseOver", true);
        }
        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            VisualStateManager.GoToState(this, "Normal", true);
        }
        #endregion
    }
}
