using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Library.Controls.Photo.PhotoModel
{
    public class PhotoCellItem
    {
        public int PhotoGridRow { get; set; }
        public int PhotoGridColumn { get; set; }
        public double CellWidth { get; set; }
        public double CellHeight { get; set; }
    }
}
