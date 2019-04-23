Imports PRMMain.MODEL
Imports PRMMain.DAL

Public Class PrmstsBLL

    Public Shared Function GetAll() As List(Of PrmstsBO)

        Return New PrmstsDAL().GetAll(Of PrmstsBO)()

    End Function

    Public Shared Function GetAll(ByVal where As String) As List(Of PrmstsBO)

        Return New PrmstsDAL().GetAll(Of PrmstsBO)(where)

    End Function

    Public Shared Function GetDataforReport_Special(ByVal where As String) As List(Of PrmstsBO)

        Return New PrmstsDAL().GetDataforReport_Special(Of PrmstsBO)(where)

    End Function

    Public Shared Function GetTable(ByVal pSql As String) As DataTable

        Return New PrmstsDAL().GetTable(pSql)

    End Function

    Public Shared Function GetUnique(ByVal input As PrmstsBO) As PrmstsBO

        Return New PrmstsDAL().GetUnique(input)

    End Function

    Public Shared Function GetTotalRecords(ByVal allRecords As Boolean) As Integer

        Return New PrmstsDAL().GetTotalRecords(allRecords)

    End Function

    Public Shared Function Exists(ByVal input As PrmstsBO) As Boolean

        Return New PrmstsDAL().Exists(input)

    End Function

    Public Shared Function Insert(ByVal input As PrmstsBO) As Boolean

        Return New PrmstsDAL().Insert(input)

    End Function

    Public Shared Function Update(ByVal input As PrmstsBO) As Boolean

        Return New PrmstsDAL().Update(input)

    End Function

    Public Shared Function Delete(ByVal input As PrmstsBO) As Boolean

        Return New PrmstsDAL().Delete(input)

    End Function

End Class