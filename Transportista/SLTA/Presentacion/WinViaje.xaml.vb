Public Class WinViaje
    Dim lotes As New List(Of String)
    Dim idcam As String
    Dim viajes As New Viaje
    Private Sub Window_Activated(sender As Object, e As EventArgs)

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        ComboBoxPatios.ItemsSource = viajes.DevolverPatios
    End Sub

    Private Sub BtnViaje_Click(sender As Object, e As RoutedEventArgs) Handles BtnViaje.Click
        Dim l As New Lote
        Dim v As New Viaje
        Dim fechaesperada As Date
        Try
            Try
                fechaesperada = TxtBoxFechaEsperada.Text

            Catch ex As Exception
                MsgBox("Ingrese el formato correcto")
            End Try

            For Each lote In lotes
                l.AltaLoteCamion(lote, idcam)
                v.AltaViaje(lote, ComboBoxPatios.SelectedItem.ToString, DateTime.Now.ToString("yyyy-MM-dd HH:mm").ToString, fechaesperada.ToString("yyyy-MM-dd HH:mm").ToString)
            Next

            LblFormato.Visibility = Visibility.Hidden
            LblHora.Visibility = Visibility.Hidden
            LblPatio.Visibility = Visibility.Hidden
            ComboBoxPatios.Visibility = Visibility.Hidden
            LblEstado.Content = "Viaje en curso"
            TxtBoxFechaEsperada.IsEnabled = False
            BtnViaje.Visibility = Visibility.Hidden
            BtnFinalizarViaje.Visibility = Visibility.Visible
        Catch ex As Exception


        End Try

    End Sub

    Public Sub SetValoresAux(l As List(Of String), id As String)
        lotes = l
        idcam = id
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As RoutedEventArgs) Handles BtnCancelar.Click
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

    Private Sub BtnFinalizarViaje_Click(sender As Object, e As RoutedEventArgs) Handles BtnFinalizarViaje.Click
        Dim bdd As New Conexion
        For Each lote In lotes
            bdd.FinalizarViaje(lote, DateTime.Now.ToString("yyyy-MM-dd HH:mm").ToString)
        Next

    End Sub
End Class
