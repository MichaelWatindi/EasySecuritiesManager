   M S B A M L   `   `   `  ����W  SEasySecuritiesManager.UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:EasySecuritiesManager.UI.WPF.Controls%EasySecuritiesManager.UI.WPF.Controls  5      m;clr-namespace:EasySecuritiesManager.UI.WPF.State.Navigators-EasySecuritiesManager.UI.WPF.State.Navigators  5      a5clr-namespace:EasySecuritiesManager.UI.WPF.ViewModels'EasySecuritiesManager.UI.WPF.ViewModels  5      a5clr-namespace:EasySecuritiesManager.UI.WPF.Converters'EasySecuritiesManager.UI.WPF.Converters  5	      @    :EasySecuritiesManager.UI.WPF.Controls.NavigationBarControl   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:EasySecuritiesManager.UI.WPF.Controls     5      Knav;clr-namespace:EasySecuritiesManager.UI.WPF.State.Navigators     5      Dvm5clr-namespace:EasySecuritiesManager.UI.WPF.ViewModels     5      L
converters5clr-namespace:EasySecuritiesManager.UI.WPF.Converters     5	        � 	Resources  5      L   FEasySecuritiesManager.UI.WPF.Converters.EqualValueToParameterConverter "  EqualValueToParameterConverter��%   &	          5   
   64   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6     BrushPrimaryLightBase#��[ 6   .+�5      �� $
��1000��6   $��0��6(    �� Padding$ 10q�65   $��28(�6B   
�������$��Easy Securities Manager��6c   5      � 5   
   $��1��6    �� EdgeMode$ Aliased=�6     BrushPrimaryDarkBase#��[ 6=     5       �� 
TargetType  NavBarButton �� BasedOn��%0   '	�       7  �� 5       " 	�6   8   61   5!       � ColumnDefinitions 5#      �� 5$      $
��auto �6#   �� 5%      $
��auto �6#   �� 5&      $
��auto �6#   �� 5'      $
��auto �6#   �� 5(      $��* �6#   �� 5)      $
��auto �6#   .+�5-      	� $��0��6   $
��Home��5.      <   6EasySecuritiesManager.UI.WPF.State.Navigators.ViewType   Home#��Z 51       d� 	IsChecked 5/      �� *CurrentViewModel+	 �� 	Converter#	 [  
 �� Mode$
 OneWay=� �� ConverterParameter;   5EasySecuritiesManager.UI.WPF.ViewModels.HomeViewModel"  ��50      �� *UpdateCurrentViewModelCommand+51      	� 54      $��1��6   $��	Portfolio��55         	Portfolio#��Z 58       56      �� *CurrentViewModel+#	 [  $
 OneWay=�@   :EasySecuritiesManager.UI.WPF.ViewModels.PortfolioViewModel"  ��57      �� *UpdateCurrentViewModelCommand+58      	� 5;      $��2��6   $	��Buy��6*   
   Buy#��Z 5>       5<      �� *CurrentViewModel+#	 [  $
 OneWay=�:   4EasySecuritiesManager.UI.WPF.ViewModels.BuyViewModel"  ��5=      �� *UpdateCurrentViewModelCommand+5>      	� 5A      $��3��6   $
��Sell��6*      Sell#��Z 5D       5B      �� *CurrentViewModel+#	 [  $
 OneWay=�;   5EasySecuritiesManager.UI.WPF.ViewModels.SellViewModel"  ��5C      �� *UpdateCurrentViewModelCommand+5D      �� 5G      $��4��6   $�� ��6(   	� 5J      $��5��6   $	��⚙��6*      Settings#��Z 5M       5K      �� *CurrentViewModel+#	 [  $
 OneWay=�?   9EasySecuritiesManager.UI.WPF.ViewModels.SettingsViewModel"  ��5L      �� *UpdateCurrentViewModelCommand+5M      5N      5O      5P      