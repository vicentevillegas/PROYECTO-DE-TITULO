<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrmpro01

    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrmpro01))
        Me.ToolStripButtons = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnReset = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.btnAudit = New System.Windows.Forms.ToolStripButton()
        Me.loadProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.grpNotes = New System.Windows.Forms.GroupBox()
        Me.btnDate = New System.Windows.Forms.Button()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.grpActive = New System.Windows.Forms.GroupBox()
        Me.rdbActiveNo = New System.Windows.Forms.RadioButton()
        Me.rdbActiveYes = New System.Windows.Forms.RadioButton()
        Me.txtPrmpro = New iShowRoomComponents.AlphaNumericUpper(Me.components)
        Me.lblPrmpro = New System.Windows.Forms.Label()
        Me.cboPrmsts = New System.Windows.Forms.ComboBox()
        Me.lblPrmsts = New System.Windows.Forms.Label()
        Me.cboPrmcmp = New System.Windows.Forms.ComboBox()
        Me.lblPrmcmp = New System.Windows.Forms.Label()
        Me.dteStrdte = New System.Windows.Forms.DateTimePicker()
        Me.lblStrdte = New System.Windows.Forms.Label()
        Me.txtDescr = New System.Windows.Forms.TextBox()
        Me.lblDescr = New System.Windows.Forms.Label()
        Me.ToolStripButtons.SuspendLayout()
        Me.grpNotes.SuspendLayout()
        Me.grpActive.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripButtons
        '
        Me.ToolStripButtons.BackColor = System.Drawing.Color.White
        Me.ToolStripButtons.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnReset, Me.btnClose, Me.btnAudit, Me.loadProgress})
        Me.ToolStripButtons.Location = New System.Drawing.Point(725, 0)
        Me.ToolStripButtons.Name = "ToolStripButtons"
        Me.ToolStripButtons.Size = New System.Drawing.Size(61, 220)
        Me.ToolStripButtons.TabIndex = 0
        Me.ToolStripButtons.Text = "ToolStrip1"
        '
        'btnSave
        '
        Me.btnSave.AutoSize = False
        Me.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(55, 55)
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnSave.ToolTipText = "Save record" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT] + S"
        '
        'btnReset
        '
        Me.btnReset.AutoSize = False
        Me.btnReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnReset.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(55, 55)
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnReset.ToolTipText = "Reset values to default" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ALT] + R"
        '
        'btnClose
        '
        Me.btnClose.AutoSize = False
        Me.btnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(55, 55)
        Me.btnClose.Text = "Close"
        Me.btnClose.ToolTipText = "Close this form whitout saving" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[ESC]"
        '
        'btnAudit
        '
        Me.btnAudit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnAudit.AutoSize = False
        Me.btnAudit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnAudit.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAudit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAudit.Image = CType(resources.GetObject("btnAudit.Image"), System.Drawing.Image)
        Me.btnAudit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAudit.Name = "btnAudit"
        Me.btnAudit.Size = New System.Drawing.Size(60, 30)
        Me.btnAudit.Text = "Audit data"
        '
        'loadProgress
        '
        Me.loadProgress.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.loadProgress.Name = "loadProgress"
        Me.loadProgress.Size = New System.Drawing.Size(56, 30)
        Me.loadProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.loadProgress.Visible = False
        '
        'grpNotes
        '
        Me.grpNotes.Controls.Add(Me.btnDate)
        Me.grpNotes.Controls.Add(Me.txtNotes)
        Me.grpNotes.Location = New System.Drawing.Point(382, 20)
        Me.grpNotes.Margin = New System.Windows.Forms.Padding(2)
        Me.grpNotes.MinimumSize = New System.Drawing.Size(293, 126)
        Me.grpNotes.Name = "grpNotes"
        Me.grpNotes.Padding = New System.Windows.Forms.Padding(2)
        Me.grpNotes.Size = New System.Drawing.Size(293, 126)
        Me.grpNotes.TabIndex = 6
        Me.grpNotes.TabStop = False
        Me.grpNotes.Text = "Notes:"
        '
        'btnDate
        '
        Me.btnDate.BackColor = System.Drawing.Color.White
        Me.btnDate.Image = CType(resources.GetObject("btnDate.Image"), System.Drawing.Image)
        Me.btnDate.Location = New System.Drawing.Point(29, 18)
        Me.btnDate.Name = "btnDate"
        Me.btnDate.Size = New System.Drawing.Size(60, 60)
        Me.btnDate.TabIndex = 6
        Me.btnDate.Text = "To stamp"
        Me.btnDate.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.btnDate.UseVisualStyleBackColor = False
        '
        'txtNotes
        '
        Me.txtNotes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNotes.Location = New System.Drawing.Point(94, 17)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(2)
        Me.txtNotes.MaxLength = 500
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotes.Size = New System.Drawing.Size(187, 93)
        Me.txtNotes.TabIndex = 7
        '
        'grpActive
        '
        Me.grpActive.Controls.Add(Me.rdbActiveNo)
        Me.grpActive.Controls.Add(Me.rdbActiveYes)
        Me.grpActive.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpActive.Location = New System.Drawing.Point(0, 174)
        Me.grpActive.Margin = New System.Windows.Forms.Padding(2)
        Me.grpActive.MinimumSize = New System.Drawing.Size(143, 46)
        Me.grpActive.Name = "grpActive"
        Me.grpActive.Padding = New System.Windows.Forms.Padding(2)
        Me.grpActive.Size = New System.Drawing.Size(725, 46)
        Me.grpActive.TabIndex = 9
        Me.grpActive.TabStop = False
        Me.grpActive.Text = "Active:"
        '
        'rdbActiveNo
        '
        Me.rdbActiveNo.AutoSize = True
        Me.rdbActiveNo.Location = New System.Drawing.Point(89, 17)
        Me.rdbActiveNo.Margin = New System.Windows.Forms.Padding(2)
        Me.rdbActiveNo.Name = "rdbActiveNo"
        Me.rdbActiveNo.Size = New System.Drawing.Size(39, 17)
        Me.rdbActiveNo.TabIndex = 10
        Me.rdbActiveNo.TabStop = True
        Me.rdbActiveNo.Text = "No"
        Me.rdbActiveNo.UseVisualStyleBackColor = True
        '
        'rdbActiveYes
        '
        Me.rdbActiveYes.AutoSize = True
        Me.rdbActiveYes.Location = New System.Drawing.Point(29, 17)
        Me.rdbActiveYes.Margin = New System.Windows.Forms.Padding(2)
        Me.rdbActiveYes.Name = "rdbActiveYes"
        Me.rdbActiveYes.Size = New System.Drawing.Size(43, 17)
        Me.rdbActiveYes.TabIndex = 9
        Me.rdbActiveYes.TabStop = True
        Me.rdbActiveYes.Text = "Yes"
        Me.rdbActiveYes.UseVisualStyleBackColor = True
        '
        'txtPrmpro
        '
        Me.txtPrmpro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrmpro.ForeColor = System.Drawing.Color.Navy
        Me.txtPrmpro.Location = New System.Drawing.Point(127, 20)
        Me.txtPrmpro.MaxLength = 20
        Me.txtPrmpro.Name = "txtPrmpro"
        Me.txtPrmpro.Size = New System.Drawing.Size(250, 20)
        Me.txtPrmpro.TabIndex = 1
        '
        'lblPrmpro
        '
        Me.lblPrmpro.AutoSize = True
        Me.lblPrmpro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrmpro.Location = New System.Drawing.Point(55, 27)
        Me.lblPrmpro.Name = "lblPrmpro"
        Me.lblPrmpro.Size = New System.Drawing.Size(66, 13)
        Me.lblPrmpro.TabIndex = 0
        Me.lblPrmpro.Text = "Project Id:"
        '
        'cboPrmsts
        '
        Me.cboPrmsts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPrmsts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPrmsts.FormattingEnabled = True
        Me.cboPrmsts.Location = New System.Drawing.Point(127, 98)
        Me.cboPrmsts.Name = "cboPrmsts"
        Me.cboPrmsts.Size = New System.Drawing.Size(250, 21)
        Me.cboPrmsts.TabIndex = 4
        '
        'lblPrmsts
        '
        Me.lblPrmsts.AutoSize = True
        Me.lblPrmsts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrmsts.Location = New System.Drawing.Point(81, 101)
        Me.lblPrmsts.Name = "lblPrmsts"
        Me.lblPrmsts.Size = New System.Drawing.Size(40, 13)
        Me.lblPrmsts.TabIndex = 0
        Me.lblPrmsts.Text = "Status:"
        '
        'cboPrmcmp
        '
        Me.cboPrmcmp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPrmcmp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPrmcmp.FormattingEnabled = True
        Me.cboPrmcmp.Location = New System.Drawing.Point(127, 125)
        Me.cboPrmcmp.Name = "cboPrmcmp"
        Me.cboPrmcmp.Size = New System.Drawing.Size(250, 21)
        Me.cboPrmcmp.TabIndex = 5
        '
        'lblPrmcmp
        '
        Me.lblPrmcmp.AutoSize = True
        Me.lblPrmcmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrmcmp.Location = New System.Drawing.Point(67, 128)
        Me.lblPrmcmp.Name = "lblPrmcmp"
        Me.lblPrmcmp.Size = New System.Drawing.Size(54, 13)
        Me.lblPrmcmp.TabIndex = 0
        Me.lblPrmcmp.Text = "Company:"
        '
        'dteStrdte
        '
        Me.dteStrdte.CustomFormat = "dd MMM yyyy"
        Me.dteStrdte.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dteStrdte.Location = New System.Drawing.Point(127, 72)
        Me.dteStrdte.Name = "dteStrdte"
        Me.dteStrdte.Size = New System.Drawing.Size(250, 20)
        Me.dteStrdte.TabIndex = 3
        '
        'lblStrdte
        '
        Me.lblStrdte.AutoSize = True
        Me.lblStrdte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStrdte.Location = New System.Drawing.Point(63, 78)
        Me.lblStrdte.Name = "lblStrdte"
        Me.lblStrdte.Size = New System.Drawing.Size(58, 13)
        Me.lblStrdte.TabIndex = 0
        Me.lblStrdte.Text = "Start Date:"
        '
        'txtDescr
        '
        Me.txtDescr.ForeColor = System.Drawing.Color.Navy
        Me.txtDescr.Location = New System.Drawing.Point(127, 46)
        Me.txtDescr.MaxLength = 100
        Me.txtDescr.Name = "txtDescr"
        Me.txtDescr.Size = New System.Drawing.Size(250, 20)
        Me.txtDescr.TabIndex = 2
        '
        'lblDescr
        '
        Me.lblDescr.AutoSize = True
        Me.lblDescr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescr.Location = New System.Drawing.Point(58, 53)
        Me.lblDescr.Name = "lblDescr"
        Me.lblDescr.Size = New System.Drawing.Size(63, 13)
        Me.lblDescr.TabIndex = 0
        Me.lblDescr.Text = "Description:"
        '
        'FrmPrmpro01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(786, 220)
        Me.Controls.Add(Me.grpActive)
        Me.Controls.Add(Me.grpNotes)
        Me.Controls.Add(Me.ToolStripButtons)
        Me.Controls.Add(Me.txtPrmpro)
        Me.Controls.Add(Me.lblPrmpro)
        Me.Controls.Add(Me.cboPrmsts)
        Me.Controls.Add(Me.lblPrmsts)
        Me.Controls.Add(Me.cboPrmcmp)
        Me.Controls.Add(Me.lblPrmcmp)
        Me.Controls.Add(Me.dteStrdte)
        Me.Controls.Add(Me.lblStrdte)
        Me.Controls.Add(Me.txtDescr)
        Me.Controls.Add(Me.lblDescr)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FrmPrmpro01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ToolStripButtons.ResumeLayout(False)
        Me.ToolStripButtons.PerformLayout()
        Me.grpNotes.ResumeLayout(False)
        Me.grpNotes.PerformLayout()
        Me.grpActive.ResumeLayout(False)
        Me.grpActive.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripButtons As ToolStrip
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnAudit As ToolStripButton
    Friend WithEvents btnReset As ToolStripButton
    Friend WithEvents btnClose As ToolStripButton
    Friend WithEvents loadProgress As ToolStripProgressBar
    Friend WithEvents grpNotes As GroupBox
    Friend WithEvents btnDate As Button
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents grpActive As GroupBox
    Friend WithEvents rdbActiveNo As RadioButton
    Friend WithEvents rdbActiveYes As RadioButton
    	Friend WithEvents txtPrmpro As iShowRoomComponents.AlphaNumericUpper
	Friend WithEvents lblPrmpro As Label
	Friend WithEvents cboPrmsts As ComboBox
	Friend WithEvents lblPrmsts As Label
	Friend WithEvents cboPrmcmp As ComboBox
	Friend WithEvents lblPrmcmp As Label
	Friend WithEvents dteStrdte As DateTimePicker
	Friend WithEvents lblStrdte As Label
	Friend WithEvents txtDescr As TextBox
	Friend WithEvents lblDescr As Label

End Class
