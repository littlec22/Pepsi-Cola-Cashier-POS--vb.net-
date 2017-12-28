Imports MySql.Data.MySqlClient

Public Class staffFormvb
    'collection of business name... nilalagyan to ng laman sa transactiomodule.. 
    Public mysource As New AutoCompleteStringCollection()

    'this is the id of key tables
    Public IDKEYTABLE As String = ""
    'this is for user information given by the form1(login form)
    ' fullname came from login to lessen the query in this form
    Public FULLNAME_ As String
    Public USERTYPE_ As String
    Public USERID_ As String


    'this is for transaction
    Private looping As Integer
    Private account_Check_Payment_Info As New Collection

    Private account_Check_Payment_Limit As New Collection

   




    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Button1.BackColor = Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer))
        Button2.BackColor = Color.Transparent

        Panel36.BackColor = Color.White
        Panel37.BackColor = Color.Transparent

        Me.Dispose()
        Form1.Show()

    End Sub

    'selecting a tab
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TabControl1.SelectedTab = reportPage
        Button1.BackColor = Color.Transparent
        Button2.BackColor = Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer))

        Panel36.BackColor = Color.Transparent
        Panel37.BackColor = Color.White



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TabControl1.SelectedTab = transactionPage
        Button1.BackColor = Color.FromArgb(CType(CType(1, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(50, Byte), Integer))
        Button2.BackColor = Color.Transparent

        Panel36.BackColor = Color.White
        Panel37.BackColor = Color.Transparent



    End Sub

    
   
    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Pepsi_Cashier.Form1.Close()
    End Sub


    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        userLabel.Text = FULLNAME_

        generateTransId1()
        TextBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        TextBox1.AutoCompleteCustomSource = mysource
        TextBox1.AutoCompleteSource = AutoCompleteSource.CustomSource


    End Sub
    'this part is for the computing grand total of all bills and coin and check
    'every change of text in the textbox it will works.

    Private Sub totalBC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalBC.TextChanged

        If looping <> 2 Then
            looping += 1
        Else
            Dim total As Double
            total += FormatCurrency(FormatCurrency(totalBC.Text))
            total += FormatCurrency(FormatCurrency(totalC.Text))
            grandTotal.Text = FormatCurrency(total.ToString)

        End If

    End Sub

    Private Sub totalC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles totalC.TextChanged
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
        Next
        total = x
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

    Private Sub v500_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v500.Leave
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

    Private Sub v20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles v1000.TextChanged
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











    'this is for searching the account number of payors if they enter or leave the textbox
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

    Private Sub transAccountNum_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles transAccountNum.SelectedValueChanged

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

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click


        If (FormatCurrency(grandTotal.Text)) <> 0 Then
            If TextBox5.Text <> "" Then
                If TextBox6.Text <> "" Then
                    Dim msgresult = MsgBox("Do you want to save the transaction?", MsgBoxStyle.YesNo, "")
                    If msgresult = MsgBoxResult.Yes Then
                        Dim transDetail As New Collection
                        Dim paymentQuantity As New Collection
                        Dim paymentCheckAccount As New Collection
                        Dim paymentCheckAmount As New Collection
                        Dim paymentCheckInfo As New Collection
                        Dim paymentCheckLimit As New Collection
                        Dim account_Check_Number_Info As New Collection
                        transDetail.Add(USERID_)
                        transDetail.Add(transIdText.Text)

                      

                        transDetail.Add(DateTimePicker1.Text)
                        transDetail.Add(TextBox5.Text)
                        transDetail.Add(TextBox6.Text)
                        transDetail.Add(Me.IDKEYTABLE)


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
                                paymentCheckAccount.Add(row.SubItems(0).Text)
                                account_Check_Number_Info.Add(row.SubItems(1).Text)
                            Next
                        End If

                        If insertingTransaction(paymentQuantity, paymentCheckAccount, paymentCheckAmount,
                                             account_Check_Payment_Info, account_Check_Number_Info, account_Check_Payment_Limit, transDetail) = True Then
                            transReset()
                            account_Check_Payment_Info.Clear()
                            account_Check_Number_Info.Clear()
                            account_Check_Payment_Limit.Clear()
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


    End Sub

 

    Private Sub Button5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseHover
        Button5.BackgroundImage = Global.Pepsi_Cashier.My.Resources.Resources.logouthover
    End Sub



    Private Sub Button5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        Button5.BackgroundImage = Global.Pepsi_Cashier.My.Resources.Resources.logout
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
            MsgBox("err.. Please try remove again.", MsgBoxStyle.Information, "")
        End Try
    End Sub


    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        transaction_Search.hrefPage = 2
        transaction_Search.Show()
        Me.Hide()

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        transReset()
    End Sub
    Sub transReset()
       
        TextBox5.Text = ""
        TextBox6.Text = ""
        q1000.Text = ""
        q500.Text = ""
        q200.Text = ""
        q100.Text = ""
        q50.Text = ""
        q20.Text = ""
        q10.Text = ""
        q5.Text = ""
        q1.Text = ""

        q25cents.Text = ""
        q10cents.Text = ""
        qothers.Text = ""
        TextBox1.Text = ""

        TextBox5.Text = ""
        TextBox6.Text = ""
        v1000.Text = "0"
        v500.Text = "0"
        v200.Text = "0"
        v100.Text = "0"
        v50.Text = "0"
        v20.Text = "0"
        v10.Text = "0"
        v5.Text = "0"
        v1.Text = "0"

        v25cents.Text = "0"
        v10cents.Text = "0"
        vothers.Text = "0"
        TextBox1.Text = ""
        transAccountNum.SelectedIndex = -1
        accountNumAmount.Text = "0"
        paymentAccountList.Items.Clear()
        account_Check_Payment_Limit.Clear()
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
    Private Sub Button19_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button19.MouseHover
        Button19.ForeColor = Color.Red
        Button19.FlatAppearance.BorderSize = 1
    End Sub

    Private Sub Button19_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button19.MouseLeave
        Button19.ForeColor = Color.Black
        Button19.FlatAppearance.BorderSize = 0
    End Sub



    

    Public reportDatasetWhat As Integer = 0

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Cursor = Cursors.WaitCursor



        Panel1.Enabled = False
        Panel5.Enabled = False
        Panel16.Enabled = False
        Panel17.Enabled = False

        transReport.ReportViewer1.Clear()
        reportDatasetWhat = 1
        reportModule.transactionReport(DateTimePicker2)
        Me.Cursor = Cursors.Default
        reportDatasetWhat = 0
        Panel1.Enabled = True
        Panel5.Enabled = True
        Panel16.Enabled = True
        Panel17.Enabled = True
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.Cursor = Cursors.WaitCursor

        Panel1.Enabled = False
        Panel5.Enabled = False
        Panel16.Enabled = False
        Panel17.Enabled = False

        transReport.ReportViewer1.Clear()
        reportDatasetWhat = 2
        reportModule.billsAndCoinReport(DateTimePicker5)
        reportDatasetWhat = 0
        Me.Cursor = Cursors.Default
        Panel1.Enabled = True
        Panel5.Enabled = True
        Panel16.Enabled = True
        Panel17.Enabled = True
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.Cursor = Cursors.WaitCursor

        Panel1.Enabled = False
        Panel5.Enabled = False
        Panel16.Enabled = False
        Panel17.Enabled = False
        transReport.ReportViewer1.Clear()
        reportDatasetWhat = 3
        reportModule.checkReport(DateTimePicker7)
        reportDatasetWhat = 0
        Me.Cursor = Cursors.Default
        Panel1.Enabled = True
        Panel5.Enabled = True
        Panel16.Enabled = True
        Panel17.Enabled = True
    End Sub

    Private Sub grandTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grandTotal.TextChanged
        If looping <> 2 Then
            looping += 1
        Else
            If FormatCurrency(FormatCurrency(totalBC.Text)) <> 0 AndAlso FormatCurrency(FormatCurrency(totalC.Text)) <> 0 Then

                paymentTypeLabel.Text = "Mixed"
            ElseIf FormatCurrency(FormatCurrency(totalBC.Text)) <> 0 Then
                paymentTypeLabel.Text = "Cash"
            ElseIf FormatCurrency(FormatCurrency(totalC.Text)) <> 0 Then
                paymentTypeLabel.Text = "Check"

            End If
        End If
    End Sub

    Private Sub RefreshBusinessNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshBusinessNameToolStripMenuItem.Click
        fillingMySourceForTransPage(2)
    End Sub


    
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class