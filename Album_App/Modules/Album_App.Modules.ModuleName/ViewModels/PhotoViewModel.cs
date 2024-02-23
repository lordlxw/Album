using Control_Library.Controls.Photo.PhotoModel;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album_App.Modules.ModuleName.ViewModels
{
    public class PhotoViewModel:BindableBase
    {
        public ObservableCollection<PhotoCellItem> PhotoData { get; set; }


        #region 依赖属性
        private int rowNum=14;

        public int RowNum
        {
            get { return rowNum; }
            set { rowNum = value; RaisePropertyChanged(); }
        }

        private int columnNum=15;

        public int ColumnNum
        {
            get { return columnNum; }
            set { columnNum = value; RaisePropertyChanged(); }
        }
        #endregion
        public PhotoViewModel()
        {
            PhotoData = new ObservableCollection<PhotoCellItem>();
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
            PhotoData.Add(new PhotoCellItem() { CellHeight = 20, CellWidth = 20 });
        }

    }
}
