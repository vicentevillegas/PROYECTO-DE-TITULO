Imports PRMMain.MODEL
Imports PRMMain.DAL

Public Class PrmcmpBLL

    Public Shared Function GetAll() As List(Of PrmcmpBO)

        Return New PrmcmpDAL().GetAll(Of PrmcmpBO)()

    End Function

    Public Shared Function GetAll(ByVal where As String) As List(Of PrmcmpBO)

        Return New PrmcmpDAL().GetAll(Of PrmcmpBO)(where)

    End Function

    Public Shared Function GetDataforReport_Special(ByVal where As String) As List(Of PrmcmpBO)

        Return New PrmcmpDAL().GetDataforReport_Special(Of PrmcmpBO)(where)

    End Function

    Public Shared Function GetTable(ByVal pSql As String) As DataTable

        Return New PrmcmpDAL().GetTable(pSql)

    End Function

    Public Shared Function GetUnique(ByVal input As PrmcmpBO) As PrmcmpBO

        Return New PrmcmpDAL().GetUnique(input)

    End Function

    Public Shared Function GetTotalRecords(ByVal allRecords As Boolean) As Integer

        Return New PrmcmpDAL().GetTotalRecords(allRecords)

    End Function

    Public Shared Function Exists(ByVal input As PrmcmpBO) As Boolean

        Return New PrmcmpDAL().Exists(input)

    End Function

    Public Shared Function Insert(ByVal input As PrmcmpBO) As Boolean

        Return New PrmcmpDAL().Insert(input)

    End Function

    Public Shared Function Update(ByVal input As PrmcmpBO) As Boolean

        Return New PrmcmpDAL().Update(input)

    End Function

    Public Shared Function Delete(ByVal input As PrmcmpBO) As Boolean

        Return New PrmcmpDAL().Delete(input)

    End Function

End Class