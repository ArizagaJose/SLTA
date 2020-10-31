Public Class Menu
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Lbl_Usuario.Content = My.Settings.USER_NAME

    End Sub

    Private Sub Btn_Viajes_Click(sender As Object, e As RoutedEventArgs) Handles Btn_Viajes.Click
        Dim camion As New ListaCamiones
        camion.Show()
        Close()
    End Sub


End Class
