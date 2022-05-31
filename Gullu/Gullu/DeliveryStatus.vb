Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class DeliveryStatus
    Dim cmd, cmd1 As New SqlCommand
    Dim drd, drd1 As SqlDataReader
    Dim r As Integer = 0
    Private Sub DeliveryStatus_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dispose()
        'deliveryregister.MdiParent = mdi
        'deliveryregister.Show()
        'deliveryregister.clickshowtbn()
    End Sub
    Private Sub DeliveryStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If editdeliverystatus = False Then
            lblsrno.Text = autonum("entryno", "deliverystatus")
            TextBox7.Text = autonum("entryno", "deliverystatus")
            lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
            btndel.Visible = False
        End If
    End Sub
    Public Function getdata(ByVal selectcmd) As DataTable
        Try
            openconn()
        Dim datatable As New DataTable
        Dim adapter1Object As New SqlDataAdapter(selectcmd, cnn)
        datatable.Locale = System.Globalization.CultureInfo.InvariantCulture
        adapter1Object.Fill(datatable)
        Return datatable
            closeconn()
        Catch ex As Exception

        End Try
    End Function
    Private Sub fetchdeliveystatus()
        Dim deliveystausfetch As DataTable = getdata("select delivereyDated ,qty ,Selectddelivery from deliverystatus where billno =" & TextBox1.Text & " and  qty > 0")
        For Each r3 In deliveystausfetch.Rows
            Dim NewRowsIndex As Integer = DataGridView1.Rows.Add
            With DataGridView1
                If deliveystausfetch.Rows.Count > 0 Then
                    .Rows(NewRowsIndex).Cells("DeliveredDate").Value = r3.Item("delivereyDated")
                    .Rows(NewRowsIndex).Cells("SelectDel").Value = r3.Item("Selectddelivery")
                    .Rows(NewRowsIndex).Cells("alreadydelivered").Value = Val(r3.Item("qty"))
                    If .Rows(NewRowsIndex).Cells("SelectDel").Value = "True" Then
                        .Rows(NewRowsIndex).Cells("Selectdelivery").Value = True
                    Else
                        .Rows(NewRowsIndex).Cells("Selectdelivery").Value = False
                    End If
                End If
            End With
        Next
    End Sub
    Public Sub displaydatarecord()
        Dim deliverydated As Date
        Dim deliveystausfetch As DataTable
        Dim deliverytable As DataTable
        DataGridView1.Rows.Clear()

        Dim fetchbillno As DataTable = getdata("select * from Delivery where billno =" & Val(TextBox1.Text) & " ")
        TextBox15.Text = fetchbillno.Rows(0).Item("cstbillno")

        deliverytable = getdata("select * from DeliveryStatusTable where billno =" & Val(TextBox1.Text) & " ")
        For Each r3 In deliverytable.Rows

            TextBox7.Text = r3.item("entryno")
            lblsrno.Text = r3.item("srno2")
            TextBox1.Text = r3.item("billno")
            DateTimePicker1.Text = r3.item("billdate")
            'TextBox15.Text = r3.item("cstbillno")
            TextBox2.Text = r3.item("cstname")
            TextBox3.Text = r3.item("mobile")

            TextBox10.Text = r3.item("amountrec")
            If IsDBNull(r3.item("Remarks1")) Then
                TextBox16.Text = ""
            Else
                TextBox16.Text = r3.item("Remarks1")
            End If


            ' TextBox9.Text = Format(r3.item("totalstitching"), "#.00")
        Next

        closeconn()

        Dim totalrecqty As Decimal = 0
        Dim alredyqty As Decimal = 0
        Dim deliveryeddated As Date
        Dim Deliverygridfetch As DataTable
        'Deliverygridfetch = getdata("select d.item ,d.description,d.itemid ,d.qty as deliveryqty,s.qty,d.deliverydate,s.deliveryon  ,d.did    from delivery as d inner join deliverystatus as s on d.cstbillno =s.cstbillno where d.billno=" & Val(TextBox1.Text) & "")

        Deliverygridfetch = getdata("select delivereyDated ,itemid,did,item,description,qty,Selectddelivery,deliveryon,srno,salemanid ,salemanname  from deliverystatus where billno  = " & Val(TextBox1.Text) & " ")
        For Each r4 In Deliverygridfetch.Rows
            Dim NewRowsIndex As Integer = DataGridView1.Rows.Add
            With DataGridView1

                deliverydated = r4.Item("delivereyDated")
                deliveryeddated = r4.Item("deliveryon")
                .Rows(NewRowsIndex).Cells("salemanid").Value = r4.Item("salemanid")
                .Rows(NewRowsIndex).Cells("SaleMan").Value = r4.Item("salemanname")


                .Rows(NewRowsIndex).Cells("itemid").Value = r4.Item("itemid")
                .Rows(NewRowsIndex).Cells("item").Value = r4.Item("item")
                .Rows(NewRowsIndex).Cells("did").Value = r4.Item("did")
                .Rows(NewRowsIndex).Cells("itemid").Value = r4.Item("itemid")
                .Rows(NewRowsIndex).Cells("deliverydate").Value = deliverydated.ToString("dd/MM/yyyy")
                .Rows(NewRowsIndex).Cells("description").Value = r4.Item("description")

                .Rows(NewRowsIndex).Cells("srno").Value = r4.Item("srno")
                .Rows(NewRowsIndex).Cells("qty").Value = 1
                .Rows(NewRowsIndex).Cells("alreadydelivered").Value = Format(r4.Item("qty"), "#.00")


                .Rows(NewRowsIndex).Cells("DeliveredDate").Value = deliveryeddated.ToString("dd/MM/yyyy")
                .Rows(NewRowsIndex).Cells("SelectDel").Value = r4.Item("Selectddelivery")
                If Trim(.Rows(NewRowsIndex).Cells("SelectDel").Value) = "True" Then
                    .Rows(NewRowsIndex).Cells("Selectdelivery").Value = True
                    .Rows(NewRowsIndex).Cells("DeliveredDate").Value = deliveryeddated.ToString("dd/MM/yyyy")
                Else
                    .Rows(NewRowsIndex).Cells("Selectdelivery").Value = False
                    .Rows(NewRowsIndex).Cells("DeliveredDate").Value = ""
                End If



               

                'MsgBox(Val(deliveystausfetch.Rows(0).Item("qty")))
                alredyqty = alredyqty + Val(.Rows(NewRowsIndex).Cells("alreadydelivered").Value)
                totalrecqty = totalrecqty + Val(.Rows(NewRowsIndex).Cells("qty").Value)

            End With

        Next
        closeconn()
        CALCULATEGRIDVIEW()

        TextBox13.Text = totalrecqty
        TextBox12.Text = alredyqty
        TextBox14.Text = totalrecqty - alredyqty
        TextBox4.Text = Format(Val(TextBox8.Text) + Val(TextBox9.Text), "#.00")


        TextBox6.Text = Format(Val(TextBox11.Text) - Val(TextBox5.Text), "#.00")
        Label20.Text = TextBox10.Text
        TextBox11.Text = Format(Val(TextBox4.Text) - Val(Label20.Text), "#.00")

    End Sub
    Private Sub CALCULATEGRIDVIEW()
        Dim balancedelivery As DataTable = getdata("select (anybalance) as balance from delivery where billno = " & TextBox1.Text & "")
        If balancedelivery.Rows.Count > 0 Then
            TextBox8.Text = balancedelivery.Rows(0).Item("balance")
        End If
        
    End Sub
    Public Sub displaydatarecord2()
        Dim deliverydated As Date
        Dim totalrecqty As Decimal = 0
        Dim alredyqty As Decimal = 0
        Dim deliverytable As DataTable
        Dim Deliverygridfetch As DataTable
        DataGridView1.Rows.Clear()
        lblsrno.Text = autonum("entryno", "deliverystatus")
        TextBox7.Text = autonum("entryno", "deliverystatus")
        lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
        deliverytable = getdata("select * from DeliveryTable where billno =" & Val(TextBox1.Text) & " ")
        For Each r3 In deliverytable.Rows
            TextBox1.Text = r3.item("billno")
            DateTimePicker1.Text = r3.item("billdate")
            TextBox15.Text = r3.item("cstbillno")
            TextBox2.Text = r3.item("cstname")
            TextBox3.Text = r3.item("mobile")
            If IsDBNull(r3.item("Remarks1")) Then
                TextBox16.Text = ""
            Else
                TextBox16.Text = r3.item("Remarks1")
            End If
            ' TextBox11.Text = Format(r3.item("totalqty"), "#.00")
            ' TextBox9.Text = Format(r3.item("totalstitching"), "#.00")
        Next
        closeconn()
         Deliverygridfetch = getdata("select deliverydate,itemid,did,item,description,qty,srno,salemanid,salemanname  from delivery where billno = " & Val(TextBox1.Text) & "")
        For Each r4 In Deliverygridfetch.Rows
            Dim NewRowsIndex As Integer = DataGridView1.Rows.Add
            With DataGridView1
                deliverydated = r4.Item("deliverydate")
                .Rows(NewRowsIndex).Cells("itemid").Value = r4.Item("itemid")
                .Rows(NewRowsIndex).Cells("item").Value = r4.Item("item")
                .Rows(NewRowsIndex).Cells("did").Value = r4.Item("did")
                .Rows(NewRowsIndex).Cells("itemid").Value = r4.Item("itemid")
                .Rows(NewRowsIndex).Cells("srno").Value = r4.Item("srno")
                .Rows(NewRowsIndex).Cells("deliverydate").Value = deliverydated.ToString("dd/MM/yyyy")
                .Rows(NewRowsIndex).Cells("description").Value = r4.Item("description")
                .Rows(NewRowsIndex).Cells("qty").Value = Format(r4.Item("qty"), "#.00")
                .Rows(NewRowsIndex).Cells("salemanid").Value = r4.Item("salemanid")
                .Rows(NewRowsIndex).Cells("SaleMan").Value = r4.Item("salemanname")
                ' .Rows(NewRowsIndex).Cells("alreadydelivered").Value = 0
                Dim balancedelivery As DataTable = getdata("select  (anybalance) as balance from delivery where billno = " & TextBox1.Text & " ")
                If balancedelivery.Rows.Count > 0 Then
                    TextBox8.Text = balancedelivery.Rows(0).Item("balance")
                End If
                alredyqty = alredyqty + Val(.Rows(NewRowsIndex).Cells("alreadydelivered").Value)
                totalrecqty = totalrecqty + Val(.Rows(NewRowsIndex).Cells("qty").Value)
            End With
        Next
        closeconn()
        TextBox13.Text = totalrecqty
        TextBox12.Text = alredyqty
        TextBox14.Text = totalrecqty - alredyqty
        TextBox4.Text = Format(Val(TextBox8.Text) + Val(TextBox9.Text), "#.00")
        TextBox11.Text = Format(Val(TextBox4.Text) - Val(TextBox10.Text), "#.00")
        TextBox6.Text = Format(Val(TextBox11.Text) - Val(TextBox5.Text), "#.00")
    End Sub
    Private Sub calculategridqty()
       Dim totalrecqty As Decimal = 0
        Dim alredyqty As Decimal = 0
        Dim r5 As DataGridViewRow
        For Each r5 In DataGridView1.Rows
            alredyqty = alredyqty + Val(r5.Cells("alreadydelivered").Value)
            totalrecqty = totalrecqty + Val(r5.Cells("qty").Value)

        Next
        TextBox13.Text = totalrecqty
        TextBox12.Text = alredyqty
        TextBox14.Text = totalrecqty - alredyqty
    End Sub
    Public Sub displaydata()        'new (not for edit)
        Dim deliverydated As Date
        openconn()
        openconn1()
        openconn2()
        cmd = New SqlCommand("select * from delivery where billno =" & Val(TextBox1.Text) & "", cnn)
        drd = cmd.ExecuteReader
        If drd.Read Then
            TextBox1.Text = drd("billno")
            DateTimePicker1.Text = drd("billdate")
            TextBox15.Text = drd("cstbillno")
            TextBox2.Text = drd("cstname")
            TextBox3.Text = drd("mobile")
            TextBox11.Text = Format(drd("totalqty"), "#.00")
            TextBox9.Text = Format(drd("totalstitching"), "#.00")
        End If
        drd.Close()

        r = 0
        DataGridView1.Rows.Clear()

        'cmd = New SqlCommand("SELECT a.billno, a.billdate, a.cstbillno, a.cstname, a.mobile, a.smid, a.smname, a.tid, a.tname, a.itemid,a.item, a.stitchingcharges, a.did,a.description, a.anybalance, a.totalstitching, a.stitchingrec, SUM(a.qty) AS qty, b.deliveryon, CASE WHEN b.delivered <> 0 THEN b.delivered ELSE 0 END AS delivered,  b.totalamt,a.deliverydate FROM         delivery AS a LEFT OUTER JOIN (SELECT     billno, deliveryon, item, stitchingcharges,tid, totalamt,  SUM(qty) AS delivered FROM          deliverystatus GROUP BY billno, deliveryon, item, stitchingcharges,tid, totalamt) AS b ON a.billno = b.billno AND a.item = b.item AND a.stitchingcharges = b.stitchingcharges and a.tid=b.tid WHERE    a.billno=" & Val(TextBox1.Text) & " GROUP BY a.billno, a.billdate, a.cstbillno, a.cstname, a.mobile, a.smid, a.smname, a.tid, a.tname, a.itemid,a.item, a.stitchingcharges,a.did, a.description, a.anybalance, a.totalstitching, a.stitchingrec, b.deliveryon, b.delivered,  b.totalamt,a.deliverydate", cnn)
        cmd = New SqlCommand("SELECT a.billno, a.billdate, a.cstbillno, a.cstname, a.mobile, a.smid, a.smname, a.tid, a.tname, a.itemid,a.item, a.stitchingcharges, a.did,a.description, a.anybalance, a.totalstitching, a.stitchingrec, SUM(a.qty) AS qty, b.deliveryon, CASE WHEN b.delivered <> 0 THEN b.delivered ELSE 0 END AS delivered,  b.totalamt,a.deliverydate FROM         delivery AS a LEFT OUTER JOIN (SELECT     billno, deliveryon, item, stitchingcharges,tid, totalamt,  SUM(qty) AS delivered FROM          deliverystatus GROUP BY billno, deliveryon, item, stitchingcharges,tid, totalamt) AS b ON a.billno = b.billno AND a.item = b.item AND a.stitchingcharges = b.stitchingcharges and a.tid=b.tid WHERE    a.billno=" & Val(TextBox1.Text) & " GROUP BY a.billno, a.billdate, a.cstbillno, a.cstname, a.mobile, a.smid, a.smname, a.tid, a.tname, a.itemid,a.item, a.stitchingcharges,a.did, a.description, a.anybalance, a.totalstitching, a.stitchingrec, b.deliveryon, b.delivered,  b.totalamt,a.deliverydate", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            deliverydated = drd("deliverydate")
            DataGridView1.Rows.Add()
            DataGridView1.Rows(r).Cells("itemid").Value = drd("itemid")
            DataGridView1.Rows(r).Cells("item").Value = drd("item")
            DataGridView1.Rows(r).Cells("did").Value = drd("did")
            DataGridView1.Rows(r).Cells("deliverydate").Value = deliverydated.ToString("dd/MM/yyyy")
            DataGridView1.Rows(r).Cells("description").Value = drd("description")
            DataGridView1.Rows(r).Cells("qty").Value = Format(drd("qty"), "#.00")
            If Val(DataGridView1.Rows(r).Cells("alreadydelivered").Value) > 0 Then
                DataGridView1.Rows(r).Cells("Selectdelivery").Value = True

                DataGridView1.Rows(r).Cells("DeliveredDate").Value = drd("deliveryon")
                DataGridView1.Rows(r).Cells("SelectDel").Value = "True"
            Else
                DataGridView1.Rows(r).Cells("Selectdelivery").Value = False
                DataGridView1.Rows(r).Cells("DeliveredDate").Value = ""
                DataGridView1.Rows(r).Cells("SelectDel").Value = ""
            End If
          
            If IsDBNull(drd("delivered")) Then
                DataGridView1.Rows(r).Cells("alreadydelivered").Value = 0
                DataGridView1.Rows(r).Cells("balanceqty").Value = Format(Val(drd("qty")), "#.00")
            Else
                DataGridView1.Rows(r).Cells("alreadydelivered").Value = Format(drd("delivered"), "#.00")
                DataGridView1.Rows(r).Cells("balanceqty").Value = Format(Val(drd("qty")) - Val(drd("delivered")), "#.00")
            End If
            DataGridView1.Rows(r).Cells("deliverqty").Value = ""
            DataGridView1.Rows(r).Cells("stitchingrate").Value = Format(Val(drd("stitchingcharges")), "#.00")
            DataGridView1.Rows(r).Cells("stitchingamt").Value = Format(Val(drd("qty")) * Val(drd("stitchingcharges")), "#.00")
            DataGridView1.Rows(r).Cells("tid").Value = drd("tid")
            DataGridView1.Rows(r).Cells("tname").Value = drd("tname")

            'DataGridView1.Rows(r).Cells("DeliveredDate").Value = Now.Date

            TextBox8.Text = Format(drd("anybalance"), "#.00")

            Dim amountrec As Double = 0
            cmd1 = New SqlCommand("select entryno,amountrec from deliverystatus where billno='" & TextBox1.Text & "'group by entryno,amountrec ", cnn1)
            drd1 = cmd1.ExecuteReader
            While drd1.Read
                amountrec = amountrec + Val(drd1("amountrec"))
            End While

            drd1.Close()
            TextBox10.Text = Format(Val(drd("stitchingrec")) + amountrec, "#.00")

            r = r + 1
        End While

        TextBox4.Text = Format(Val(TextBox8.Text) + Val(TextBox9.Text), "#.00")
        TextBox11.Text = Format(Val(TextBox4.Text) - Val(TextBox10.Text), "#.00")
        TextBox6.Text = Format(Val(TextBox11.Text) - Val(TextBox5.Text), "#.00")

        drd.Close()
        openconn2()
        closeconn1()
        closeconn()
    End Sub
  
    'Public Sub displaydata2()           'used for edit entry.(not use display1 because of entryno field .)
    '    r = 0
    '    DataGridView1.Rows.Clear()

    '    openconn()
    '    openconn1()
    '    cmd = New SqlCommand("select * from delivery where billno=" & TextBox1.Text, cnn)
    '    drd = cmd.ExecuteReader
    '    While drd.Read
    '        TextBox1.Text = drd("billno")
    '        DateTimePicker1.Text = drd("billdate")
    '        TextBox15.Text = drd("cstbillno")
    '        TextBox2.Text = drd("cstname")
    '        TextBox3.Text = drd("mobile")
    '        TextBox8.Text = Format(drd("anybalance"), "#.00")
    '        TextBox9.Text = Format(drd("totalstitching"), "#.00")

    '        ' totalamtrec = drd("stitchingrec")

    '        DataGridView1.Rows.Add()
    '        DataGridView1.Rows(r).Cells("item").Value = drd("item")
    '        DataGridView1.Rows(r).Cells("description").Value = drd("description")
    '        DataGridView1.Rows(r).Cells("qty").Value = Format(drd("qty"), "#.00")

    '        ' cmd1 = New SqlCommand("select  alreadydelivered,qty,amountrec from deliverystatus where entryno=" & TextBox7.Text & " and item='" & drd("item") & "' and description='" & drd("description") & "'", cnn1)
    '        cmd1 = New SqlCommand("SELECT     SUM(alreadydelivered) AS alreadydelivered, SUM(qty) AS qty, SUM(amountrec) AS amountrec FROM         deliverystatus WHERE     (billno = 1)", cnn1)
    '        drd1 = cmd1.ExecuteReader
    '        If drd1.Read Then
    '            DataGridView1.Rows(r).Cells("alreadydelivered").Value = Format(Val(drd1("alreadydelivered")), "#.00")
    '            DataGridView1.Rows(r).Cells("deliverqty").Value = Format(Val(drd1("qty")), "#.00")
    '            DataGridView1.Rows(r).Cells("balanceqty").Value = Format(Val(drd("qty")) - (Val(drd1("alreadydelivered")) + Val(drd1("qty"))), "#.00")

    '        End If
    '        drd1.Close()
    '        r = r + 1
    '    End While
    '    drd.Close()

    '    TextBox4.Text = Format(Val(TextBox8.Text) + Val(TextBox9.Text), "#.00")
    '    TextBox11.Text = Format(Val(TextBox4.Text) - Val(TextBox10.Text), "#.00")
    '    TextBox6.Text = Format(Val(TextBox11.Text) - Val(TextBox5.Text), "#.00")

    '    drd.Close()
    '    closeconn()
    'End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        'If e.ColumnIndex = 7 And Val(DataGridView1.Rows(e.RowIndex).Cells("deliverqty").Value) <= Val(DataGridView1.Rows(e.RowIndex).Cells("qty").Value) And Not (Val(DataGridView1.Rows(e.RowIndex).Cells("qty").Value) - (Val(DataGridView1.Rows(e.RowIndex).Cells("alreadydelivered").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("deliverqty").Value))) < 0 Then
        '    DataGridView1.Rows(e.RowIndex).Cells("deliverqty").Value = Format(Val(DataGridView1.Rows(e.RowIndex).Cells("deliverqty").Value), "#.00")
        '    DataGridView1.Rows(e.RowIndex).Cells("balanceqty").Value = Format(Val(DataGridView1.Rows(e.RowIndex).Cells("qty").Value) - (Val(DataGridView1.Rows(e.RowIndex).Cells("alreadydelivered").Value) + Val(DataGridView1.Rows(e.RowIndex).Cells("deliverqty").Value)), "#.00")
        'Else
        '    MsgBox("Invalid Quantity", vbCritical, "Alert!!!")
        '    DataGridView1.Rows(e.RowIndex).Cells("deliverqty").Value = ""
        'End If
    End Sub

    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If DataGridView1.CurrentCell.ColumnIndex = 4 Then
            AddHandler CType(e.Control, TextBox).KeyPress, AddressOf TxtCheck_keyPress
        End If
    End Sub

    Private Sub TxtCheck_keyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        If Not (Char.IsDigit(CChar(CStr(e.KeyChar))) Or e.KeyChar = "." Or Asc(e.KeyChar) = 8) Then e.Handled = True
    End Sub
    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If editdeliverystatus = True Then
            DeleteTrans()
        Else
            lblsrno.Text = autonum("entryno", "deliverystatus")
            TextBox7.Text = autonum("entryno", "deliverystatus")
            lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
        End If
        If editdeliverystatus = True Then
            DeleteTrans()
            openconn()

            cmd = New SqlCommand("Update DeliveryStatusTable set entryno=@entryno,billno=@billno,billdate=@billdate,cstbillno=@cstbillno,cstname=@cstname,mobile=@mobile,updateusername=@updateusername,pcname=@pcname,updatelogtime=@updatelogtime,finyear=@finyear,totalamt=@totalamt,alreadyrec=@alreadyrec,amountrec=@amountrec,totalbalance=@totalbalance,srno2=@srno2,totalrecqty=@totalrecqty,totaldelived=@totaldelived ,balqty=@balqty,Remarks1=@Remarks1 where billno = @billno ", cnn)
            cmd.Parameters.AddWithValue("@entryno", TextBox7.Text)
            cmd.Parameters.AddWithValue("@billno", TextBox1.Text)
            cmd.Parameters.AddWithValue("@billdate", DateTimePicker1.Value.Date)
            cmd.Parameters.AddWithValue("@cstbillno", TextBox15.Text)
            cmd.Parameters.AddWithValue("@cstname", TextBox2.Text)
            cmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
            cmd.Parameters.AddWithValue("@updateusername", Trim(mdi.lblusername.Text))
            cmd.Parameters.AddWithValue("@updatelogtime", Now.ToString())
            cmd.Parameters.AddWithValue("@pcname", Trim(mdi.lblPcname.Text))
            cmd.Parameters.AddWithValue("@finyear", "22-23")
            cmd.Parameters.AddWithValue("@totalamt", Val(TextBox4.Text))
            'cmd.Parameters.AddWithValue("@alreadyrec", TextBox10.Text)     'no need alreadyrec field can b removed
            cmd.Parameters.AddWithValue("@alreadyrec", Val(Label20.Text))
            cmd.Parameters.AddWithValue("@totalbalance", Val(TextBox11.Text))
            cmd.Parameters.AddWithValue("@amountrec", Val(Label20.Text))
            cmd.Parameters.AddWithValue("@srno2", Val(lblsrno.Text))
            cmd.Parameters.AddWithValue("@totalrecqty", Val(TextBox13.Text))
            cmd.Parameters.AddWithValue("@totaldelived", Val(TextBox12.Text))
            cmd.Parameters.AddWithValue("@balqty", Val(TextBox14.Text))
            cmd.Parameters.AddWithValue("@Remarks1", Trim(TextBox16.Text))
            cmd.ExecuteNonQuery()
            closeconn()
        Else
            lblsrno.Text = autonum("entryno", "deliverystatus")
            TextBox7.Text = autonum("entryno", "deliverystatus")
            lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
            openconn()
            cmd = New SqlCommand("insert into DeliveryStatusTable(entryno,billno,billdate,cstbillno,cstname,mobile,updateusername,username,pcname,logintime,updatelogtime,finyear,totalamt,alreadyrec,amountrec,totalrecqty ,totaldelived ,balqty,totalbalance,srno2,Remarks1)values(@entryno,@billno,@billdate,@cstbillno,@cstname,@mobile,@updateusername,@username,@pcname,@logintime,@updatelogtime,@finyear,@totalamt,@alreadyrec,@amountrec,@totalrecqty,@totaldelived,@balqty,@totalbalance,@srno2,@Remarks1)", cnn)
            cmd.Parameters.AddWithValue("@entryno", Val(TextBox7.Text))
            cmd.Parameters.AddWithValue("@billno", TextBox1.Text)
            cmd.Parameters.AddWithValue("@billdate", (DateTimePicker1.Value.Date))
            cmd.Parameters.AddWithValue("@cstbillno", TextBox15.Text)
            cmd.Parameters.AddWithValue("@cstname", Trim(TextBox2.Text))
            cmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
            cmd.Parameters.AddWithValue("@updateusername", Trim(mdi.lblusername.Text))
            cmd.Parameters.AddWithValue("@updatelogtime", Now.ToString)
            cmd.Parameters.AddWithValue("@username", Trim(mdi.lblusername.Text))
            cmd.Parameters.AddWithValue("@pcname", Trim(mdi.lblPcname.Text))
            cmd.Parameters.AddWithValue("@logintime", Now.ToString)
            cmd.Parameters.AddWithValue("@finyear", "22-23")
            cmd.Parameters.AddWithValue("@totalamt", Val(TextBox4.Text))
            'cmd.Parameters.AddWithValue("@alreadyrec", TextBox10.Text)     'no need alreadyrec field can b removed
            cmd.Parameters.AddWithValue("@alreadyrec", Val(Label20.Text))
            cmd.Parameters.AddWithValue("@amountrec", Val(Label20.Text))
            cmd.Parameters.AddWithValue("@totalbalance", Val(TextBox11.Text))
            cmd.Parameters.AddWithValue("@totalrecqty", Val(TextBox13.Text))
            cmd.Parameters.AddWithValue("@totaldelived", Val(TextBox12.Text))
            cmd.Parameters.AddWithValue("@balqty", Val(TextBox14.Text))
            cmd.Parameters.AddWithValue("@srno2", Val(lblsrno.Text))
            cmd.Parameters.AddWithValue("@Remarks1", Trim(TextBox16.Text))
            cmd.ExecuteNonQuery()
            closeconn()
        End If
        Try
            DeleteTrans()
            openconn()
            For a As Integer = 0 To DataGridView1.Rows.Count - 1
                cmd = New SqlCommand("insert into deliverystatus(entryno,billno,billdate,cstbillno,cstname,mobile,deliveryon,itemid,item,did,description,totalqty,alreadydelivered,qty,totalamt,alreadyrec,amountrec,delivereyDated,Selectddelivery,srno,username,srno2,salemanid,salemanname,Remarks1)values(@entryno,@billno,@billdate,@cstbillno,@cstname,@mobile,@deliveryon,@itemid,@item,@did,@description,@totalqty,@alreadydelivered,@qty,@totalamt,@alreadyrec,@amountrec,@delivereyDated,@Selectddelivery,@srno,@username,@srno2,@salemanid,@salemanname,@Remarks1)", cnn)
                cmd.Parameters.AddWithValue("@entryno", TextBox7.Text)
                cmd.Parameters.AddWithValue("@billno", TextBox1.Text)
                cmd.Parameters.AddWithValue("@billdate", DateTimePicker1.Value.Date)
                cmd.Parameters.AddWithValue("@cstbillno", TextBox15.Text)
                cmd.Parameters.AddWithValue("@cstname", TextBox2.Text)
                cmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
                ' cmd.Parameters.AddWithValue("@deliveryon", DateTimePicker2.Value.Date)
                If Trim(DataGridView1.Rows(a).Cells("SelectDel").Value) = "" Then
                    cmd.Parameters.AddWithValue("@deliveryon", "")
                Else
                    cmd.Parameters.AddWithValue("@deliveryon", CDate(DataGridView1.Rows(a).Cells("DeliveredDate").Value))
                End If
                cmd.Parameters.AddWithValue("@delivereyDated", CDate(DataGridView1.Rows(a).Cells("DeliveryDate").Value))
                cmd.Parameters.AddWithValue("@Selectddelivery", Trim(DataGridView1.Rows(a).Cells("SelectDel").Value))
                cmd.Parameters.AddWithValue("@itemid", DataGridView1.Rows(a).Cells("itemid").Value)
                cmd.Parameters.AddWithValue("@item", DataGridView1.Rows(a).Cells("item").Value)
                cmd.Parameters.AddWithValue("@did", DataGridView1.Rows(a).Cells("did").Value)
                cmd.Parameters.AddWithValue("@description", DataGridView1.Rows(a).Cells("description").Value)
                cmd.Parameters.AddWithValue("@totalqty", DataGridView1.Rows(a).Cells("qty").Value)
                cmd.Parameters.AddWithValue("@alreadydelivered", Val(DataGridView1.Rows(a).Cells("alreadydelivered").Value))
                cmd.Parameters.AddWithValue("@qty", Val(DataGridView1.Rows(a).Cells("alreadydelivered").Value))
                cmd.Parameters.AddWithValue("@salemanid", Val(DataGridView1.Rows(a).Cells("salemanid").Value))
                cmd.Parameters.AddWithValue("@salemanname", Trim(DataGridView1.Rows(a).Cells("SaleMan").Value))
                cmd.Parameters.AddWithValue("@totalamt", Val(TextBox4.Text))
                cmd.Parameters.AddWithValue("@Remarks1", Trim(TextBox16.Text))
                'cmd.Parameters.AddWithValue("@alreadyrec", TextBox10.Text)     'no need alreadyrec field can b removed
                cmd.Parameters.AddWithValue("@alreadyrec", "")
                cmd.Parameters.AddWithValue("@amountrec", Label20.Text)
                cmd.Parameters.AddWithValue("@srno", Val(DataGridView1.Rows(a).Cells("srno").Value))
                cmd.Parameters.AddWithValue("@username", mdi.lblusername.Text)
                cmd.Parameters.AddWithValue("@srno2", Val(lblsrno.Text))
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
        End Try
        closeconn()
        openconn()
        For a As Integer = 0 To DataGridView1.Rows.Count - 1
            cmd = New SqlCommand("insert into StockDetail(Stockrecno,slipno,vohtype,alrefno,billdate,cstbillno,cstname,mobile,itemid,item,did,description,salemanid,saleman,receiptqty,delivereyDated,Deliverddate,recivedqty,alreadyqty,selctdelivedqty,Totalqty,totalrecqty,totalbalqty,totalamt,totalrecbal,totalbalance,username,entryno,Remarks1)values(@Stockrecno,@slipno,@vohtype,@alrefno,@billdate,@cstbillno,@cstname,@mobile,@itemid,@item,@did,@description,@salemanid,@saleman,@receiptqty,@delivereyDated,@Deliverddate,@recivedqty,@alreadyqty,@selctdelivedqty,@Totalqty,@totalrecqty,@totalbalqty,@totalamt,@totalrecbal,@totalbalance,@username,@entryno,@Remarks1)", cnn)
            cmd.Parameters.AddWithValue("@Stockrecno", lblstocksrno.Text)
            cmd.Parameters.AddWithValue("@vohtype", "Delivery")
            cmd.Parameters.AddWithValue("@alrefno", "Delivery-" & TextBox7.Text)
            cmd.Parameters.AddWithValue("@slipno", TextBox1.Text)
            cmd.Parameters.AddWithValue("@billdate", CDate(DateTimePicker1.Value.Date))
            cmd.Parameters.AddWithValue("@cstbillno", TextBox15.Text)
            cmd.Parameters.AddWithValue("@cstname", Trim(TextBox2.Text))
            cmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
            cmd.Parameters.AddWithValue("@delivereyDated", CDate(DataGridView1.Rows(a).Cells("DeliveryDate").Value))
            cmd.Parameters.AddWithValue("@salemanid", Val(DataGridView1.Rows(a).Cells("salemanid").Value))
            cmd.Parameters.AddWithValue("@saleman", Trim(DataGridView1.Rows(a).Cells("Saleman").Value))
            cmd.Parameters.AddWithValue("@itemid", Val(DataGridView1.Rows(a).Cells("itemid").Value))
            cmd.Parameters.AddWithValue("@item", Trim(DataGridView1.Rows(a).Cells("item").Value))
            cmd.Parameters.AddWithValue("@did", DataGridView1.Rows(a).Cells("did").Value)
            cmd.Parameters.AddWithValue("@description", Trim(DataGridView1.Rows(a).Cells("description").Value))
            cmd.Parameters.AddWithValue("@receiptqty", Val(DataGridView1.Rows(a).Cells("qty").Value))
            cmd.Parameters.AddWithValue("@Totalqty", Val(TextBox13.Text))
            cmd.Parameters.AddWithValue("@totalrecqty", TextBox12.Text)
            cmd.Parameters.AddWithValue("@totalbalqty", Val(TextBox14.Text))
            cmd.Parameters.AddWithValue("@username", mdi.lblusername.Text)

            cmd.Parameters.AddWithValue("@Remarks1", Trim(TextBox16.Text))

            cmd.Parameters.AddWithValue("@alreadyqty", "00")
            '  cmd.Parameters.AddWithValue("@Deliverddate", "")
            '  cmd.Parameters.AddWithValue("@receiptqty", "00")
            cmd.Parameters.AddWithValue("@recivedqty", Val(DataGridView1.Rows(a).Cells("alreadydelivered").Value))
            If Trim(DataGridView1.Rows(a).Cells("SelectDel").Value) = "" Then
                cmd.Parameters.AddWithValue("@Deliverddate", "")
            Else
                cmd.Parameters.AddWithValue("@Deliverddate", CDate(DataGridView1.Rows(a).Cells("DeliveredDate").Value))
            End If
            cmd.Parameters.AddWithValue("@selctdelivedqty", Trim(DataGridView1.Rows(a).Cells("SelectDel").Value))
            cmd.Parameters.AddWithValue("@totalamt", TextBox8.Text)
            cmd.Parameters.AddWithValue("@totalrecbal", Val(TextBox5.Text))
            cmd.Parameters.AddWithValue("@totalbalance", Val(Label20.Text))
            cmd.Parameters.AddWithValue("@entryno", TextBox7.Text)
            cmd.ExecuteNonQuery()
        Next
        closeconn()
        print()
        lblsrno.Text = autonum("entryno", "deliverystatus")
        TextBox7.Text = autonum("entryno", "deliverystatus")
        Dispose()
        deliveryregister.MdiParent = mdi
        deliveryregister.Show()
        deliveryregister.SendToBack()
        deliveryregister.clickshowtbn()

    End Sub

    Private Sub print()
        print_billno = Val(lblsrno.Text)
        ' Dim CReport As New DeliveryStatusRpt
        Dim CReport As New DeliveryPrintstatus
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


        'CReport.SetParameterValue("billno", print_billno)

        CReport.RecordSelectionFormula = "{deliverystatus.srno2} = " & print_billno
        DeliveryStatusPrint.CrystalReportViewer1.ReportSource = CReport
        DeliveryStatusPrint.CrystalReportViewer1.Refresh()

        For a As Integer = 0 To Val(TextBox7.Text)
            Dim recqty As Decimal = 0
            Dim delivedqty As Decimal = 0
            Dim balanceqty As Decimal = 0


            Dim recbal As Decimal = 0
            Dim bilbalance As Decimal = 0
            Dim totalbalance As Decimal = 0
            Dim IGST As String = ""
            Dim CGST As String = ""
            Dim SGST As String = ""
            Dim TotalTax As String = ""
            Dim TotalQty As String = ""
            Dim UnitName As String = ""
            openconn()
            cmd = New SqlCommand("select totalrecqty ,totaldelived ,balqty,totalbalance,totalamt,sum(amountrec) as amountrec  from DeliveryStatusTable where srno2 =" & print_billno & "  group by totalrecqty ,totaldelived ,balqty,totalbalance,totalamt ", cnn)
            drd = cmd.ExecuteReader
            While drd.Read
                If IsDBNull(drd("totalrecqty")) Then
                    recqty = 0
                Else
                    recqty = drd("totalrecqty")
                End If
                If IsDBNull(drd("totaldelived")) Then
                    delivedqty = 0
                Else
                    delivedqty = drd("totaldelived")
                End If
                If IsDBNull(drd("balqty")) Then
                    balanceqty = 0
                Else
                    balanceqty = drd("balqty")
                End If
                If IsDBNull(drd("amountrec")) Then
                    totalbalance = 0
                Else
                    totalbalance = drd("amountrec")
                End If
                If IsDBNull(drd("totalbalance")) Then
                    recbal = 0
                Else
                    recbal = drd("totalbalance")
                End If
                If IsDBNull(drd("totalamt")) Then
                    bilbalance = 0
                Else
                    bilbalance = drd("totalamt")
                End If
            End While
            drd.Close()
            closeconn()
            Dim txtHSNCode As CrystalDecisions.CrystalReports.Engine.TextObject
            txtHSNCode = CReport.ReportDefinition.Sections(0).ReportObjects("Text12")
            txtHSNCode.Text = Trim(recqty)
            Dim txtGstrate As CrystalDecisions.CrystalReports.Engine.TextObject
            txtGstrate = CReport.ReportDefinition.Sections(0).ReportObjects("Text15")
            txtGstrate.Text = Trim(delivedqty)
            Dim txtTaxableAmt As CrystalDecisions.CrystalReports.Engine.TextObject
            txtTaxableAmt = CReport.ReportDefinition.Sections(0).ReportObjects("Text20")
            txtTaxableAmt.Text = Trim(balanceqty)

            Dim recbalance As CrystalDecisions.CrystalReports.Engine.TextObject
            recbalance = CReport.ReportDefinition.Sections(0).ReportObjects("Text21")
            recbalance.Text = Trim(recbal)
            Dim totalamount As CrystalDecisions.CrystalReports.Engine.TextObject
            totalamount = CReport.ReportDefinition.Sections(0).ReportObjects("Text23")
            totalamount.Text = Trim(totalbalance)
            Dim billbal As CrystalDecisions.CrystalReports.Engine.TextObject
            billbal = CReport.ReportDefinition.Sections(0).ReportObjects("Text22")
            billbal.Text = Trim(bilbalance)
        Next
        CReport.PrintToPrinter(1, True, 1, 1)

        'DeliveryStatusPrint.MdiParent = mdi
        'DeliveryStatusPrint.Show()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
        ' deliveryregister.MdiParent = mdi
        ' deliveryregister.Show()
        ' deliveryregister.clickshowtbn()
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
    Private Sub TextBox5_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.LostFocus
        TextBox5.Text = Format(Val(TextBox5.Text), "#.00")
        TextBox6.Text = Format(Val(TextBox11.Text) - Val(TextBox5.Text), "#.00")
    End Sub
    'Private Sub calculations()
    '    Dim totalstitching As Double = 0
    '    Dim j As Integer

    '    For j = 0 To DataGridView1.Rows.Count - 1
    '        totalstitching = Val(totalstitching) + Val(DataGridView1.Rows(j).Cells("stitching").Value)
    '    Next
    '    TextBox9.Text = Format(totalstitching, "#.00")
    'End Sub
  

    'Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
    '    Dim ch As String
    '    ch = MsgBox("Are You Sure To Delete?...", vbYesNo, "Confirm!!!")
    '    If ch = vbYes Then
    '        If Trim(TextBox1.Text) <> "" Then
    '            DeleteTrans()
    '            Dispose()
    '            DeliveryStatusRegister.MdiParent = mdi
    '            DeliveryStatusRegister.Show()
    '            DeliveryStatusRegister.clickshowtbn()
    '        End If
    '    End If
    'End Sub
    Private Sub DeleteTrans()
        openconn()
        cmd = New SqlCommand("delete from deliverystatus where billno=" & TextBox1.Text & " and username='" & mdi.lblusername.Text & "'", cnn)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("delete from StockDetail where slipno=" & TextBox1.Text & "  and vohtype='Delivery'", cnn)
        cmd.ExecuteNonQuery()
        closeconn()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
    Private Sub empteyrecord()
        Label20.Text = "00"
        TextBox4.Text = "00"
        TextBox10.Text = "00"
        TextBox11.Text = "00"
        DataGridView1.Rows.Clear()
        TextBox16.Text = ""
        TextBox13.Text = "00"
        TextBox12.Text = "00"
        TextBox14.Text = "00"
    End Sub
    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        empteyrecord()
        Dim fetchbillnno As DataTable = getdata("select billno from deliverystatus where billno ='" & TextBox1.Text & "'")
        '  Try
        If fetchbillnno.Rows.Count > 0 Then
            Try

                editdeliverystatus = True
                displaydatarecord()
            Catch ex As Exception
            End Try
        Else
            ' Try

            displaydatarecord2()
            '        Catch ex As Exception
            'End Try
        End If
        'Catch ex As Exception
        'End Try
        ' displaydatarecord()
    End Sub

    Private Sub DataGridView1_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        If e.ColumnIndex = 0 Then


            If DataGridView1.CurrentRow.Cells("Selectdelivery").Value = True Then
                DataGridView1.CurrentRow.Cells("SelectDel").Value = True
                DataGridView1.CurrentRow.Cells("DeliveredDate").Value = DateTimePicker2.Value.ToString("dd/MM/yyyy")
               
                DataGridView1.CurrentRow.Cells("alreadydelivered").Value = 1

            Else
                DataGridView1.CurrentRow.Cells("SelectDel").Value = ""
                'DataGridView1.CurrentRow.Cells("DeliveredDate").Value = ""
                DataGridView1.CurrentRow.Cells("alreadydelivered").Value = 0
            End If
        End If
        If e.ColumnIndex = 5 And DataGridView1.CurrentRow.Cells("Selectdelivery").Value = True Then
            If IsDate(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value) = False Then

                MsgBox("Invaild Date")
                DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value = DateTimePicker2.Value.ToString("dd/MM/yyyy")
            Else
                'DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value = DateTimePicker2.Value.ToString("dd/MM/yyyy")
            End If
        End If
        calculategridqty()
    End Sub
    Private Sub calculatebal()
        Dim toatalbal As Decimal = 0
        If Val(TextBox5.Text) > 0 Then
            toatalbal = Val(TextBox10.Text) + Val(TextBox5.Text)
            Label20.Text = toatalbal
            TextBox11.Text = Val(TextBox4.Text) - Val(Label20.Text)
        End If
        'toatalbal = Val(TextBox11.Text) - Val(TextBox5.Text)
        'Label20.Text = toatalbal
        ' TextBox10.Text = Label20.Text
    End Sub
    Private Sub TextBox5_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox5.TextChanged
        calculatebal()
    End Sub

    Private Sub TextBox15_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox15.TextChanged

    End Sub

    Private Sub btndel_Click(sender As System.Object, e As System.EventArgs) Handles btndel.Click
        openconn()
        cmd = New SqlCommand("delete from deliverystatus where entryno=" & TextBox7.Text & "", cnn)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("delete from DeliveryStatusTable where entryno=" & TextBox7.Text & "", cnn)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("delete from StockDetail where entryno=" & TextBox7.Text & "  and vohtype='Receipt'", cnn)
        cmd.ExecuteNonQuery()
        closeconn()
        TextBox1.Text = autonum("entryno", "deliverystatus")
        lblsrno.Text = autonum("srno2", "deliverystatus")
        lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
        editdelivery = False
    End Sub
End Class