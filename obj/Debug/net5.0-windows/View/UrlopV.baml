   M S B A M L   `   `   `  ����K  GEwidencjaUrlopow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:EwidencjaUrlopow.ViewEwidencjaUrlopow.View  5      G(clr-namespace:EwidencjaUrlopow.ViewModelEwidencjaUrlopow.ViewModel  5      "    EwidencjaUrlopow.View.UrlopV   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:EwidencjaUrlopow.View     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5      8	viewmodel(clr-namespace:EwidencjaUrlopow.ViewModel  5      .��5      � 
�������  � ColumnDefinitions  5   
   �� 5      $��* �6   �� 5      $��3* �6    � RowDefinitions 5   
   �� 5      �� 5      $��50 �6   .+�5   
   �� $��0��6   $��0��6"   $��5,0,5,0q�62   .+�5      �� $��Filtrowanie wyników��6    �� Padding$ 5,5,5,5q�63    �� TextAlignment$ Center=�6E   �� 5      *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton$
 True��6      	Watermark$ 	ID urlopu��5      ��5      �� *szukaneIdUrlopu+ �� TargetNullValue$  ���� 5      $
 True��6   $ 
Dni urlopu��5      ��5      �� *
szukaneDni+$  ��(  "System.Windows.Controls.DatePicker  5         SelectedDate 6   �� *szukaneDataRozpoczecia+$  ��  5       6   �� *szukaneDataZakonczenia+$  ���� 5      $
 True��6   $ Opis urlopu��5       ��5!      �� *szukaneOpis+$  ���� 5"      $
 True��6   $ ID pracownika��5#      ��5$      �� *szukaneIdPracownika+$  ���� 5%       '  #MahApps.Styles.Button.Square.Accent#��[  6   $��Szukaj��5&      ��6&   �� *SearchCommand+5)      �� 5+   
   $��1��6   $��0��5,      $��Dodaj urlop��6!   $��5,0,5,5q�5-      #��[  5/      ��5.      �� *OpenAddLeaveWindowCommand+5/      �� 52   
   $��2��6   $��2��6(   .��53      �� .+�54      �� -   5         �� SelectionMode$ Single=�56      ��54      �� *szukaneUrlopy+	 �� SelectedValue	 57      �� *selectedItem+��58      �� 59      .R�5:      �� 
���   �$��1q�69   $��5q�6M   ._�5;   "   � $��10q�6'     5<   &   �� 5=   *   �� 5>   *   �� 5?   *    5A   &   �� 5B   *   �� 5C   *   �� 5D   *   .+�5G   &   �� $��0��60   $��0��6=   $��0,0,10,0q�6�   ��6M   �� *DataRozpoczeciaUrlopu+
 �� StringFormat$
 Data rozpoczecia: {0:d}��6�   �� 5H   &   $��1��60   $��0��6=   $��0,0,10,0q�6�   ��6M   �� *DataZakonczeniaUrlopu+$
 Data zakonczenia: {0:d}��6�   �� 5I   &   $��2��60   $��3��6=   $��0,0,10,0q�6�   ��6Q   �� *
OpisUrlopu+$
 Opis urlopu: {0}��6�   �� 5K   &   $��0��60   $��1��6=   $��0,0,10,0q�6�   ��6M   �� *
IdUrlopu+$
 Id urlopu: {0}��6�   �� 5L   &   $��0��60   $��2��6=   $��0,0,10,0q�6�   ��6M   �� *IdPracownika+$
 ID pracownika: {0}��6�   �� 5M   &   $��1��60   $��1��6=   $��0,0,10,0q�6�   ��6M   �� *	DniUrlopu+$
 Dni urlopu: {0}��6�   5O   #   5P      5Q      5S      5T      5U      5X      5Y      