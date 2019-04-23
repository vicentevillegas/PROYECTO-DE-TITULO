Imports PRMMain.Model
Imports Dapper

Public Class PrmstsDAL
    Inherits BaseDAL
    Implements IBaseDAL(Of PrmstsBO)

    Public Function Insert(input As PrmstsBO) As Boolean Implements IBaseDAL(Of PrmstsBO).Insert

        Return _db.Execute($"insert into crsfile.prmsts (  prmsts, descr ) 
                             values (  @prmsts, @descr )",
            New With { input.prmsts, input.descr}) > 0

    End Function

    Public Function Update(input As PrmstsBO) As Boolean Implements IBaseDAL(Of PrmstsBO).Update

        Return _db.Execute($"update crsfile.prmsts 
                             set  descr = @descr 
                             where  prmsts = @prmsts ",
            New With { input.descr, input.prmsts}) > 0

    End Function

    Public Function Delete(input As PrmstsBO) As Boolean Implements IBaseDAL(Of PrmstsBO).Delete

        Return _db.Execute($"delete from crsfile.prmsts 
                             where  prmsts = @prmsts ",
            New With { input.prmsts})

    End Function

    Public Function GetAll(Of PrmstsBO)() As List(Of PrmstsBO) Implements IBaseDAL(Of PrmstsBO).GetAll

        Return _db.Query(Of PrmstsBO)("select * from crsfile.prmsts").AsList()

    End Function

    Public Function GetAll(Of PrmstsBO)(where As String) As List(Of PrmstsBO) Implements IBaseDAL(Of PrmstsBO).GetAll

        Return _db.Query(Of PrmstsBO)($"select * from crsfile.prmsts where {where}").AsList()

    End Function

    Public Function GetDataforReport_Special(Of PrmstsBO)(where As String) As List(Of PrmstsBO)

        Dim sqlText As String = $"select * from crsfile.prmsts where {where}"
        Return _db.Query(Of PrmstsBO)(sqlText).AsList()

    End Function

    Public Function GetTable(input As String) As DataTable Implements IBaseDAL(Of PrmstsBO).GetTable

        Dim dr As IDataReader = _db.ExecuteReader(input)
        Dim datatable As New DataTable
        datatable.Load(dr)
        Return datatable

    End Function

    Public Function GetUnique(input As PrmstsBO) As PrmstsBO Implements IBaseDAL(Of PrmstsBO).GetUnique

        Return _db.Query(Of PrmstsBO)("select * from crsfile.prmsts where  prmsts = @prmsts ",
            New With { input.prmsts}).SingleOrDefault()

    End Function

    Public Function Exists(input As PrmstsBO) As Boolean Implements IBaseDAL(Of PrmstsBO).Exists

        Return _db.Query(Of PrmstsBO)($"Select * from crsfile.prmsts 
                                           where  prmsts = @prmsts ",
            New With { input.prmsts}).Count() > 0

    End Function

    Public Function GetTotalRecords(ByVal allRecords As Boolean) As Integer Implements IBaseDAL(Of PrmstsBO).GetTotalRecords

        Dim SQLText As String = "select count(*) from crsfile.prmsts"
        If Not allRecords Then
            SQLText = $"{SQLText} where active = 'T'"
        End If

        Return _db.Query(Of Integer)(SQLText).AsList().FirstOrDefault()

    End Function

End Class