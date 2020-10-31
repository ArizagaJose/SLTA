Imports System.Data
Public Class Inspeccion
    Private idvehiculo As String
    Private fecha As Date
    Private inspeccionado As Boolean
    Private Daños As New List(Of Daño)

    Public Sub SetIDVehiculo(vin As String)
        idvehiculo = vin
    End Sub

    Public Function GetIDVehiculo()
        Return idvehiculo
    End Function

    Public Sub AltaInspeccion()
        Dim BDD As New Conexion
        BDD.AltaInspeccion(idvehiculo, Daños)
    End Sub

    Public Sub SetFecha(fecha As DateTime)
        Me.fecha = fecha
    End Sub

    Public Function GetFecha()
        Return fecha
    End Function

    Public Function ComprobarInspeccion() As Boolean
        Dim DataSetI As DataSet
        Dim bdd As New Conexion
        If bdd.ComprobarInspeccion(idvehiculo) Then
            DataSetI = bdd.DevolverInspeccion(idvehiculo)
            Dim fechalist As Date() = (From fila In DataSetI.Tables(0).AsEnumerable Select fila.Field(Of Date)("fecha")).ToArray
            fecha = fechalist(0)

            Return True
        Else
            Return False
        End If

    End Function

    Public Sub AgregarDaño(d As Daño)
        Daños.Add(d)
    End Sub

    Public Function DevolverDaños() As List(Of Daño)
        Return Daños
    End Function

    Public Function GetInspeccionado() As Boolean
        Return inspeccionado
    End Function

End Class
