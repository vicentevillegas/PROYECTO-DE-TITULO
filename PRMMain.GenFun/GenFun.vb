Imports System.ComponentModel
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Module GenFun

    Private illegalFileName As New Regex(String.Format("[{0}]", Regex.Escape(New String(Path.GetInvalidFileNameChars()))), RegexOptions.Compiled)
    Private validEmail As New RegularExpressions.Regex("^(("".+?"")|([0-9a-zA-Z](((\.(?!\.))|([-!#\$%&'\*\+/=\?\^`\{\}\|~\w]))*[0-9a-zA-Z])*))@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9}$")

    Function GetUserName() As String
        If TypeOf My.User.CurrentPrincipal Is
    Security.Principal.WindowsPrincipal Then
            ' The application is using Windows authentication.
            ' The name format is DOMAIN\USERNAME.
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            ' The application is using custom authentication.
            Return My.User.Name
        End If
    End Function

    Function ConvertToDataTable(Of T)(list As IList(Of T)) As DataTable
        Dim entityType As Type = GetType(T)
        Dim table As New DataTable()
        Dim properties As PropertyDescriptorCollection = TypeDescriptor.GetProperties(entityType)
        For Each prop As PropertyDescriptor In properties
            table.Columns.Add(prop.Name, If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType))
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each prop As PropertyDescriptor In properties
                row(prop.Name) = If(prop.GetValue(item), DBNull.Value)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

    Function fixPath(ByVal pString As String) As String

        pString = illegalFileName.Replace(pString, "")

        Return pString

    End Function

    Sub CleanForm(ByVal frm As Form)

        For Each ctrl As Object In frm.Controls
            If ctrl.GetType() Is GetType(TextBox) Or ctrl.GetType() Is GetType(iShowRoomComponents.AlphaNumericUpper) Then
                CType(ctrl, TextBox).Text = ""
            End If

            If ctrl.GetType() Is GetType(NumericUpDown) Then
                CType(ctrl, NumericUpDown).Value = CType(ctrl, NumericUpDown).Minimum
            End If

            If ctrl.GetType() Is GetType(ComboBox) Then
                CType(ctrl, ComboBox).SelectedIndex = -1
            End If
        Next

    End Sub

    Public Function validateEmail(ByVal email As String) As Boolean

        Return validEmail.IsMatch(email.Trim)

    End Function


End Module
