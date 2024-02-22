Public Interface IUserDAL
    Sub CreateNewUser(name As String, email As String, password As String, Optional dateOfBirth As Date = Nothing, Optional profileImage As Byte() = Nothing, Optional userType As String = "regular")
End Interface
