   M S B A M L   `   `   `  ����G  CDigitalClock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DigitalClock.ViewsDigitalClock.Views  5      "    DigitalClock.Views.AlarmView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:DigitalClock.Views     5      ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      .��5
      � .+�5   
   � -   5          �Name$  AlarmListIsVisible��5       � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $��* �6#   �� 5      $
��auto �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      $
��auto �6    �� 5      $��* �6    .+�5      �� -   5         ��Name$ 	EditClock��5      $��Edytuj��5      $��0��5      $��0��6      TopMenuButtonTheme#��[  5      $��0q�5      �� 5      -   5        $ NewAlarm��5!      $��Dodaj��5       $��2��5"      $��0��6   #��[  5#      $��0q�5$      �� 5(      $��1��6   $��3��5)      $��Alarm��5*      ���#fff$
��Bold"�5,      $��40(�5-      $��	4 10 0 10q�5.      �� 50      $��2��6   $��3��51      
������ 
������ $��Hidden=�55      $��Hidden=�56      ��52      ��  �� Path$ Alarms���57      �� 58      .R�59      ��  �� Orientation$ 
Horizontal=�6%   .+�5:      �� $	��200��6)   .+�5;   "   �� ���#fff$��60(�5=   (   ��5;   ,   �� $
 time�5=   (   �� 5>   "   $��Alarm��6,   ���#fff$��20(�5@   (   5A      �� 5B      ���#ff9900$��20(�6^   
������ $��20q�6�   $��0q�6�     Caliburn.Micro.Message   Attach$5 /[Event Click] = [Action AlarmOff($dataContext)]��5C   %   ��5B   %   �� $ 
ButtonText�5C   %   5D      5E      5G      5H      � 5I   
   -   5        $  AlarmAddIsVisible��5I       5J      �� 5K      $
��auto �6#   �� 5L      $��* �6#   �� 5M      $
��auto �6#    5O      �� 5P      $
��auto �6    �� 5Q      $
��auto �6    �� 5R      $��* �6    .+�5U      �� -   5        $ CloseNewAlarm��5V      $��Anuluj��5W      $��0��5X      $��0��6   #��[  5Y      $��0q�5Z      �� 5]      -   5        $ AddNewAlarm��5_      $��Zachowaj��5^      $��2��5`      $��0��6   #��[  5a      $��0q�5b      �� 5e      -   5         ��Name$ TimeSelectIsVisible��5e   ;   $��1��6   $��3��6'   .+�5f      :  4System.Windows.Controls.Primitives.DatePickerTextBox  $��0 100q�6$   $��3��6_   $��Center=�6s   $��Center=�6�    �� TextAlignment$ Center=�6�   
������ ���#fff$��60(�5h       ��5f   3   �� *NewAlarmClock+	 �� Mode$	 TwoWay=�5h       5i      5k      5l      5m      