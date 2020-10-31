Public Class ListaCamiones
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Lbl_Usuario.Content = My.Settings.USER_NAME
        Dim c As New Camion
        ListBoxCamiones.ItemsSource = c.devolverCamiones
    End Sub


    Private Sub Btn_Atras_Click(sender As Object, e As RoutedEventArgs) Handles Btn_Atras.Click
        Dim WinAdminMenu As New MenuAdministrador
        Dim winMenu As New Menu
        If (My.Settings.USER_ROLE.ToString = "administrador                   ") Then
            WinAdminMenu.Show()
            Close()
        ElseIf (My.Settings.USER_ROLE.ToString = "transportista                   ") Then
            winMenu.Show()
            Close()
        End If

    End Sub

    Private Sub BtnSeleccionar_Click(sender As Object, e As RoutedEventArgs)
        Dim cam As New Camion
        Dim ListLotes As New ListaLotes
        ListLotes.SetCamion(sender.tag.ToString)
        ListLotes.Show()
        Close()
    End Sub
End Class
