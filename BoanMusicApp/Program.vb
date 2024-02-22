Imports BoanMusicAppBO
Imports BoanMusicAppDAL


' Update this namespace as per your project structure

Module Program
    Sub Main(args As String())
        ' Panggil metode CreateNewUser di sini
        ' Dim userDAL As New UserDAL("Server=.\BSISqlExpress; Database=BoanMusic; Trusted_Connection=true")
        ' UserDAL.CreateNewUser("John John Jogn", "johnjohnjogn@example.com", "password123", #2000-01-01#, Nothing, "regular")

        ' Membuat instance TrackDAL
        Dim trackDAL As New TrackDAL("Server=.\BSISqlExpress; Database=BoanMusic; Trusted_Connection=true")

        ' Menyiapkan data untuk ditambahkan
        'Dim newTrack As New Track()
        'newTrack.ArtistID = 1 ' Contoh ID artis dari database
        'newTrack.AlbumID = 3 ' Contoh ID album dari database (opsional)
        'newTrack.Name = "Kill my weakness"
        'newTrack.Duration = 382 ' Durasi lagu dalam detik
        'newTrack.Genre = "Rock" ' Genre lagu

        ' Memanggil method AddNewTrack dari instance trackDAL
        'trackDAL.AddNewTrack(newTrack)

        ' Specify the genre you want to retrieve tracks for
        Dim genre As String = "Hip Hop"

        ' Call the GetTracksByGenreDTO method to retrieve tracks by genre
        Dim tracks As List(Of TrackDTO) = trackDAL.GetTracksByGenreDTO(genre)

        ' Display the retrieved tracks
        For Each track As TrackDTO In tracks
            Console.WriteLine($"Artist: {track.Artist_Name}, Track: {track.Track_Name}, Album: {track.Album_Name}, Duration: {track.Duration}, Genre: {track.Genre}")
        Next
    End Sub
End Module
