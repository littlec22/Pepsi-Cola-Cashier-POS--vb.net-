Imports MySql.Data.MySqlClient

Module userSettingModule
    'this is for adding and edit
    Private offId As String
    Private fn As String
    Private mn As String
    Private ln As String
    Private un As String
    Private pw As String
    Private dob As String
    Private gen As String
    Private ut As String
    Private us As String



    'this is for userlistview, the colledction of id
    Public userID As New Collection

#Region "Validating, checking for the null input of the user details"
    Function userChecking(ByVal uid As String, ByVal officeid As String, ByVal fname As String, ByVal mname As String, ByVal lname As String, ByVal uname As String, ByVal pword As String, ByVal dobirth As DateTimePicker, ByVal gender As ComboBox, ByVal utype As ComboBox, ByVal ustat As ComboBox, ByVal whatdo As Integer)
        Dim success As Boolean = False
        If officeid = "" Then
            MsgBox("Please Enter Office Id Number!", MsgBoxStyle.Critical, "")
        ElseIf uname = "" Then

            MsgBox("Please Enter Username!", MsgBoxStyle.Critical, "")
        Else

            If whatdo = 1 Then

                If userValidateID(officeid, uid) = True Then

                    If userValidateUsername(uname, uid) = True Then

                        Dim textnull As String = ""
                        If fname = "" Then
                            textnull += "Please enter firstname"
                        End If

                        If lname = "" Then
                            textnull += ", enter lastname"
                        End If

                        If gender.SelectedIndex = -1 Then
                            textnull += ", select gender"
                        End If
                        If utype.SelectedIndex = -1 Then
                            textnull += ", select user type"
                        End If
                        If textnull = "" Then

                            dobirth.Format = DateTimePickerFormat.Custom
                            dobirth.CustomFormat = "yyyy-MM-dd"
                            offId = officeid
                            fn = fname
                            mn = mname
                            ln = lname
                            un = uname
                            pw = pword
                            dob = dobirth.Text
                            gen = gender.Text
                            ut = utype.Text


                            addUser()

                            success = True
                        Else
                            MsgBox(textnull, MsgBoxStyle.Critical, "")
                        End If
                    End If
                End If
            ElseIf whatdo = 2 Then

                If userValidateID(officeid, uid) = True Then

                    If userValidateUsername(uname, uid) = True Then

                        Dim textnull As String = ""
                        If fname = "" Then
                            textnull += "Please enter firstname"
                        End If

                        If lname = "" Then
                            textnull += ", enter lastname"
                        End If

                        If gender.SelectedIndex = -1 Then
                            textnull += ", select gender"
                        End If
                        If utype.SelectedIndex = -1 Then
                            textnull += ", select user type"
                        End If
                        If ustat.SelectedIndex = -1 Then
                            textnull += ", select status"
                        End If
                        If textnull = "" Then

                            dobirth.Format = DateTimePickerFormat.Custom
                            dobirth.CustomFormat = "yyyy-MM-dd"
                            offId = officeid
                            fn = fname
                            mn = mname
                            ln = lname
                            un = uname
                            pw = pword
                            dob = dobirth.Text
                            gen = gender.Text
                            ut = utype.Text
                            us = ustat.Text

                            editUser(uid)

                            success = True
                        Else
                            MsgBox(textnull, MsgBoxStyle.Critical, "")
                        End If
                    End If

                End If
            End If
        End If
        Return success
    End Function
    Function userValidateID(ByVal id As String, ByVal uid As String)

        Dim result As Boolean = True

        Dim validate As String = "SELECT `officeIdNum` FROM user_table WHERE `officeIdNum` = ?id OR `userId` = ?userid "

        cmd = New MySqlCommand(validate, con)
        cmd.Parameters.Add("?id", id)
        cmd.Parameters.Add("?userid", uid)
        Dim count As String
        count = 0
        Try
            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            count = dt.Rows.Count

            If count > 0 Then
                If uid = "" Then

                    If count <> 0 Then
                        MsgBox("Your Enter Office Id Number is Exist, Please search to find it.", MsgBoxStyle.Critical, "")
                        result = False
                    End If


                ElseIf uid <> "" Then

                    If count <> 1 Then
                        MsgBox("Your Enter Office Id Number is use by the other person, Please search to find it.", MsgBoxStyle.Critical, "")
                        result = False

                    End If
                End If


            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return result
    End Function
    Function userValidateUsername(ByVal username As String, ByVal uid As String)

        Dim result As Boolean = True

        Dim validate As String = "SELECT `userName` FROM user_table WHERE `userName` = ?un OR `userId` = ?userid"

        cmd = New MySqlCommand(validate, con)
        cmd.Parameters.Add("?un", username)
        cmd.Parameters.Add("?userid", uid)
        Dim count As String
        count = 0
        Try
            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            count = dt.Rows.Count

            If count > 0 Then
                If uid = "" Then

                    If count <> 0 Then
                        MsgBox("Your Enter Username is Exist, Please search to find it.", MsgBoxStyle.Critical, "")
                        result = False
                    End If

                ElseIf uid <> "" Then
                    If count <> 1 Then
                        MsgBox("Your EnterUsername is use by the other person, Please search to find it.", MsgBoxStyle.Critical, "")
                        result = False

                    End If
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


        Return result
    End Function
#End Region

    Sub addUser()
        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If

        Dim insertdata As String = "INSERT INTO user_table(officeIdNum,firstName,middleName,lastName,userName,passWord,dateOfBirth,gender,userType,status) " & _
            "  VALUES(?offid,?fn,?mn,?ln,?un,?pw,?dob,?gen,?utype,?status)"
        cmd = New MySqlCommand(insertdata, con)
        cmd.Parameters.Add("?offid", offId)
        cmd.Parameters.Add("?fn", fn)
        cmd.Parameters.Add("?mn", mn)
        cmd.Parameters.Add("?ln", ln)
        cmd.Parameters.Add("?un", un)
        cmd.Parameters.Add("?pw", pw)
        cmd.Parameters.Add("?dob", dob)
        cmd.Parameters.Add("?gen", gen)
        cmd.Parameters.Add("?utype", ut)
        cmd.Parameters.Add("?status", "Active")

        Try
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("New User has been save!", MsgBoxStyle.Information, "")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()

    End Sub
    'edting user details
    Sub editUser(ByVal uid As String)
        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If

        Dim insertdata As String = "UPDATE user_table SET officeIdNum = ?offid ,firstName = ?fn ,middleName = ?mn ,lastName = ?ln ," & _
            "userName = ?un ,passWord = ?pw ,dateOfBirth = ?dob ,gender = ?gen ,userType = ?utype ,status = ?status WHERE userId = ?uid  "

        cmd = New MySqlCommand(insertdata, con)
        cmd.Parameters.Add("?offid", offId)
        cmd.Parameters.Add("?fn", fn)
        cmd.Parameters.Add("?mn", mn)
        cmd.Parameters.Add("?ln", ln)
        cmd.Parameters.Add("?un", un)
        cmd.Parameters.Add("?pw", pw)
        cmd.Parameters.Add("?dob", dob)
        cmd.Parameters.Add("?gen", gen)
        cmd.Parameters.Add("?utype", ut)
        cmd.Parameters.Add("?status", us)
        cmd.Parameters.Add("?uid", uid)

        Try
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("User Update has been save!", MsgBoxStyle.Information, "")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()

    End Sub


    'selecting of user.. to see the details.
    Sub selectingUser(ByVal intId As Integer)
        Dim selectdata As String = "SELECT * FROM `user_table` WHERE userId = ?search"
        cmd = New MySqlCommand(selectdata, con)

        cmd.Parameters.Add("?search", userID(intId + 1).ToString + "%")





        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            If dt.Rows.Count <> 0 Then
                With Form2
                    .officeidtextbox.Text = dt.Rows(0).Item(10)
                    .fntextbox.Text = dt.Rows(0).Item(1)
                    .mntextbox.Text = dt.Rows(0).Item(2)
                    .lntextbox.Text = dt.Rows(0).Item(3)
                    .untextbox.Text = dt.Rows(0).Item(4)
                    .pwtextbox.Text = dt.Rows(0).Item(5).ToString
                    .repeatpwtextbox.Text = dt.Rows(0).Item(5).ToString

                    .dobtextbox.Value = dt.Rows(0).Item(6)

                    Dim y As Integer = Now.Year
                    Dim m As Integer = Now.Month
                    Dim d As Integer = Now.Day
                    Dim dob As String = dt.Rows(0).Item(6)
                    Dim age As Integer = 0
                    Dim dy As String() = Split(dob, "-", 3, CompareMethod.Text)
                    If m < Val(dy(1)) Then
                        age = y - dy(0) - 1

                    Else
                        If m = Val(dy(1)) Then
                            If d < Val(dy(2)) Then
                                age = y - dy(0) - 1
                            Else
                                age = y - dy(0)
                            End If
                        Else
                            age = y - dy(0)
                        End If

                    End If
                    .agetextbox.Text = age.ToString
                    .gentextbox.Text = dt.Rows(0).Item(7)
                    .utypetextbox.Text = dt.Rows(0).Item(8)
                    .uStatusComboBox.Text = dt.Rows(0).Item(9)



                End With


            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
    End Sub


#Region "Loading of the user and counting"
    'couting of user
    Function userCount(ByVal search As String) As Double
        Dim selectdata As String = "SELECT `userId` FROM `user_table` WHERE CONCAT(`firstName`,' ',`lastName`,' ',`middleName`)" & _
            " LIKE ?search OR `middleName` LIKE ?search OR `lastName` LIKE ?search OR `firstName` LIKE ?search OR `userType` LIKE ?search ORDER BY `userId` DESC LIMIT 1"

        cmd = New MySqlCommand(selectdata, con)
        cmd.Parameters.Add("?search", search + "%")
        Dim result As Double

        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            If dt.Rows.Count <> 0 Then
                result = dt.Rows(0).Item(0)
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
        Return result

    End Function

    Sub loadingOfUser(ByVal paginateFrom As Integer, ByVal paginateTo As Integer, ByVal searchString As String)
        Dim selectdata As String = "SELECT `userId`,`lastName`,`firstName`,`middleName`,`userType`,`status` " & _
            "FROM `user_table` WHERE CONCAT_WS(' ',`firstName`,`lastName`,`middleName`) LIKE ?search ORDER BY `lastName` ASC LIMIT 0,18"
        cmd = New MySqlCommand(selectdata, con)
        cmd.Parameters.Add("?search", searchString + "%")





        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            userID.Clear()
            Form2.userListView.Items.Clear()
            If dt.Rows.Count <> 0 Then

                For Each row In dt.Rows



                    With Form2.userListView
                        Dim i As New ListViewItem


                        userID.Add(row(0))
                        i = .Items.Add(row(1).ToString + ", " + row(2).ToString + " " + row(3).ToString)
                        i.SubItems.Add(row(4))
                        i.SubItems.Add(row(5))



                    End With
                Next

            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
    End Sub

#End Region
End Module
