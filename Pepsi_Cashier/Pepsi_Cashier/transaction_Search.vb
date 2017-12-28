Imports MySql.Data.MySqlClient

Public Class transaction_Search

    'this is for list Pagination
    Private Spaginatefrom As Integer
    Private Const Spaginateto As Integer = 15
    Private searchSearchString As String = ""
    Private totalSearchcount As Double

    Public hrefPage As Integer

#Region "Loading transaction"

    Sub loadTransactionKeyDetail()

    End Sub

#End Region

    Private Sub transaction_Search_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter

    End Sub

    Private Sub transaction_Search_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If hrefPage = 1 Then
            Form2.Show()
        ElseIf hrefPage = 2 Then
            staffFormvb.Show()
        End If

    End Sub
    Private Sub transaction_Search_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePicker1.Checked = False
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy-MM-dd"
        totalSearchcount = transCount("", DateTimePicker1)

        Spaginatefrom = 0
        loadingOfTransaction(Spaginatefrom, Spaginateto, "", DateTimePicker1)



        If totalSearchcount - Spaginateto <= 0 Then
            searchPaginateCounter.Text = Spaginatefrom.ToString + "-" + totalSearchcount.ToString + "/" + totalSearchcount.ToString
        Else
            searchPaginateCounter.Text = Spaginatefrom.ToString + "-" + (Spaginateto + Spaginatefrom).ToString + "/" + totalSearchcount.ToString
        End If

        If Spaginatefrom + 15 > totalSearchcount Then
            Button22.Visible = False
        End If
        Button21.Visible = False



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Me.Close()
    End Sub

    Private Sub Button3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseHover
        Button3.ForeColor = Color.Red
    End Sub

    Private Sub Button3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.MouseLeave
        Button3.ForeColor = Color.White
    End Sub


    

    Private Sub transSearchBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles transSearchBox.TextChanged
        totalSearchcount = transCount(transSearchBox.Text, DateTimePicker1)

        Spaginatefrom = 0
        loadingOfTransaction(Spaginatefrom, Spaginateto, transSearchBox.Text, DateTimePicker1)



        If totalSearchcount - Spaginateto <= 0 Then
            searchPaginateCounter.Text = Spaginatefrom.ToString + "-" + totalSearchcount.ToString + "/" + totalSearchcount.ToString
        Else
            searchPaginateCounter.Text = Spaginatefrom.ToString + "-" + (Spaginateto + Spaginatefrom).ToString + "/" + totalSearchcount.ToString
        End If

        If Spaginatefrom + 15 > totalSearchcount Then
            Button22.Visible = False
        End If
        Button21.Visible = False

    End Sub

    Private Sub addCP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles viewDetails.Click
        If transListView.SelectedItems.Count <> 0 Then

            Dim selectedTrans_ID As String = transListView.FocusedItem.SubItems(0).Text
            Dim selectedTransDetail_ID As String = transListView.FocusedItem.Index

            editTransactionForm.Label4.Text = selectedTrans_ID
            editTransactionForm.trans_Key_ID = selectedTrans_ID
            editTransactionForm.Show()
            Me.Hide()

        Else
            MsgBox("Please select a transaction", MsgBoxStyle.Critical, "Select Index err")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If transListView.SelectedItems.Count <> 0 Then

          

       


        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If
        Dim selectedTrans_ID As String = transListView.FocusedItem.SubItems(0).Text
        If MsgBox("Are you sure to void transaction with ID = " + selectedTrans_ID + "? , if you void this, you'll never see it again.", MsgBoxStyle.YesNo, "") = MsgBoxResult.Yes Then



            Try
                Dim insertdata As String = "UPDATE `transaction_key_table` SET `status`= '0' WHERE `trans_Id` = ?search  "

                cmd = New MySqlCommand(insertdata, con)
                cmd.Parameters.Add("?search", selectedTrans_ID)



                If cmd.ExecuteNonQuery() > 0 Then
                    MsgBox("Transaction has been void, you never see it again!", MsgBoxStyle.Information, "")
                    loadingOfTransaction(0, 0, "", DateTimePicker1)
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            con.Close()
            End If
        Else
            MsgBox("Please select a transaction", MsgBoxStyle.Critical, "Select Transaction err")
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        Spaginatefrom = 0
        If DateTimePicker1.Checked = True Then
            totalSearchcount = transCount(transSearchBox.Text, DateTimePicker1)

            Spaginatefrom = 0
            loadingOfTransaction(Spaginatefrom, Spaginateto, transSearchBox.Text, DateTimePicker1)



            If totalSearchcount - Spaginateto <= 0 Then
                searchPaginateCounter.Text = Spaginatefrom.ToString + "-" + totalSearchcount.ToString + "/" + totalSearchcount.ToString
            Else
                searchPaginateCounter.Text = Spaginatefrom.ToString + "-" + (Spaginateto + Spaginatefrom).ToString + "/" + totalSearchcount.ToString
            End If

            If Spaginatefrom + 15 > totalSearchcount Then
                Button22.Visible = False
            End If
            Button21.Visible = False
        End If

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Spaginatefrom += Spaginateto

        loadingOfTransaction(Spaginatefrom, Spaginateto, transSearchBox.Text, DateTimePicker1)
        If totalSearchcount - (Spaginatefrom + 15) <= 0 Then
            searchPaginateCounter.Text = (Spaginatefrom + 1).ToString + "-" + totalSearchcount.ToString + "/" + totalSearchcount.ToString
        Else
            searchPaginateCounter.Text = (Spaginatefrom + 1).ToString + "-" + (Spaginateto + Spaginatefrom).ToString + "/" + totalSearchcount.ToString
        End If


        Button21.Visible = True
        If Spaginatefrom + Spaginateto >= totalSearchcount Then
            Button22.Visible = False
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        Spaginatefrom -= Spaginateto
        loadingOfTransaction(Spaginatefrom, Spaginateto, transSearchBox.Text, DateTimePicker1)
        If totalSearchcount - (Spaginatefrom - 15) <= 0 Then
            searchPaginateCounter.Text = (Spaginatefrom + 1).ToString + "-" + totalSearchcount.ToString + "/" + totalSearchcount.ToString
        Else
            searchPaginateCounter.Text = (Spaginatefrom + 1).ToString + "-" + (Spaginateto + Spaginatefrom).ToString + "/" + totalSearchcount.ToString
        End If


        Button22.Visible = True
        If Spaginatefrom - Spaginateto < 0 Then
            Button21.Visible = False
        End If
    End Sub

    Private Sub transListView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles transListView.DoubleClick
        If transListView.SelectedItems.Count <> 0 Then

            Dim selectedTrans_ID As String = transListView.FocusedItem.SubItems(0).Text
            Dim selectedTransDetail_ID As String = transListView.FocusedItem.Index

            editTransactionForm.Label4.Text = selectedTrans_ID
            editTransactionForm.trans_Key_ID = selectedTrans_ID
            editTransactionForm.Show()
            Me.Hide()

        Else
            MsgBox("Please select a transaction", MsgBoxStyle.Critical, "Select Index err")
        End If
    End Sub

    

End Class