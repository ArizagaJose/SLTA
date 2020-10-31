Public Class EscanearVin


    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim WinIngresoManual As New WinVehiculo
        WinIngresoManual.Show()
        Close()
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim winMenu As New Menu
        If (My.Settings.USER_ROLE.ToString = "administrador                   ") Then
            winMenu.Show()
            Close()

        ElseIf (My.Settings.USER_ROLE.ToString = "operariopuerto                  ") Then
            winMenu.Show()
            Close()
        End If
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub

    Private Sub Button_Click_2(sender As Object, e As RoutedEventArgs)
        Dim Explorador As New Forms.OpenFileDialog
        Explorador.InitialDirectory = "C:\\"
        Explorador.Filter = "Imagenes (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|Todos los archivos (*.*)|*.*"
        Dim UbicacionIMG As String
        If Explorador.ShowDialog = Forms.DialogResult.OK Then
            UbicacionIMG = Explorador.FileName
            Dim Scan As New LecturaQR(UbicacionIMG)
            Scan.ReconocerQR()
        End If
        Close()
    End Sub
End Class
