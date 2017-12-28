Imports MySql.Data.MySqlClient

Public Class editTransactionForm


    'collection of business name... nilalagyan to ng laman sa transactiomodule.. 
    Public mysource As New AutoCompleteStringCollection()

    Private trans_Detail_ID As New Collection
    'this is the key_id of the transaction in transaction key table : ex. 2017-1
    Public trans_Key_ID As String

    'this is the key_id of the transaction in transaction detail table : ex. 1 , 2 ,3
    Public trans_Key_Details As String

    'this is for transaction
    Private looping As Integer
    Private account_Check_Payment_Info As New Collection
    Private account_Check_Number_Info As New Collection
    Private account_Check_Payment_Limit As New Collection

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
        transaction_Search.Show()

    End Sub
    Private Sub Button3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseHover
        Button3.ForeColor = Color.Red
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.ForeColor = Color.White
    End Sub

    Private Sub Panel6_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub editTransactionForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox1.AutoCompleteCustomSource = mysource
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource
        loadingOfDateofTrans()

        
    End Sub

    Sub loadingOfDateofTrans()
        Dim selectdata As String = "SELECT `trans_Id`,`date`,`trans_Key_Id` FROM " & _
            " `transaction_details_table` WHERE  `trans_Key_Id` = any(SELECT `Id` FROM `transaction_key_table` WHERE `trans_Id` = ?search ) ORDER BY `trans_Id` DESC"


        cmd = New MySqlCommand(selectdata, con)
        cmd.Parameters.Add("?search", trans_Key_ID)

        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)

            If dt.Rows.Count <> 0 Then
                ComboBox1.Items.Clear()
                trans_Detail_ID.Clear()
                Dim i As Integer = 1

                For Each row In dt.Rows
                    trans_Detail_ID.Add(row(0))
                    ComboBox1.Items.Add((i).ToString + ". " + row(1).ToString)
                    trans_Key_Details = (row(2))
                    i += 1
                Next
                ComboBox1.SelectedIndex = 0

            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try




        con.Close()
    End Sub
    Sub loadingDetailsTransaction()
        Dim comboIndex As Integer = ComboBox1.SelectedIndex + 1

        Dim selectdata2 As String = "SELECT `transaction_details_table`.`trans_Id` ,  " & _
          " usertable.`firstName` , usertable.`middlename`,usertable.`lastName`, " & _
          " `transaction_details_table`.`pd_Number`, `transaction_details_table`.`settler_Name`," & _
          " `transaction_details_table`.`date`," & _
          "paymentCash.`1000`, paymentCash.`500`, paymentCash.`200`, paymentCash.`100`, paymentCash.`50`," & _
          " paymentCash.`20`, paymentCash.`10`, paymentCash.`5`, paymentCash.`1`,paymentCash.`.25`,paymentCash.`.10` ,paymentCash.`other` " & _
          " FROM `transaction_details_table` LEFT JOIN (SELECT `trans_Id`,`1000`,`500`," & _
          " `200`,`100`,`50`,`20`,`10`,`5`,`1`,`other`,`.25`,`.10` " & _
          " FROM `trans_payment_cash`) as paymentCash ON `transaction_details_table`.`trans_Id` = " & _
          "paymentCash.`trans_ID` LEFT JOIN (SELECT userID,firstName,middleName,lastName FROM user_Table )as usertable ON `transaction_details_table`.`teller_Id` " & _
          " = usertable.`userId` WHERE `transaction_details_table`.`trans_Id` = ?id ORDER BY trans_Id DESC LIMIT 1"

        cmd = New MySqlCommand(selectdata2, con)
        cmd.Parameters.Add("?id", trans_Detail_ID(comboIndex))

        adapter = New MySqlDataAdapter(cmd)
        dt = New DataTable
        adapter.Fill(dt)


        If dt.Rows.Count <> 0 Then


            userLabel.Text = dt.Rows(0).Item("firstName") + " " + dt.Rows(0).Item("middleName") + ". " + dt.Rows(0).Item("lastName")
            DateTimePicker1.Value = dt.Rows(0).Item("date")
            TextBox5.Text = dt.Rows(0).Item("settler_Name")
            TextBox6.Text = dt.Rows(0).Item("pd_Number")
            q1000.Text = dt.Rows(0).Item("1000")
            q500.Text = dt.Rows(0).Item("500")
            q200.Text = dt.Rows(0).Item("200")
            q100.Text = dt.Rows(0).Item("100")
            q50.Text = dt.Rows(0).Item("50")
            q20.Text = dt.Rows(0).Item("20")
            q10.Text = dt.Rows(0).Item("10")
            q5.Text = dt.Rows(0).Item("5")
            q1.Text = dt.Rows(0).Item("1")
            q25cents.Text = dt.Rows(0).Item(".25")
            q10cents.Text = dt.Rows(0).Item(".10")
            qothers.Text = dt.Rows(0).Item("other")

            Dim selectdata3 As String = "SELECT  `account_Num`, `amount`,`account_num_series`,`account_Num_Info`,`account_Limit` FROM trans_payment_check WHERE trans_Id = ?id"
            cmd = New MySqlCommand(selectdata3, con)
            cmd.Parameters.Add("?id", dt.Rows(0).Item("trans_Id"))

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            If dt.Rows.Count <> 0 Then
                paymentAccountList.Items.Clear()
                For Each row In dt.Rows
                    With paymentAccountList
                        Dim i As ListViewItem

                        i = .Items.Add(row(0).ToString)
                        i.SubItems.Add(row(2).ToString)
                        i.SubItems.Add(row(1).ToString)
                        account_Check_Payment_Info.Add(row(3).ToString)

                        account_Check_Payment_Limit.Add(row(4).ToString)

                    End With

                Next
                totalC.Text = computeCheckInEdit()
            End If

           


        End If
    End Sub


    'this part is for the computing grand total of all bills and coin and check
    'every change of text in the textbox it will works.

    Private Sub totalBC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If looping <> 2 Then
            looping += 1
        Else
            Dim total As Double
            total += FormatCurrency(FormatCurrency(totalBC.Text))
            total += FormatCurrency(FormatCurrency(totalC.Text))
            grandTotal.Text = FormatCurrency(total.ToString)
            If Val(FormatCurrency(totalBC.Text)) <> 0 And Val(FormatCurrency(totalBC.Text)) Then
                paymentTypeLabel.Text = "MIXED"
            ElseIf Val(FormatCurrency(totalBC.Text)) Then
                paymentTypeLabel.Text = "CASH"
            Else
                paymentTypeLabel.Text = "CHECK"
            End If
        End If

    End Sub

    Private Sub totalC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If looping <> 2 Then
            looping += 1
        Else
            Dim total As Double
            total += FormatCurrency(FormatCurrency(totalBC.Text))
            total += FormatCurrency(FormatCurrency(totalC.Text))
            grandTotal.Text = FormatCurrency(total.ToString)

        End If
    End Sub

    Function computeBC() As Double
        Dim total As Double
        If v1000.Text = "" Or v500.Text = "" Or v200.Text = "" Or v100.Text = "" Or v50.Text = "" Or v20.Text = "" Or v10.Text = "" Or
            v5.Text = "" Or v1.Text = "" Or v25cents.Text = "" Or v10cents.Text = "" Or vothers.Text = "" Then
        Else
            total += FormatCurrency(FormatCurrency(v1000.Text))
            total += FormatCurrency(FormatCurrency(v500.Text))
            total += FormatCurrency(FormatCurrency(v200.Text))
            total += FormatCurrency(FormatCurrency(v100.Text))
            total += FormatCurrency(FormatCurrency(v50.Text))
            total += FormatCurrency(FormatCurrency(v20.Text))
            total += FormatCurrency(FormatCurrency(v10.Text))
            total += FormatCurrency(FormatCurrency(v5.Text))
            total += FormatCurrency(FormatCurrency(v1.Text))
            total += FormatCurrency(FormatCurrency(v25cents.Text))
            total += FormatCurrency(FormatCurrency(v10cents.Text))
            total += FormatCurrency(FormatCurrency(vothers.Text))
        End If
        Return total
    End Function
    Function computeCheck() As Double
        Dim total As Double
        Dim x As Double = 0
        For i = 0 To paymentAccountList.Items.Count - 1 Step 1

            x += Val(paymentAccountList.Items(i).SubItems(2).Text)
            MsgBox(x)
        Next
        total = x
        MsgBox(total)

        Return total
    End Function


    Private Sub v1000_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v1000.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub q1000_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q1000.Leave
        v1000.Text = FormatCurrency(Val(q1000.Text) * 1000)
    End Sub
    Private Sub q500_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q500.Leave
        v500.Text = FormatCurrency(Val(q500.Text) * 500)
    End Sub
    Private Sub q200_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q200.Leave
        v200.Text = FormatCurrency(Val(q200.Text) * 200)
    End Sub
    Private Sub q100_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q100.Leave
        v100.Text = FormatCurrency(Val(q100.Text) * 100)
    End Sub
    Private Sub q50_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q50.Leave
        v50.Text = FormatCurrency(Val(q50.Text) * 50)
    End Sub
    Private Sub q20_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q20.Leave
        v20.Text = FormatCurrency(Val(q20.Text) * 20)
    End Sub
    Private Sub q10_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q10.Leave
        v10.Text = FormatCurrency(Val(q10.Text) * 10)
    End Sub
    Private Sub q5_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q5.Leave
        v5.Text = FormatCurrency(Val(q5.Text) * 5)
    End Sub
    Private Sub q1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q1.Leave
        v1.Text = FormatCurrency(Val(q1.Text) * 1)
    End Sub
    Private Sub q25cents_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q25cents.Leave
        v25cents.Text = FormatCurrency(Val(q25cents.Text) * 0.25)
    End Sub
    Private Sub q10cents_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles q10cents.Leave
        v10cents.Text = FormatCurrency(Val(q10cents.Text) * 0.1)
    End Sub
    Private Sub qothers_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles qothers.Leave
        vothers.Text = FormatCurrency(Val(qothers.Text))
    End Sub

    Private Sub v500_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v500.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v200_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v200.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v100_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v100.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v50_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v50.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v20.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v10.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v5.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v1.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v25cents_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v25cents.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub vothers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vothers.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)
    End Sub

    Private Sub v10cents_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v10cents.TextChanged
        totalBC.Text = FormatCurrency(computeBC().ToString)


    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        loadingDetailsTransaction()
        v1000.Text = FormatCurrency(Val(q1000.Text) * 1000)
        v500.Text = FormatCurrency(Val(q500.Text) * 500)
        v200.Text = FormatCurrency(Val(q200.Text) * 200)
        v100.Text = FormatCurrency(Val(q100.Text) * 100)
        v50.Text = FormatCurrency(Val(q50.Text) * 50)
        v20.Text = FormatCurrency(Val(q20.Text) * 20)
        v10.Text = FormatCurrency(Val(q10.Text) * 10)
        v5.Text = FormatCurrency(Val(q5.Text) * 5)
        v1.Text = FormatCurrency(Val(q1.Text) * 1)
        v25cents.Text = FormatCurrency(Val(q25cents.Text) * 0.25)
        v10cents.Text = FormatCurrency(Val(q10cents.Text) * 0.1)
        vothers.Text = FormatCurrency(Val(qothers.Text))

    End Sub

    Private Sub paymentAccountList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles paymentAccountList.SelectedIndexChanged

    End Sub
    Function computeCheckInEdit() As Double
        Dim total As Double
        Dim x As Double = 0
        For i = 0 To paymentAccountList.Items.Count - 1 Step 1

            x += Val(paymentAccountList.Items(i).SubItems(2).Text)
        Next
        total = x
        Return total
    End Function

   

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button9.Visible = False
        Button8.Text = "Update"
        DateTimePicker1.Enabled = False

        ComboBox1.Enabled = True
        TextBox1.Enabled = False
        accountNumAmount.Enabled = False
        accountNumAmount.Enabled = False
        Button7.Enabled = False
        loadingDetailsTransaction()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            searchingPayorsAccountOnTransactionPage()


        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        searchingPayorsAccountOnTransactionPage()
    End Sub
    Sub searchingPayorsAccountOnTransactionPage()

        Dim searchCheckAccount As String = TextBox1.Text


        Dim searchData As String = "SELECT `account_number_table`.`account_Num_Id` , `account_number_table`.`account_Num` FROM `account_number_table` LEFT JOIN `check_payers_table` ON `account_number_table`.`check_Payers_Id` = `check_payers_table`.`check_Payers_Id` WHERE `check_payers_table`.`business_Name` = ?search "

        cmd = New MySqlCommand(searchData, con)
        cmd.Parameters.Add("?search", searchCheckAccount)
        Dim count As Integer

        Try
            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            count = dt.Rows.Count
            transAccountNum.Items.Clear()
            If count <> 0 Then


                For Each row In dt.Rows
                    transAccountNum.Items.Add(row(1).ToString)

                Next
                transAccountNum.SelectedIndex = 0
            Else
                transAccountNum.Text = "No Account Number!"
            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub transAccountNum_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles transAccountNum.TextChanged
        If transAccountNum.Text <> "No Account Number!" Or transAccountNum.SelectedIndex <> -1 Or transAccountNum.Items.Count <> 0 Then
            Dim searchCheckAccount As String = transAccountNum.Text


            Dim searchData As String = "SELECT `account_number_table`.`bank_Name` ,`account_number_table`.`branch_Address`, `account_number_table`.`app_check_Limit` FROM `account_number_table`  WHERE `account_number_table`.`account_Num` = ?search limit 1"
            cmd = New MySqlCommand(searchData, con)
            cmd.Parameters.Add("?search", searchCheckAccount)
            Dim count As Integer

            Try
                adapter = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adapter.Fill(dt)
                count = dt.Rows.Count

                If count <> 0 Then

                    For Each row In dt.Rows

                        Label95.Text = row(0).ToString.ToUpper
                        Label96.Text = row(1).ToString.ToUpper
                        Label98.Text = row(2).ToString

                    Next

                Else
                    Label95.Text = "None"
                    Label96.Text = "None"
                    Label98.Text = "None"

                End If

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            Label95.Text = "None"
            Label96.Text = "None"
            Label98.Text = "None"
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If transAccountNum.Text <> "No Account Number!" Or transAccountNum.SelectedIndex <> -1 Or transAccountNum.Items.Count <> 0 Then
            If Val(accountNumAmount.Text) <> 0 Then

                If (TextBox2.Text.Length <= 25) Then
                    If Val(Label98.Text) >= Val(accountNumAmount.Text) Then
                        Dim i As New ListViewItem

                        i = paymentAccountList.Items.Add(transAccountNum.SelectedItem.ToString)
                        i.SubItems.Add(TextBox2.Text)
                        i.SubItems.Add(accountNumAmount.Text)

                        account_Check_Payment_Info.Add(Label95.Text + " - " + TextBox1.Text)
                        account_Check_Payment_Limit.Add(Label98.Text)
                        TextBox2.Text = ""
                        totalC.Text = FormatCurrency(FormatCurrency(computeCheck()))
                    Else
                        If MsgBox("The input amount is exceed to the limit, do you want to accept it?", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then
                            Dim i As New ListViewItem
                            i = paymentAccountList.Items.Add(transAccountNum.SelectedItem.ToString)
                            i.SubItems.Add(TextBox2.Text)
                            i.SubItems.Add(accountNumAmount.Text)
                            account_Check_Payment_Info.Add(Label95.Text + " - " + TextBox1.Text)
                            account_Check_Payment_Limit.Add(Label98.Text)
                            TextBox2.Text = ""
                            totalC.Text = FormatCurrency(FormatCurrency(computeCheck()))
                        End If

                    End If
                Else
                    MsgBox("The Check Number is too long, requirement 25 characters less than.", MsgBoxStyle.Critical, "")
                End If

            Else
                MsgBox("Please enter amount!", MsgBoxStyle.Critical, "")
            End If
        Else
            MsgBox("Please select account number!", MsgBoxStyle.Critical, "")
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try


            If paymentAccountList.SelectedItems.Count <> 0 Then
                Dim i As Integer = paymentAccountList.FocusedItem.Index

                account_Check_Payment_Info.Remove(i + 1)

                account_Check_Payment_Limit.Remove(i + 1)
                paymentAccountList.FocusedItem.Remove()
                totalC.Text = FormatCurrency(FormatCurrency(computeCheck()))
            Else
                MsgBox("Please select account number!", MsgBoxStyle.Critical, "")
            End If
        Catch ex As Exception
            MsgBox("err.. Please try remove again." + ex.Message, MsgBoxStyle.Information, "")
        End Try
    End Sub

    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If Button8.Text = "Update" Then

            Button9.Visible = True
            Button8.Text = "Save"
            DateTimePicker1.Enabled = True
            DateTimePicker1.Value = Now
            ComboBox1.Enabled = False
            TextBox1.Enabled = True
            TextBox5.Enabled = True
            TextBox6.Enabled = True
            transAccountNum.Enabled = True
            accountNumAmount.Enabled = True
            Button7.Enabled = True
            userLabel.Text = Form2.userLabel.Text
        Else

                 If (FormatCurrency(grandTotal.Text)) <> 0 Then
                        If TextBox5.Text <> "" Then
                            If TextBox6.Text <> "" Then
                                Dim msgresult = MsgBox("Are you sure to update Transaction with ID : " + Label4.Text + " ?", MsgBoxStyle.YesNo, "")
                                If msgresult = MsgBoxResult.Yes Then
                                    Dim transDetail As New Collection
                                    Dim paymentQuantity As New Collection
                                    Dim paymentCheckAccount As New Collection
                                    Dim paymentCheckAmount As New Collection

                                    transDetail.Add(Form2.USERID_)


                              

                            transDetail.Add(DateTimePicker1.Text)
                                    transDetail.Add(TextBox5.Text)
                                    transDetail.Add(TextBox6.Text)
                                    If Val(q1000.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q1000.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q500.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q500.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q200.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q200.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q100.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q100.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q50.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q50.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q20.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q20.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q10.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q10.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q5.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q5.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q1.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q1.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q25cents.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q25cents.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(q10cents.Text) <> 0 Then
                                        paymentQuantity.Add(Val(q10cents.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If Val(qothers.Text) <> 0 Then
                                        paymentQuantity.Add(Val(qothers.Text))
                                    Else
                                        paymentQuantity.Add("0")
                                    End If
                                    If paymentAccountList.Items.Count <> 0 Then
                                        Dim row As New ListViewItem
                                        For Each row In paymentAccountList.Items
                                    paymentCheckAmount.Add(Val(row.SubItems(2).Text))
                                    account_Check_Number_Info.Add(row.SubItems(1).Text)
                                    paymentCheckAccount.Add(row.SubItems(0).Text)
                                        Next
                                    End If

                            If insertingEditedTransaction(paymentQuantity, paymentCheckAccount, paymentCheckAmount,
                                     account_Check_Payment_Info, account_Check_Number_Info, account_Check_Payment_Limit, transDetail) = True Then
                                Button9.Visible = False
                                Button8.Text = "Update"
                                DateTimePicker1.Enabled = False

                                ComboBox1.Enabled = True
                                TextBox1.Enabled = False
                                accountNumAmount.Enabled = False
                                accountNumAmount.Enabled = False
                                Button7.Enabled = False
                                account_Check_Payment_Info.Clear()
                                account_Check_Number_Info.Clear()
                                account_Check_Payment_Limit.Clear()
                                loadingOfDateofTrans()
                            End If
                                End If


                            Else
                                MsgBox("Please enter PD Number.", MsgBoxStyle.Critical, "")
                            End If


                        Else
                            MsgBox("Please enter settler name.", MsgBoxStyle.Critical, "")
                        End If


                    Else
                        MsgBox("Grand Total is equal to Zero, it's impossible to save the transaction!", MsgBoxStyle.Critical, "")
                    End If




               
        End If
    End Sub

    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Button9.Visible = False
        Button8.Text = "Update"
      
        ComboBox1.Enabled = True
        TextBox1.Enabled = False
        TextBox5.Enabled = False
        TextBox6.Enabled = False
        transAccountNum.Enabled = False
        accountNumAmount.Enabled = False
        Button7.Enabled = False
        loadingOfDateofTrans()
    End Sub

    Private Sub totalBC_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalBC.TextChanged

        If looping <> 2 Then
            looping += 1
        Else
            Dim total As Double
            total += FormatCurrency(FormatCurrency(totalBC.Text))
            total += FormatCurrency(FormatCurrency(totalC.Text))
            grandTotal.Text = FormatCurrency(total.ToString)

        End If
    End Sub

    Private Sub totalC_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalC.TextChanged
        If looping <> 2 Then
            looping += 1
        Else
            Dim total As Double
            total += FormatCurrency(FormatCurrency(totalBC.Text))
            total += FormatCurrency(FormatCurrency(totalC.Text))
            grandTotal.Text = FormatCurrency(total.ToString)

        End If
    End Sub
End Class