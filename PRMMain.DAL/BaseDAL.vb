Imports IBM.Data.DB2.iSeries
Imports Dapper
Partial Public Class BaseDAL

    Public _db As New iDB2Connection

    Public ReadOnly Property GetConnectionString() As String
        Get
            Return My.Settings.ConnString
        End Get
    End Property

    Public WriteOnly Property SetConnectionString() As String
        Set(ByVal value As String)
            My.Settings.ConnString = value
            My.Settings.Save()
            _db = New iDB2Connection(GetConnectionString())
        End Set
    End Property

    Public Sub New()
        _db = New iDB2Connection(GetConnectionString())
    End Sub

    Public Sub TestQuery()
        _db.Execute("SELECT current date FROM sysibm.sysdummy1")
    End Sub

End Class
