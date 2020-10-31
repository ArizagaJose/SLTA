Imports System.Data

Public Class Lote

    Public Function DevolverLotes() As IEnumerable
        Dim bdd As New Conexion
        Dim DataS As New DataSet
        Dim DataT As New DataTable
        DataS = bdd.DevolverLotes
        Dim NuevaColumna As New DataColumn("ID", GetType(Integer))
        DataT.Columns.Add(NuevaColumna)
        NuevaColumna = New DataColumn("Capacidad", GetType(String))
        DataT.Columns.Add(NuevaColumna)
        DataS.Tables.Add(DataT)
        Dim datos As IEnumerable
        Dim query = (From fila In DataS.Tables(0).AsEnumerable Select ID = fila.Item(0), Capacidad = fila.Item(1)).ToList()
        datos = query
        Return datos
    End Function

    Public Sub AltaLoteCamion(idlote As String, idcamion As String)
        Dim bdd As New Conexion
        bdd.AltaLoteCamion(idlote, idcamion)
    End Sub


End Class
