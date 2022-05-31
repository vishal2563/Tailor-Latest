Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class slipprint
    Dim CReport As New sliprpt

    Private Sub slipprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim myConnectionInfo As New ConnectionInfo()
        'myConnectionInfo.ServerName = SqlServerName(1)
        'myConnectionInfo.DatabaseName = SqlDataBase(1)
        'myConnectionInfo.UserID = SqlUserId(1)
        'myConnectionInfo.Password = SqlPassword(1)

        'CReport.Load()
        'Dim myTables As Tables = CReport.Database.Tables
        'For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
        '    Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
        '    myTableLogonInfo.ConnectionInfo = myConnectionInfo
        '    myTable.ApplyLogOnInfo(myTableLogonInfo)
        'Next

        'CReport.RecordSelectionFormula = "{delivery.billno} = " & print_billno
        'CrystalReportViewer1.ReportSource = CReport
        'CrystalReportViewer1.Refresh()
    End Sub

End Class