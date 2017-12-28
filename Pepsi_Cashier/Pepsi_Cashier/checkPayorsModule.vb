Imports MySql.Data.MySqlClient

Module checkPayorsModule

    Private businessName As String
    Private ownersName As String
    Private prysID As String
    Private checkLimit As String
    Private bankName As String
    Private branchAddress As String
    Private approvedDate As String
    Private remarks As String
    Private acnstat As String



    'the accountNumber in inserting of account number
    Public accountNumber As String

    'the array of accountNumber in Viewing of account Number
    Public accountNumberID As New Collection

    'collection of payors id .. this is identifier in list
    Public payorsID As New Collection





    'adding of check payors
    Function addCheckPayor()
        Dim result As Boolean = False
        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If

        Dim insertdata As String = "INSERT INTO check_payers_table(business_Name) " & _
            "  VALUES(?bn)"
        cmd = New MySqlCommand(insertdata, con)
        cmd.Parameters.Add("?bn", businessName)

       


        Try
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("New account has been save! : " + businessName.ToUpper,MsgBoxStyle.OkOnly,"")
                Form2.mysource.Add(businessName)

                result = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
        Return result
    End Function
    'validating all data of payors
    Function payorsChecking(ByVal bn As String)

        Dim result As Boolean = False
        Dim whatproblem As String = ""




        If bn = "" Then
            whatproblem = "Business/Trade Name"
        End If







        If whatproblem <> "" Then
            MsgBox("Please Fill up the Following : " + whatproblem, MsgBoxStyle.Critical, "Fill up the Blank")
        Else

            businessName = bn



            If checkPayorsModule.addCheckPayor() = True Then
                result = True
            End If

        End If


        Return result
    End Function
    'counting of payors
    Function payorsCount(ByVal searchString As String)
        Dim counter As Integer
        Dim selectdata As String = "SELECT  count(`check_payers_table`.`check_payers_id`)  FROM `check_payers_table` " & _
            "WHERE `check_Payers_Id` = any(SELECT `check_Payers_Id` FROM `account_number_table` WHERE `account_Num` LIKE ?search" & _
            " OR `owners_Name`  LIKE ?search OR `status`  LIKE ?search) OR `check_Payers_Id` = any(SELECT `check_Payers_Id`" & _
            " FROM `check_payers_table` WHERE `business_Name` LIKE ?search)"

        cmd = New MySqlCommand(selectdata, con)
        cmd.Parameters.Add("?search", searchString + "%")


        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)


            If dt.Rows.Count <> 0 Then

                counter = dt.Rows(0).Item(0)
            Else

            End If


            con.Close()



        Catch ex As Exception

        End Try
        Return counter

    End Function


    'loading of payors with pagination
    Sub loadingOfPayors(ByVal paginateFrom As Integer, ByVal paginateTo As Integer, ByVal searchString As String, ByVal whatDo As Integer)
        Dim selectdata As String = "SELECT   `check_payers_table`.`check_Payers_Id`,`check_payers_table`.`business_Name`  FROM `check_payers_table` " & _
                                    "WHERE `check_Payers_Id` = any(SELECT `check_Payers_Id` FROM `account_number_table` WHERE `account_Num` LIKE ?search" & _
                                    " OR `owners_Name`  LIKE ?search OR `status`  LIKE ?search) OR `check_Payers_Id` = any(SELECT `check_Payers_Id`" & _
                                    " FROM `check_payers_table` WHERE `business_Name` LIKE ?search)" & _
                                    " ORDER BY `check_payers_table`.`business_Name` ASC LIMIT " + paginateFrom.ToString + "," + paginateTo.ToString + " "
        cmd = New MySqlCommand(selectdata, con)
        cmd.Parameters.Add("?search", searchString + "%")





        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            payorsID.Clear()
            If whatDo = 1 Then
                Form2.payorsListView.Items.Clear()
            Else
                encoderForm.payorsListView.Items.Clear()
            End If

            If dt.Rows.Count <> 0 Then
                Dim x As Integer = paginateFrom + 1
                For Each row In dt.Rows


                    Dim selectdata1 As String = "SELECT COUNT(`account_num`) " & _
                                    "FROM `account_number_table`  " & _
                                    "WHERE `check_payers_Id` = ?search "
                    cmd = New MySqlCommand(selectdata1, con)
                    cmd.Parameters.Add("?search", row(0))
                    adapter = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adapter.Fill(dt)

                    Dim theAccountNumCount As Integer = 0

                    If dt.Rows.Count <> 0 Then

                        theAccountNumCount = (dt.Rows(0).Item(0))
                    Else
                        theAccountNumCount = 0
                    End If
                    If whatDo = 1 Then
                        With Form2.payorsListView
                            Dim i As New ListViewItem

                            Dim a As String = ""

                            payorsID.Add(row(0))
                            i = .Items.Add(x)
                            i.SubItems.Add(row(1))
                            i.SubItems.Add(theAccountNumCount)


                            x += 1
                        End With
                    ElseIf whatDo = 2 Then
                        With encoderForm.payorsListView
                            Dim i As New ListViewItem

                            Dim a As String = ""

                            payorsID.Add(row(0))
                            i = .Items.Add(x)
                            i.SubItems.Add(row(1))
                            i.SubItems.Add(theAccountNumCount)


                            x += 1
                        End With

                    End If

                   
                Next

            Else

            End If






        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
    End Sub

    'selecting of the payors ' loading their details
    Sub selectingPayorFromList(ByVal id As String, ByVal whatDo As Integer)
        Dim selectdata As String = "SELECT  * " & _
                                    "FROM `check_payers_table`  " & _
                                    "WHERE  check_Payers_Id = ?search"

        cmd = New MySqlCommand(selectdata, con)

        cmd.Parameters.Add("?search", payorsID(id + 1))

        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            If dt.Rows.Count <> 0 Then


                For Each row In dt.Rows
                    accountNumberID.Clear()
                    If whatDo = 1 Then
                        Form2.busiNameText.Text = row("business_Name")
                        Form2.accountNumList.Items.Clear()
                    Else
                        encoderForm.busiNameText.Text = row("business_Name")
                        encoderForm.accountNumList.Items.Clear()
                    End If



                    Dim selectdata1 As String = "SELECT * " & _
                                    "FROM `account_number_table`  " & _
                                    "WHERE `check_payers_Id` = ?search "
                    cmd = New MySqlCommand(selectdata1, con)
                    cmd.Parameters.Add("?search", row("check_Payers_Id"))
                    adapter = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adapter.Fill(dt)


                   

                    If dt.Rows.Count <> 0 Then

                        If whatDo = 1 Then
                            For Each row2 In dt.Rows

                                With Form2.accountNumList

                                    Dim x As New ListViewItem

                                    x = .Items.Add(row2("account_Num"))

                                    x.SubItems.Add(row2("bank_Name"))
                                    x.SubItems.Add(row2("owners_Name"))
                                    If row2("Status") = "1" Then
                                        x.SubItems.Add("Active")
                                    Else
                                        x.SubItems.Add("Inactive")
                                    End If


                                    accountNumberID.Add(row2("account_Num_Id"))
                                End With

                            Next
                        Else
                            For Each row2 In dt.Rows

                                With encoderForm.accountNumList

                                    Dim x As New ListViewItem

                                    x = .Items.Add(row2("account_Num"))

                                    x.SubItems.Add(row2("bank_Name"))
                                    x.SubItems.Add(row2("owners_Name"))
                                    If row2("Status") = "1" Then
                                        x.SubItems.Add("Active")
                                    Else
                                        x.SubItems.Add("Inactive")
                                    End If


                                    accountNumberID.Add(row2("account_Num_Id"))
                                End With

                            Next
                        End If

                        

                        selectingAccountNumber(0, whatDo)
                    End If


                Next

            Else
                If whatDo = 1 Then
                    With Form2
                        .accountNumText.Text = ""
                        .ownerNameText.Text = ""
                        .checkLimitText.Text = ""
                        .bankNameText.Text = ""
                        .branchText.Text = ""
                        .approvedDateText.Text = ""
                        .remarksText.Text = ""

                        .cpStatusText.Text = "Active"
                    End With
                Else
                    With encoderForm
                        .accountNumText.Text = ""
                        .ownerNameText.Text = ""
                        .checkLimitText.Text = ""
                        .bankNameText.Text = ""
                        .branchText.Text = ""
                        .approvedDateText.Text = ""
                        .remarksText.Text = ""

                        .cpStatusText.Text = "Active"
                    End With
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
    End Sub
    'selecting payors after add or edit accounts
    Sub selectingPayorAfterOrEditAccounts(ByVal id As String, ByVal whatDo As Integer)
        Dim selectdata As String = "SELECT  * " & _
                                    "FROM `check_payers_table`  " & _
                                    "WHERE  check_Payers_Id = ?search"

        cmd = New MySqlCommand(selectdata, con)

        cmd.Parameters.Add("?search", id)


        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            If dt.Rows.Count <> 0 Then


                For Each row In dt.Rows
                    accountNumberID.Clear()
                    If whatDo = 1 Then
                        Form2.busiNameText.Text = row("business_Name")
                        Form2.accountNumList.Items.Clear()
                    Else
                        encoderForm.busiNameText.Text = row("business_Name")
                        encoderForm.accountNumList.Items.Clear()
                    End If

                    Dim selectdata1 As String = "SELECT * " & _
                                    "FROM `account_number_table`  " & _
                                    "WHERE `check_payers_Id` = ?search "
                    cmd = New MySqlCommand(selectdata1, con)
                    cmd.Parameters.Add("?search", row("check_Payers_Id"))
                    adapter = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adapter.Fill(dt)



                    
                    If dt.Rows.Count <> 0 Then

                        If whatDo = 1 Then
                            For Each row2 In dt.Rows

                                With Form2.accountNumList

                                    Dim x As New ListViewItem

                                    x = .Items.Add(row2("account_Num"))

                                    x.SubItems.Add(row2("bank_Name"))
                                    x.SubItems.Add(row2("owners_Name"))
                                    If row2("Status") = "1" Then
                                        x.SubItems.Add("Active")
                                    Else
                                        x.SubItems.Add("Inactive")
                                    End If


                                    accountNumberID.Add(row2("account_Num_Id"))
                                End With

                            Next
                        Else
                            For Each row2 In dt.Rows

                                With encoderForm.accountNumList

                                    Dim x As New ListViewItem

                                    x = .Items.Add(row2("account_Num"))

                                    x.SubItems.Add(row2("bank_Name"))
                                    x.SubItems.Add(row2("owners_Name"))
                                    If row2("Status") = "1" Then
                                        x.SubItems.Add("Active")
                                    Else
                                        x.SubItems.Add("Inactive")
                                    End If


                                    accountNumberID.Add(row2("account_Num_Id"))
                                End With

                            Next
                        End If


                    End If


                Next

            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
    End Sub


    'the function is for the account number . 


    'check the account no. if exist or not
    Function checkAccountNumber(ByVal id As String)
        Dim owners As String = ""

        If id <> "" Then
            Dim validate As String = "SELECT `business_Name` FROM check_Payers_table WHERE `check_payers_Id` = ?id"

            cmd = New MySqlCommand(validate, con)
            cmd.Parameters.Add("?id", id)
            Dim count As String
            count = 0
            Try
                adapter = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adapter.Fill(dt)
                count = dt.Rows.Count

                If count > 0 Then
                    owners = dt.Rows(0).Item("business_Name")
                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else

        End If
        Return owners
    End Function

    Function validateAccountNumber(ByVal id As String, ByVal accnum As String)

        Dim result As String = ""
        Dim validate As String = "SELECT `check_Payers_Id` FROM account_Number_table WHERE `account_Num_Id`= ?id OR `account_Num` = ?accnum"

        cmd = New MySqlCommand(validate, con)
        cmd.Parameters.Add("?accnum", accnum)
        cmd.Parameters.Add("?id", id)
        Dim count As String
        count = 0
        Try
            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            count = dt.Rows.Count

            If count > 0 Then
                If id = "" Then
                    If count <> 0 Then
                        result = checkAccountNumber(dt.Rows(0).Item("check_Payers_Id").ToString)

                    End If

                ElseIf id <> "" Then
                    If count <> 1 Then
                        result = checkAccountNumber(dt.Rows(0).Item("check_Payers_Id").ToString)

                    End If
                End If

            Else
                result = ""
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return result

    End Function

    'validating the account numbers data
    Function accountNumCheck(ByVal acnid As String, ByVal accn As String, ByVal ck As String, ByVal bnkn As String, ByVal bnka As String, ByVal appd As DateTimePicker, ByVal rmrk As String, ByVal pyrs As String, ByVal ownName As String, ByVal cstat As ComboBox, ByVal whatdo As Integer)
        Dim result As Boolean



        Dim appdate As New DateTimePicker
        Dim textnull As String = "Please fill the blank : "

        If ownName = "" Then
            textnull += " Owners Name"
        End If
        If ck = "" Then
            textnull += ", Approved check Limit"
        End If
        If bnkn = "" Then
            textnull += ", Bank name"
        End If
        If bnka = "" Then
            textnull += ", Branch address"
        End If

        If appd.Checked = True Then
            appdate = appd
        End If

        If textnull <> "Please fill the blank : " Then
            MsgBox("Please Fill up the Following : " + textnull, MsgBoxStyle.Critical, "Fill up the Blank")
        Else
            prysID = pyrs
            accountNumber = accn
            checkLimit = ck
            bankName = bnkn
            branchAddress = bnka
            appd.Format = DateTimePickerFormat.Custom
            appd.CustomFormat = "yyyy-MM-dd"
            approvedDate = appd.Value
            remarks = rmrk
            ownersName = ownName

            acnstat = (cstat.SelectedIndex + 1).ToString
            If whatdo = 1 Then

                If checkPayorsModule.addAccountNumber() = True Then
                    result = True
                End If

            ElseIf whatdo = 2 Then
                If checkPayorsModule.editAccountNumber(acnid) = True Then
                    result = True
                End If

            End If

        End If


        Return result
    End Function
    'adding of ccheck account
    Function addAccountNumber()
        Dim result As Boolean = False
        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If

        Dim insertdata As String = "INSERT INTO account_number_table(check_Payers_Id,account_Num,owners_Name,app_Check_Limit,bank_Name,branch_Address,approved_Date,remarks,date_Input,status) " & _
            "  VALUES(?pyrs,?accn,?own,?cl,?bnk,?ba,?ad,?rem,?di,'1')"
        cmd = New MySqlCommand(insertdata, con)
        cmd.Parameters.Add("?pyrs", prysID)

        cmd.Parameters.Add("?accn", accountNumber)
        cmd.Parameters.Add("?cl", checkLimit)
        cmd.Parameters.Add("?own", ownersName)
        cmd.Parameters.Add("?bnk", bankName)
        cmd.Parameters.Add("?ba", branchAddress)
        cmd.Parameters.Add("?ad", approvedDate)
        cmd.Parameters.Add("?rem", remarks)
        cmd.Parameters.Add("?di", Now.Date + " " + TimeOfDay)


        Try
            If cmd.ExecuteNonQuery() > 0 Then

                result = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
        Return result
    End Function


    'editing detials of check account
    Function editAccountNumber(ByVal id As String)
        Dim result As Boolean = False
        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If

        Dim insertdata As String = "UPDATE account_number_table SET account_Num = ?accn ,owners_Name = ?own ,app_Check_Limit = ?cl " & _
            ",bank_Name = ?bnk ,branch_Address  = ?ba  ,approved_Date = ?ad ,remarks = ?rem  ,status = ?status WHERE `account_Num_id` = ?id  "

        cmd = New MySqlCommand(insertdata, con)

        cmd.Parameters.Add("?id", id)
        cmd.Parameters.Add("?accn", accountNumber)
        cmd.Parameters.Add("?cl", checkLimit)
        cmd.Parameters.Add("?own", ownersName)
        cmd.Parameters.Add("?bnk", bankName)
        cmd.Parameters.Add("?ba", branchAddress)
        cmd.Parameters.Add("?ad", approvedDate)
        cmd.Parameters.Add("?rem", remarks)
        cmd.Parameters.Add("?status", acnstat)



        Try
            If cmd.ExecuteNonQuery() > 0 Then

                result = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
        Return result
    End Function

    Sub selectingAccountNumber(ByVal intId As Integer, ByVal whatDo As Integer)
        Dim selectdata As String = "SELECT * FROM `account_number_table` WHERE `account_Num_Id` = ?search"
        cmd = New MySqlCommand(selectdata, con)

        cmd.Parameters.Add("?search", accountNumberID(intId + 1).ToString + "%")





        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            If dt.Rows.Count <> 0 Then
                If whatDo = 1 Then
                    With Form2
                        .accountNumText.Text = dt.Rows(0).Item(3)
                        .ownerNameText.Text = dt.Rows(0).Item(2)
                        .checkLimitText.Text = dt.Rows(0).Item(4)
                        .bankNameText.Text = dt.Rows(0).Item(5)
                        .branchText.Text = dt.Rows(0).Item(6)
                        .approvedDateText.Text = dt.Rows(0).Item(7)
                        .remarksText.Text = dt.Rows(0).Item(8)
                        If dt.Rows(0).Item(10) = "1" Then
                            .cpStatusText.Text = "Active"
                        Else
                            .cpStatusText.Text = "Inactive"
                        End If




                    End With
                Else
                    With encoderForm
                        .accountNumText.Text = dt.Rows(0).Item(3)
                        .ownerNameText.Text = dt.Rows(0).Item(2)
                        .checkLimitText.Text = dt.Rows(0).Item(4)
                        .bankNameText.Text = dt.Rows(0).Item(5)
                        .branchText.Text = dt.Rows(0).Item(6)
                        .approvedDateText.Text = dt.Rows(0).Item(7)
                        .remarksText.Text = dt.Rows(0).Item(8)
                        If dt.Rows(0).Item(10) = "1" Then
                            .cpStatusText.Text = "Active"
                        Else
                            .cpStatusText.Text = "Inactive"
                        End If
                    End With
                End If
               


            Else

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
    End Sub

    'editing the check payor
    Function editCheckPayor(ByVal bname As String, ByVal id As String)
        Dim result As Boolean = False
        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If

        Dim insertdata As String = "UPDATE `check_payers_table` SET `business_Name`=?bn WHERE `check_Payers_Id`= ?id"
        cmd = New MySqlCommand(insertdata, con)
        cmd.Parameters.Add("?bn", bname)
        cmd.Parameters.Add("?id", id)



        Try
            If cmd.ExecuteNonQuery() > 0 Then
                MsgBox("Account has been save! : " + bname.ToUpper, MsgBoxStyle.OkOnly, "")


                result = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
        Return result
    End Function
End Module
