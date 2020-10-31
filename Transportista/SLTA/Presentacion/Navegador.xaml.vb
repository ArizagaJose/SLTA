Imports CefSharp
Imports CefSharp.Wpf

Public Class Navegador
    Dim pwd As String
    Dim usr As String

    Public Sub SetAux(l As String())
        pwd = l(1)
        usr = l(0)
    End Sub

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
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

    Private Sub Browser_FrameLoadEnd(sender As Object, e As FrameLoadEndEventArgs)

        Browser.SetZoomLevel(-5.0)
        Browser.ExecuteScriptAsync("document.getElementById('identifierId').value=""" & usr & """")
        Browser.ExecuteScriptAsync("document.getElementById('identifierNext').click()")

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        TxtBoxContraseña.Text = pwd
    End Sub
End Class
