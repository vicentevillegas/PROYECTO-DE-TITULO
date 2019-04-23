Imports PRMMain.MODEL
Imports PRMMain.DAL

Public Class PrmuserBLL

    Public Shared Function GetAll() As List(Of PrmuserBO)

        Return New PrmuserDAL().GetAll(Of PrmuserBO)()

    End Function

    Public Shared Function GetAll(ByVal where As String) As List(Of PrmuserBO)

        Return New PrmuserDAL().GetAll(Of PrmuserBO)(where)

    End Function

    Public Shared Function GetDataforReport_Special(ByVal where As String) As List(Of PrmuserBO)

        Return New PrmuserDAL().GetDataforReport_Special(Of PrmuserBO)(where)

    End Function

    Public Shared Function GetTable(ByVal pSql As String) As DataTable

        Return New PrmuserDAL().GetTable(pSql)

    End Function

    Public Shared Function GetUnique(ByVal input As PrmuserBO) As PrmuserBO

        Return New PrmuserDAL().GetUnique(input)

    End Function

    Public Shared Function GetTotalRecords(ByVal allRecords As Boolean) As Integer

        Return New PrmuserDAL().GetTotalRecords(allRecords)

    End Function

    Public Shared Function Exists(ByVal input As PrmuserBO) As Boolean

        Return New PrmuserDAL().Exists(input)

    End Function

    Public Shared Function Insert(ByVal input As PrmuserBO) As Boolean

        Return New PrmuserDAL().Insert(input)

    End Function

    Public Shared Function Update(ByVal input As PrmuserBO) As Boolean

        Return New PrmuserDAL().Update(input)

    End Function

    Public Shared Function Delete(ByVal input As PrmuserBO) As Boolean

        Return New PrmuserDAL().Delete(input)

    End Function

End Class