Imports MySql.Data.MySqlClient

Public Class Form1


    Dim x, y, attemp, attempcount As Integer

    Dim newpoint As New System.Drawing.Point

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= (x)

            newpoint.Y -= (y)
            Me.Location = newpoint
        End If
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        testConnection()
        usernameText.Focus()
        attempcount = 3
    End Sub



  

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        login()
    End Sub
    Sub login()

       
        Try



            Dim usernameVar As String = usernameText.Text
            Dim passwordVar As String = passwordText.Text
            Dim query As String = "SELECT  `userId`,`firstName`,`middleName`, `lastName`,`userName`,`passWord`, `userType`,`status` FROM `user_table` WHERE `userName` =?user AND `passWord`=?pass"
            cmd = New MySqlCommand(query, con)

            'variable can be use to define data
            Dim count, restriction As String

            cmd.Parameters.Add("?user", usernameVar)
            cmd.Parameters.Add("?pass", passwordVar)



            'open connection

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If



            adapter = New MySqlDataAdapter(cmd)
            Dim da As New DataTable()
            adapter.Fill(da)
            count = da.Rows.Count

            If count > 0 Then
                Me.Cursor = Cursors.WaitCursor

                restriction = da.Rows(0).Item("userType")
                If restriction = "Staff" Then
                    If "Active" = da.Rows(0).Item("status") Then
                        'throw data into admin form
                        staffFormvb.FULLNAME_ = da.Rows(0).Item("firstName") + ", " + da.Rows(0).Item("middleName") + " " + da.Rows(0).Item("lastName")
                        staffFormvb.USERTYPE_ = da.Rows(0).Item("userType")
                        staffFormvb.USERID_ = da.Rows(0).Item("userId")

                        'need to close the connection before leaving the form

                        con.Close()
                        fillingMySourceForTransPage(2)
                        staffFormvb.Show()

                        Me.Hide()
                        usernameText.Text = ""
                        passwordText.Text = ""
                    Else
                        MsgBox("You can't access to the system, contact administrator!", MsgBoxStyle.Information, "")
                    End If
                ElseIf restriction = "Encoder" Then
                    If "Active" = da.Rows(0).Item("status") Then
                        'throw data into admin form
                        encoderForm.FULLNAME_ = da.Rows(0).Item("firstName") + ", " + da.Rows(0).Item("middleName") + " " + da.Rows(0).Item("lastName")
                        encoderForm.USERTYPE_ = da.Rows(0).Item("userType")
                        encoderForm.USERID_ = da.Rows(0).Item("userId")

                        'need to close the connection before leaving the form

                        con.Close()
                        fillingMySourceForTransPage(2)
                        encoderForm.Show()

                        Me.Hide()
                        usernameText.Text = ""
                        passwordText.Text = ""
                    Else
                        MsgBox("You can't access to the system, contact administrator!", MsgBoxStyle.Information, "")
                    End If

                ElseIf restriction = "Admin" Then
                    If "Active" = da.Rows(0).Item("status") Then
                        'throw data into admin form
                        Form2.FULLNAME_ = da.Rows(0).Item("firstName") + ", " + da.Rows(0).Item("middleName") + " " + da.Rows(0).Item("lastName")
                        Form2.USERTYPE_ = da.Rows(0).Item("userType")
                        Form2.USERID_ = da.Rows(0).Item("userId")

                        'need to close the connection before leaving the form

                        con.Close()
                        fillingMySourceForTransPage(1)
                        Form2.Show()

                        Me.Hide()
                        usernameText.Text = ""
                        passwordText.Text = ""
                    Else
                        MsgBox("You can't access to the system, contact administrator!", MsgBoxStyle.Information, "")
                    End If
                End If
                Me.Cursor = Cursors.Default

                Else
                    con.Close()


                    If attemp = 3 Then
                        MsgBox("You are attemp to login 4 times, the system will close.", MsgBoxStyle.Critical, "Login Attemp")
                        Me.Close()
                    Else
                        MsgBox("Username and Password not matched! next " + attempcount.ToString + " login attemp the system will shutdown.", MsgBoxStyle.Critical, "Login Attemped")
                        attempcount -= 1
                        attemp = attemp + 1
                    End If

                End If




            'closing of connection


        Catch ex As Exception
            MsgBox(ex.ToString)
            ' MsgBox("Check your Xampp Control Panel, Make sure that the Mysql is already Start., if nothing happen contact to your System Provider.", MsgBoxStyle.Information, "")
        End Try
        usernameText.Focus()
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click

    End Sub
  
    
    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub



  
End Class
