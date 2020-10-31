Public Class InspeccionarVehiculo
    Private inspeccion As Inspeccion
    Private Daños As New List(Of Daño)

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        TxtBoxVIN.Text = inspeccion.GetIDVehiculo
        TxtBoxFuncionario.Text = My.Settings.USER_NAME.ToString
        TxtBoxHora.Text = DateTime.Now.ToString("HH:mm").ToString
        TxtBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm").ToString
        LblUsuario.Content = My.Settings.USER_NAME
        Daños = inspeccion.DevolverDaños
        For Each daño In Daños
            ListBoxDaños.Items.Add(daño.GetDescripcion)
        Next
    End Sub

    Public Sub AgregarDaño(d As Daño)
        Daños.Add(d)
    End Sub

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim winmenu As New Menu
        If (My.Settings.USER_ROLE.ToString = "administrador                   ") Then
            winMenu.Show()
            Close()

        ElseIf (My.Settings.USER_ROLE.ToString = "operariopuerto                  ") Then
            winMenu.Show()
            Close()
        End If

    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As RoutedEventArgs) Handles BtnAgregarDaño.Click
        Dim WinSiguiente As New AgregarDaño
        WinSiguiente.SetInspeccion(inspeccion)
        WinSiguiente.Show()
        Close()
    End Sub

    Public Sub SetInspeccionOBJ(ins As Inspeccion)
        inspeccion = ins
    End Sub

    Private Sub Btn_Ingresar_Click(sender As Object, e As RoutedEventArgs) Handles Btn_Ingresar.Click
        inspeccion.AltaInspeccion()
    End Sub
End Class
