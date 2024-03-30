using Control_Library.Controls.Photo.PhotoModel;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Control_Library.Controls.Photo
{
    public class PhotoGrid:ContentControl
    {
        #region 依赖属性
        public int RowNums
        {
            get { return (int)GetValue(RowNumsProperty); }
            set { SetValue(RowNumsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RowNumsProperty =
            DependencyProperty.Register("RowNums", typeof(int), typeof(PhotoGrid), new PropertyMetadata(10, AutoSizeChanged));


        public int ColumnNums
        {
            get { return (int)GetValue(ColumnNumsProperty); }
            set { SetValue(ColumnNumsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RowNum.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnNumsProperty =
            DependencyProperty.Register("ColumnNums", typeof(int), typeof(PhotoGrid), new PropertyMetadata(10,AutoSizeChanged));


        public static readonly DependencyProperty PhotoDataProperty =
          DependencyProperty.Register("PhotoData", typeof(ObservableCollection<PhotoCellItem>), typeof(PhotoGrid), new PropertyMetadata(null, OnPhotoDataChanged));

        private ObservableCollection<PhotoCellItem> _photoData;

        public ObservableCollection<PhotoCellItem> PhotoData
        {
            get { return (ObservableCollection<PhotoCellItem>)GetValue(PhotoDataProperty); }
            set { SetValue(PhotoDataProperty, value); }
        }

        #endregion



        #region 一般属性
        public Grid ItemsPanel;
        #endregion
        #region 事件及方法

        /// <summary>
        /// 创建格子方法（行和列）
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void AutoSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PhotoGrid photoGrid = (PhotoGrid)d;
            if(photoGrid.ItemsPanel!=null)
            {
                int rowNums = (int)photoGrid.GetValue(RowNumsProperty);
                int columnNums = (int)photoGrid.GetValue(ColumnNumsProperty);

                photoGrid.ItemsPanel.RowDefinitions.Clear();
                photoGrid.ItemsPanel.ColumnDefinitions.Clear();

                for (int i = 0; i < rowNums; i++)
                {
                    photoGrid.ItemsPanel.RowDefinitions.Add(new RowDefinition());
                }

                for (int i = 0; i < columnNums; i++)
                {
                    photoGrid.ItemsPanel.ColumnDefinitions.Add(new ColumnDefinition());
                }

                // 为每个格子添加鼠标悬浮事件处理程序
                //foreach (var child in photoGrid.ItemsPanel.Children)
                //{
                //    if (child is PhotoCell element)
                //    {
                //        element.MouseEnter += photoGrid.GridItem_MouseEnter;
                //    }
                //}
            }
         
        }

        private void GridItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // 获取当前触发事件的小格子
            if (sender is UIElement element)
            {

                enlargeAnimation.Begin((FrameworkElement)element);
            }
        }

   

        /// <summary>
        /// 当实际大小改变时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void PhotoGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (sender is PhotoGrid photoGrid)
            {
                UpdateUI(photoGrid.ActualWidth,photoGrid.ActualHeight);
            }
        }





        /// <summary>
        /// 当绑定的图片变化时触发
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void OnPhotoDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                var control = d as PhotoGrid;
                if (e.NewValue != e.OldValue)
                {
                    if (control.PhotoData != null)
                    {
                        control.PhotoData.CollectionChanged -= control.PhotoData_CollectionChanged;
                        control.PhotoData.CollectionChanged += control.PhotoData_CollectionChanged;

                        foreach (var item in control.PhotoData)
                        {
                            control.Push(item);
                        }
                    }
                }

              
            }
            catch { 

            }
        }
        public void Push(PhotoCellItem item)
        {
            if(item!=null)
            {
                var photoCell = new PhotoCell()
                {
                    CellWidth =20,
                    CellHeight =12,
                    
                };
                // 将控件放在第 2 行第 3 列
                Grid.SetRow(photoCell, item.PhotoGridRow);
                Grid.SetColumn(photoCell, item.PhotoGridColumn);
            }
        }

        private void PhotoData_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    AddItem(item as PhotoCellItem);
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    RemoveItem(item as PhotoCellItem);
                }
            }
        }

        private void RemoveItem(PhotoCellItem? photoCellItem)
        {
            try
            {
                // 获取单元格的行号和列号
                if(ItemsPanel!= null)
                {
                    int row = photoCellItem.PhotoGridRow;
                    int column = photoCellItem.PhotoGridColumn;
                    if (row < 0 || row >= ItemsPanel.RowDefinitions.Count || column < 0 || column >= ItemsPanel.ColumnDefinitions.Count)
                    {
                        return;
                    }

                    // 获取第 3 行第 4 列的单元格
                    var cell = ItemsPanel.Children.Cast<UIElement>().FirstOrDefault(x => Grid.GetRow(x) == row && Grid.GetColumn(x) == column);

                    // 如果找到单元格，则将其从 Grid 中删除
                    if (cell != null)
                    {
                        ItemsPanel.Children.Remove(cell);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void AddItem(PhotoCellItem? photoCellItem)
        {
            if (photoCellItem != null)
            {
                var photoCell = new PhotoCell() { TestBackGround = photoCellItem.Brush,PhotoGridRow=photoCellItem.PhotoGridRow,PhotoGridColumn=photoCellItem.PhotoGridColumn };


                // 将控件放在第 PhotoGridRow 行第PhotoGridColumn 列
                Grid.SetRow(photoCell, photoCellItem.PhotoGridRow);
                Grid.SetColumn(photoCell, photoCellItem.PhotoGridColumn);


                // 添加鼠标悬浮事件处理程序
                photoCell.MouseEnter += PhotoCell_MouseEnter;
                photoCell.MouseLeave += PhotoCell_MouseLeave;
                ItemsPanel.Children.Add(photoCell);
            }
        }
        // 鼠标进入控件时触发
        private void PhotoCell_MouseEnter(object sender, MouseEventArgs e)
        {
            if (sender is PhotoCell photoCell)
            {
                // 执行放大动画
                //ScaleTransform scaleTransform = new ScaleTransform(5, 5);
                //photoCell.RenderTransform = scaleTransform;
                photoCell.TestBackGround= Brushes.Blue;
                // 创建一个新的 PhotoCell 控件作为 Popup 的内容

                    // 获取 PhotoGrid 的宽度和高度
                    double width = photoCell.ActualWidth;
                    double height = photoCell.ActualHeight;

                    // 创建一个圆形
                    Ellipse ellipse = new Ellipse();
                    ellipse.Width = 50; // 圆形的直径
                    ellipse.Height = 50; // 圆形的直径
                    ellipse.Fill = Brushes.Red; // 圆形的填充颜色
                Grid.SetRow(ellipse, photoCell.PhotoGridRow);
                Grid.SetColumn(ellipse, photoCell.PhotoGridColumn);
                // 将圆形添加到 PhotoGrid 中心
                //Canvas.SetLeft(ellipse, (width - ellipse.Width) / 2);
                //    Canvas.SetTop(ellipse, (height - ellipse.Height) / 2);
                ItemsPanel.Children.Add(ellipse);

            }
        }

        // 鼠标离开控件时触发
        private void PhotoCell_MouseLeave(object sender, MouseEventArgs e)
        {
            if (sender is PhotoCell photoCell)
            {
                // 执行缩小动画
                ScaleTransform scaleTransform = new ScaleTransform(1.0, 1.0);
                photoCell.RenderTransform = scaleTransform;
            }
        }
            private static void UpdateUI(double actualWidth, double actualHeight)
        {
           
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ItemsPanel = GetTemplateChild("ItemsPanel") as Grid;

           // Push();
        }
        #endregion



        #region 动画效果
        private Storyboard enlargeAnimation;
        private Storyboard shrinkAnimation;
        private void InitializeAnimations()
        {
            // 创建放大动画
            enlargeAnimation = new Storyboard();
            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.To = 100;
            widthAnimation.Duration = TimeSpan.FromSeconds(0.2);
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("(FrameworkElement.Width)"));
            enlargeAnimation.Children.Add(widthAnimation);

            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.To = 100;
            heightAnimation.Duration = TimeSpan.FromSeconds(0.2);
            Storyboard.SetTargetProperty(heightAnimation, new PropertyPath("(FrameworkElement.Height)"));
            enlargeAnimation.Children.Add(heightAnimation);

            // 创建缩小动画
            shrinkAnimation = new Storyboard();
            DoubleAnimation widthShrinkAnimation = new DoubleAnimation();
            widthShrinkAnimation.To = 50;
            widthShrinkAnimation.Duration = TimeSpan.FromSeconds(0.2);
            Storyboard.SetTargetProperty(widthShrinkAnimation, new PropertyPath("(FrameworkElement.Width)"));
            shrinkAnimation.Children.Add(widthShrinkAnimation);

            DoubleAnimation heightShrinkAnimation = new DoubleAnimation();
            heightShrinkAnimation.To = 50;
            heightShrinkAnimation.Duration = TimeSpan.FromSeconds(0.2);
            Storyboard.SetTargetProperty(heightShrinkAnimation, new PropertyPath("(FrameworkElement.Height)"));
            shrinkAnimation.Children.Add(heightShrinkAnimation);
        }
        #endregion


        public PhotoGrid()
        {
            DefaultStyleKey = typeof(PhotoGrid);
            Loaded += PhotoGrid_Loaded;
            
            InitializeAnimations(); // 初始化动画
        }

        private void PhotoGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (ItemsPanel != null)
            {
                if (ItemsPanel != null)
                {
                    int rowNums = (int)GetValue(RowNumsProperty);
                    int columnNums = (int)GetValue(ColumnNumsProperty);

                    ItemsPanel.RowDefinitions.Clear();
                    ItemsPanel.ColumnDefinitions.Clear();

                    for (int i = 0; i < rowNums; i++)
                    {
                        ItemsPanel.RowDefinitions.Add(new RowDefinition());
                    }

                    for (int i = 0; i < columnNums; i++)
                    {
                        ItemsPanel.ColumnDefinitions.Add(new ColumnDefinition());
                    }
                }
            }
            if(PhotoData!=null&&PhotoData.Count>0)
            {
                try
                {
                    var control = sender as PhotoGrid;
                   
                        if (control.PhotoData != null)
                        {
                            control.PhotoData.CollectionChanged -= control.PhotoData_CollectionChanged;
                            control.PhotoData.CollectionChanged += control.PhotoData_CollectionChanged;

                            foreach (var item in control.PhotoData)
                            {
                                control.Push(item);
                            }
                        
                    }


                }
                catch
                {

                }
            }
        }
    }
}
