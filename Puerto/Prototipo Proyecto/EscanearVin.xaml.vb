Imports Winsoft.Ocr
Public Class EscanearVin


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim WinIngresoManual As New Vehiculo
        WinIngresoManual.Show()
        Close()
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim WinMenu As New Menu
        WinMenu.Show()
        Close()

    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub
End Class
