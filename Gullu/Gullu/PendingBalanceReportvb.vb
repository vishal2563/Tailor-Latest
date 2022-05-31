Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Excel = Microsoft.Office.Interop.Excel
Public Class PendingBalanceReportvb
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader
    Dim r As Integer = 0
    Dim fso As New Scripting.FileSystemObject
    Dim fil1 As Scripting.File
    Private Sub PendingBalanceReportvb_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

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
        DeliveryStatusFetch = getdata("select  d.billno as [SlipNo] ,d.cstbillno as [BillNo],d.billdate AS [BillDate] ,d.cstname as[Customer Name],d.mobile as [Mobile No] ,(d.totalqty - ISNULL (s.totaldelived,'0.00')) as[Balance] from DeliveryTable as d left outer join DeliveryStatusTable  as s  on d.billno = s.billno and d.cstbillno =s.cstbillno where d.billdate >='" & Format(CDate(DateTimePicker1.Text), "yyyy-MM-dd") & "' and d.billdate <='" & Format(CDate(DateTimePicker2.Text), "yyyy-MM-dd") & "' and (d.totalqty - ISNULL (s.totaldelived,'0.00'))>0 order by d.billno")
        DataGridView2.DataSource = DeliveryStatusFetch
    End Sub

    Private Sub btnshow_Click(sender As System.Object, e As System.EventArgs) Handles btnshow.Click
        RecordFetch()
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub btnclose_Click(sender As System.Object, e As System.EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnexcel_Click(sender As System.Object, e As System.EventArgs) Handles btnexcel.Click
        CreatePage2()
        visitMicrosoft2()
    End Sub
    Private Sub CreatePage2()
        Dim HTMLTitle As String = ""
        Dim HTMLText As String = ""
        Dim HTMLFileName As String = ""
        Dim strFile As String
        Dim rowcounter As Integer
        Dim rowtablecounter As Integer
        rowcounter = 0
        rowtablecounter = 0
        Dim rgdno As String = ""
        Dim dtd As String = ""
        ' ----------------------
        ' -- Prepare String --
        ' ----------------------
        strFile = ""

        strFile = strFile & "<html>" & vbNewLine
        strFile = strFile & "<head>" & vbNewLine
        strFile = strFile & "<title>" & HTMLTitle & "</title>" & vbNewLine
        strFile = strFile & "</head><body>"

        strFile = strFile & " <table style='width: 519px' border=0>"
        strFile = strFile & "  <tr> "
        strFile = strFile & "</tr>"
        strFile = strFile & "</table>"
        'strFile = strFile & " <center><b> <Font Size=4> " & MDI.ToolStripStatusLabel3.Text & "</Font></b></center>"
        strFile = strFile & "<center><b>PendingBalanceReport </b></center>"
        strFile = strFile & " <table  border='1'>"
        strFile = strFile & "  <tr> "
        strFile = strFile & "  <td> "
        strFile = strFile & " <table style='width: 519px' border='0'>"
        strFile = strFile & "  <tr> "
        For Each col In DataGridView2.Columns
            If col.Visible = True Then
                strFile = strFile & "      <td style='height: 20px'>"
                strFile = strFile & "     <center> <b> " & col.HeaderText & " </b> </center></td>"
            End If
        Next
        strFile = strFile & "  </tr>"
        Dim col2 As DataGridViewColumn
        Dim R As DataGridViewRow
        For Each R In Me.DataGridView2.Rows
            strFile = strFile & "  <tr>"
            For Each col2 In DataGridView2.Columns
                If col2.Visible = True Then
                    strFile = strFile & "       <td style='Height: 21px'> <center>"
                    strFile = strFile & " " & R.Cells(col2.Index).Value & " </center></td>"
                End If
            Next
            strFile = strFile & "  <tr>"
        Next
        strFile = strFile & "</table>"
        strFile = strFile & "</td> </tr>"
        strFile = strFile & "</table>"
        strFile = strFile & "  </form>"
        strFile = strFile & "  </body></html>"
        SaveTextToFile(strFile, "D:\" & HTMLFileName & "PendingBalanceReport.xls")
    End Sub
    Public Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean
        '   Dim Contents As String
        Dim Saved As Boolean = False
        Dim objReader As IO.StreamWriter

        Try
            objReader = New IO.StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            Saved = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return Saved
    End Function
    Private Sub visitMicrosoft2()
        System.Diagnostics.Process.Start("D:\PendingBalanceReport.xls")
    End Sub
End Class