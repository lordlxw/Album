   M S B A M L   `   `   `  ����I  EAlbum_App.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:Album_App.Core;assembly=Album_App.CoreAlbum_App.Core  5   	   D @Album_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Album_App.Controls.BaseAlbum_App.Controls.Base 5   	   M+clr-namespace:Album_App.Controls.NavigationAlbum_App.Controls.Navigation 5	   	       Album_App.Views.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   5   	   Acore4clr-namespace:Album_App.Core;assembly=Album_App.Core   5   	   2Base%clr-namespace:Album_App.Controls.Base   5   	   >
Navigation+clr-namespace:Album_App.Controls.Navigation   5	   	   _	 [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors 	 5
   	   !  Prism.Mvvm.ViewModelLocator    AutoWireViewModel  True5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��800��5   #   $
��1280��60    � Title 6	   �� *Title+.��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   $��40��6,   �� 5      $��* �6   .+�5   
   �� $��0��6   $��	0,0,0.1,0q�6"   
���iii� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         ShadowDepth$ 0Q�6#      
BlurRadius$ 1Q�63      Color$
 Gray��6B      	Direction$ 45Q�6O   ._�5      .  (Album_App.Controls.Navigation.Navigation  -   5        	  Name$	 
Navigation��5   %   
   Items
 69   �� *NavigationItems+ �� Mode$ TwoWay=�   SelectedItem 6g   �� *NavSelectedItem+$ TwoWay=�* 	 $Microsoft.Xaml.Behaviors.Interaction   Triggers 5      + 	 %Microsoft.Xaml.Behaviors.EventTrigger  5         	EventName$ 
OnSelected��6%   * 	 $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2 	 ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 60   �� *ViewCommand+   CommandParameter 6P   ��  �� ElementName$ 
Navigation�� �� Path$ SelectedItem�5        5      $ OnMouseRightButtonUP��6%   5         BottomExtContent 5      2  ,Album_App.Controls.Navigation.NavigationItem  5          Icon$ Settings=�6,      TextInfo$ 设置��6<   5"      5#      �� 5$   
   $��抓取视频图片��6   $��Center=�6K   
���`�����6"   �� *CaptureImagesCommand+6f   �� 5%   
   $��1��6    	   Album_App.Core.RegionNames 	  ContentRegion!
  Prism.Regions.RegionManager 
  
RegionName# Z 6)   5'      5(      