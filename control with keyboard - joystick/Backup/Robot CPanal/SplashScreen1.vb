Public NotInheritable Class SplashScreen1

    Private Sub SplashScreen1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Close()
    End Sub


    Private Sub SplashScreen1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Copyright.Text = My.Application.Info.Copyright

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)
        ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
    End Sub

    Private Sub GroupBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.Click
        Close()
    End Sub


    Private Sub GroupBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles GroupBox1.KeyPress
        Close()
    End Sub


    Private Sub Version_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Version.Click

    End Sub
End Class
