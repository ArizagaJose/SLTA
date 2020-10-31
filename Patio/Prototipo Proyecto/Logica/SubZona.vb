Imports System.Data

Public Class SubZona
    Private idSubZona As Integer
    Private idZona As Integer
    Private capacidad As Integer
    Private nombre As String
    Private esquivas As Integer
    Private filas As Integer




    Public Sub AltaSubZona()
        Dim ConexionBDD As New Conexion
        ConexionBDD.AltaSubZona(idSubZona, idZona, capacidad, nombre, esquivas, filas)
    End Sub
    Public Sub setCapacidad(capacidad As Integer)
        Me.capacidad = capacidad
    End Sub

    Public Sub setNombre(nombre As String)
        Me.nombre = nombre
    End Sub

    Public Sub setIdSubZona(idsubzona As Integer)
        Me.idSubZona = idsubzona
    End Sub

    Public Sub setIdZona(idZona As Integer)
        Me.idZona = idZona
    End Sub

    Public Sub setEsquivas(esquivas As Integer)
        Me.esquivas = esquivas
    End Sub

    Public Sub setFilas(filas As Integer)
        Me.filas = filas
    End Sub



    Public Function devolverSubZonas() As String()
        Dim BDD As New Conexion
        Dim DataS As New System.Data.DataSet
        DataS = BDD.devolverSubZonas
        Dim lista As String() = (From vin In DataS.Tables(0).AsEnumerable Select vin.Field(Of String)("nombre")).ToArray
        Return lista
    End Function


    Public Function InformacionSubZona(Nombre As String) As SubZona
        Dim bdd As New Conexion
        Dim DataT As New System.Data.DataTable
        DataT = bdd.InfoSubZonas(Nombre)
        Dim fila As DataRow() = (From row As DataRow In DataT.Rows.Cast(Of DataRow) Select row).ToArray()
        Dim lista As DataRow = fila(0)
        Me.idSubZona = lista(0).ToString
        Me.idZona = lista(1).ToString
        Me.capacidad = lista(2).ToString
        Me.nombre = lista(3).ToString
        Me.esquivas = lista(4).ToString
        Me.filas = lista(5).ToString

        Return Me
    End Function

    Public Function getIdSubZona() As String
        Return idSubZona
    End Function

    Public Function getidZona() As String
        Return idZona
    End Function

    Public Function getCapacidad() As String
        Return capacidad
    End Function

    Public Function getNombre() As String
        Return nombre
    End Function

    Public Function getEsquiva() As String
        Return esquivas
    End Function

    Public Function getFila() As String
        Return filas
    End Function

End Class
