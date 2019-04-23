Public Interface IBaseDAL(Of T)

    Function Insert(ByVal input As T) As Boolean
    Function Update(ByVal input As T) As Boolean
    Function Delete(ByVal input As T) As Boolean
    Function Exists(ByVal input As T) As Boolean
    Function GetUnique(ByVal input As T) As T
    Function GetAll(Of L)() As List(Of L)
    Function GetAll(Of L)(ByVal where As String) As List(Of L)
    Function GetTable(ByVal input As String) As DataTable
    Function GetTotalRecords(ByVal allRecords As Boolean) As Integer

End Interface
