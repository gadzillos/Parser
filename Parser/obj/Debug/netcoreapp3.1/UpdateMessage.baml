   M S B A M L   `   `   `  ����A  =Parser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ParserParser  5   	       Parser.UpdateMessage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Parser     5   	     � Title$  UpdateMessage��5   	   $	��450��6   $	��800��6,   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5   
   �� -   5         ��Name$ ThreatsChanged��5      $��1��6,   $��1��6<   $	��5,5q�6I   $��22(�6�   ��6V   ��  �� Source$ totalThreatsChanged��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ ChangesGrid��5         AutoGenerateColumns$ False��5   ;   $��14(�6W   $��1��5   (   $��2��68   $��3��6E   $y�Visible=�6Y   $��5,5,5,5q�6n      CanUserAddRows$ False��5         CanUserDeleteRows$ False��6*   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6D   ��5      �� $ Changes��
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width$
 auto 6N   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
ThreatId+6N     5      $ Изменение��6%   $
 auto 6^    68   �� *ChangedColumnName+6^     5       $ Было��6%   $ * 6O    63   �� *	OldData+6O     5!      $ 
Стало��6%   $ * 6P    64   �� *	NewData+6P   5#      5$      5%      