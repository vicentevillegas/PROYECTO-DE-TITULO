<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmailOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtToEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboContacts = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCCEmail = New System.Windows.Forms.TextBox()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblMyEmail = New System.Windows.Forms.Label()
        Me.chbBCC = New System.Windows.Forms.CheckBox()
        Me.rtbBody = New System.Windows.Forms.RichTextBox()
        Me.grdSecusr = New iShowRoomComponents.gridTemplate()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chbJustMe = New System.Windows.Forms.CheckBox()
        Me.lblMyEmail2 = New System.Windows.Forms.Label()
        Me.lsvAttachments = New System.Windows.Forms.ListView()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtToEmail
        '
        Me.txtToEmail.Location = New System.Drawing.Point(58, 17)
        Me.txtToEmail.Name = "txtToEmail"
        Me.txtToEmail.Size = New System.Drawing.Size(377, 20)
        Me.txtToEmail.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "To:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Subject:"
        '
        'txtSubject
        '
        Me.txtSubject.Location = New System.Drawing.Point(58, 129)
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(377, 20)
        Me.txtSubject.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Body:"
        '
        'cboContacts
        '
        Me.cboContacts.FormattingEnabled = True
        Me.cboContacts.Location = New System.Drawing.Point(58, 66)
        Me.cboContacts.Name = "cboContacts"
        Me.cboContacts.Size = New System.Drawing.Size(377, 21)
        Me.cboContacts.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "CC:"
        '
        'txtCCEmail
        '
        Me.txtCCEmail.Location = New System.Drawing.Point(58, 103)
        Me.txtCCEmail.Name = "txtCCEmail"
        Me.txtCCEmail.Size = New System.Drawing.Size(377, 20)
        Me.txtCCEmail.TabIndex = 3
        '
        'btnSend
        '
        Me.btnSend.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSend.BackColor = System.Drawing.SystemColors.ButtonHighlight
        'Me.btnSend.Image = Global.iWarehouse.My.Resources.Resources.envelope
        Me.btnSend.Location = New System.Drawing.Point(6, 3)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(52, 57)
        Me.btnSend.TabIndex = 1
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.btnSend)
        Me.Panel1.Location = New System.Drawing.Point(1067, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(67, 134)
        Me.Panel1.TabIndex = 9
        '
        'lblMyEmail
        '
        Me.lblMyEmail.AutoSize = True
        Me.lblMyEmail.ForeColor = System.Drawing.Color.Blue
        Me.lblMyEmail.Location = New System.Drawing.Point(120, 43)
        Me.lblMyEmail.Name = "lblMyEmail"
        Me.lblMyEmail.Size = New System.Drawing.Size(52, 13)
        Me.lblMyEmail.TabIndex = 1
        Me.lblMyEmail.Text = "myEmail#"
        '
        'chbBCC
        '
        Me.chbBCC.AutoSize = True
        Me.chbBCC.Checked = True
        Me.chbBCC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chbBCC.Location = New System.Drawing.Point(58, 508)
        Me.chbBCC.Name = "chbBCC"
        Me.chbBCC.Size = New System.Drawing.Size(56, 17)
        Me.chbBCC.TabIndex = 6
        Me.chbBCC.Text = "BCC ?"
        Me.chbBCC.UseVisualStyleBackColor = True
        '
        'rtbBody
        '
        Me.rtbBody.Location = New System.Drawing.Point(58, 164)
        Me.rtbBody.Name = "rtbBody"
        Me.rtbBody.Size = New System.Drawing.Size(377, 338)
        Me.rtbBody.TabIndex = 5
        Me.rtbBody.Text = ""
        '
        'grdSecusr
        '
        Me.grdSecusr.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.grdSecusr.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSecusr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.grdSecusr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdSecusr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdSecusr.Location = New System.Drawing.Point(473, 17)
        Me.grdSecusr.Name = "grdSecusr"
        Me.grdSecusr.Size = New System.Drawing.Size(587, 282)
        Me.grdSecusr.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(450, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "CC:"
        '
        'chbJustMe
        '
        Me.chbJustMe.AutoSize = True
        Me.chbJustMe.Location = New System.Drawing.Point(58, 43)
        Me.chbJustMe.Name = "chbJustMe"
        Me.chbJustMe.Size = New System.Drawing.Size(63, 17)
        Me.chbJustMe.TabIndex = 1
        Me.chbJustMe.Text = "Just Me"
        Me.chbJustMe.UseVisualStyleBackColor = True
        '
        'lblMyEmail2
        '
        Me.lblMyEmail2.AutoSize = True
        Me.lblMyEmail2.ForeColor = System.Drawing.Color.Blue
        Me.lblMyEmail2.Location = New System.Drawing.Point(120, 508)
        Me.lblMyEmail2.Name = "lblMyEmail2"
        Me.lblMyEmail2.Size = New System.Drawing.Size(52, 13)
        Me.lblMyEmail2.TabIndex = 18
        Me.lblMyEmail2.Text = "myEmail#"
        '
        'lsvAttachments
        '
        Me.lsvAttachments.GridLines = True
        Me.lsvAttachments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lsvAttachments.Location = New System.Drawing.Point(473, 305)
        Me.lsvAttachments.Name = "lsvAttachments"
        Me.lsvAttachments.Size = New System.Drawing.Size(587, 197)
        Me.lsvAttachments.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lsvAttachments.TabIndex = 19
        Me.lsvAttachments.UseCompatibleStateImageBehavior = False
        Me.lsvAttachments.View = System.Windows.Forms.View.Details
        '
        'frmEmailOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1137, 528)
        Me.Controls.Add(Me.lsvAttachments)
        Me.Controls.Add(Me.lblMyEmail2)
        Me.Controls.Add(Me.chbJustMe)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.grdSecusr)
        Me.Controls.Add(Me.rtbBody)
        Me.Controls.Add(Me.chbBCC)
        Me.Controls.Add(Me.lblMyEmail)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCCEmail)
        Me.Controls.Add(Me.cboContacts)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtToEmail)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MaximizeBox = False
        Me.Name = "frmEmailOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtToEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSubject As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboContacts As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCCEmail As System.Windows.Forms.TextBox
    Friend WithEvents btnSend As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblMyEmail As System.Windows.Forms.Label
    Friend WithEvents chbBCC As System.Windows.Forms.CheckBox
    Friend WithEvents rtbBody As System.Windows.Forms.RichTextBox
    Friend WithEvents grdSecusr As iShowRoomComponents.gridTemplate
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chbJustMe As System.Windows.Forms.CheckBox
    Friend WithEvents lblMyEmail2 As System.Windows.Forms.Label
    Friend WithEvents lsvAttachments As System.Windows.Forms.ListView
End Class
