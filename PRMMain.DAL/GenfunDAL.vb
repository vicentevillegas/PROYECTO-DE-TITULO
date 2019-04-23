Imports Dapper

Public Class GenfunDAL
    Inherits BaseDAL


    Public Function ExecCmd(input As String) As Boolean

        _db.Execute("gen.execcmd", New With {input.Trim}, commandType:=CommandType.StoredProcedure)

        Return True

    End Function

    Public Function GetUserID(userid As String) As String

        Dim parms As New DynamicParameters
        parms.Add("@1", userid, direction:=ParameterDirection.InputOutput)

        _db.Query("gen.getuserid", parms, commandType:=CommandType.StoredProcedure)

        Return parms.Get(Of String)("@1")

    End Function

End Class