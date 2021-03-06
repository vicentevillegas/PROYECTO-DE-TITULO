Imports System.ComponentModel
Imports System.Text
Imports PRMMain.BLL
Imports PRMMain.MODEL
Imports PRMMain.Report

Public Class FrmPrmpro

#Region "#### Public & Private Global Objects"

    Public table As New DataTable
    Public addedRow As Integer = 0
    Public userID As String = ""
    Public meTitle As String = ""
    Public iFilelib As String = ""
    Public meTableDescr As String = "Project"
    Public iUserLoc As String = "PRMMain"
    Public FormSelectedObject As New PrmproBO
    Public maxiumRecorsLocally As Integer = 5000 'Default maxnumber of record to get from DB remotelly: select count (*) from 
    Public FormMode As String = "Maintenance" 'Modes: Maintenance, Selection
    Private view As DataView
    Private ShowAllRecors As Boolean = False
    Private loading As Boolean = True
    Private totalRecords As Integer = 0
    Private filterLocally As Boolean = True

#End Region

#Region "### Maintainer Initializer"

    Private Sub FrmPrmpro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        totalRecords = PrmproBLL.GetTotalRecords(False)

        If totalRecords > maxiumRecorsLocally Then

            filterLocally = False

        End If

        If filterLocally Then

            gbFilter.Text = "Filter locally by:"
            '
		'GetCodeTextBoxesBackgroundColor_Filter_Local
		'
		txtPrmpro.BackColor = Color.Honeydew
		txtPrmsts.BackColor = Color.Honeydew
		txtPrmcmp.BackColor = Color.Honeydew
		'
		'End Code.
		'

        Else

            gbFilter.Text = "Filter remotelly by:"
            '
		'GetCodeTextBoxesBackgroundColor_Filter_Remote
		'
		txtPrmpro.BackColor = Color.LightYellow
		txtPrmsts.BackColor = Color.LightYellow
		txtPrmcmp.BackColor = Color.LightYellow
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

        Dim Form01 As New FrmPrmpro01
        Form01.rowAdding = True
        Dim objectBO As New PrmproBO
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
			newrow.Item("prmpro") = If(objectBO.prmpro Is Nothing, "", objectBO.prmpro.Trim)
            newrow.Item("prmsts") = If(objectBO.descr Is Nothing, "", PrmstsBLL.GetUnique(New PrmstsBO With {.prmsts = objectBO.prmsts.Trim()}).descr)
            newrow.Item("prmcmp") = If(objectBO.descr Is Nothing, "", PrmcmpBLL.GetUnique(New PrmcmpBO With {.prmcmp = objectBO.prmcmp.Trim()}).descr)
            newrow.Item("strdte") = objectBO.strdte
			newrow.Item("descr") = If(objectBO.descr Is Nothing, "", objectBO.descr.Trim)
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
		txtPrmpro.Select()
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

        Dim Form01 As New FrmPrmpro01
        Form01.rowCopy = True
        Form01.iUserLoc = iUserLoc
        Dim objectBO = New PrmproBO
        '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		'
		'End Code.
		'
        objectBO = PrmproBLL.GetUnique(objectBO)
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
			newrow.Item("prmpro") = If(objectBO.prmpro Is Nothing, "", objectBO.prmpro.Trim)
            newrow.Item("prmsts") = If(objectBO.descr Is Nothing, "", PrmstsBLL.GetUnique(New PrmstsBO With {.prmsts = objectBO.prmsts.Trim()}).descr)
            newrow.Item("prmcmp") = If(objectBO.descr Is Nothing, "", PrmcmpBLL.GetUnique(New PrmcmpBO With {.prmcmp = objectBO.prmcmp.Trim()}).descr)
            newrow.Item("strdte") = objectBO.strdte
			newrow.Item("descr") = If(objectBO.descr Is Nothing, "", objectBO.descr.Trim)
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
		txtPrmpro.Select()
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
        Dim objectBO = New PrmproBO
        '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		'
		'End Code.
		'
        objectBO = PrmproBLL.GetUnique(objectBO)
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

        Dim listObjectBO As List(Of PrmproBO) = PrmproBLL.GetDataforReport_Special(filter)
        Dim rpt As New RptPrmpro
        rpt.Database.Tables.Item("FrmMain_Reports_RptPrmproBO").SetDataSource(listObjectBO)
        Dim rptObject As Object
        '
        ' set report parameters
        '
        rptObject = FrmMain.SecusrBO.Secnam.Trim
        rpt.SetParameterValue("rptUser", rptObject)

        '
		'Code to get the Report's parameters.
		'
		rptObject = "Project Id......................................."
		rpt.SetParameterValue("rptRunDescr01", rptObject)
		rpt.SetParameterValue("rptRunValue01", IIf(String.IsNullOrEmpty(txtPrmpro.Text.Trim()), "[not set]", "Start With: " & txtPrmpro.Text.Trim()))
		rptObject = "Status Id........................................"
		rpt.SetParameterValue("rptRunDescr02", rptObject)
		rpt.SetParameterValue("rptRunValue02", IIf(String.IsNullOrEmpty(txtPrmsts.Text.Trim()), "[not set]", "Contains: " & txtPrmsts.Text.Trim()))
		rptObject = "Company Id......................................."
		rpt.SetParameterValue("rptRunDescr03", rptObject)
		rpt.SetParameterValue("rptRunValue03", IIf(String.IsNullOrEmpty(txtPrmcmp.Text.Trim()), "[not set]", "Contains: " & txtPrmcmp.Text.Trim()))
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
		txtPrmpro.Select()
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

            Dim objectBO As New PrmproBO
            '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		'
		'End Code.
		'
            objectBO = PrmproBLL.GetUnique(objectBO)

            If objectBO.descr Is Nothing Then

                MessageBox.Show("Row not found for selected line..please refresh grid", "Row Missing",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            End If

            Dim Form01 As New FrmPrmpro01
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
			thisRow.Item("prmpro") = If(objectBO.prmpro Is Nothing, "", objectBO.prmpro.Trim)
                thisRow.Item("prmsts") = If(objectBO.descr Is Nothing, "", PrmstsBLL.GetUnique(New PrmstsBO With {.prmsts = objectBO.prmsts.Trim()}).descr)
                thisRow.Item("prmcmp") = If(objectBO.descr Is Nothing, "", PrmcmpBLL.GetUnique(New PrmcmpBO With {.prmcmp = objectBO.prmcmp.Trim()}).descr)
                thisRow.Item("strdte") = objectBO.strdte
			thisRow.Item("descr") = If(objectBO.descr Is Nothing, "", objectBO.descr.Trim)
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
		txtPrmpro.Select()
		'
		'End Code.
		'

            Try

                Form01.Dispose()

            Catch ex As Exception

            End Try

        End If

        If columnName.Trim = "delButton" And delCell.Enabled Then

            If MessageBox.Show("Are you sure you wish to delete Project: " & vbCrLf  & thisRow.Item("Prmpro").ToString.Trim  & " ?",
            "Delete Verification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                '
		'Code to get the focus on the first filter TextBox.
		'
		txtPrmpro.Select()
		'
		'End Code.
		'
                Exit Sub
            End If

            Dim objectBO As New PrmproBO
            '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		'
		'End Code.
		'
            Dim _message As String = ""

            Try

                Dim deleted As Boolean = PrmproBLL.Delete(objectBO)

            Catch ex As Exception
                _message = ex.Message.Trim

                If _message.Trim.Length > 6 Then

                    If _message.Substring(0, 7) = "SQL0532" Then

                        _message = _message & vbCrLf & "Project: "  & thisRow.Item("Prmpro").ToString.Trim  & " is used in the above mentioned table" & vbCrLf & "Would You like to mark this code inactive?"

                    End If

                End If

                If MessageBox.Show(_message.Trim, "Delete Not Allowed",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error) = Windows.Forms.DialogResult.Yes Then

                    '
		'Code to Get Only the Object indexes(PKs).
		'
		objectBO.prmpro = thisRow.Item("prmpro").ToString.Trim
		'
		'End Code.
		'
                    objectBO = PrmproBLL.GetUnique(objectBO)
                    objectBO.active = "F"
                    Dim updated As Boolean = PrmproBLL.Update(objectBO)
                    '
			'Code to Get the thisRow.Items Columns for Main Grid.
			'
			thisRow.Item("prmpro") = If(objectBO.prmpro Is Nothing, "", objectBO.prmpro.Trim)
                    thisRow.Item("prmsts") = If(objectBO.descr Is Nothing, "", PrmstsBLL.GetUnique(New PrmstsBO With {.prmsts = objectBO.prmsts.Trim()}).descr)
                    thisRow.Item("prmcmp") = If(objectBO.descr Is Nothing, "", PrmcmpBLL.GetUnique(New PrmcmpBO With {.prmcmp = objectBO.prmcmp.Trim()}).descr)
                    thisRow.Item("strdte") = objectBO.strdte
			thisRow.Item("descr") = If(objectBO.descr Is Nothing, "", objectBO.descr.Trim)
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
		txtPrmpro.Select()
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
		If Not String.IsNullOrEmpty(txtPrmpro.Text.Trim()) Then
			filter.Append("prmpro like '" + txtPrmpro.Text.Trim().Replace("%", "[%]").Replace("'", "''") + "%'")
		End If
		If Not String.IsNullOrEmpty(txtPrmsts.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(" and ")
			End If
			filter.Append("prmsts like '%" + txtPrmsts.Text.Trim().Replace("%", "[%]").Replace("'", "''") + "%'")
		End If
		If Not String.IsNullOrEmpty(txtPrmcmp.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(" and ")
			End If
			filter.Append("prmcmp like '%" + txtPrmcmp.Text.Trim().Replace("%", "[%]").Replace("'", "''") + "%'")
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
		If Not String.IsNullOrEmpty(txtPrmpro.Text.Trim()) Then
			filter.Append($"Project Id(Start with: '{txtPrmpro.Text.Trim()}')")
		End If
		If Not String.IsNullOrEmpty(txtPrmsts.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(", ")
			End If
			filter.Append($"Status Id(Contains: '{txtPrmsts.Text.Trim()}')")
		End If
		If Not String.IsNullOrEmpty(txtPrmcmp.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(", ")
			End If
			filter.Append($"Company Id(Contains: '{txtPrmcmp.Text.Trim()}')")
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
		If Not String.IsNullOrEmpty(txtPrmpro.Text.Trim()) Then
			filter.Append($"Project Id(Start with: '{txtPrmpro.Text.Trim()}')")
		End If
		If Not String.IsNullOrEmpty(txtPrmsts.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(", ")
			End If
			filter.Append($"Status Id(Contains: '{txtPrmsts.Text.Trim()}')")
		End If
		If Not String.IsNullOrEmpty(txtPrmcmp.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(", ")
			End If
			filter.Append($"Company Id(Contains: '{txtPrmcmp.Text.Trim()}')")
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

    Private Sub TextBoxes_TextChanged(sender As Object, e As EventArgs) Handles txtPrmpro.TextChanged, txtPrmsts.TextChanged, txtPrmcmp.TextChanged

        If filterLocally Then

            Dim task As New Task(AddressOf FilterLocalData)
            task.RunSynchronously()

        Else

            RefreshMessagesOnRemote()

        End If

    End Sub

    Private Sub txt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrmpro.KeyDown, txtPrmsts.KeyDown, txtPrmcmp.KeyDown

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
		txtPrmpro.Clear()
		txtPrmsts.Clear()
		txtPrmcmp.Clear()
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
		txtPrmpro.Select()
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
		If Not String.IsNullOrEmpty(txtPrmpro.Text.Trim()) Then
			filter.Append($"upper(prmpro) like '{txtPrmpro.Text.Trim().ToUpper()}%'")
		End If
		If Not String.IsNullOrEmpty(txtPrmsts.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(" and ")
			End If
			filter.Append("upper(prmsts) like '%" + txtPrmsts.Text.Trim().ToUpper().Replace("%", "\%").Replace("'", "''") + "%' ESCAPE '\'")
		End If
		If Not String.IsNullOrEmpty(txtPrmcmp.Text.Trim()) Then
			If (filter.Length > 0) Then
				filter.Append(" and ")
			End If
			filter.Append("upper(prmcmp) like '%" + txtPrmcmp.Text.Trim().ToUpper().Replace("%", "\%").Replace("'", "''") + "%' ESCAPE '\'")
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
                            trim(crsfile.Prmpro.prmpro) as prmpro,
							trim(crsfile.Prmsts.descr)  as prmsts,
							trim(crsfile.Prmcmp.descr)  as prmcmp,
							crsfile.Prmpro.strdte as strdte,
							trim(crsfile.Prmpro.descr)  as descr,
							crsfile.Prmpro.active as active                            
                         from
	                        crsfile.Prmpro
                                left join crsfile.Prmsts
									on crsfile.Prmpro.prmsts = crsfile.Prmsts.prmsts
								left join crsfile.Prmcmp
									on crsfile.Prmpro.prmcmp = crsfile.Prmcmp.prmcmp

                         where {If(Not ShowAllRecors, " crsfile.Prmpro.active = 'T' ", " crsfile.Prmpro.active in ('T','F') ")}
                            {RemoteFilterString}"

        'Debug.Write(sqlQuery)
        Try
            table = PrmproBLL.GetTable(sqlQuery)
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
            'Debug.Write(sqlQuery)
        End Try

    End Sub

    Private Sub bgwLoadData_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bgwLoadData.RunWorkerCompleted

        view = New DataView(table)
        lblRecords.Text = $"{view.Count} of {totalRecords} records."
        view.Sort = "prmpro"
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
		grid.myGrid.Columns("prmpro").HeaderText = "Project Id"
		grid.myGrid.Columns("prmsts").HeaderText = "Prmsts"
		grid.myGrid.Columns("prmcmp").HeaderText = "Prmcmp"
		grid.myGrid.Columns("strdte").HeaderText = "Start Date"
		grid.myGrid.Columns("descr").HeaderText = "Description"
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
		txtPrmpro.Select()
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
		txtPrmpro.Select()
		'
		'End Code.
		'
        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "### Resize Main Grid Columns"

    Private Sub FrmPrmpro_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd

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
		txtPrmpro.Select()
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
		If grid.myGrid.Columns(e.ColumnIndex).Name.ToUpper = "STRDTE" Then
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
		If grid.myGrid.Columns(e.ColumnIndex).Name.ToUpper = "CHGSTM" Then
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

    Private Sub FrmPrmpro_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

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
                totalRecords = PrmproBLL.GetTotalRecords(False)

            Case "noactive"

                ShowAllRecors = True
                cbcActiveRecrods.Text = "Show all records."
                totalRecords = PrmproBLL.GetTotalRecords(True)

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