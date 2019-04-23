Imports PRMMain.Model
Imports Dapper

Public Class PrmproDAL
    Inherits BaseDAL
    Implements IBaseDAL(Of PrmproBO)

    Public Function Insert(input As PrmproBO) As Boolean Implements IBaseDAL(Of PrmproBO).Insert

        Return _db.Execute($"insert into crsfile.prmpro (  prmpro, prmsts, prmcmp, strdte, descr, addloc, addmod, addstm, addusr, chgloc, chgmod, chgstm, chgusr, active, notes ) 
                             values (  @prmpro, @prmsts, @prmcmp, @strdte, @descr, @addloc, @addmod, @addstm, @addusr, @chgloc, @chgmod, @chgstm, @chgusr, @active, @notes )",
            New With { input.prmpro, input.prmsts, input.prmcmp, input.strdte, input.descr, input.addloc, input.addmod, input.addstm, input.addusr, input.chgloc, input.chgmod, input.chgstm, input.chgusr, input.active, input.notes}) > 0

    End Function

    Public Function Update(input As PrmproBO) As Boolean Implements IBaseDAL(Of PrmproBO).Update

        Return _db.Execute($"update crsfile.prmpro 
                             set  prmsts = @prmsts, prmcmp = @prmcmp, strdte = @strdte, descr = @descr, addloc = @addloc, addmod = @addmod, addstm = @addstm, addusr = @addusr, chgloc = @chgloc, chgmod = @chgmod, chgstm = @chgstm, chgusr = @chgusr, active = @active, notes = @notes 
                             where  prmpro = @prmpro ",
            New With { input.prmsts, input.prmcmp, input.strdte, input.descr, input.addloc, input.addmod, input.addstm, input.addusr, input.chgloc, input.chgmod, input.chgstm, input.chgusr, input.active, input.notes, input.prmpro}) > 0

    End Function

    Public Function Delete(input As PrmproBO) As Boolean Implements IBaseDAL(Of PrmproBO).Delete

        Return _db.Execute($"delete from crsfile.prmpro 
                             where  prmpro = @prmpro ",
            New With { input.prmpro})

    End Function

    Public Function GetAll(Of PrmproBO)() As List(Of PrmproBO) Implements IBaseDAL(Of PrmproBO).GetAll

        Return _db.Query(Of PrmproBO)("select * from crsfile.prmpro").AsList()

    End Function

    Public Function GetAll(Of PrmproBO)(where As String) As List(Of PrmproBO) Implements IBaseDAL(Of PrmproBO).GetAll

        Return _db.Query(Of PrmproBO)($"select * from crsfile.prmpro where {where}").AsList()

    End Function

    Public Function GetDataforReport_Special(Of PrmproBO)(where As String) As List(Of PrmproBO)

        Dim sqlText As String = $"select * from crsfile.prmpro where {where}"
        Return _db.Query(Of PrmproBO)(sqlText).AsList()

    End Function

    Public Function GetTable(input As String) As DataTable Implements IBaseDAL(Of PrmproBO).GetTable

        Dim dr As IDataReader = _db.ExecuteReader(input)
        Dim datatable As New DataTable
        datatable.Load(dr)
        Return datatable

    End Function

    Public Function GetUnique(input As PrmproBO) As PrmproBO Implements IBaseDAL(Of PrmproBO).GetUnique

        Return _db.Query(Of PrmproBO)("select * from crsfile.prmpro where  prmpro = @prmpro ",
            New With { input.prmpro}).SingleOrDefault()

    End Function

    Public Function Exists(input As PrmproBO) As Boolean Implements IBaseDAL(Of PrmproBO).Exists

        Return _db.Query(Of PrmproBO)($"Select * from crsfile.prmpro 
                                           where  prmpro = @prmpro ",
            New With { input.prmpro}).Count() > 0

    End Function

    Public Function GetTotalRecords(ByVal allRecords As Boolean) As Integer Implements IBaseDAL(Of PrmproBO).GetTotalRecords

        Dim SQLText As String = "select count(*) from crsfile.prmpro"
        If Not allRecords Then
            SQLText = $"{SQLText} where active = 'T'"
        End If

        Return _db.Query(Of Integer)(SQLText).AsList().FirstOrDefault()

    End Function

End Class