using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;

namespace Control_Library.Controls.ProgressBar
{
    public class HeartProgressBar : System.Windows.Controls.ProgressBar
    {
        static HeartProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HeartProgressBar), new FrameworkPropertyMetadata(typeof(HeartProgressBar)));
        }

        public HeartProgressBar()
        {
            // 在构造函数中初始化控件

            // 创建箭头和爱心
            Path pathArrow = new Path();
            pathArrow.Data = new LineGeometry(new Point(0, 0), new Point(100, 0));
            pathArrow.Stroke = Brushes.Black;
            pathArrow.StrokeThickness = 1;

            Path pathHeart = new Path();
            pathHeart.Data = new EllipseGeometry(new Point(50, 50), 50, 50);
            pathHeart.Fill = Brushes.Red;

            //// 将箭头和爱心添加到控件中
            //Children.Add(pathArrow);
            //Children.Add(pathHeart);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // 在 OnRender 方法中更新箭头和爱心的形状

            //// 箭头
            //double progress = Value / Maximum;
            //pathArrow.Data = new LineGeometry(new Point(0, 0), new Point(progress * 100, 0));

            //// 爱心
            //pathHeart.Data = new EllipseGeometry(new Point(50, 50), progress * 50, progress * 50);
        }
    }
}
