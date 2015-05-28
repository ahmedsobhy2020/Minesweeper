
Public Class Form2
    Dim w, d, s, a, p, o, n, m As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label8.Text = ""
        Label9.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""
        CenterToScreen()
        Button4.Enabled = False
    End Sub


    Private Sub Button11_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        n = True
        Button12.Visible = True
    End Sub

    Private Sub Button11_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        n = False
        Button11.Enabled = False
    End Sub



    Private Sub Button12_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m = True
    End Sub

    Private Sub Button12_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m = False
        Button12.Visible = False
        Button11.Enabled = True
    End Sub



    Private Sub Button13_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        o = True

    End Sub

    Private Sub Button13_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        o = False
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SplashScreen1.Show()
    End Sub

   Private Sub Button8_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button8.MouseDown
        w = True
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.Open()
        Label5.Text = "Connected"
        Label6.Text = "SSR Is Online"
        Label12.ForeColor = Color.Blue
        Button3.Enabled = False
        Button4.Enabled = True
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        SerialPort1.Close()
        Label5.Text = "DisConnected"
        Label6.Text = "SSR Is Offline"
        Label12.ForeColor = Color.Red
        Button3.Enabled = True
        Button4.Enabled = False
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox1.Text = ""
        Label8.Text = ""
        Label9.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""
    End Sub

    

    Private Sub Button8_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button8.MouseUp
        w = False

    End Sub

    Private Sub Timer1_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If w = True Then
            SerialPort1.Write("w")
        End If
        If d = True Then
            SerialPort1.Write("d")
        End If
        If s = True Then
            SerialPort1.Write("s")
        End If
        If a = True Then
            SerialPort1.Write("a")
        End If
        If p = True Then
            SerialPort1.Write("p")
        End If
        If o = True Then
            SerialPort1.Write("o")
        End If
        If n = True Then
            SerialPort1.Write("n")
        End If
        If m = True Then
            SerialPort1.Write("m")
        End If
    End Sub

    Private Sub Timer2_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim X As String
        If SerialPort1.IsOpen = True Then
            X = SerialPort1.ReadExisting
            If Trim(X) = "" Then Exit Sub
            TextBox1.Text = TextBox1.Text & X
            If X.StartsWith("T") Then
                Label8.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If
            If X.StartsWith("F") Then
                Label10.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If
            If X.StartsWith("H") Then
                Label11.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If
            If X.StartsWith("R") Then
                Label12.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If
            If X.StartsWith("G") Then
                Label9.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If


        End If
    End Sub


    Private Sub Button6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button6.MouseDown
        a = True
    End Sub

    Private Sub Button6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button6.MouseUp
        a = False
    End Sub

    Private Sub Button9_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button9.MouseDown
        s = True
    End Sub

    Private Sub Button9_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button9.MouseUp
        s = False
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click

    End Sub

    Private Sub Button7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button7.MouseDown
        d = True
    End Sub

    Private Sub Button7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button7.MouseUp
        d = False
    End Sub

    Private Sub Button5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseDown
        p = True
    End Sub

    Private Sub Button5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseUp
        p = False
    End Sub


    Private Sub Button10_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button10.MouseDown
        n = True
        Button11.Visible = True
    End Sub

    Private Sub Button10_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button10.MouseUp
        n = False
        Button10.Enabled = False
    End Sub

    Private Sub Button11_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button11.MouseDown
        m = True
    End Sub

    Private Sub Button11_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button11.MouseUp
        m = False
        Button11.Visible = False
        Button10.Enabled = True
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click

    End Sub

    Private Sub Button12_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button12.MouseDown
        o = True
    End Sub

    Private Sub Button12_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button12.MouseUp
        o = False
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click

    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        frmMain.Show()

    End Sub
End Class

