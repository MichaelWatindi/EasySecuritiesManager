   M S B A M L   `   `   `  ����W  SEasySecuritiesManager.UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EasySecuritiesManager.UI.WPF.Views"EasySecuritiesManager.UI.WPF.Views  5      ]3clr-namespace:EasySecuritiesManager.UI.WPF.Controls%EasySecuritiesManager.UI.WPF.Controls  5      0    *EasySecuritiesManager.UI.WPF.Views.BuyView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:EasySecuritiesManager.UI.WPF.Views     5      Hcontrols3clr-namespace:EasySecuritiesManager.UI.WPF.Controls     5        � 	Resources  5
          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   $��Center=�6!   .+�5      �� $	��100��6   $��5q�6"   ��6.   �� *Symbol+ �� UpdateSourceTrigger$ PropertyChanged=��� 5      $��5 0 0 0q�6   $��Search��6&   ��67   �� *SearchSymbolCommand+5      �� 5!   
   $��1��6   $��0 10 0 0q�5$      $��Center=�5%      
���  �� � DataContext 5"      �� *ErrorMessageViewModel+��5#      �� *	Message+y�5'      �� *
HasMessage+ �� 	Converter# [  �� 5*   
   $��2��6   $��0 10 0 0q�5-      $��Center=�5.      
��� d � 5+      �� *StatusMessageViewModel+��5,      �� *	Message+y�50      �� *
HasMessage+# [  J   DEasySecuritiesManager.UI.WPF.Controls.SearchSymbolResultPanelControl  52   
   $��3��62   $��0 20 0 0q�6?   .��53      �� $��Center=�6   .+�56      � $
��0 10q�6   .+�57      �� $	��150��6    $��Shares to Buy��6,   �� 58      $��50��6   ��6)   �� *SharesToBuy+$ PropertyChanged=�59      � 5<      $
��0 10q�6   .+�5=      �� $	��150��6    $��Price per share��6,   �� 5>      ��6    �� *
StockPrice+ �� StringFormat$ {0:C}��5?      �� 5B      $��Center=�6   $��32(�69   $
��0 10q�6G   ��6U   �� *
TotalPrice+$ {0:C}���� 5C      $
��0 10q�6   $
��20 5q�6'   $��24(�66   $	��Buy��6D   ��6R   �� *BuyStockCommand+5D      5E      5G      5H      