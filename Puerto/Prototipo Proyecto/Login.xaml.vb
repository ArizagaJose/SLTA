Class Login
    Private Sub ButtonLogin_Click(sender As Object, e As RoutedEventArgs) Handles ButtonIngresar.Click
        Dim ConexionBDD As New ConexionBDD

        If ConexionBDD.Conectar(TxtBoxUsuario.Text, TxtBoxContraseña.Text) Then
            Dim WinMenu As New Menu

            Close()
            My.Settings.USER_NAME = TxtBoxUsuario.Text
            WinMenu.Show()
        Else
            MsgBox("Usuario no existe")

        End If


    End Sub
End Class
