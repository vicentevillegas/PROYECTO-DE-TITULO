Imports PRMMain.Model
Imports Dapper

Public Class PrmuserDAL
    Inherits BaseDAL
    Implements IBaseDAL(Of PrmuserBO)

    Public Function Insert(input As PrmuserBO) As Boolean Implements IBaseDAL(Of PrmuserBO).Insert

        Return _db.Execute($"insert into crsfile.prmuser (  prmuser, descr, addloc, addmod, addstm, addusr, chgloc, chgmod, chgstm, chgusr, active, notes ) 
                             values (  @prmuser, @descr, @addloc, @addmod, @addstm, @addusr, @chgloc, @chgmod, @chgstm, @chgusr, @active, @notes )",
            New With { input.prmuser, input.descr, input.addloc, input.addmod, input.addstm, input.addusr, input.chgloc, input.chgmod, input.chgstm, input.chgusr, input.active, input.notes}) > 0

    End Function

    Public Function Update(input As PrmuserBO) As Boolean Implements IBaseDAL(Of PrmuserBO).Update

        Return _db.Execute($"update crsfile.prmuser 
                             set  descr = @descr, addloc = @addloc, addmod = @addmod, addstm = @addstm, addusr = @addusr, chgloc = @chgloc, chgmod = @chgmod, chgstm = @chgstm, chgusr = @chgusr, active = @active, notes = @notes 
                             where  prmuser = @prmuser ",
            New With { input.descr, input.addloc, input.addmod, input.addstm, input.addusr, input.chgloc, input.chgmod, input.chgstm, input.chgusr, input.active, input.notes, input.prmuser}) > 0

    End Function

    Public Function Delete(input As PrmuserBO) As Boolean Implements IBaseDAL(Of PrmuserBO).Delete

        Return _db.Execute($"delete from crsfile.prmuser 
                             where  prmuser = @prmuser ",
            New With { input.prmuser})

    End Function

    Public Function GetAll(Of PrmuserBO)() As List(Of PrmuserBO) Implements IBaseDAL(Of PrmuserBO).GetAll

        Return _db.Query(Of PrmuserBO)("select * from crsfile.prmuser").AsList()

    End Function

    Public Function GetAll(Of PrmuserBO)(where As String) As List(Of PrmuserBO) Implements IBaseDAL(Of PrmuserBO).GetAll

        Return _db.Query(Of PrmuserBO)($"select * from crsfile.prmuser where {where}").AsList()

    End Function

    Public Function GetDataforReport_Special(Of PrmuserBO)(where As String) As List(Of PrmuserBO)

        Dim sqlText As String = $"select * from crsfile.prmuser where {where}"
        Return _db.Query(Of PrmuserBO)(sqlText).AsList()

    End Function

    Public Function GetTable(input As String) As DataTable Implements IBaseDAL(Of PrmuserBO).GetTable

        Dim dr As IDataReader = _db.ExecuteReader(input)
        Dim datatable As New DataTable
        datatable.Load(dr)
        Return datatable

    End Function

    Public Function GetUnique(input As PrmuserBO) As PrmuserBO Implements IBaseDAL(Of PrmuserBO).GetUnique

        Return _db.Query(Of PrmuserBO)("select * from crsfile.prmuser where  prmuser = @prmuser ",
            New With { input.prmuser}).SingleOrDefault()

    End Function

    Public Function Exists(input As PrmuserBO) As Boolean Implements IBaseDAL(Of PrmuserBO).Exists

        Return _db.Query(Of PrmuserBO)($"Select * from crsfile.prmuser 
                                           where  prmuser = @prmuser ",
            New With { input.prmuser}).Count() > 0

    End Function

    Public Function GetTotalRecords(ByVal allRecords As Boolean) As Integer Implements IBaseDAL(Of PrmuserBO).GetTotalRecords

        Dim SQLText As String = "select count(*) from crsfile.prmuser"
        If Not allRecords Then
            SQLText = $"{SQLText} where active = 'T'"
        End If

        Return _db.Query(Of Integer)(SQLText).AsList().FirstOrDefault()

    End Function

End Class