Imports System.Data.SqlClient
Imports System.IO

Module Module1
    Sub Main()

        Dim connetionString As String
        Dim sql As String
        connetionString = "Data Source=localhost;Initial Catalog=rotiseria;Integrated Security=True"

        Console.WriteLine("Init the procces")

        If Not Directory.Exists("c:\backup") Then
            Directory.CreateDirectory("c:\backup")
        End If

        Dim year As String = Now.Year
        Dim month As String = Now.Month
        Dim day As String = Now.Day
        Dim completDate As String = year + month + day

        sql = "BACKUP DATABASE rotiseria TO DISK='c:\backup\" + completDate + ".bak'"
        Try
            Using con As New SqlConnection(connetionString)
                Using cmd As New SqlCommand(sql, con)
                    cmd.CommandType = CommandType.Text
                    con.Open()
                    Dim i As Integer = cmd.ExecuteNonQuery()
                    con.Close()
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine("Problem with the backup. Communicate with area of Systems.")
        End Try

    End Sub

End Module
