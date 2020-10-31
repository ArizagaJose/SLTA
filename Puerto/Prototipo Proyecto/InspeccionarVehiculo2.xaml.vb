Public Class InspeccionarVehiculo2
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinAtras As New InspeccionarVehiculo
        WinAtras.Show()
        Close()
    End Sub
End Class
