Imports System.Data

Public Class Zona

    Private id As Integer
    Private capacidad As Integer
    Private nombre As String
    Private idpatio As Integer
    Private esquivas As Integer
    Private filas As Integer


    Public Sub AltaZona()
        Dim ConexionBDD As New Conexion
        ConexionBDD.AltaZona(id, capacidad, nombre, idpatio, esquivas, filas)
    End Sub


    Public Sub setID(id As Integer)
        Me.id = id
    End Sub
    Public Sub setCapacidad(capacidad As Integer)
        Me.capacidad = capacidad
    End Sub

    Public Sub setNombre(nombre As String)
        Me.nombre = nombre
    End Sub

    Public Sub setIdPatio(idpatio As Integer)
        Me.idpatio = idpatio
    End Sub

    Public Sub setEsquivas(esquivas As Integer)
        Me.esquivas = esquivas
    End Sub

    Public Sub setFilas(filas As Integer)
        Me.filas = filas
    End Sub


    Public Function devolverZonas() As String()
        Dim BDD As New Conexion
        Dim DataS As New System.Data.DataSet
        DataS = BDD.devolverZonas
        Dim lista As String() = (From vin In DataS.Tables(0).AsEnumerable Select vin.Field(Of String)("nombre")).ToArray
        Return lista
    End Function


    Public Function InformacionZona(Nombre As String) As Zona
        Dim bdd As New Conexion
        Dim DataT As New System.Data.DataTable
        DataT = bdd.InfoZonas(Nombre)
        Dim fila As DataRow() = (From row As DataRow In DataT.Rows.Cast(Of DataRow) Select row).ToArray()
        Dim lista As DataRow = fila(0)
        Me.id = lista(0).ToString
        Me.capacidad = lista(1).ToString
        Me.nombre = lista(2).ToString
        Me.idpatio = lista(3).ToString
        Me.filas = lista(4).ToString
        Me.esquivas = lista(5).ToString

        Return Me
    End Function


    Public Function getId() As String
        Return id
    End Function

    Public Function getCapacidad() As String
        Return capacidad
    End Function

    Public Function getNombre() As String
        Return nombre
    End Function

    Public Function getPatio() As String
        Return idpatio
    End Function
    Public Function getFila() As String
        Return filas
    End Function

    Public Function getEsquiva() As String
        Return esquivas
    End Function

    Public Function getIdPatio() As String
        Return idpatio
    End Function












End Class
