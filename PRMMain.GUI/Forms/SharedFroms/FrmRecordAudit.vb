Public Class frmRecordAudit

    Private Sub frmRecordAudit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Me.Hide()
        e.Cancel = True

    End Sub


    Private Sub frmRecordAudit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If e.KeyChar = Chr(Keys.Escape) Then
            Me.Close()
        End If

    End Sub

    Private Sub frmRecordAudit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Me.Text = Me.Text.Trim & " (" & Me.Name.Trim & ")"

        If lblAddusr.Text = "" Then
            lblAddtim.Text = ""
            lblAdddat.Text = ""
        End If

        If lblChgusr.Text = "" Then
            lblChgtim.Text = ""
            lblChgdat.Text = ""
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub
End Class