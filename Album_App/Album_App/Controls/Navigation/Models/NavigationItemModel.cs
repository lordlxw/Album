using Album_App.Controls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Album_App.Controls.Navigation.Models
{
    public class NavigationItemModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
     
        public string BadgeText { get; set; }
        public string RegionName { get; set; }


        /// <summary>
        /// 未选择时默认图标
        /// </summary>
        public IconTypes UnSelectedIcon { get; set; }

        private IconTypes SelectedIcon_ = IconTypes.None;
        /// <summary>
        /// 选中后图标
        /// </summary>
        public IconTypes SelectedIcon
        {
            get
            {

                if (SelectedIcon_ == IconTypes.None)
                {
                    return UnSelectedIcon;
                }
                else
                {
                    return SelectedIcon_;
                }
            }
            set
            {
                SelectedIcon_ = value;
            }
        }

        public string Uri { get; set; }
    }
}
