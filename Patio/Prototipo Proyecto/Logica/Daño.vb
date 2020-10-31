Public Class Daño
    Public IDDaño As Integer
    Public IdInspeccion As Integer
    Public Nombre As String
    Public Descripcion As String
    Public Foto As String

    Public Sub New(iDDaño As Integer, IdInspeccion As Integer, nombre As String, descripcion As String, foto As String)
        Me.IDDaño = iDDaño
        Me.IdInspeccion = IdInspeccion
        Me.Nombre = nombre
        Me.Descripcion = descripcion
        Me.Foto = foto
    End Sub

End Class
