   M S B A M L   `   `   `  ����K  GEwidencjaUrlopow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:EwidencjaUrlopow.WindowsEwidencjaUrlopow.Windows  5   	   G(clr-namespace:EwidencjaUrlopow.ViewModelEwidencjaUrlopow.ViewModel  5   G   *    $EwidencjaUrlopow.Windows.UtworzUrlop   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:EwidencjaUrlopow.Windows     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   8	viewmodel(clr-namespace:EwidencjaUrlopow.ViewModel  6G     � Title$  Dodaj Urlop��5	   	   $	��290��6   $	��331��6+    � 
ResizeMode$ NoResize=�67   .��5
      �� .+�5   
   �� $��Data rozpoczęcia urlopu��6    �� Padding$ 10,5,5,5q�63   (  "System.Windows.Controls.DatePicker  5   
   
�������$��0,0,0,5q�6-      SelectedDate 6>   �� *dataRozpoczecia+ �� StringFormat$ d���� 5   
   $��Data zakończenia urlopu��6   $ 10,5,5,5q�63     5   
   
�������$��0,0,0,5q�6-    6>   �� *dataZakonczenia+$ d���� 5   
   $��Opis urlopu:��6   $ 10,5,5,5q�6(   �� 5   
   *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton$
 True��6   
�������   	Watermark$ Opis urlopu��5      $��0,0,0,5q�5      ��5      �� *opis+5      �� 5   
   $��ID pracownika:��6   $ 10,5,5,5q�6*   �� 5   
   $
 True��6   
�������$ ID pracownika��5      $��0,0,0,5q�5      ��5      �� *idPracownika+5      � 5   
    � ColumnDefinitions 5      �� 5      �� 5      .+�5"      �� $��0��6   $��Anuluj��6%    '  #MahApps.Styles.Button.Square.Accent#��[  5#      $��5,0,0,0q�5%      ��5$      �� *CancelAddLeaveCommand+5%      �� 5&      $��1��6   $��Dodaj��6%   #��[  5(      $��5,0,5,0q�5)      ��5'      �� *AddLeaveCommand+5)      5*      5,      5-      