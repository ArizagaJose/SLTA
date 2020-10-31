Imports System.Net
Imports System.Text

Public Class AgregarDaño
    Private insc As Inspeccion
    Private IMGUR_CLIENT_ID As String = "a57f7c82af1b673"
    Private b64 As String
    Dim url As String
    Dim ruta As String
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As RoutedEventArgs) Handles BtnIngresar.Click
        Dim inspc As New InspeccionarVehiculo
        Dim desc As String = TextBoxDesc.Text

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
        Catch ex As Exception
            MsgBox("Hubo un error")
        End Try
        Dim d As New Daño(desc, url)
        insc.AgregarDaño(d)
        Dim WinInspeccion As New InspeccionarVehiculo
        WinInspeccion.SetInspeccionOBJ(insc)
        WinInspeccion.Show()
        Close()
    End Sub

    Public Sub SetInspeccion(i As Inspeccion)
        insc = i
    End Sub

    Public Function GetInspeccion()
        Return insc
    End Function

    Private Sub BtnExaminar_Click(sender As Object, e As RoutedEventArgs) Handles BtnExaminar.Click
        Dim Explorador As New Forms.OpenFileDialog
        Explorador.InitialDirectory = "C:\\"
        Explorador.Filter = "Imágenes (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG"
        If Explorador.ShowDialog = Forms.DialogResult.OK Then
            ruta = Explorador.FileName
            b64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(ruta))
            LblRuta.Content = ruta
        End If

    End Sub

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim winInspec As New InspeccionarVehiculo
        winInspec.Show()
        Close()
    End Sub

    Public Function ConvertFileToBase64(ByVal fileName As String) As String
        Return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName))
    End Function
End Class
