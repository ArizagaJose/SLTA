Class Login
    Private Sub Ventana_Loaded(sender As Object, e As RoutedEventArgs) Handles Ventana.Loaded
        SetLanguage("español")
    End Sub

    Private Sub ButtonIngresar_Click(sender As Object, e As RoutedEventArgs) Handles ButtonIngresar.Click
        Conectar()
    End Sub


    Private Sub Conectar()
        Dim ConexionBDD As New Conexion
        Dim rol As New Conexion

        If ConexionBDD.Conectar(TxtBoxUsuario.Text, TxtBoxContraseña.Password) Then
            Dim WinAdminMenu As New MenuAdministrador
            Dim winMenu As New Menu




            My.Settings.USER_NAME = TxtBoxUsuario.Text
            My.Settings.USER_PWD = TxtBoxContraseña.Password

            My.Settings.USER_ROLE = rol.EjecutarSentencia("select rolename from sysroleauth where grantee ='" & TxtBoxUsuario.Text & "'", "rolename")

            If (My.Settings.USER_ROLE.ToString = "administrador                   ") Then
                WinAdminMenu.Show()
                Close()
            ElseIf (My.Settings.USER_ROLE.ToString = "transportista                   ") Then
                winMenu.Show()
                Close()
            Else
                MsgBox("Usted no puede utilizar esta aplicacion")
            End If

        Else
            MsgBox("Usuario o contraseña incorrecta")
        End If
    End Sub
    Private Sub BtnIdiomas_Click(sender As Object, e As RoutedEventArgs) Handles BtnIdiomas.Click
        BtnIdiomaIngles.Visibility = Visibility.Visible
        BtnIdiomaEspañol.Visibility = Visibility.Visible
    End Sub

    Private Sub BtnIdiomaEspañol_Click(sender As Object, e As RoutedEventArgs) Handles BtnIdiomaEspañol.Click
        SetLanguage("español")
        BtnIdiomaIngles.Visibility = Visibility.Hidden
        BtnIdiomaEspañol.Visibility = Visibility.Hidden
    End Sub

    Private Sub BtnIdiomaIngles_Click(sender As Object, e As RoutedEventArgs) Handles BtnIdiomaIngles.Click
        SetLanguage("ingles")
        BtnIdiomaIngles.Visibility = Visibility.Hidden
        BtnIdiomaEspañol.Visibility = Visibility.Hidden
    End Sub

    Private Sub Ventana_KeyDown(sender As Object, e As KeyEventArgs) Handles Ventana.KeyDown
        If e.Key = Key.Enter Then
            Conectar()
        End If
    End Sub
End Class
