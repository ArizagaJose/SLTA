Imports System.Data

Public Class Viaje

    Public Function DevolverPatios() As String()
        Dim bdd As New Conexion
        Dim Patios As DataSet
        Patios = bdd.DevolverPatios
        Return (From fila In Patios.Tables(0).AsEnumerable Select fila.Field(Of String)("nombre")).ToArray
    End Function

    Public Sub AltaViaje(idlote As String, patio As String, horainicio As String, horaesperada As String)
        Dim bdd As New Conexion
        bdd.AltaViaje(idlote, patio, horainicio, horaesperada)
        bdd.ActualizarLote(idlote)
    End Sub

End Class
