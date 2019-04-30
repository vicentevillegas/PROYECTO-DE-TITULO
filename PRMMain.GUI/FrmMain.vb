Imports System.Windows.Forms
Imports PRMMain.Model
Imports PRMMain.BLL

Public Class FrmMain

    Public Shared IsNetworkAvailable As Boolean
    Public Shared appName As String = "PRMMain"
    Public Shared thisLocation As String = "SEED"
    Public Shared SecusrBO As New SecusrBO
    Public Shared SoftwareVersion As String = "Version 1.00"
    Public Shared TestEnviroment As Boolean = False


    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim _thisUser As String = GenfunBLL.GetUserID(" ").Trim

        LoadWindowPosition()
        Me.Text = $"TJMMain - {SoftwareVersion} - [{SecusrBO.secusr.ToUpper}]"

        ToolStripStatusLabel.Text = "Ready."

        If TestEnviroment Then

            Me.Text &= " *** TEST ENVIROMENT ***"
            ToolStripStatusLabel.Text = $"Ready in test mode."

        End If

        'SecusrBO.secapp = appName.Trim
        'SecusrBO.secusr = _thisUser.Trim

        'SecusrBO = secusrbll

    End Sub

#Region "    Toolbar & Menu tools Click Event    "

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click

        Dim f As New AboutBox1
        f.ShowInTaskbar = False
        f.ShowDialog()

    End Sub


#End Region

#Region "    Form Events & Subs    "

    Private Sub FrmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        My.Settings.WindowLocation = Me.Location
        My.Settings.WindowSize = Me.Size
        My.Settings.Save()

    End Sub

    Public Sub SetConnectionStatus(ByVal status As Boolean)

        IsNetworkAvailable = status

        If IsNetworkAvailable Then
            ToolStripNetworkLabel.Image = My.Resources.networkonline16
            ToolStripStatusLabel.Text = "Available network."
        Else
            ToolStripNetworkLabel.Image = My.Resources.networkoffline16
            ToolStripStatusLabel.Text = "Network not available."
        End If

    End Sub

    Public Sub SetDatabaseStatus(ByVal db As String)

        ToolStripDatabaseLabel.Text = db.Trim.ToUpper

        If db.Trim.ToUpper = "IAG" Or db.Trim.ToUpper = "STG" Then

            MenuStrip.BackColor = Color.Orange
            ToolTip.BackColor = Color.Orange
            TestEnviroment = True

        End If

    End Sub

    Private Sub FrmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize

        Me.Refresh()

    End Sub

    Private Sub LoadWindowPosition()

        Dim ptLocation As System.Drawing.Point = My.Settings.WindowLocation

        If ptLocation.X = -1 And ptLocation.Y = -1 Then
            Return
        End If

        Dim bLocationVisible As Boolean = False

        For Each S As Screen In Screen.AllScreens
            If S.Bounds.Contains(ptLocation) Then
                bLocationVisible = True
                Exit For
            End If
        Next

        If Not bLocationVisible Then
            Return
        End If

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = ptLocation
        Me.Size = My.Settings.WindowSize

    End Sub

    Private Sub PrintToolStripButton_Click(sender As Object, e As EventArgs) Handles PrintToolStripButton.Click
        SetConnectionStatus(True)
    End Sub

    Private Sub NewToolStripButton_Click(sender As Object, e As EventArgs) Handles NewToolStripButton.Click
        SetConnectionStatus(False)
    End Sub

#End Region

#Region "    Main Menu item click events Subs    "

    '
	'GetCodeForMaintainersMenuItem_Click
	'
	Private Sub MenuItemPrmcmpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItemPrmcmpToolStripMenuItem.Click

		For Each f As Form In Application.OpenForms

			If TypeOf f Is FrmPrmcmp Then

				f.Activate()
				Return

			End If

		Next

		Dim _frmPrmcmp As New FrmPrmcmp
		_frmPrmcmp.maxiumRecorsLocally = My.Settings.MaxRecordsFilter
		_frmPrmcmp.MdiParent = Me
		_frmPrmcmp.Show()

	End Sub

	Private Sub MenuItemPrmproToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItemPrmproToolStripMenuItem.Click

		For Each f As Form In Application.OpenForms

			If TypeOf f Is FrmPrmpro Then

				f.Activate()
				Return

			End If

		Next

		Dim _frmPrmpro As New FrmPrmpro
		_frmPrmpro.maxiumRecorsLocally = My.Settings.MaxRecordsFilter
		_frmPrmpro.MdiParent = Me
		_frmPrmpro.Show()

	End Sub

	Private Sub MenuItemPrmregToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItemPrmregToolStripMenuItem.Click

		For Each f As Form In Application.OpenForms

			If TypeOf f Is FrmPrmreg Then

				f.Activate()
				Return

			End If

		Next

		Dim _frmPrmreg As New FrmPrmreg
		_frmPrmreg.maxiumRecorsLocally = My.Settings.MaxRecordsFilter
		_frmPrmreg.MdiParent = Me
		_frmPrmreg.Show()

	End Sub

	Private Sub MenuItemPrmstsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItemPrmstsToolStripMenuItem.Click

        'For Each f As Form In Application.OpenForms

        '	If TypeOf f Is FrmPrmsts Then

        '		f.Activate()
        '		Return

        '	End If

        'Next

        'Dim _frmPrmsts As New FrmPrmsts
        '_frmPrmsts.maxiumRecorsLocally = My.Settings.MaxRecordsFilter
        '_frmPrmsts.MdiParent = Me
        '_frmPrmsts.Show()

    End Sub

	Private Sub MenuItemPrmuserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItemPrmuserToolStripMenuItem.Click

		For Each f As Form In Application.OpenForms

			If TypeOf f Is FrmPrmuser Then

				f.Activate()
				Return

			End If

		Next

		Dim _frmPrmuser As New FrmPrmuser
		_frmPrmuser.maxiumRecorsLocally = My.Settings.MaxRecordsFilter
		_frmPrmuser.MdiParent = Me
		_frmPrmuser.Show()

	End Sub

	'
	'End Code.
	'

#End Region

End Class
