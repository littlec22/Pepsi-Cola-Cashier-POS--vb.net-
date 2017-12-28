Imports MySql.Data.MySqlClient
Module conModule



    Public connectionString As String = "server=Villar-PC;database=pctsodatabase;uid=root;password=;port=3306"
    Public con As New MySqlConnection
    Public cmd As MySqlCommand
    Public adapter As MySqlDataAdapter
    Public dt As New DataTable()


    Sub testConnection()

        Try
            con = New MySqlConnection(connectionString)
        Catch ex As Exception
            MsgBox("Start Mysql on Xampp!", MsgBoxStyle.Critical)
        End Try


    End Sub

End Module
