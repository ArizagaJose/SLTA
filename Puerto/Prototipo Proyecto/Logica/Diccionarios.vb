Module Diccionarios
    Dim dic As New ResourceDictionary
    Public Sub SetLanguage(idioma As String)

        Select Case (idioma)
            Case "ingles"
                dic.Source = New Uri("..\Resources\StringResourcesEnglish.xaml", UriKind.Relative)
            Case "español"
                dic.Source = New Uri("..\Resources\StringResourcesEspañol.xaml", UriKind.Relative)
        End Select
        My.Application.Resources.MergedDictionaries.Add(dic)
    End Sub

End Module
