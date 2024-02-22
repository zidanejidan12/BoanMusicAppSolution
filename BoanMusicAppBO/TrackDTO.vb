Public Class TrackDTO
    Public Property Artist_Name As String
    Public Property Track_Name As String
    Public Property Album_Name As String
    Public Property Duration As Integer
    Public Property Genre As String
    ' Additional properties as needed

    Public Sub New()
        ' Initialize properties to empty strings or default values
        Artist_Name = ""
        Track_Name = ""
        Album_Name = ""
        Duration = 0
        Genre = ""
    End Sub
End Class
