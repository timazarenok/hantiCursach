   M S B A M L   `   `   `  ����@  <Hatni, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HatniHatni  5   	       Hatni.MyBronWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Hatni     5   	     � Title$  MyBronWindow��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Table��5
         AutoGenerateColumns .  $	��400��6>   $	��300��6J      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 30 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ��  �� Path$ ID�6M     5      $ Стол��6%   $ 60 6S    63   �� $ Number�6S     5      $ Мероприятие��6%   $	 200 6X    6:   �� $
 Name�6X     5      $ 
Время��6%   $ 70 6R    64   �� $
 Time�6R   5      �� 5   
   $��ID��6   $��Right=�6   $	��Top=�6:   $��0,100,100,0q�6R   �� 5   
   -   5         ��Name$ ID��5      $	��100��6   $��25��6*   $��Right=�66   $	��Top=�6R   $��
0,140,55,0q�6j   �� 5   
   -   5        	 ��Name$	 Button��5      $	��150��6!   $��25��6-   $!��Отменить бронь��69   $��Right=�6R   $	��Top=�6n   $��
0,180,20,0q�6�   6�   �� 5   
   -   5        $	 
AddProduct��5      $	��150��6%   $��25��61   $��Добавить еду��6=   $��Right=�6T   $	��Top=�6p   $��
0,280,20,0q�6�   6�   5      5      