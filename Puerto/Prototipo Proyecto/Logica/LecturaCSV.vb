Imports System.IO
Imports KBCsv

Public Class LecturaCSV
    Dim ruta As String

    Public Sub New(ruta As String)
        Me.ruta = ruta
    End Sub

    Public Sub Leer()
        Dim v As New Vehiculo
        Dim contador As Integer = 0

        Using textReader As New StreamReader(ruta)
            Using reader As New CsvReader(textReader, True)
                reader.ReadHeaderRecord()
                reader.ValueSeparator() = ";"

                While (reader.HasMoreRecords)
                    Dim dataRecord = reader.ReadDataRecord
                    Try
                        v.setVIN(dataRecord(0).ToString)
                        v.setMarca(dataRecord(1).ToString)
                        v.setModelo(dataRecord(2).ToString)
                        v.SetAñoManual(dataRecord(3).ToString)
                        v.setColor(dataRecord(4).ToString)
                        v.setPais(dataRecord(5).ToString)
                        v.setTipo(dataRecord(6).ToString)
                        v.AltaVehiculo()
                        contador += 1
                    Catch ex As Exception
                    End Try

                End While



            End Using
        End Using

        MsgBox("Se agregaron ", contador, " vehiculos")

    End Sub


End Class