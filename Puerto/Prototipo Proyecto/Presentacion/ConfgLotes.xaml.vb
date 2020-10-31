Public Class ConfgLotes
    Dim VehiculosLote As New List(Of String)
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Llenar()
        ListBoxLote.ItemsSource = VehiculosLote
        ListBoxLote.InvalidateArrange()
    End Sub

    Private Sub Llenar()
        Dim LVehiculo As New Vehiculo
        Dim lista As String() = LVehiculo.devolverVehiculosLote
        ListBoxVehiculo.ItemsSource = lista
    End Sub

    Private Sub BtnAñadir_Click(sender As Object, e As RoutedEventArgs) Handles BtnAñadir.Click
        'Para comprobar si el vehiculo ya fue ingresado a la lista
        If VehiculosLote.Contains(ListBoxVehiculo.SelectedItem.ToString) Then
            MsgBox("El vehiculo ya esta en el lote")
        Else
            VehiculosLote.Add(ListBoxVehiculo.SelectedItem.ToString)
            ListBoxLote.Items.Refresh()
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As RoutedEventArgs) Handles BtnEliminar.Click
        Try
            VehiculosLote.Remove(ListBoxLote.SelectedItem.ToString)
        Catch ex As Exception
            MsgBox("Debe seleccionar un vehiculo de la lista de abajo")
        End Try

        ListBoxLote.Items.Refresh()
    End Sub

    Private Sub BtnCrear_Click(sender As Object, e As RoutedEventArgs) Handles BtnCrear.Click
        Dim l As New Lote
        l.ArmadoLotes(VehiculosLote)
        Llenar()
        VehiculosLote.Clear()
        ListBoxLote.Items.Refresh()

    End Sub

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinMenu As New Menu
        WinMenu.Show()
        Close()
    End Sub
End Class
