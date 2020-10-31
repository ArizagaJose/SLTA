Public Class InfoVehiculo

    Dim vin As String
    Dim fechaaux As String
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
        cargarDatos()
        Dim insc As New Inspeccion
        insc.SetIDVehiculo(vin)
        If insc.ComprobarInspeccion() Then
            TxtBoxInspeccion.Text = "Inspeccionado el " & insc.GetFecha
        Else
            TxtBoxInspeccion.Text = "No fue inspeccionado"
        End If
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim Lista As New ListaVehiculos
        Lista.Show()
        Me.Close()
    End Sub

    Public Sub setVinAux(vIN As String)
        Me.vin = vIN
    End Sub

    Public Sub setFechaAux(fecha As String)
        fechaaux = fecha
    End Sub

    Private Sub cargarDatos()

        Dim V As New Vehiculo
        V = V.InformacionVehiculo(vin)
        TxtBoxVIN.Text = V.getVIN
        TxtBoxID.Text = V.getID
        TxtBoxMarca.Text = V.getMarca
        TxtBoxModelo.Text = V.getModelo
        TxtBoxPais.Text = V.getPais
        TxtBoxColor.Text = V.getColor
        TxtBoxAño.Text = V.getAño
        TxtBoxTipo.Text = V.getTipo
        TxtBoxLote.Text = V.getLote
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)

    End Sub
End Class
