   M S B A M L   `   `   `  ����  FeriaVirtualApp3    -FeriaVirtualApp.Views.Productos.ProductosView   5      W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5	      �� $��0,0,-160,-216q�6   .+�5
   
   �� $ ��Administrador de Productos��6   
�������$��28(�5      $
��left=�5      $��0, 0, 0, 20q�5      �� 5   
     �� Orientation$  
Horizontal=�6   $	��600��6.   .+�5      �� $	��995��6   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,2&�6;   .��5      �  � Color$ #5bc3ff��6'    � Offset$	 0.0Q�67   � 5      $ #3AA0FF��6'   $ 1Q�67   5       J� Clip 5      �� 5       �� RadiusX$ 10Q�6(    �� RadiusY$ 10Q�5   (    �� Rect$ 0, 0, 950, 600�5   (   ._�5      � 	 � ColumnDefinitions	 5      �� 5      $
��Auto �6+   �� 5       $��2* �6+   
 � RowDefinitions
 5"      �� 5#      $��65 �6(   �� 5$      $��* �6(   .+�5'      �� $  
Horizontal=�6!   $��0��5(   !   $��0��5)   !   $��
10,0,64,10q�5*   !   .+�5+      �� -   5         ��Name$ 	TxtBuscar��5+       $��Buscar: ��5,       $��Bottom=�5-       $��Right=�5.       $��18(�5/       
�������$
��Bold"�51       �� 52      -   5         ��Name$ 	txtSearch��52   "   $��Bottom=�53   "   $
��Left=�54   "   $	��150��55   "   $��14(�56   "   57   "   58      �� 5:      -   5         ��Name$ BtnCrearProducto��5:      $��0��5;      $��1��5<      $��539,17,64,16q�5=      .��5?      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$
 Plus=�62   $
��Bold"�5@   2   $��18(�5A   2   $��27��5B   2   $��40��5C   2   $��Center=�5D   2   5E      &   System.Windows.Controls.DataGrid  5G      -   5          Name$ dgProductos��5G      $��1��5H      $��0��5I      $��2��5J         AutoGenerateColumns$ False��5L      $��10,10,64,10q�5M         
IsReadOnly$
 True��5N      ��5K      �� *	productos+   Columns 5O      0  *System.Windows.Controls.DataGridTextColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Header$ Nombre��61      FontSize$ 16Q�6\      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6j   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *nombre+6j     5Q      $ Activo��61   $ 16Q�6^   $ * 6l    6A   �� *
isActive+6l   4  .System.Windows.Controls.DataGridTemplateColumn  5R      $ Acción��65      CellTemplate 5S   "   �� 5T   &   .R�5U   *   �� $ btnActualizar��61   -   5         � ToolTip$ 	Modificar��5W   1   .��5X   .     $ Pencil=�6F   $��18(�6T   $��27��6b   $��40��6n   $��Center=�6y   5Y   +   5Z   '   5\      5^      5_      5`      5a      5b      5c      