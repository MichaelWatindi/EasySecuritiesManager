   M S B A M L   `   `   `  ����W  SEasySecuritiesManager.UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EasySecuritiesManager.UI.WPF.Views"EasySecuritiesManager.UI.WPF.Views  5      2    ,EasySecuritiesManager.UI.WPF.Views.LoginView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:EasySecuritiesManager.UI.WPF.Views     5      $��24(�5      ��5
      �� 5   
     �� ImageSource$%  /Resources/login-background.jpg��6    j� Stretch$ UniformToFill=�6C    �� Opacity$	 0.2Q�6[    � 	Resources 5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �� $��Center=�6   $��Center=�5        BrushPrimaryDarkBase#��[ 5      
������� �� CornerRadius$ 10��5      $��3q�5       �� Padding$ 50q�5      $��25q�5       J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      Color$ Black��6/   ._�5   
   � 	 � IsSharedSizeScope$
	 True��6   
 � RowDefinitions
 5      �� 5       $
��auto �6    �� 5!      $
��auto �6    �� 5"      $
��auto �6    .+�5&      �� $��0��6   $��48(�6%   $��Center=�63   $��Easy Securities Manager��6P   �� 5)      $��1��6   $��18(�5*      $
��Thin"�5+      $��10q�5,      $��Center=�5-      $#��Easy to use portfolio manager��5.      � 50      $��2��6   $
��0 20q�6    
 51      �� 52      $
��auto �6$   �� 53      $
��auto �6$   �� 54      $
��auto �6$   �� 55      $
��auto �6$   �� 56      $
��auto �6$   .+�5:      � $��0��6   $
��0 10q�6$    � ColumnDefinitions 5;      �� 5<       z� SharedSizeGroup$ LoginLabels��6+   $
��auto �6I   �� 5=      $	��300 �6+   .+�5A      �� $��0��6    $��Username��60   �� 5B      $��1��6   $��20 0 0 0q�5C      ��5D      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5E      � 5H      $��1��6   $
��0 10q�6$    5I      �� 5J      $ LoginLabels��6+   $
��auto �6I   �� 5K      $	��300 �6+   .+�5O      �� $��0��6!   $��Password��61   G� 5P      -   5         G�Name$ 
pbPassWord��5P   "   $��20 0 0 0q�5Q   "   $��1��5R   "   5S      �� 5V      -   5        $��2��5V      $��Center=�5W       �� 	IsDefault$
 True��5X      $��10q�5Y      $��Login��5Z      5[      �� 5^      $��3��6   $��Center=�5_      $��0 10 0 0q�5`      $��Register��5a      
������ 
����  ���5b      �� *ViewRegisterCommand+5d      �� 5g      $��4��6   $��Center=�5h      
���  �� � DataContext 5i      �� *ErrorMessageViewModel+��5k      �� *	Message+y�5l      �� *
HasMessage+ �� 	Converter# [  5m      5o      5p      5q      