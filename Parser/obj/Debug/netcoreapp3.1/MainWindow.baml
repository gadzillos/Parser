   M S B A M L   `   `   `  ����A  =Parser, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ParserParser  5   	       Parser.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Parser     5   	   $��Segoe UI Light)�5      $��22(�66     � Title$  Parser��5   	   $	��450��6   $
��1000��6%    � Icon$ /icons8_dragon.ico��62   
�������.��5	      �  � ColumnDefinitions 5
   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��10 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $��10 �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Table��5         AutoGenerateColumns$ False��5   ;   $��14(�6W      MaxColumnWidth$	 300Q�6e   $��1��5   "   $��3��62   $��7��6?   $y�Visible=�6S   $��5,5,5,5q�6h      CanUserAddRows$ False��5          CanUserDeleteRows$ False��6*   ��5      �� 	 �� Source$	 Threats��
   Columns
 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
ThreatId+  5#      $ Наименование��6%    6;   �� *
ThreatName+  5$      $ Описание��6%    67   �� *Description+  5%      $ Источник��6%    67   �� *Source+  5&      $) #Объект воздействия��6%    6A   �� *Target+4  .System.Windows.Controls.DataGridCheckBoxColumn  5'      $= 7Нарушение конфиденциальности��6)    6O   �� *ConfidentialityBreach+  5(      $/ )Нарушение целостности��6)    6H   �� *IntegrityViolation+  5)      $/ )Нарушение доступности��6)    6H   �� *AccessViolation+5+      �� 5-   
   -   5         ��Name$ ViewData��5-      $��1��6#   $��2��63   $��	View Data��6@   $	��5,0q�5.      6   �� 50   
   -   5        $ RefreshFile��50      $��2��6&   $��2��66   $��Refresh Data��6C   $	��5,0q�51      6   �� 53   
   -   5        $ PreviousPage��53      $��3��6'   $��2��67   $��Previous Page��6D   $	��5,0q�54      $y�	Collapsed=�69   �� 56   
   -   5        $ NextPage��56      $��4��6#   $��2��63   $��	Next Page��6@   $	��5,0q�57      6   �� 59   
   -   5        $ ViewMode��59      $��5��6#   $��2��63   $��ViewMode��6@   $	��5,0q�5:      6   �� 5<   
   -   5        $
 Save��5<      $��6��6   $��2��6/   $
��Save��6<   $	��5,0q�5=      $y�	Collapsed=�61   � 5?   
   -   5         �Name$ LoadProgress��5?      $��1��6,   $��6��6<   $��4��6P   $y�	Collapsed=�5@      $��20��6-   $��10��6<   5A      5C      