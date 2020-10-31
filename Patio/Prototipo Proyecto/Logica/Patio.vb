Public Class Patio
    Public Idpatio As Integer
    Public Nombre As String
    Public Tipo As String
    Public Capacidad As Integer
    Public Baja As Boolean




    Public Sub setCapacidad(capacidad As Integer)
        Me.Capacidad = capacidad
    End Sub

    Public Sub setNombre(nombre As String)
        Me.Nombre = nombre
    End Sub

    Public Sub setIdPatio(idpatio As Integer)
        Me.Idpatio = idpatio
    End Sub

    Public Sub setTipo(tipo As String)
        Me.Tipo = tipo
    End Sub

    Public Sub setBaja(baja As Boolean)
        Me.Baja = baja
    End Sub
End Class
