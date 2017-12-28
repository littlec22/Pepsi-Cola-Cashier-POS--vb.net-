Imports MySql.Data.MySqlClient

Module editTransactionModule
    Function insertingEditedTransaction(ByVal transCash As Collection, ByVal transCheckAccount As Collection, ByVal transCheckAmount As Collection,
                                        ByVal transCheckInfo As Collection, ByVal transCheckNumber As Collection, ByVal transCheckLimit As Collection, ByVal transdetail As Collection) As Boolean
        Dim result As Boolean = False
        If con.State = ConnectionState.Closed Then
            con.Open()
        Else

        End If


        Try

            Dim insertDetails As String = "INSERT INTO `transaction_details_table`( `trans_Key_Id`, `teller_Id`, `pd_Number`, `settler_Name`, `date`,`active`)" & _
                " VALUES (?key,?teller,?pd,?settler,?date,'1')"
            cmd = New MySqlCommand(insertDetails, con)
            cmd.Parameters.Add("?key", editTransactionForm.trans_Key_Details)
            cmd.Parameters.Add("?teller", transdetail.Item(1))
            cmd.Parameters.Add("?pd", transdetail.Item(4))
            cmd.Parameters.Add("?settler", transdetail.Item(3))
            cmd.Parameters.Add("?date", transdetail.Item(2))


            If cmd.ExecuteNonQuery() > 0 Then


                Dim searchData As String = "SELECT `trans_Id`,`trans_Key_Id` FROM `transaction_details_table` ORDER BY `trans_Id` DESC LIMIT 1"

                cmd = New MySqlCommand(searchData, con)
                Dim count As Integer
                count = 0

                adapter = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adapter.Fill(dt)
                count = dt.Rows.Count
                Dim transactionDetailId As String = ""
                Dim transactionDetailId1 As String = ""
                If count <> 0 Then
                    transactionDetailId = dt.Rows(0).Item(0).ToString
                    transactionDetailId1 = dt.Rows(0).Item(1).ToString
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


                Dim searchData1 As String = "SELECT `trans_Id` FROM `transaction_details_table` WHERE trans_Key_Id = '" + transactionDetailId1 + "' ORDER BY `trans_Id` DESC LIMIT 1"

                cmd = New MySqlCommand(searchData1, con)
                
                adapter = New MySqlDataAdapter(cmd)
                dt = New DataTable
                adapter.Fill(dt)

                Dim transactionDetailKeyId As String = ""
                If dt.Rows.Count <> 0 Then
                    transactionDetailKeyId = dt.Rows(0).Item(0).ToString
                End If

                Dim updateTheLastData As String = "UPDATE `transaction_details_table` SET `active` = '0' WHERE `trans_Id` = '" + (Val(transactionDetailKeyId) - 1).ToString + "' "

                cmd = New MySqlCommand(updateTheLastData, con)
                cmd.ExecuteNonQuery()



                result = True
                MsgBox("Edit Transaction (with Transaction ID : " + editTransactionForm.Label4.Text.ToUpper + " )Complete!")

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
        Return result
    End Function
End Module
