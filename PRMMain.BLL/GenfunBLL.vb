Imports PRMMain.DAL
Public Class GenfunBLL

    Public Shared Function ExecCmd(ByVal command As String) As Boolean
        Return New GenfunDAL().ExecCmd(command)
    End Function

    Public Shared Function GetUserID(ByVal command As String) As String
        Return New GenfunDAL().GetUserID(command)
    End Function

End Class
