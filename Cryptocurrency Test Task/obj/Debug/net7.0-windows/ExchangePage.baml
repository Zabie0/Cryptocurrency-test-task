   M S B A M L   `   `   `  ����S  OCryptocurrency Test Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Cryptocurrency_Test_TaskCryptocurrency_Test_Task  5      +    %Cryptocurrency_Test_Task.ExchangePage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:Cryptocurrency_Test_Task     5        N� Title$  ExchangePage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   �� -   5        $��MainPageButton��5      $��0��6'   $
��Main��67   ���	#FFDDDDDD$��22(�6]   6k   �� 5   
   -   5        $��CurrencyDetailsButton��5      $��1��6.   $��Details��6>   $��22(�6P   6^   �� 5   
   -   5        $��ExchangePageButton��5      $��Exchange��6+   $��2��6>   ���	#FFA5A5A5$��22(�6e   �� 5   
   -   5        $��SearchPageButton��5      $��3��6)   $��22(�69   $��Search��6G   6X   �� 5   
   -   5        $��CurrencyFromComboBox��5   �   $��1��6   $��Center=�6�   $��0,10,0,0q�6�   $��2��6�   $	��Top=�6�   $	��120��6�   ��6#   �� *availableCurrencies+ �� SelectedValue 6O   �� *CurrencyFrom+ �� Mode$ OneWayToSource=�6  �� 5   
   -   5        $��CurrencyToComboBox��5   �   $��2��6   $��Center=�6�   $��0,10,0,0q�6�   $��2��6�   $	��Top=�6�   $	��120��6�   ��6#   �� *availableCurrencies+ 6O   �� *
CurrencyTo+$ OneWayToSource=�6  �� 5   
   $��Convert��6   $��Center=�6"   $��2��6?   $	��Top=�6S   $��2��6k   $��	0,0,250,0q�6x   $��22(�6�   �� 5   
   $��Center=�6   $��2��6i   $	��Top=�6}   $��2��6�   $��	0,10,50,0q�6�   $��15(�6�   $	��100��6�   ��6/   ��  �� Path$ CurrencyAmount�$ OneWayToSource=�6�   �� 5   
   $��to��6   $��Center=�6   $��2��6:   $	��Top=�6N   $��2��6f   $��1��6s   $��0,0,0,0q�6�   $��22(�6�   �� 5    
   -   5        $��ExchangeResult��5       $��22(�6(    �� 
IsReadOnly$
 True��6f   $��1��6x   $��2��6�   $��2��6�   $��40q�6�   $��Center=�6�   ��66   �� $ ExchangeInfo�$ OneWay=�6�   5!      5#      