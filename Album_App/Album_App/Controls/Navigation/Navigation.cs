using Album_App.Controls.Navigation.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Album_App.Controls.Navigation
{
   public class Navigation:Control
    {
        #region 依赖属性
        public NavigationItemModel SelectedItem
        {
            get { return (NavigationItemModel)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(NavigationItemModel), typeof(Navigation), new PropertyMetadata(new PropertyChangedCallback(OnSelectedItemChanged)));



        public ObservableCollection<NavigationItemModel> Items
        {
            get { return (ObservableCollection<NavigationItemModel>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<NavigationItemModel>), typeof(Navigation), new PropertyMetadata(new PropertyChangedCallback(OnDataChanged)));




        #endregion


        #region 事件及方法

        public event RoutedEventHandler OnSelected;
        public event RoutedEventHandler OnMouseRightButtonUP;

        private StackPanel ItemsPanel;
        private Dictionary<int, NavigationItem> ItemsDictionary;

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Navigation;
            if (e.NewValue != e.OldValue)
            {
                var newItem = e.NewValue as NavigationItemModel;
                var oldItem = e.OldValue as NavigationItemModel;
                if (newItem != null && control.ItemsDictionary.ContainsKey(newItem.ID))
                {
                    control.ItemsDictionary[newItem.ID].IsSelected = true;
                }
                if (oldItem != null && control.ItemsDictionary.ContainsKey(oldItem.ID))
                {
                    control.ItemsDictionary[oldItem.ID].IsSelected = false;
                }
                control.ScrollToActive();
            }
        }

        private static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Navigation;
            if (e.NewValue != e.OldValue)
            {
                if (control.Items != null)
                {
                    control.Items.CollectionChanged -= control.Data_CollectionChanged;
                    control.Items.CollectionChanged += control.Data_CollectionChanged;

                    foreach (var item in control.Items)
                    {
                        control.AddItem(item);
                    }
                }
            }
        }

        private void Data_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    AddItem(item as NavigationItemModel);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    RemoveItem(item as NavigationItemModel);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                foreach (var ritem in e.NewItems)
                {
                    var item = ritem as NavigationItemModel;
                    var id = item.ID;
                    ItemsDictionary[id].Icon = item.UnSelectedIcon;
                    ItemsDictionary[id].TextInfo = item.Title;
                    //ItemsDictionary[id].SelectedIcon = item.SelectedIcon;

                }
            }
        }

        private void RemoveItem(NavigationItemModel item)
        {
            var navItem = ItemsDictionary[item.ID];
            ItemsPanel.Children.Remove(navItem);
            ItemsDictionary.Remove(item.ID);
        }

        private void AddItem(NavigationItemModel item)
        {
            if (ItemsPanel != null)
            {
                var navItem = new NavigationItem();
                //int id = item.ID < -1 ? CreateID() : item.ID;
                //if (ItemsDictionary.ContainsKey(id))
                //{
                //    return;
                //}

                //item.ID = id;
                navItem.ID = item.ID;
                navItem.TextInfo = item.Title;
                navItem.Icon = item.UnSelectedIcon;
                //navItem.SelectedIcon = item.SelectedIcon;
                //navItem.IconColor = item.IconColor;
                //navItem.BadgeText = item.BadgeText;
                //navItem.Uri = item.Uri;

                if (!string.IsNullOrEmpty(item.Title))
                {
                    navItem.MouseUp += NavItem_MouseUp;
                    navItem.Unloaded += (e, c) =>
                    {
                        navItem.MouseUp -= NavItem_MouseUp;
                    };
                }
                ItemsPanel.Children.Add(navItem);
                ItemsDictionary.Add(item.ID, navItem);
                //if (item.IsSelected)
                //{
                //    SelectedItem = item;
                //}
            }
        }

        private void NavItem_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var navitem = sender as NavigationItem;
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                //左键选中

                SelectedItem = Items.Where(m => m.ID == navitem.ID).FirstOrDefault();
                OnSelected?.Invoke(this, null);

                if (SelectedItem != null && SelectedItem.ID != navitem.ID)
                {
                    ScrollToActive();
                }
            }
            if (e.ChangedButton == System.Windows.Input.MouseButton.Right)
            {
                ////右键
                //var args = new RoutedEventArgs();
                //args.RoutedEvent = e.RoutedEvent;
                //args.Source = Data.Where(m => m.ID == navitem.ID).FirstOrDefault();
                //OnMouseRightButtonUP?.Invoke(this, args);
            }
        }
        #endregion
        #region 动画创建及触发

        //  选中标记块
        private Border ActiveBlock;
        //  动画
        Storyboard storyboard;
        //  滚动动画
        DoubleAnimation scrollAnimation;
        //  伸缩动画
        DoubleAnimation stretchAnimation;


        private void CreateAnimations()
        {
            if (ActiveBlock != null)
            {
                var tfg = new TransformGroup();
                tfg.Children.Add(new TranslateTransform() { X = 0, Y = 0 });
                tfg.Children.Add(new ScaleTransform() { ScaleX = 0, ScaleY = 0 });
                ActiveBlock.RenderTransform = tfg;
            }
            storyboard = new Storyboard();
            scrollAnimation = new DoubleAnimation();
            stretchAnimation = new DoubleAnimation();

            //  滚动动画
            scrollAnimation.EasingFunction = new SineEase() { EasingMode = EasingMode.EaseIn };
            scrollAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.35));

            Storyboard.SetTarget(scrollAnimation, ActiveBlock);
            Storyboard.SetTargetProperty(scrollAnimation, new PropertyPath("RenderTransform.Children[0].Y"));

            //  伸缩动画
            stretchAnimation.AutoReverse = true;
            stretchAnimation.EasingFunction = new SineEase() { EasingMode = EasingMode.EaseIn };
            stretchAnimation.Duration = new Duration(TimeSpan.FromSeconds(0.35));

            Storyboard.SetTarget(stretchAnimation, ActiveBlock);
            Storyboard.SetTargetProperty(stretchAnimation, new PropertyPath("RenderTransform.Children[1].ScaleY"));

            storyboard.Children.Add(stretchAnimation);
            storyboard.Children.Add(scrollAnimation);
        }

        private void ScrollToActive(double animationDuration = 0.35)
        {
            //  获取选中项
            if (SelectedItem == null || ItemsDictionary.Count == 0 || !ItemsDictionary.ContainsKey(SelectedItem.ID))
            {
                return;
            }
            var item = ItemsDictionary[SelectedItem.ID];
            item.IsSelected = true;

            scrollAnimation.Duration = new Duration(TimeSpan.FromSeconds(animationDuration));
            stretchAnimation.Duration = new Duration(TimeSpan.FromSeconds(animationDuration));


            //  选中项的坐标
            Point relativePoint = item.TransformToAncestor(this).Transform(new Point(0, 0));

            //  设定动画方向
            var activeBlockTTF = (ActiveBlock.RenderTransform as TransformGroup).Children[0] as TranslateTransform;
            scrollAnimation.To = relativePoint.Y + 8;

            //  伸缩动画

            stretchAnimation.To = 1.6;

            if (relativePoint.Y > activeBlockTTF.Y)
            {
                //  向下移动
                var transformGroup = new TransformGroup();
                transformGroup.Children.Add(new TranslateTransform(0, activeBlockTTF.Y));
                transformGroup.Children.Add(new ScaleTransform(1, 1, 0, 200));

                ActiveBlock.RenderTransform = transformGroup;
            }
            else
            {
                var transformGroup = new TransformGroup();
                transformGroup.Children.Add(new TranslateTransform(0, activeBlockTTF.Y));
                transformGroup.Children.Add(new ScaleTransform(1, 1, 0, 0));

                ActiveBlock.RenderTransform = transformGroup;

            }

            storyboard.Begin();
        }

        private void Render()
        {
            ItemsPanel.Children.Clear();
            ItemsDictionary.Clear();

            if (Items != null)
            {
                foreach (var item in Items)
                {
                    AddItem(item);
                }
            }

            UpdateActiveLocation();
        }

        private void UpdateActiveLocation()
        {
            if (SelectedItem == null || !IsLoaded)
            {
                return;
            }
            var item = ItemsDictionary[SelectedItem.ID];
            item.Loaded += (e, c) =>
            {
                ScrollToActive(0);
            };
        }
        #endregion

        #region 初始化
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ItemsPanel = GetTemplateChild("ItemsPanel") as StackPanel;
            ActiveBlock = GetTemplateChild("ActiveBlock") as Border;

            CreateAnimations();
            Render();
        }

        public Navigation()
        {
            DefaultStyleKey = typeof(Navigation);
            ItemsDictionary = new Dictionary<int, NavigationItem>();
            Loaded += Navigation_Loaded;
        }

        private void Navigation_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollToActive();
        }
        #endregion


        public object TopExtContent
        {
            get { return (object)GetValue(TopExtContentProperty); }
            set { SetValue(TopExtContentProperty, value); }
        }
        public static readonly DependencyProperty TopExtContentProperty =
            DependencyProperty.Register("TopExtContent", typeof(object), typeof(Navigation));
        public object BottomExtContent
        {
            get { return (object)GetValue(BottomExtContentProperty); }
            set { SetValue(BottomExtContentProperty, value); }
        }
        public static readonly DependencyProperty BottomExtContentProperty =
            DependencyProperty.Register("BottomExtContent", typeof(object), typeof(Navigation));
    }
}
