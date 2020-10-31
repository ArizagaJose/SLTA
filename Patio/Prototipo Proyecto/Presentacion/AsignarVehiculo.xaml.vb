Imports System.Data

Public Class AsignarVehiculo
    Dim contador As Integer = 0

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim winAdminMenu As New MenuAdmin
        Dim winMenu As New Menu


        If (My.Settings.USER_ROLE.ToString = "administrador                   ") Then
            winAdminMenu.Show()
            Close()
        ElseIf (My.Settings.USER_ROLE.ToString = "operariopatio                   ") Then
            winMenu.Show()
            Close()
        End If
    End Sub

    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs) Handles grid.Loaded
        Dim extractorFilas As New Conexion


        comboBoxPatio.ItemsSource = DevolverPatios()
        comboBoxVin.ItemsSource = DevolverVehiculos()
    End Sub

    Public Sub CargarZonas(sender As Object, e As RoutedEventArgs) Handles comboBoxPatio.LostFocus
        If (comboBoxPatio.Text <> "") Then
            Dim extraerIdpatio As New Conexion
            Dim idpatio As String = extraerIdpatio.EjecutarSentencia("SELECT idpatio from patio where nombre='" & comboBoxPatio.Text & "'", "idpatio")
            comboBoxZona.SelectedValue = Nothing
            comboBoxZona.Text = Nothing
            comboBoxZona.ItemsSource = DevolverZonas(idpatio)
            comboBoxEstiva.SelectedValue = Nothing
            comboBoxEstiva.Text = Nothing

        End If

    End Sub

    Private Sub FilasLoades(sender As Object, e As RoutedEventArgs) Handles comboBoxZona.LostFocus
        If (comboBoxZona.Text <> "") Then
            comboBoxEstiva.Items.Clear()

            Dim extractorEstivas As New Conexion
            Dim extractorIdZona As New Conexion
            Dim idZona As Integer = extractorIdZona.EjecutarSentencia("SELECT idzona from zona where nombre like '" & comboBoxZona.Text & "'", "idzona")
            Dim EstivasTotales As Integer = extractorEstivas.EjecutarSentencia("SELECT esquivas from zona where idzona = '" & idZona & "'", "esquivas")
            Dim esquivas
            For esquivas = 1 To EstivasTotales Step 1
                comboBoxEstiva.Items.Add(esquivas)
            Next
        End If
    End Sub
    Private Sub EstivasLoades(sender As Object, e As RoutedEventArgs) Handles comboBoxZona.LostFocus
        If (comboBoxZona.Text <> "") Then
            comboBoxFila.Items.Clear()

            Dim extractorFilas As New Conexion
            Dim extractorIdZona As New Conexion
            Dim idZona As Integer = extractorIdZona.EjecutarSentencia("SELECT idzona from zona where nombre like '" & comboBoxZona.Text & "'", "idzona")
            Dim FilasTotales As Integer = extractorFilas.EjecutarSentencia("SELECT filas from zona where idzona = '" & idZona & "'", "filas")
            Dim Filas
            For Filas = 1 To FilasTotales Step 1
                comboBoxFila.Items.Add(Filas)
            Next
        End If
    End Sub

    Private Sub BtnAsignar_Click(sender As Object, e As RoutedEventArgs) Handles BtnAsignar.Click
        Dim conexion As New Conexion
        Dim Idpatio As New Conexion
        Dim IdZona As New Conexion

        Dim patio As String = Idpatio.EjecutarSentencia("select idpatio from patio where nombre like '" & comboBoxPatio.Text & "'", "idpatio")
        Dim zona As String = IdZona.EjecutarSentencia("select idzona from zona where nombre like '" & comboBoxZona.Text & "'", "idzona")

        If (comboBoxVin.Text <> "" And comboBoxVin.Text <> "" And comboBoxZona.Text <> "" And comboBoxFila.Text <> "" And comboBoxEstiva.Text <> "") Then
            conexion.AsignarVehiuclo(comboBoxVin.Text, zona, comboBoxFila.Text, comboBoxEstiva.Text)
        Else
            MsgBox("Datos sin ingresar")
        End If


    End Sub

    Public Function DevolverZonas(ByVal idpatio As String) As String()
        Try
            Dim ExtraerZonas As New Conexion
            Dim dataS As New System.Data.DataSet
            dataS = ExtraerZonas.listaZona2(idpatio)
            Dim lista As String() = (From nombre In dataS.Tables(0).AsEnumerable Select nombre.Field(Of String)("nombre")).ToArray
            Return lista
        Catch

        End Try
    End Function

    Public Function DevolverVehiculos() As String()
        Try
            Dim ExtraerZonas As New Conexion
            Dim dataS As New System.Data.DataSet
            dataS = ExtraerZonas.devolverVehiculosDeLotes
            Dim lista As String() = (From vin In dataS.Tables(0).AsEnumerable Select vin.Field(Of String)("vin")).ToArray
            Return lista
        Catch

        End Try
    End Function

    Public Function DevolverPatios() As String()
        Dim ExtraerZonas As New Conexion
        Dim dataS As New System.Data.DataSet
        dataS = ExtraerZonas.listaPatio
        Dim lista As String() = (From nombre In dataS.Tables(0).AsEnumerable Select nombre.Field(Of String)("nombre")).ToArray
        Return lista
    End Function

    Private Sub BtnEliminar_Click(sender As Object, e As RoutedEventArgs) Handles BtnEliminar.Click
        Dim conexion As New Conexion

        conexion.BajaVehiculoZona(comboBoxVin.Text)
    End Sub
End Class
