Imports System.Data.SqlClient

Module Module1

    Public conn As SqlConnection
    Public cmd As SqlCommand
    Public da As SqlDataAdapter
    Public dr As SqlDataReader
    Public ds As DataSet
    Public result As String

    Public Sub Koneksi()

        conn = New SqlConnection("data source = DESKTOP-36PBVQ5; initial catalog = Restaurant; integrated security = true;")

        If conn.State = ConnectionState.Closed Then conn.Open()

    End Sub

End Module
