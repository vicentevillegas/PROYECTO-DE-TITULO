Imports PRMMain.BLL
Imports PRMMain.MODEL

Public Class FrmPrmreg01

#Region "#### Public & Private Global Objects"

    Public frmRecordAudit As frmRecordAudit
    Public rowAdding As Boolean = False
    Public rowCopy As Boolean = False
    Public loading As Boolean = False
    Public meTitle As String = ""
    Public meTableDescr As String = "Resgistry"
    Public iUserLoc As String = "PRMMain"
    Public settingUp As Boolean = False
    Public wasDone As Boolean = False
    Public objectBO As New PrmregBO

#End Region

#Region "### Maintainer Initializer"

    Private Sub frmTemplate01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.WaitCursor
        Dim indexesMsg
        loading = True
        loadProgress.Visible = loading
        'Me.Icon = My.Resources.HS_Icon
        meTitle = meTableDescr & " Maintenance"
        Me.Text = meTitle.Trim & " (" & Me.Name.Trim & ")"
        Me.KeyPreview = True
        frmRecordAudit = New frmRecordAudit
        wasDone = False

        Dim task As New Task(AddressOf FillComboboxes)
        task.RunSynchronously()

        If rowAdding Then
            setForAdd()
        ElseIf rowCopy Then
            setForCopy()
        Else
            setForUpdate()
        End If

        indexesMsg = $"wknum: {txtWknum.Text.Trim}, prmpro: {cboPrmpro.SelectedText.Trim}, prmuser: {cboPrmuser.SelectedText.Trim}"

        If rowAdding Then
            Me.Text = Me.Text.Trim & " ADDING"
        ElseIf rowCopy Then
            Me.Text = Me.Text.Trim & $" COPYING (Resgistry)"
        Else
            Me.Text = Me.Text.Trim & $" UPDATING (Resgistry: {indexesMsg})"
        End If

        loading = False
        loadProgress.Visible = loading
        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "### Buttons Events, Functions and Subs"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        '
		'Code for requiered fields.
		'
		If String.IsNullOrEmpty(txtWknum.Text.Trim()) Then
			MessageBox.Show("Week Number must be entered", "Week Number Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
			txtWknum.Select()
			Exit Sub
		End If
		If cboPrmpro.SelectedIndex = -1 Then
			MessageBox.Show("Prmpro must be selected.", "Project Id Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
			cboPrmpro.Select()
			Exit Sub
		End If
		If cboPrmuser.SelectedIndex = -1 Then
			MessageBox.Show("Prmuser must be selected.", "User Id Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
			cboPrmuser.Select()
			Exit Sub
		End If
		If String.IsNullOrEmpty(txtWrkhrs.Text.Trim()) Then
			MessageBox.Show("Work Hours must be entered", "Work Hours Missing", MessageBoxButtons.OK, MessageBoxIcon.Error)
			txtWrkhrs.Select()
			Exit Sub
		End If
		'
		'End Code.
		'        

        If rowAdding Or rowCopy Then

            '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.wknum = txtWknum.Text.Trim
		objectBO.prmpro = cboPrmpro.SelectedValue
		objectBO.prmuser = cboPrmuser.SelectedValue
		'
		'End Code.
		'

            Dim indexesMsg = $"wknum: {txtWknum.Text.Trim}, prmpro: {cboPrmpro.SelectedText.Trim}, prmuser: {cboPrmuser.SelectedText.Trim}"

            If PrmregBLL.Exists(objectBO) Then
                MessageBox.Show("Resgistry " & indexesMsg & " already exists", "Duplicate Resgistry Detected", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'
                Exit Sub
            End If

            '
		'Code to fill Object with controls informatiuon.
		'
		objectBO.strdate = If(dteStrdate.Value = DateTimePicker.MinimumDateTime, Nothing, dteStrdate.Value)
		objectBO.wrkhrs = txtWrkhrs.Text.Trim
		'
		'End Code.
		'

            If rdbActiveYes.Checked Then
                objectBO.active = "T"
            Else
                objectBO.active = "F"
            End If

            objectBO.notes = txtNotes.Text.Trim
            objectBO.addloc = FrmMain.thisLocation.Trim
            objectBO.addmod = "prmreg01"
            objectBO.addstm = Date.Now
            objectBO.addusr = FrmMain.SecusrBO.Secusr.Trim
            objectBO.chgloc = ""
            objectBO.chgmod = ""
            objectBO.chgstm = Nothing
            objectBO.chgusr = ""
            Dim success As Boolean = PrmregBLL.Insert(objectBO)

        Else

            '
		'Code to fill Object with controls informatiuon.
		'
		objectBO.strdate = If(dteStrdate.Value = DateTimePicker.MinimumDateTime, Nothing, dteStrdate.Value)
		objectBO.wrkhrs = txtWrkhrs.Text.Trim
		'
		'End Code.
		'

            If rdbActiveYes.Checked Then
                objectBO.active = "T"
            Else
                objectBO.active = "F"
            End If

            objectBO.notes = txtNotes.Text.Trim
            objectBO.chgloc = FrmMain.thisLocation.Trim
            objectBO.chgmod = "prmreg01"
            objectBO.chgstm = Date.Now
            objectBO.chgusr = FrmMain.SecusrBO.Secusr.Trim
            Dim success As Boolean = PrmregBLL.Update(objectBO)

        End If

        wasDone = True
        Me.Close()

    End Sub

    Private Sub frmTemplate01_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.Alt = True Then

            If e.KeyCode = Keys.S Then
                If btnSave.Enabled = True Then
                    e.Handled = True
                    btnSave_Click(sender, e)
                End If
            End If

        End If

        If e.KeyCode = Keys.Escape Then
            e.Handled = True
            Me.Close()
        End If

    End Sub

    Private Sub btnAudit_Click(sender As Object, e As EventArgs) Handles btnAudit.Click
        frmRecordAudit.ShowDialog()
        Me.Focus()
    End Sub

    Private Sub frmIshBnk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            e.Handled = True
            Me.Close()
        End If

    End Sub

    Private Sub btnDate_Click(sender As Object, e As EventArgs) Handles btnDate.Click
        If txtNotes.Text.Trim <> "" Then
            txtNotes.Text = txtNotes.Text.Trim & vbCrLf & vbCrLf & Date.Now.ToString("dd MMM yyyy") & " @ " & Date.Now.ToString("hh:mm tt") & " by " & FrmMain.SecusrBO.Secnam.Trim & ControlChars.NewLine
            txtNotes.SelectionStart = txtNotes.TextLength + 1
            txtNotes.Select()
        Else                                                                                         'no esta creado el bll
            txtNotes.Text = Date.Now.ToString("dd MMM yyyy") & " @ " & Date.Now.ToString("hh:mm tt") ' & " by " & FrmMain.SecusrBO.Secnam.Trim & ControlChars.NewLine
            txtNotes.SelectionStart = txtNotes.TextLength + 1
            txtNotes.Select()
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If rowAdding Then
            setForAdd()
        ElseIf rowCopy Then
            setForCopy()
        Else
            setForUpdate()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub dte_ValueChanged(sender As Object, e As EventArgs) Handles dteStrdate.ValueChanged

        Dim objectDTE As New DateTimePicker
        objectDTE = CType(sender, DateTimePicker)

        If objectDTE.Value = DateTimePicker.MinimumDateTime Then
            objectDTE.CustomFormat = " "
        Else
            objectDTE.CustomFormat = "dd MMM yyyy"
        End If

    End Sub

#End Region

#Region "### ADD, COPY & UPDATE Subs"

    Private Sub setForAdd()

        frmRecordAudit.lblAdddat.Text = ""
        frmRecordAudit.lblAddtim.Text = ""
        frmRecordAudit.lblChgdat.Text = ""
        frmRecordAudit.lblChgtim.Text = ""
        frmRecordAudit.lblAddloc.Text = ""
        frmRecordAudit.lblAddmod.Text = ""
        frmRecordAudit.lblAddusr.Text = ""
        frmRecordAudit.lblChgloc.Text = ""
        frmRecordAudit.lblChgmod.Text = ""
        frmRecordAudit.lblChgusr.Text = ""

        '
		'Code to fill Clean Controls.
		'
		txtWknum.Text = Nothing
		cboPrmpro.SelectedValue = -1
		cboPrmuser.SelectedValue = -1
		dteStrdate.Value = DateTimePicker.MinimumDateTime
		txtWrkhrs.Text = Nothing
		'
		'End Code.
		'

        rdbActiveYes.Checked = True
        txtNotes.Text = Nothing

        '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

    End Sub

    Private Sub setForCopy()

        frmRecordAudit.lblAdddat.Text = ""
        frmRecordAudit.lblAddtim.Text = ""
        frmRecordAudit.lblAddloc.Text = ""
        frmRecordAudit.lblAddmod.Text = ""
        frmRecordAudit.lblAddusr.Text = ""

        frmRecordAudit.lblChgdat.Text = ""
        frmRecordAudit.lblChgtim.Text = ""
        frmRecordAudit.lblChgloc.Text = ""
        frmRecordAudit.lblChgmod.Text = ""
        frmRecordAudit.lblChgusr.Text = ""

        txtNotes.Text = objectBO.notes.Trim

        '
		'Code to fill Control with object informatiuon.
		'
		dteStrdate.Value = If(objectBO.strdate = Nothing, DateTimePicker.MinimumDateTime, objectBO.strdate)
		txtWrkhrs.Text = If(objectBO.wrkhrs Is Nothing, Nothing, objectBO.wrkhrs.Trim)
		'
		'End Code.
		'

        If objectBO.active.Trim = "T" Then
            rdbActiveYes.Checked = True
        Else
            rdbActiveNo.Checked = True
        End If

        '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

    End Sub

    Private Sub setForUpdate()

        frmRecordAudit.lblAdddat.Text = objectBO.addstm.ToString("dd MMM yyyy")
        frmRecordAudit.lblAddtim.Text = objectBO.addstm.ToString("hh.mm.ss tt")
        frmRecordAudit.lblAddloc.Text = objectBO.addloc.Trim
        frmRecordAudit.lblAddmod.Text = objectBO.addmod.Trim
        frmRecordAudit.lblAddusr.Text = objectBO.addusr.Trim

        If objectBO.chgstm = Date.MinValue Then
            frmRecordAudit.lblChgdat.Text = ""
            frmRecordAudit.lblChgtim.Text = ""
            frmRecordAudit.lblChgloc.Text = ""
            frmRecordAudit.lblChgmod.Text = ""
            frmRecordAudit.lblChgusr.Text = ""
        Else
            frmRecordAudit.lblChgdat.Text = objectBO.chgstm.ToString("dd MMM yyyy")
            frmRecordAudit.lblChgtim.Text = objectBO.chgstm.ToString("hh.mm.ss tt")
            frmRecordAudit.lblChgloc.Text = objectBO.chgloc.Trim
            frmRecordAudit.lblChgmod.Text = objectBO.chgmod.Trim
            frmRecordAudit.lblChgusr.Text = objectBO.chgusr.Trim
        End If

        txtNotes.Text = objectBO.notes.Trim

        '
		'Code to fill controls with object information for Update.
		'
		txtWknum.Text = If(objectBO.wknum Is Nothing, String.Empty, objectBO.wknum.Trim)
		cboPrmpro.SelectedValue = If(objectBO.prmpro Is Nothing, -1, objectBO.prmpro.Trim)
		cboPrmuser.SelectedValue = If(objectBO.prmuser Is Nothing, -1, objectBO.prmuser.Trim)
		dteStrdate.Value = If(objectBO.strdate = Date.MinValue, DateTimePicker.MinimumDateTime, objectBO.strdate)
		txtWrkhrs.Text = If(objectBO.wrkhrs Is Nothing, String.Empty, objectBO.wrkhrs.Trim)
		txtNotes.Text = If(objectBO.notes Is Nothing, String.Empty, objectBO.notes.Trim)
		'
		'End Code.
		'

        If objectBO.active.Trim = "T" Then
            rdbActiveYes.Checked = True
        Else
            rdbActiveNo.Checked = True
        End If

        '
		'Code to Get Readonly Controls.
		'
		txtWknum.ReadOnly = True
		txtWknum.TabStop = False
		cboPrmpro.Enabled = False
		cboPrmpro.TabStop = False
		cboPrmuser.Enabled = False
		cboPrmuser.TabStop = False
		'
		'End Code.
		'

        '
		'Code to Get the first control filter.
		'
		txtWknum.Select()
		'
		'End Code.
		'

    End Sub

#End Region

#Region "### Fill Comboboxes"

    Private Sub FillComboboxes()

        '
		'Code to Fill comboboxes.
		'
		cboPrmpro.Enabled = False
		cboPrmuser.Enabled = False
        cboPrmpro.DisplayMember = "descr"
        cboPrmpro.ValueMember = "prmpro"
        cboPrmpro.DataSource = PrmproBLL.GetTable($"select trim(prmpro) as prmpro, trim(descr) as descr from crsfile.prmpro where trim(descr) <> '' and active = 'T' order by prmpro asc")
        cboPrmpro.SelectedIndex = -1
		RecalculateDropDownBoxWidth(cboPrmpro)
		cboPrmpro.Enabled = True
        cboPrmuser.DisplayMember = "descr"
        cboPrmuser.ValueMember = "prmuser"
        cboPrmuser.DataSource = PrmuserBLL.GetTable($"select trim(prmuser) as prmuser, trim(descr) as descr from crsfile.prmuser where trim(descr) <> '' and active = 'T' order by prmuser asc")
        cboPrmuser.SelectedIndex = -1
		RecalculateDropDownBoxWidth(cboPrmuser)
		cboPrmuser.Enabled = True
		'
		'End Code.
		'

    End Sub

#End Region

#Region "### Helpers"

    Public Sub RecalculateDropDownBoxWidth(combobox As Windows.Forms.ComboBox)

        ' Just reset if there are no items
        If combobox.Items.Count = 0 Then
            combobox.DropDownWidth = combobox.Width
            Return
        End If

        Dim g As Graphics = combobox.CreateGraphics()
        Dim WidestWidth As Integer = 0
        Dim ValueToMeasure As String
        Dim CurrentWidth As Integer
        Dim LeftCorner As Integer

        ' Find the longest string
        For i As Integer = 0 To combobox.Items.Count - 1
            ValueToMeasure = combobox.GetItemText(combobox.Items(i))
            CurrentWidth = CType(g.MeasureString(ValueToMeasure, combobox.Font).Width, Integer)
            WidestWidth = Math.Max(CurrentWidth, WidestWidth)
        Next

        ' Add a little space for a scroll bar
        If combobox.Items.Count > combobox.MaxDropDownItems Then
            WidestWidth += SystemInformation.VerticalScrollBarWidth
        End If

        ' Make sure we don't go off the screen
        LeftCorner = combobox.PointToScreen(New Point(0, combobox.Left)).X
        WidestWidth = Math.Min(Screen.PrimaryScreen.WorkingArea.Width - LeftCorner, WidestWidth)

        combobox.DropDownWidth = Math.Max(WidestWidth, combobox.Width)

        g.Dispose()

    End Sub

#End Region

End Class
