Imports Microsoft.VisualBasic.FileIO

Public Class Menu
    Private Sub BtnList_Click(sender As Object, e As RoutedEventArgs) Handles BtnList.Click
        Dim ListVehiculos As New ListaVehiculos
        ListVehiculos.Show()
        Close()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim WinEscanear As New EscanearVin
        WinEscanear.Show()
        Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
        If My.Settings.USER_ROLE.Contains("administrador") Then

        Else
            BtnAdministrador.Visibility = Visibility.Hidden
            LblAdmin.Visibility = Visibility.Hidden
        End If
    End Sub

    Private Sub BtnLot_Click(sender As Object, e As RoutedEventArgs) Handles BtnLot.Click
        Dim WinLotes As New ConfgLotes
        WinLotes.Show()
        Close()

    End Sub

    Private Sub BtnImport_Click(sender As Object, e As RoutedEventArgs) Handles BtnImport.Click
        Importar()
    End Sub

    Private Sub Importar()
        Dim Explorador As New Forms.OpenFileDialog
        Explorador.InitialDirectory = "C:\\"
        Explorador.Filter = "CSV delimitado por comas (*.csv)|*.csv"
        Dim UbicacionCSV As String
        If Explorador.ShowDialog = Forms.DialogResult.OK Then
            UbicacionCSV = Explorador.FileName
            Dim Reader As New LecturaCSV(UbicacionCSV)
            Reader.Leer()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As RoutedEventArgs) Handles BtnPrint.Click
        Throw New NotImplementedException()
    End Sub

    Private Sub BtnAdministrador_Click(sender As Object, e As RoutedEventArgs) Handles BtnAdministrador.Click
        Throw New NotImplementedException()
    End Sub
End Class
