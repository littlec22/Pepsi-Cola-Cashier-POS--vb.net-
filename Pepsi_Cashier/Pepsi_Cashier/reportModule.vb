Imports MySql.Data.MySqlClient

Module reportModule



    'this is the report for transaction
    Sub transactionReport(ByVal dateFrom As DateTimePicker)

        Try


            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim selectdata As String = ""


            selectdata = "SELECT `trans_Id` FROM `transaction_details_table` WHERE " & _
                "(date  LIKE '" + dateFrom.Text + "%') AND `active`='1'AND `trans_key_Id` = any(SELECT `Id` FROM `transaction_key_table` WHERE status='1')  "



            cmd = New MySqlCommand(selectdata, con)
         





            Form2.reportsLoadingCounter.Text = "Fetching data from database ..."
            adapter = New MySqlDataAdapter(cmd)
            Form2.reportsLoadingCounter.Text = "Fetching data from database ..."
            dt = New DataTable
            adapter.Fill(dt)
            Form2.reportsLoadingCounter.Text = "Analyzing data ..."

            Dim dateByDay As Date
            Dim ds As New DataSet1
            Dim grandTotalSum As Double = 0

            Dim dtCount = dt.Rows.Count
            Form2.ProgressBar1.Maximum = dtCount
            Form2.reportsLoadingCounter.Text = "/" + dtCount.ToString
            Form2.reportsLoadingCounter.Visible = True
            If dt.Rows.Count <> 0 Then

                Dim x As Integer = 1

                For Each row In dt.Rows


                    Dim selectdata2 As String = "SELECT  `transaction_details_table`.`pd_Number`, `transaction_details_table`.`date`, " & _
                        " `transaction_details_table`.`settler_Name`," & _
                        " paymentCash.cashPayment, " & _
                        "paymentCheck.checkPayment" & _
                        " FROM `transaction_details_table` LEFT JOIN (SELECT `trans_Id`,((`1000`*1000)+(`500`*500)+ " & _
                        " (`200`*200)+(`100`*100)+(`50`*50)+(`20`*20)+(`10`*10)+(`5`*5)+`1`+`other`+(`.25`*.25)+(`.10`*.10)) " & _
                        " as cashPayment FROM `trans_payment_cash`) as paymentCash ON `transaction_details_table`.`trans_Id` = " & _
                        "paymentCash.`trans_ID` LEFT JOIN (SELECT trans_Id,SUM(`amount`) as checkPayment FROM trans_payment_check " & _
                        "GROUP BY trans_Id) as paymentCheck ON `transaction_details_table`.`trans_Id` = paymentCheck.`trans_ID` " & _
                        " LEFT JOIN (SELECT userID,firstName,middleName,lastName FROM user_Table )as usertable ON `transaction_details_table`.`teller_Id` " & _
                        " = usertable.`userId` WHERE `transaction_details_table`.`trans_Id` = ?id  ORDER BY `transaction_details_table`.`trans_Id` DESC LIMIT 1"
                    cmd = New MySqlCommand(selectdata2, con)
                    cmd.Parameters.Add("?id", row("trans_Id"))

                    adapter = New MySqlDataAdapter(cmd)
                    Dim dt1 = New DataTable()
                    adapter.Fill(dt1)


                    If dt1.Rows.Count <> 0 Then

                        Dim arrayString As Object()
                        dateByDay = dt1.Rows(0).Item(1)
                        dateByDay.ToLongTimeString()

                        Dim pdNum As String = dt1.Rows(0).Item(0)
                        Dim transDate As String = dt1.Rows(0).Item(1)
                        Dim settlerName As String = dt1.Rows(0).Item(2)
                        Dim check As Double = 0
                        Dim a As String = Val(dt1.Rows(0).Item("checkPayment").ToString)
                        If a <> 0 Then
                            check = a
                        End If
                        Dim cash As Double = 0
                        a = Val(dt1.Rows(0).Item("cashPayment").ToString)
                        If a <> 0 Then
                            cash = a
                        End If


                        Dim paymentType As String = ""

                        If cash <> 0 And check = 0 Then
                            paymentType = "Mixed"
                        ElseIf cash <> 0 Then
                            paymentType = "Cash"
                        Else
                            paymentType = "Check"

                        End If
                        Try
                            grandTotalSum += check + cash
                        Catch ex As Exception

                        End Try
                        arrayString = {dateByDay.ToString, pdNum, dateByDay.ToString, settlerName, paymentType, FormatCurrency(check.ToString), FormatCurrency(cash.ToString), FormatCurrency((check + cash).ToString), x.ToString}
                        ds.Tables(0).Rows.Add(arrayString)


                        x += 1

                    End If
                Next
               
            End If
            Dim dateParam As New ReportParameter("dateCover", "Date: " + dateFrom.Text)

            transReport.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pepsi_Cashier.Report1.rdlc"
            transReport.ReportViewer1.LocalReport.SetParameters(dateParam)
            Dim grandTotalParam As New ReportParameter("grandTotal", FormatCurrency(grandTotalSum.ToString))
            transReport.ReportViewer1.LocalReport.SetParameters(grandTotalParam)

            Form2.reportsLoadingCounter.Visible = False
            transReport.ds = ds
            transReport.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub

    Sub billsAndCoinReport(ByVal dateFrom As DateTimePicker)
        Try


            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim selectdata As String = ""


            Dim ds As New DataSet1







            Dim selectdata2 As String = "SELECT   sum(`1000`) ,SUM(`500`)  ,SUM(`200`) ,SUM(`100`),SUM(`50`)  ,SUM(`20`),SUM(`10`) ,SUM(`5`) ,SUM(`1`),SUM(`other`)  ,SUM(`.25`) ,SUM(`.10`)  FROM `trans_payment_cash`where `trans_Id` = any(SELECT `trans_Id` FROM `transaction_details_table`  WHERE `active`='1' AND(`transaction_details_table`.`date`  LIKE '" + dateFrom.Text + "%') AND `transaction_details_table`.`trans_Key_Id` = any(SELECT `Id` FROM `transaction_key_table` WHERE `status` = '1'))"
            cmd = New MySqlCommand(selectdata2, con)


            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)


            If dt.Rows.Count <> 0 Then
                Dim arrayString() As Object = {}

                If Val(dt.Rows(0).Item(0)) <> vbNull Then
                    arrayString = {Val(dt.Rows(0).Item(0)), Val(dt.Rows(0).Item(1)), Val(dt.Rows(0).Item(2)), Val(dt.Rows(0).Item(3)), Val(dt.Rows(0).Item(4)),
                             Val(dt.Rows(0).Item(5)), Val(dt.Rows(0).Item(6)), Val(dt.Rows(0).Item(7)), Val(dt.Rows(0).Item(8)), Val(dt.Rows(0).Item(9)),
                               Val(dt.Rows(0).Item(10)), Val(dt.Rows(0).Item(11))}
                Else
                    arrayString = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
                End If







                ds.Tables(1).Rows.Add(arrayString)

                

            End If

            Dim dateParam As New ReportParameter("dateCover", "Date: " + dateFrom.Text)

            transReport.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pepsi_Cashier.Report2.rdlc"
            transReport.ReportViewer1.LocalReport.SetParameters(dateParam)
            transReport.ds = ds
            transReport.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub
    Sub checkReport(ByVal dateFrom As DateTimePicker)
        Try


            If con.State = ConnectionState.Closed Then
                con.Open()
            End If

            Dim selectdata As String = ""


            Dim ds As New DataSet1
            Dim grandTotalSum As Double = 0

            Dim selectdata2 As String = "SELECT `trans_Id`, `pd_Number`, `settler_Name` " & _
                "FROM `transaction_details_table`  " & _
                "WHERE `transaction_details_table`.`trans_Key_Id` = any(SELECT `Id` FROM `transaction_key_table` WHERE `status` = '1')" & _
                " AND (`transaction_details_table`.`date`  LIKE '" + dateFrom.Text + "%' ) AND active='1' "





            cmd = New MySqlCommand(selectdata2, con)



            adapter = New MySqlDataAdapter(cmd)
            dt = New DataTable
            adapter.Fill(dt)


            If dt.Rows.Count <> 0 Then

                For Each row In dt.Rows

                    Dim a As String = "SELECT `account_Num`, `account_Num_Info`,`account_num_series`," & _
                " `account_Limit`, `amount` FROM `trans_payment_check` WHERE `trans_Id` = " + row(0).ToString + "  "

                    cmd = New MySqlCommand(a, con)

                    adapter = New MySqlDataAdapter(cmd)
                    Dim dt1 = New DataTable
                    adapter.Fill(dt1)


                    If dt1.Rows.Count <> 0 Then

                        For Each row1 In dt1.Rows

                            Dim arrayString() As String = {}
                            If Val(row1("amount").ToString) <= Val(row1("account_Limit").ToString) Then
                                arrayString = {row(1).ToString, row(2).ToString, row1(1).ToString + " (" + row1(0) + ")", row1(2).ToString, FormatCurrency(Val(row1("amount").ToString)), " OK (Limit : " + (FormatCurrency(Val(row1("account_Limit").ToString))) + " )"}
                            Else
                                arrayString = {row(1).ToString, row(2).ToString, row1(1).ToString + " (" + row1(0) + ")", row1(2).ToString, FormatCurrency(Val(row1("amount").ToString)), " Exceed (Limit : " + (FormatCurrency(Val(row1("account_Limit").ToString))).ToString + " )"}
                            End If



                            ds.Tables(2).Rows.Add(arrayString)

                            grandTotalSum += Val(row1("amount"))

                        Next
                    End If



                Next
               


            End If
            Dim dateParam As New ReportParameter("dateCover", "Date:  " + dateFrom.Text)

            transReport.ReportViewer1.LocalReport.ReportEmbeddedResource = "Pepsi_Cashier.Report4.rdlc"

            transReport.ReportViewer1.LocalReport.SetParameters(dateParam)
            Dim grandTotalParam As New ReportParameter("grandTotal", FormatCurrency(grandTotalSum.ToString))
            transReport.ReportViewer1.LocalReport.SetParameters(grandTotalParam)

            transReport.ds = ds
            transReport.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        con.Close()
    End Sub
End Module
