Public NotInheritable Class SplashScreen1

    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  
        PreVentFlicker()
        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Dim sv As String = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        If sv = "Version 1.00" Then
            sv = $"{sv} DEV."
        End If
        Version.Text = sv
        FrmMain.SoftwareVersion = sv
        labelStatus.Text = "Loading..."

    End Sub

    Private Sub PreVentFlicker()
        With Me
            .SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            .SetStyle(ControlStyles.UserPaint, True)
            .SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            .UpdateStyles()
        End With

    End Sub

    Public Sub ChangeLabelStatus(ByVal msg As String)

        labelStatus.Text = msg

    End Sub

    Public Sub Display(ByVal strParam As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() Display(strParam))
            Return
        End If
        labelStatus.Text = strParam
    End Sub

    Public Sub HideMe()
        If Me.InvokeRequired Then
            Me.Invoke(Sub() HideMe())
            Return
        End If
        Me.Hide()
    End Sub

End Class
