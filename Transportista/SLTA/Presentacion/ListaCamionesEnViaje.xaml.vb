Public Class ListaCamionesEnViaje
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim Win As New MenuAdministrador
        Win.Show()
        Me.Close()

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim c As New Camion
        ListBoxCamiones.ItemsSource = c.devolverCamionesViaje
    End Sub

    Private Sub BtnSeleccionar_Click(sender As Button, e As RoutedEventArgs)
        Dim win As New Navegador
        Dim bdd As New Conexion
        bdd.UbicacionCamion(sender.Tag.ToString)
        win.Show()
        Me.Close()
    End Sub
End Class
