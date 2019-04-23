Imports PRMMain.Model
Imports Dapper

Public Class PrmregDAL
    Inherits BaseDAL
    Implements IBaseDAL(Of PrmregBO)

    Public Function Insert(input As PrmregBO) As Boolean Implements IBaseDAL(Of PrmregBO).Insert

        Return _db.Execute($"insert into crsfile.prmreg (  wknum, prmpro, prmuser, strdate, wrkhrs, addloc, addmod, addusr, chgloc, chgmod, chgstm, chgusr, addstm, active, notes ) 
                             values (  @wknum, @prmpro, @prmuser, @strdate, @wrkhrs, @addloc, @addmod, @addusr, @chgloc, @chgmod, @chgstm, @chgusr, @addstm, @active, @notes )",
            New With { input.wknum, input.prmpro, input.prmuser, input.strdate, input.wrkhrs, input.addloc, input.addmod, input.addusr, input.chgloc, input.chgmod, input.chgstm, input.chgusr, input.addstm, input.active, input.notes}) > 0

    End Function

    Public Function Update(input As PrmregBO) As Boolean Implements IBaseDAL(Of PrmregBO).Update

        Return _db.Execute($"update crsfile.prmreg 
                             set  strdate = @strdate, wrkhrs = @wrkhrs, addloc = @addloc, addmod = @addmod, addusr = @addusr, chgloc = @chgloc, chgmod = @chgmod, chgstm = @chgstm, chgusr = @chgusr, addstm = @addstm, active = @active, notes = @notes 
                             where  wknum = @wknum and prmpro = @prmpro and prmuser = @prmuser ",
            New With { input.strdate, input.wrkhrs, input.addloc, input.addmod, input.addusr, input.chgloc, input.chgmod, input.chgstm, input.chgusr, input.addstm, input.active, input.notes, input.wknum, input.prmpro, input.prmuser}) > 0

    End Function

    Public Function Delete(input As PrmregBO) As Boolean Implements IBaseDAL(Of PrmregBO).Delete

        Return _db.Execute($"delete from crsfile.prmreg 
                             where  wknum = @wknum and prmpro = @prmpro and prmuser = @prmuser ",
            New With { input.wknum, input.prmpro, input.prmuser})

    End Function

    Public Function GetAll(Of PrmregBO)() As List(Of PrmregBO) Implements IBaseDAL(Of PrmregBO).GetAll

        Return _db.Query(Of PrmregBO)("select * from crsfile.prmreg").AsList()

    End Function

    Public Function GetAll(Of PrmregBO)(where As String) As List(Of PrmregBO) Implements IBaseDAL(Of PrmregBO).GetAll

        Return _db.Query(Of PrmregBO)($"select * from crsfile.prmreg where {where}").AsList()

    End Function

    Public Function GetDataforReport_Special(Of PrmregBO)(where As String) As List(Of PrmregBO)

        Dim sqlText As String = $"select * from crsfile.prmreg where {where}"
        Return _db.Query(Of PrmregBO)(sqlText).AsList()

    End Function

    Public Function GetTable(input As String) As DataTable Implements IBaseDAL(Of PrmregBO).GetTable

        Dim dr As IDataReader = _db.ExecuteReader(input)
        Dim datatable As New DataTable
        datatable.Load(dr)
        Return datatable

    End Function

    Public Function GetUnique(input As PrmregBO) As PrmregBO Implements IBaseDAL(Of PrmregBO).GetUnique

        Return _db.Query(Of PrmregBO)("select * from crsfile.prmreg where  wknum = @wknum and prmpro = @prmpro and prmuser = @prmuser ",
            New With { input.wknum, input.prmpro, input.prmuser}).SingleOrDefault()

    End Function

    Public Function Exists(input As PrmregBO) As Boolean Implements IBaseDAL(Of PrmregBO).Exists

        Return _db.Query(Of PrmregBO)($"Select * from crsfile.prmreg 
                                           where  wknum = @wknum and prmpro = @prmpro and prmuser = @prmuser ",
            New With { input.wknum, input.prmpro, input.prmuser}).Count() > 0

    End Function

    Public Function GetTotalRecords(ByVal allRecords As Boolean) As Integer Implements IBaseDAL(Of PrmregBO).GetTotalRecords

        Dim SQLText As String = "select count(*) from crsfile.prmreg"
        If Not allRecords Then
            SQLText = $"{SQLText} where active = 'T'"
        End If

        Return _db.Query(Of Integer)(SQLText).AsList().FirstOrDefault()

    End Function

End Class