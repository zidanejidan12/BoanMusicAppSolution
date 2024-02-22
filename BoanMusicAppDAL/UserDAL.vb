Imports System.Data
Imports System.Data.SqlClient
Imports Interfaces

Public Class UserDAL
    Implements IUserDAL

    Private connectionString As String = "Server=.\BSISqlExpress; Database=BoanMusic; Trusted_Connection = true"

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Sub CreateNewUser(name As String, email As String, password As String, Optional dateOfBirth As Date = Nothing, Optional profileImage As Byte() = Nothing, Optional userType As String = "regular") Implements IUserDAL.CreateNewUser
        Try
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand("CreateNewUser", connection)
                    command.CommandType = CommandType.StoredProcedure

                    ' Parameters
                    command.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = email
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = password
                    command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateOfBirth
                    command.Parameters.Add("@ProfileImage", SqlDbType.VarBinary).Value = If(profileImage, DBNull.Value)
                    command.Parameters.Add("@UserType", SqlDbType.NVarChar, 50).Value = userType

                    ' Open connection and execute command
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Handle exceptions here
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub
End Class
