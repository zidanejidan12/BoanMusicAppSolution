Imports System.Data
Imports System.Data.SqlClient
Imports BoanMusicAppBO
Imports Interfaces

' Update this namespace as per your project structure

Public Class TrackDAL
    Implements ITrackDAL

    Private connectionString As String = "Server=.\BSISqlExpress; Database=BoanMusic; Trusted_Connection=true"

    Public Sub New(connectionString As String)
        Me.connectionString = connectionString
    End Sub

    Public Sub AddNewTrack(track As Track) Implements ITrackDAL.AddNewTrack
        Try
            Using connection As New SqlConnection(Me.connectionString)
                connection.Open()
                Using command As New SqlCommand("dbo.AddNewTrack", connection)
                    command.CommandType = CommandType.StoredProcedure

                    ' Add parameters for the stored procedure
                    command.Parameters.AddWithValue("@ArtistID", track.ArtistID)
                    command.Parameters.AddWithValue("@AlbumID", track.AlbumID)
                    command.Parameters.AddWithValue("@Name", track.Name)
                    command.Parameters.AddWithValue("@Duration", track.Duration)
                    command.Parameters.AddWithValue("@Genre", track.Genre)

                    ' Execute the command
                    command.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Handle exceptions here
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Sub

    Public Function GetTracksByGenreDTO(genre As String) As List(Of TrackDTO) Implements ITrackDAL.GetTracksByGenreDTO
        Dim tracks As New List(Of TrackDTO)()

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using command As New SqlCommand("dbo.GetTracksByGenre", connection)
                    command.CommandType = CommandType.StoredProcedure

                    ' Add parameters
                    command.Parameters.AddWithValue("@Genre", genre)

                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim track As New TrackDTO()
                            track.Artist_Name = reader.GetString(reader.GetOrdinal("Artist_Name"))
                            track.Track_Name = reader.GetString(reader.GetOrdinal("Track_Name"))
                            If Not reader.IsDBNull(reader.GetOrdinal("Album_Name")) Then
                                track.Album_Name = reader.GetString(reader.GetOrdinal("Album_Name"))
                            End If
                            track.Duration = reader.GetInt32(reader.GetOrdinal("Duration"))
                            track.Genre = reader.GetString(reader.GetOrdinal("Genre"))

                            tracks.Add(track)
                        End While

                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Handle exceptions here
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Return tracks
    End Function

End Class
