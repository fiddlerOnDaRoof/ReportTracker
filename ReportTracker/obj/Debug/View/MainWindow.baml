   M S B A M L   `   `   `  ����H  DReportTracker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ReportTrackerReportTracker  5   	   A%clr-namespace:ReportTracker.ViewModelReportTracker.ViewModel  5   	   7 clr-namespace:ReportTracker.ViewReportTracker.View  5   	       ReportTracker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ReportTracker     5   	   4VM%clr-namespace:ReportTracker.ViewModel     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   +view clr-namespace:ReportTracker.View  5   	      MaterialDesignBody#���   5   	     MaterialDesignPaper#���  5	   	   $��Medium"�5
   	   $��14(�5   	   $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5   	     � WindowState$  	Maximized=�5   	    � WindowStyle$
 None=�5   	    � Title$ 
MainWindow��5   	    � DataContext 5      -   'ReportTracker.ViewModel.MainWindowModel  5   
   .��5      )  #MaterialDesignThemes.Wpf.DialogHost  $��Stretch=�5      $��Stretch=�5         CloseOnClickAway .    
Identifier$ 
RootDialog��5   	      DialogContent 5    
   � 5!      $��20q�6   .+�5"      �� $��	EMERGENCY��6   5#      .��5%   
   )  #MaterialDesignThemes.Wpf.DrawerHost     IsLeftDrawerOpen 6$   �� *IsDrawerOpen+   LeftDrawerContent 5&      #   ReportTracker.View.MainDrawer  5'       6"   �� *MainDrawerViewModel+.��5*      � $��Stretch=�6   $��Stretch=�6/   	 � RowDefinitions	 5+      �� 5,      $��80 �6$   �� 5-      $��* �6$   .+�50      � $��0��6     PrimaryHueMidBrush#���  6$   .+�51      �� $��10q�6   $��Right=�6+   $��Center=�6G    * &MaterialDesignFloatingActionMiniButton#���  52      +  %MaterialDesignThemes.Wpf.ShadowAssist
   ShadowDepth$
 Depth0=�53      
������ 
������ ��54      �� *OpenDialogCommand+.��57      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Shutdown=�62   $��25��6B   $��25��6N   58      �� 59       �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��Center=�6W   .+�5:      �� $��Fiddle��6$    # MaterialDesignDisplay3TextBlock#��[ 62   
�������$��48(�6~     5;      $ 
HeartPulse=�62   
�������
������ $��34��6p   $��34��6{   5<      �� 5=      $��10q�6   $
��Left=�6*   $��Center=�6E   #���  5>         OpenDrawerCommand#��Z 5?      "  System.Windows.Controls.Dock   Left#��Z 5@      $
 Depth0=�5A      
������ 
������ .��5D        $
 Menu=�62   $��25��6>   $��25��6J   5E      5F      �� 5G      $��1��6!   ��6.   �� *ContentViewModel+'	  !MaterialDesignThemes.Wpf.Snackbar	  5H      -   5         	 Name$ SnackbarThree��5I      $��1��5K       	  MessageQueue 5J      �� *MessageQueue+5K      5M      5N      5O      5P      