Imports BoanMusicAppBO

Public Interface ITrackDAL
    Sub AddNewTrack(track As Track)
    Function GetTracksByGenreDTO(genre As String) As List(Of TrackDTO)
End Interface
