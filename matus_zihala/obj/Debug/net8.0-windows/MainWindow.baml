   M S B A M L   `   `   `  ����G  Cmatus_zihala, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:matus_zihalamatus_zihala  5   	       matus_zihala.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:matus_zihala     5   	     � Title$   Weather App - matus_zihala��5   	   $	��500��6,   $	��900��69   ���#232946.��5	      � $��30q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,30q�6;   $��Center=�6M   $��Center=�6h   ���#232946   DropShadowEffect J� Effect# �   6�   .+�5      �� -   5         ��Name$ LatitudeLabel��5      $��	Latitude:��6/   $��Center=�6@   $��0,0,8,0q�6[   ���#eebbc3$
��Bold"�6�   $��16(�6�    �� TextAlignment$ Center=�6�   $��80��6�   �� 5      -   5         ��Name$ LatitudeTextBox��5      $	��110��6/   $��0,0,20,0q�6;   ���#121629���#eebbc3���#eebbc3$��16(�6�   $	��6,2q�6�   $��2q�6�   $��48.7164��6�   �� 5      -   5        $ LongitudeLabel��5      $��
Longitude:��60   $��Center=�6B   $��0,0,8,0q�6]   ���#eebbc3$
��Bold"�6�   $��16(�6�   $ Center=�6�   $��90��6�   �� 5      -   5        $ LongitudeTextBox��5      $	��110��60   $��0,0,20,0q�6<   ���#121629���#eebbc3���#eebbc3$��16(�6�   $	��6,2q�6�   $��2q�6�   $��21.2611��6�   �� 5      -   5        $ 
EmailLabel��5      $��Email pre API:��6,   $��Center=�6B   $��0,0,8,0q�6]   ���#eebbc3$
��Bold"�6�   $��16(�6�   $ Center=�6�   $	��120��6�   �� 5      -   5        $ EmailTextBox��5      $	��230��6,   $��0,0,20,0q�68   ���#121629���#eebbc3���#eebbc3$��16(�6�   $	��6,2q�6�   $��2q�6�   $��example@gmail.com��6�   �� 5      -   5         ��Name$ FetchWeatherButton��5      $��Get Weather��61   ���#eebbc3���#232946$
��Bold"�6�   $
��16,8q�6�   $��16(�6�   $��0q�6�    � Cursor$
 Hand��6�   $��Stretch=�6�   5      �� 5   
   -   5        $ StatusTextBlock��5      $��1��6-   ���#ffadad$��0,0,0,10q�6O   $
��Bold"�6a   $��16(�6s   $��Stretch=�6�   $ Center=�6�   �� 5   
   $��2��6   ���#121629	 �� CornerRadius$	 30��63   
 �� Padding$
 40q�6E   # �   6R   ._�5      �� $��Stretch=�6   $��Stretch=�67   .+�5      �� $��Weather Forecast��6   $
��Bold"�64   $��28(�6F   ���#eebbc3$��0,0,0,28q�6i   $��Center=�6{   $ Center=�6�   �� 5      $ 
Horizontal=�6   $��Center=�66   $��0,0,0,18q�6S   .+�5      � $��80��6   $��80��6&   .+�5      A� -	   5         A�Name$ LoadingEllipse��5   "   $��80��6:   $��80��6E   ���#eebbc3$y�	Collapsed=�6`   z�5      �� 5    "   -
   5        LoadingRotate�� �� Angle$ 0Q�5    I    �� CenterX$ 40Q�6S    �� CenterY$ 40Q�6`   5"      �� 5#      -   5        $ WeatherIconTextBlock��5#   $   $��64(�6B   $��Center=�6P   $��Center=�6m   5$      5%      �� 5&      -   5        $ WeatherResultTextBlock��5&      $
��Wrap=�6<   ���#fffffe$��22(�6e   $��Stretch=�6s   $ Center=�6�   $��0,0,0,10q�6�   5'      5(      5)       � 	Resources 5*      3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth   Opacity��%U   &	          5+   
   $ #000000��64   $ 20Q�6D   $ 0Q�6T   $	 0.5Q�6d   5,      5-      