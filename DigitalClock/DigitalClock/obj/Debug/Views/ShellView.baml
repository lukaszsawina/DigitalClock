   M S B A M L   `   `   `  ����  DigitalClock"    DigitalClock.Views.ShellView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  	ShellView��5   	   $	��300��6   $	��600��6'    � WindowStyle$ SingleBorderWindow=�5   	    � 
ResizeMode$ NoResize=�5	   	   .��5   
   � 
���   � � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ 
ActiveItem��5      $��1��5      $��4��5      $��2��5      5      �� 5    
   -   5         ��Name$ LoadWordlClocks��5!      $��Zegary��5"      $��4��5#      $��0��6      MenuButtonTheme#��[  5$      5&      �� 5'      -   5        $ 	LoadAlarm��5(      $��Budzik��5)      $��4��5*      $��1��6   #��[  5+      5-      �� 5.   
   -   5        $ LoadStopWatch��5/      $��Stoper��50      $��4��51      $��2��6   #��[  52      54      �� 55   
   -   5        $ 	LoadTimer��56      $��Minutnik��57      $��4��58      $��3��6   #��[  59      5;      5?      5@      