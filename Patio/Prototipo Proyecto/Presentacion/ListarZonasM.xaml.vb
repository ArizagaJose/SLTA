Public Class listarZonasM
    Dim lista As List(Of String)
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Llenar()
    End Sub

    Private Sub Llenar()
        Dim LZona As New Zona
        Dim lista As String() = LZona.devolverZonas
        ListBoxZona.ItemsSource = lista
    End Sub



    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinMenu As New ConfgZonas
        WinMenu.Show()
        Close()

    End Sub

    Private Sub BtnVerMas_Click(sender As Button, e As RoutedEventArgs)
        Dim InfVehiculo As New modificarZona
        InfVehiculo.setVinAux(sender.Tag.ToString)
        InfVehiculo.Show()
        Close()

    End Sub

    Private Sub CheckBoxLote_Checked(sender As CheckBox, e As RoutedEventArgs)
        lista.Add(sender.Tag.ToString)
    End Sub

    Private Sub BtnCrear_Click(sender As Object, e As RoutedEventArgs) Handles BtnCrear.Click
        MsgBox(lista.ToString)
    End Sub
End Class
