Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports PRMMain.GenFun

Public Class frmReport

    Public reportDescription As String = ""
    Public meTitle As String
    Public toEmail As ArrayList
    Public toCC As ArrayList
    Public toBCC As ArrayList
    Public mailBody As String
    Public currentReport As New ReportDocument
    Public reportClient As String = ""
    Private myAttachments As New List(Of emailAttachment)
    Public Shared emailSent As Boolean = False
    Private mySignature As Object
    Public noEmail As Boolean = False
    Public wasDone As Boolean = False

    Public Sub Email(ByVal exportFile As ArrayList, ByVal directory As String)

        Dim sessionName As String = Environment.GetEnvironmentVariable("SessionName")
        Dim clientName As String = Environment.GetEnvironmentVariable("ClientName")
        Dim computerName As String = Environment.GetEnvironmentVariable("ComputerName")
        Dim serverName As String = ""

        Dim emailOptions As New frmEmailOptions
        If toEmail Is Nothing Then
            emailOptions.myToEmail = ""
        Else
            'emailOptions.myToEmail = iShowroom.refToGenfun.arrayListToDelimString(toEmail, ";")
        End If

        emailOptions.mySubject = "Holland & Sherry - " & reportDescription.Trim

        emailOptions.myClient = ""
        If Not reportClient Is Nothing Then
            emailOptions.myClient = reportClient
        End If

        emailOptions.myToEmailSelected = ""
        emailOptions.myCCEmail = ""
        emailOptions.myBCCEmail = ""
        emailOptions.myBody = ""
        emailOptions.attachMents = myAttachments
        emailOptions.ShowDialog()

        If emailOptions.cancelSelected Then

            Try
                emailOptions.Dispose()
            Catch ex As Exception
            End Try

            Exit Sub

        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            Dim SmtpServer As New SmtpClient()

            'SmtpServer.UseDefaultCredentials = False
            'Dim mailCredentials As New Net.NetworkCredential
            'mailCredentials.UserName = "email@hollandandsherry.com"
            'mailCredentials.Password = "1Sh0wr00m"
            ''SmtpServer.Credentials = New Net.NetworkCredential("email@hollandandsherry.com", "1Sh0wr00m")
            'SmtpServer.Credentials = mailCredentials
            'SmtpServer.Port = 4025
            'SmtpServer.Host = "mail.tjmmail.com"
            ''     SmtpServer.EnableSsl = True
            'SmtpServer.EnableSsl = False

            SmtpServer.UseDefaultCredentials = False
            Dim mailCredentials As New Net.NetworkCredential
            mailCredentials.UserName = "ishowroom@hollandandsherry.com"
            mailCredentials.Password = "1Sh0wr00m"
            'SmtpServer.Credentials = New Net.NetworkCredential("email@hollandandsherry.com", "1Sh0wr00m")
            SmtpServer.Credentials = mailCredentials
            SmtpServer.Port = 8025
            SmtpServer.Host = "smtp.emailsrvr.com"
            '     SmtpServer.EnableSsl = True
            SmtpServer.EnableSsl = False

            Dim omail As New MailMessage()


            'omail.From = New MailAddress(iShowroom.iUserEmail01.Trim, iShowroom.iUserName.Trim, System.Text.Encoding.UTF8)

            omail.Subject = emailOptions.mySubject

            If emailOptions.myToEmail.Trim <> "" Then
                omail.To.Add(emailOptions.myToEmail)
            End If

            If emailOptions.myToEmailSelected.Trim <> "" Then
                omail.To.Add(emailOptions.myToEmailSelected)
            End If

            If emailOptions.myCCEmail.Trim <> "" Then
                omail.CC.Add(emailOptions.myCCEmail)
            End If

            For Each email As String In emailOptions.myGroupCCEmail
                omail.CC.Add(email)
            Next

            If emailOptions.myBCCEmail.Trim <> "" Then
                omail.Bcc.Add(emailOptions.myBCCEmail)
            End If

            omail.IsBodyHtml = True

            If Not emailOptions.myBody Is Nothing Then
                omail.Body = emailOptions.myBody
            End If

            Try
                emailOptions.Dispose()
            Catch ex As Exception
            End Try

            If exportFile.Count > 0 Then

                For i As Integer = 0 To exportFile.Count - 1

                    omail.Attachments.Add(New Attachment(exportFile(i).ToString.Trim))

                Next

            End If

            ' SmtpServer.SendAsync(omail, Nothing)
            SmtpServer.Send(omail)

            omail.Dispose()

        Catch ex As System.Net.Mail.SmtpException
            Me.Cursor = Cursors.Default
            MessageBox.Show("System Problem Sending Email" & vbCrLf & ex.Message.Trim & vbCrLf & ex.StackTrace.ToString.Trim, "Error!", _
            MessageBoxButtons.OK, MessageBoxIcon.Error)
            MsgBox(ex.ToString)
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        emailSent = True

        MessageBox.Show("Email Has Been Sent", "Information", _
                  MessageBoxButtons.OK, MessageBoxIcon.Information)


        If My.Computer.FileSystem.DirectoryExists(directory.Trim) Then

            Do Until "i'm" = "done"

                Try
                    My.Computer.FileSystem.DeleteDirectory(directory.Trim, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Exit Do
                Catch ex As Exception
                    Threading.Thread.Sleep(2000)
                End Try

            Loop

        End If

        Me.Close()

    End Sub

    Private Sub btnPdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPdf.Click

        Me.Cursor = Cursors.WaitCursor

        currentReport = Me.CrystalReportViewer1.ReportSource

        Dim directory As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString.Trim & "\EM" & Date.Now.ToString("yyyyMMddHHmmssffffff")

        If My.Computer.FileSystem.DirectoryExists(directory.Trim) Then
        Else
            My.Computer.FileSystem.CreateDirectory(directory.Trim)
        End If

        reportDescription = GenFun.fixPath(reportDescription.Trim)

        Dim exportFile As String = directory.Trim & "\" & reportDescription.Trim & ".pdf"

        If My.Computer.FileSystem.FileExists(exportFile.Trim) Then
            My.Computer.FileSystem.DeleteFile(exportFile.Trim)
        End If

        currentReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, exportFile.Trim)

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(exportFile.Trim)
        Dim kiloBytes As Decimal = Math.Round(infoReader.Length / 1024, 0, MidpointRounding.AwayFromZero)

        Me.Cursor = Cursors.Default

        myAttachments.Clear()

        Dim thisAttachment As New emailAttachment
        thisAttachment.attachmentName = reportDescription.Trim & ".pdf"
        thisAttachment.sizeKB = kiloBytes
        myAttachments.Add(thisAttachment)

        Dim attach As New ArrayList
        attach.Add(exportFile.Trim)
        Email(attach, directory.Trim)

    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click

        Me.Cursor = Cursors.WaitCursor

        currentReport = Me.CrystalReportViewer1.ReportSource

        Dim directory As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString.Trim & "\EM" & Date.Now.ToString("yyyyMMddHHmmssffffff")

        If My.Computer.FileSystem.DirectoryExists(directory.Trim) Then
        Else
            My.Computer.FileSystem.CreateDirectory(directory.Trim)
        End If

        reportDescription = GENFUN.fixPath(reportDescription.Trim)

        Dim exportFile As String = directory.Trim & "\" & reportDescription.Trim & ".xls"

        If My.Computer.FileSystem.FileExists(exportFile.Trim) Then
            My.Computer.FileSystem.DeleteFile(exportFile.Trim)
        End If

        currentReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, exportFile.Trim)

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(exportFile.Trim)
        Dim kiloBytes As Decimal = Math.Round(infoReader.Length / 1024, 0, MidpointRounding.AwayFromZero)

        Me.Cursor = Cursors.Default

        myAttachments.Clear()

        Dim thisAttachment As New emailAttachment
        thisAttachment.attachmentName = reportDescription.Trim & ".xls"
        thisAttachment.sizeKB = kiloBytes
        myAttachments.Add(thisAttachment)

        Dim attach As New ArrayList
        attach.Add(exportFile.Trim)
        Email(attach, directory.Trim)

    End Sub

    Private Sub btnWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWord.Click

        Me.Cursor = Cursors.WaitCursor

        currentReport = Me.CrystalReportViewer1.ReportSource

        Dim directory As String = My.Computer.FileSystem.SpecialDirectories.Temp.ToString.Trim & "\EM" & Date.Now.ToString("yyyyMMddHHmmssffffff")

        If My.Computer.FileSystem.DirectoryExists(directory.Trim) Then
        Else
            My.Computer.FileSystem.CreateDirectory(directory.Trim)
        End If

        reportDescription = GENFUN.fixPath(reportDescription.Trim)

        Dim exportFile As String = directory.Trim & "\" & reportDescription.Trim & ".doc"

        If My.Computer.FileSystem.FileExists(exportFile.Trim) Then
            My.Computer.FileSystem.DeleteFile(exportFile.Trim)
        End If

        currentReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.WordForWindows, exportFile.Trim)

        Dim infoReader As System.IO.FileInfo
        infoReader = My.Computer.FileSystem.GetFileInfo(exportFile.Trim)
        Dim kiloBytes As Decimal = Math.Round(infoReader.Length / 1024, 0, MidpointRounding.AwayFromZero)

        Me.Cursor = Cursors.Default

        myAttachments.Clear()

        Dim thisAttachment As New emailAttachment
        thisAttachment.attachmentName = reportDescription.Trim & ".doc"
        thisAttachment.sizeKB = kiloBytes
        myAttachments.Add(thisAttachment)

        Dim attach As New ArrayList
        attach.Add(exportFile.Trim)
        Email(attach, directory.Trim)

    End Sub

    Private Sub CrystalReportViewer1_ClickPage(sender As Object, e As CrystalDecisions.Windows.Forms.PageMouseEventArgs) Handles CrystalReportViewer1.ClickPage

        Dim myUrl As String = e.ObjectInfo.Hyperlink

        If myUrl IsNot Nothing Then
            If myUrl.Trim <> "" Then
                Try
                    Process.Start(myUrl.Trim)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

        Me.CrystalReportViewer1.Enabled = False

        Dim btnPdfToolTip As New ToolTip
        Dim btnExcelToolTip As New ToolTip
        Dim btnWordToolTip As New ToolTip

        btnPdfToolTip.SetToolTip(btnPdf, "Email PDF Format")
        btnExcelToolTip.SetToolTip(btnExcel, "Email Excel Format")
        btnWordToolTip.SetToolTip(btnWord, "Email Word Format")

        If meTitle = Nothing Then
            meTitle = Me.Text.Trim
        End If

        If noEmail Then

            btnExcel.Enabled = False
            btnPdf.Enabled = False
            btnWord.Enabled = False

        End If

        Me.Text = meTitle.Trim & " (" & Me.Name.Trim & ")"

        wasDone = True
        'Me.Icon = My.Resources.HS_Icon

        reportDescription = Regex.Replace(reportDescription, "[\W]", " ")

    End Sub

    Private Sub frmReport_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If Not IsNothing(toEmail) Then
            toEmail.Clear()
        End If

        reportClient = ""

    End Sub

    Private Sub frmReport_Shown(sender As Object, e As System.EventArgs) Handles MyBase.Shown

        Me.CrystalReportViewer1.Enabled = True

    End Sub

End Class