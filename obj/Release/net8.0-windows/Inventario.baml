   M S B A M L   `   `   `  ����   Celltech    Celltech.Inventario   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
Inventario��$	��450��$	��800��   MaterialDesignBody#���     MaterialDesignPaper#���  $��Regular"�$��13(���:  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .��� .+�]� .+��� $	��Top=����#1976D2$��60��._�� .+���  �� Orientation$ 
Horizontal=�$��Center=�$
��20,0q�.+��� $��Mi Negocio Comercial��
�������$��22(�$��Center=�� $��20q�.+��� .@��� $��
Inventario��.���  � RowDefinitions �� $
��Auto ��� $��* �.+��� $��0�����#f8f9fa �� Padding$ 15q�._�]� .+��� $��Nuevo Producto�����#1976D2
�������$
��15,8q�$��Right=��� $��Gestión de Inventario��$��20(�$��Center=�&   System.Windows.Controls.DataGrid  $��1��$��0,20,0,0q�   AutoGenerateColumns$ False��   
IsReadOnly$
 True��   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Código��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100   $ Producto��$ *   $ 
Categoría��$	 150   $ Stock��$	 100   $ Precio��$	 120 4  .System.Windows.Controls.DataGridTemplateColumn  $ Acciones��$	 120 	   CellTemplate	 �� .R��� $ 
Horizontal=�.+��� $��Editar��$��2q����#FFC107�� $��Eliminar��$��2q����#DC3545�� $��Categorías��.���  �� $
��Auto ��� $��* �.+��� $��0�����#f8f9fa$ 15q�._�]� .+��� $��Nueva Categoría�����#1976D2
�������$
��15,8q�$��Right=��� $��Gestión de Categorías��$��20(�$��Center=�  $��1��$��0,20,0,0q�$ False��$
 True��   $ ID��$ 80   $ Nombre��$ *   $ Descripción��$ *   $ 	Productos��$	 100   $ Acciones��$	 120 	 �� .R��� $ 
Horizontal=�.+��� $��Editar��$��2q����#FFC107�� $��Eliminar��$��2q����#DC3545�� $��Precios��.���  �� $
��Auto ��� $��* �.+��� $��0�����#f8f9fa$ 15q�._�]� .+��� $��Actualizar Precios�����#1976D2
�������$
��15,8q�$��Right=��� $��Gestión de Precios��$��20(�$��Center=�  $��1��$��0,20,0,0q�$ False��$
 True��   $ Código��$	 100   $ Producto��$ *   $ Precio Actual��$	 120   $ Último Cambio��$	 150   $ Acciones��$	 120 	 �� .R��� $��	Modificar�����#1976D2
�������