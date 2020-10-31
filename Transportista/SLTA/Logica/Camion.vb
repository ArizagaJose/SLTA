Imports System.Data

Public Class Camion
    Private idcamion As String
    Private matricula As String
    Private Capacidad As String
    Private Correo As String
    Private Telefono As String
    Private Contraseña As String

    Public Function devolverCamiones() As IEnumerable
        Dim bdd As New Conexion
        Dim DataS As New DataSet
        Dim DataT As New DataTable
        DataS = bdd.DevolverCamiones
        Dim NuevaColumna As New DataColumn("ID", GetType(Integer))
        DataT.Columns.Add(NuevaColumna)
        NuevaColumna = New DataColumn("Matricula", GetType(String))
        DataT.Columns.Add(NuevaColumna)
        DataS.Tables.Add(DataT)
        Dim datos As IEnumerable
        Dim query = (From fila In DataS.Tables(0).AsEnumerable Select ID = fila.Item(0), Matricula = fila.Item(1)).ToList()
        datos = query
        Return datos
    End Function

    Public Function devolverCamionesViaje() As IEnumerable
        Dim bdd As New Conexion
        Dim DataS As New DataSet
        Dim DataT As New DataTable
        DataS = bdd.DevolverCamionesEnViaje
        Dim NuevaColumna As New DataColumn("ID", GetType(Integer))
        DataT.Columns.Add(NuevaColumna)
        DataS.Tables.Add(DataT)
        Dim datos As IEnumerable
        Dim query = (From fila In DataS.Tables(0).AsEnumerable Select ID = fila.Item(0)).ToList()
        datos = query
        Return datos
    End Function

    Public Sub SetIDCamion(id As String)
        idcamion = id
    End Sub

    Public Function getIDCamion() As String
        Return idcamion
    End Function






End Class
