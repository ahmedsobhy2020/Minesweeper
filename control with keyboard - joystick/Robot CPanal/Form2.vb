
Public Class Form2
    Dim w, d, s, a, p, o, n, m As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label8.Text = ""
        Label9.Text = ""
        Label10.Text = ""
       
        CenterToScreen()
        Button4.Enabled = False
    End Sub


   

  



    Private Sub Button12_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m = True
    End Sub

    Private Sub Button12_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m = False
       
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

   

    Private Sub Button8_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        w = True
    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.Open()
        Label5.Text = "Connected"
        Label6.Text = "S.R Is Online"
        Label5.ForeColor = Color.Green
        Label6.ForeColor = Color.Green
        Button3.Enabled = False
        Button4.Enabled = True
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        SerialPort1.Close()
        Label5.Text = "DisConnected"
        Label6.Text = "S.R Is Offline"
        Label5.ForeColor = Color.Red
        Label6.ForeColor = Color.Red
        Button3.Enabled = True
        Button4.Enabled = False
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox1.Text = ""
        Label8.Text = ""
        Label9.Text = ""
        Label10.Text = ""
        
    End Sub

    

    Private Sub Button8_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
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
           
            If X.StartsWith("G") Then
                Label9.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If


        End If
    End Sub


   


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

   
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class

