Public Class Menu
    Private Sub BtnList_Click(sender As Object, e As RoutedEventArgs) Handles BtnList.Click
        Dim WinVehiculos As New Window2
        WinVehiculos.Show()
        Close()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim WinEscanear As New EscanearVin
        WinEscanear.Show()
        Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub

    Private Sub BtnInspect_Click(sender As Object, e As RoutedEventArgs) Handles BtnInspect.Click
        Dim WinInspeccion As New InspeccionarVehiculo
        WinInspeccion.Show()
        Close()
    End Sub

    Private Sub BtnLot_Click(sender As Object, e As RoutedEventArgs) Handles BtnLot.Click
        Dim WinLotes As New ConfgLotes
        WinLotes.Show()
        Close()
    End Sub
End Class
