   M S B A M L   `   `   `  ����J  FFeriaVirtualApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FeriaVirtualApp.ValidationsFeriaVirtualApp.Validations  5   	   7    1FeriaVirtualApp.Views.VentasExternas.SubastarView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Avalidations)clr-namespace:FeriaVirtualApp.Validations     5   	   -   5        $	��500��5   	   $	��600��6     � 
ResizeMode$  NoResize=�5	   	    � WindowStyle$ SingleBorderWindow=�5
   	   ���#272537 � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,2&�63   .��5      �  � Color$ #5bc3ff��6    � Offset$	 0.0Q�6/   � 5      $ #3AA0FF��6   $ 1Q�6/   5       J� Clip 5   
   �� 5       �� RadiusX$ 10Q�6    	 �� RadiusY$	 10Q�6-   
 �� Rect$
 0, 0, 600, 500�6:   ._�5   
   � $��
0, 0, 0, 0q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5       �� 5!      $	��100 �6    �� 5"      $��50 �6    �� 5#      $��50 �6    �� 5$      $��50 �6    �� 5%      $��50 �6    �� 5&      $��50 �6    �� 5'      $	��100 �6    .+�5*      �� $��0��6   $��0��5+      $��2��5,      $��Center=�5-      $��Center=�5.      .+�5/      �� -   5         ��Name$ 	txtTitulo��5/      $��Center=�50      $��Center=�51      
�������$��30(�53      $��10q�54      $��	Underline{�55      $
��Bold"�56      57      �� 59       �� Orientation$ 
Horizontal=�6   $��10q�62   $��1��5:      $��0��6&   $��2��66   $��Center=�5;      .+�5<      �� $��
Id Venta: ��6   $��18(�6-   $��80��6;   $	��150��6F   
�������6S   �� 5=      -   5         ��Name$ txtIdVentaExterna��5=   S   $��16(�6   $	��150��6(   $��30��64   
������� � Cursor$ IBeam��6n   ${�False��6}   .��6�   ��5>      �� 5?       �� Path$ idVentaExterna�6"    �� UpdateSourceTrigger$ PropertyChanged=�68   5@      .��5A   $   5B      5C      �� 5E      $ 
Horizontal=�6   $��10q�62   $��2��5F      $��0��6&   $��2��66   $��Center=�5G      .+�5H      �� $��Fecha Termino: ��6   $��18(�62   $	��150��6@   $��30��6L   
�������6X   (  "System.Windows.Controls.DatePicker  5I      -   5          Name$ dpFechaTermino��5I   V   $��16(�6   $	��150��6+   $��30��67   
�������5K      5M      �� 5N      $ 
Horizontal=�6   $��10q�62   $��3��5O      $��0��6&   $��2��66   $��Center=�5P      .+�5Q      �� $��Tipo Refrigerante: ��6   $��18(�66   $	��150��6D   $��30��6P   
�������6\   �� 5R      -   5         ��Name$ cbTipoRefrigerante��5W      $	��125��5R      $��30��6'    �� SelectedIndex$ 0��5T       �� SelectedValuePath$ idTipoRefrigerante��5U       �� DisplayMemberPath$ descripcion��5V      ��5S      �� $ tpRefrigerantes�5X      5Y      �� 5[      $ 
Horizontal=�6   $��10q�62   $��4��5\      $��0��6&   $��2��66   $��Center=�5]      .+�5^      �� $��Tipo Transporte: ��6   $��18(�64   $	��150��6B   $��30��6N   
�������6Z   �� 5_      -   5        $ cbTipoTransporte��5d      $	��125��5_      $��30��6'   $ 0��5a      $ idTipoTransporte��5b      $ descripcion��5c      ��5`      �� $ tpTransportes�5f      5g      �� 5i      $ 
Horizontal=�6   $��10q�62   $��5��5j      $��0��6&   $��2��66   $��Center=�5k      .+�5l      �� -   5         ��Name$ 
btnGuardar��5l      5m      5n      5o      5p      5q      