using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Album_App.Services.StaticCoreService
{
    public enum ZoomMode
    {
        [Description("正常缩放")]
        Normal = 1,
        [Description("按比例缩放")]
        Stretch,
        [Description("居中缩放")]
        Center
    }
}
