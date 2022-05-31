Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Excel = Microsoft.Office.Interop.Excel

Public Class deliveryregister
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader
    Dim r As Integer = 0

    Dim fso As New Scripting.FileSystemObject
    Dim fil1 As Scripting.File
    Public Function getdata(ByVal selectcmd) As DataTable
        openconn()
        Dim datatable As New DataTable
        Dim adapter1Object As New SqlDataAdapter(selectcmd, cnn)
        datatable.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter1Object.Fill(datatable)
        Return datatable
        closeconn()
    End Function
    Private Sub deliveryregister_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshAll()
        openconn()
        cmd = New SqlCommand("select * from financeyear", cnn)
        drd = cmd.ExecuteReader
        If drd.Read Then
            'DateTimePicker1.MinDate = drd("date1")
            'DateTimePicker1.MaxDate = drd("date2")
            'DateTimePicker2.MinDate = drd("date1")
            'DateTimePicker2.MaxDate = drd("date2")
            DateTimePicker1.Value = drd("date1")
            DateTimePicker2.Value = Format(Date.Now, "dd/MM/yyyy")
        End If
        drd.Close()
        closeconn()
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

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = Len(TextBox1.Text)
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
            e.Handled = True
        Else
            e.Handled = False
        End If

        If Asc(e.KeyChar) = 46 Then
            e.Handled = False
        End If

        If Asc(e.KeyChar) = 8 Then
            e.Handled = False
        End If

        If Asc(e.KeyChar) = 13 Then
            e.Handled = False
            SendKeys.Send("{tab}")
        End If

    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text <> "" Then
            If Len(TextBox1.Text) <> 10 Then
                MsgBox("Please fill proper 10 digits Mobile Number", vbCritical, "Alert!!!")
                TextBox1.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        TextBox4.SelectionStart = 0
        TextBox4.SelectionLength = Len(TextBox4.Text)
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBox5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus
        TextBox5.SelectionStart = 0
        TextBox5.SelectionLength = Len(TextBox5.Text)
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged

    End Sub
    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.SelectionStart = 0
        TextBox2.SelectionLength = Len(TextBox2.Text)
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If ListBox3.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox3.Visible = True
                ListBox3.Height = 200
                ListBox3.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox2.Text = ""
            ListBox3.Visible = False
            ListBox2.SelectedItem = Nothing
            ListBox3.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        ListBox3.Visible = True
        ListBox3.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox3.Items.Count - 1
            str1 = StrConv(TextBox2.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox3.Items.Item(start), 1, length) Then
                ListBox3.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox3.KeyDown
        If e.KeyCode = 38 And ListBox3.SelectedIndex = 0 Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub ListBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox2.Text = ListBox3.Text
            ListBox3.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox2.Text = ""
            ListBox3.Visible = False
            ListBox2.SelectedItem = Nothing
            ListBox3.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        ListBox2.SelectedIndex = ListBox3.SelectedIndex
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.SelectionStart = 0
        TextBox3.SelectionLength = Len(TextBox3.Text)
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If ListBox5.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox5.Visible = True
                ListBox5.Height = 200
                ListBox5.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox3.Text = ""
            ListBox5.Visible = False
            ListBox4.SelectedItem = Nothing
            ListBox5.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        ListBox5.Visible = True
        ListBox5.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox5.Items.Count - 1
            str1 = StrConv(TextBox3.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox5.Items.Item(start), 1, length) Then
                ListBox5.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox5.KeyDown
        If e.KeyCode = 38 And ListBox5.SelectedIndex = 0 Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub ListBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox5.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox3.Text = ListBox5.Text
            ListBox5.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox3.Text = ""
            ListBox5.Visible = False
            ListBox4.SelectedItem = Nothing
            ListBox5.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox5.SelectedIndexChanged
        ListBox4.SelectedIndex = ListBox5.SelectedIndex
    End Sub

    Private Sub btnanew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnanew.Click
        editdelivery = False
        Delivery.MdiParent = mdi
        Delivery.Show()
        Dispose()
    End Sub

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        Dim srno As Integer = 1
        Dim SqlStmt As String = ""
        Dim eno As Integer = 0
        r = 0
        DataGridView1.Rows.Clear()


        If TextBox1.Text <> "" Then
            SqlStmt = SqlStmt & " and a.mobile='" & TextBox1.Text & "'"
        End If

        If TextBox2.Text <> "" Then
            SqlStmt = SqlStmt & " and a.smid=" & ListBox2.Text
        End If

        If TextBox3.Text <> "" Then
            SqlStmt = SqlStmt & " and a.tid=" & ListBox4.Text
        End If

        If TextBox4.Text <> "" Then
            SqlStmt = SqlStmt & " and a.billno=" & TextBox4.Text
        End If
        If TextBox5.Text <> "" Then
            SqlStmt = SqlStmt & " and a.cstbillno=" & TextBox5.Text
        End If

        openconn()
        'cmd = New SqlCommand("select * from delivery where billdate between '" & Format(CDate(DateTimePicker1.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(DateTimePicker2.Text), "yyyy-MM-dd") & "'" & SqlStmt & " order by billno", cnn)
        cmd = New SqlCommand("SELECT a.billno, a.billdate, a.cstbillno,a.deliverydate, a.cstname, a.mobile, a.smid, a.smname, a.item, a.stitchingcharges, SUM(a.qty) AS qty, a.description,a.tid,a.tname, a.anybalance,a.totalqty, a.totalstitching, a.stitchingrec,a.stitchingbal,  b.deliveryon,  CASE WHEN b.delivered <> 0 THEN b.delivered ELSE 0 END AS delivered, b.amountrec, b.totalamt FROM         delivery AS a LEFT OUTER JOIN (SELECT     billno,deliveryon, item, stitchingcharges,totalamt,sum(amountrec) as amountrec , SUM(qty) AS delivered FROM          deliverystatus GROUP BY billno,deliveryon, item, stitchingcharges,totalamt) AS b ON a.billno = b.billno AND a.item = b.item  AND a.stitchingcharges = b.stitchingcharges WHERE  a.deliverydate between '" & Format(CDate(DateTimePicker1.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(DateTimePicker2.Text), "yyyy-MM-dd") & "'" & SqlStmt & "       GROUP BY a.billno, a.billdate, a.cstbillno, a.deliverydate,a.cstname, a.mobile, a.smid, a.smname, a.item, a.stitchingcharges, a.description,a.tid,a.tname, a.anybalance,a.totalqty, a.totalstitching, a.stitchingrec,a.stitchingbal, b.deliveryon, b.delivered, b.amountrec, b.totalamt", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            DataGridView1.Rows.Add()
            If Val(drd("billno")) <> eno Then
                DataGridView1.Rows(r).Cells("srno").Value = srno
                DataGridView1.Rows(r).Cells("billno").Value = drd("billno")
                DataGridView1.Rows(r).Cells("billdate").Value = Format(drd("billdate"), "dd/MM/yyyy")
                DataGridView1.Rows(r).Cells("cstbillno").Value = drd("cstbillno")
                DataGridView1.Rows(r).Cells("anybalance").Value = Format(Val(drd("anybalance")), "#.00")
                DataGridView1.Rows(r).Cells("cstname").Value = drd("cstname")
                DataGridView1.Rows(r).Cells("mobile").Value = drd("mobile")
                DataGridView1.Rows(r).Cells("smname").Value = drd("smname")
                DataGridView1.Rows(r).Cells("deliverydate").Value = Format(drd("deliverydate"), "dd/MM/yyyy")
                DataGridView1.Rows(r).Cells("totalqty").Value = Format(Val(drd("totalqty")), "#.00")

                DataGridView1.Rows(r).Cells("totalstitching").Value = Format(Val(drd("totalstitching")), "#.00")
                DataGridView1.Rows(r).Cells("stitchingrec").Value = Format(Val(drd("stitchingrec")), "#.00")
                DataGridView1.Rows(r).Cells("stitchingbal").Value = Format(Val(drd("stitchingbal")), "#.00")
                DataGridView1.Rows(r).Cells("balanceamt").Value = Format(Val(DataGridView1.Rows(r).Cells("stitchingbal").Value) + Val(DataGridView1.Rows(r).Cells("anybalance").Value), "#.00")
                srno = srno + 1
            End If
            DataGridView1.Rows(r).Cells("item").Value = drd("item")
            DataGridView1.Rows(r).Cells("qty").Value = Format(Val(drd("qty")), "#.00")
            DataGridView1.Rows(r).Cells("des").Value = drd("description")
            DataGridView1.Rows(r).Cells("tname").Value = drd("tname")
            DataGridView1.Rows(r).Cells("stitchingcharges").Value = Format(Val(drd("qty")) * Val(drd("stitchingcharges")), "#.00")
            eno = drd("billno")

            r = r + 1
        End While

        ''To get total at last row
        DataGridView1.Rows.Add()
        Dim max As Integer = DataGridView1.Rows.Count - 1
        DataGridView1.Rows(max).Cells(10).Value = "Totals"
        DataGridView1.Rows(max).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)

        For I = 0 To DataGridView1.Rows.Count - 2
            DataGridView1.Rows(max).Cells(11).Value = Format(Val(DataGridView1.Rows(max).Cells(11).Value) + Val(DataGridView1.Rows(I).Cells(11).Value), "#.00")
            DataGridView1.Rows(max).Cells(13).Value = Format(Val(DataGridView1.Rows(max).Cells(13).Value) + Val(DataGridView1.Rows(I).Cells(13).Value), "#.00")
            DataGridView1.Rows(max).Cells(14).Value = Format(Val(DataGridView1.Rows(max).Cells(14).Value) + Val(DataGridView1.Rows(I).Cells(14).Value), "#.00")
            DataGridView1.Rows(max).Cells(15).Value = Format(Val(DataGridView1.Rows(max).Cells(15).Value) + Val(DataGridView1.Rows(I).Cells(15).Value), "#.00")
            DataGridView1.Rows(max).Cells(16).Value = Format(Val(DataGridView1.Rows(max).Cells(16).Value) + Val(DataGridView1.Rows(I).Cells(16).Value), "#.00")
            DataGridView1.Rows(max).Cells(17).Value = Format(Val(DataGridView1.Rows(max).Cells(17).Value) + Val(DataGridView1.Rows(I).Cells(17).Value), "#.00")
            DataGridView1.Rows(max).Cells(18).Value = Format(Val(DataGridView1.Rows(max).Cells(18).Value) + Val(DataGridView1.Rows(I).Cells(18).Value), "#.00")
        Next

        drd.Close()
        closeconn()

        '---------------------------------------------------------------------


        'Dim srno As Integer = 1
        'Dim SqlStmt As String = ""
        'Dim eno As Integer = 0
        'r = 0
        'DataGridView1.Rows.Clear()


        'If TextBox1.Text <> "" Then
        '    SqlStmt = SqlStmt & " and mobile='" & TextBox1.Text & "'"
        'End If

        'If TextBox2.Text <> "" Then
        '    SqlStmt = SqlStmt & " and smid=" & ListBox2.Text
        'End If

        'If TextBox3.Text <> "" Then
        '    SqlStmt = SqlStmt & " and tid=" & ListBox4.Text
        'End If

        'If TextBox4.Text <> "" Then
        '    SqlStmt = SqlStmt & " and billno=" & TextBox4.Text
        'End If
        'If TextBox5.Text <> "" Then
        '    SqlStmt = SqlStmt & " and cstbillno=" & TextBox5.Text
        'End If

        'openconn()
        'cmd = New SqlCommand("select * from delivery where billdate between '" & Format(CDate(DateTimePicker1.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(DateTimePicker2.Text), "yyyy-MM-dd") & "'" & SqlStmt & " order by billno", cnn)
        'drd = cmd.ExecuteReader
        'While drd.Read
        '    DataGridView1.Rows.Add()
        '    If Val(drd("billno")) <> eno Then
        '        DataGridView1.Rows(r).Cells("srno").Value = srno
        '        DataGridView1.Rows(r).Cells("billno").Value = drd("billno")
        '        DataGridView1.Rows(r).Cells("billdate").Value = Format(drd("billdate"), "dd/MM/yyyy")
        '        DataGridView1.Rows(r).Cells("cstbillno").Value = drd("cstbillno")
        '        DataGridView1.Rows(r).Cells("anybalance").Value = Format(Val(drd("anybalance")), "#.00")
        '        DataGridView1.Rows(r).Cells("cstname").Value = drd("cstname")
        '        DataGridView1.Rows(r).Cells("mobile").Value = drd("mobile")
        '        DataGridView1.Rows(r).Cells("smname").Value = drd("smname")
        '        DataGridView1.Rows(r).Cells("deliverydate").Value = Format(drd("deliverydate"), "dd/MM/yyyy")
        '        DataGridView1.Rows(r).Cells("totalqty").Value = Format(Val(drd("totalqty")), "#.00")

        '        DataGridView1.Rows(r).Cells("totalstitching").Value = Format(Val(drd("totalstitching")), "#.00")
        '        DataGridView1.Rows(r).Cells("stitchingrec").Value = Format(Val(drd("stitchingrec")), "#.00")
        '        DataGridView1.Rows(r).Cells("stitchingbal").Value = Format(Val(drd("stitchingbal")), "#.00")
        '        DataGridView1.Rows(r).Cells("balanceamt").Value = Format(Val(DataGridView1.Rows(r).Cells("stitchingbal").Value) + Val(DataGridView1.Rows(r).Cells("anybalance").Value), "#.00")
        '        srno = srno + 1
        '    End If
        '    DataGridView1.Rows(r).Cells("item").Value = drd("item")
        '    DataGridView1.Rows(r).Cells("qty").Value = Format(Val(drd("qty")), "#.00")
        '    DataGridView1.Rows(r).Cells("des").Value = drd("description")
        '    DataGridView1.Rows(r).Cells("tname").Value = drd("tname")
        '    DataGridView1.Rows(r).Cells("stitchingcharges").Value = Format(Val(drd("qty")) * Val(drd("stitchingcharges")), "#.00")
        '    eno = drd("billno")

        '    r = r + 1
        'End While

        ' ''To get total at last row
        'DataGridView1.Rows.Add()
        'Dim max As Integer = DataGridView1.Rows.Count - 1
        'DataGridView1.Rows(max).Cells(10).Value = "Totals"
        'DataGridView1.Rows(max).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)

        'For I = 0 To DataGridView1.Rows.Count - 2
        '    DataGridView1.Rows(max).Cells(11).Value = Format(Val(DataGridView1.Rows(max).Cells(11).Value) + Val(DataGridView1.Rows(I).Cells(11).Value), "#.00")
        '    DataGridView1.Rows(max).Cells(13).Value = Format(Val(DataGridView1.Rows(max).Cells(13).Value) + Val(DataGridView1.Rows(I).Cells(13).Value), "#.00")
        '    DataGridView1.Rows(max).Cells(14).Value = Format(Val(DataGridView1.Rows(max).Cells(14).Value) + Val(DataGridView1.Rows(I).Cells(14).Value), "#.00")
        '    DataGridView1.Rows(max).Cells(15).Value = Format(Val(DataGridView1.Rows(max).Cells(15).Value) + Val(DataGridView1.Rows(I).Cells(15).Value), "#.00")
        '    DataGridView1.Rows(max).Cells(16).Value = Format(Val(DataGridView1.Rows(max).Cells(16).Value) + Val(DataGridView1.Rows(I).Cells(16).Value), "#.00")
        '    DataGridView1.Rows(max).Cells(17).Value = Format(Val(DataGridView1.Rows(max).Cells(17).Value) + Val(DataGridView1.Rows(I).Cells(17).Value), "#.00")
        '    DataGridView1.Rows(max).Cells(18).Value = Format(Val(DataGridView1.Rows(max).Cells(18).Value) + Val(DataGridView1.Rows(I).Cells(18).Value), "#.00")
        'Next

        'drd.Close()
        'closeconn()


    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If DataGridView1.Rows.Count > 0 Then
            If CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value) <> 0 Then
                Delivery.TextBox1.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value
                Delivery.MdiParent = mdi
                editdelivery = True
                Delivery.Show()
                Delivery.displaydata()
                Me.Hide()
            End If
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = 13 Then
            If DataGridView1.Rows.Count > 0 Then
                If CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value) <> 0 Then
                    Delivery.TextBox1.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value
                    Delivery.MdiParent = mdi
                    editdelivery = True
                    Delivery.Show()
                    Delivery.displaydata()
                    Me.Hide()
                End If
            End If
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
    End Sub

    Public Sub RefreshAll()

        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()

        openconn()

        cmd = New SqlCommand("select * from salesman  order by smname", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox2.Items.Add(drd("smid"))
            ListBox3.Items.Add(drd("smname"))
        End While
        drd.Close()

        cmd = New SqlCommand("select * from tailor  order by tname", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox4.Items.Add(drd("tid"))
            ListBox5.Items.Add(drd("tname"))
        End While
        drd.Close()
        closeconn()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        TextBox1.Text = ""

        TextBox2.Text = ""
        ListBox2.SelectedItem = Nothing
        ListBox3.SelectedItem = Nothing
        ListBox3.Visible = False

        TextBox3.Text = ""
        ListBox4.SelectedItem = Nothing
        ListBox5.SelectedItem = Nothing
        ListBox5.Visible = False

        TextBox4.Text = ""
        DataGridView1.Rows.Clear()
        RefreshAll()

    End Sub

    Public Sub clickshowtbn()
        btnshow.PerformClick()
    End Sub

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
            ObjWs.Cells(A, 1) = "Delivery REGISTER From " & DateTimePicker1.Text & " To " & DateTimePicker2.Text
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
                ObjWs.Cells(A, 5) = DataGridView1.Rows(xd).Cells(4).Value : ObjWs.Cells(A, 5).numberformat = "#.00"
                ObjWs.Cells(A, 6) = DataGridView1.Rows(xd).Cells(5).Value
                ObjWs.Cells(A, 7) = DataGridView1.Rows(xd).Cells(6).Value

                If DataGridView1.Rows(xd).Cells(7).Value <> "" Then
                    ObjWs.Cells(A, 8) = Format(CDate(DataGridView1.Rows(xd).Cells(7).Value), "dd/MMM/yyyy") : ObjWs.Cells(A, 8).NumberFormat = "dd/MM/yyyy"
                End If

                ObjWs.Cells(A, 9) = DataGridView1.Rows(xd).Cells(8).Value : ObjWs.Cells(A, 9).numberformat = "#.00"
                ObjWs.Cells(A, 10) = DataGridView1.Rows(xd).Cells(9).Value
                ObjWs.Cells(A, 11) = DataGridView1.Rows(xd).Cells(10).Value
                ObjWs.Cells(A, 12) = DataGridView1.Rows(xd).Cells(11).Value : ObjWs.Cells(A, 12).numberformat = "#.00"
                ObjWs.Cells(A, 13) = DataGridView1.Rows(xd).Cells(12).Value
                ObjWs.Cells(A, 14) = DataGridView1.Rows(xd).Cells(13).Value : ObjWs.Cells(A, 14).numberformat = "#.00"
                ObjWs.Cells(A, 15) = DataGridView1.Rows(xd).Cells(14).Value : ObjWs.Cells(A, 15).numberformat = "#.00"
                ObjWs.Cells(A, 16) = DataGridView1.Rows(xd).Cells(15).Value : ObjWs.Cells(A, 16).numberformat = "#.00"
                ObjWs.Cells(A, 17) = DataGridView1.Rows(xd).Cells(16).Value : ObjWs.Cells(A, 17).numberformat = "#.00"
                ObjWs.Cells(A, 18) = DataGridView1.Rows(xd).Cells(17).Value : ObjWs.Cells(A, 18).numberformat = "#.00"
                ObjWs.Cells(A, 19) = DataGridView1.Rows(xd).Cells(18).Value : ObjWs.Cells(A, 19).numberformat = "#.00"
                A = A + 1
            Next

            A = A - 1
            ObjWs.Rows(A).Font.Bold = True

            ObjWs.Columns("A:S").EntireColumn.AutoFit()
            ObjWs.Columns("A:D").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            ObjWs.Columns("E:E").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            ObjWs.Columns("F:H").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            ObjWs.Columns("I:I").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            ObjWs.Columns("J:K").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            ObjWs.Columns("L:L").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
            ObjWs.Columns("M:M").HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
            ObjWs.Columns("N:S").HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataGridView1.Rows.Count > 0 Then
            If CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value) <> 0 Then
                DeliveryStatus.TextBox1.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value
                DeliveryStatus.MdiParent = mdi
                ' MsgBox(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value)
                Dim fetchbillnno As DataTable = getdata("select cstbillno from deliverystatus where billno =" & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value & " and username='" & mdi.lblusername.Text & "'")
                If fetchbillnno.Rows.Count > 0 Then
                    editdeliverystatus = True
                    DeliveryStatus.displaydatarecord()

                Else
                    MsgBox("")
                    DeliveryStatus.displaydatarecord2()

                End If
                DeliveryStatus.Show()
                

                Me.Hide()
            End If
        End If
    End Sub

    'print button
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If DataGridView1.RowCount <> 0 Then
            If CStr(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value) <> 0 Then
                print()
            End If
        End If
    End Sub

    Private Sub print()
        print_billno = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("billno").Value
        Dim CReport As New sliprpt
        Dim myConnectionInfo As New ConnectionInfo()
        myConnectionInfo.ServerName = SqlServerName(1)
        myConnectionInfo.DatabaseName = SqlDataBase(1)
        myConnectionInfo.UserID = SqlUserId(1)
        myConnectionInfo.Password = SqlPassword(1)

        CReport.Load()
        Dim myTables As Tables = CReport.Database.Tables
        For Each myTable As CrystalDecisions.CrystalReports.Engine.Table In myTables
            Dim myTableLogonInfo As TableLogOnInfo = myTable.LogOnInfo
            myTableLogonInfo.ConnectionInfo = myConnectionInfo
            myTable.ApplyLogOnInfo(myTableLogonInfo)
        Next
        CReport.SetParameterValue("billno", print_billno)
        ' ''''''CReport.RecordSelectionFormula = "{delivery.billno} = " & print_billno

        slipprint.CrystalReportViewer1.ReportSource = CReport
        slipprint.CrystalReportViewer1.Refresh()

        CReport.PrintToPrinter(1, True, 1, 1)
        'slipprint.MdiParent = mdi
        'slipprint.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim srno As Integer = 1
        Dim SqlStmt As String = ""
        Dim eno As Integer = 0
        r = 0
        DataGridView1.Rows.Clear()

        If TextBox1.Text <> "" Then
            SqlStmt = SqlStmt & " and mobile='" & TextBox1.Text & "'"
        End If

        If TextBox2.Text <> "" Then
            SqlStmt = SqlStmt & " and smid=" & ListBox2.Text
        End If

        If TextBox3.Text <> "" Then
            SqlStmt = SqlStmt & " and tid=" & ListBox4.Text
        End If

        If TextBox4.Text <> "" Then
            SqlStmt = SqlStmt & " and billno=" & TextBox4.Text
        End If
        If TextBox5.Text <> "" Then
            SqlStmt = SqlStmt & " and cstbillno=" & TextBox5.Text
        End If

        openconn()
        '  cmd = New SqlCommand("select * from delivery where deliverydate between '" & Format(CDate(DateTimePicker1.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(DateTimePicker2.Text), "yyyy-MM-dd") & "'" & SqlStmt & " order by billno", cnn)
        cmd = New SqlCommand("SELECT     a.billno, a.billdate, a.cstbillno,a.deliverydate, a.cstname, a.mobile, a.smid, a.smname, a.item, a.stitchingcharges, SUM(a.qty) AS qty, a.description,a.tid,a.tname, a.anybalance,a.totalqty, a.totalstitching, a.stitchingrec,a.stitchingbal,  b.deliveryon,  CASE WHEN b.delivered <> 0 THEN b.delivered ELSE 0 END AS delivered, b.amountrec, b.totalamt FROM         delivery AS a LEFT OUTER JOIN (SELECT     billno,deliveryon, item, stitchingcharges,totalamt,sum(amountrec) as amountrec , SUM(qty) AS delivered FROM          deliverystatus GROUP BY billno,deliveryon, item, stitchingcharges,totalamt) AS b ON a.billno = b.billno AND a.item = b.item  AND a.stitchingcharges = b.stitchingcharges WHERE  a.deliverydate between '" & Format(CDate(DateTimePicker1.Text), "yyyy-MM-dd") & "' and '" & Format(CDate(DateTimePicker2.Text), "yyyy-MM-dd") & "'" & SqlStmt & "       GROUP BY a.billno, a.billdate, a.cstbillno, a.deliverydate,a.cstname, a.mobile, a.smid, a.smname, a.item, a.stitchingcharges, a.description,a.tid,a.tname, a.anybalance,a.totalqty, a.totalstitching, a.stitchingrec,a.stitchingbal, b.deliveryon, b.delivered, b.amountrec, b.totalamt", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            DataGridView1.Rows.Add()
            If Val(drd("billno")) <> eno Then
                DataGridView1.Rows(r).Cells("srno").Value = srno
                DataGridView1.Rows(r).Cells("billno").Value = drd("billno")
                DataGridView1.Rows(r).Cells("billdate").Value = Format(drd("billdate"), "dd/MM/yyyy")
                DataGridView1.Rows(r).Cells("cstbillno").Value = drd("cstbillno")
                DataGridView1.Rows(r).Cells("anybalance").Value = Format(Val(drd("anybalance")), "#.00")
                DataGridView1.Rows(r).Cells("cstname").Value = drd("cstname")
                DataGridView1.Rows(r).Cells("mobile").Value = drd("mobile")
                DataGridView1.Rows(r).Cells("smname").Value = drd("smname")
                DataGridView1.Rows(r).Cells("deliverydate").Value = Format(drd("deliverydate"), "dd/MM/yyyy")
                DataGridView1.Rows(r).Cells("totalqty").Value = Format(Val(drd("totalqty")), "#.00")

                DataGridView1.Rows(r).Cells("totalstitching").Value = Format(Val(drd("totalstitching")), "#.00")
                DataGridView1.Rows(r).Cells("stitchingrec").Value = Format(Val(drd("stitchingrec")), "#.00")
                DataGridView1.Rows(r).Cells("stitchingbal").Value = Format(Val(drd("stitchingbal")), "#.00")
                DataGridView1.Rows(r).Cells("balanceamt").Value = Format(Val(DataGridView1.Rows(r).Cells("stitchingbal").Value) + Val(DataGridView1.Rows(r).Cells("anybalance").Value), "#.00")
                srno = srno + 1
            End If
            DataGridView1.Rows(r).Cells("item").Value = drd("item")
            DataGridView1.Rows(r).Cells("qty").Value = Format(Val(drd("qty")), "#.00")
            DataGridView1.Rows(r).Cells("des").Value = drd("description")
            DataGridView1.Rows(r).Cells("tname").Value = drd("tname")
            DataGridView1.Rows(r).Cells("stitchingcharges").Value = Format(Val(drd("qty")) * Val(drd("stitchingcharges")), "#.00")
            eno = drd("billno")

            r = r + 1
        End While

        ''To get total at last row
        DataGridView1.Rows.Add()
        Dim max As Integer = DataGridView1.Rows.Count - 1
        DataGridView1.Rows(max).Cells(10).Value = "Totals"
        DataGridView1.Rows(max).DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)

        For I = 0 To DataGridView1.Rows.Count - 2
            DataGridView1.Rows(max).Cells(11).Value = Format(Val(DataGridView1.Rows(max).Cells(11).Value) + Val(DataGridView1.Rows(I).Cells(11).Value), "#.00")
            DataGridView1.Rows(max).Cells(13).Value = Format(Val(DataGridView1.Rows(max).Cells(13).Value) + Val(DataGridView1.Rows(I).Cells(13).Value), "#.00")
            DataGridView1.Rows(max).Cells(14).Value = Format(Val(DataGridView1.Rows(max).Cells(14).Value) + Val(DataGridView1.Rows(I).Cells(14).Value), "#.00")
            DataGridView1.Rows(max).Cells(15).Value = Format(Val(DataGridView1.Rows(max).Cells(15).Value) + Val(DataGridView1.Rows(I).Cells(15).Value), "#.00")
            DataGridView1.Rows(max).Cells(16).Value = Format(Val(DataGridView1.Rows(max).Cells(16).Value) + Val(DataGridView1.Rows(I).Cells(16).Value), "#.00")
            DataGridView1.Rows(max).Cells(17).Value = Format(Val(DataGridView1.Rows(max).Cells(17).Value) + Val(DataGridView1.Rows(I).Cells(17).Value), "#.00")
            DataGridView1.Rows(max).Cells(18).Value = Format(Val(DataGridView1.Rows(max).Cells(18).Value) + Val(DataGridView1.Rows(I).Cells(18).Value), "#.00")
        Next
        drd.Close()
        closeconn()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class