Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Drawing.Printing
Public Class transReport

    Public ds As New DataSet1

    Private Sub transReport_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Form2.ProgressBar1.Value = 0
    End Sub
    Private Sub transReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim dataSourceReport As ReportDataSource = New ReportDataSource("DataSet1", ds.Tables(0))

            
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            If Form2.reportDatasetWhat = 1 Then
                dataSourceReport = New ReportDataSource("DataSet1", ds.Tables(0))
            ElseIf Form2.reportDatasetWhat = 2 Then
                dataSourceReport = New ReportDataSource("DataSet1", ds.Tables(1))
            ElseIf Form2.reportDatasetWhat = 3 Then
                dataSourceReport = New ReportDataSource("DataSet1", ds.Tables(2))
           
            End If


            ReportViewer1.LocalReport.DataSources.Clear()
            ReportViewer1.LocalReport.DataSources.Add(dataSourceReport)

            ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)

            'Dim pg As New PageSettings
            'pg.PaperSize.RawKind = PaperKind.Letter
            'pg.Margins.Top = 0.5
            'pg.Margins.Left = 0.5
            'pg.Margins.Right = 0.5
            'pg.Margins.Bottom = 0.5

            'pg.Landscape = True

            'ReportViewer1.SetPageSettings(pg)
            ReportViewer1.ZoomMode = ZoomMode.PageWidth
            Me.ReportViewer1.RefreshReport()


            If con.State = ConnectionState.Open Then
                con.Close()

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub




End Class