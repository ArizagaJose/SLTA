Public Class MenuAdministrador
    Private Sub BtnUbicar_Click(sender As Object, e As RoutedEventArgs) Handles BtnUbicar.Click
        Dim win As New ListaCamionesEnViaje
        win.Show()
        Me.Close()

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub

    Private Sub Btn_Viajes_Click(sender As Object, e As RoutedEventArgs) Handles Btn_Viajes.Click
        Dim camion As New ListaCamiones
        camion.Show()
        Close()
    End Sub
End Class
