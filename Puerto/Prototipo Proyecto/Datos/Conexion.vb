Imports System.Data
Imports System.Data.Odbc

Public Class Conexion
    Private ODBCCon As New OdbcConnection
    Private ODBCCom As New OdbcCommand
    Private CadenaDSN As String
    Private SQLInsert As String
    Private dr As OdbcDataReader

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

    Public Function Conectar(nombre As String, pwd As String) As Boolean
        Try
            CadenaDSN = "FileDsn=" & System.IO.Directory.GetCurrentDirectory.ToString & "\ConexionInformix.dsn;UID=" & nombre & ";PWD=" & pwd & ""
            ODBCCon.ConnectionString = CadenaDSN
            ODBCCon.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            CerrarCon()
            Return False
        End Try
    End Function

    Public Sub AltaVehiculo(ByVal VIN As String, ByVal Marca As String, ByVal Modelo As String, ByVal Año As Integer, ByVal Color As String, ByVal Pais As String, ByVal Tipo As String)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO vehiculo VALUES('" & VIN & "',0,'" & Marca & "','" & Modelo & "','" & Año & "','" & Color & "','" & Pais & "','" & Tipo & "','f',NULL);"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Ingreso exitoso")
        Catch ex As Exception
            MsgBox("Hubo un error al querer insertar un vehiculo")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub



    Public Function devolverVehiculos() As DataSet
        Try
            Dim DataSetV As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * FROM vehiculo where baja='f'"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV, "vehiculo")
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar vehiculos")
            CerrarCon()
        End Try
#Disable Warning BC42105 ' La función no devuelve un valor en todas las rutas de código
    End Function
#Enable Warning BC42105 ' La función no devuelve un valor en todas las rutas de código

    Public Function devolverVehiculosLote() As DataSet
        Try
            Dim DataSetV As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * FROM vehiculo WHERE baja='f' and idlote IS NULL"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV, "vehiculo")
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar vehiculos")
            CerrarCon()
        End Try
#Disable Warning BC42105 ' La función no devuelve un valor en todas las rutas de código
    End Function
#Enable Warning BC42105 ' La función no devuelve un valor en todas las rutas de código

    Public Function InfoVehiculo(Vin As String) As DataTable
        Try
            Dim DataSetV As New DataTable
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * FROM vehiculo where baja='f' and vin = """ & Vin & """;"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetV)
            Return DataSetV
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer mostrar vehiculos")
            CerrarCon()
        End Try
    End Function

    Public Sub AltaLote(idlote As Integer, capacidad As Integer)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO lote values(" & idlote & ",""Armado""," & capacidad & ",'f');"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
            MsgBox("Ingreso exitoso")
        Catch ex As Exception
            MsgBox("Hubo un error al querer crear un lote")
            CerrarCon()
        End Try
    End Sub

    Public Sub ArmarLote(VIN As String, idlote As Integer)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "UPDATE vehiculo SET idlote = " & idlote & " WHERE vin = """ & VIN & """;"
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = SQLInsert
            ODBCCom.ExecuteReader()
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer armar el lote")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub

    Public Function UltimoLote() As Integer
        Dim idlote As Integer
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT idlote FROM lote order by idlote desc limit 1"
            idlote = ODBCCom.ExecuteScalar()
            CerrarCon()
            idlote += 1
            Return idlote
        Catch ex As Exception
            MsgBox("Error, contacte a su administrador")
        End Try
    End Function

    Public Sub AltaInspeccion(Vin As String, daños As List(Of Daño))
        Try
            Dim idinspeccion As Integer
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "INSERT INTO inspeccion VALUES('0','" & DateTime.Now.ToString("yyyy-MM-dd HH:mm") & "','" & Vin & "','f');"
            ODBCCom.ExecuteReader()
            CerrarCon()
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.CommandText = "select idinspeccion from inspeccion order by fecha desc limit 1"
            idinspeccion = ODBCCom.ExecuteScalar
            CerrarCon()
            If daños.Count > 0 - 1 Then
                For Each daño In daños
                    Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
                    ODBCCom.CommandText = "INSERT INTO danio values(0,'" & daño.GetDescripcion & "','" & daño.GetFoto & "','f'," & idinspeccion & ");"
                    ODBCCom.ExecuteReader()
                    CerrarCon()
                Next
            End If
            CerrarCon()
            MsgBox("Ingreso exitoso")
        Catch ex As Exception
            MsgBox("Hubo un error al querer insertar una inspeccion")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Sub

    Public Function ComprobarInspeccion(vin As String) As Boolean
        Try
            Dim contador As Integer = 0
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "select count(idinspeccion) from inspeccion where vin= """ & vin & """;"
            contador = ODBCCom.ExecuteScalar()
            CerrarCon()
            If (contador > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            MsgBox(ex.ToString)
            CerrarCon()
        End Try
    End Function

    Public Sub AltaDaño(ByVal IdDaño As Integer, ByVal Descripcion As String, ByVal Imagen As String, ByVal Baja As String, ByVal IdInspeccion As Integer)
        Try
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            SQLInsert = "INSERT INTO danio VALUES('" & IdDaño & "','" & Descripcion & "','" & Imagen & "','" & Baja & "','" & IdInspeccion & "');"
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

    Public Function DevolverInspeccion(VIN As String) As DataSet
        Try
            Dim DataSetI As New DataSet
            Dim ODBCDataAdapter As New Odbc.OdbcDataAdapter
            Conectar(My.Settings.USER_NAME, My.Settings.USER_PWD)
            ODBCCom.Connection = ODBCCon
            ODBCCom.CommandText = "SELECT * from inspeccion WHERE vin = """ & VIN & """;"
            ODBCCom.ExecuteNonQuery()
            ODBCDataAdapter.SelectCommand = ODBCCom
            ODBCDataAdapter.Fill(DataSetI)
            Return DataSetI
            CerrarCon()
        Catch ex As Exception
            MsgBox("Hubo un error al querer devolver una inspeccion")
            MsgBox(ex.ToString)
            CerrarCon()
        End Try

    End Function


    Public Sub CerrarCon()
        ODBCCon.Close()
    End Sub


End Class

