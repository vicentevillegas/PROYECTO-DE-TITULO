Imports System.ComponentModel
Imports System.Text
Imports PRMMain.BLL
Imports PRMMain.MODEL
Imports PRMMain.Report

Public Class FrmPrmreg

#Region "#### Public & Private Global Objects"

    Public table As New DataTable
    Public addedRow As Integer = 0
    Public userID As String = ""
    Public meTitle As String = ""
    Public iFilelib As String = ""
    Public meTableDescr As String = "Resgistry"
    Public iUserLoc As String = "PRMMain"
    Public FormSelectedObject As New PrmregBO
    Public maxiumRecorsLocally As Integer = 5000 'Default maxnumber of record to get from DB remotelly: select count (*) from 
    Public FormMode As String = "Maintenance" 'Modes: Maintenance, Selection
    Private view As DataView
    Private ShowAllRecors As Boolean = False
    Private loading As Boolean = True
    Private totalRecords As Integer = 0
    Private filterLocally As Boolean = True

#End Region

#Region "### Maintainer Initializer"

    Private Sub FrmPrmreg_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        loading = True
        'Me.Icon = My.Resources.HS_Icon

        If FormMode = "Maintenance" Then

            meTitle = meTableDescr & " Maintenance mode"
            SetuToolBoxforMaintenanceMode()

        End If

        If FormMode = "Selection" Then

            Me.FormBorderStyle = FormBorderStyle.SizableToolWindow
            meTitle = meTableDescr & " Selection mode"
            SetuToolBoxforSelectionMode()

        End If

        Me.Text = $" {Me.meTitle.Trim}  ({Me.Name.Trim})"
        Me.KeyPreview = True
        userID = FrmMain.SecusrBO.Secusr.Trim
        totalRecords = PrmregBLL.GetTotalRecords(False)

        If totalRecords > maxiumRecorsLocally Then

            filterLocally = False

        End If

        If filterLocally Then

            gbFilter.Text = "Filter locally by:"
            '
		'GetCodeTextBoxesBackgroundColor_Filter_Local
		'
		txtWknum.BackColor = Color.Honeydew
		txtPrmpro.BackColor = Color.Honeydew
		txtPrmuser.BackColor = Color.Honeydew
		'
		'End Code.
		'

        Else

            gbFilter.Text = "Filter remotelly by:"
            '
		'GetCodeTextBoxesBackgroundColor_Filter_Remote
		'
		txtWknum.BackColor = Color.LightYellow
		txtPrmpro.BackColor = Color.LightYellow
		txtPrmuser.BackColor = Color.LightYellow
		'
		'End Code.
		'

        End If

        If filterLocally Then

            GetDataForGridFromDB()
            lblRecords.Text = $"{totalRecords} records."

        Else

            lblRecords.Text = $"0 of {totalRecords} records."
            lblMessage.Text = "To search for a record, use the filter panel on the top of this form pressing [ENTER] after you typed your filter."

        End If

        loading = False

    End Sub

#End Region

#Region "### Add, Copy, Refresh, Print, Edit and Delete Buttons Click Events, Functions and Subs"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim Form01 As New FrmPrmreg01
        Form01.rowAdding = True
        Dim objectBO As New PrmregBO
        Form01.objectBO = objectBO
        Form01.ShowDialog()
        objectBO = Form01.objectBO

        If Form01.wasDone Then

            Dim newrow As DataRow
            newrow = table.NewRow
            newrow.Item("edtbut") = "+"
            newrow.Item("delbut") = "+"
            '
		'Code to Get the newrow.Items Column for Main Grid.
		'
			newrow.Item("wknum") = If(objectBO.wknum Is Nothing, "", objectBO.wknum.Trim)
            newrow.Item("prmpro") = If(objectBO.prmpro Is Nothing, "", PrmproBLL.GetUnique(New PrmproBO With {.prmpro = objectBO.prmpro.Trim()}).prmpro)
            newrow.Item("prmuser") = If(objectBO.prmuser Is Nothing, "", PrmuserBLL.GetUnique(New PrmuserBO With {.prmuser = objectBO.prmuser.Trim()}).prmuser)
            newrow.Item("strdate") = objectBO.strdate
			newrow.Item("wrkhrs") = If(objectBO.wrkhrs Is Nothing, "", objectBO.wrkhrs.Trim)
			newrow.Item("active") = If(objectBO.active Is Nothing, "", objectBO.active.Trim)
		'
		'End Code.
		'
            table.Rows.Add(newrow)
            grid.myGrid.CurrentCell = grid.myGrid(0, addedRow)
            grid.myGrid.CurrentRow.Selected = True
            table.AcceptChanges()
            btnPrint.Enabled = True
            btnCopy.Enabled = True

        End If

        '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

        Try
            Form01.Dispose()
        Catch ex As Exception
        End Try

        setButtons()

    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click

        If IsNothing(grid.myGrid.CurrentRow) Then
            Exit Sub
        End If

        Dim thisRow As DataRowView = grid.myGrid.CurrentRow.DataBoundItem

        Dim Form01 As New FrmPrmreg01
        Form01.rowCopy = True
        Form01.iUserLoc = iUserLoc
        Dim objectBO = New PrmregBO
        '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.wknum = thisRow.Item("wknum").ToString.Trim
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		objectBO.prmuser = thisRow.Item("prmuser").ToString.Trim
		'
		'End Code.
		'
        objectBO = PrmregBLL.GetUnique(objectBO)
        Form01.objectBO = objectBO
        Form01.ShowDialog()
        objectBO = Form01.objectBO

        If Form01.wasDone Then

            Dim newrow As DataRow
            newrow = table.NewRow
            newrow.Item("edtbut") = "+"
            newrow.Item("delbut") = "+"
            '
		'Code to Get the newrow.Items Column for Main Grid.
		'
			newrow.Item("wknum") = If(objectBO.wknum Is Nothing, "", objectBO.wknum.Trim)
            newrow.Item("prmpro") = If(objectBO.prmuser Is Nothing, "", PrmproBLL.GetUnique(New PrmproBO With {.prmpro = objectBO.prmpro.Trim()}).prmpro)
            newrow.Item("prmuser") = If(objectBO.prmuser Is Nothing, "", PrmuserBLL.GetUnique(New PrmuserBO With {.prmuser = objectBO.prmuser.Trim()}).prmuser)
            newrow.Item("strdate") = objectBO.strdate
			newrow.Item("wrkhrs") = If(objectBO.wrkhrs Is Nothing, "", objectBO.wrkhrs.Trim)
			newrow.Item("active") = If(objectBO.active Is Nothing, "", objectBO.active.Trim)
		'
		'End Code.
		'
            table.Rows.Add(newrow)
            grid.myGrid.CurrentCell = grid.myGrid(0, addedRow)
            grid.myGrid.CurrentRow.Selected = True
            table.AcceptChanges()
            btnPrint.Enabled = True
            btnCopy.Enabled = True

        End If

        '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

        Try
            Form01.Dispose()
        Catch ex As Exception
        End Try

        setButtons()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        If Not filterLocally Then

            If GetFilterStringForRemoteData.Trim <> "" Then

                GetDataForGridFromDB()
                Dim task As New Task(AddressOf FilterLocalData)
                task.RunSynchronously()
                Me.Focus()

            End If

        Else

            GetDataForGridFromDB()
            Dim task As New Task(AddressOf FilterLocalData)
            task.RunSynchronously()
            Me.Focus()

        End If

    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

        If IsNothing(grid.myGrid.CurrentRow) Then
            Exit Sub
        End If

        Dim thisRow As DataRowView = grid.myGrid.CurrentRow.DataBoundItem
        Dim objectBO = New PrmregBO
        '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.wknum = thisRow.Item("wknum").ToString.Trim
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		objectBO.prmuser = thisRow.Item("prmuser").ToString.Trim
		'
		'End Code.
		'
        objectBO = PrmregBLL.GetUnique(objectBO)
        FormSelectedObject = objectBO
        Me.Hide()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        If grid.myGrid.Rows.Count = 0 Then

            Me.Cursor = Cursors.Default
            MessageBox.Show("No data to report per selections", "Blank Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End If

        Me.Cursor = Cursors.WaitCursor
        Dim filter As String = GetFilterStringForRemoteData()

        If String.IsNullOrEmpty(filter.Trim()) Then

            filter = If(Not ShowAllRecors, " active = 'T' ", " active in ('T','F') ")

        Else

            filter = filter & If(Not ShowAllRecors, " and active = 'T' ", " and active in ('T','F') ")

        End If

        Dim listObjectBO As List(Of PrmregBO) = PrmregBLL.GetDataforReport_Special(filter)
        Dim rpt As New RptPrmreg
        rpt.Database.Tables.Item("FrmMain_Reports_RptPrmregBO").SetDataSource(listObjectBO)
        Dim rptObject As Object
        '
        ' set report parameters
        '
        rptObject = FrmMain.SecusrBO.Secnam.Trim
        rpt.SetParameterValue("rptUser", rptObject)

        '
		'Code to get the Report's parameters.
		'
		rptObject = "Week Number......................................"
		rpt.SetParameterValue("rptRunDescr01", rptObject)
		rpt.SetParameterValue("rptRunValue01", IIf(String.IsNullOrEmpty(txtWknum.Text.Trim()), "[not set]", "Start With: " & txtWknum.Text.Trim()))
		rptObject = "Project Id......................................."
		rpt.SetParameterValue("rptRunDescr02", rptObject)
		rpt.SetParameterValue("rptRunValue02", IIf(String.IsNullOrEmpty(txtPrmpro.Text.Trim()), "[not set]", "Start With: " & txtPrmpro.Text.Trim()))
		rptObject = "User Id.........................................."
		rpt.SetParameterValue("rptRunDescr03", rptObject)
		rpt.SetParameterValue("rptRunValue03", IIf(String.IsNullOrEmpty(txtPrmuser.Text.Trim()), "[not set]", "Start With: " & txtPrmuser.Text.Trim()))
		rptObject = " "
		rpt.SetParameterValue("rptRunDescr04", rptObject)
		rpt.SetParameterValue("rptRunValue04", rptObject)
		rpt.SetParameterValue("rptRunDescr05", rptObject)
		rpt.SetParameterValue("rptRunValue05", rptObject)
		rpt.SetParameterValue("rptRunDescr06", rptObject)
		rpt.SetParameterValue("rptRunValue06", rptObject)
		rpt.SetParameterValue("rptRunDescr07", rptObject)
		rpt.SetParameterValue("rptRunValue07", rptObject)
		rpt.SetParameterValue("rptRunDescr08", rptObject)
		rpt.SetParameterValue("rptRunValue08", rptObject)
		rpt.SetParameterValue("rptRunDescr09", rptObject)
		rpt.SetParameterValue("rptRunValue09", rptObject)
		rpt.SetParameterValue("rptRunDescr10", rptObject)
		rpt.SetParameterValue("rptRunValue10", rptObject)
		'
		'End Code.
		'

        'show time
        frmReport.CrystalReportViewer1.ReportSource = rpt
        frmReport.reportDescription = meTableDescr & " Listing"

        Me.Cursor = Cursors.Default

        frmReport.ShowDialog()

        If frmReport.wasDone Then

            '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

        End If

        Try

            frmReport.Dispose()

        Catch ex As Exception
        End Try

        Try

            rpt.Dispose()

        Catch ex As Exception
        End Try
    End Sub

    Private Sub gridTemplate_myGridCellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid.myGridCellClick

        If e.RowIndex < 0 Then

            Exit Sub

        End If

        Dim columnName As String = grid.myGrid.Columns(e.ColumnIndex).Name.Trim

        If columnName.Trim <> "edtButton" And columnName.Trim <> "delButton" And columnName.Trim <> "edtButton" Then

            Exit Sub

        End If

        Dim thisRow As DataRowView = grid.myGrid.CurrentRow.DataBoundItem
        Dim edtCell As genClass.genClass.DataGridViewDisableButtonCell = CType(grid.myGrid.Rows(e.RowIndex).Cells("edtButton"), genClass.genClass.DataGridViewDisableButtonCell)
        Dim delCell As genClass.genClass.DataGridViewDisableButtonCell = CType(grid.myGrid.Rows(e.RowIndex).Cells("delButton"), genClass.genClass.DataGridViewDisableButtonCell)

        If columnName.Trim = "edtButton" And edtCell.Enabled Then

            Dim objectBO As New PrmregBO
            '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.wknum = thisRow.Item("wknum").ToString.Trim
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		objectBO.prmuser = thisRow.Item("prmuser").ToString.Trim
		'
		'End Code.
		'
            objectBO = PrmregBLL.GetUnique(objectBO)

            If objectBO.prmpro Is Nothing Then

                MessageBox.Show("Row not found for selected line..please refresh grid", "Row Missing",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            End If

            Dim Form01 As New FrmPrmreg01
            Form01.rowAdding = False
            Form01.rowCopy = False
            Form01.objectBO = objectBO
            Form01.ShowDialog()
            objectBO = Form01.objectBO

            If Form01.wasDone Then

                thisRow.Item("edtbut") = "+"
                thisRow.Item("delbut") = "+"
                '
			'Code to Get the thisRow.Items Columns for Main Grid.
			'
			thisRow.Item("wknum") = If(objectBO.wknum Is Nothing, "", objectBO.wknum.Trim)
                thisRow.Item("prmpro") = If(objectBO.prmpro Is Nothing, "", PrmproBLL.GetUnique(New PrmproBO With {.prmpro = objectBO.prmpro.Trim()}).prmpro)
                thisRow.Item("prmuser") = If(objectBO.prmuser Is Nothing, "", PrmuserBLL.GetUnique(New PrmuserBO With {.prmuser = objectBO.prmuser.Trim()}).prmuser)
                thisRow.Item("strdate") = objectBO.strdate
			thisRow.Item("wrkhrs") = If(objectBO.wrkhrs Is Nothing, "", objectBO.wrkhrs.Trim)
			thisRow.Item("active") = If(objectBO.active Is Nothing, "", objectBO.active.Trim)
			'
			'End Code.
			'
                table.AcceptChanges()
                edtCell.Enabled = True
                edtCell.Value = "+"
                delCell.Enabled = True
                delCell.Value = "+"

            End If

            '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

            Try

                Form01.Dispose()

            Catch ex As Exception

            End Try

        End If

        If columnName.Trim = "delButton" And delCell.Enabled Then

            If MessageBox.Show("Are you sure you wish to delete Resgistry: " & vbCrLf  & thisRow.Item("Prmreg").ToString.Trim & ", " & thisRow.Item("Prmreg").ToString.Trim & ", " & thisRow.Item("Prmreg").ToString.Trim  & " ?",
            "Delete Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'
                Exit Sub
            End If

            Dim objectBO As New PrmregBO
            '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.wknum = thisRow.Item("wknum").ToString.Trim
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		objectBO.prmuser = thisRow.Item("prmuser").ToString.Trim
		'
		'End Code.
		'
            Dim _message As String = ""

            Try

                Dim deleted As Boolean = PrmregBLL.Delete(objectBO)

            Catch ex As Exception
                _message = ex.Message.Trim

                If _message.Trim.Length > 6 Then

                    If _message.Substring(0, 7) = "SQL0532" Then

                        _message = _message & vbCrLf & "Resgistry: "  & thisRow.Item("Prmreg").ToString.Trim & ", " & thisRow.Item("Prmreg").ToString.Trim & ", " & thisRow.Item("Prmreg").ToString.Trim  & " is used in the above mentioned table" & vbCrLf & "Would You like to mark this code inactive?"

                    End If

                End If

                If MessageBox.Show(_message.Trim, "Delete Not Allowed",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then

                    '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.wknum = thisRow.Item("wknum").ToString.Trim
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		objectBO.prmuser = thisRow.Item("prmuser").ToString.Trim
		'
		'End Code.
		'
                    objectBO = PrmregBLL.GetUnique(objectBO)
                    objectBO.active = "F"
                    Dim updated As Boolean = PrmregBLL.Update(objectBO)
                    '
			'Code to Get the thisRow.Items Columns for Main Grid.
			'
			thisRow.Item("wknum") = If(objectBO.wknum Is Nothing, "", objectBO.wknum.Trim)
                    thisRow.Item("prmpro") = If(objectBO.prmpro Is Nothing, "", PrmproBLL.GetUnique(New PrmproBO With {.prmpro = objectBO.prmpro.Trim()}).prmpro)
                    thisRow.Item("prmuser") = If(objectBO.prmuser Is Nothing, "", PrmuserBLL.GetUnique(New PrmuserBO With {.prmuser = objectBO.prmuser.Trim()}).prmuser)
                    thisRow.Item("strdate") = objectBO.strdate
			thisRow.Item("wrkhrs") = If(objectBO.wrkhrs Is Nothing, "", objectBO.wrkhrs.Trim)
			thisRow.Item("active") = If(objectBO.active Is Nothing, "", objectBO.active.Trim)
			'
			'End Code.
			'
                    table.AcceptChanges()
                    edtCell.Enabled = True
                    edtCell.Value = "+"
                    delCell.Enabled = True
                    delCell.Value = "+"

                End If

                Exit Sub

            End Try

            thisRow.Delete()
            table.AcceptChanges()

            '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

            If grid.myGrid.Rows.Count = 0 Then

                btnPrint.Enabled = False
                btnCopy.Enabled = False
                btnAdd.Select()

            Else

                btnPrint.Enabled = True
                btnCopy.Enabled = True

            End If

        End If

    End Sub

    Private Sub setButtons()

        If FormMode <> "Selection" Then

            For Each row As DataGridViewRow In grid.myGrid.Rows

                Dim edtCell As genClass.genClass.DataGridViewDisableButtonCell = CType(grid.myGrid.Rows(row.Index).Cells("edtButton"), genClass.genClass.DataGridViewDisableButtonCell)
                Dim delCell As genClass.genClass.DataGridViewDisableButtonCell = CType(grid.myGrid.Rows(row.Index).Cells("delButton"), genClass.genClass.DataGridViewDisableButtonCell)

                grid.myGrid("edtButton", row.Index).ToolTipText = "Click to edit"
                grid.myGrid("delButton", row.Index).ToolTipText = "Click to delete"

                edtCell.Enabled = True
                edtCell.Value = "+"
                delCell.Enabled = True
                delCell.Value = "+"

            Next

        End If

    End Sub

#End Region

#Region "### Getting and Filtering Main Grid Local Data"

    Private Sub FilterLocalData()

        view.RowFilter = GetFilterStringForLocalData()
        grid.myGrid.DataSource = view
        lblRecords.Text = $"{view.Count} of {totalRecords} records."

        If view.Count > 0 Then

            If FormMode = "Maintenance" Then

                btnCopy.Enabled = True
                btnPrint.Enabled = True

            End If

            If FormMode = "Selection" Then

                btnSelect.Enabled = True

            End If

        Else

            If FormMode = "Maintenance" Then

                btnCopy.Enabled = False
                btnPrint.Enabled = False

            End If

            If FormMode = "Selection" Then

                btnSelect.Enabled = False

            End If

        End If

        RefreshMessages()

    End Sub

    Private Function GetFilterStringForLocalData() As String

        Dim filter As StringBuilder = New StringBuilder()
        '
		'Code for Get Filter Local Data Logic.
		'
		If Not String.IsNullOrEmpty(txtWknum.Text.Trim()) Then
			filter.Append("wknum like '" + txtWknum.Text.Trim().Replace("%", "[%]").Replace("'", "''") + "%'")
		End If
		If Not String.IsNullOrEmpty(txtPrmpro.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(" and ")
			End If
			filter.Append("prmpro like '%" + txtPrmpro.Text.Trim().Replace("%", "[%]").Replace("'", "''") + "%'")
		End If
		If Not String.IsNullOrEmpty(txtPrmuser.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(" and ")
			End If
			filter.Append("prmuser like '%" + txtPrmuser.Text.Trim().Replace("%", "[%]").Replace("'", "''") + "%'")
		End If
		'
		'End Code.
		'
        Return filter.ToString()

    End Function

    Private Sub RefreshMessages()

        Dim filter As StringBuilder = New StringBuilder()
        '
		'Code for Get Filter String Message.
		'
		If Not String.IsNullOrEmpty(txtWknum.Text.Trim()) Then
			filter.Append($"Week Number(Start with: '{txtWknum.Text.Trim()}')")
		End If
		If Not String.IsNullOrEmpty(txtPrmpro.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(", ")
			End If
			filter.Append($"Project Id(Contains: '{txtPrmpro.Text.Trim()}')")
		End If
		If Not String.IsNullOrEmpty(txtPrmuser.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(", ")
			End If
			filter.Append($"User Id(Contains: '{txtPrmuser.Text.Trim()}')")
		End If
		'
		'End Code.
		'
        If Not String.IsNullOrEmpty(filter.ToString.Trim) Then
            lblMessage.Text = $"Filtered by: {filter.ToString}."
        Else

            If Not filterLocally Then

                lblMessage.Text = "To search for a record, use the filter panel on the top of this form pressing [ENTER] after you typed your filter."

            Else

                lblMessage.Text = "To search for a record, use the filter panel on the top of this form."

            End If

        End If

    End Sub

    Private Sub RefreshMessagesOnRemote()

        Dim filter As StringBuilder = New StringBuilder()
        '
		'Code for Get Filter String Message.
		'
		If Not String.IsNullOrEmpty(txtWknum.Text.Trim()) Then
			filter.Append($"Week Number(Start with: '{txtWknum.Text.Trim()}')")
		End If
		If Not String.IsNullOrEmpty(txtPrmpro.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(", ")
			End If
			filter.Append($"Project Id(Contains: '{txtPrmpro.Text.Trim()}')")
		End If
		If Not String.IsNullOrEmpty(txtPrmuser.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(", ")
			End If
			filter.Append($"User Id(Contains: '{txtPrmuser.Text.Trim()}')")
		End If
		'
		'End Code.
		'
        If Not String.IsNullOrEmpty(filter.ToString.Trim) Then

            If Not filterLocally Then
                lblMessage.Text = $"Prepared to filter by: {filter.ToString}. press [ENTER] to get the results."
            End If

        Else

            lblMessage.Text = "To search for a record, use the filter panel on the top of this form pressing [ENTER] after you typed your filter."

        End If

    End Sub

    Private Sub TextBoxes_TextChanged(sender As Object, e As EventArgs) Handles txtWknum.TextChanged, txtPrmpro.TextChanged, txtPrmuser.TextChanged

        If filterLocally Then

            Dim task As New Task(AddressOf FilterLocalData)
            task.RunSynchronously()

        Else

            RefreshMessagesOnRemote()

        End If

    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWknum.KeyDown, txtPrmpro.KeyDown, txtPrmuser.KeyDown

        If Not filterLocally Then

            If e.KeyCode = Keys.Enter Then

                e.SuppressKeyPress = True

                If GetFilterStringForRemoteData.Trim <> "" Then

                    GetDataForGridFromDB()

                Else

                    view = New DataView()
                    grid.myGrid.DataSource = view
                    lblRecords.Text = $"0 of {totalRecords} records."
                    lblMessage.Text = "To search for a record, use the filter panel on the top of this form pressing [ENTER] after you typed your filter."
                    btnSelect.Enabled = False
                    btnCopy.Enabled = False
                    btnPrint.Enabled = False

                End If

            End If

        Else

            If e.KeyCode = Keys.Enter Then

                e.SuppressKeyPress = True

            End If

        End If

    End Sub

    Private Sub PerformClearFilters()

        lblMessage.Text = "Removing filters..."
        '
		'Code to get the TextBoxes for Clearing.
		'
		txtWknum.Clear()
		txtPrmpro.Clear()
		txtPrmuser.Clear()
		'
		'End Code.
		'
        ShowAllRecors = False
        cbcActiveRecrods.Text = "Show only active records."

        If filterLocally Then

            view.RowFilter = GetFilterStringForLocalData()
            grid.myGrid.DataSource = view

        Else

            view = New DataView()
            grid.myGrid.DataSource = view

        End If

        setButtons()

        If view Is Nothing Then

            lblRecords.Text = $"0 of {totalRecords} records."

        Else

            lblRecords.Text = $"{view.Count} of {totalRecords} records."

            If view.Count > 0 Then

                If FormMode = "Maintenance" Then

                    btnCopy.Enabled = True

                End If

                If FormMode = "Selection" Then

                    btnSelect.Enabled = True

                End If

                btnPrint.Enabled = True

            Else

                If FormMode = "Maintenance" Then

                    btnCopy.Enabled = False
                    btnPrint.Enabled = False

                End If

                If FormMode = "Selection" Then

                    btnSelect.Enabled = False

                End If

                lblRecords.Text = $"0 of {totalRecords} records."

            End If

        End If

        RefreshMessages()
        '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles btnClear.LinkClicked

        PerformClearFilters()

    End Sub

#End Region

#Region "### Getting and Filtering Main Grid Remote Data"

    Private Sub GetDataForGridFromDB()

        If Not bgwLoadData.IsBusy Then

            Me.Cursor = Cursors.WaitCursor
            lblMessage.Text = $"Loading  records..."
            lblRecords.Text = $""
            pnlButtons.Enabled = False
            gbFilter.Enabled = False
            pbLoadingData.Visible = True
            pbLoadingData.Enabled = True
            table.Clear()
            grid.myGrid.Columns.Clear()
            bgwLoadData.RunWorkerAsync()

        End If

    End Sub

    Private Function GetFilterStringForRemoteData() As String

        Dim filter As StringBuilder = New StringBuilder()
        '
		'Code for Get Filter Remote Data Logic.
		'
		If Not String.IsNullOrEmpty(txtWknum.Text.Trim()) Then
			filter.Append($"upper(wknum) like '{txtWknum.Text.Trim().ToUpper()}%'")
		End If
		If Not String.IsNullOrEmpty(txtPrmpro.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(" and ")
			End If
			filter.Append("upper(prmpro) like '%" + txtPrmpro.Text.Trim().ToUpper().Replace("%", "\%").Replace("'", "''") + "%' ESCAPE '\'")
		End If
		If Not String.IsNullOrEmpty(txtPrmuser.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(" and ")
			End If
			filter.Append("upper(prmuser) like '%" + txtPrmuser.Text.Trim().ToUpper().Replace("%", "\%").Replace("'", "''") + "%' ESCAPE '\'")
		End If
		'
		'End Code.
		'

        If String.IsNullOrEmpty(filter.ToString().Trim) Then

            Return ""

        Else

            Return $" and {filter.ToString()}"

        End If

    End Function

    Private Sub bgwLoadData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwLoadData.DoWork

        Dim sqlQuery As String
        Dim sqlButtons As String = ""
        Dim RemoteFilterString As String = ""

        If FormMode <> "Selection" Then
            sqlButtons = "' ' as edtbut,' ' as delbut,"
        End If

        If Not filterLocally Then
            RemoteFilterString = GetFilterStringForRemoteData()

        End If

        sqlQuery = $"select 
                            {sqlButtons}                                         
                            crsfile.Prmreg.wknum as wknum,
							crsfile.Prmpro.descript as prmpro,
							crsfile.Prmuser.descript as prmuser,
							crsfile.Prmreg.strdate as strdate,
							crsfile.Prmreg.wrkhrs as wrkhrs,
							crsfile.Prmreg.active as active                            
                         from
	                        crsfile.Prmreg
                                left join crsfile.Prmpro
									on crsfile.Prmreg.prmpro = crsfile.Prmpro.prmpro
								left join crsfile.Prmuser
									on crsfile.Prmreg.prmuser = crsfile.Prmuser.prmuser

                         where {If(Not ShowAllRecors, " crsfile.Prmreg.active = 'T' ", " crsfile.Prmreg.active in ('T','F') ")}
                            {RemoteFilterString}"

        'Debug.Write(sqlQuery)
        Try
            table = PrmregBLL.GetTable(sqlQuery)
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            'Debug.Write(sqlQuery)
        End Try

    End Sub

    Private Sub bgwLoadData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwLoadData.RunWorkerCompleted

        view = New DataView(table)
        lblRecords.Text = $"{view.Count} of {totalRecords} records."
        view.Sort = "wknum, prmpro, prmuser"
        grid.myGrid.DataSource = view

        If FormMode <> "Selection" Then

            Dim delButton As New genClass.genClass.DataGridViewDisableButtonColumn
            With delButton
                .HeaderText = "Del"
                .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                .Name = "delButton"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DataPropertyName = "delbut"
            End With

            grid.myGrid.Columns.Insert(0, delButton)

            Dim edtButton As New genClass.genClass.DataGridViewDisableButtonColumn
            With edtButton
                .HeaderText = "Edt"
                .DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                .Name = "edtButton"
                .Width = 50
                .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                .DataPropertyName = "edtbut"
            End With

            grid.myGrid.Columns.Insert(0, edtButton)


            grid.myGrid.Columns("edtbut").Visible = False
            grid.myGrid.Columns("delbut").Visible = False

        End If
        '
		'Code to Get Main Grid Columns.
		'
		grid.myGrid.Columns("wknum").HeaderText = "Week Number"
		grid.myGrid.Columns("prmpro").HeaderText = "Prmpro"
		grid.myGrid.Columns("prmuser").HeaderText = "Prmuser"
		grid.myGrid.Columns("strdate").HeaderText = "Start Date"
		grid.myGrid.Columns("wrkhrs").HeaderText = "Work Hours"
		grid.myGrid.Columns("active").HeaderText = "Active (yes/no)"
		'
		'End Code.
		'
        ResizeColumns()

        If grid.myGrid.Rows.Count = 0 Then

            pnlButtons.Enabled = True
            gbFilter.Enabled = True
            btnPrint.Enabled = False
            btnCopy.Enabled = False
            btnAdd.Select()
            pbLoadingData.Visible = False
            pbLoadingData.Enabled = False
            Me.Cursor = Cursors.Default
            lblMessage.Text = "Ready."
            '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'
            Exit Sub

        Else

            btnPrint.Enabled = True
            btnCopy.Enabled = True

        End If

        FilterLocalData()

        If grid.myGrid.Rows.Count > 0 Then
            grid.myGrid.Rows(0).Selected = True
        End If

        setButtons()

        pnlButtons.Enabled = True
        gbFilter.Enabled = True
        pbLoadingData.Visible = False
        pbLoadingData.Enabled = False
        RefreshMessages()
        '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'
        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "### Resize Main Grid Columns"

    Private Sub FrmPrmreg_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd

        Dim task As New Task(AddressOf ResizeColumns)
        task.RunSynchronously()

    End Sub

    Private Sub ResizeColumns()

        bgReziseColumns.RunWorkerAsync()

    End Sub

    Private Sub bgReziseColumns_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgReziseColumns.RunWorkerCompleted

        '
		'Code to get the focus on the first filter TextBox.
		'
		txtWknum.Select()
		'
		'End Code.
		'

    End Sub

    Private Sub bgReziseColumns_DoWork(sender As Object, e As DoWorkEventArgs) Handles bgReziseColumns.DoWork

        Try

            ResetGridColumns()

        Catch ex As Exception

            Debug.WriteLine(Threading.Thread.CurrentThread.Name, ex.Message)

        End Try

    End Sub

    Private Sub ResetGridColumns()

        If grid.InvokeRequired Then

            grid.Invoke(New MethodInvoker(AddressOf ResetGridColumns))

        Else

            grid.myGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            grid.myGrid.AutoResizeColumns()

            '
            ' Here you can fix the size of the Column.
            '
            ' Example:
            '
            '    grid.myGrid.Columns("column").Width = 70
            '    grid.myGrid.Columns("column").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        End If

    End Sub

#End Region

#Region "### Formatting Main Grid Columns"

    Private Sub grid_myGridCellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles grid.myGridCellFormatting

        If IsDBNull(e.Value) Then

            Exit Sub

        End If

        If grid.myGrid.Columns(e.ColumnIndex).Name.ToLower = "active" Then

            If e.Value = "T" Then

                e.Value = "Yes"

            Else

                e.Value = "No"

            End If

        End If

        '
		'Code to get the Gridview Columns Standard Format.
		'
		If grid.myGrid.Columns(e.ColumnIndex).Name.ToUpper = "STRDATE" Then
			If e.Value <> Nothing Then
				e.CellStyle.Format = "dd MMM yyyy"
				e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
			Else
				e.Value = ""
			End If
		End If
		If grid.myGrid.Columns(e.ColumnIndex).Name.ToUpper = "CHGSTM" Then
			If e.Value <> Nothing Then
				e.CellStyle.Format = "dd MMM yyyy"
				e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
			Else
				e.Value = ""
			End If
		End If
		If grid.myGrid.Columns(e.ColumnIndex).Name.ToUpper = "ADDSTM" Then
			If e.Value <> Nothing Then
				e.CellStyle.Format = "dd MMM yyyy"
				e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
			Else
				e.Value = ""
			End If
		End If
		'
		'End Code.
		'

    End Sub

#End Region

#Region "### Window Short Cuts"

    Private Sub FrmPrmreg_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.Escape Then

            e.Handled = True
            Me.Close()

        End If

        If e.Alt = True Then

            If e.KeyCode = Keys.A Then

                If btnAdd.Enabled = True Then

                    e.Handled = True
                    btnAdd_Click(sender, e)

                End If

            End If

            If e.KeyCode = Keys.C Then

                If btnCopy.Enabled = True Then

                    e.Handled = True
                    btnCopy_Click(sender, e)

                End If

            End If

            If e.KeyCode = Keys.P Then

                If btnPrint.Enabled = True Then

                    e.Handled = True
                    btnPrint_Click(sender, e)

                End If

            End If

            If e.KeyCode = Keys.R Then

                If btnRefresh.Enabled = True Then

                    e.Handled = True
                    btnRefresh_Click(sender, e)

                End If

            End If

        End If

    End Sub

#End Region

#Region "### Buttons settings"

    Private Sub SetuToolBoxforMaintenanceMode()

        btnSelect.Enabled = False
        btnSelect.Visible = False

    End Sub

    Private Sub SetuToolBoxforSelectionMode()

        btnAdd.Enabled = False
        btnAdd.Visible = False

        btnCopy.Enabled = False
        btnCopy.Visible = False

    End Sub

#End Region

#Region "### Bottom Status Bar"

    Private Sub cbcActiveRecrods_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles cbcActiveRecrods.DropDownItemClicked

        Select Case e.ClickedItem.Tag

            Case "active"

                ShowAllRecors = False
                cbcActiveRecrods.Text = "Show only active records."
                totalRecords = PrmregBLL.GetTotalRecords(False)

            Case "noactive"

                ShowAllRecors = True
                cbcActiveRecrods.Text = "Show all records."
                totalRecords = PrmregBLL.GetTotalRecords(True)

        End Select

        If Not filterLocally Then

            If GetFilterStringForRemoteData.Trim <> "" Then

                GetDataForGridFromDB()
                Dim task As New Task(AddressOf FilterLocalData)
                task.RunSynchronously()
                Me.Focus()

            End If

        Else

            GetDataForGridFromDB()
            Dim task As New Task(AddressOf FilterLocalData)
            task.RunSynchronously()
            Me.Focus()

        End If

    End Sub

#End Region



End Class