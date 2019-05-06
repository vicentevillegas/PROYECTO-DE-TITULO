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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrmreg01))
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
        Me.cboPrmpro = New System.Windows.Forms.ComboBox()
        Me.cboPrmuser = New System.Windows.Forms.ComboBox()
        Me.txtWknum = New iShowRoomComponents.AlphaNumericUpper(Me.components)
        Me.lblWknum = New System.Windows.Forms.Label()
        Me.txtPrmpro = New iShowRoomComponents.AlphaNumericUpper(Me.components)
        Me.lblPrmpro = New System.Windows.Forms.Label()
        Me.txtPrmuser = New iShowRoomComponents.AlphaNumericUpper(Me.components)
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
        'ToolStripButtons
        '
        Me.ToolStripButtons.BackColor = System.Drawing.Color.White
        Me.ToolStripButtons.Dock = System.Windows.Forms.DockStyle.Right
        Me.ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.btnReset, Me.btnClose, Me.btnAudit, Me.loadProgress})
        Me.ToolStripButtons.Location = New System.Drawing.Point(783, 0)
        Me.ToolStripButtons.Name = "ToolStripButtons"
        Me.ToolStripButtons.Size = New System.Drawing.Size(61, 211)
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
        Me.grpNotes.Location = New System.Drawing.Point(382, 9)
        Me.grpNotes.Margin = New System.Windows.Forms.Padding(2)
        Me.grpNotes.MinimumSize = New System.Drawing.Size(293, 126)
        Me.grpNotes.Name = "grpNotes"
        Me.grpNotes.Padding = New System.Windows.Forms.Padding(2)
        Me.grpNotes.Size = New System.Drawing.Size(361, 126)
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
        Me.txtNotes.Size = New System.Drawing.Size(255, 93)
        Me.txtNotes.TabIndex = 201
        '
        'grpActive
        '
        Me.grpActive.Controls.Add(Me.rdbActiveNo)
        Me.grpActive.Controls.Add(Me.rdbActiveYes)
        Me.grpActive.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.grpActive.Location = New System.Drawing.Point(0, 165)
        Me.grpActive.Margin = New System.Windows.Forms.Padding(2)
        Me.grpActive.MinimumSize = New System.Drawing.Size(143, 46)
        Me.grpActive.Name = "grpActive"
        Me.grpActive.Padding = New System.Windows.Forms.Padding(2)
        Me.grpActive.Size = New System.Drawing.Size(783, 46)
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
        'cboPrmpro
        '
        Me.cboPrmpro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPrmpro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPrmpro.FormattingEnabled = True
        Me.cboPrmpro.Location = New System.Drawing.Point(127, 44)
        Me.cboPrmpro.Name = "cboPrmpro"
        Me.cboPrmpro.Size = New System.Drawing.Size(250, 21)
        Me.cboPrmpro.TabIndex = 2
        '
        'cboPrmuser
        '
        Me.cboPrmuser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPrmuser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPrmuser.FormattingEnabled = True
        Me.cboPrmuser.Location = New System.Drawing.Point(127, 68)
        Me.cboPrmuser.Name = "cboPrmuser"
        Me.cboPrmuser.Size = New System.Drawing.Size(250, 21)
        Me.cboPrmuser.TabIndex = 3
        '
        'txtWknum
        '
        Me.txtWknum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
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
        Me.lblWknum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWknum.Location = New System.Drawing.Point(35, 27)
        Me.lblWknum.Name = "lblWknum"
        Me.lblWknum.Size = New System.Drawing.Size(91, 13)
        Me.lblWknum.TabIndex = 0
        Me.lblWknum.Text = "Week Number:"
        '
        'txtPrmpro
        '
        Me.txtPrmpro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrmpro.Location = New System.Drawing.Point(0, 0)
        Me.txtPrmpro.Name = "txtPrmpro"
        Me.txtPrmpro.Size = New System.Drawing.Size(100, 20)
        Me.txtPrmpro.TabIndex = 0
        '
        'lblPrmpro
        '
        Me.lblPrmpro.AutoSize = True
        Me.lblPrmpro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrmpro.Location = New System.Drawing.Point(75, 52)
        Me.lblPrmpro.Name = "lblPrmpro"
        Me.lblPrmpro.Size = New System.Drawing.Size(51, 13)
        Me.lblPrmpro.TabIndex = 0
        Me.lblPrmpro.Text = "Project:"
        '
        'txtPrmuser
        '
        Me.txtPrmuser.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPrmuser.Location = New System.Drawing.Point(0, 0)
        Me.txtPrmuser.Name = "txtPrmuser"
        Me.txtPrmuser.Size = New System.Drawing.Size(100, 20)
        Me.txtPrmuser.TabIndex = 0
        '
        'lblPrmuser
        '
        Me.lblPrmuser.AutoSize = True
        Me.lblPrmuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrmuser.Location = New System.Drawing.Point(88, 74)
        Me.lblPrmuser.Name = "lblPrmuser"
        Me.lblPrmuser.Size = New System.Drawing.Size(37, 13)
        Me.lblPrmuser.TabIndex = 0
        Me.lblPrmuser.Text = "User:"
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
        Me.lblStrdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStrdate.Location = New System.Drawing.Point(67, 99)
        Me.lblStrdate.Name = "lblStrdate"
        Me.lblStrdate.Size = New System.Drawing.Size(58, 13)
        Me.lblStrdate.TabIndex = 0
        Me.lblStrdate.Text = "Start Date:"
        '
        'txtWrkhrs
        '
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
        Me.lblWrkhrs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWrkhrs.Location = New System.Drawing.Point(58, 123)
        Me.lblWrkhrs.Name = "lblWrkhrs"
        Me.lblWrkhrs.Size = New System.Drawing.Size(67, 13)
        Me.lblWrkhrs.TabIndex = 0
        Me.lblWrkhrs.Text = "Work Hours:"
        '
        'FrmPrmreg01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(844, 211)
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
        Me.Name = "FrmPrmreg01"
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
    Private components As System.ComponentModel.IContainer
End Class
