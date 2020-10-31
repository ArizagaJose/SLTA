Public Class AltaVehiculo
    Private VIN As Integer
    Private Marca As String
    Private Modelo As String
    Private Pais As String
    Private Color As String
    Private Año As Integer
    Private Tipo As String

    Public Sub New(vIN As Integer)
        If VerificarLongitudVin(vIN) Then
            Me.VIN = vIN
        End If
    End Sub

    Public Function verificarLongitudVin(VIN As Integer) As Boolean

        Return False
    End Function

    Public Sub decodificarVIN()
        Dim ArrayVin() As Char
        ArrayVin = VIN.ToString.ToCharArray
        Select Case ArrayVin(1)
            Case "1"
                Pais = "Estados Unidos"
            Case "2"
                Pais = "Canada"
            Case "3"
                Pais = "Mexico"
            Case "4"
                Pais = "Estados Unidos"
            Case "5"
                Pais = "Estados Unidos"
            Case "6"
                Pais = "Australia"
            Case "9"
                Pais = "Brasil"
            Case "J"
                Pais = "Japon"
            Case "K"
                Pais = "Corea"
            Case "S"
                Pais = "Inglaterra"
            Case "T"
                Pais = "Alemania"
            Case "V"
                Pais = "Francia"
            Case "W"
                Pais = "Alemania"
            Case "Y"
                Pais = "Finlandia"
            Case "Z"
                Pais = "Italia"
        End Select
        Select Case ArrayVin(2)
            Case "B"
                Marca = "BMW"
            Case "4"
                Marca = "Buick"
            Case "F"
                Marca = "Ford"
            Case "6"
                Marca = "Cadillac"
            Case "F"
                Marca = "Renault"
            Case "7"
                Marca = "GM Canada"
            Case "G"
                Marca = "General Motors"
            Case "H"
                Marca = "Honda"
            Case "L"
                Marca = "Lincoln"
            Case "M"
                Marca = "Mercury"
            Case "N"
                Marca = "Nissan"
            Case "3"
                Marca = "Oldsmobile"
            Case "2"
                Marca = "Pontiac"
            Case "5"
                Marca = "Pontiac"
            Case "P"
                Marca = "Plymouth"
            Case "S"
                Marca = "Saab"
            Case "8"
                Marca = "Saturn"
            Case "T"
                Marca = "Toyota"
            Case "V"
                Marca = "Volkswagen"
            Case "VV"
                Marca = "Chery"
        End Select
        Select Case ArrayVin(3)
            Case "A"
                Año = 1980
            Case "B"
                Año = 1981
            Case "C"
                Año = 1982
            Case "D"
                Año = 1983
            Case "E"
                Año = 1984
            Case "F"
                Año = 1985
            Case "G"
                Año = 1986
            Case "H"
                Año = 1987
            Case "J"
                Año = 1988
            Case "K"
                Año = 1989
            Case "L"
                Año = 1990
            Case "M"
                Año = 1991
            Case "N"
                Año = 1992
            Case "P"
                Año = 1993
            Case "R"
                Año = 1994
            Case "S"
                Año = 1995
            Case "T"
                Año = 1996
            Case "V"
                Año = 1997
            Case "W"
                Año = 1998
            Case "X"
                Año = 1999
            Case "Y"
                Año = 2000
            Case "1"
                Año = 2001
            Case "2"
                Año = 2002
            Case "3"
                Año = 2003
            Case "4"
                Año = 2004
            Case "5"
                Año = 2005
            Case "6"
                Año = 2006
            Case "7"
                Año = 2007
            Case "8"
                Año = 2008
            Case "9"
                Año = 2009
        End Select
        'Case "A"
        '   Marca = "Audi"
        'Case "A"
        '   Marca = "Jaguar"
        'Case "C"
        '   Marca = "Chevrolet"
        'Case "C"
        '   Marca = "Crysler"
        'Case "D"
        '   Marca = "Dodge"
        'Case "D"
        '   Marca = "Mercedes Benz"
        Select Case ArrayVin(4)
            'Case 
        End Select



    End Sub

End Class
