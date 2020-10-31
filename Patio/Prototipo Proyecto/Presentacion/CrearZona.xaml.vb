Imports System.Data

Public Class CrearZona


    Dim z As New Zona

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinAtras As New ConfgZonas
        WinAtras.Show()
        Close()
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As RoutedEventArgs) Handles BtnSiguiente.Click
        Dim Bdd As New Conexion
        If (TextBoxNombre.Text = "" Or TextBoxFilas.Text = "" Or TextBoxFilas.Text = "") Then
            MsgBox("Datos sin completar")
        Else
            Ingresar(z)
        End If




    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)







    End Sub

    Public Function DevolverPatios() As String()
        Dim ExtraerZonas As New Conexion
        Dim dataS As New System.Data.DataSet
        dataS = ExtraerZonas.listaPatio
        Dim lista As String() = (From nombre In dataS.Tables(0).AsEnumerable Select nombre.Field(Of String)("nombre")).ToArray
        Return lista
    End Function

    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TextBoxEstivas.TextChanged
        If (IsNumeric(TextBoxFilas.Text)) Then
            Dim FilaS As String = TextBoxFilas.Text
            Dim EstivaS As String = TextBoxEstivas.Text
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
            TextBoxCapacidad.Text = Capacidad
        Else
            If (Not IsNumeric(TextBoxEstivas.Text)) Then
                MsgBox("Por favor ingrese un numero en las estivas")
            End If
        End If
    End Sub

    Private Sub TextBoxFilas_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TextBoxFilas.TextChanged
        If (IsNumeric(TextBoxFilas.Text)) Then
            Dim FilaS As String = TextBoxFilas.Text
            Dim EstivaS As String = TextBoxEstivas.Text
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
            TextBoxCapacidad.Text = Capacidad
        Else
            If (Not IsNumeric(TextBoxFilas.Text)) Then
                MsgBox("Por favor ingrese un numero en las filas")
            End If
        End If


    End Sub

    Private Sub TextBoxNombre_LostFocus(sender As Object, e As RoutedEventArgs) Handles TextBoxNombre.LostFocus
        If (TextBoxNombre.Text = "") Then
            label_Copy_Nombre.Visibility = False
        End If
    End Sub

    Private Sub Gird_Loaded(sender As Object, e As RoutedEventArgs) Handles Gird.Loaded

        Dim ExtraerIdZona As New Conexion
        Dim ExtraerPatios As New Conexion

        Dim IdZona As Integer = ExtraerIdZona.EjecutarSentencia("SELECT idzona from zona order by idzona desc limit 1", "idzona") + 1
        TxtBoxIdZona.Text = IdZona



        comboBoxNombrePatio.ItemsSource = DevolverPatios()




        label_Copy_Nombre.Visibility = True
        label_Copy_Flla.Visibility = True
        label_Copy_Esquiva.Visibility = True
        label_Copy_Patio.Visibility = True

    End Sub

    Private Sub TextBoxFilas_LostFocus(sender As Object, e As RoutedEventArgs) Handles TextBoxFilas.LostFocus
        If (TextBoxFilas.Text = "") Then
            label_Copy_Flla.Visibility = False
        End If
    End Sub

    Private Sub TextBoxEstivas_LostFocus(sender As Object, e As RoutedEventArgs) Handles TextBoxEstivas.LostFocus
        If (TextBoxEstivas.Text = "") Then
            label_Copy_Esquiva.Visibility = False
        End If
    End Sub



    Private Sub ComboBoxPatio_LostFocus(sender As Object, e As RoutedEventArgs) Handles comboBoxNombrePatio.LostFocus
        If (comboBoxNombrePatio.Text = "") Then
            label_Copy_Patio.Visibility = False
        End If
    End Sub


    Private Sub Ingresar(z As Zona)
        Dim conexion As New Conexion
        Dim idpatio As Integer = conexion.EjecutarSentencia("SELECT idpatio from patio where nombre like '" & comboBoxNombrePatio.Text & "'", "idpatio")

        z.setID(TxtBoxIdZona.Text)
        z.setNombre(TextBoxNombre.Text)
        z.setCapacidad(TextBoxCapacidad.Text)
        z.setEsquivas(TextBoxEstivas.Text)
        z.setFilas(TextBoxFilas.Text)
        z.setIdPatio(idpatio)
        z.AltaZona()



    End Sub
End Class

