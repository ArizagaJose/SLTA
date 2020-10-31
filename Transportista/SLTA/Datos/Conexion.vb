Imports System.Data
Imports System.Data.Odbc

Public Class Conexion
    Private ODBCCon As New OdbcConnection
    Private ODBCCom As New OdbcCommand
    Private CadenaDSN As String
    Private SQLInsert As String

    Public Sub RolUsuario(usr As String, pwd As String)
        Dim rol As String
        Try
            Conectar(usr, pwd)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT rolename from sysroleauth where grantee like '" & usr & "';"
            rol = ODBCCom.ExecuteScalar()
            CerrarCon()
            My.Settings.USER_ROLE = rol
        Catch ex As Exception

        End Try

    End Sub

    Public Function Conectar(nombre As String, pwd As String) As Boolean
        Try
            CadenaDSN = "FileDsn=" & System.IO.Directory.GetCurrentDirectory.ToString & "\ConexionInformix.dsn;UID=" & nombre & ";PWD=" & pwd & ""
            ODBCCon.ConnectionString = CadenaDSN
            ODBCCon.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            ODBCCon.Close()
            Return False
        End Try
    End Function

    Public Function DevolverPatios() As DataSet
        Try
            Dim DataSetP As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT nombre from patio;"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetP)
            CerrarCon()
            Return DataSetP
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar descargar los patios")
            CerrarCon()
        End Try
    End Function

    Public Function DevolverLotes() As DataSet
        Try
            Dim DataSetL As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT idlote,capacidad FROM lote where baja='f' and estado = ""Armado"" and idlote NOT IN(select idlote from lotecamion where baja='f');"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetL)
            Return DataSetL
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar los lotes")
            CerrarCon()
        End Try
    End Function

    Public Function DevolverCamiones() As DataSet
        Try
            Dim DataSetC As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT idcamion,matricula FROM camion where baja='f';"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetC)
            Return DataSetC
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar los camiones")
            CerrarCon()
        End Try
    End Function

    Public Function DevolverCamionesEnViaje() As DataSet
        Try
            Dim DataSetC As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT idcamion FROM camion where idcamion IN(select idcamion from lotecamion where idlote IN(select idlote from lote where estado=""En Camino"";"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetC)
            Return DataSetC
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar los camiones")
            CerrarCon()
        End Try
    End Function

    Public Sub AltaLoteCamion(idlote As String, idcamion As String)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "insert into lotecamion values(" & idcamion & "," & idlote & ",'f');"
            ODBCCom.ExecuteReader()
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer armar el embarque")
            CerrarCon()
        End Try
    End Sub

    Public Sub AltaViaje(idlote As String, idpatio As String, FechaInicio As String, FechaEsperada As String)
        Dim id As String
        Dim ci As String
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = ("Select idpatio from patio where nombre=""" & idpatio & """;")
            id = ODBCCom.ExecuteScalar
            CerrarCon()
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.CommandText = "select ci from funcionario where user=""" & My.Settings.USER_NAME & """;"
            ci = ODBCCom.ExecuteScalar().ToString
            CerrarCon()
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.CommandText = "insert into viaje values(" & idlote & "," & id & ",'" & FechaInicio & "'," & "'" & FechaEsperada & "',NULL," & ci & ",'f');"
            ODBCCom.ExecuteReader()
            CerrarCon()
        Catch ex As Exception
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub


    Public Sub ActualizarLote(idlote As String)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = ("update lote set estado=""En camino"" where idlote=" & idlote & ";")
            ODBCCom.ExecuteReader()
        Catch es As Exception

        End Try
    End Sub


    Public Sub CancelarViaje(idlote As String, idcamion As String)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "update lotecamion set baja = 't' where idlote=" & idlote & " and idcamion=" & idcamion & ";"
            ODBCCom.ExecuteReader()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar los camiones")
            CerrarCon()
        End Try
    End Sub

    Public Function UbicacionCamion(idcamion As String) As String()
        Dim lista As String()
        Dim usr As String
        Dim pwd As String
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "select correo from camion where idcamion =" & idcamion & ";"
            usr = ODBCCom.ExecuteScalar()
            CerrarCon()
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "select contrasenia from camion where idcamion =" & idcamion & ";"
            pwd = ODBCCom.ExecuteScalar()
            CerrarCon()
            lista(0) = usr
            lista(2) = pwd
            Return lista
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar los camiones")
            CerrarCon()

        End Try
    End Function


    Public Function EjecutarSentencia(ByVal Sentencia As String, ByVal extractor As String)
        Try
            Dim ODBCDataAdapter As New OdbcDataAdapter
            Dim ODBCDataSet As New Data.DataSet
            Dim Datatable As New Data.DataTable
            Dim dr As OdbcDataReader
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)


            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = Sentencia

            dr = ODBCCom.ExecuteReader()


            If dr.HasRows Then

                Return dr(extractor)

            End If
            CerrarCon()
            Return False
        Catch ex As Exception
            MsgBox("Hubo un error al ejecutar sentencia")
            CerrarCon()
        End Try

    End Function

    Public Sub FinalizarViaje(idlote As String, fecha As Date)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "update viaje set baja = 't' where idlote=" & idlote & ";"
            ODBCCom.ExecuteReader()
            CerrarCon()
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "update viaje set fechafinal = '" & fecha & "' where idlote=" & idlote & ";"
            ODBCCom.ExecuteReader()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar los camiones")
            CerrarCon()
        End Try
    End Sub
    Public Sub CerrarCon()
        ODBCCon.Close()
    End Sub


End Class

