Public Class Window2

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim BDD As New ConexionBDD
        Dim host As New Forms.Integration.WindowsFormsHost
        Dim gridview As New Forms.DataGridView
        gridview = BDD.listaVehiculo
        host.Child = gridview
        Grid1.Children.Add(host)
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim WinMenu As New Menu
        WinMenu.Show()
        Close()
    End Sub
End Class
