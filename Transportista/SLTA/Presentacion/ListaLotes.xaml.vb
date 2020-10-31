Public Class ListaLotes
    Dim lotecamion As New List(Of String)
    Dim idcam As String
    Dim idlote As String

    Private Sub Btn_Atras_Click(sender As Object, e As RoutedEventArgs) Handles Btn_Atras.Click
        Dim WinAdminMenu As New MenuAdministrador
        Dim winMenu As New Menu
        If (My.Settings.USER_ROLE.ToString = "administrador                   ") Then
            WinAdminMenu.Show()
            Close()
        ElseIf (My.Settings.USER_ROLE.ToString = "transportista                   ") Then
            winMenu.Show()
            Close()
        End If
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim l As New Lote
        ListBoxLotes.ItemsSource = l.DevolverLotes
        ListBoxLotesViaje.ItemsSource = lotecamion
    End Sub

    Public Sub SetCamion(c As String)
        idcam = c
    End Sub

    Private Sub Btn_Viaje_Click(sender As Object, e As RoutedEventArgs) Handles Btn_Viaje.Click
        Dim l As New Lote
        Dim WinViaje As New WinViaje
        If lotecamion.Count = 0 Then
            MsgBox("Debe seleccionar lote(s)")
        Else
            WinViaje.SetValoresAux(lotecamion, idcam)
            WinViaje.Show()
            Close()
        End If

    End Sub


    Private Sub BtnAñadir_Click(sender As Object, e As RoutedEventArgs) Handles BtnAñadir.Click
        'Para comprobar si el vehiculo ya fue ingresado a la lista
        If lotecamion.Contains(ListBoxLotes.SelectedItem.ID.ToString) Then
            MsgBox("El vehiculo ya esta en el lote")
        Else
            lotecamion.Add(ListBoxLotes.SelectedItem.ID.ToString)
            ListBoxLotesViaje.Items.Refresh()
        End If
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As RoutedEventArgs) Handles BtnEliminar.Click
        Try
            lotecamion.Remove(ListBoxLotesViaje.SelectedItem.ID.ToString)
        Catch ex As Exception
            MsgBox("Debe seleccionar un lote de la lista de abajo")
        End Try
        ListBoxLotesViaje.Items.Refresh()
    End Sub
End Class
