   M S B A M L   `   `   `  ����   FeriaVirtualApp1    +FeriaVirtualApp.Views.Usuarios.UsuariosView   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .���� $��0,0,-160,-216q�.+���   �� Orientation$  
Horizontal=�.+��� $��Administrador de Usuarios��
�������$��28(�$
��left=�$��0, 0, 0, 20q��� $  
Horizontal=�$	��600��.+��� $	��995������  �� 
StartPoint$	 0,0&� �� EndPoint$	 1,2&�.���  � Color$ #5bc3ff�� � Offset$	 0.0Q�� $ #3AA0FF��$ 1Q� J� Clip ��  �� RadiusX$ 10Q� �� RadiusY$ 10Q� �� Rect$ 0, 0, 950, 600�._�� 	 � ColumnDefinitions	 �� $
��Auto ��� $��2* �
 � RowDefinitions
 �� $��65 ��� $��* �.+��� $  
Horizontal=�$��0��$��0��$��
10,0,64,10q�.+��� $��Buscar: ��$��Bottom=�$��Right=�$��18(�
�������$
��Bold"��� -    ��Name$ 	txtSearch��$��Bottom=�$
��Left=�$	��150��$��14(��� -    � ToolTip$ Crear Usuario��$��0��$��1��$��539,17,64,16q�.��'  !MaterialDesignThemes.Wpf.PackIcon     Kind$ AccountPlus=�$��18(�$��27��$��40��$��Center=�&   System.Windows.Controls.DataGrid  -     Name$ 
dgUsuarios��$��1��$��0��$��2��   AutoGenerateColumns$ False��$��10,10,64,10q�   
IsReadOnly$
 True������ *
usuarios+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$	 Rut��   FontSize$ 16Q�   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *rut+  $ Email��$ 16Q�$ *  �� *email+  $ Nombre��$ 16Q�$ *  �� *nombre+  $ 	Apellidos��$ 16Q�$ *  �� *	apellidos+4  .System.Windows.Controls.DataGridTemplateColumn  $ Acción��   CellTemplate �� .R���  ��Name$ btnActualizar��-   $ 	Modificar��.��  $ Pencil=�$��18(�$��27��$��40��$��Center=�