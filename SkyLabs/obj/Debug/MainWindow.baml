   M S B A M L   `   `   `  ����B  >SkyLabs, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:SkyLabsSkyLabs  5   	       SkyLabs.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TFontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   !localclr-namespace:SkyLabs  5   	   $	��740��5      $
��1280��6'     � WindowStartupLocation$  CenterScreen=�64    � WindowStyle$
 None=�5	   	    � AllowsTransparency . 
������ .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   ��  �� CornerRadius$ 	10 0 0 10��6   ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   .��5      �  � Color$ #223266��6#    � Offset$ 0.097Q�63   � 5      $ Black��6#   $ 1Q�61   5      5      �� 5   
   .+�5      �� 	 �� Orientation$	 
Horizontal=�6   $��Center=�62   $��0 35 0 0q�6O   .+�5      �� $ 10��6   $��40��6+   $��40��66   ��5      �� 5      $	 0,0&�6.   $	 1,2&�6?   .��5      � $ #7f7cf1��6+   $ 0Q�6;   � 5       $ Black��6+   $ 1Q�69   � 5!      $ 	#FF121223��6+   $ 0.483Q�6=   5"      ._�5%      �� $��SL��6    ���#ffffff$��22(�6?   $��SemiBold"�6M   
 �� TextAlignment$
 Center=�5&       $��Center=�67   $��3 0 0 2q�6R   5(      �� 5*      $��10 0 0 0q�6   $��Center=�6/   .+�5+      �� $��Sky Labs��6    $��15(�60   
�������6>   5,      5-      �� 5.      $	��0.8��6   $��20 30q�6%   ���#46558a64   �� 51      -   5         ��Name$ 
homeButton��51         
menuButton#��[  6)   .��52      �� $	 
Horizontal=�6   .+�53      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.6.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]   Icon$
 Home=�6#     menuButtonIcon#��[ 6/   �� 54      $
��Home��6      menuButtonText#��[ 6,   55      56      �� 58      -   5        $ iaddPatientButton��58      #��[  60   .��59      �� $	 
Horizontal=�6   .+�5:        $
 Plus=�6#   #��[ 6/   �� 5;      $��Add Patient��6    #��[ 63   5<      5=      �� 5?      -   5        $ enterResultsButton��5?      #��[  61   .��5@      �� $	 
Horizontal=�6   .+�5A        $ Bacteria=�6#   #��[ 63   �� 5B      $��Enter Results��6    #��[ 65   5C      5D      �� 5F      -   5        $ viewResults��5F      #��[  6*   .��5G      �� $	 
Horizontal=�6   .+�5H        $ Display=�6#   #��[ 62   �� 5I      $��View Results��6    #��[ 64   5J      5K      �� 5M      -   5        #��[  5M      .��5N      �� $	 
Horizontal=�6   .+�5O        $ SignOut=�6#   #��[ 62   �� 5P      $��Log Off��6    #��[ 6/   5Q      5R      5U      �� 5W   
   $��36,580,36,26q�6   $;��5\Images\sky-labs-high-resolution-logo-transparent.png��6&   �� 5Y   
   $��1��6   $ 	0 10 10 0��6!   ��5Z      �� 5[      $	 1,0&�6&   $	 0,1&�67   .��5\      � $ #41518f��6#   $ 0.142Q�63   � 5]      $ Black��6#   $ 1Q�61   5^      ._�5`       � -   5        $��	Container��5a      $��1��5`      $��45 45q�5b        � NavigationUIVisibility$ Hidden=�5c      5d      5e      5f      