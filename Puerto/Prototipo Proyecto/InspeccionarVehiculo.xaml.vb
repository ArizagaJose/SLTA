Public Class InspeccionarVehiculo

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinMenu As New Menu
        WinMenu.Show()
        Close()
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As RoutedEventArgs) Handles BtnSiguiente.Click
        Dim WinSiguiente As New InspeccionarVehiculo2
        WinSiguiente.Show()
        Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub
End Class
