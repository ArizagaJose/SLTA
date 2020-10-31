Public Class Lote
    Private idlote As Integer
    Private capacidad As Integer


    Public Sub ArmadoLotes(lista As List(Of String))
        Dim bdd As New Conexion
        Me.capacidad = lista.Count
        Me.idlote = UltimoLote()
        CreacionLote()
        For I As Integer = 0 To lista.Count - 1
            bdd.ArmarLote(lista(I).ToString, idlote)
        Next
    End Sub

    Public Function UltimoLote() As Integer
        Dim bdd As New Conexion
        Return bdd.UltimoLote
    End Function

    Public Sub CreacionLote()
        Dim bdd As New Conexion
        bdd.AltaLote(idlote, capacidad)
    End Sub

End Class
