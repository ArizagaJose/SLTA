Imports iText
Imports System.Windows.Forms
Public Class GeneradorPDF

    Sub Main()
        Dim UbicacionPDF As String

        Dim explorador As New System.Windows.Forms.SaveFileDialog
        explorador.Filter = "PDF (*.pdf)|*.pdf"
        If explorador.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            UbicacionPDF = explorador.FileName
        End If

    End Sub

End Class
