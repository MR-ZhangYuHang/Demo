   M S B A M L   `   `   `  ����H  DUtil.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:Util.Controls;assembly=Util.ControlsUtil.Controls  5   	    WpfApp4   WpfApp4.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Bxly2clr-namespace:Util.Controls;assembly=Util.Controls     5   	      WindowBackground#��[  5        � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5	      � 
����  � � RowDefinitions 5
   
   �� 5      $��44 �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��Center=�6.   $��3q�6I   .+�5         Util.Controls.FButton  -   5          Name$ btnBind��5   %   $��3q�6   .��6L   绑定列表6R   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ gridList��5       $��1��6   $��3q�62      GridLinesVisibility$
 None=�6=   $��0q�6X      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6%   	   Header$	 成绩状态��61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6?   �� *PerformanceStatus+6g     5      $	 提交时间��6%   
 63   �� *
CommitTime+6T     5      $	 成绩��6%   
 61   �� *Achievement+6S     5      $	 操作��6%   $	 100 62   6@   5      5      5      