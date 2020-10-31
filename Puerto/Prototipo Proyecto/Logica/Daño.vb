Imports System.Data
Imports System.IO

Public Class Daño
    Private Descripcion As String
    Private Foto As String


    Public Sub New(descripcion As String, foto As String)
        Me.Descripcion = descripcion
        Me.Foto = foto
    End Sub

    Public Function GetDescripcion() As String
        Return Descripcion
    End Function

    Public Function GetFoto() As String
        Return Foto
    End Function

End Class
