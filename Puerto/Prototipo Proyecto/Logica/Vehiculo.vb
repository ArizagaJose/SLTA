Imports System.Data

Public Class Vehiculo
    Private VIN As String
    Private ID As String
    Private Marca As String
    Private Modelo As String
    Private Pais As String
    Private Color As String
    Private Año As Integer
    Private Tipo As String
    Private Lote As String

    Private WMI As String

    Public Sub New()
    End Sub

    Public Sub New(vIN As String, iD As String, marca As String, modelo As String, pais As String, color As String, año As Integer, tipo As String, lote As String)
        Me.VIN = vIN
        Me.ID = iD
        Me.Marca = marca
        Me.Modelo = modelo
        Me.Pais = pais
        Me.Color = color
        Me.Año = año
        Me.Tipo = tipo
        Me.Lote = lote
    End Sub




    'debido a los altos problemas con la decodificacion, decidimos que primero verifique la marca del vehiculo y luego decodifique todo lo demas
    Public Sub decodificarVIN()
        'WMI es "World Manufacturer Identification", los 3 primeros digitos de todos los vins se utlizan para identificar a las marcas
        Dim ArrayVIN() = VIN.ToCharArray
        WMI = VIN.Substring(0, 2)
        Dim ArrayWMI() As Char
        ArrayWMI = WMI.ToCharArray()

        'Seteo de pais
        Select Case ArrayWMI(0)
            Case "A"
                If (isBetween(ArrayWMI(1), "A", "H")) Then
                    Pais = "Sudafrica"
                ElseIf (isBetween(ArrayWMI(1), "J", "N")) Then
                    Pais = "Costa de Marfil"
                End If
            Case "B"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Angola"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Kenia"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Tanzania"
                End If
            Case "C"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Benin"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Madagascar"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Tunez"
                End If
            Case "D"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Egipto"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Marruecos"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Madagascar"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Zambia"
                End If
            Case "E"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Etiopia"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Mozambique"
                End If
            Case "F"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Ghana"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Nigeria"
                End If
            Case "J"
                Pais = "Japon"
            Case "K"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Sri Lanka"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Israel"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Corea del Sur"
                ElseIf (isBetween(ArrayWMI(1), "S", "0")) Then
                    Pais = "Kazajistan"
                End If
            Case "L"
                Pais = "China"
            Case "M"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "India"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Indonesia"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Tailandia"
                ElseIf (isBetween(ArrayWMI(1), "S", "0")) Then
                    Pais = "Myanmar"
                End If
            Case "N"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Iran"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Pakistan"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Turquia"
                End If
            Case "P"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Filipinas"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Singapur"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Malasia"
                End If
            Case "R"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Emiratos Arabes Unidos"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Taiwan"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Vietnam"
                ElseIf (isBetween(ArrayWMI(1), "S", "0")) Then
                    Pais = "Arabia Saudita"
                End If
            Case "S"
                If (isBetween(ArrayWMI(1), "A", "M")) Then
                    Pais = "Reino Unido"
                ElseIf (isBetween(ArrayWMI(1), "N", "T")) Then
                    Pais = "Alemania"
                ElseIf (isBetween(ArrayWMI(1), "U", "Z")) Then
                    Pais = "Polonia"
                ElseIf (isBetween(ArrayWMI(1), "1", "4")) Then
                    Pais = "Letonia"
                End If
            Case "T"
                If (isBetween(ArrayWMI(1), "A", "H")) Then
                    Pais = "Suiza"
                ElseIf (isBetween(ArrayWMI(1), "J", "P")) Then
                    Pais = "Republica Checa"
                ElseIf (isBetween(ArrayWMI(1), "R", "V")) Then
                    Pais = "Hungria"
                ElseIf (isBetween(ArrayWMI(1), "W", "1")) Then
                    Pais = "Portugal"
                End If
            Case "U"
                If (isBetween(ArrayWMI(1), "H", "M")) Then
                    Pais = "Dinamarca"
                ElseIf (isBetween(ArrayWMI(1), "N", "T")) Then
                    Pais = "Irlanda"
                ElseIf (isBetween(ArrayWMI(1), "U", "Z")) Then
                    Pais = "Rumania"
                ElseIf (isBetween(ArrayWMI(1), "5", "7")) Then
                    Pais = "Eslovaquia"
                End If
            Case "V"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Austria"
                ElseIf (isBetween(ArrayWMI(1), "F", "R")) Then
                    Pais = "Francia"
                ElseIf (isBetween(ArrayWMI(1), "S", "W")) Then
                    Pais = "España"
                ElseIf (isBetween(ArrayWMI(1), "X", "2")) Then
                    Pais = "Serbia"
                ElseIf (isBetween(ArrayWMI(1), "3", "5")) Then
                    Pais = "Croacia"
                ElseIf (isBetween(ArrayWMI(1), "6", "0")) Then
                    Pais = "Estonia"
                End If
            Case "W"
                Pais = "Alemania"
            Case "X"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Bulgaria"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Grecia"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Holanda"
                ElseIf (isBetween(ArrayWMI(1), "S", "W")) Then
                    Pais = "Rusia"
                ElseIf (isBetween(ArrayWMI(1), "X", "2")) Then
                    Pais = "Luxemburgo"
                ElseIf (isBetween(ArrayWMI(1), "3", "0")) Then
                    Pais = "Rusia"
                End If
            Case "V"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Austria"
                ElseIf (isBetween(ArrayWMI(1), "F", "R")) Then
                    Pais = "Francia"
                ElseIf (isBetween(ArrayWMI(1), "S", "W")) Then
                    Pais = "España"
                ElseIf (isBetween(ArrayWMI(1), "X", "2")) Then
                    Pais = "Serbia"
                ElseIf (isBetween(ArrayWMI(1), "3", "5")) Then
                    Pais = "Croacia"
                ElseIf (isBetween(ArrayWMI(1), "6", "0")) Then
                    Pais = "Estonia"
                End If
            Case "Y"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Belgica"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Finlandia"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Malta"
                ElseIf (isBetween(ArrayWMI(1), "S", "W")) Then
                    Pais = "Suecia"
                ElseIf (isBetween(ArrayWMI(1), "X", "2")) Then
                    Pais = "Noruega"
                ElseIf (isBetween(ArrayWMI(1), "3", "5")) Then
                    Pais = "Bielorrusia"
                ElseIf (isBetween(ArrayWMI(1), "6", "0")) Then
                    Pais = "Ucrania"
                End If
            Case "Z"
                If (isBetween(ArrayWMI(1), "A", "R")) Then
                    Pais = "Italia"
                ElseIf (isBetween(ArrayWMI(1), "X", "2")) Then
                    Pais = "Eslovenia"
                ElseIf (isBetween(ArrayWMI(1), "3", "5")) Then
                    Pais = "Lituania"
                End If
            Case "1"
                Pais = "Estados Unidos"
            Case "4"
                Pais = "Estados Unidos"
            Case "5"
                Pais = "Estados Unidos"
            Case "2"
                Pais = "Canada"
            Case "3"
                If (isBetween(ArrayWMI(1), "A", "W")) Then
                    Pais = "Mexico"
                ElseIf (isBetween(ArrayWMI(1), "X", "7")) Then
                    Pais = "Costa Rica"
                ElseIf (isBetween(ArrayWMI(1), "8", "9")) Then
                    Pais = "Islas Caiman"
                End If
            Case "6"
                Pais = "Australia"
            Case "7"
                Pais = "Nueva Zelanda"
            Case "8"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Argentina"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Chile"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Ecuador"
                ElseIf (isBetween(ArrayWMI(1), "S", "W")) Then
                    Pais = "Peru"
                ElseIf (isBetween(ArrayWMI(1), "X", "2")) Then
                    Pais = "Venezuela"
                End If
            Case "9"
                If (isBetween(ArrayWMI(1), "A", "E")) Then
                    Pais = "Brasil"
                ElseIf (isBetween(ArrayWMI(1), "F", "K")) Then
                    Pais = "Colombia"
                ElseIf (isBetween(ArrayWMI(1), "L", "R")) Then
                    Pais = "Paraguay"
                ElseIf (isBetween(ArrayWMI(1), "S", "W")) Then
                    Pais = "Uruguay"
                ElseIf (isBetween(ArrayWMI(1), "X", "2")) Then
                    Pais = "Trinidad y Tobago"
                End If
        End Select
        'Seteo de año
        Año = SetAño(ArrayVIN(9), ArrayVIN(6))

    End Sub

    'Probablemente la funcion mas reutilizable de toda la clase
    'Se utiliza para verificar que una letra este entre otro rango de letras
    Private Function isBetween(Letra As Char, Inicio As Char, Final As Char) As Boolean
        If Letra >= Inicio And Letra <= Final Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub AltaVehiculo()
        Dim ConexionBDD As New Conexion
        ConexionBDD.AltaVehiculo(VIN, Marca, Modelo, Año, Color, Pais, Tipo)
    End Sub

    Private Function SetAño(Letra As Char, DigVerificador As Char) As Integer
        Dim ArrayAños1() As Integer = {1980, 1981, 1982, 1983, 1984, 1985, 1986, 1987, 1988, 1989, 1990, 1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998, 1999, 2000, 2001, 2002, 2003, 2004, 2005, 2006, 2007, 2008, 2009}
        Dim ArrayAños2() As Integer = {2010, 2011, 2012, 2013, 2014, 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025, 2026, 2027, 2028, 2029, 2030, 2031, 2032, 2033, 2034, 2035, 2036, 2037, 2038, 2039}
        Dim ArrayLetras() As Char = {"A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "R", "S", "T", "V", "W", "X", "Y", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
        If isBetween(DigVerificador, "0", "9") Then
            For i As Integer = 0 To ArrayLetras.Length
                If Letra = ArrayLetras(i) Then
                    Return ArrayAños1(i)
                End If
            Next
        ElseIf isBetween(DigVerificador, "A", "Z") Then
            For i As Integer = 0 To ArrayLetras.Length
                If Letra = ArrayLetras(i) Then
                    Return ArrayAños2(i)
                End If
            Next
        End If
#Disable Warning BC42353 ' La función no devuelve un valor en todas las rutas de código
    End Function
#Enable Warning BC42353 ' La función no devuelve un valor en todas las rutas de código

    Public Sub SetAñoManual(a As Integer)
        Me.Año = a
    End Sub

    Public Function getVIN() As String
        Return VIN
    End Function

    Public Function getID() As String
        Return ID
    End Function

    Public Function getMarca() As String
        Return Marca
    End Function

    Public Function getModelo() As String
        Return Modelo
    End Function

    Public Function getPais() As String
        Return Pais
    End Function

    Public Function getColor() As String
        Return Color
    End Function

    Public Function getAño() As String
        Return Año
    End Function

    Public Function getTipo() As String
        Return Tipo
    End Function

    Public Function getLote() As String
        Return Lote
    End Function

    Public Sub setVIN(vIN As String)
        Me.VIN = vIN
    End Sub

    Public Sub setMarca(m As String)
        Marca = m
    End Sub

    Public Sub setColor(c As String)
        Color = c
    End Sub

    Public Sub setModelo(m As String)
        Modelo = m
    End Sub

    Public Sub setTipo(t As String)
        Tipo = t
    End Sub

    Public Sub setPais(p As String)
        Me.Pais = p
    End Sub

    Public Sub setLote(l As String)
        Lote = l
    End Sub

    Public Function devolverVehiculos() As String()
        Dim BDD As New Conexion
        Dim DataS As New System.Data.DataSet
        DataS = BDD.devolverVehiculos
        Dim lista As String() = (From vin In DataS.Tables(0).AsEnumerable Select vin.Field(Of String)("vin")).ToArray
        Return lista
    End Function

    Public Function devolverVehiculosLote() As String()
        Dim BDD As New Conexion
        Dim DataS As New System.Data.DataSet
        DataS = BDD.devolverVehiculosLote
        Dim lista As String() = (From vin In DataS.Tables(0).AsEnumerable Select vin.Field(Of String)("vin")).ToArray
        Return lista
    End Function

    Public Function InformacionVehiculo(vIN As String) As Vehiculo
        Dim bdd As New Conexion
        Dim DataT As New System.Data.DataTable
        Dim fechaaux As DateTime
        DataT = bdd.InfoVehiculo(vIN)
        Dim fila As DataRow() = (From row As DataRow In DataT.Rows.Cast(Of DataRow) Select row).ToArray()
        Dim lista As DataRow = fila(0)
        Me.VIN = lista(0).ToString
        Me.ID = lista(1).ToString
        Me.Marca = lista(2).ToString
        Me.Modelo = lista(3).ToString
        fechaaux = lista(4)
        Me.Año = fechaaux.Year.ToString
        Me.Color = lista(5).ToString
        Me.Pais = lista(6).ToString
        Me.Tipo = lista(7).ToString
        Me.Lote = lista(8).ToString
        Return Me
    End Function




End Class

