   M S B A M L   `   `   `  ����W  SEasySecuritiesManager.UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EasySecuritiesManager.UI.WPF.Views"EasySecuritiesManager.UI.WPF.Views  5      J FPasswordBoxMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null`Aclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVMPasswordBoxMVVM.Components 6M   5    /EasySecuritiesManager.UI.WPF.Views.RegisterView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:EasySecuritiesManager.UI.WPF.Views     5      X
componentsAclr-namespace:PasswordBoxMVVM.Components;assembly=PasswordBoxMVVM     6M   $��24(�5      ��5
      �� 5   
     �� ImageSource$%  /Resources/login-background.jpg��6    j� Stretch$ UniformToFill=�6C    �� Opacity$	 0.2Q�6[    � 	Resources 5          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      �� $��Center=�6   $��Center=�5        BrushPrimaryDarkBase#��[ 5      
������� �� CornerRadius$ 10��5      $��3q�5       �� Padding$ 50q�5      $��25q�5       J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      Color$ Black��6/   ._�5   
   � 	 � IsSharedSizeScope$
	 True��6   
 � RowDefinitions
 5       �� 5!      $
��auto �6    �� 5"      $
��auto �6    �� 5#      $
��auto �6    .+�5'      �� $��0��6   $��48(�6%   $��Center=�63   $��Easy Securities Manager��6P   �� 5*      $��1��6   $��18(�5+      $
��Thin"�5,      $��10q�5-      $��Center=�5.      $#��Easy to use portfolio manager��5/      � 51      $��2��6   $
��0 20q�6    
 52      �� 53      $
��auto �6$   �� 54      $
��auto �6$   �� 55      $
��auto �6$   �� 56      $
��auto �6$   �� 57      $
��auto �6$   �� 58      $
��auto �6$   �� 59      $
��auto �6$   �� 5:      $
��auto �6$   .+�5>      � $��0��6   $
��0 10q�6$    � ColumnDefinitions 5?      �� 5@       z� SharedSizeGroup$ LoginLabels��6+   $
��auto �6I   �� 5A      $	��300 �6+   .+�5E      �� $��0��6    $
��Name��60   �� 5F      $��1��6   $��20 0 0 0q�5G      ��5H      �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�5J      � 5M      $��1��6   $
��0 10q�6$    5N      �� 5O      $ LoginLabels��6+   $
��auto �6I   �� 5P      $	��300 �6+   .+�5T      �� $��0��6    $��Email��60   �� 5U      $��1��6   $��20 0 0 0q�5V      ��5W      �� *Email+$ PropertyChanged=�5Y      � 5\      $��2��6   $
��0 10q�6$    5]      �� 5^      $ LoginLabels��6+   $
��auto �6I   �� 5_      $	��300 �6+   .+�5c      �� $��0��6    $��Username��60   �� 5d      $��1��6   $��20 0 0 0q�5e      ��5f      �� *
Username+$ PropertyChanged=�5h      � 5k      $��3��6   $
��0 10q�6$    5l      �� 5m      $ LoginLabels��6+   $
��auto �6I   �� 5n      $	��300 �6+   .+�5r      �� $��0��6!   $��Password��61   4  .PasswordBoxMVVM.Components.BindablePasswordBox  5s      -   5          Name$ 
pbPassWord��5t   !   $��20 0 0 0q�5u   !   $��1��5v   !      Password 5w   !   �� *
Password+5x      � 5{      $��4��6   $
��0 10q�6$    5|      �� 5}      $ LoginLabels��6+   $
��auto �6I   �� 5~      $	��300 �6+   .+�5�      �� $��0��6!   $��Password��61     5�      -   5        $ pbConfirmPassWord��5�   !   $��20 0 0 0q�5�   !   $��1��5�   !    5�   !   �� *ConfirmPassword+5�      �� 5�      $��5��6   $��Center=�5�       �� 	IsDefault$
 True��5�      $��10q�5�      $��Register��5�      ��5�      �� *pRegisterCommand+5�      �� 5�      $��6��6   $��Center=�5�      $��0 10 0 0q�5�      $-��'Already have an account? Login instead.��5�      
������ 
����  ���5�      �� *ViewLoginCommand+5�      �� 5�      $��7��6   $��Center=�5�      
���  �� � DataContext 5�      �� *ErrorMessageViewModel+��5�      �� *	Message+y�5�      �� *
HasMessage+ �� 	Converter# [  5�      5�      5�      5�      