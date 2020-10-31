Public Class UsserSettings
    Private Sub ButtonAtras_Click(sender As Object, e As RoutedEventArgs) Handles ButtonAtras.Click
        Dim WinAdminMenu As New MenuAdmin
        Dim winMenu As New Menu

        If (My.Settings.USER_ROLE.ToString = "administrador                   ") Then
            WinAdminMenu.Show()
            Close()
        ElseIf (My.Settings.USER_ROLE.ToString = "operariopatio                   ") Then
            winMenu.Show()

            Close()
        End If
    End Sub

    Private Sub ButtonLogout_Click(sender As Object, e As RoutedEventArgs) Handles ButtonLogout.Click
        Dim winLogin As New Login
        winLogin.Show()
        Close()
    End Sub

    Private Sub TxtBoxUsuario_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TxtBoxUsuario.TextChanged

    End Sub

    Private Sub Grid1_Loaded(sender As Object, e As RoutedEventArgs) Handles grid1.Loaded
        TxtBoxUsuario.Text = My.Settings.USER_NAME
        TxtBoxRol.Text = My.Settings.USER_ROLE
    End Sub
End Class
