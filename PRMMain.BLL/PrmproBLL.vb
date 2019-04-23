Imports PRMMain.MODEL
Imports PRMMain.DAL

Public Class PrmproBLL

    Public Shared Function GetAll() As List(Of PrmproBO)

        Return New PrmproDAL().GetAll(Of PrmproBO)()

    End Function

    Public Shared Function GetAll(ByVal where As String) As List(Of PrmproBO)

        Return New PrmproDAL().GetAll(Of PrmproBO)(where)

    End Function

    Public Shared Function GetDataforReport_Special(ByVal where As String) As List(Of PrmproBO)

        Return New PrmproDAL().GetDataforReport_Special(Of PrmproBO)(where)

    End Function

    Public Shared Function GetTable(ByVal pSql As String) As DataTable

        Return New PrmproDAL().GetTable(pSql)

    End Function

    Public Shared Function GetUnique(ByVal input As PrmproBO) As PrmproBO

        Return New PrmproDAL().GetUnique(input)

    End Function

    Public Shared Function GetTotalRecords(ByVal allRecords As Boolean) As Integer

        Return New PrmproDAL().GetTotalRecords(allRecords)

    End Function

    Public Shared Function Exists(ByVal input As PrmproBO) As Boolean

        Return New PrmproDAL().Exists(input)

    End Function

    Public Shared Function Insert(ByVal input As PrmproBO) As Boolean

        Return New PrmproDAL().Insert(input)

    End Function

    Public Shared Function Update(ByVal input As PrmproBO) As Boolean

        Return New PrmproDAL().Update(input)

    End Function

    Public Shared Function Delete(ByVal input As PrmproBO) As Boolean

        Return New PrmproDAL().Delete(input)

    End Function

End Class