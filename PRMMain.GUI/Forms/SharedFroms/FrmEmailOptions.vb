Imports System.Text.RegularExpressions
Imports PRMMain.GenFun

Public Class frmEmailOptions

    Public meTableDescr As String = "Email Options"
    Public meTitle As String
    Public userName As String
    Public addedRow As Integer
    Public myToEmail As String
    Public myToEmailSelected As String
    Public myCCEmail As String
    Public myGroupCCEmail As New ArrayList
    Public myBCCEmail As String
    Public mySubject As String
    Public myBody As String
    Public myClient As String
    Public cancelSelected As Boolean
    'Public pmtnIshsig As iShowroomDa.mtnIshsig
    Public attachMents As New List(Of emailAttachment)

    Private tableSecusr As New DataTable
    Private pSql As String
    Private nowLoading As Boolean = True

    Private Sub frmEmailOptions_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Chr(Keys.Escape) Then
            myBody = ""
            Me.Close()
        End If

    End Sub

    Private Sub frmEmailOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        meTitle = meTableDescr.Trim
        'Me.Icon = My.Resources.HS_Icon
        Me.Text = meTitle.Trim & " (" & Me.Name.Trim & ")"
        cancelSelected = True

        If myToEmail = "" Then
            txtToEmail.Text = ""
        Else
            txtToEmail.Text = myToEmail.Trim
        End If

        lblMyEmail.Text = ""
        lblMyEmail2.Text = ""
        txtSubject.Text = mySubject.Trim

        chbBCC.Checked = True

        'Get The Client Email Shtuff
        If myClient = "" Then

            cboContacts.Enabled = False
            chbBCC.Checked = False

        Else

            'cboContacts.Enabled = True
            'pSql = "select * from " & iShowroom.iFilelib.Trim & ".ishadc where xfrloc = '" & iShowroom.iUserLoc.Trim & "' and  hsiadridn = '" & myClient & _
            '    "' and hsiemail <> '' and active = 'T' order by hsiname"
            'Dim tableIshadc As DataTable = iShowroom.refToGenfun.getResultSet(pSql)
            'cboContacts.DataSource = tableIshadc
            'cboContacts.DisplayMember = "hsiname"
            'cboContacts.ValueMember = "hsiemail"
            'chbBCC.Checked = True

        End If

        cboContacts.SelectedIndex = -1

        loadGrid()

        'Get Signature Shtuff
        'pmtnIshsig = New iShowroomDa.mtnIshsig
        'pmtnIshsig.calltype = "GR"
        'pmtnIshsig.secusr = iShowroom.iUser.Trim

        'Try
        '    pmtnIshsig = iShowroom.refToiShowroomAccess.mtnIshsig(pmtnIshsig)
        'Catch ex As Exception
        '    pmtnIshsig.errmsg = "Not Found"
        'End Try

        'If pmtnIshsig.errmsg.Trim = "Not Found" Then
        rtbBody.Rtf = Nothing
        'Else
        'rtbBody.Rtf = System.Text.UnicodeEncoding.UTF8.GetString(pmtnIshsig.signature)
        'End If

        lsvAttachments.Columns.Add("Attachment Name", 500, HorizontalAlignment.Left)
        lsvAttachments.Columns.Add("Size KB", 82, HorizontalAlignment.Right)
        lsvAttachments.Scrollable = True

        Dim lvi As New ListViewItem

        For Each attachment As emailAttachment In attachMents

            lvi = New ListViewItem(attachment.attachmentName.ToString.Trim)
            lvi.SubItems.Add(attachment.sizeKB.ToString("###,###"))
            lsvAttachments.Items.Add(lvi)

        Next

        nowLoading = False

    End Sub

    Private Sub loadGrid()

        Dim strWhere As String = ""

        ''Get Emails for Grid
        'pSql = "select a.xfrloc, b.descr, secnam, email01 from " & iShowroom.iFilelib.Trim & ".secusr a " & _
        '    " left join " & iShowroom.iFilelib.Trim & ".ishshw b on a.xfrloc = b.xfrloc " & _
        '    " where ( email01 <> '' and a.active = 'T' and usrfg2 = 'F' " & strWhere & ") or  " & _
        '    " ( email01 <> '' and a.active = 'T' and usrfg3 = 'T' )  " & _
        '      " order by b.descr, secnam"

        'tableSecusr.Clear()
        'tableSecusr = iShowroom.refToGenfun.getResultSet(pSql)

        'Dim select_email As New DataColumn
        'select_email.DataType = GetType(Boolean)
        'select_email.ColumnName = "select_email"
        'select_email.DefaultValue = False
        'tableSecusr.Columns.Add("select_email")
        'tableSecusr.AcceptChanges()

        'grdSecusr.myGrid.Columns.Clear()
        'grdSecusr.myGrid.DataSource = tableSecusr

        'Dim chbselect_email As New genClass.genClass.DataGridViewDisableCheckBoxColumn

        'With chbselect_email
        '    .HeaderText = "CC?"
        '    .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
        '    .Name = "chbselect_email"
        '    .Width = 50
        '    .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        '    .DataPropertyName = "select_email"
        '    .ToolTipText = "Click to Email"
        'End With

        'grdSecusr.myGrid.Columns.Insert(0, chbselect_email)

        'grdSecusr.myGrid.Columns("xfrloc").HeaderText = "Loc ID"
        'grdSecusr.myGrid.Columns("descr").HeaderText = "Location Name"
        'grdSecusr.myGrid.Columns("secnam").HeaderText = "User Name"
        'grdSecusr.myGrid.Columns("email01").Visible = False
        'grdSecusr.myGrid.Columns("select_email").Visible = False
        'grdSecusr.myGrid.AutoResizeColumns()

        'For Each row As DataGridViewRow In grdSecusr.myGrid.Rows
        '    Dim emailCell As genClass.genClass.DataGridViewDisableCheckBoxCell = CType(grdSecusr.myGrid.Rows(row.Index).Cells("chbselect_email"), genClass.genClass.DataGridViewDisableCheckBoxCell)
        '    emailCell.Enabled = True
        '    emailCell.Value = False
        '    emailCell.ToolTipText = "Click To CC Email User"
        'Next

    End Sub

    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click

        If txtToEmail.Text.Trim = "" And cboContacts.SelectedIndex = -1 Then
            MessageBox.Show("At Least One Email Address Must Be Input", "Data Error Message", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtToEmail.Text.Trim <> "" Then
            If Not EmailAddressCheck(txtToEmail.Text.Trim) Then
                MessageBox.Show("To Email Address Is Invalid", "Data Error Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtToEmail.Select()
                Exit Sub
            End If
        End If

        If cboContacts.SelectedIndex <> -1 Then
            If Not EmailAddressCheck(cboContacts.SelectedValue.ToString.Trim) Then
                MessageBox.Show("Contact Email Address Is Invalid", "Data Error Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                cboContacts.Select()
                Exit Sub
            End If
        End If

        If txtCCEmail.Text.Trim <> "" Then
            If Not EmailAddressCheck(txtCCEmail.Text.Trim) Then
                MessageBox.Show("CC Email Address Is Invalid", "Data Error Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtCCEmail.Select()
                Exit Sub
            End If
        End If

        If txtSubject.Text.Trim = "" Then
            MessageBox.Show("Email Subject Must Be Input", "Data Error Message", _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtSubject.Select()
            Exit Sub
        End If

        ' All Ok Mr. Sherrif

        cancelSelected = False

        myToEmail = txtToEmail.Text.Trim

        If cboContacts.SelectedIndex <> -1 Then
            myToEmailSelected = cboContacts.SelectedValue.ToString.Trim
        End If

        myCCEmail = txtCCEmail.Text.Trim

        myGroupCCEmail.Clear()

        For Each row As DataGridViewRow In grdSecusr.myGrid.Rows
            If row.Cells("chbselect_email").Value = True Then
                myGroupCCEmail.Add(row.Cells("email01").Value.ToString.Trim)
            End If
        Next


        If chbBCC.Checked Then
            myBCCEmail = lblMyEmail2.Text.Trim
        Else
            myBCCEmail = ""
        End If

        mySubject = txtSubject.Text.Trim

        Dim strHTML As String

        strHTML = ConvertToHTML(rtbBody)
        myBody = strHTML

        'If Not txtBody Is Nothing Then
        '    myBody = txtBody.Text
        'End If

        Me.Close()

    End Sub

    Function EmailAddressCheck(ByVal emailAddress As String) As Boolean

        Dim pattern As String = "^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            EmailAddressCheck = True
        Else
            EmailAddressCheck = False
        End If

    End Function

    Public Function ConvertToHTML(ByVal Box As RichTextBox) As String
        ' Takes a RichTextBox control and returns a
        ' simple HTML-formatted version of its contents
        Dim strHTML As String
        Dim strColour As String
        Dim blnBold As Boolean
        Dim blnItalic As Boolean
        Dim strFont As String
        Dim shtSize As Short
        Dim lngOriginalStart As Long
        Dim lngOriginalLength As Long
        Dim intCount As Integer
        ' If nothing in the box, exit
        If Box.Text.Length = 0 Then
            Return ""
            Exit Function
        End If
        ' Store original selections, then select first character
        lngOriginalStart = 0
        lngOriginalLength = Box.TextLength
        Box.Select(0, 1)
        ' Add HTML header
        strHTML = "<html>"
        ' Set up initial parameters
        strColour = Box.SelectionColor.ToKnownColor.ToString
        blnBold = Box.SelectionFont.Bold
        blnItalic = Box.SelectionFont.Italic
        strFont = Box.SelectionFont.FontFamily.Name
        shtSize = Box.SelectionFont.Size
        ' Include first 'style' parameters in the HTML
        strHTML += "<span style=""font-family: " & strFont & _
          "; font-size: " & shtSize & "pt; color: " _
              & strColour & """>"
        ' Include bold tag, if required
        If blnBold = True Then
            strHTML += "<b>"
        End If
        ' Include italic tag, if required
        If blnItalic = True Then
            strHTML += "<i>"
        End If
        ' Finally, add our first character
        strHTML += Box.Text.Substring(0, 1)
        ' Loop around all remaining characters
        For intCount = 2 To Box.Text.Length
            ' Select current character
            Box.Select(intCount - 1, 1)
            ' If this is a line break, add HTML tag
            If Box.Text.Substring(intCount - 1, 1) = _
                Convert.ToChar(10) Then
                strHTML += "<br>"
            End If
            ' Check/implement any changes in style
            If Box.SelectionColor.ToKnownColor.ToString <> _
               strColour Or Box.SelectionFont.FontFamily.Name _
               <> strFont Or Box.SelectionFont.Size <> shtSize _
               Then
                strHTML += "</span><span style=""font-family: " _
                  & Box.SelectionFont.FontFamily.Name & _
                  "; font-size: " & Box.SelectionFont.Size & _
                  "pt; color: " & _
                  Box.SelectionColor.ToKnownColor.ToString & """>"
            End If
            ' Check for bold changes
            If Box.SelectionFont.Bold <> blnBold Then
                If Box.SelectionFont.Bold = False Then
                    strHTML += "</b>"
                Else
                    strHTML += "<b>"
                End If
            End If
            ' Check for italic changes
            If Box.SelectionFont.Italic <> blnItalic Then
                If Box.SelectionFont.Italic = False Then
                    strHTML += "</i>"
                Else
                    strHTML += "<i>"
                End If
            End If
            ' Add the actual character
            strHTML += Mid(Box.Text, intCount, 1)
            ' Update variables with current style
            strColour = Box.SelectionColor.ToKnownColor.ToString
            blnBold = Box.SelectionFont.Bold
            blnItalic = Box.SelectionFont.Italic
            strFont = Box.SelectionFont.FontFamily.Name
            shtSize = Box.SelectionFont.Size
        Next
        ' Close off any open bold/italic tags
        If blnBold = True Then strHTML += ""
        If blnItalic = True Then strHTML += ""
        ' Terminate outstanding HTML tags
        strHTML += "</span></html>"
        ' Restore original RichTextBox selection
        Box.Select(lngOriginalStart, lngOriginalLength)
        ' Return HTML
        Return strHTML
    End Function

    Private Sub grdSecusr_myGridCellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdSecusr.myGridCellClick

        If e.RowIndex = -1 Then
            Exit Sub
        End If

        Dim colname As String = grdSecusr.myGrid.Columns(e.ColumnIndex).Name.ToUpper.Trim

        If colname.Trim = "CHBSELECT_EMAIL" Then

            Dim chbselect_email As genClass.genClass.DataGridViewDisableCheckBoxCell

            'ok it was an actual cell
            chbselect_email = CType(grdSecusr.myGrid.Rows(e.RowIndex).Cells("chbselect_email"), genClass.genClass.DataGridViewDisableCheckBoxCell)

            If chbselect_email.Enabled Then

                If chbselect_email.Value = True Then
                    chbselect_email.Value = False
                Else
                    chbselect_email.Value = True
                End If
            End If

        End If

    End Sub

    Private Sub chbMyShowroom_CheckedChanged(sender As Object, e As System.EventArgs)

        If nowLoading Then
            Exit Sub
        End If

        loadGrid()

    End Sub

    Private Sub chbJustMe_CheckedChanged(sender As Object, e As EventArgs) Handles chbJustMe.CheckedChanged

        If nowLoading Then
            Exit Sub
        End If

        'If chbJustMe.Checked Then
        '    txtToEmail.Text = iShowroom.iUserEmail01.Trim
        'Else
        '    If myToEmail = "" Then
        '        txtToEmail.Text = iShowroom.iUserEmail01
        '    Else
        '        txtToEmail.Text = myToEmail.Trim
        '    End If
        'End If

    End Sub

End Class