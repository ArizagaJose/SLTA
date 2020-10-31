Imports System.Data

Public Class modificarZona
    Dim Nombre As String

    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TxtBoxEsquiva.TextChanged
        If (IsNumeric(TxtBoxEsquiva.Text)) Then
            Dim FilaS As String = TxtBoxFila.Text
            Dim EstivaS As String = TxtBoxEsquiva.Text
            Dim Fila As Integer
            Dim Estiva As Integer
            If (FilaS = "") Then
                FilaS = "0"
            End If
            If (EstivaS = "") Then
                EstivaS = "0"
            End If

            Fila = Integer.Parse(FilaS)
            Estiva = Integer.Parse(EstivaS)

            Dim Capacidad As Integer = Fila * Estiva
            TxtBoxCapacidad.Text = Capacidad
        Else
            If (Not IsNumeric(TxtBoxFila.Text)) Then
                MsgBox("Por favor ingrese un numero en las filas")
            End If
            If (Not IsNumeric(TxtBoxEsquiva.Text)) Then
                MsgBox("Por favor ingrese un numero en las esquivas")
            End If
        End If

    End Sub

    Private Sub TextBoxFilas_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TxtBoxFila.TextChanged


        If (IsNumeric(TxtBoxFila.Text)) Then
            Dim FilaS As String = TxtBoxFila.Text
            Dim EstivaS As String = TxtBoxEsquiva.Text
            Dim Fila As Integer
            Dim Estiva As Integer
            If (FilaS = "") Then
                FilaS = "0"
            End If
            If (EstivaS = "") Then
                EstivaS = "0"
            End If

            Fila = Integer.Parse(FilaS)
            Estiva = Integer.Parse(EstivaS)

            Dim Capacidad As Integer = Fila * Estiva
            TxtBoxCapacidad.Text = Capacidad
        Else
            If (Not IsNumeric(TxtBoxFila.Text)) Then
                MsgBox("Por favor ingrese un numero en las filas")
            End If
            If (Not IsNumeric(TxtBoxEsquiva.Text)) Then
                MsgBox("Por favor ingrese un numero en las esquivas")
            End If
        End If
    End Sub
    Private Sub BtnModificar_Click(sender As Object, e As RoutedEventArgs) Handles BtnModificar.Click
        Dim conexion As New Conexion

        Dim getidpatio As New Conexion

        Dim idpatio As String = getidpatio.EjecutarSentencia("select idpatio from patio where nombre like '" & comboBoxNombrePatio.Text & "'", "idpatio")

        conexion.modificarZona(TxtBoxIdZona.Text, TxtBoxCapacidad.Text, TxtBoxNombre.Text, idpatio, TxtBoxEsquiva.Text, TxtBoxFila.Text)

    End Sub



    Public Function DevolverPatios() As String()
        Dim ExtraerZonas As New Conexion
        Dim dataS As New System.Data.DataSet
        dataS = ExtraerZonas.listaPatio
        Dim lista As String() = (From nombre In dataS.Tables(0).AsEnumerable Select nombre.Field(Of String)("nombre")).ToArray
        Return lista
    End Function
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        comboBoxNombrePatio.ItemsSource = DevolverPatios()

        cargarDatos()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim Lista As New ListarZonasM

        Lista.Show()
        Me.Close()
    End Sub

    Public Sub setVinAux(Nombre As String)
        Me.Nombre = Nombre
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As RoutedEventArgs) Handles BtnEliminar.Click
        Dim conexion As New Conexion
        conexion.EliminarZona(TxtBoxIdZona.Text)
        Dim Lista As New ListarZonasM

        Lista.Show()
        Me.Close()
    End Sub

    Private Sub cargarDatos()
        Dim Conexion As New Conexion
        Dim Z As New Zona


        Z = Z.InformacionZona(Nombre)
        TxtBoxIdZona.Text = Z.getId
        TxtBoxNombre.Text = Z.getNombre
        TxtBoxFila.Text = Z.getFila
        TxtBoxEsquiva.Text = Z.getEsquiva
        TxtBoxCapacidad.Text = Z.getCapacidad
        Dim NombrePatio As String = Conexion.EjecutarSentencia("SELECT nombre from patio where idpatio='" & Z.getIdPatio & "'", "nombre")

        comboBoxNombrePatio.Text = NombrePatio


    End Sub
End Class
