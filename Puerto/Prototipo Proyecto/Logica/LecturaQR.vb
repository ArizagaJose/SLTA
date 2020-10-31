Imports Dynamsoft.Barcode
Public Class LecturaQR
    Dim ruta As String

    Public Sub New(ruta As String)
        Me.ruta = ruta
    End Sub

    Public Sub ReconocerQR()
        Try
            Dim DBR As New BarcodeReader()
            DBR.LicenseKeys = "t0068UwAAABmJM6DOuqwKOoqTEML6dtg6LyAlkgejvJpSIerRIK0aD3LA9hLiBY4suV2BidC0j65L4rgF0HJfEstCaFul9+I="
            Dim resultado As TextResult() = DBR.DecodeFile(ruta, "")
            If (resultado.Length = 0) Then

                MsgBox("No se encontró un VIN")

            Else

                For i As Integer = 0 To i > resultado.Length

                    Dim v As New WinVehiculo
                    v.SetVinAux(resultado(i).BarcodeText)
                    v.Show()

                Next


            End If

        Catch ex As BarcodeReaderException
            MsgBox(ex.ToString)
            MsgBox("Se produjo un error, contactese con su administrador")
        End Try

    End Sub
End Class
