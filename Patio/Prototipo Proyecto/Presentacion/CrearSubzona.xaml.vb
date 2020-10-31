Imports System.Data

Public Class CrearSubzona
    Dim sz As New SubZona

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinAtras As New ConfgZonas
        WinAtras.Show()
        Close()
    End Sub

    Private Sub BtnSiguiente_Click(sender As Object, e As RoutedEventArgs) Handles BtnModificar.Click
        If (TextBoxNombre.Text = "" Or comboBoxNombreZona.Text = "") Then
            MsgBox("Datos sin ingresar")
        Else
            Ingresar(sz)

        End If



    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
    End Sub



    Private Sub TextBoxNombre_LostFocus(sender As Object, e As RoutedEventArgs) Handles TextBoxNombre.LostFocus
        If (TextBoxNombre.Text = "") Then
            label_Copy_Nombre.Visibility = False
        End If
    End Sub

    Private Sub grid_Loaded(sender As Object, e As RoutedEventArgs) Handles gird.Loaded
        Dim ExtraerIdsubZona As New Conexion
        Dim ExtraerZonas As New Conexion

        Dim IdsubZona As Integer = ExtraerIdsubZona.EjecutarSentencia("SELECT idsubzona from subzona where baja='f' order by idzona desc limit 1 ", "idsubzona") + 1
        TextBoxNroSubZona.Text = IdsubZona




        comboBoxNombreZona.ItemsSource = DevolverZonas()


        label_Copy_Nombre.Visibility = True
        label_Copy_Esquiva.Visibility = True
        label_Copy_Flla.Visibility = True
        label_Copy_Patio.Visibility = True


    End Sub


    Public Function DevolverZonas() As String()
        Dim ExtraerZonas As New Conexion
        Dim dataS As New System.Data.DataSet
        dataS = ExtraerZonas.devolverZonas
        Dim lista As String() = (From nombre In dataS.Tables(0).AsEnumerable Select nombre.Field(Of String)("nombre")).ToArray
        Return lista
    End Function

    Private Sub TextBox_TextChanged(sender As Object, e As TextChangedEventArgs) Handles TextBoxEstivas.TextChanged
        If (IsNumeric(TextBoxEstivas.Text)) Then
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

    Private Sub ComboBoxZona_LostFocus(sender As Object, e As RoutedEventArgs) Handles comboBoxNombreZona.LostFocus
        If (comboBoxNombreZona.Text = "") Then
            label_Copy_Patio.Visibility = False
        End If
    End Sub

    Private Sub Ingresar(cz As SubZona)
        Dim conexion As New Conexion

        Dim idZona As Integer = conexion.EjecutarSentencia("SELECT idzona from zona where nombre='" & comboBoxNombreZona.Text & "'", "idzona")

        cz.setIdSubZona(TextBoxNroSubZona.Text)
        cz.setIdZona(idZona)
        cz.setNombre(TextBoxNombre.Text)
        cz.setCapacidad(TextBoxCapacidad.Text)
        cz.setFilas(TextBoxFilas.Text)
        cz.setEsquivas(TextBoxEstivas.Text)
        cz.AltaSubZona()






    End Sub
End Class
