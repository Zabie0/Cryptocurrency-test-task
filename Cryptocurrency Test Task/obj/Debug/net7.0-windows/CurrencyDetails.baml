   M S B A M L   `   `   `  ����S  OCryptocurrency Test Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Cryptocurrency_Test_TaskCryptocurrency_Test_Task  5      .    (Cryptocurrency_Test_Task.CurrencyDetails   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Cryptocurrency_Test_Task     5        N� Title$  CurrencyDetails��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��MainPageButton��5      $��0��6'   $
��Main��67   $��22(�6a   �� 5   
   -   5        $��CurrencyDetailsButton��5      $��1��6.   $��Details��6>   ���	#FFA5A5A5$��22(�6g   �� 5   
   -   5        $��ExchangePageButton��5      $��Exchange��6+   $��2��6>   $��22(�6m   �� 5   
   -   5        $��SearchPageButton��5      $��3��6)   $��22(�69   $��Search��6G   6X   �� 5   
   -   5        $��MarketInfoListBox��5      $��Center=�6+   $��2��6t   $��1��6�   ��6O   ��  �� Path$ Markets�6�   �� 5   
   $��1��6   $��1��6   $��Center=�6-   $��Center=�6O   $��Markets list:��6s   $��22(�6�   �� 5   
   -   5        $��CurrencyDetailsTextBox��5      $��0q�6g   $��2��6{   $��Center=�6�   $
��Left=�6�   $��2��6�   $��2��6�   $��22(�6�    �� 
IsReadOnly$
 True��6�   ��60   �� $ InfoForDetailsLabel� �� Mode$ OneWay=�6�   �� 5   
   $��Choose currencies:��6   $��Center=�6-   $��Center=�6Q   $��22(�6s   $��0��6�   $��1��6�   �� 5   
   -   5        $��CurrencyFilterComboBox��5       �� SelectedIndex$ 0��61   $	��Top=�6~   $��10q�6�   $��0��6�   $��2��6�   $	��120��6�   $��25��6�    �� SelectedValue 6C   �� *SelectedBox+$ OneWayToSource=���6�   �� *availableCurrencies+5       5!      5"      