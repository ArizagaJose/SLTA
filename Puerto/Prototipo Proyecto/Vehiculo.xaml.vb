Public Class Vehiculo
    Private VIN As String
    Private Marca As String
    Private Modelo As String
    Private Pais As String
    Private Color As String
    Private Año As Integer
    Private Tipo As String
    Private WMI As String

    Public Sub New(vIN As String)
        Me.VIN = vIN
    End Sub

    'debido a los altos problemas con la decodificacion, decidimos que primero verifique la marca del vehiculo y luego decodifique todo lo demas
    Public Sub decodificarVIN()
        Dim ArrayVin() As Char
        ArrayVin = VIN.ToString.ToCharArray
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

    'WMI es "World Manufacturer Identification", los 3 primeros digitos de todos los vins se utlizan para identificar a las marcas
    Public Sub getWMI()
        WMI = VIN.Substring(0, 3)
    End Sub

    Public Sub altaVehiculo()
        Dim bdd As New ConexionBDD
        VIN = TxtBoxVIN.Text
        Marca = TxtBoxMarca.Text
        Modelo = TxtBoxModelo.Text
        Color = TxtBoxColor.Text
        Pais = TxtBoxPais.Text
        Año = TxtBoxAño.Text
        Tipo = TxtBoxTipo.Text
        bdd.altaVehiculo(VIN, Marca, Modelo, Año, Color, Pais, Tipo)
    End Sub

    Private Sub Window_Loaded_1(sender As Object, e As RoutedEventArgs)
        LblUsuario.Content = My.Settings.USER_NAME
    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As RoutedEventArgs) Handles BtnIngresar.Click
        altaVehiculo()

    End Sub

    Private Sub BtnAtras_Click(sender As Object, e As RoutedEventArgs) Handles BtnAtras.Click
        Dim WinAtras As New EscanearVin
        WinAtras.Show()
        Close()
    End Sub
End Class
