<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPrmreg01

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrmreg01))
        Me.ToolStripButtons = New System.Windows.Forms.ToolStrip()
        Me.btnSave = New System.Windows.Forms.ToolStripButton()
        Me.btnAudit = New System.Windows.Forms.ToolStripButton()
        Me.btnReset = New System.Windows.Forms.ToolStripButton()
        Me.btnClose = New System.Windows.Forms.ToolStripButton()
        Me.grpNotes = New System.Windows.Forms.GroupBox()
        Me.btnDate = New System.Windows.Forms.Button()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.grpActive = New System.Windows.Forms.GroupBox()
        Me.rdbActiveNo = New System.Windows.Forms.RadioButton()
        Me.rdbActiveYes = New System.Windows.Forms.RadioButton()
        Me.loadProgress = New System.Windows.Forms.ToolStripProgressBar()
        		Me.txtWknum = New iShowRoomComponents.AlphaNumericUpper()
		Me.lblWknum = New System.Windows.Forms.Label()
		Me.txtPrmpro = New iShowRoomComponents.AlphaNumericUpper()
		Me.lblPrmpro = New System.Windows.Forms.Label()
		Me.txtPrmuser = New iShowRoomComponents.AlphaNumericUpper()
		Me.lblPrmuser = New System.Windows.Forms.Label()
		Me.dteStrdate = New System.Windows.Forms.DateTimePicker()
		Me.lblStrdate = New System.Windows.Forms.Label()
		Me.txtWrkhrs = New System.Windows.Forms.TextBox()
		Me.lblWrkhrs = New System.Windows.Forms.Label()

        Me.ToolStripButtons.SuspendLayout()
        Me.grpNotes.SuspendLayout()
        Me.grpActive.SuspendLayout()
        Me.SuspendLayout()
        		'
		'txtWknum
		'
		Me.txtWknum.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
		Me.txtWknum.ForeColor = System.Drawing.Color.Navy
		Me.txtWknum.Location = New System.Drawing.Point(127, 20)
		Me.txtWknum.MaxLength = 20
		Me.txtWknum.Name = "txtWknum"
		Me.txtWknum.Size = New System.Drawing.Size(250, 20)
		Me.txtWknum.TabIndex = 1
		'
		'lblWknum
		'
		Me.lblWknum.AutoSize = True
		lblWknum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		lblWknum.Location = New System.Drawing.Point(8, 20)
		lblWknum.Name = "lblWknum"
		lblWknum.Size = New System.Drawing.Size(110, 13)
		lblWknum.TabIndex = 0
		lblWknum.Text = "Week Number:"
		'
		'cboPrmpro
		'
		Me.cboPrmpro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cboPrmpro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cboPrmpro.Location = New System.Drawing.Point(127, 44)
		Me.cboPrmpro.FormattingEnabled = True
		Me.cboPrmpro.Name = "txtPrmpro"
		Me.cboPrmpro.Size = New System.Drawing.Size(250, 20)
		Me.cboPrmpro.TabIndex = 2
		'
		'lblPrmpro
		'
		Me.lblPrmpro.AutoSize = True
		lblPrmpro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		lblPrmpro.Location = New System.Drawing.Point(8, 44)
		lblPrmpro.Name = "lblPrmpro"
		lblPrmpro.Size = New System.Drawing.Size(110, 13)
		lblPrmpro.TabIndex = 0
		lblPrmpro.Text = "Prmpro:"
		'
		'cboPrmuser
		'
		Me.cboPrmuser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
		Me.cboPrmuser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
		Me.cboPrmuser.Location = New System.Drawing.Point(127, 68)
		Me.cboPrmuser.FormattingEnabled = True
		Me.cboPrmuser.Name = "txtPrmuser"
		Me.cboPrmuser.Size = New System.Drawing.Size(250, 20)
		Me.cboPrmuser.TabIndex = 3
		'
		'lblPrmuser
		'
		Me.lblPrmuser.AutoSize = True
		lblPrmuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		lblPrmuser.Location = New System.Drawing.Point(8, 68)
		lblPrmuser.Name = "lblPrmuser"
		lblPrmuser.Size = New System.Drawing.Size(110, 13)
		lblPrmuser.TabIndex = 0
		lblPrmuser.Text = "Prmuser:"
		'
		'dteStrdate
		'
		Me.dteStrdate.CustomFormat = "dd MMM yyyy"
		Me.dteStrdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.dteStrdate.Location = New System.Drawing.Point(127, 92)
		Me.dteStrdate.Name = "dteStrdate"
		Me.dteStrdate.Size = New System.Drawing.Size(250, 20)
		Me.dteStrdate.TabIndex = 4
		'
		'lblStrdate
		'
		Me.lblStrdate.AutoSize = True
		lblStrdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		lblStrdate.Location = New System.Drawing.Point(8, 92)
		lblStrdate.Name = "lblStrdate"
		lblStrdate.Size = New System.Drawing.Size(110, 13)
		lblStrdate.TabIndex = 0
		lblStrdate.Text = "Start Date:"
		'
		'txtWrkhrs
		'
		Me.txtWrkhrs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
		Me.txtWrkhrs.ForeColor = System.Drawing.Color.Navy
		Me.txtWrkhrs.Location = New System.Drawing.Point(127, 116)
		Me.txtWrkhrs.MaxLength = 4
		Me.txtWrkhrs.Name = "txtWrkhrs"
		Me.txtWrkhrs.Size = New System.Drawing.Size(250, 20)
		Me.txtWrkhrs.TabIndex = 5
		'
		'lblWrkhrs
		'
		Me.lblWrkhrs.AutoSize = True
		lblWrkhrs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		lblWrkhrs.Location = New System.Drawing.Point(8, 116)
		lblWrkhrs.Name = "lblWrkhrs"
		lblWrkhrs.Size = New System.Drawing.Size(110, 13)
		lblWrkhrs.TabIndex = 0
		lblWrkhrs.Text = "Work Hours:"

        '
        'ToolStripButtons
        '
        Me.ToolStripButtons.BackColor = System.Drawing.Color.White
        Me.ToolStripButtons.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnReset, Me.btnClose, Me.btnAudit, Me.loadProgress})
        Me.ToolStripButtons.Location = New System.Drawing.Point(927, 0)
        Me.ToolStripButtons.Name = "ToolStripButtons"
        Me.ToolStripButtons.Size = New System.Drawing.Size(61, 540)
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
        Me.grpNotes.Location = New System.Drawing.Point(440, 11)
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
        Me.btnDate.TabIndex = 200
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
        Me.txtNotes.TabIndex = 201
        '
        'grpActive
        '
        Me.grpActive.Controls.Add(Me.rdbActiveNo)
        Me.grpActive.Controls.Add(Me.rdbActiveYes)
        Me.grpActive.Location = New System.Drawing.Point(440, 141)
        Me.grpActive.Margin = New System.Windows.Forms.Padding(2)
        Me.grpActive.MinimumSize = New System.Drawing.Size(143, 46)
        Me.grpActive.Name = "grpActive"
        Me.grpActive.Padding = New System.Windows.Forms.Padding(2)
        Me.grpActive.Size = New System.Drawing.Size(293, 46)
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
        'FrmPrmreg01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(988, 540)
        Me.Controls.Add(Me.grpActive)
        Me.Controls.Add(Me.grpNotes)
        Me.Controls.Add(Me.ToolStripButtons)
        		Me.Controls.Add(Me.txtWknum)
		Me.Controls.Add(Me.lblWknum)
		Me.Controls.Add(Me.cboPrmpro)
		Me.Controls.Add(Me.lblPrmpro)
		Me.Controls.Add(Me.cboPrmuser)
		Me.Controls.Add(Me.lblPrmuser)
		Me.Controls.Add(Me.dteStrdate)
		Me.Controls.Add(Me.lblStrdate)
		Me.Controls.Add(Me.txtWrkhrs)
		Me.Controls.Add(Me.lblWrkhrs)

        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(520, 367)
        Me.Name = "FrmPrmreg01"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ToolStripButtons.ResumeLayout(False)
        Me.ToolStripButtons.PerformLayout()
        Me.grpNotes.ResumeLayout(False)
        Me.grpNotes.PerformLayout()
        Me.grpActive.ResumeLayout(False)
        Me.grpActive.PerformLayout()
        Me.ResumeLayout(False)

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
    Friend WithEvents txtWknum As iShowRoomComponents.AlphaNumericUpper
    Friend WithEvents cboPrmpro As ComboBox
    Friend WithEvents cboPrmuser As ComboBox
    Friend WithEvents lblWknum As Label
	Friend WithEvents txtPrmpro As iShowRoomComponents.AlphaNumericUpper
	Friend WithEvents lblPrmpro As Label
	Friend WithEvents txtPrmuser As iShowRoomComponents.AlphaNumericUpper
	Friend WithEvents lblPrmuser As Label
	Friend WithEvents dteStrdate As DateTimePicker
	Friend WithEvents lblStrdate As Label
	Friend WithEvents txtWrkhrs As TextBox
	Friend WithEvents lblWrkhrs As Label

End Class
