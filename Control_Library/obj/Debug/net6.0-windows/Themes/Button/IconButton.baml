   M S B A M L   `   `   `  ����J  FControl_Library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:Control_Library.Controls.Base.Button$Control_Library.Controls.Base.Button  5      =#clr-namespace:Control_Library.IconsControl_Library.Icons  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e0895    /Control_Library.Controls.Base.Button.IconButton  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding � ColumnDefinitions    Control_Library.Icons.Icon  Name	    Icon
   IconType   StandardTextBrush'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   Transitions%  System.Windows.VisualTransition   GeneratedDuration	   To   States   System.Windows.VisualState   
Storyboard �� TargetProperty �� 
TargetName8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value �� Triggers�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      <local2clr-namespace:Control_Library.Controls.Base.Button  5      ,base#clr-namespace:Control_Library.Icons  5      %�  '         �� 5      "    6   .�5   
   ��  �@J�SnapsToDevicePixels$
 true��5      �� 5   
    � ��$
 auto��6"   �� 5	   
    � ��$
 auto��6#   �� 5
   
    � ��$ 16(�6%   �� 5   
    � ��
 ���� 6'   �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� $ 	BoxBorder��6`   #��z��6   #��z��6>   $ 4��6s   $ 5q�6�   ���#E1E1F3._�5      �  5      �� 5   "   $��30 �63   �� 5   "   $��* �63   .+�5        $
 Icon��6(   #
 z	 66   #���   6X   $��Center=�6�   #��z��6�   5      �� 5      $��1��6/   5       5        5      CommonStates�� 5    "     5!   &   $ 0:0:0D�67     5"   &   $ 0D�67   $ Pressed��5#   #   . 5%   "     
Normal��6.     5&   "   	MouseOver��. 5'   &   �� .��5(   *   �� $1 +(Border.Background).(SolidColorBrush.Color)�6G   $ 	BoxBorder��5)   1   .g�5*   .     $ 0��6B   $ #C2C2F3��5+   *   5,   +   5-   '   5.   #     5/   "   Pressed��. 50   &   �� .��51   *   �� $1 +(Border.Background).(SolidColorBrush.Color)�6G   $ 	BoxBorder��52   1   .g�53   .     $ 0��6B   $ DarkGray��54   *   55   +   �� 56   *   $4 .(base:Icon.Foreground).(SolidColorBrush.Color)�6G   $
 Icon��57   1   .g�58   .     $ 0��6B   $
 #fff��59   *   5:   +   5;   '   5<   #   5=      5?       5D      5G      5I      5J      5K      