   M S B A M L   `   `   `  ����   FeriaVirtualApp7    1FeriaVirtualApp.Views.Contratos.CrearContratoView   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $	��500��$	��500��  � 
ResizeMode$  NoResize=� � WindowStyle$ SingleBorderWindow=����#272537 � WindowStartupLocation$ CenterScreen=�.���� ����  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,2&�.���  � Color$ #5bc3ff�� � Offset$	 0.0Q�� $ #3AA0FF��$ 1Q� J� Clip ��  �� RadiusX$ 10Q�	 �� RadiusY$	 10Q�
 �� Rect$
 0, 0, 485, 460�._�� $��
0, 0, 0, 0q�$��Center=� � ColumnDefinitions �� $
��Auto ��� $��* � � RowDefinitions �� $	��100 ��� $��50 ��� $	��100 ��� $	��100 ��� $	��100 �.+��� $��0��$��0��$��2��$��Center=�$��Center=� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ 	txtTitulo��$��Registrar Contrato��$��Center=�$��Center=�
�������$��30(�$��10q�$��	Underline{�$
��Bold"��� $ 
Horizontal=�$��10q�$��1��$��0��$��2��$��Center=�.+��� $��Fecha Creación: ��$��18(�$	��150��$��30��
�������(  "System.Windows.Controls.DatePicker  -     Name$ dpFechaCreacion��$��16(�$	��150��$��30��
��������� $ 
Horizontal=�$��10q�$��2��$��0��$��2��$��Center=�.+��� $��Fecha Termino: ��$��18(�$	��150��$��30��
�������  -   $ dpFechaTermino��$��16(�$	��150��$��30��
��������� $ 
Horizontal=�$��10q�$��3��$��0��$��2��.+��� $��PDF: ��$��18(�$��80��$��31��
��������� -    ��Name$ BtnPdfContrato��$��
Buscar PDF���� $ 
Horizontal=�$��10q�$��2��$��1��$��2��.+��� -    ��Name$ imgPdfContrato���� $ 
Horizontal=�$��10q�$��Center=�$��4��$��0��$��2��.+��� -   $ 
BtnGuardar��$��GUARDAR��