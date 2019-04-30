<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrmpro
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrmpro))
        Me.gbFilter = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.LinkLabel()
        Me.txtPrmpro = New iShowRoomComponents.AlphaNumericUpper(Me.components)
        Me.lblPrmpro = New System.Windows.Forms.Label()
        Me.txtPrmsts = New System.Windows.Forms.TextBox()
        Me.lblPrmsts = New System.Windows.Forms.Label()
        Me.txtPrmcmp = New System.Windows.Forms.TextBox()
        Me.lblPrmcmp = New System.Windows.Forms.Label()
        Me.bgwLoadData = New System.ComponentModel.BackgroundWorker()
        Me.statusForm = New System.Windows.Forms.StatusStrip()
        Me.cbcActiveRecrods = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuActive = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuNotActive = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pbLoadingData = New System.Windows.Forms.ToolStripProgressBar()
        Me.lblRecords = New System.Windows.Forms.ToolStripStatusLabel()
        Me.bgReziseColumns = New System.ComponentModel.BackgroundWorker()
        Me.pnlButtons = New System.Windows.Forms.ToolStrip()
        Me.btnSelect = New System.Windows.Forms.ToolStripButton()
        Me.btnAdd = New System.Windows.Forms.ToolStripButton()
        Me.btnCopy = New System.Windows.Forms.ToolStripButton()
        Me.btnRefresh = New System.Windows.Forms.ToolStripButton()
        Me.btnPrint = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.grid = New iShowRoomComponents.gridTemplate()
        Me.gbFilter.SuspendLayout()
        Me.statusForm.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbFilter
        '
        Me.gbFilter.Controls.Add(Me.btnClear)
        Me.gbFilter.Controls.Add(Me.txtPrmpro)
        Me.gbFilter.Controls.Add(Me.lblPrmpro)
        Me.gbFilter.Controls.Add(Me.txtPrmsts)
        Me.gbFilter.Controls.Add(Me.lblPrmsts)
        Me.gbFilter.Controls.Add(Me.txtPrmcmp)
        Me.gbFilter.Controls.Add(Me.lblPrmcmp)
        Me.gbFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.gbFilter.Location = New System.Drawing.Point(0, 3)
        Me.gbFilter.Name = "gbFilter"
        Me.gbFilter.Size = New System.Drawing.Size(1234, 59)
        Me.gbFilter.TabIndex = 0
        Me.gbFilter.TabStop = False
        Me.gbFilter.Text = "Filter By:"
        '
        'btnClear
        '
        Me.btnClear.AutoSize = True
        Me.btnClear.Location = New System.Drawing.Point(378, 36)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(70, 13)
        Me.btnClear.TabIndex = 172
        Me.btnClear.TabStop = True
        Me.btnClear.Text = "Clear Filter(s)."
        '
        'txtPrmpro
        '
        Me.txtPrmpro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrmpro.ForeColor = System.Drawing.Color.Navy
        Me.txtPrmpro.Location = New System.Drawing.Point(9, 33)
        Me.txtPrmpro.MaxLength = 20
        Me.txtPrmpro.Name = "txtPrmpro"
        Me.txtPrmpro.Size = New System.Drawing.Size(110, 20)
        Me.txtPrmpro.TabIndex = 1
        '
        'lblPrmpro
        '
        Me.lblPrmpro.AutoSize = True
        Me.lblPrmpro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrmpro.Location = New System.Drawing.Point(9, 19)
        Me.lblPrmpro.Name = "lblPrmpro"
        Me.lblPrmpro.Size = New System.Drawing.Size(62, 13)
        Me.lblPrmpro.TabIndex = 171
        Me.lblPrmpro.Text = "Project Id"
        '
        'txtPrmsts
        '
        Me.txtPrmsts.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrmsts.ForeColor = System.Drawing.Color.Navy
        Me.txtPrmsts.Location = New System.Drawing.Point(129, 33)
        Me.txtPrmsts.MaxLength = 20
        Me.txtPrmsts.Name = "txtPrmsts"
        Me.txtPrmsts.Size = New System.Drawing.Size(110, 20)
        Me.txtPrmsts.TabIndex = 1
        '
        'lblPrmsts
        '
        Me.lblPrmsts.AutoSize = True
        Me.lblPrmsts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrmsts.Location = New System.Drawing.Point(129, 19)
        Me.lblPrmsts.Name = "lblPrmsts"
        Me.lblPrmsts.Size = New System.Drawing.Size(37, 13)
        Me.lblPrmsts.TabIndex = 171
        Me.lblPrmsts.Text = "Status"
        '
        'txtPrmcmp
        '
        Me.txtPrmcmp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrmcmp.ForeColor = System.Drawing.Color.Navy
        Me.txtPrmcmp.Location = New System.Drawing.Point(249, 33)
        Me.txtPrmcmp.MaxLength = 20
        Me.txtPrmcmp.Name = "txtPrmcmp"
        Me.txtPrmcmp.Size = New System.Drawing.Size(110, 20)
        Me.txtPrmcmp.TabIndex = 1
        '
        'lblPrmcmp
        '
        Me.lblPrmcmp.AutoSize = True
        Me.lblPrmcmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrmcmp.Location = New System.Drawing.Point(249, 19)
        Me.lblPrmcmp.Name = "lblPrmcmp"
        Me.lblPrmcmp.Size = New System.Drawing.Size(51, 13)
        Me.lblPrmcmp.TabIndex = 171
        Me.lblPrmcmp.Text = "Company"
        '
        'bgwLoadData
        '
        '
        'statusForm
        '
        Me.statusForm.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusForm.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.statusForm.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cbcActiveRecrods, Me.lblMessage, Me.pbLoadingData, Me.lblRecords})
        Me.statusForm.Location = New System.Drawing.Point(0, 623)
        Me.statusForm.Name = "statusForm"
        Me.statusForm.Size = New System.Drawing.Size(1234, 22)
        Me.statusForm.TabIndex = 8
        Me.statusForm.Text = "StatusStrip1"
        '
        'cbcActiveRecrods
        '
        Me.cbcActiveRecrods.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuActive, Me.mnuNotActive})
        Me.cbcActiveRecrods.Image = CType(resources.GetObject("cbcActiveRecrods.Image"), System.Drawing.Image)
        Me.cbcActiveRecrods.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cbcActiveRecrods.Margin = New System.Windows.Forms.Padding(0)
        Me.cbcActiveRecrods.Name = "cbcActiveRecrods"
        Me.cbcActiveRecrods.Size = New System.Drawing.Size(170, 22)
        Me.cbcActiveRecrods.Text = "Show only active records."
        '
        'mnuActive
        '
        Me.mnuActive.Image = CType(resources.GetObject("mnuActive.Image"), System.Drawing.Image)
        Me.mnuActive.Name = "mnuActive"
        Me.mnuActive.Size = New System.Drawing.Size(208, 22)
        Me.mnuActive.Tag = "active"
        Me.mnuActive.Text = "Show only active records."
        '
        'mnuNotActive
        '
        Me.mnuNotActive.Image = CType(resources.GetObject("mnuNotActive.Image"), System.Drawing.Image)
        Me.mnuNotActive.Name = "mnuNotActive"
        Me.mnuNotActive.Size = New System.Drawing.Size(208, 22)
        Me.mnuNotActive.Tag = "noactive"
        Me.mnuNotActive.Text = "Show all records."
        '
        'lblMessage
        '
        Me.lblMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.lblMessage.ForeColor = System.Drawing.Color.Maroon
        Me.lblMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(987, 17)
        Me.lblMessage.Spring = True
        Me.lblMessage.Text = "To search for a record, use the filter panel on the top of this form."
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pbLoadingData
        '
        Me.pbLoadingData.MarqueeAnimationSpeed = 50
        Me.pbLoadingData.Name = "pbLoadingData"
        Me.pbLoadingData.Size = New System.Drawing.Size(150, 18)
        Me.pbLoadingData.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbLoadingData.Visible = False
        '
        'lblRecords
        '
        Me.lblRecords.Image = CType(resources.GetObject("lblRecords.Image"), System.Drawing.Image)
        Me.lblRecords.Name = "lblRecords"
        Me.lblRecords.Size = New System.Drawing.Size(62, 17)
        Me.lblRecords.Text = "records"
        '
        'bgReziseColumns
        '
        '
        'pnlButtons
        '
        Me.pnlButtons.BackColor = System.Drawing.Color.White
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.pnlButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSelect, Me.btnAdd, Me.btnCopy, Me.btnRefresh, Me.btnPrint, Me.btnClose})
        Me.pnlButtons.Location = New System.Drawing.Point(1180, 62)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(54, 561)
        Me.pnlButtons.TabIndex = 0
        '
        'btnSelect
        '
        Me.btnSelect.AutoSize = False
        Me.btnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSelect.Enabled = False
        Me.btnSelect.Image = CType(resources.GetObject("btnSelect.Image"), System.Drawing.Image)
        Me.btnSelect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSelect.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(53, 53)
        Me.btnSelect.Text = "select"
        Me.btnSelect.ToolTipText = "Select current record"
        '
        'btnAdd
        '
        Me.btnAdd.AutoSize = False
        Me.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(53, 53)
        Me.btnAdd.Text = "add"
        Me.btnAdd.ToolTipText = "Add new record." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT] + A"
        '
        'btnCopy
        '
        Me.btnCopy.AutoSize = False
        Me.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnCopy.Enabled = False
        Me.btnCopy.Image = CType(resources.GetObject("btnCopy.Image"), System.Drawing.Image)
        Me.btnCopy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(53, 53)
        Me.btnCopy.Text = "copy"
        Me.btnCopy.ToolTipText = "Copy selected record" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT] + C"
        '
        'btnRefresh
        '
        Me.btnRefresh.AutoSize = False
        Me.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(53, 53)
        Me.btnRefresh.Text = "refresh"
        Me.btnRefresh.ToolTipText = "Refresh data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT] + R"
        '
        'btnPrint
        '
        Me.btnPrint.AutoSize = False
        Me.btnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrint.Enabled = False
        Me.btnPrint.Image = CType(resources.GetObject("btnPrint.Image"), System.Drawing.Image)
        Me.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(53, 53)
        Me.btnPrint.Text = "print"
        Me.btnPrint.ToolTipText = "Print" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT] + P"
        '
        'btnClose
        '
        Me.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(51, 52)
        Me.btnClose.Text = "close"
        Me.btnClose.ToolTipText = "Close this form" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ESC]"
        '
        'grid
        '
        Me.grid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grid.BackColor = System.Drawing.Color.Transparent
        Me.grid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grid.Location = New System.Drawing.Point(0, 62)
        Me.grid.Margin = New System.Windows.Forms.Padding(0)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(1180, 561)
        Me.grid.TabIndex = 7
        '
        'FrmPrmpro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1234, 645)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.pnlButtons)
        Me.Controls.Add(Me.statusForm)
        Me.Controls.Add(Me.gbFilter)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1250, 684)
        Me.Name = "FrmPrmpro"
        Me.Padding = New System.Windows.Forms.Padding(0, 3, 0, 0)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPrmpro"
        Me.gbFilter.ResumeLayout(False)
        Me.gbFilter.PerformLayout()
        Me.statusForm.ResumeLayout(False)
        Me.statusForm.PerformLayout()
        Me.pnlButtons.ResumeLayout(False)
        Me.pnlButtons.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grid As iShowRoomComponents.gridTemplate
    Friend WithEvents gbFilter As GroupBox
    Friend WithEvents txtPrmpro As iShowRoomComponents.AlphaNumericUpper
    Friend WithEvents lblPrmpro As Label
    Friend WithEvents txtPrmsts As TextBox
    Friend WithEvents lblPrmsts As Label
    Friend WithEvents txtPrmcmp As TextBox
    Friend WithEvents lblPrmcmp As Label

    Friend WithEvents bgwLoadData As System.ComponentModel.BackgroundWorker
    Friend WithEvents statusForm As StatusStrip
    Friend WithEvents cbcActiveRecrods As ToolStripDropDownButton
    Friend WithEvents lblMessage As ToolStripStatusLabel
    Friend WithEvents pbLoadingData As ToolStripProgressBar
    Friend WithEvents lblRecords As ToolStripStatusLabel
    Friend WithEvents mnuActive As ToolStripMenuItem
    Friend WithEvents mnuNotActive As ToolStripMenuItem
    Friend WithEvents bgReziseColumns As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlButtons As ToolStrip
    Friend WithEvents btnAdd As ToolStripButton
    Friend WithEvents btnCopy As ToolStripButton
    Friend WithEvents btnRefresh As ToolStripButton
    Friend WithEvents btnPrint As ToolStripButton
    Friend WithEvents btnClear As LinkLabel
    Friend WithEvents btnSelect As ToolStripButton
    Friend WithEvents btnClose As ToolStripButton
    Private components As System.ComponentModel.IContainer
End Class
