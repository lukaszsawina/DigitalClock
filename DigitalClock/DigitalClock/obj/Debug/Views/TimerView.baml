   M S B A M L   `   `   `  ����  DigitalClock"    DigitalClock.Views.TimerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ TimeSelectIsVisible��5   +   $��3��6   .+�5      :  4System.Windows.Controls.Primitives.DatePickerTextBox  $��0 100q�6    $��3��6S   $��Center=�6g   $��Center=�6�    �� TextAlignment$ Center=�6�   
������ ���#fff$��60(�5       ��5   /   �� *Timer+ �� Mode$ TwoWay=�5       5      �� 5   
   -   5        $ TimeLeftIsVisible��5      $��3��61   .+�5      �� $��0 100 0 102q�5      $��60(�5       ���#fff$��Center=�5"      $��center=�5#      ��5      �� *Timer+$ TwoWay=�5#      5$      �� 5'   
   -   5         ��Name$ RoundIsVisible��5.      $��1��5'      $
��10 0q�5(      $��2q�5)      ���#1a1a1a �� CornerRadius$	 360��5+      $��70��5,      $��70��5-      ._�5/      � $��60��6   $��60��6   .+�50      A� ���#1a1a1a6   �� 51         CircleButton#��[  6B   $��Wyzeruj��6h     Caliburn.Micro.Message   Attach$' ![Event Click] = [Action Reset()] ��6z   ���#737373{�6   �� *ReturnButtonEnable+6�   52      53      �� 55   
   -   5        $ StartButtonIsVisible��5=      $��1��55      $��2��56      $
��10 0q�57      $��2q�58      ���#004d00$	 360��5:      $��70��5;      $��70��5<      ._�5?      � $��60��6   $��60��6   .+�5@      A� ���#004d006   �� 5A      #��[  6   $��Start��6?   $, &[Event Click] = [Action StartTimer()] ��6O   5B      5C      �� 5E   
   -   5        $ StopButtonIsVisible��5M      $��1��5E      $��2��5F      $
��10 0q�5G      $��2q�5H      ���#004d00$	 360��5J      $��70��5K      $��70��5L      ._�5O      � $��60��6   $��60��6   .+�5P      A� ���#004d006   �� 5Q      #��[  6   $
��Stop��6?   $* $[Event Click] = [Action StopTimer()]��6N   5R      5S      �� 5U   
   -   5        $ ReturnButtonIsVisible��5]      $��1��5U      $��2��5V      $
��10 0q�5W      $��2q�5X      ���#004d00$	 360��5Z      $��70��5[      $��70��5\      ._�5_      � $��60��6   $��60��6   .+�5`      A� ���#004d006   �� 5a      #��[  6   $��Wznów��6?   $, &[Event Click] = [Action ReturnTimer()]��6O   5b      5c      5f      5g      