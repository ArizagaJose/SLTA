Public Class ConfgZonas
    Private Sub BtnList_Click(sender As Object, e As RoutedEventArgs) Handles BtnList.Click
        Dim winListarZonas As New listarZonas
        winListarZonas.Show()
        Close()

    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim WinMZonas As New listarZonasM
        WinMZonas.Show()
        Close()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub

    Private Sub BtnInspect_Click(sender As Object, e As RoutedEventArgs) Handles BtnInspect.Click
        Dim winListarZonas As New ListarSubZonas
        winListarZonas.Show()
        Close()
    End Sub

    Private Sub BtnLot_Click(sender As Object, e As RoutedEventArgs) Handles BtnLot.Click
        Dim winMSubZona As New ListarSubZonasM
        winMSubZona.Show()
        Close()
    End Sub

    Private Sub BtnImport_Click(sender As Object, e As RoutedEventArgs) Handles BtnImport.Click
        Dim WinCrearZona As New CrearZona
        WinCrearZona.Show()
        Close()
    End Sub

    Private Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Dim winAdminMenu As New MenuAdmin
        Dim winMenu As New Menu


        If (My.Settings.USER_ROLE.ToString = "administrador                   ") Then
            winAdminMenu.Show()
            Close()
        ElseIf (My.Settings.USER_ROLE.ToString = "operariopatio                   ") Then
            winMenu.Show()
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As RoutedEventArgs) Handles BtnPrint.Click
        Dim winCrearSubZona As New CrearSubzona
        winCrearSubZona.Show()
        Close()
    End Sub
End Class
