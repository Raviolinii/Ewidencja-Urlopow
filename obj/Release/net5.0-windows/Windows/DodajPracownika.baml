   M S B A M L   `   `   `  ���� K  GEwidencjaUrlopow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:EwidencjaUrlopow.WindowsEwidencjaUrlopow.Windows  G(clr-namespace:EwidencjaUrlopow.ViewModelEwidencjaUrlopow.ViewModel  .    (EwidencjaUrlopow.Windows.DodajPracownika   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     8local&clr-namespace:EwidencjaUrlopow.Windows     >	viewmodel(clr-namespace:EwidencjaUrlopow.ViewModel     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls    � Title$  Dodaj Pracownika��$	��350��$	��326�� � 
ResizeMode$ NoResize=�.���� .+��� $��Imię:�� �� Padding$ 10,5,5,5q��� *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton$
 True��
�������   	Watermark$ Imię nowego pracownika��$��0,0,0,5q����� *imie+ �� TargetNullValue$  ���� $��	Nazwisko:��$ 10,5,5,5q��� $
 True��
�������$  Nazwisko nowego pracownika��$��0,0,0,5q����� *
nazwisko+$  ���� $��Stanowisko pracy:��$ 10,5,5,5q��� $
 True��
�������$( "Stanowisko pracy nowego pracownika��$��0,0,0,5q����� *
stanowisko+$  ���� $��Lata pracy:��$ 10,5,5,5q��� $
 True��
�������$" Lata pracy nowego pracownika��$��0,0,0,5q����� *	lataPracy+$  ���� $��Dostępny urlop:��$ 10,5,5,5q��� $
 True��
�������$' !Dostępny urlop nowego pracownika��$��0,0,0,5q����� *dostepnyUrlop+$  ���  � ColumnDefinitions �� �� .+��� $��0��$��Anuluj�� '  #MahApps.Styles.Button.Square.Accent#��[  $��5,0,0,0q����� *CancelWorkerAddingCommand+�� $��1��$��Dodaj��#��[  $��5,0,5,0q����� *AddWorkerCommand+