Public Class WinVehiculo

    Dim v As New Vehiculo


    Dim vin As String

    Public Sub SetVinAux(vin As String)
        Me.vin = vin
        TxtBoxVIN.Text = vin
        If (Funciones.ComprobarLongitud(TxtBoxVIN.Text, 17)) Then
            v.setVIN(TxtBoxVIN.Text)
            v.decodificarVIN()
            TxtBoxPais.Text = v.getPais
            TxtBoxAño.Text = v.getAño
            TxtBoxPais.IsEnabled = True
            TxtBoxAño.IsEnabled = True
            TxtBoxColor.IsEnabled = True
            TxtBoxMarca.IsEnabled = True
            TxtBoxModelo.IsEnabled = True
            ComboBoxTipo.IsEnabled = True
        End If
    End Sub

    Private Sub Window_Loaded_1(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As RoutedEventArgs) Handles BtnIngresar.Click
        Ingresar(v)
    End Sub

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinAtras As New EscanearVin
        WinAtras.Show()
        Close()
    End Sub


    Private Sub TxtBoxVIN_MouseLeave(sender As Object, e As MouseEventArgs) Handles TxtBoxVIN.MouseLeave
        If (Funciones.ComprobarLongitud(TxtBoxVIN.Text, 17)) Then
            v.setVIN(TxtBoxVIN.Text)
            v.decodificarVIN()
            TxtBoxPais.Text = v.getPais
            TxtBoxAño.Text = v.getAño
            TxtBoxPais.IsEnabled = True
            TxtBoxAño.IsEnabled = True
            TxtBoxColor.IsEnabled = True
            TxtBoxMarca.IsEnabled = True
            TxtBoxModelo.IsEnabled = True
            ComboBoxTipo.IsEnabled = True
        End If
    End Sub


    Private Sub Ingresar(v As Vehiculo)
        v.setMarca(TxtBoxMarca.Text)
        v.setColor(TxtBoxColor.Text)
        v.setModelo(TxtBoxModelo.Text)
        v.setTipo(ComboBoxTipo.SelectedItem.ToString)
        v.AltaVehiculo()
    End Sub
End Class


