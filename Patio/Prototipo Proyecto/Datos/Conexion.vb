Imports System.Data
Imports System.Data.Odbc

Public Class Conexion

    Shared Patios As New List(Of Patio)

    Private ODBCCon As New OdbcConnection
    Private ODBCCom As New OdbcCommand
    Private CadenaDSN As String
    Private SQLInsert As String
    Private dr As OdbcDataReader


    Public Function Conectar(nombre As String, pwd As String) As Boolean
        Try
            CadenaDSN = "FileDsn=" & System.IO.Directory.GetCurrentDirectory.ToString & "\ConexionInformix.dsn;UID=" & nombre & ";PWD=" & pwd & ""
            ODBCCon.ConnectionString = CadenaDSN
            ODBCCon.Open()
            Return True
        Catch ex As Exception
            ODBCCon.Close()
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function


    Public Sub AltaInspeccionPatio(ByVal IdInspeccion As Integer, ByVal Ci As Integer, ByVal baja As String)
        Try
            Dim idDaño2 As Integer = 0
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO inspeccionpatio VALUES('" & IdInspeccion & "','" & Ci & "','" & baja & "');"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer asignar una inspeccion al patio")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub

    Public Function devolverLotesEnCamino() As DataSet
        Try
            Dim DataSetV As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT idlote FROM lote where estado = 'en camino'"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV, "lote")
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar subzona")
            CerrarCon()
        End Try
    End Function

    Public Function devolverVehiculosDeLotes() As DataSet
        Try
            Dim DataSetV As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "Select vehiculo.vin from vehiculo join lote
                On vehiculo.idlote = lote.idlote
                where lote.estado = 'Arribado'"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV, "subzona")
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar subzona")
            CerrarCon()
        End Try
    End Function

    Public Function devolverZonas() As DataSet
        Try
            Dim DataSetV As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * FROM zona where baja='f'"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV, "zona")
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar zona")
            CerrarCon()
        End Try
    End Function





    Public Function devolverSubZonas() As DataSet
        Try
            Dim DataSetV As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * FROM subzona where baja='f'"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV, "subzona")
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar subzona")
            CerrarCon()
        End Try
    End Function

    Public Function InfoSubZonas(Nombre As String) As DataTable
        Try
            Dim DataSetV As New DataTable
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * FROM subzona where baja='f' and nombre like '" & Nombre & "';"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV)
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar subzonas")
            CerrarCon()
        End Try
    End Function
    Public Function InfoZonas(Nombre As String) As DataTable
        Try
            Dim DataSetV As New DataTable
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * FROM zona where baja='f' and nombre like '" & Nombre & "';"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV)
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar zonas")
            CerrarCon()
        End Try
    End Function


    Public Sub AltaInspeccion(ByVal IdIspeccion As Integer, ByVal Fecha As String, ByVal Vin As String, ByVal Baja As String)
        Try
            Dim idInspeccion2 As Integer = 0
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO inspeccion VALUES('" & idInspeccion2 & "','" & Fecha & "','" & Vin & "','" & Baja & "');"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()

            MsgBox("Ingreso exitoso")
        Catch ex As Exception
            MsgBox("Hubo un error al querer insertar una inspeccion")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub
    Public Sub modificarZona(ByVal IdZona As Integer, ByVal Capacidad As Integer, ByVal Nombre As String, ByVal IdPatio As Integer, ByVal Estiva As Integer, ByVal Fila As Integer)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)

            SQLInsert = "UPDATE zona SET (idzona,capacidad,nombre,idpatio,esquivas,filas) = (" & IdZona & "," & Capacidad & ",'" & Nombre & "'," & IdPatio & "," & Estiva & "," & Fila & ") where idzona = " & IdZona & ";"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Modificacion exitosa")
        Catch ex As Exception
            MsgBox("Hubo un error al querer modificar una zona")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub
    Public Sub AsignarVehiuclo(ByVal Vin As String, ByVal idzona As Integer, ByVal fila As String, ByVal estiva As Integer)
        Try
            Dim baja As String = "f"
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO ubicacion values('" & Vin & "','" & fila & "','" & estiva & "','" & idzona & "','" & baja & "');"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Eliminacion exitosa")
        Catch ex As Exception
            MsgBox("Hubo un error al querer eliminar un vehiculo de una zona")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub

    Public Sub BajaVehiculoZona(ByVal Vin As String)
        Try
            Dim baja As String = "f"
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "UPDATE ubicacion SET baja ='t'  where vin = " & Vin & ";"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Asignacio exitosa")
        Catch ex As Exception
            MsgBox("Hubo un error al querer asignar un vehiculo")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub
    Public Sub EliminarSubZona(ByVal Idsubzona As String)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "update subzona set baja = 't' where idsubzona = " & Idsubzona
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Eliminacion exitosa")
        Catch ex As Exception
            MsgBox("Hubo un error al querer eliminar una subzona")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub
    Public Sub EliminarZona(ByVal Idzona As String)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "update zona set baja = 't' where idzona = " & Idzona
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Eliminacion exitosa")
        Catch ex As Exception
            MsgBox("Hubo un error al querer eliminar una zona")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub
    Public Sub modificarSubZona(ByVal IdSubZona As Integer, ByVal IdZona As Integer, ByVal Capacidad As Integer, ByVal Nombre As String, ByVal Estiva As Integer, ByVal Fila As Integer)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "UPDATE subzona SET (idzona,capacidad,nombre,esquivas,filas) = (" & IdZona & "," & Capacidad & ",'" & Nombre & "'," & Estiva & "," & Fila & ") where idsubzona = " & IdSubZona & ";"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Modificacion exitosa")
        Catch ex As Exception
            MsgBox("Hubo un error al querer modificar una subzona")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub


    Public Sub AltaDaño(ByVal IdDaño As Integer, ByVal Descripcion As String, ByVal Imagen As String, ByVal Baja As String, ByVal IdInspeccion As Integer)
        Try
            Dim idDaño2 As Integer = 0
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO danio VALUES('" & idDaño2 & "','" & Descripcion & "','" & Imagen & "','" & Baja & "','" & IdInspeccion & "');"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer insertar una daño")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub
    Public Sub MarcarLoteComoArribado(idlote As Integer)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "UPDATE lote set estado='Arribado' where idlote=" & idlote & ";"

            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Marcado correctamente")
        Catch ex As Exception

            MsgBox("Hubo un error al querer marcar un lote como arribado")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub


    Public Sub CargarPatios()
        Dim ODBCDataAdapter As New OdbcDataAdapter
        Dim ODBCDataSet As New Data.DataSet
        Dim Datagrid As New Forms.DataGridView
        Dim Datatable As New Data.DataTable

        Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)

        ODBCCom.Connection = ODBCCon
        ODBCCom.CommandText = "SELECT * FROM patio"
        ODBCCom.ExecuteNonQuery()
        ODBCDataAdapter.SelectCommand = ODBCCom
        ODBCDataAdapter.Fill(ODBCDataSet, "patio")
        Dim i As Integer = 0
        For Each dr As DataRow In Datatable.Rows

            Patios.Insert(i, dr("nombre"))

            i += 1

        Next

        CerrarCon()

    End Sub


    Public Sub AltaZona(ByVal IdZona As Integer, ByVal Capacidad As Integer, ByVal Nombre As String, ByVal IdPatio As Integer, ByVal Estiva As Integer, ByVal Fila As Integer)
        Dim baja As String = "f"
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO zona VALUES('" & IdZona & "','" & Capacidad & "','" & Nombre & "','" & IdPatio & "','" & Estiva & "','" & Fila & "','" & baja & "');"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Ingreso exitoso")
        Catch ex As Exception
            MsgBox("Hubo un error al querer insertar una zona")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub

    Public Sub AltaSubZona(ByVal IdSubZona As Integer, ByVal idZona As Integer, ByVal Capacidad As Integer, ByVal Nombre As String, ByVal Estiva As Integer, ByVal Fila As Integer)
        Dim baja As String = "f"

        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO subzona VALUES('" & IdSubZona & "','" & idZona & "','" & Capacidad & "','" & Nombre & "','" & Estiva & "','" & Fila & "','" & baja & "');"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Ingreso exitoso")
        Catch ex As Exception
            MsgBox("Hubo un error al querer insertar una zona")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub


    Public Function listavehiculo() As DataSet
        Try
            Dim DataSetZ As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT vin from vehiculo"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetZ, "vehiculo")
            Return DataSetZ
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al descargar vehiculo")
            CerrarCon()
        End Try
    End Function


    Public Function listaZona() As DataSet
        Try
            Dim DataSetZ As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT idzona,nombre from zona"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetZ, "zona")
            Return DataSetZ
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al descargar zona")
            CerrarCon()
        End Try
    End Function
    Public Function listaZona2(ByVal idpatio As String) As DataSet
        Try
            Dim DataSetZ As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT zona.idzona,zona.nombre from zona join patio on patio.idpatio = zona.idpatio where patio.idpatio =" & idpatio & "and zona.baja='f'"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetZ, "zona")
            Return DataSetZ
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al descargar zona")
            CerrarCon()
        End Try
    End Function

    Public Function listaPatio() As DataSet
        Try
            Dim DataSetZ As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT idpatio,nombre from patio"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetZ, "patio")
            Return DataSetZ
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al descargar patio")
            CerrarCon()
        End Try
    End Function

    Public Function listaLotes() As DataSet
        Try
            Dim DataSetZ As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)

            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT idlote from lote"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetZ, "lote")
            Return DataSetZ
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al descargar lote")
            CerrarCon()
        End Try
    End Function

    Public Function listaSubZona() As Forms.DataGridView
        Try
            Dim ODBCDataAdapter As New OdbcDataAdapter
            Dim ODBCDataSet As New Data.DataSet
            Dim Datagrid As New Forms.DataGridView
            Dim Datatable As New Data.DataTable
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)


            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * FROM subzona"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(ODBCDataSet, "vehiculo")
            Datagrid.DataSource = ODBCDataSet.Tables("vehiculo")
            Return Datagrid
        Catch ex As Exception
            MsgBox("Hubo un error al descargar SubZona")
            CerrarCon()
        End Try
    End Function
    Public Function EjecutarSentencia(ByVal Sentencia As String, ByVal extractor As String)
        Try
            Dim ODBCDataAdapter As New OdbcDataAdapter
            Dim ODBCDataSet As New Data.DataSet
            Dim Datagrid As New Forms.DataGridView
            Dim Datatable As New Data.DataTable
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

    Public Sub CerrarCon()
        ODBCCon.Close()
    End Sub

End Class
