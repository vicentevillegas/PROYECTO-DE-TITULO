Imports PRMMain.Model
Imports Dapper

Public Class PrmcmpDAL
    Inherits BaseDAL
    Implements IBaseDAL(Of PrmcmpBO)

    Public Function Insert(input As PrmcmpBO) As Boolean Implements IBaseDAL(Of PrmcmpBO).Insert

        Return _db.Execute($"insert into crsfile.prmcmp (  prmcmp, descr, addloc, addmod, addusr, chgloc, chgmod, chgstm, chgusr, addstm, active, notes ) 
                             values (  @prmcmp, @descr, @addloc, @addmod, @addusr, @chgloc, @chgmod, @chgstm, @chgusr, @addstm, @active, @notes )",
            New With { input.prmcmp, input.descr, input.addloc, input.addmod, input.addusr, input.chgloc, input.chgmod, input.chgstm, input.chgusr, input.addstm, input.active, input.notes}) > 0

    End Function

    Public Function Update(input As PrmcmpBO) As Boolean Implements IBaseDAL(Of PrmcmpBO).Update

        Return _db.Execute($"update crsfile.prmcmp 
                             set  descr = @descr, addloc = @addloc, addmod = @addmod, addusr = @addusr, chgloc = @chgloc, chgmod = @chgmod, chgstm = @chgstm, chgusr = @chgusr, addstm = @addstm, active = @active, notes = @notes 
                             where  prmcmp = @prmcmp ",
            New With { input.descr, input.addloc, input.addmod, input.addusr, input.chgloc, input.chgmod, input.chgstm, input.chgusr, input.addstm, input.active, input.notes, input.prmcmp}) > 0

    End Function

    Public Function Delete(input As PrmcmpBO) As Boolean Implements IBaseDAL(Of PrmcmpBO).Delete

        Return _db.Execute($"delete from crsfile.prmcmp 
                             where  prmcmp = @prmcmp ",
            New With {input.prmcmp})

    End Function

    Public Function GetAll(Of PrmcmpBO)() As List(Of PrmcmpBO) Implements IBaseDAL(Of PrmcmpBO).GetAll

        Return _db.Query(Of PrmcmpBO)("select * from crsfile.prmcmp").AsList()

    End Function

    Public Function GetAll(Of PrmcmpBO)(where As String) As List(Of PrmcmpBO) Implements IBaseDAL(Of PrmcmpBO).GetAll

        Return _db.Query(Of PrmcmpBO)($"select * from crsfile.prmcmp where {where}").AsList()

    End Function





    Public Function GetDataforReport_Special(Of PrmcmpBO)(where As String) As List(Of PrmcmpBO)
        If where.Trim.StartsWith("and") Then
            where = where.Remove(0, 4)
        End If
        Dim sqlText As String = $"select * from crsfile.prmcmp where {where.Trim} order by prmcmp asc"
        Return _db.Query(Of PrmcmpBO)(sqlText).AsList()

    End Function







    Public Function GetTable(input As String) As DataTable Implements IBaseDAL(Of PrmcmpBO).GetTable

        Dim dr As IDataReader = _db.ExecuteReader(input)
        Dim datatable As New DataTable
        datatable.Load(dr)
        Return datatable

    End Function

    Public Function GetUnique(input As PrmcmpBO) As PrmcmpBO Implements IBaseDAL(Of PrmcmpBO).GetUnique

        Return _db.Query(Of PrmcmpBO)("select * from crsfile.prmcmp where  prmcmp = @prmcmp ",
            New With { input.prmcmp}).SingleOrDefault()

    End Function

    Public Function Exists(input As PrmcmpBO) As Boolean Implements IBaseDAL(Of PrmcmpBO).Exists

        Return _db.Query(Of PrmcmpBO)($"Select * from crsfile.prmcmp 
                                           where  prmcmp = @prmcmp ",
            New With { input.prmcmp}).Count() > 0

    End Function

    Public Function GetTotalRecords(ByVal allRecords As Boolean) As Integer Implements IBaseDAL(Of PrmcmpBO).GetTotalRecords

        Dim SQLText As String = "select count(*) from crsfile.prmcmp"
        If Not allRecords Then
            SQLText = $"{SQLText} where active = 'T'"
        End If

        Return _db.Query(Of Integer)(SQLText).AsList().FirstOrDefault()

    End Function

End Class