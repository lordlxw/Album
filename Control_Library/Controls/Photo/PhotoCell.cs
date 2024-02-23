using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Control_Library.Controls.Photo
{
    public class PhotoCell:ContentControl
    {
        #region 依赖属性
        public static readonly DependencyProperty ImageProperty =
  DependencyProperty.Register(
    "Image",
    typeof(ImageSource),
    typeof(PhotoCell),
    new PropertyMetadata(null));

        public static readonly DependencyProperty CellWidthProperty =
          DependencyProperty.Register(
            "CellWidth",
            typeof(double),
            typeof(PhotoCell),
            new PropertyMetadata(20.0));

        public static readonly DependencyProperty CellHeightProperty =
          DependencyProperty.Register(
            "CellHeight",
            typeof(double),
            typeof(PhotoCell),
            new PropertyMetadata(20.0));

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public double CellWidth
        {
            get { return (double)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public double CellHeight
        {
            get { return (double)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        #endregion


        #region 构造函数
        public PhotoCell()
        {
            DefaultStyleKey  = typeof(PhotoCell);
        }

        #endregion  



    }
}
