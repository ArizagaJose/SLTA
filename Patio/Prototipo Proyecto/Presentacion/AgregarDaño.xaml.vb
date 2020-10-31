Imports System.Net
Imports System.Text

Public Class AgregarDaño
    Public IdInspec As String

    Dim url As String
    Dim b64 As String
    Private IMGUR_CLIENT_ID As String = "a57f7c82af1b673"

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs) Handles MyBase.Loaded
        LblUsuario.Content = My.Settings.USER_NAME
        IdInspec = TextBoxNroInsp.Text


    End Sub

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinAtras As New Inspeccionar
        WinAtras.Show()
        Close()
    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As RoutedEventArgs) Handles BtnIngresar.Click
        Dim InspeccionarVehiculo As New Inspeccionar
        Dim conexion As New Conexion
        Dim w As New WebClient()
        w.Headers.Add("Authorization", "Client-ID " & IMGUR_CLIENT_ID)
        Dim keys As New System.Collections.Specialized.NameValueCollection
        Try
            keys.Add("image", b64)
            Dim responseArray As Byte() = w.UploadValues("https://api.imgur.com/3/image", keys)
            Dim result = Encoding.ASCII.GetString(responseArray)
            Dim reg As New System.Text.RegularExpressions.Regex("link"":""(.*?)""")
            Dim match As RegularExpressions.Match = reg.Match(result)
            url = match.ToString.Replace("link"":""", "").Replace("""", "").Replace("\/", "/")
            MsgBox(url)
        Catch ex As Exception
            MsgBox("LA URL ES: " & ex.Message)
        End Try
        InspeccionarVehiculo.AgregarDaño(IdInspec, TextBoxDesc.Text, url)
        MsgBox("El daño, " & TextBoxNombre.Text & "  ha sido agregado")

        Dim WinInspeccion As New Inspeccionar
        WinInspeccion.Show()
        Close()







    End Sub

    Private Sub Grid1_Loaded(sender As Object, e As RoutedEventArgs) Handles grid1.Loaded
        Dim ExtraerIdDaño As New Conexion

        Dim iddanio As Integer = ExtraerIdDaño.EjecutarSentencia("SELECT iddanio from danio order by iddanio desc limit 1", "iddanio") + 1
    End Sub

    Private Sub BtnExaminar_Click(sender As Object, e As RoutedEventArgs) Handles BtnExaminar.Click
        Dim Explorador As New Forms.OpenFileDialog
        Explorador.InitialDirectory = "C:\\"
        If Explorador.ShowDialog = Forms.DialogResult.OK Then
            Dim ruta As String = Explorador.FileName
            b64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(ruta))
        End If
    End Sub
End Class
