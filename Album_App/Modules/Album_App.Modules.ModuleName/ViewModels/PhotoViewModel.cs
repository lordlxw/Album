using Control_Library.Controls.Photo.PhotoModel;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Album_App.Modules.ModuleName.ViewModels
{
    public class PhotoViewModel:BindableBase
    {
 

        private ObservableCollection<PhotoCellItem> photoData;

        public ObservableCollection<PhotoCellItem> PhotoDatas
        {
            get { return photoData; }
            set { photoData = value;RaisePropertyChanged(); }
        }


        #region 依赖属性
        private int rowNum=10;

        public int RowNum
        {
            get { return rowNum; }
            set { rowNum = value; RaisePropertyChanged(); }
        }

        private int colNum=10;

        public int ColNum
        {
            get { return colNum; }
            set { colNum = value; RaisePropertyChanged(); }
        }
        #endregion

        #region 命令
        public DelegateCommand AddCellCmd { get; set; }
        #endregion
        public PhotoViewModel()
        {
            PhotoDatas = new ObservableCollection<PhotoCellItem>();
           

            AddCellCmd = new DelegateCommand(() =>
            {
                var random = new Random();
                int row = RowNum;
                int col = ColNum;

                for(int i=0;i<row;i++)
                {
                    for(int j=0;j<col;j++)
                    {
                        var randomColor = GetRandomColor();
                        var item = new PhotoCellItem() { CellHeight = 20, CellWidth = 20, PhotoGridRow = i, PhotoGridColumn = j, Brush = randomColor };
                        PhotoDatas.Add(item);
                        TextInfo += item.ToString()+"\r";
                    }
                }
              
            });
        }
        public static Brush GetRandomColor()
        {
            var random = new Random();
            var red = random.Next(256);
            var green = random.Next(256);
            var blue = random.Next(256);
            return new SolidColorBrush(Color.FromRgb((byte)red, (byte)green, (byte)blue));
        }
        private string Text;

        public string TextInfo
        {
            get { return Text; }
            set { Text = value;RaisePropertyChanged(); }
        }

    }
}
