   M S B A M L   `   `   `  ����J  FFeriaVirtualApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FeriaVirtualApp.ValidationsFeriaVirtualApp.Validations  5   	   9    3FeriaVirtualApp.Views.Subastas.ModificarSubastaView   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Avalidations)clr-namespace:FeriaVirtualApp.Validations     5   	   -   5        $	��500��5   	   $	��600��6     � 
ResizeMode$  NoResize=�5	   	    � WindowStyle$ SingleBorderWindow=�5
   	   ���#272537 � WindowStartupLocation$ CenterScreen=�5   	   .��5      �� ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,2&�63   .��5      �  � Color$ #5bc3ff��6    � Offset$	 0.0Q�6/   � 5      $ #3AA0FF��6   $ 1Q�6/   5       J� Clip 5   
   �� 5       �� RadiusX$ 10Q�6    	 �� RadiusY$	 10Q�6-   
 �� Rect$
 0, 0, 600, 500�6:   ._�5   
   � $��
0, 0, 0, 0q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#    � RowDefinitions 5       �� 5!      $��80 �6    �� 5"      $��50 �6    �� 5#      $��50 �6    �� 5$      $��50 �6    �� 5%      $��50 �6    �� 5&      $��50 �6    �� 5'      $��50 �6    �� 5(      $��70 �6    .+�5+      �� $��0��6   $��0��5,      $��2��5-      $��Center=�5.      $��Center=�5/      .+�50      �� -   5         ��Name$ 	txtTitulo��50      $��Center=�51      $��Center=�52      
�������$��30(�54      $��10q�55      $��	Underline{�56      $
��Bold"�57      58      �� 5:       �� Orientation$ 
Horizontal=�6   $��10q�62   $��1��5;      $��0��6&   $��2��66   $��Center=�5<      .+�5=      �� $��Id Subasta: ��6   $��18(�6/   $	��100��6=   $	��150��6I   
�������6V   �� 5>      -   5         ��Name$ txtIdSubastaTrans��5>   S   $��16(�6   $	��150��6(   $��30��64   
������� � Cursor$ IBeam��6n   ${�False��6}   .��6�   5@      5A      �� 5C      $ 
Horizontal=�6   $��10q�62   $��2��5D      $��0��6&   $��2��66   $��Center=�5E      .+�5F      �� $��
Id Venta: ��6   $��18(�6-   $��80��6;   $	��150��6F   
�������6S   �� 5G      -   5        $ 
txtIdVenta��5G   S   $��16(�6   $	��150��6(   $��30��64   
�������$ IBeam��6g   ${�False��6v   .��6�   5I      5J      �� 5L      $ 
Horizontal=�6   $��10q�62   $��3��5M      $��0��6&   $��2��66   $��Center=�5N      .+�5O      �� $��Tipo Venta: ��6   $��18(�6/   $	��100��6=   $	��150��6I   
�������6V   �� 5P      -   5        $ txtTipoVenta��5P   S   $��16(�6   $	��150��6(   $��30��64   
�������$ IBeam��6i   ${�False��6x   .��6�   5R      5S      �� 5U      $ 
Horizontal=�6   $��10q�62   $��4��5V      $��0��6&   $��2��66   $��Center=�5W      .+�5X      �� $��Fecha Termino: ��6   $��18(�62   $	��150��6@   $��30��6L   
�������6X   (  "System.Windows.Controls.DatePicker  5Y      -   5          Name$ dpFechaTermino��5Y   V   $��16(�6   $	��150��6+   $��30��67   
�������5[      5]      �� 5^      $ 
Horizontal=�6   $��10q�62   $��5��5_      $��0��6&   $��2��66   $��Center=�5`      .+�5a      �� $��Tipo Refrigerante: ��6   $��18(�66   $	��150��6D   $��30��6P   
�������6\   �� 5b      -   5         ��Name$ cbTipoRefrigerante��5g      $	��125��5b      $��30��6'    �� SelectedValuePath$ idTipoRefrigerante��5e       �� DisplayMemberPath$ descripcion��5f      ��5c      ��  �� Path$ tpRefrigerantes�5h      5i      �� 5k      $ 
Horizontal=�6   $��10q�62   $��6��5l      $��0��6&   $��2��66   $��Center=�5m      .+�5n      �� $��Tipo Transporte: ��6   $��18(�64   $	��150��6B   $��30��6N   
�������6Z   �� 5o      -   5        $ cbTipoTransporte��5t      $	��125��5o      $��30��6'   $ idTipoTransporte��5r      $ descripcion��5s      ��5p      �� $ tpTransportes�5v      5w      �� 5y      $ 
Horizontal=�6   $��10q�62   $��7��5z      $��0��6&   $��2��66   $��Center=�5{      .+�5|      �� -	   5         ��Name$ btnModificarSubasta��5|      5}      5~      5      5�      5�      