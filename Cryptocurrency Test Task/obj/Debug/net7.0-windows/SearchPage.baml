   M S B A M L   `   `   `  ����S  OCryptocurrency Test Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Cryptocurrency_Test_TaskCryptocurrency_Test_Task  5      )    #Cryptocurrency_Test_Task.SearchPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Cryptocurrency_Test_Task     5        N� Title$  
SearchPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��MainPageButton��5      $��0��6'   $
��Main��67   ���	#FFDDDDDD$��22(�6x   �� 5   
   -   5        $��CurrencyDetailsButton��5      $��1��6.   $��Details��6>   $��22(�6n   �� 5   
   -   5        $��ExchangePageButton��5      $��Exchange��6+   $��2��6>   ���	#FFDDDDDD$��22(�6�   �� 5   
   -   5        $��SearchPageButton��5      $��3��6)   ���	#FFA5A5A5$��Search��6P   $��22(�6a   �� 5   
   $��Enter currency name/code:��6   $��1��64   $��0��6A   $��16(�6Q   $��Center=�6_   $��Center=�6|   �� 5   
   $��Search results:��6   $��1��6*   $��1��67   $��20(�6G   $��Center=�6U   �� 5   
   -   5        $��SearchTextBox��5      $��10q�6'   $��2��63    �� TextWrapping$
 Wrap=�6x   $	��Top=�6�   $	��120��6�   ��6@   ��  �� Path$ SearchedText� �� Mode$ OneWayToSource=�6�   �� 5   
   -   5        $��CurrenciesListBox��5      $��2��5       $��1��6   ��5   +   �� $ 
Currencies� �� SelectedItem 5      �� $ SelectedCurrency�$ OneWayToSource=�5       �� 5!   
   -   5        $��0��5!      $��2��6!   $��Search��6.   $��40q�6?   $	��100��6K   $��20��6W   $	��Top=�6c   6{   5"      5#      