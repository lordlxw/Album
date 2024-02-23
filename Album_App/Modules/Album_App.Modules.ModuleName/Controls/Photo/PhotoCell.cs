using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Album_App.Modules.ModuleName.Controls.Photo
{
    /// <summary>
    /// 单一单元格控件封装
    /// </summary>
    public class PhotoCell : Control
    {
        public PhotoCell()
        {
                DefaultStyleKey = typeof(PhotoCell);
        }

        /// <summary>
        /// 鼠标悬浮时照片显露(或许用的到Win32API?)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            VisualStateManager.GoToState(this, "MouseOver", true);
        }
    }
}
