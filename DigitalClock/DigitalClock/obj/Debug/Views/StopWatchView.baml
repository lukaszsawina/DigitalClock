   M S B A M L   `   `   `  ����G  CDigitalClock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:DigitalClock.ViewsDigitalClock.Views  5      &     DigitalClock.Views.StopWatchView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:DigitalClock.Views     5      ^ ZCaliburn.Micro.Platform, Version=4.0.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      .��5
      �   � ColumnDefinitions  5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ Measure��5      $��3��5      $��00:00,00��5      $��60(�5      $��	0 80 0 60q�5      ���#fff$��Center=�5      $��center=�5      �� 5    
   -   5         ��Name$ RoundIsVisible��5'      $��1��5       $
��10 0q�5!      $��2q�5"      ���#1a1a1a �� CornerRadius$	 360��5$      $��70��5%      $��70��5&      ._�5(      � $��60��6   $��60��6   .+�5)      A� ���#1a1a1a6   �� 5*         CircleButton#��[  6   $��Runda��6?     Caliburn.Micro.Message   Attach$* $[Event Click] = [Action AddRound()] ��6O   ���#7373736�   5+      5,      �� 5.   
   -   5        $ ResetButtonIsVisible��55      $��1��5.      $
��10 0q�5/      $��2q�50      ���#1a1a1a$	 360��52      $��70��53      $��70��54      ._�56      � $��60��6   $��60��6   .+�57      A� ���#1a1a1a6   �� 58      #��[  6   $��Wyzeruj��6?   $2 ,[Event Click] = [Action ResetMeasureTime()] ��6Q   ���#7373736�   59      5:      �� 5<   
   -   5        $ StartButtonIsVisible��5D      $��1��5<      $��2��5=      $
��10 0q�5>      $��2q�5?      ���#004d00$	 360��5A      $��70��5B      $��70��5C      ._�5F      � $��60��6   $��60��6   .+�5G      A� ���#004d006   �� 5H      #��[  6   $��Start��6?   $2 ,[Event Click] = [Action StartMeasureTime()] ��6O   5I      5J      �� 5L   
   -   5        $ StopButtonIsVisible��5T      $��1��5L      $��2��5M      $
��10 0q�5N      $��2q�5O      ���#004d00$	 360��5Q      $��70��5R      $��70��5S      ._�5V      � $��60��6   $��60��6   .+�5W      A� ���#004d006   �� 5X      #��[  6   $
��Stop��6?   $0 *[Event Click] = [Action StopMeasureTime()]��6N   5Y      5Z      �� 5^   
   $��2��6   $��3��5_      
������ $��0q�5b      $��0 20 0 0q�5c      $��Hidden=�5d      $��Hidden=�5e      ��5`      ��  �� Path$ Rounds���5f      �� 5g      .R�5h      ��  �� Orientation$ 
Horizontal=�6!   .+�5i      �� $	��100��6$   ��61   �� $ Color���6S   �� $ RoundNumber� �� Mode$ OneWay=��� 5j      $	��170��6$   	 �� TextAlignment$	 Right=�61   ��6G   �� $ Color���6i   �� $
 Time�$ OneWay=�5k      5l      5n      5q      5r      