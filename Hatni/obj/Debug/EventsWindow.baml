   M S B A M L   `   `   `  ����@  <Hatni, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HatniHatni  5   	       Hatni.EventsWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Hatni     5   	     � Title$  EventsWindow��5   	   $	��450��6   $	��800��6+   .��5	      � .+�5
   
   �� $	��Top=�6   $��Center=�6(   $
��Bold"�6E   $��0,30,0,0q�6W   .��6i   )'Добавить мероприятие6   �� 5   
   $��25��6   $	��180��6    $-��'Название мероприятия��6,   $��0��6H   $��Center=�6U   $��Center=�6r   $��0,70,200,280q�6�   �� 5   
   -   5        $
��Name��5      $	��150��6   $��25��6*   $��0,100,200,250q�66   �� 5   
   $��25��6   $	��150��6    $%��Дата мероприятия��6,   $��0��6D   $��Center=�6Q   $��Center=�6n   $��200,70,0,280q�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        $
��Date��5      $	��150��6!   $��25��6-   $��200,100,0,250q�69   �� 5   
   -   5         ��Name$	 Add��5      $	��120��6   $��25��6*   $��0,100,200,170q�66   .��6_   Создать6h   �� 5   
   -   5        $ Delete��5      $	��120��6!   $��25��6-   $��200,100,0,170q�69   .��6e   Удалить6n   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Table��5         AutoGenerateColumns .  $	��300��6>   $	��200��6J   $��0, 180, 0, 0q�6W      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$- 'Название мероприятия��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 140 6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   ��  �� Path$
 Name�  5      $% Дата мероприятия��6%   $	 140 6?    6K   �� $
 Date�5      5      5      