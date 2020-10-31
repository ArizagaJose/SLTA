Public Class InfoZona

    Dim Nombre As String
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        
        cargarDatos()
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim Lista As New ListarZonas

        Lista.Show()
        Me.Close()
    End Sub

    Public Sub setVinAux(Nombre As String)
        Me.Nombre = Nombre
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

        TxtBoxIdPatio.Text = NombrePatio


    End Sub
End Class
