   M S B A M L   `   `   `  ����K  GEwidencjaUrlopow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:EwidencjaUrlopow.WindowsEwidencjaUrlopow.Windows  5   	   G(clr-namespace:EwidencjaUrlopow.ViewModelEwidencjaUrlopow.ViewModel  5   	   /    )EwidencjaUrlopow.Windows.EdytujPracownika   5      \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:EwidencjaUrlopow.Windows     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   8	viewmodel(clr-namespace:EwidencjaUrlopow.ViewModel  5   	     � Title$  Edytuj Pracownika��5
   	   $	��350��6#   $	��326��60    � 
ResizeMode$ NoResize=�6<   .��5      �� .+�5   
   �� $��Imię:��6    �� Padding$ 10,5,5,5q�6!   �� 5   
   *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton$
 True��6   
�������$��0,0,0,5q�5      ��5      �� *imie+5      �� 5   
   $��	Nazwisko:��6   $ 10,5,5,5q�6%   �� 5   
   $
 True��6   
�������$��0,0,0,5q�5      ��5      �� *
nazwisko+5      �� 5   
   $��Stanowisko pracy:��6   $ 10,5,5,5q�6-   �� 5   
   $
 True��6   
�������$��0,0,0,5q�5      ��5      �� *
stanowisko+5      �� 5    
   $��Lata pracy:��6   $ 10,5,5,5q�6'   �� 5!   
   $
 True��6   
�������$��0,0,0,5q�5$      ��5#      �� *	lataPracy+5$      �� 5&   
   $��Dostępny urlop:��6   $ 10,5,5,5q�6+   �� 5'   
   $
 True��6   
�������$��0,0,0,5q�5*      ��5)      �� *dostepnyUrlop+5*      � 5,   
    � ColumnDefinitions 5-      �� 5.      �� 5/      �� 50      .+�52      �� $��0��6   $��Anuluj��6%    '  #MahApps.Styles.Button.Square.Accent#��[  53      $��5,3,0,0q�55      ��54      �� *CancelEditWorkerCommand+55      �� 56      $��1��6   $��Usuń��6%   #��[  57      $��5,3,0,0q�59      ��58      �� *DeleteWorkerCommand+59      �� 5:      $��2��6   $��Zapisz��6%   #��[  5;      $��5,3,5,0q�5=      ��5<      �� *SaveWorkerCommand+5=      5>      5@      5A      