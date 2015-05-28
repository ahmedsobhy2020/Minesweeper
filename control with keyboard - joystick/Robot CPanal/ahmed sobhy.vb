Imports System.IO
Imports Microsoft.Win32
Imports System.Runtime.InteropServices
Public Class Form2
    Dim w, d, s, a, p, n, m, l, o, k, r, t, y, u, z As Boolean
    Private WithEvents joystick1 As Joystick
    Declare Function joyGetPosEx Lib "winmm.dll" (ByVal uJoyID As Integer, ByRef pji As JOYINFOEX) As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label8.Text = ""
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""

        CenterToScreen()
        Button4.Enabled = False

        joystick1 = New Joystick(Me, 0)
        myjoyEX.dwSize = 64
        myjoyEX.dwFlags = &HFF ' All information
        Timer3.Interval = 200  'Update at 5 hz
        Timer3.Start()

   



    End Sub

    Private Sub Button12_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m = True
    End Sub

    Private Sub Button12_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m = False
       
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Close()
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
        Label10.Text = ""
        Label11.Text = ""
        Label12.Text = ""



        
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
        If k = True Then
            SerialPort1.Write("k")
        End If
        If l = True Then
            SerialPort1.Write("l")
        End If
        If r = True Then
            SerialPort1.Write("r")
        End If
        If t = True Then
            SerialPort1.Write("t")
        End If
        If y = True Then
            SerialPort1.Write("y")
        End If
        If u = True Then
            SerialPort1.Write("u")
        End If
        If z = True Then
            SerialPort1.Write("z")
        End If
    End Sub


    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        ' Get the joystick information
        Call joyGetPosEx(0, myjoyEX)

        With myjoyEX
            Label7.Text = .dwXpos.ToString          'Up to six axis supported
            Label9.Text = .dwYpos.ToString
            'Label363.Text = .dwZpos.ToString
            'Label363.Text = .dwRpos.ToString
            'Label363.Text = .dwUpos.ToString
            'Label363.Text = .dwVpos.ToString
            Label363.Text = .dwButtons.ToString("X")  'Print in Hex, so can see the individual bits associated with the buttons
            Label364.Text = .dwButtonNumber.ToString  'number of buttons pressed at the same time
            'Label363.Text = (.dwPOV / 100).ToString     'POV hat (in 1/100ths of degrees, so divided by 100 to give degrees)
        End With
    End Sub


    Private Sub Timer2_Tick_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Dim X As String
        If SerialPort1.IsOpen = True Then
            X = SerialPort1.ReadExisting
            If Trim(X) = "" Then Exit Sub
            TextBox1.Text = TextBox1.Text & X
            If X.StartsWith("A") Then
                Label8.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If

            If X.StartsWith("C") Then
                Label10.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If

            If X.StartsWith("D") Then
                Label11.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If

            If X.StartsWith("E") Then
                Label12.Text = X.Trim(X, ChrW(Len(X) - 1))
            End If

        End If
    End Sub

    '------------------------- keyboard -------------------------------------------

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown

        If (e.KeyValue = Keys.Up) Then

            w = True


        End If

        If (e.KeyValue = Keys.Right) Then

            d = True


        End If

        If (e.KeyValue = Keys.Down) Then


            s = True

        End If


        If (e.KeyValue = Keys.Left) Then

            a = True



        End If
        If (e.KeyValue = Keys.Space) Then

            p = True

        End If
        If (e.KeyValue = Keys.A) Then

            y = True

        End If
        If (e.KeyValue = Keys.S) Then

            u = True

        End If
        If (e.KeyValue = Keys.Q) Then

            r = True

        End If
        If (e.KeyValue = Keys.W) Then

            t = True

        End If


    End Sub

    Private Sub TextBox2_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyUp
        w = False
        s = False
        d = False
        a = False
        p = False
        n = False
        m = False
        k = False
        l = False
        r = False
        t = False
        y = False
        u = False

    End Sub

    '----------------------------------joystick-------------------------------------

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure JOYINFOEX
        Public dwSize As Integer
        Public dwFlags As Integer
        Public dwXpos As Integer
        Public dwYpos As Integer
        Public dwZpos As Integer
        Public dwRpos As Integer
        Public dwUpos As Integer
        Public dwVpos As Integer
        Public dwButtons As Integer
        Public dwButtonNumber As Integer
        Public dwPOV As Integer
        Public dwReserved1 As Integer
        Public dwReserved2 As Integer
    End Structure
    Public myjoyEX As JOYINFOEX


    Private Sub Label363_TextChanged(sender As Object, e As EventArgs) Handles Label363.TextChanged

        p = False
        y = False
        u = False
        m = False
        k = False
        l = False
        r = False
        t = False
        n = False
        z = False

        If (Label363.Text = "20") Then
            p = True
        ElseIf (Label363.Text = "10") Then
            y = True
        ElseIf (Label363.Text = "40") Then
            u = True
        ElseIf (Label363.Text = "1") Then
            n = True
        ElseIf (Label363.Text = "2") Then
            m = True
        ElseIf (Label363.Text = "4") Then
            k = True
        ElseIf (Label363.Text = "8") Then
            l = True
        ElseIf (Label363.Text = "200") Then
            r = True
        ElseIf (Label363.Text = "100") Then
            t = True
        ElseIf (Label363.Text = "80") Then
            z = True
        End If



    End Sub

    Private Sub Label9_TextChanged(sender As Object, e As EventArgs) Handles Label9.TextChanged
        w = False
        s = False
        If (Label9.Text = "0") Then
            w = True
        ElseIf (Label9.Text = "65535") Then
            s = True
        End If

    End Sub
    Private Sub Label7_TextChanged(sender As Object, e As EventArgs) Handles Label7.TextChanged

        d = False
        a = False

        If (Label7.Text = "65535") Then
            d = True
        ElseIf (Label7.Text = "0") Then
            a = True
        End If



    End Sub

    '----------------------------------------------------------------------------------------



    Private Sub Button8_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button8.MouseDown
        w = True

    End Sub


    Private Sub Button8_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button8.MouseUp
        w = False

    End Sub

    Private Sub Button6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button6.MouseDown
        d = True
    End Sub

    Private Sub Button6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button6.MouseUp
        d = False
    End Sub

    Private Sub Button9_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button9.MouseDown
        s = True
    End Sub

    Private Sub Button9_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button9.MouseUp
        s = False
    End Sub

    Private Sub Button7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button7.MouseDown
        a = True
    End Sub

    Private Sub Button7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button7.MouseUp
        a = False
    End Sub

    Private Sub Button5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseDown
        p = True
    End Sub

    Private Sub Button5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button5.MouseUp
        p = False
    End Sub
    Private Sub Button12_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button12.MouseDown
        n = True

    End Sub


    Private Sub Button12_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button12.MouseUp
        n = False

    End Sub
    Private Sub Button2_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseDown
        m = True

    End Sub


    Private Sub Button2_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button2.MouseUp
        m = False

    End Sub
    Private Sub Button15_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button15.MouseDown
        k = True

    End Sub


    Private Sub Button15_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button15.MouseUp
        k = False

    End Sub
    Private Sub Button14_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button14.MouseDown
        l = True

    End Sub


    Private Sub Button14_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button14.MouseUp
        l = False

    End Sub
    Private Sub Button10_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button10.MouseDown
        r = True

    End Sub
    Private Sub Button10_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button10.MouseUp
        r = False

    End Sub

    Private Sub Button11_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button11.MouseDown
        t = True

    End Sub
    Private Sub Button11_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button11.MouseUp
        t = False

    End Sub

    Private Sub Button17_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button17.MouseDown
        y = True

    End Sub
    Private Sub Button17_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button17.MouseUp
        y = False

    End Sub
    Private Sub Button16_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button16.MouseDown
        u = True

    End Sub
    Private Sub Button16_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button16.MouseUp
        u = False

    End Sub
    Private Sub Button18_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button18.MouseDown
        z = True

    End Sub
    Private Sub Button18_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button18.MouseUp
        z = False

    End Sub



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        ' Dim ax As String
        Dim mine As String
        Dim ynum As String
        Dim xnum As String
        xnum = Label12.Text
        ynum = Label11.Text
        mine = Label10.Text

        If (ynum = "1" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox1.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox1.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "1") Then


            If (mine = "1") Then

                PictureBox2.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox2.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox3.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox3.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox4.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox4.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox5.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox5.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox6.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox6.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox7.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox7.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox8.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox8.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox9.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox9.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox10.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox10.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "11" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox11.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox11.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "12" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox12.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox12.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox13.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox13.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox14.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox14.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox15.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox15.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "16" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox16.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox16.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "17" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox17.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox17.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox18.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox18.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "19" And xnum = "1") Then
            If (mine = "1") Then

                PictureBox19.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox19.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If


        '----------------------------------- 2nd one  ------------------------------------



        If (ynum = "1" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox20.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox20.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "2") Then


            If (mine = "1") Then

                PictureBox21.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox21.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox22.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox22.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox23.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox23.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox24.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox24.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox25.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox25.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox26.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox26.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox27.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox27.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox28.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox28.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox29.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox29.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "11" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox30.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox30.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "12" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox31.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox31.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox32.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox32.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox33.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox33.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox34.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox34.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "16" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox35.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox35.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "17" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox36.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox36.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox37.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox37.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "19" And xnum = "2") Then
            If (mine = "1") Then

                PictureBox38.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox38.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '----------------------------- 3rd one ----------------------------------

        If (ynum = "1" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox39.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox39.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "3") Then


            If (mine = "1") Then

                PictureBox40.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox40.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox41.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox41.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox42.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox42.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox43.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox43.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox44.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox44.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox45.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox45.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox46.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox46.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox47.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox47.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox48.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox48.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "11" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox49.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox49.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "12" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox50.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox50.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox51.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox51.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox52.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox52.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox53.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox53.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "16" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox54.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox54.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "17" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox55.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox55.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox56.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox56.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "19" And xnum = "3") Then
            If (mine = "1") Then

                PictureBox57.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox57.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '----------------------------- 4th one ----------------------------------

        If (ynum = "1" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox58.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox58.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "4") Then


            If (mine = "1") Then

                PictureBox59.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox59.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox60.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox60.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox61.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox61.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox62.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox62.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox63.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox63.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox64.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox64.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox65.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox65.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox66.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox66.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox67.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox67.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox68.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox68.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox69.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox69.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox70.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox70.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox71.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox71.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox72.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox72.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox73.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox73.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox74.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox74.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox75.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox75.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "4") Then
            If (mine = "1") Then

                PictureBox76.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox76.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '----------------------------- 5th one ----------------------------------

        If (ynum = "1" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox77.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox77.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "5") Then


            If (mine = "1") Then

                PictureBox78.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox78.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox79.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox79.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox80.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox80.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox81.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox81.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox82.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox82.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox83.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox83.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox84.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox84.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox85.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox85.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox86.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox86.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox87.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox87.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox88.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox88.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox89.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox89.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox90.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox90.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox91.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox91.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox92.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox92.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox93.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox93.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox94.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox94.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "5") Then
            If (mine = "1") Then

                PictureBox95.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox95.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If


        '----------------------------- 6th one ----------------------------------

        If (ynum = "1" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox96.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox96.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "6") Then


            If (mine = "1") Then

                PictureBox97.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox97.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox98.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox98.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox99.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox99.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox100.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox100.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox101.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox101.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox102.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox102.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox103.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox103.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox104.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox104.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox105.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox105.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox106.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox106.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox107.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox107.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox108.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox108.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox109.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox109.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox110.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox110.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox111.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox111.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox112.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox112.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox113.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox113.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "6") Then
            If (mine = "1") Then

                PictureBox114.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox114.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '----------------------------- 7th one ----------------------------------

        If (ynum = "1" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox115.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox115.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "7") Then


            If (mine = "1") Then

                PictureBox116.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox116.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox117.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox117.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox118.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox118.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox119.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox119.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox120.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox120.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox121.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox121.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox122.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox122.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox123.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox123.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox124.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox124.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox125.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox125.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox126.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox126.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox127.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox127.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox128.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox128.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox129.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox129.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox130.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox130.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox131.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox131.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox132.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox132.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "7") Then
            If (mine = "1") Then

                PictureBox133.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox133.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '----------------------------- 8th one ----------------------------------

        If (ynum = "1" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox134.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox134.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "8") Then


            If (mine = "1") Then

                PictureBox135.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox135.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox136.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox136.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox137.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox137.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox138.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox138.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox139.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox139.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox140.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox140.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox141.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox141.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox142.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox142.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox143.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox143.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox144.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox144.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox145.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox145.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox146.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox146.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox147.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox147.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox148.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox148.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox149.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox149.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox150.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox150.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox151.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox151.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "8") Then
            If (mine = "1") Then

                PictureBox152.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox152.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If



        '----------------------------- 9th one ----------------------------------

        If (ynum = "1" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox153.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox153.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "9") Then


            If (mine = "1") Then

                PictureBox154.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox154.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox155.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox155.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox156.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox156.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox157.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox157.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox158.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox158.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox159.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox159.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox160.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox160.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox161.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox161.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox162.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox162.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox163.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox163.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox164.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox164.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox165.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox165.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox166.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox166.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox167.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox167.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox168.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox168.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox169.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox169.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox170.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox170.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "9") Then
            If (mine = "1") Then

                PictureBox171.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox171.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If





        '----------------------------- 10th one ----------------------------------

        If (ynum = "1" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox172.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox172.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "10") Then


            If (mine = "1") Then

                PictureBox173.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox173.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox174.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox174.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox175.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox175.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox176.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox176.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox177.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox177.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox178.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox178.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox179.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox179.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox180.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox180.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox181.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox181.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox182.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox182.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox183.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox183.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox184.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox184.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox185.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox185.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox186.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox186.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox187.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox187.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox188.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox188.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox189.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox189.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "10") Then
            If (mine = "1") Then

                PictureBox190.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox190.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If




        '----------------------------- 11th one ----------------------------------

        If (ynum = "1" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox191.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox191.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "11") Then


            If (mine = "1") Then

                PictureBox192.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox192.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox193.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox193.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox194.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox194.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox195.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox195.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox196.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox196.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox197.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox197.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox198.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox198.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox199.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox199.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox200.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox200.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox201.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox201.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox202.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox202.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox203.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox203.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox204.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox204.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox205.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox205.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox206.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox206.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox207.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox207.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox208.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox208.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "11") Then
            If (mine = "1") Then

                PictureBox209.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox209.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If



        '----------------------------- 12th one ----------------------------------

        If (ynum = "1" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox210.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox210.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "12") Then


            If (mine = "1") Then

                PictureBox211.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox211.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox212.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox212.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox213.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox213.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox214.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox214.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox215.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox215.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox216.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox216.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox217.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox217.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox218.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox218.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox219.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox219.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox220.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox220.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox221.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox221.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox222.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox222.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox223.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox223.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox224.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox224.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox225.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox225.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox226.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox226.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox227.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox227.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "12") Then
            If (mine = "1") Then

                PictureBox228.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox228.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '----------------------------- 13th one ----------------------------------

        If (ynum = "1" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox229.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox229.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "13") Then


            If (mine = "1") Then

                PictureBox230.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox230.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox231.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox231.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox232.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox232.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox233.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox233.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox234.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox234.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox235.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox235.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox236.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox236.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox237.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox237.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox238.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox238.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox239.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox239.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox240.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox240.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox241.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox241.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox242.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox242.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox243.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox243.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox244.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox244.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox245.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox245.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox246.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox246.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "13") Then
            If (mine = "1") Then

                PictureBox247.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox247.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If


        '----------------------------- 14th one ----------------------------------


        If (ynum = "1" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox248.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox248.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "14") Then


            If (mine = "1") Then

                PictureBox249.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox249.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox250.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox250.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox251.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox251.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox252.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox252.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox253.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox253.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox254.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox254.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox255.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox255.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox256.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox256.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox257.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox257.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox258.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox258.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox259.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox259.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox260.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox260.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox261.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox261.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox262.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox262.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox263.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox263.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox264.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox264.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox265.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox265.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "14") Then
            If (mine = "1") Then

                PictureBox266.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox266.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '----------------------------- 15th one ----------------------------------


        If (ynum = "1" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox267.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox267.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "15") Then


            If (mine = "1") Then

                PictureBox268.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox268.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox269.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox269.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox270.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox270.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox271.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox271.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox272.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox272.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox273.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox273.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox274.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox274.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox275.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox275.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox276.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox276.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox277.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox277.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox278.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox278.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox279.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox279.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox280.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox280.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox281.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox281.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox282.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox282.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox283.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox283.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox284.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox284.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "15") Then
            If (mine = "1") Then

                PictureBox285.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox285.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '----------------------------- 16th one ----------------------------------


        If (ynum = "1" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox286.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox286.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "16") Then


            If (mine = "1") Then

                PictureBox287.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox287.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox288.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox288.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox289.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox289.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox290.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox290.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox291.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox291.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox292.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox292.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox293.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox293.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox294.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox294.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox295.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox295.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox296.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox296.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox297.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox297.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox298.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox298.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox299.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox299.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox300.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox300.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox301.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox301.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox302.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox302.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox303.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox303.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "16") Then
            If (mine = "1") Then

                PictureBox304.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox304.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If


        '----------------------------- 17th one ----------------------------------


        If (ynum = "1" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox305.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox305.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "17") Then


            If (mine = "1") Then

                PictureBox306.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox306.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox307.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox307.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox308.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox308.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox309.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox309.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox310.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox310.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox311.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox311.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox312.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox312.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox313.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox313.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox314.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox314.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox315.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox315.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox316.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox316.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox317.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox317.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox318.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox318.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox319.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox319.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox320.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox320.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox321.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox321.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox322.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox322.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "17") Then
            If (mine = "1") Then

                PictureBox323.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox323.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If







        '----------------------------- 18th one ----------------------------------


        If (ynum = "1" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox324.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox324.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "18") Then


            If (mine = "1") Then

                PictureBox325.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox325.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox326.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox326.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox327.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox327.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox328.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox328.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox329.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox329.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox330.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox330.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox331.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox331.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox332.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox332.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox333.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox333.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox334.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox334.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox335.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox335.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox336.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox336.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox337.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox337.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox338.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox338.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox339.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox339.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox340.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox340.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox341.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox341.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "18") Then
            If (mine = "1") Then

                PictureBox342.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox342.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If





        '----------------------------- 19th one ----------------------------------


        If (ynum = "1" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox343.Image = Image.FromFile("D:\minered.jpg")

            ElseIf (mine = "3") Then

                PictureBox343.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If


        '------------------------------------------

        If (ynum = "2" And xnum = "19") Then


            If (mine = "1") Then

                PictureBox344.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox344.Image = Image.FromFile("D:\mine.jpg")

            End If


        End If

        '----------------------
        If (ynum = "3" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox345.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox345.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "4" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox346.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox346.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "5" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox347.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox347.Image = Image.FromFile("D:\mine.jpg")


            End If

        End If
        '-----------------------------------

        If (ynum = "6" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox348.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox348.Image = Image.FromFile("D:\mine.jpg")


            End If
        End If

        '-----------------------------------

        If (ynum = "7" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox349.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox349.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "8" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox350.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox350.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "9" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox351.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox351.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "10" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox352.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox352.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------


        If (ynum = "11" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox353.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox353.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "12" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox354.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox354.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "13" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox355.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox355.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "14" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox356.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox356.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "15" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox357.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox357.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "16" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox358.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox358.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "17" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox359.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox359.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If
        '-----------------------------------

        If (ynum = "18" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox360.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox360.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If

        '-----------------------------------

        If (ynum = "19" And xnum = "19") Then
            If (mine = "1") Then

                PictureBox361.Image = Image.FromFile("D:\minered.jpg")


            ElseIf (mine = "3") Then

                PictureBox361.Image = Image.FromFile("D:\mine.jpg")

            End If

        End If



    End Sub

 
   
    Private Sub PictureBox362_Click(sender As Object, e As EventArgs)

    End Sub
End Class

