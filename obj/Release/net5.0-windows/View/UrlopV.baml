   M S B A M L   `   `   `  ���� K  GEwidencjaUrlopow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:EwidencjaUrlopow.ViewEwidencjaUrlopow.View  G(clr-namespace:EwidencjaUrlopow.ViewModelEwidencjaUrlopow.ViewModel  "    EwidencjaUrlopow.View.UrlopV   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     5local#clr-namespace:EwidencjaUrlopow.View     T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f;Controls,http://metro.mahapps.com/winfx/xaml/controls  8	viewmodel(clr-namespace:EwidencjaUrlopow.ViewModel  .��� 
�������  � ColumnDefinitions  �� $��* ��� $��3* � � RowDefinitions �� �� $��50 �.+��� $��0��$��0��$��5,0,5,0q�.+��� $��Filtrowanie wyników�� �� Padding$ 5,5,5,5q� �� TextAlignment$ Center=��� *  $MahApps.Metro.Controls.TextBoxHelper   ClearTextButton$
 True��   	Watermark$ 	ID urlopu������ *szukaneIdUrlopu+ �� TargetNullValue$  ���� $
 True��$ 
Dni urlopu������ *
szukaneDni+$  ��(  "System.Windows.Controls.DatePicker     SelectedDate �� *szukaneDataRozpoczecia+$  ��   �� *szukaneDataZakonczenia+$  ���� $
 True��$ Opis urlopu������ *szukaneOpis+$  ���� $
 True��$ ID pracownika������ *szukaneIdPracownika+$  ����  '  #MahApps.Styles.Button.Square.Accent#��[  $��Szukaj������ *SearchCommand+�� $��1��$��0��$��Dodaj urlop��$��5,0,5,5q�#��[  ���� *OpenAddLeaveWindowCommand+�� $��2��$��2��.���� .+��� -    �� SelectionMode$ Single=����� *szukaneUrlopy+	 �� SelectedValue	 �� *selectedItem+���� .R��� 
���   �$��1q�$��5q�._�� $��10q�  �� �� ��  �� �� �� .+��� $��0��$��0��$��0,0,10,0q����� *DataRozpoczeciaUrlopu+
 �� StringFormat$
 Data rozpoczecia: {0:d}���� $��1��$��0��$��0,0,10,0q����� *DataZakonczeniaUrlopu+$
 Data zakonczenia: {0:d}���� $��2��$��3��$��0,0,10,0q����� *
OpisUrlopu+$
 Opis urlopu: {0}���� $��0��$��1��$��0,0,10,0q����� *
IdUrlopu+$
 Id urlopu: {0}���� $��0��$��2��$��0,0,10,0q����� *IdPracownika+$
 ID pracownika: {0}���� $��1��$��1��$��0,0,10,0q����� *	DniUrlopu+$
 Dni urlopu: {0}��