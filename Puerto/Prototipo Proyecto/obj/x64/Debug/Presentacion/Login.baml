   M S B A M L   `   `   `  ����?  ;SLTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SLTASLTA  5   	   ) clr-namespace:SLTA;assembly=SLTASLTA  5   	       
SLTA.Login   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:SLTA     5   	   8MyNamespace clr-namespace:SLTA;assembly=SLTA     5   	   -   5          �Name$  Ventana��5   	      Title_Login � Title# �   5	   	    � WindowStartupLocation$ CenterScreen=�6/   $��977.737��6T   $��1771.868��6e    � WindowState$ 	Maximized=�6v   ��5
      �� 5   
    �� ImageSource$' !../Resources/WindowBackground.bmp��6   .��5      (� $��-3,1,4,6q�6    J� RenderTransformOrigin$ 0.5,0.5&�6     (� Stretch$
 Fill=�6@   z�5   
   V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.229Q�6"   T� 5      5      .��5   
   � $	��993��6   $
��2135��6   .+�5      �� $�� ��6   $��
939,41,0,0q�6   $	��215��63   $��Arial)�6@   $	��257��6S   $	��Top=�6_   $
��Left=�6w   ��5      �� 5      $ ../Resources/logo.png��6!   5      �� 5        Lbl_Usr#���  6   $��326,346,0,0q�68   $ 0.591,-1.209&�6M   $��36(�6r   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   $
��Left=�6�   $	��Top=�6�   $��51��6�   $	��144��6�   �� 5        Lbl_Pwd#���  6   $��326,552,0,0q�68   $��36(�6M   $ 0.519,-0.32&�6[   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6   $	��Top=�6�   $
��Left=�6�   $	��206��6�   $��51��6�   �� 5      -   5         ��Name$ ButtonIngresar��5        RoundCorner#���  6-     	Btn_Login#���  6T   $��858,842,0,0q�6z   $	��105��6�   }�. ���	#FF282525
���������.  $��36(�6�   $��Proxima Nova Alt Lt)�6�   $	��201��6  $
��Left=�6*  $	��Top=�6E  $	��419��6]  �� 5      -   5        	 ��Name$	 TxtBoxUsuario��5      $��63��6.   $��1380,346,0,0q�6:   
 �� TextWrapping$

 Wrap=�6P   ���	#FF282525
�������$��36(�6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   $	��250��6�   $��63��6�   $
��Left=�6�   $	��Top=�6  $	��420��6)  G� 5       -   5         G�Name$ TxtBoxContraseña��5       $
��Left=�64   $��1380,540,0,0q�6O   $	��Top=�6e   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6}   ���	#FF282525
�������$	��420��6�   $��63��6�    G� PasswordChar$ ×��6�   $��36(�6  �� 5!      -   5        $ 
BtnIdiomas��5!      #���  6)     Btn_Idiomas#���  6O   $
��Left=�6x   $��
25,944,0,0q�6�   $	��Top=�6�   $	��199��6�   $��49��6�   ���	#FF282525
�������$��24(�6  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6  �� 5"      -   5        $ BtnIdiomaEspañol��5"      #���  6/     Btn_IdiomaEspañol#���  6U   $
��Left=�6�   $��475,944,0,0q�6�   $	��Top=�6�   $	��199��6�   $��49��6�   ���	#FF282525
�������$��24(�6  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6  $y�Hidden=�6W  �� 5#      -   5        $ BtnIdiomaIngles��5#      #���  6.     Btn_IdiomaIngles#���  6T   $
��Left=�6�   $��250,944,0,0q�6�   $	��Top=�6�   $	��199��6�   $��49��6�   ���	#FF282525
�������$��24(�6  $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6  $y�Hidden=�6U  5$      5%      5&      