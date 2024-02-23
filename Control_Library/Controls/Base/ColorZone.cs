using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Control_Library.Controls.Base
{
    public class ColorZone : ContentControl
    {
        public ColorZone()
        {
            DefaultStyleKey = typeof(ColorZone);
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
     nameof(CornerRadius), typeof(CornerRadius), typeof(ColorZone), new PropertyMetadata(default(CornerRadius)));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}
