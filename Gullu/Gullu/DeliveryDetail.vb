Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Excel = Microsoft.Office.Interop.Excel

Public Class DeliveryDetail
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader
    Dim r As Integer = 0

    Dim fso As New Scripting.FileSystemObject
    Dim fil1 As Scripting.File

    Private Sub DeliveryDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'openconn()
        'cmd = New SqlCommand("select * from financeyear", cnn)
        'drd = cmd.ExecuteReader
        'If drd.Read Then
        '    DateTimePicker1.MinDate = drd("date1")
        '    DateTimePicker1.MaxDate = drd("date2")
        '    DateTimePicker2.MinDate = drd("date1")
        '    DateTimePicker2.MaxDate = drd("date2")
        '    DateTimePicker1.Value = drd("date1")
        '    DateTimePicker2.Value = (DateTime.Now)
        'End If
        'drd.Close()
        'closeconn()
    End Sub

    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click

        Dim srno As Integer = 1
        Dim SqlStmt As String = ""
        Dim eno As Integer = 0
        r = 0
        DataGridView1.Rows.Clear()

        If Val(TextBox1.Text) > 0 Then
            SqlStmt = SqlStmt & " and  billno=" & Val(TextBox1.Text) & ""
        End If
        If TextBox2.Text <> "" Then
            SqlStmt = SqlStmt & " and  cstbillno='" & TextBox2.Text & "'"
        End If

        openconn()
        cmd = New SqlCommand("SELECT * FROM deliverystatus  WHERE  billdate between '" & Format(CDate(DateTimePicker1.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(DateTimePicker2.Text), "yyyy-MM-dd") & "'" & SqlStmt & " order by entryno ", cnn)

        drd = cmd.ExecuteReader
        While drd.Read
            DataGridView1.Rows.Add()
            If Val(drd("entryno")) <> eno Then
                'DataGridView1.Rows(r).Cells("srno").Value = srno
                DataGridView1.Rows(r).Cells("entryno").Value = drd("entryno")
                DataGridView1.Rows(r).Cells("billno").Value = drd("billno")
                DataGridView1.Rows(r).Cells("billdate").Value = Format(drd("billdate"), "dd/MM/yyyy")
                DataGridView1.Rows(r).Cells("cstbillno").Value = drd("cstbillno")
                DataGridView1.Rows(r).Cells("cstname").Value = drd("cstname")
                DataGridView1.Rows(r).Cells("mobile").Value = drd("mobile")
                DataGridView1.Rows(r).Cells("deliveryon").Value = Format(drd("deliveryon"), "dd/MM/yyyy")


                DataGridView1.Rows(r).Cells("totalamt").Value = Format(drd("totalamt"), "#.00")
                srno = srno + 1
            End If
            DataGridView1.Rows(r).Cells("tname").Value = drd("tname")
            DataGridView1.Rows(r).Cells("item").Value = drd("item")
            DataGridView1.Rows(r).Cells("des").Value = drd("description")
            DataGridView1.Rows(r).Cells("totalqty").Value = Format(Val(drd("totalqty")), ".00")
            DataGridView1.Rows(r).Cells("deliveredqty").Value = Format(Val(drd("alreadydelivered")) + Val(drd("qty")), "#.00")
            DataGridView1.Rows(r).Cells("balance").Value = Format(Val(DataGridView1.Rows(r).Cells("totalqty").Value) - Val(DataGridView1.Rows(r).Cells("deliveredqty").Value), "#.00")
            eno = drd("entryno")
            r = r + 1
        End While

        drd.Close()
        closeconn()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            If CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value) <> 0 Then
                MsgBox("Access Denied", MsgBoxStyle.Critical, "Warning !!!")
                'DeliveryStatus.TextBox7.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value
                'DeliveryStatus.TextBox1.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value
                'DeliveryStatus.MdiParent = mdi
                'editdeliverystatus = True
                'DeliveryStatus.Show()
                'DeliveryStatus.displaydata2()
                'Me.Hide()
            End If
        End If
    End Sub

    Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
        If DataGridView1.Rows.Count > 0 Then
            If CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value) <> 0 Then
                If currentuser = "ADMIN" Then
                    Dim ch As String
                    ch = MsgBox("Are You Sure To Delete Entry No " & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value & " ?...", vbYesNo, "Confirm!!!")
                    If ch = vbYes Then

                        openconn()
                        cmd = New SqlCommand("insert into bindeliverystatus select * from deliverystatus where entryno= " & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value, cnn)
                        cmd.ExecuteNonQuery()

                        cmd = New SqlCommand("delete from deliverystatus where entryno= " & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value, cnn)
                        cmd.ExecuteNonQuery()
                        closeconn()
                        btnshow.PerformClick()
                    End If
                Else
                    MsgBox("Not Authorised Contact To Administrator.", vbCritical, "Warning!!!")
                End If
            End If
        End If
    End Sub



    'Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
    '    If DataGridView1.Rows.Count > 0 Then
    '        If CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value) <> 0 Then
    '            If currentuser = "ADMIN" Then
    '                Dim ch As String
    '                ch = MsgBox("Are You Sure To Delete Entry No " & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value & " ?...", vbYesNo, "Confirm!!!")
    '                If ch = vbYes Then
    '                    openconn()
    '                    cmd = New SqlCommand("delete from deliverystatus where entryno= " & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("entryno").Value, cnn)
    '                    cmd.ExecuteNonQuery()
    '                    closeconn()
    '                    btnshow.PerformClick()
    '                End If
    '            Else
    '                MsgBox("Not Authorised Contact To Administrator.", vbCritical, "Warning!!!")
    '            End If
    '        End If
    '    End If
    'End Sub

    Private Sub btnexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnexcel.Click

        If DataGridView1.Rows.Count > 0 Then
            Dim AppXls As Excel.Application
            Dim ObjWb As Excel.Workbook
            Dim ObjWs As Excel.Worksheet
            Dim A As Integer

            AppXls = CreateObject("Excel.Application")
            ObjWb = AppXls.Workbooks.Add
            ObjWs = ObjWb.Worksheets(1)

            ObjWs.PageSetup.LeftMargin = 0.12
            ObjWs.PageSetup.RightMargin = 0.1
            ObjWs.PageSetup.TopMargin = 0.24
            ObjWs.PageSetup.BottomMargin = 0.18
            ObjWs.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
            ObjWs.PageSetup.PaperSize = Excel.XlPaperSize.xlPaperA4

            A = 1
            ObjWs.Cells.Font.Size = 8
            ObjWs.Rows(A).Font.Bold = True
            ObjWs.Cells(A, 1) = "Delivery Detail Register From " & DateTimePicker1.Text & " To " & DateTimePicker2.Text
            A = A + 1

            'If ListBox1.SelectedItem <> "" Then
            '    ObjWs.Rows(A).Font.Bold = True
            '    ObjWs.Cells(A, 1) = "BILL No : " & ListBox1.Text
            '    A = A + 1
            'End If

            ObjWs.Rows(A).Font.Bold = True
            For xd As Integer = 0 To DataGridView1.ColumnCount - 1
                ObjWs.Cells(A, xd + 1) = DataGridView1.Columns(xd).HeaderText
            Next
            A = A + 1

            For xd As Integer = 0 To DataGridView1.Rows.Count - 1
                ObjWs.Cells(A, 1) = DataGridView1.Rows(xd).Cells(0).Value
                ObjWs.Cells(A, 2) = DataGridView1.Rows(xd).Cells(1).Value

                If DataGridView1.Rows(xd).Cells(2).Value <> "" Then
                    ObjWs.Cells(A, 3) = Format(CDate(DataGridView1.Rows(xd).Cells(2).Value), "dd/MMM/yyyy") : ObjWs.Cells(A, 3).NumberFormat = "dd/MM/yyyy"
                End If

                ObjWs.Cells(A, 4) = DataGridView1.Rows(xd).Cells(3).Value
                ObjWs.Cells(A, 5) = DataGridView1.Rows(xd).Cells(4).Value
                ObjWs.Cells(A, 6) = DataGridView1.Rows(xd).Cells(5).Value

                If DataGridView1.Rows(xd).Cells(6).Value <> "" Then
                    ObjWs.Cells(A, 7) = Format(CDate(DataGridView1.Rows(xd).Cells(6).Value), "dd/MMM/yyyy") : ObjWs.Cells(A, 7).NumberFormat = "dd/MM/yyyy"
                End If

                ObjWs.Cells(A, 8) = DataGridView1.Rows(xd).Cells(7).Value
                ObjWs.Cells(A, 9) = DataGridView1.Rows(xd).Cells(8).Value
                ObjWs.Cells(A, 10) = DataGridView1.Rows(xd).Cells(9).Value
                ObjWs.Cells(A, 11) = DataGridView1.Rows(xd).Cells(10).Value : ObjWs.Cells(A, 11).numberformat = "#.00"
                ObjWs.Cells(A, 12) = DataGridView1.Rows(xd).Cells(11).Value : ObjWs.Cells(A, 12).numberformat = "#.00"
                ObjWs.Cells(A, 13) = DataGridView1.Rows(xd).Cells(12).Value : ObjWs.Cells(A, 13).numberformat = "#.00"
                ObjWs.Cells(A, 14) = DataGridView1.Rows(xd).Cells(13).Value : ObjWs.Cells(A, 14).numberformat = "#.00"
                A = A + 1
            Next

            A = A - 1
            ' ObjWs.Rows(A).Font.Bold = True

            ObjWs.Columns("A:S").EntireColumn.AutoFit()
            ObjWs.Columns("A:J").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            ObjWs.Columns("K:N").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight

            ObjWs.Columns(1).ColumnWidth = 5.5

            If fso.FileExists("E:\ExcelData\Deliveryfile.xls") = True Then
                fil1 = fso.GetFile("E:\ExcelData\Deliveryfile.xls")
                fil1.Delete()
            End If

            ObjWb.SaveAs("E:\ExcelData\Deliveryfile.xls")
            ObjWb.Close(True)
            AppXls.Quit()

            ObjWs = Nothing
            ObjWb = Nothing
            AppXls = Nothing
            System.Diagnostics.Process.Start("E:\ExcelData\Deliveryfile.xls")
        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        DataGridView1.Rows.Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class