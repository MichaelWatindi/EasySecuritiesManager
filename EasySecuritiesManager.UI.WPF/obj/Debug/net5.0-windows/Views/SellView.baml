   M S B A M L   `   `   `  ����W  SEasySecuritiesManager.UI.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:EasySecuritiesManager.UI.WPF.Views"EasySecuritiesManager.UI.WPF.Views  5      ]3clr-namespace:EasySecuritiesManager.UI.WPF.Controls%EasySecuritiesManager.UI.WPF.Controls  5      1    +EasySecuritiesManager.UI.WPF.Views.SellView   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:EasySecuritiesManager.UI.WPF.Views     5      Hcontrols3clr-namespace:EasySecuritiesManager.UI.WPF.Controls     5        � 	Resources  5
          BooleanToVisibilityConverter��%   &	        �� 5   
   6'   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ cbAssets��5      $��0��5      $	��300��5      ��5      �� *pAssetListingViewModel.Assets+ �� SelectedItem 5      �� *SelectedAsset+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5       �� ��6$   �� *Symbol+�� 5!      $
��10 0q�6!   
���   �$��1 0 0 0q�6C   �� 5"      ��6$   �� *Shares+5#      5$      5&      �� 5)   
   $��1��6   $��0 10 0 0q�6!   $��Center=�5*      
���  �� � DataContext 5+      �� *ErrorMessageViewModel+��5-      �� *	Message+y�5.      �� *
HasMessage+ �� 	Converter# [  �� 51   
   $��2��6   $��0 10 0 0q�6!   $��Center=�52      
��� d � 53      �� *StatusMessageViewModel+��55      �� *	Message+y�56      �� *
HasMessage+# [  J   DEasySecuritiesManager.UI.WPF.Controls.SearchSymbolResultPanelControl  58   
   $��3��62   $��0 20 0 0q�6?   .��59      �� $��Center=�6   .+�5<      � $
��0 10q�6   .+�5=      �� $	��150��6    $��Shares to Sell��6,   �� 5>      $��50��6   ��6)   �� *SharesToSell+ �� UpdateSourceTrigger$ PropertyChanged=�5?      � 5B      $
��0 10q�6   .+�5C      �� $	��150��6    $��Price per share��6,   �� 5D      ��6    �� *
StockPrice+ �� StringFormat$ {0:C}��5E      �� 5H      $��Center=�6   $��32(�69   $
��0 10q�6G   ��6U   �� *
TotalPrice+$ {0:C}���� 5I      $
��0 10q�6   $
��20 5q�6'   $��24(�66   $
��Sell��6D   ��6S   �� *pSellStockCommand+5J      5K      5L      5M      