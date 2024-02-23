using Control_Library.Controls.Photo.PhotoModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
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


        public ObservableCollection<PhotoCellItem> PhotoData
        {
            get
            {
                return (ObservableCollection<PhotoCellItem>)GetValue(PhotoDataProperty);
            }
            set
            {
                SetValue(PhotoDataProperty, value);
            }
        }
        public static readonly DependencyProperty PhotoDataProperty =
            DependencyProperty.Register("PhotoData", typeof(ObservableCollection<PhotoCellItem>), typeof(PhotoGrid), new PropertyMetadata(new PropertyChangedCallback(OnPhotoDataChanged)));


        #endregion



        #region 一般属性
        public ItemsControl ItemsPanel;
        #endregion
        #region 事件及方法

        private static void AutoSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PhotoGrid photoGrid)
            {
                //if ((bool)e.NewValue)
                //{
                //    photoGrid.SizeChanged += PhotoGrid_SizeChanged;
                //}
                //else
                //{
                //    photoGrid.SizeChanged -= PhotoGrid_SizeChanged;
                //}
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
            //if (ItemsPanel != null)
            //{
            //    ItemContainerGenerator generator = ItemsPanel.ItemContainerGenerator;
            //    int index = item.PhotoGridRow * ColumnNum + item.PhotoGridColumn;
            //    var container = generator.ContainerFromIndex(index);
            //    // 获取容器

            //    if (container != null)
            //    {
            //        // 创建 PhotoCell 控件
            //        PhotoCell photoCell = new PhotoCell()
            //        {
            //            // 设置 PhotoCell 属性 (可选)
            //        };

            //        // 将 PhotoCell 插入容器
            //        //container.Content = photoCell;
            //    }
            //}
        }

        private void PhotoData_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            
        }

        private static void UpdateUI(double actualWidth, double actualHeight)
        {
           
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ItemsPanel = GetTemplateChild("ItemsPanel") as ItemsControl;
        }
        #endregion


        public PhotoGrid()
        {
            DefaultStyleKey = typeof(PhotoGrid);
        }
    }
}
