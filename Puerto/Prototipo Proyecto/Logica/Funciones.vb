Module Funciones


    Public Function ComprobarLongitud(Cadena As String, Longitud As Integer) As Boolean
        If (Cadena.Length = Longitud) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ComprobarVacio(Cadena As String) As Boolean
        If (Cadena = "") Then
            Return False
        Else
            Return True
        End If
    End Function



End Module
