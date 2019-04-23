Imports PRMMain.MODEL
Imports PRMMain.DAL

Public Class PrmregBLL

    Public Shared Function GetAll() As List(Of PrmregBO)

        Return New PrmregDAL().GetAll(Of PrmregBO)()

    End Function

    Public Shared Function GetAll(ByVal where As String) As List(Of PrmregBO)

        Return New PrmregDAL().GetAll(Of PrmregBO)(where)

    End Function

    Public Shared Function GetDataforReport_Special(ByVal where As String) As List(Of PrmregBO)

        Return New PrmregDAL().GetDataforReport_Special(Of PrmregBO)(where)

    End Function

    Public Shared Function GetTable(ByVal pSql As String) As DataTable

        Return New PrmregDAL().GetTable(pSql)

    End Function

    Public Shared Function GetUnique(ByVal input As PrmregBO) As PrmregBO

        Return New PrmregDAL().GetUnique(input)

    End Function

    Public Shared Function GetTotalRecords(ByVal allRecords As Boolean) As Integer

        Return New PrmregDAL().GetTotalRecords(allRecords)

    End Function

    Public Shared Function Exists(ByVal input As PrmregBO) As Boolean

        Return New PrmregDAL().Exists(input)

    End Function

    Public Shared Function Insert(ByVal input As PrmregBO) As Boolean

        Return New PrmregDAL().Insert(input)

    End Function

    Public Shared Function Update(ByVal input As PrmregBO) As Boolean

        Return New PrmregDAL().Update(input)

    End Function

    Public Shared Function Delete(ByVal input As PrmregBO) As Boolean

        Return New PrmregDAL().Delete(input)

    End Function

End Class