   M S B A M L   `   `   `  ����D  @Album_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Album_App.Controls.NavigationAlbum_App.Controls.Navigation  5      A%clr-namespace:Album_App.Controls.BaseAlbum_App.Controls.Base  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e0892    ,Album_App.Controls.Navigation.NavigationItem  �� 
TargetType �� Property �� Value �� 
TargetType ��Name �� CornerRadius �� Padding'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	   
Storyboard
 �� 
TargetName �� TargetProperty	 W� To g� Duration �� Value �� KeyTime �Name"   Album_App.Controls.Base.Icon  Name    Icon   IconType J� RenderTransformOrigin �� ElementName �� Path ��Name �� EdgeMode    TextInfo   NavUnselectedTextBrush�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml     5      5local+clr-namespace:Album_App.Controls.Navigation  5      .base%clr-namespace:Album_App.Controls.Base  5      %�  '         �� 5      "    6   .�5   
   ��  �@J�SnapsToDevicePixels$
 True��60   �� 5   
    � ��$ 60��6"   �� 5   
    � ��$ 60��6#   �� 5	   
    � ��
 ���� 6'   �� 5
   
    �@�FocusVisualStyle 6-   Z� �� 5   
    � �� 5      �� 5      "   6"   .R�5      �� $ Border��6H   
������ $ 10��66   $ 1q�6X    5        5      CommonStates��. 5   "     
Normal��6.     5   "   	MouseOver��.	 5   &   �� .��5   *   W� $
 Border��6:   $ Opacity�5   2    0.85   2   $ 0:0:0.3D�6;   �� 5   *   $1 +(Border.Background).(SolidColorBrush.Color)�5      $
 Border��5      g�5   2   �� $ #EAEAEA��6F   $ 0:0:0��6V   5   +   5    '   5#   #     5%   "   Pressed��5'   #   5(      ._�5+      � $ Content��6   $��5q�61   .+�5-        $
 Icon��6(   # z 66   $��Center=�6�   $��1��6�   $��17(�6�   $ 0.5,0.5&�6�   ��6X   �� $ Title��$ 
Foreground�5/      �� 52      $ Title��6(   $ Aliased=�67   #��z 6X   $��2��6z   $��Bottom=�6�   $��Center=�6�   $��10(�6�   #���   6�   $��0,5,0,0q�6  57      58      59      5;      5<      5=      