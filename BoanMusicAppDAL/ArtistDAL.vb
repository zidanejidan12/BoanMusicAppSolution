Imports System.Data
Imports System.Data.SqlClient
Imports BoanMusicAppBO
Imports Interfaces


Public Class ArtistDAL
    Implements IArtistDAL

    Private ReadOnly connectionString As String

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Sub AddNewArtist(artist As Artist) Implements IArtistDAL.AddNewArtist
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Using command As New SqlCommand("dbo.AddNewArtist", connection)
                    command.CommandType = CommandType.StoredProcedure

                    ' Add parameters for the stored procedure
                    command.Parameters.AddWithValue("@Name", artist.Name)
                    command.Parameters.AddWithValue("@Image", If(artist.Image IsNot Nothing, artist.Image, DBNull.Value))

                    ' Execute the command
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Handle exceptions here
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub
End Class
