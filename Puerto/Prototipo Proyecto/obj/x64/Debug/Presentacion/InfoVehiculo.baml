   M S B A M L   `   `   `  ����?  ;SLTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SLTASLTA  5   	       SLTA.InfoVehiculo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:SLTA     5   	   -   5          � Title$$  Informacion de Vehiculo - SLTA��5   	   $��562.5��60   $
��1073��6?    � WindowState$ 	Maximized=�6L    � WindowStartupLocation$ CenterScreen=�6{   ��5	      �� 5
   
    �� ImageSource$' !../Resources/WindowBackground.bmp��6   .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � $	��420��6   $	��792��6    � ColumnDefinitions 5      �� 5      .+�5      �� -   5         ��Name$ 
LblUsuario��5      $��Usuario��6(   $��Right=�6:   $��	0,10,10,0q�6V   $	��Top=�6i   $��24(�6�   $��49��6�   $	��102��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5         Lbl_VIN#���   6   $
��Left=�68   $��	28,77,0,0q�6S   $	��Top=�6f   $��48��6~   $��63��6�   $��22(�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5         ��Name$ 	TxtBoxVIN��5      $
��Left=�6)   $��48��6D   $��
113,77,0,0q�6P    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��207��6�   {�.  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5        	Lbl_Marca#���  6   $
��Left=�6:   $��
28,153,0,0q�6U   $	��Top=�6i   $��48��6�   $��79��6�   $��22(�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5        $ TxtBoxMarca��5      $
��Left=�6+   $��48��6F   $��113,153,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��207��6�   {�.  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5        
Lbl_Modelo#���  6   $
��Left=�6;   $��
28,235,0,0q�6V   $	��Top=�6j   $��48��6�   $��85��6�   $��22(�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5        $ TxtBoxModelo��5      $
��Left=�6,   $��48��6G   $��113,235,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��207��6�   {�.  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5        Lbl_Año#���  6   $
��Left=�68   $��
28,302,0,0q�6S   $	��Top=�6g   $��48��6   $��63��6�   $��22(�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5        $ 
TxtBoxAño��5      $
��Left=�6)   $��48��6D   $��113,302,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��207��6�   {�.  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5        	Lbl_Color#���  6   $
��Left=�6:   $��
457,77,0,0q�6U   $	��Top=�6i   $��48��6�   $��78��6�   $��22(�6�   	 J� RenderTransformOrigin$	 	0.585,0.3&�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5        $ TxtBoxColor��5      $
��Left=�6+   $��48��6F   $��
540,81,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $	��207��6�   {�.  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5        Lbl_Pais#���  6   $
��Left=�69   $��463,153,0,0q�6T   $	��Top=�6i   $��48��6�   $��79��6�   $��22(�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5        $ 
TxtBoxPais��5      $
��Left=�6*   $��48��6E   $��540,153,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��207��6�   {�.  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5        Lbl_Lote#���  6   $
��Left=�69   $��463,306,0,0q�6T   $	��Top=�6i   $��48��6�   $��57��6�   $��22(�6�   $	 0.852,0.522&�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5       -	   5        $ 
TxtBoxLote��5       $
��Left=�6*   $��48��6E   $��540,306,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $��47��6�   {�.  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5!      -
   5        
 ��Name$
 BtnAtras��5!        	Btn_Atras#���  6'   $
��Left=�6M   $��
10,383,0,0q�6h   $	��Top=�6|   $��81��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�     RoundCorner#���  6�   $��27��6  �� 5"       
	 Lbl_ID#��� 	 6   $
��Left=�67   $��642,306,0,0q�6R   $	��Top=�6g   $��48��6   $��35��6�   $��22(�6�   $	 5.503,1.262&�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5#      -   5        $ TxtBoxID��5#      $
��Left=�6(   $��48��6C   $��700,306,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $��47��6�   {�.  $	 3.225,1.762&�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5$       
 Lbl_Tipo#��� 
 6   $
��Left=�69   $��463,235,0,0q�6T   $	��Top=�6i   $��48��6�   $��79��6�   $��22(�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5%      -   5        $ 
TxtBoxTipo��5%      $
��Left=�6*   $��48��6E   $��540,235,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��207��6�   {�.  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5&      -   5        $ TxtBoxInspeccion��5&      $
��Left=�61   $��33��6L   $��587,373,0,0q�6X   $
 Wrap=�6m   $	��Top=�6�   $	��160��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   {�.  6�   �� 5'      $��
Inspeccion��6   $
��Left=�6)   $��457,373,0,0q�6D   $	��Top=�6Y   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6q   $��22(�6�   5(      5)      5*      