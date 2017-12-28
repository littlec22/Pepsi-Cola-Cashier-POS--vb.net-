Imports MySql.Data.MySqlClient

Module transactionSearchModule
    Dim transDetailID As New Collection


    Function transCount(ByVal searchString As String, ByVal dateTimeSearch As DateTimePicker) As Double
        Dim selectdata As String = ""
        If dateTimeSearch.Checked = False Then

            selectdata = "SELECT count(`Id`) FROM `transaction_key_table` WHERE status = '1' AND (`Id` = any(SELECT `trans_Key_Id` FROM " & _
                " `transaction_details_table` WHERE  `active` ='1' AND( `teller_Id` LIKE ?search " & _
                " OR `pd_Number` LIKE ?search OR `settler_Name` LIKE ?search ) OR `trans_Id` = any(SELECT `trans_Id` FROM `trans_payment_check` " & _
                " WHERE `account_Num` LIKE ?search)))"
        Else

            selectdata = "SELECT count(`Id`) FROM `transaction_key_table` WHERE status = '1' AND (`Id` = any(SELECT `trans_Key_Id` FROM " & _
                " `transaction_details_table` WHERE  `active` ='1' AND  `date` LIKE '" + dateTimeSearch.Text + "%' AND( `teller_Id` LIKE ?search " & _
                " OR `pd_Number` LIKE ?search OR `settler_Name` LIKE ?search ) OR `trans_Id` = any(SELECT `trans_Id` FROM `trans_payment_check` " & _
                " WHERE `account_Num` LIKE ?search)))"
        End If

        cmd = New MySqlCommand(selectdata, con)
        cmd.Parameters.Add("?search", searchString + "%")
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

    Sub loadingOfTransaction(ByVal paginateFrom As Integer, ByVal paginateTo As Integer, ByVal searchString As String, ByVal dateTimeSearch As DateTimePicker)

        Dim selectdata As String = ""
        If dateTimeSearch.Checked = False Then
            selectdata = "SELECT `Id`,`trans_Id` FROM `transaction_key_table` WHERE status = '1' AND (`Id` = any(SELECT `trans_Key_Id` FROM " & _
                " `transaction_details_table` WHERE  `active` ='1' AND( `teller_Id` LIKE ?search " & _
                " OR `pd_Number` LIKE ?search OR `settler_Name` LIKE ?search ) OR `trans_Id` = any(SELECT `trans_Id` FROM `trans_payment_check` " & _
                " WHERE `account_Num` LIKE ?search))) ORDER BY `id` DESC LIMIT " + paginateFrom.ToString + "," + paginateTo.ToString + ""
        Else

            selectdata = "SELECT `Id`,`trans_Id` FROM `transaction_key_table` WHERE status = '1' AND (`Id` = any(SELECT `trans_Key_Id` FROM " & _
                " `transaction_details_table` WHERE  `active` ='1' AND  `date` LIKE '" + dateTimeSearch.Text + "%' AND( `teller_Id` LIKE ?search " & _
                " OR `pd_Number` LIKE ?search OR `settler_Name` LIKE ?search ) OR `trans_Id` = any(SELECT `trans_Id` FROM `trans_payment_check` " & _
                " WHERE `account_Num` LIKE ?search))) ORDER BY `id` DESC LIMIT " + paginateFrom.ToString + "," + paginateTo.ToString + ""
        End If

        cmd = New MySqlCommand(selectdata, con)
        cmd.Parameters.Add("?search", searchString + "%")





        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)

            transaction_Search.transListView.Items.Clear()
            If dt.Rows.Count <> 0 Then

                For Each row In dt.Rows

                    Dim selectdata2 As String = "SELECT `transaction_details_table`.`trans_Id`, " & _
                        "`transaction_details_table`.`trans_Key_Id`, usertable.firstName ,usertable.middlename,usertable.lastName," & _
                        " `transaction_details_table`.`pd_Number`, `transaction_details_table`.`settler_Name`," & _
                        " `transaction_details_table`.`date`,paymentCash.cashPayment,paymentCheck.checkPayment" & _
                        " FROM `transaction_details_table` LEFT JOIN (SELECT `trans_Id`,((`1000`*1000)+(`500`*500)+ " & _
                        " (`200`*200)+(`100`*100)+(`50`*50)+(`20`*20)+(`10`*10)+(`5`*5)+`1`+`other`+(`.25`*.25)+(`.10`*.10)) " & _
                        " as cashPayment FROM `trans_payment_cash`) as paymentCash ON paymentCash.`trans_ID`= `transaction_details_table`.`trans_Id`  " & _
                        " LEFT JOIN (SELECT trans_Id,SUM(`amount`) as checkPayment FROM trans_payment_check GROUP BY `trans_Id`)" & _
                        " as paymentCheck ON   paymentCheck.`trans_ID` = `transaction_details_table`.`trans_Id` " & _
                        " LEFT JOIN (SELECT userID,firstName,middleName,lastName FROM user_Table )as usertable ON `transaction_details_table`.`teller_Id` " & _
                        " = usertable.`userId` WHERE trans_Key_Id = ?id ORDER BY trans_Id DESC LIMIT 1"
                    cmd = New MySqlCommand(selectdata2, con)
                    cmd.Parameters.Add("?id", row("Id"))

                    adapter = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adapter.Fill(dt)
                    Dim x As Integer = 0
                    If dt.Rows.Count <> 0 Then


                        With transaction_Search.transListView
                            Dim i As New ListViewItem

                            'this is the id, of the row in the search transaction
                            transDetailID.Add(dt.Rows(0).Item("trans_Id"))

                            i = .Items.Add(row("trans_Id"))

                            i.SubItems.Add(dt.Rows(0).Item("settler_Name"))
                            i.SubItems.Add(dt.Rows(0).Item("pd_Number"))
                            i.SubItems.Add(dt.Rows(0).Item("firstName") + " " + dt.Rows(0).Item("middleName") + " " + dt.Rows(0).Item("lastName"))
                            i.SubItems.Add(dt.Rows(0).Item("date"))
                            Dim cash As Double = Val(dt.Rows(0).Item("cashPayment").ToString)
                            Dim check As Double = Val(dt.Rows(0).Item("checkPayment").ToString)
                            If cash <> 0 And check <> 0 Then
                                i.SubItems.Add("Mixed")
                            ElseIf cash <> 0 Then
                                i.SubItems.Add("Cash")
                            ElseIf check <> 0 Then
                                i.SubItems.Add("Check")
                            End If
                            i.SubItems.Add(FormatCurrency(FormatCurrency(cash)).ToString)
                            i.SubItems.Add(FormatCurrency(FormatCurrency(check)).ToString)

                            i.SubItems.Add(FormatCurrency(FormatCurrency(cash + check)).ToString)


                        End With
                    End If
                Next


            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
    End Sub

    Sub searchOfTransaction(ByVal paginateFrom As Integer, ByVal paginateTo As Integer, ByVal serachString As String)
        Dim selectdata1 As String = "SELECT * FROM `transaction_key_table` ORDER BY `Id` DESC LIMIT " + paginateFrom.ToString + "," + paginateTo.ToString + ""
        cmd = New MySqlCommand(selectdata1, con)





        Try

            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)

            transaction_Search.transListView.Items.Clear()
            If dt.Rows.Count <> 0 Then

                For Each row In dt.Rows

                    Dim selectdata2 As String = "SELECT `transaction_details_table`.`trans_Id`, " & _
                        "`transaction_details_table`.`trans_Key_Id`, usertable.firstName ,usertable.middlename,usertable.lastName," & _
                        " `transaction_details_table`.`pd_Number`, `transaction_details_table`.`settler_Name`," & _
                        " `transaction_details_table`.`date`,paymentCash.cashPayment,paymentCheck.checkPayment" & _
                        " FROM `transaction_details_table` LEFT JOIN (SELECT `trans_Id`,((`1000`*1000)+(`500`*500)+ " & _
                        " (`200`*200)+(`100`*100)+(`50`*50)+(`20`*20)+(`10`*10)+(`5`*5)+`1`+`other`+(`.25`*.25)+(`.10`*.10)) " & _
                        " as cashPayment FROM `trans_payment_cash`) as paymentCash ON `transaction_details_table`.`trans_Id` = " & _
                        "paymentCash.`trans_ID` LEFT JOIN (SELECT trans_Id,SUM(`amount`) as checkPayment FROM trans_payment_check " & _
                        "GROUP BY trans_Id) as paymentCheck ON `transaction_details_table`.`trans_Id` = paymentCheck.`trans_ID` " & _
                        " LEFT JOIN (SELECT userID,firstName,middleName,lastName FROM user_Table )as usertable ON `transaction_details_table`.`teller_Id` " & _
                        " = usertable.`userId` WHERE trans_Key_Id = ?id ORDER BY trans_Id DESC LIMIT 1"
                    cmd = New MySqlCommand(selectdata2, con)
                    cmd.Parameters.Add("?id", row("Id"))

                    adapter = New MySqlDataAdapter(cmd)
                    dt = New DataTable
                    adapter.Fill(dt)

                    If dt.Rows.Count <> 0 Then


                        With transaction_Search.transListView
                            Dim i As New ListViewItem
                            i = .Items.Add(row("trans_Id"))
                            i.SubItems.Add(dt.Rows(0).Item("settler_Name"))
                            i.SubItems.Add(dt.Rows(0).Item("pd_Number"))
                            i.SubItems.Add(dt.Rows(0).Item("firstName") + " " + dt.Rows(0).Item("middleName") + " " + dt.Rows(0).Item("lastName"))
                            i.SubItems.Add(dt.Rows(0).Item("date"))
                            Dim cash As Double = Val(dt.Rows(0).Item("cashPayment").ToString)
                            Dim check As Double = Val(dt.Rows(0).Item("checkPayment").ToString)
                            If cash <> 0 And check <> 0 Then
                                i.SubItems.Add("Mixed")
                            ElseIf cash <> 0 Then
                                i.SubItems.Add("Cash")
                            ElseIf check <> 0 Then
                                i.SubItems.Add("Check")
                            End If
                            i.SubItems.Add(FormatCurrency(FormatCurrency(cash)).ToString)
                            i.SubItems.Add(FormatCurrency(FormatCurrency(check)).ToString)
                            i.SubItems.Add(FormatCurrency(FormatCurrency(cash + check)).ToString)

                        End With
                    End If
                Next


            End If

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        con.Close()
    End Sub

End Module
