Imports System.Data.Odbc

Public Class ConexionBDD
    Private ODBCCon As New OdbcConnection
    Private ODBCCom As New OdbcCommand
    Private CadenaDSN As String
    Private SQLInsert As String

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

    Public Sub altaVehiculo(ByVal VIN As String, ByVal Marca As String, ByVal Modelo As String, ByVal Año As Integer, ByVal Color As String, ByVal Pais As String, ByVal Tipo As String)
        Try
            'Conectar()
            SQLInsert = "INSERT INTO vehiculo VALUES('" & VIN & "',0,'" & Marca & "','" & Modelo & "',DATE(" & Año & "),'" & Color & "','" & Pais & "','" & Tipo & "',NULL);"
            MsgBox(SQLInsert)
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


    Public Function listaVehiculo() As Forms.DataGridView
        Dim ODBCDataAdapter As New OdbcDataAdapter
        Dim ODBCDataSet As New Data.DataSet
        Dim Datagrid As New Forms.DataGridView
        Dim Datatable As New Data.DataTable
        'Conectar()
        ODBCCom.Connection = ODBCCon
        ODBCCom.CommandText = "SELECT * FROM vehiculo"
        ODBCCom.ExecuteNonQuery()
        ODBCDataAdapter.SelectCommand = ODBCCom
        ODBCDataAdapter.Fill(ODBCDataSet, "vehiculo")
        Datagrid.DataSource = ODBCDataSet.Tables("vehiculo")
        Return Datagrid
    End Function

    Public Sub CerrarCon()
        ODBCCon.Close()
    End Sub

End Class

