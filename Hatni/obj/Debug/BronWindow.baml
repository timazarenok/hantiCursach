   M S B A M L   `   `   `  ����@  <Hatni, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HatniHatni  5   	       Hatni.BronWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Hatni     5   	     � Title$  
BronWindow��5   	   $	��850��6   $	��800��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ Excel��5
      $ ��Отчет в эксель��6    $	��120��69   $��30��6E   $	��Top=�6Q   $
��Left=�6i   $��	20,20,0,0q�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Table��5         AutoGenerateColumns .  $	��750��6>   $	��300��6J   $	��Top=�6W   $��0, 100, 0, 0q�6o      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   ��  �� Path$ ID�  5      $ Email��6%   $	 100 64    6@   �� $ Email�  5      $ Телефон��6%   $	 150 66    6B   �� $ 	Telephone�  5      $ Стол��6%   $ 50 63    6>   �� $ Number�  5      $ Мероприятие��6%   $	 200 6:    6F   �� $
 Name�  5      $ Дата��6%   $	 100 63    6?   �� $
 Date�  5      $ 
Время��6%   $ 70 64    6?   �� $
 Time�5      �� 5   
   $��Center=�6   $��Center=�6+   $��0,50,0,0q�6H   .��6Z   kiВведите ID брони чтобы просмотреть блюда которые заказали6�   �� 5   
   -   5        	 ��Name$	 IdBron��5      $	��120��6"   $��30��6.   $��	0,150,0,0q�6:   6M   �� 5   
   -   5        $ Submit��5      $	��200��6!   $��Просмотреть��6-   $��30��6C   $��	0,250,0,0q�6O   6b     5   
   -   5        $ Products��5       .  $	��250��6A   $	��260��6M   $��Center=�6Z   $��0, 550, 0, 0q�6u    5        5      $ ID��6%   $	 100 61    6=   �� $
 Name�  5      $ Email��6%   $	 100 64    6@   �� $ Price�5      5      5       