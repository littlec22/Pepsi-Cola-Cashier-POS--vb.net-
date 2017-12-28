
Imports MySql.Data.MySqlClient
Public Class encoderForm

    ' fullname came from login to lessen the query in this form
    Public FULLNAME_ As String
    Public USERTYPE_ As String
    Public USERID_ As String

    'this is for Check payers ; if the value is 1 it's add, if 2 it's edit, if 0 nothing
    Private CPwhatdo As Integer = 0

    'this is for account number .. as array.. 
    Private accountNumberArray As New Collection

    'this is for payors list Pagination
    Private CPpaginatefrom As Integer
    Private Const CPpaginateto As Integer = 15
    Private payorSearchString As String = ""
    Private totalpayorscount As Integer

    Private Sub encoderForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        userLabel.Text = FULLNAME_



        Me.Cursor = Cursors.WaitCursor
        totalpayorscount = payorsCount("")
        CPpaginatefrom = 0

        loadingOfPayors(CPpaginatefrom, CPpaginateto, payorSearchString, 2)


        If totalpayorscount - CPpaginateto <= 0 Then
            payorsPaginateCounter.Text = CPpaginatefrom.ToString + "-" + totalpayorscount.ToString + "/" + totalpayorscount.ToString
        Else
            payorsPaginateCounter.Text = CPpaginatefrom.ToString + "-" + (CPpaginateto + CPpaginatefrom).ToString + "/" + totalpayorscount.ToString
        End If

        If CPpaginatefrom + 15 > totalpayorscount Then
            Button22.Visible = False
        End If
        Button21.Visible = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseHover
        Button5.BackgroundImage = Global.Pepsi_Cashier.My.Resources.Resources.logouthover
    End Sub



    Private Sub Button5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.MouseLeave
        Button5.BackgroundImage = Global.Pepsi_Cashier.My.Resources.Resources.logout
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

    'pagination button is heare
    'this is pagination next
    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click


        CPpaginatefrom += CPpaginateto

        loadingOfPayors(CPpaginatefrom, CPpaginateto, payorSearchString, 2)
        If totalpayorscount - (CPpaginatefrom + 15) <= 0 Then
            payorsPaginateCounter.Text = (CPpaginatefrom + 1).ToString + "-" + totalpayorscount.ToString + "/" + totalpayorscount.ToString
        Else
            payorsPaginateCounter.Text = (CPpaginatefrom + 1).ToString + "-" + (CPpaginateto + CPpaginatefrom).ToString + "/" + totalpayorscount.ToString
        End If


        Button21.Visible = True
        If CPpaginatefrom + CPpaginateto >= totalpayorscount Then
            Button22.Visible = False
        End If
    End Sub
    'this is pagination down
    Private Sub Button21_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        CPpaginatefrom -= CPpaginateto
        loadingOfPayors(CPpaginatefrom, CPpaginateto, payorSearchString, 2)
        If totalpayorscount - (CPpaginatefrom - 15) <= 0 Then
            payorsPaginateCounter.Text = (CPpaginatefrom + 1).ToString + "-" + totalpayorscount.ToString + "/" + totalpayorscount.ToString
        Else
            payorsPaginateCounter.Text = (CPpaginatefrom + 1).ToString + "-" + (CPpaginateto + CPpaginatefrom).ToString + "/" + totalpayorscount.ToString
        End If


        Button22.Visible = True
        If CPpaginatefrom - CPpaginateto < 0 Then
            Button21.Visible = False
        End If
    End Sub


    Private Sub addCP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addCP.Click
        If addCP.Text = "ADD BUSINESS ACCOUNT" Then
            addCP.Text = "SAVE"
            addCP.BackColor = Color.Green
            editCP.Text = "CANCEL"
            editCP.BackColor = Color.Maroon

            Panel35.Visible = False
            Panel31.Visible = False

            CPwhatdo = 1
        ElseIf addCP.Text = "SAVE" Then
            If CPwhatdo = 1 Then

                If checkPayorsModule.payorsChecking(busiNameText.Text) = True Then
                    addCP.Text = "ADD BUSINESS ACCOUNT"
                    addCP.BackColor = Color.Transparent
                    editCP.Text = "EDIT BUSINESS ACCOUNT"
                    editCP.BackColor = Color.Transparent


                    Panel35.Visible = True
                    Panel31.Visible = True

                    searchACA(busiNameText.Text)


                    If totalpayorscount - CPpaginateto <= 0 Then
                        payorsPaginateCounter.Text = CPpaginatefrom.ToString + "-" + totalpayorscount.ToString + "/" + totalpayorscount.ToString
                    Else
                        payorsPaginateCounter.Text = CPpaginatefrom.ToString + "-" + (CPpaginateto + CPpaginatefrom).ToString + "/" + totalpayorscount.ToString
                    End If

                    If CPpaginatefrom + 15 > totalpayorscount Then
                        Button22.Visible = False
                    End If


                    CPwhatdo = 0
                End If

            ElseIf CPwhatdo = 2 Then
                If busiNameText.Text <> "" Then
                    If checkPayorsModule.editCheckPayor(busiNameText.Text, checkPayorsModule.payorsID(Val(payorsIdSelected))) = True Then
                        payorsListView.Enabled = True

                        addCP.Text = "ADD BUSINESS ACCOUNT"
                        addCP.BackColor = Color.Transparent
                        editCP.Text = "EDIT BUSINESS ACCOUNT"
                        editCP.BackColor = Color.Transparent

                        Panel35.Visible = True
                        Panel31.Visible = True

                        searchACA(busiNameText.Text)


                        If totalpayorscount - CPpaginateto <= 0 Then
                            payorsPaginateCounter.Text = CPpaginatefrom.ToString + "-" + totalpayorscount.ToString + "/" + totalpayorscount.ToString
                        Else
                            payorsPaginateCounter.Text = CPpaginatefrom.ToString + "-" + (CPpaginateto + CPpaginatefrom).ToString + "/" + totalpayorscount.ToString
                        End If

                        If CPpaginatefrom + 15 > totalpayorscount Then
                            Button22.Visible = False
                        End If


                        CPwhatdo = 0
                    End If
                Else
                    MsgBox("Please enter the Business Name.", MsgBoxStyle.Critical, "")
                End If
            End If



        End If

    End Sub


    Private Sub editCP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editCP.Click
        If editCP.Text = "EDIT BUSINESS ACCOUNT" Then
            If payorsListView.SelectedItems.Count <> 0 Then

                payorsIdSelected = payorsListView.FocusedItem.Index
                payorsListView.Enabled = False
                addCP.Text = "SAVE"
                addCP.BackColor = Color.Green
                editCP.Text = "CANCEL"
                editCP.BackColor = Color.Maroon

                Panel35.Visible = False
                Panel31.Visible = False

                CPwhatdo = 2
            Else
                MsgBox("Please select Business Payors", MsgBoxStyle.Critical, "")
            End If
        ElseIf editCP.Text = "CANCEL" Then

            Panel35.Visible = True
            Panel31.Visible = True
            payorsListView.Enabled = True


            addCP.Text = "ADD BUSINESS ACCOUNT"
            addCP.BackColor = Color.Transparent
            editCP.Text = "EDIT BUSINESS ACCOUNT"
            editCP.BackColor = Color.Transparent
            cpStatusText.Enabled = False
            CPwhatdo = 0


        End If
    End Sub



    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ownersname As String = ""
        ownersname = checkPayorsModule.checkAccountNumber(accountNumText.Text)
        If ownersname <> "" Then
            MsgBox(accountNumText.Text + " is already exist, Owners name is : " + ownersname.ToUpper)
        Else

            With accountNumList
                Dim i As New ListViewItem
                i = .Items.Add(accountNumText.Text)
                i.SubItems.Add("Active")
                accountNumberArray.Add(accountNumText.Text)
            End With
        End If
    End Sub


    Private Sub payorsListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles payorsListView.SelectedIndexChanged
        If payorsListView.SelectedItems.Count <> 0 Then
            Dim accountCount As String = payorsListView.FocusedItem.SubItems(2).Text
            Dim business As String = payorsListView.FocusedItem.SubItems(1).Text
            If accountCount <> "0" Then
                Dim a As Integer = payorsListView.FocusedItem.Index
                If totalpayorscount >= a Then
                    checkPayorsModule.selectingPayorFromList(a.ToString, 2)
                End If
            Else
                busiNameText.Text = business
                checkPayorsModule.accountNumberID.Clear()
                accountNumList.Items.Clear()
                accountNumText.Text = ""
                ownerNameText.Text = ""
                checkLimitText.Text = ""
                bankNameText.Text = ""
                branchText.Text = ""
                approvedDateText.Text = ""
                remarksText.Text = ""

                cpStatusText.Text = "Active"
            End If
            

        End If
    End Sub

    Dim payorsIdSelected As String
    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        If Button14.Text = "SAVE" Then

            If CPwhatdo = 3 Then
                If accountNumText.Text <> "" Then
                    If validateAccountNumber("", accountNumText.Text) = "" Then

                        If accountNumCheck("", accountNumText.Text, checkLimitText.Text, bankNameText.Text, branchText.Text, approvedDateText, remarksText.Text, payorsIdSelected, ownerNameText.Text, cpStatusText, 1) = True Then
                            MsgBox("Account Number has been save", MsgBoxStyle.Information, "Saved")
                            checkPayorsModule.selectingPayorAfterOrEditAccounts(payorsIdSelected, 2)
                            accountNumList.Enabled = True

                            payorsListView.Enabled = True
                            cpStatusText.Enabled = True
                            editCP.Enabled = True
                            addCP.Enabled = True
                            Button14.Text = "Add Account Number"
                            Button13.Text = "Edit Account Number"
                            CPwhatdo = 0
                        End If


                    End If
                Else
                    MsgBox("Please Enter Account Number!", MsgBoxStyle.Critical, "")
                End If
            ElseIf CPwhatdo = 4 Then
                If accountNumText.Text <> "" Then
                    If validateAccountNumber(checkIdSelected, accountNumText.Text) = "" Then

                        If accountNumCheck(checkIdSelected, accountNumText.Text, checkLimitText.Text, bankNameText.Text, branchText.Text, approvedDateText, remarksText.Text, payorsIdSelected, ownerNameText.Text, cpStatusText, 2) = True Then
                            MsgBox("Account Number has been update", MsgBoxStyle.Information, "Saved")
                            checkPayorsModule.selectingPayorAfterOrEditAccounts(payorsIdSelected, 2)
                            accountNumList.Enabled = True

                            payorsListView.Enabled = True
                            cpStatusText.Enabled = True
                            editCP.Enabled = True
                            addCP.Enabled = True
                            Button14.Text = "Add Account Number"
                            Button13.Text = "Edit Account Number"
                            CPwhatdo = 0
                        End If


                    End If
                Else
                    MsgBox("Please Enter Account Number!", MsgBoxStyle.Critical, "")
                End If

            End If
        Else


            If payorsListView.SelectedItems.Count <> 0 Then
                payorsIdSelected = checkPayorsModule.payorsID(payorsListView.FocusedItem.Index + 1)
                payorsListView.Enabled = False
                accountNumList.Enabled = False
                addCP.Enabled = False
                editCP.Enabled = False

                cpStatusText.SelectedIndex = 0
                cpStatusText.Enabled = False
                Button14.Text = "SAVE"
                Button14.BackColor = Color.Green
                Button13.Text = "CANCEL"
                Button13.BackColor = Color.Maroon
                CPwhatdo = 3
            Else
                MsgBox("Please select payors.", MsgBoxStyle.Critical, "")

            End If



        End If
    End Sub
    Dim checkIdSelected As String
    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        If Button13.Text = "CANCEL" Then



            accountNumList.Enabled = True

            payorsListView.Enabled = True
            cpStatusText.Enabled = True
            editCP.Enabled = True
            addCP.Enabled = True
            Button14.Text = "Add Account Number"
            Button13.Text = "Edit Account Number"
            CPwhatdo = 0

        Else

            If accountNumList.SelectedItems.Count <> 0 Then
                checkIdSelected = checkPayorsModule.accountNumberID(accountNumList.FocusedItem.Index + 1)
                payorsListView.Enabled = False
                accountNumList.Enabled = False
                addCP.Enabled = False
                editCP.Enabled = False



                Button14.Text = "SAVE"
                Button14.BackColor = Color.Green
                Button13.Text = "CANCEL"
                Button13.BackColor = Color.Maroon
                CPwhatdo = 4
            Else
                MsgBox("Please select payors.", MsgBoxStyle.Critical, "")

            End If
        End If
    End Sub

    Private Sub accountNumList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles accountNumList.SelectedIndexChanged
        If accountNumList.SelectedItems.Count > 0 Then

            checkPayorsModule.selectingAccountNumber(accountNumList.FocusedItem.Index, 2)
        Else
            accountNumText.Text = ""
            ownerNameText.Text = ""
            checkLimitText.Text = ""
            bankNameText.Text = ""
            branchText.Text = ""
            approvedDateText.Text = ""
            remarksText.Text = ""

            cpStatusText.Text = "Active"
   
        End If
    End Sub
    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        searchACA(payorsSearchBox.Text)
    End Sub

    Sub searchACA(ByVal text As String)
        payorSearchString = text
        totalpayorscount = payorsCount(payorSearchString)
        CPpaginatefrom = 0

        loadingOfPayors(CPpaginatefrom, CPpaginateto, payorSearchString, 2)


        If totalpayorscount - CPpaginateto <= 0 Then
            payorsPaginateCounter.Text = CPpaginatefrom.ToString + "-" + totalpayorscount.ToString + "/" + totalpayorscount.ToString
        Else
            payorsPaginateCounter.Text = CPpaginatefrom.ToString + "-" + (CPpaginateto + CPpaginatefrom).ToString + "/" + totalpayorscount.ToString
        End If

        If CPpaginatefrom + 15 > totalpayorscount Then
            Button22.Visible = False
        Else
            Button22.Visible = True
        End If



        Button21.Visible = False
    End Sub

    Private Sub RefreshBusinessNameToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshBusinessNameToolStripMenuItem.Click

    End Sub

    Private Sub Panel13_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel13.Paint

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class