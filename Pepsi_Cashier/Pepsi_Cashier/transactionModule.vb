Imports MySql.Data.MySqlClient

Module transactionModule

    

    'filling the mysource.. this is the collection of all business name .. if they search a business. it will easy to find them.. in transaction page only
    Sub fillingMySourceForTransPage(ByVal ix As Integer)
        Form2.Cursor = Cursors.WaitCursor

        Dim searchData As String = "SELECT DISTINCT `business_Name` FROM check_payers_table "

        cmd = New MySqlCommand(searchData, con)
        Dim count As Integer
        count = 0
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            count = dt.Rows.Count

            If count <> 0 Then

                Dim i As Integer = 0
                For Each row In dt.Rows
                    If ix = 1 Then
                        Form2.mysource.Add(row(0).ToString)
                        editTransactionForm.mysource.Add(row(0).ToString)
                    ElseIf ix = 2 Then
                        staffFormvb.mysource.Add(row(0).ToString)
                        editTransactionForm.mysource.Add(row(0).ToString)
                    End If

                Next



            End If
            con.Close()
        Catch ex As Exception
            MsgBox("Err. Error to fill business name in resource!", MsgBoxStyle.Critical, "Error")
        End Try
        Form2.Cursor = Cursors.Default
    End Sub

    'this is for auto increment transaction id
    Sub generateTransId()
        Dim searchData As String = "SELECT `Id`,`trans_Id` FROM transaction_key_table  ORDER BY `Id` DESC LIMIT 1"

        cmd = New MySqlCommand(searchData, con)
        Dim count As Integer
        count = 0
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            count = dt.Rows.Count

            If count <> 0 Then
                Dim pastId As String = dt.Rows(0).Item(1).ToString

                If pastId.Contains(Now.Year.ToString) Then
                    Dim pastkey As String = dt.Rows(0).Item(0).ToString
                    Dim id As String = Now.Year.ToString + "-" + (Val(pastkey) + 1).ToString
                    Form2.IDKEYTABLE = Val(pastkey) + 1

                    Form2.transIdText.Text = id
                Else

                    Dim id As String = Now.Year.ToString + "-" + "1"
                    Form2.IDKEYTABLE = "1"

                    Form2.transIdText.Text = id
                End If


            Else
                Form2.IDKEYTABLE = "1"
                Dim id As String = Now.Year.ToString + "-" + "1"


                Form2.transIdText.Text = id

            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    'tinamad na ako.. kaya ganto na ginawa ko hahahaha
    Sub generateTransId1()
        Dim searchData As String = "SELECT `Id`,`trans_Id` FROM transaction_key_table  ORDER BY `Id` DESC LIMIT 1"

        cmd = New MySqlCommand(searchData, con)
        Dim count As Integer
        count = 0
        Try

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)
            count = dt.Rows.Count

            If count <> 0 Then
                Dim pastId As String = dt.Rows(0).Item(1).ToString

                If pastId.Contains(Now.Year.ToString) Then
                    Dim pastkey As String = dt.Rows(0).Item(0).ToString
                    Dim id As String = Now.Year.ToString + "-" + (Val(pastkey) + 1).ToString
                    staffFormvb.IDKEYTABLE = Val(pastkey) + 1

                    staffFormvb.transIdText.Text = id
                Else

                    Dim id As String = Now.Year.ToString + "-" + "1"
                    staffFormvb.IDKEYTABLE = "1"

                    staffFormvb.transIdText.Text = id
                End If


            Else
                staffFormvb.IDKEYTABLE = "1"
                Dim id As String = Now.Year.ToString + "-" + "1"


                staffFormvb.transIdText.Text = id

            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Function insertingTransaction(ByVal transCash As Collection, ByVal transCheckAccount As Collection, ByVal transCheckAmount As Collection,
                                  ByVal transCheckInfo As Collection, ByVal transCheckNumber As Collection, ByVal transCheckLimit As Collection, ByVal transdetail As Collection) As Boolean
        Dim result As Boolean = False
        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If





        Dim insertKEY As String = "INSERT INTO `transaction_key_table`(`trans_Id`, `status`) VALUES (?id,'1')"
        cmd = New MySqlCommand(insertKEY, con)
        cmd.Parameters.Add("?id", transdetail.Item(2))

        Try
            If cmd.ExecuteNonQuery() > 0 Then
                Dim insertDetails As String = "INSERT INTO `transaction_details_table`( `trans_Key_Id`, `teller_Id`, `pd_Number`, `settler_Name`, `date`,`active`)" & _
                    " VALUES (?key,?teller,?pd,?settler,?date,'1')"
                cmd = New MySqlCommand(insertDetails, con)
                cmd.Parameters.Add("?key", transdetail.Item(6))
                cmd.Parameters.Add("?teller", transdetail.Item(1))
                cmd.Parameters.Add("?pd", transdetail.Item(5))
                cmd.Parameters.Add("?settler", transdetail.Item(4))
                cmd.Parameters.Add("?date", transdetail.Item(3))

                cmd.ExecuteNonQuery()



                Dim searchData As String = "SELECT `trans_Id` FROM `transaction_details_table` ORDER BY `trans_Id` DESC LIMIT 1"

                cmd = New MySqlCommand(searchData, con)
                Dim count As Integer
                count = 0

                adapter = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adapter.Fill(dt)
                count = dt.Rows.Count
                Dim transactionDetailId As String = ""
                If count <> 0 Then
                    transactionDetailId = dt.Rows(0).Item(0).ToString

                End If

                Dim insertCash As String = "INSERT INTO `trans_payment_cash`( `trans_ID`, `1000`, `500`, `200`, `100`, `50`, `20`, `10`, `5`, `1`, " & _
                    " `.25`, `.10`, `other`) VALUES (?id ,?1000 ,?500,?200,?100,?50,?20,?10,?5,  " & _
                    "?1,?25c,?10c,?other)"
                cmd = New MySqlCommand(insertCash, con)
                cmd.Parameters.Add("?id", transactionDetailId)
                cmd.Parameters.Add("?1000", transCash.Item(1))
                cmd.Parameters.Add("?500", transCash.Item(2))
                cmd.Parameters.Add("?200", transCash.Item(3))
                cmd.Parameters.Add("?100", transCash.Item(4))
                cmd.Parameters.Add("?50", transCash.Item(5))
                cmd.Parameters.Add("?20", transCash.Item(6))
                cmd.Parameters.Add("?10", transCash.Item(7))
                cmd.Parameters.Add("?5", transCash.Item(8))
                cmd.Parameters.Add("?1", transCash.Item(9))
                cmd.Parameters.Add("?25c", transCash.Item(10))
                cmd.Parameters.Add("?10c", transCash.Item(11))
                cmd.Parameters.Add("?other", transCash.Item(12))


                cmd.ExecuteNonQuery()

                Dim x As Integer = 1

                For i = 1 To transCheckAccount.Count
                    Dim insertCheck As String = "INSERT INTO `trans_payment_check`( `account_Num`, `amount`,account_Num_Info,account_Limit, `trans_Id`,`account_num_series`)" & _
                    " VALUES (?account,?amount,?info,?limit,?id,?number)"
                    cmd = New MySqlCommand(insertCheck, con)
                    cmd.Parameters.Add("?id", transactionDetailId)
                    cmd.Parameters.Add("?account", transCheckAccount(x).ToString)
                    cmd.Parameters.Add("?info", transCheckInfo.Item(x))
                    cmd.Parameters.Add("?number", transCheckNumber.Item(x))
                    If Val(transCheckLimit.Item(x)) = 0 Then
                        cmd.Parameters.Add("?limit", "0")
                    Else
                        cmd.Parameters.Add("?limit", transCheckLimit.Item(x))
                    End If

                    cmd.Parameters.Add("?amount", transCheckAmount.Item(x))

                    cmd.ExecuteNonQuery()
                    x += 1
                Next

                MsgBox("Transaction Complete!")
                result = True
                generateTransId()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
        Return result
    End Function

End Module
