Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Excel = Microsoft.Office.Interop.Excel
Public Class DeleiveryStatusReport
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader
    Dim r As Integer = 0

    Dim fso As New Scripting.FileSystemObject
    Dim fil1 As Scripting.File
    Private Sub DeleiveryStatusReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Function getdata(ByVal selectcmd) As DataTable
        openconn()
        Dim datatable As New DataTable
        Dim adapter1Object As New SqlDataAdapter(selectcmd, cnn)
        datatable.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter1Object.Fill(datatable)
        Return datatable
        closeconn()
    End Function
    Private Sub RecordFetch()
        Dim DeliveryStatusFetch As DataTable
        DeliveryStatusFetch = getdata("select m.billno as [SlipNo],m.billdate as [BillDate] ,m.cstbillno as [BillNo],m.cstname as [CustomerName] ,m.mobile as [MobileNo] ,item as [ItemName],description as [Descripition]  ,SUM(qty)as [RecQty],(m.totalamt -m.amountrec) as [Balance]  ,SUM(d.totalqty ) as Delivedqty from  deliverystatus as d inner join DeliveryStatusTable as m on d.billno =m.billno  group by m.billdate ,m.billno ,m.cstbillno ,item,description  ,m.totalamt ,m.amountrec,m.cstname ,m.mobile")
        DataGridView2.DataSource = DeliveryStatusFetch
    End Sub
    Private Sub DataGridView2_DoubleClick(sender As Object, e As System.EventArgs) Handles DataGridView2.DoubleClick
        editdeliverystatus = True
        DeliveryStatus.TextBox1.Text = DataGridView2.CurrentRow.Cells("SlipNo").Value
        DeliveryStatus.Show()
        DeliveryStatus.BringToFront()
    End Sub
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

    End Sub

    Private Sub btnshow_Click(sender As System.Object, e As System.EventArgs) Handles btnshow.Click
        RecordFetch()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    
    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class