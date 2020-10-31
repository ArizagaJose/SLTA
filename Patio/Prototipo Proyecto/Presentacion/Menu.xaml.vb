Public Class Menu
    Private Sub BtnList_Click(sender As Object, e As RoutedEventArgs) Handles BtnList.Click
        Dim winListarZonas As New listarZonas
        winListarZonas.Show()
        Close()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim WinVehiculo As New AsignarVehiculo
        WinVehiculo.Show()
        Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub

    Private Sub BtnInspect_Click(sender As Object, e As RoutedEventArgs) Handles BtnInspect.Click
        Dim winListarZonas As New ListarSubZonas
        winListarZonas.Show()
        Close()
    End Sub

    Private Sub BtnLot_Click(sender As Object, e As RoutedEventArgs) Handles BtnLot.Click
        Dim WinZonas As New ConfgZonas
        WinZonas.Show()

        Close()
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As RoutedEventArgs) Handles BtnImport.Click
        Dim WinLotesArribados As New MarcarLote
        WinLotesArribados.Show()
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As RoutedEventArgs) Handles BtnPrint.Click
        Dim WinInspeccionarV As New Inspeccionar
        WinInspeccionarV.Show()
        Close()
    End Sub

    Private Sub BtnPrint2_Click(sender As Object, e As RoutedEventArgs) Handles LblUsuario.MouseDoubleClick
        Dim winSettings As New UsserSettings
        winSettings.Show()
        Close()

    End Sub
End Class
