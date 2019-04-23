Imports PRMMain.BLL
Namespace My

    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    Partial Friend Class MyApplication

        Private Sub MyApplication_Startup(ByVal sender As Object, ByVal e As ApplicationServices.StartupEventArgs) Handles Me.Startup

            CheckDatabaseConnection()
            CheckUserNameCredentials()

        End Sub

        Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As ApplicationServices.UnhandledExceptionEventArgs) Handles Me.UnhandledException

            Dim sb As New Text.StringBuilder

            sb.AppendLine("Therewas an unhandled exception, message: ")
            sb.Append(Environment.NewLine)
            sb.Append($"'{e.Exception.Message}'")
            sb.Append(Environment.NewLine)
            sb.Append(Environment.NewLine)
            sb.AppendLine("Stack trace: ")
            sb.Append(Environment.NewLine)
            sb.Append(Environment.NewLine)
            sb.Append($"{e.Exception.StackTrace}")
            sb.Append(Environment.NewLine)
            sb.Append(Environment.NewLine)
            sb.Append(Environment.NewLine)
            sb.AppendLine("PLEASE CONTACT TO YOUR IT SUPPORT.")

            ' If the user clicks No, then exit.
            e.ExitApplication = MessageBox.Show(sb.ToString() &
                                vbCrLf & "Do you want to continue ?", "Ups something went wrong!",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) _
                                = DialogResult.No

        End Sub

        Private Sub MyApplication_NetworkAvailabilityChanged(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.Devices.NetworkAvailableEventArgs) Handles Me.NetworkAvailabilityChanged

            My.Forms.FrmMain.SetConnectionStatus(e.IsNetworkAvailable)

        End Sub

        Private Sub CheckUserNameCredentials()

            Dim splash As SplashScreen1 = CType(My.Application.SplashScreen, SplashScreen1)

            splash.Display("Checking username credentials && security...")

            Dim _thisUser As String = GenfunBLL.GetUserID(" ").Trim
            If _thisUser Is Nothing Then
                MessageBox.Show("Error: You are not Defined For Security", "¡Atention!", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Environment.Exit(0)
                Exit Sub
            End If

            FrmMain.SecusrBO.secusr = _thisUser

            Threading.Thread.Sleep(500)

            splash.Display($"¡ Credentials && security information looks alright, Welcome {_thisUser}!")

            Threading.Thread.Sleep(700)
        End Sub

        Private Sub CheckDatabaseConnection()

            Dim splash As SplashScreen1 = CType(My.Application.SplashScreen, SplashScreen1)
            splash.Display("Checking Database Connection...")
            Threading.Thread.Sleep(500)

            Try

                Dim objDAL As New DAL.BaseDAL()
                'Here you can change the project connectionstring or add more connections
                objDAL.SetConnectionString = "DataSource=stg.tomjames.com;DataCompression=True"
                FrmMain.SetDatabaseStatus(objDAL.GetConnectionString.Substring(11, 3))
                objDAL.TestQuery()
                My.Forms.FrmMain.SetConnectionStatus(True)
                'splash.Display("¡ Database seems fine !")
                'Threading.Thread.Sleep(600)

            Catch ex As Exception

                Dim sb As New System.Text.StringBuilder
                sb.AppendLine("Error when we try to connect to the database: ")
                sb.Append(Environment.NewLine)
                sb.Append($"'{ex.Message}'")
                sb.Append(Environment.NewLine)
                sb.Append(Environment.NewLine)
                sb.AppendLine("Stack trace: ")
                sb.Append(Environment.NewLine)
                sb.Append(Environment.NewLine)
                sb.Append($"{ex.StackTrace}")
                sb.Append(Environment.NewLine)
                sb.Append(Environment.NewLine)
                sb.Append(Environment.NewLine)
                sb.AppendLine("PLEASE CONTACT TO YOUR IT SUPPORT.")
                splash.HideMe()
                MessageBox.Show(sb.ToString, "Ups something went wrong!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information)
                Environment.Exit(0)

            End Try

        End Sub

    End Class

End Namespace
