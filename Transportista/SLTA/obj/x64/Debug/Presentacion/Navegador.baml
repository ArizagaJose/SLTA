   M S B A M L   `   `   `  ����?  ;SLTA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SLTASLTA  5   	   V RCefSharp.Wpf, Version=75.1.143.0, Culture=neutral, PublicKeyToken=40c4b6fc221f4138A0clr-namespace:CefSharp.Wpf;assembly=CefSharp.WpfCefSharp.Wpf 5   	       SLTA.Navegador   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:SLTA     5   	   Hcefsharpwpf0clr-namespace:CefSharp.Wpf;assembly=CefSharp.Wpf     5   	     � Title$  	Navegador��5	   	   $	��450��6   $	��800��6(    � WindowState$ 	Maximized=�64   ��5
      �� 5   
    �� ImageSource$' !../Resources/WindowBackground.bmp��6   .��5      (�  (� Stretch$
 Fill=�6   .��5   
   � $	��419��6   $	��792��6   .+�5      �� -   5         ��Name$ BtnAtras��5         RoundCorner#���   6'   $��Atras��6M   $
��Left=�6]   $��
10,372,0,0q�6x   $	��Top=�6�   $	��115��6�   $��37��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   �� 5      $��Correo��6   $
��Left=�6%   $��154,378,0,0q�6@   $	��Top=�6U   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6m    J� RenderTransformOrigin$ 
0.174,0.76&�6�   �� 5      -   5         ��Name$ TxtBoxCorreo��5      $
��Left=�6,   $��23��6G   $��205,378,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��170��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   {�.  6�   �� 5      $��Contraseña��6   $
��Left=�6)   $��464,378,0,0q�6D   $	��Top=�6Y   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6q   $ 
-0.07,0.68&�6�   �� 5      -   5        $ TxtBoxContraseña��5      $
��Left=�60   $��23��6K   $��540,378,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��170��6�   $4��./SLTA;component/Resources/#Proxima Nova Alt Lt)�6�   {�.  6�   � 5      -   5         �Name$ GridBrowser��5      $
��Left=�6(   $	��357��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $	��772��6{   .+�5      %  CefSharp.Wpf.ChromiumWebBrowser  -   5        $��Browser��5   [   	   Address$%	 https://google.com/android/find��61   6�   5      5      5      5      