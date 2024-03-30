using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Control_Library.Controls.Photo.PhotoModel
{
    public class PhotoCellItem
    {
        public int PhotoGridRow { get; set; }
        public int PhotoGridColumn { get; set; }
        public double CellWidth { get; set; }
        public double CellHeight { get; set; }
        public Brush Brush { get; set; }
        public override string ToString()
        {
            return "[位置——行："+PhotoGridRow+"，列："+PhotoGridColumn+"]"+"\r\n"+"[宽度："+CellWidth+"，高度："+CellHeight+"]";
        }
    }
}
