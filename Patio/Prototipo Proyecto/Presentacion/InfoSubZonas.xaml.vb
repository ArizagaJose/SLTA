Public Class InfoSubZonas

    Dim Nombre As String
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        cargarDatos()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim Lista As New ListarSubZonas

        Lista.Show()
        Me.Close()
    End Sub

    Public Sub setVinAux(Nombre As String)
        Me.Nombre = Nombre
    End Sub

    Private Sub cargarDatos()
        Dim Conexion As New Conexion
        Dim Z As New SubZona


        Z = Z.InformacionSubZona(Nombre)
        TxtBoxIdZona.Text = Z.getidZona
        TxtBoxNombre.Text = Z.getNombre
        TxtBoxFila.Text = Z.getFila
        TxtBoxEsquiva.Text = Z.getEsquiva
        TxtBoxCapacidad.Text = Z.getCapacidad

        TxtBoxIdSubZona.Text = Z.getIdSubZona


    End Sub
End Class
