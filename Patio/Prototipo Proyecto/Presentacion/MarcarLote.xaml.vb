Imports System.Data

Public Class MarcarLote




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

    Private Sub TxtChanged(sender As Object, e As RoutedEventArgs) Handles TextBoxIdLote.TextChanged
        If (Not IsNumeric(TextBoxIdLote.Text)) Then

            MsgBox("Ingrese un numero en el campo de IdLote")
        End If
    End Sub
    Private Sub BtnSiguiente_Click(sender As Object, e As RoutedEventArgs) Handles BtnSiguiente.Click
        Dim Bdd As New Conexion

        If (IsNumeric(TextBoxIdLote.Text)) Then
            Dim idlote As Integer = TextBoxIdLote.Text

            Bdd.MarcarLoteComoArribado(idlote)
        Else
            MsgBox("Ingrese un numero en el campo de IdLote")
        End If


    End Sub


    Private Sub Gird_Loaded(sender As Object, e As RoutedEventArgs) Handles Gird.Loaded

    End Sub


End Class
