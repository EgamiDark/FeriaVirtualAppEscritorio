   M S B A M L   `   `   `  ����J  FFeriaVirtualApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:FeriaVirtualApp.ViewModelsFeriaVirtualApp.ViewModels  5   	        FeriaVirtualApp.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >	viewModel(clr-namespace:FeriaVirtualApp.ViewModels     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1200��6)    � WindowStyle$ SingleBorderWindow=�5	   	    � 
ResizeMode$ NoResize=�5
   	   
���   � � AllowsTransparency$ False��5   	    � WindowStartupLocation$ CenterScreen=�6$    � DataContext 5      .  (FeriaVirtualApp.ViewModels.MainViewModel  5   
   .��5      �� ���#272537._�5   
   �  � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��75 �6    �� 5      $��* �6    .+�5      �� $��FeriaVirtualApp��6   $��Center=�5      $
��Left=�5      
�������$��22(�5       $��20, 0, 0, 0q�5!      �� 5#      $��1��6   .+�5$      	� $��Inicio��6   $��50��5%      
�������$��18(�5'         MenuButtonTheme#��[  5(       d� 	IsChecked$
 TrueY�5)      ��5*      �� *HomeViewCommand+	� 5,      $��Usuarios��6   $��50��5-      
�������$��18(�5/      #��[  50      ��51      �� *UsuariosViewCommand+	� 53      $��	Productos��6   $��50��54      
�������$��18(�56      #��[  57      ��58      �� *ProductosViewCommand+	� 5:      $��Ventas Externas��6   $��50��5;      
�������$��18(�5=      #��[  5>      ��5?      �� *VentasExternasViewCommand+	� 5A      $��Ventas Locales��6   $��50��5B      
�������$��18(�5D      #��[  5E      ��5F      �� *VentasLocalesViewCommand+	� 5H      $��Subastas��6   $��50��5I      
�������$��18(�5K      #��[  5L      ��5M      �� *SubastasViewCommand+	� 5O      $��	Contratos��6   $��50��5P      
�������$��18(�5R      #��[  5S      ��5T      �� *ContratosViewCommand+5V      �� 5X      $	��250��6   $��40��5Y      $��Center=�5Z      $
��Left=�5[      $��5q�5\      $��1��5]        Moderntextbox#��[ 5^      �� 5`      $��1��6   $��1��5a      $��10q�5b      ��5c      �� *CurrentView+5d      5e      5f      