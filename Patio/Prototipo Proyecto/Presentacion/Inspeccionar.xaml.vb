Imports System.Data

Public Class Inspeccionar
    Shared Danios As New List(Of Daño)
    Shared PVez As Boolean = True

    Shared IdInspeccion As String
    Shared Vin As String






    Public Sub AgregarDaño(ByVal IdInspeccion As Integer, ByVal Nombre As String, ByVal Descripcion As String)
        Dim IdDaño As Integer = 0
        Danios.Add(New Daño(IdDaño, IdInspeccion, Nombre, Descripcion, "ejemplo"))
        PVez = False

    End Sub



    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinMenu As New Menu
        Dim WinAdminMenu As New MenuAdmin

        Danios.Clear()
        PVez = True

        If (My.Settings.USER_ROLE = "administrador                   ") Then
            WinAdminMenu.Show()
            Close()
        ElseIf (My.Settings.USER_ROLE = "operariopatio                   ") Then
            WinMenu.Show()
            Close()
        End If

    End Sub

    Private Sub listbox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBoxDesc.MouseDoubleClick
        ListBoxDesc.Items.RemoveAt(ListBoxDesc.SelectedIndex.ToString())
    End Sub
    Private Sub BtnSiguiente_Click(sender As Object, e As RoutedEventArgs) Handles BtnSiguiente.Click
        Dim WinSiguiente As New AgregarDaño
        WinSiguiente.TextBoxNroInsp.Text = TextBoxIdInspeccion.Text


        WinSiguiente.Show()
        Close()

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
        If (PVez = False) Then
            TextBoxIdInspeccion.Text = Danios.Item(0).IdInspeccion

            For Each Daño In Danios
                ListBoxDesc.Items.Add(Daño.Nombre)

            Next

        End If

    End Sub

    Private Sub TextBox_LostFocus(sender As Object, e As RoutedEventArgs)
        If (TextBoxFuncionario.Text = "") Then

        End If


    End Sub


    Private Sub Grid_Loaded(sender As Object, e As RoutedEventArgs)
        Dim ExtraerIdInspeccion As New Conexion

        Dim idInspeccion As Integer = ExtraerIdInspeccion.EjecutarSentencia("SELECT idinspeccion from inspeccion order by idinspeccion desc limit 1", "idinspeccion") + 1
        TextBoxIdInspeccion.Text = idInspeccion

        label_Copy2.Visibility = True
        TextBoxFuncionario.Text = My.Settings.USER_NAME
        TextBoxHora.Text = DateTime.Now.ToShortTimeString()
        TextBoxFecha.Text = DateTime.Now.ToString("yyyy-MM-dd")

        comboBoxVin.ItemsSource = DevolverVehiculos()





    End Sub

    Private Sub TextBox_LostFocus_1(sender As Object, e As RoutedEventArgs)
        If (TextBoxFecha.Text = "") Then
            label_Copy2.Visibility = False
        End If
    End Sub

    Private Sub TextBox_LostFocus_2(sender As Object, e As RoutedEventArgs)


    End Sub

    Private Sub ListBox_LostFocus(sender As Object, e As RoutedEventArgs)

    End Sub



    Private Sub ComboBox_LostFocus(sender As Object, e As RoutedEventArgs)
        If (comboBoxVin.Text = "") Then
            label_Copy2.Visibility = False

        End If


    End Sub



    Private Sub Button_Click(sender As Object, e As RoutedEventArgs) Handles button.Click
        Dim conexion As New Conexion
        Dim altainspeccionpatio As New Conexion
        Dim id As New Conexion
        Dim baja As String = "f"
        Dim Imagen As String = "Url"
        conexion.AltaInspeccion(TextBoxIdInspeccion.Text, TextBoxFecha.Text & " " & TextBoxHora.Text, comboBoxVin.Text, "f")
        altainspeccionpatio.AltaInspeccionPatio(TextBoxIdInspeccion.Text, 1111111111, "f")
        Dim contador As Integer = 0
        For Each item As Daño In Danios
            contador += 1
            conexion.AltaDaño(item.IDDaño, item.Descripcion, Imagen, baja, item.IdInspeccion)
        Next
        MsgBox("se han agregado " & contador & " daños")


    End Sub
    Public Function DevolverVehiculos() As String()
        Dim ExtraerZonas As New Conexion
        Dim dataS As New System.Data.DataSet
        dataS = ExtraerZonas.listavehiculo
        Dim lista As String() = (From vin In dataS.Tables(0).AsEnumerable Select vin.Field(Of String)("vin")).ToArray
        Return lista
    End Function
    Private Sub ListBoxDesc_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles ListBoxDesc.SelectionChanged

    End Sub
End Class
