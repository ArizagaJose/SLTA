Public Class ListaVehiculos
    Dim lista As List(Of String)
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Llenar()
    End Sub

    Private Sub Llenar()
        Dim LVehiculo As New Vehiculo
        Dim lista As String() = LVehiculo.devolverVehiculos
        ListBoxVehiculo.ItemsSource = lista
    End Sub


    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinMenu As New Menu
        Close()
        WinMenu.Show()
    End Sub

    Private Sub BtnVerMas_Click(sender As Button, e As RoutedEventArgs)
        Dim InfVehiculo As New InfoVehiculo
        InfVehiculo.setVinAux(sender.Tag.ToString)
        Close()
        InfVehiculo.Show()

    End Sub

    Private Sub CheckBoxLote_Checked(sender As CheckBox, e As RoutedEventArgs)
        lista.Add(sender.Tag.ToString)
    End Sub

    Private Sub BtnInspeccionar_Click(sender As Object, e As RoutedEventArgs)
        Dim InspcVehiculo As New InspeccionarVehiculo
        Dim InspcVehiculoOBJ As New Inspeccion
        InspcVehiculoOBJ.SetIDVehiculo(sender.tag.ToString)
        If InspcVehiculoOBJ.ComprobarInspeccion() Then
            MsgBox("Este vehiculo ya fue inspeccionado")
        Else
            InspcVehiculo.SetInspeccionOBJ(InspcVehiculoOBJ)
            InspcVehiculo.Show()
            Close()
        End If


    End Sub
End Class
