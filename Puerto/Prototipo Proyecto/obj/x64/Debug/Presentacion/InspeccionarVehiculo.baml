   M S B A M L   `   `   `  ����?  ;SLTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SLTASLTA  5   	       SLTA.InspeccionarVehiculo   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:SLTA     5   	   -   5           Title_InspeccionVehiculo  � Title#  �   5   	   $	��450��6<   $	��800��6I    � WindowState$ 	Maximized=�6U   ��5	      �� 5
   
    �� ImageSource$' !../Resources/WindowBackground.bmp��6   .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � $	��419��6   $	��792��6    � ColumnDefinitions 5      �� 5      $��5* �6#   �� 5      $	��17* �6#   .+�5      ��   Lbl_VIN#���  6   $
��Left=�68   $��
21,109,0,0q�6S   $	��Top=�6g    J� RenderTransformOrigin$ 0.646,-0.121&�6   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5         ��Name$ BtnAtras��5        	Btn_Atras#���  6'   $
��Left=�6M   $��
10,380,0,0q�6h   $	��Top=�6|   $	��100��6�   $��30��6�   
�������$4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�     RoundCorner#���  6�   �� 5      -   5        $ BtnAgregarDaño��5        Btn_Agregar#���  6-   $
��Left=�6U   $��304,292,0,0q�6p   $	��Top=�6�   $	��100��6�   $��30��6�   
�������$4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   #���  6  $��1��6)  �� 5        Lbl_Funcionario#���  6   $
��Left=�6@   $��
21,157,0,0q�6[   $	��Top=�6o   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5         ��Name$ TxtBoxFuncionario��5      $
��Left=�61   $��23��6L   $��119,160,0,0q�6X    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��156��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   ���	#FF282525{�.  $��2��6  �� 5        	Lbl_Fecha#���  6   $
��Left=�6:   $��
21,207,0,0q�6U   $	��Top=�6i   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5        $ TxtBoxFecha��5      $
��Left=�6+   $��23��6F   $��119,210,0,0q�6R   $
 Wrap=�6g   $	��Top=�6{   $	��156��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   ���	#FF282525{�.  $��2��6  �� 5        Lbl_Hora#���  6   $
��Left=�69   $��
21,255,0,0q�6T   $	��Top=�6h   $ -0.036,-0.101&�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      -   5        $ 
TxtBoxHora��5      $
��Left=�6*   $��23��6E   $��119,258,0,0q�6Q   $
 Wrap=�6f   $	��Top=�6z   $	��156��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   ���	#FF282525{�.  $��2��6  �� 5      -   5        	 ��Name$	 ListBoxDaños��5      $
��Left=�6,   $	��178��6G   $��247,109,0,0q�6T   $	��Top=�6i   $	��208��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   
�������$��1��6�   ��6�   Z� 6�   �� 5        Lbl_AgregarDaño#���  6   $
��Left=�6@   $��147,109,0,0q�6[   $	��Top=�6p   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   $��1��6�   �� 5      -   5        
 ��Name$
 
LblUsuario��5      $��Usuario��6(   $
��Left=�6:   $��
551,10,0,0q�6U   $	��Top=�6i   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   $��1��6�   �� 5       -	   5        $ 	TxtBoxVIN��5       $
��Left=�6)   $��23��6D   $��119,109,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��156��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   {�.  $��2��6�   �� 5!      -
   5        $ Btn_Ingresar��5!       	 Btn_Ingresar#��� 	 6+   $
��Left=�6T   $��502,380,0,0q�6o   $	��Top=�6�   $	��100��6�   $��30��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   #���  6�   $��1��6  5"      5#      5$      