Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web

Public Class Deliveryold
    Dim cmd, cmd1 As New SqlCommand
    Dim drd, drd1 As SqlDataReader
    Dim r As Integer = 0

    Private Sub Delivery_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If editdelivery = True Then
            Dispose()
            deliveryregister.MdiParent = mdi
            deliveryregister.Show()
            deliveryregister.clickshowtbn()
        End If
    End Sub

    Private Sub Delivery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If editdelivery = False Then
            TextBox1.Text = autonum("billno", "delivery")
            btndel.Visible = False
            Button3.Visible = False
        End If

        openconn()
        cmd = New SqlCommand("select * from deliverystatus where billno=" & TextBox1.Text, cnn)
        drd = cmd.ExecuteReader
        If drd.Read Then
            btndel.Visible = False
        End If
        drd.Close()
        closeconn()
        '''' Call autocomplete()
        Call refreshall()
        Call refreshall2()
        Call loaditems()

    End Sub

    Public Sub refreshall()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()
        ListBox7.Items.Clear()
        ListBox8.Items.Clear()
        ListBox9.Items.Clear()
        ListBox10.Items.Clear()
        ListBox11.Items.Clear()
        ListBox12.Items.Clear()
        ListBox13.Items.Clear()
        ListBox14.Items.Clear()
        ListBox15.Items.Clear()
        ListBox16.Items.Clear()
        ListBox17.Items.Clear()
        ListBox18.Items.Clear()
        ListBox19.Items.Clear()
        ListBox20.Items.Clear()

        openconn()
        cmd = New SqlCommand("select * from description order by des", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox3.Items.Add(drd("did"))
            ListBox4.Items.Add(drd("des"))
            ListBox5.Items.Add(drd("did"))
            ListBox6.Items.Add(drd("des"))
            ListBox7.Items.Add(drd("did"))
            ListBox8.Items.Add(drd("des"))
            ListBox9.Items.Add(drd("did"))
            ListBox10.Items.Add(drd("des"))
            ListBox11.Items.Add(drd("did"))
            ListBox12.Items.Add(drd("des"))
            ListBox13.Items.Add(drd("did"))
            ListBox14.Items.Add(drd("des"))
            ListBox15.Items.Add(drd("did"))
            ListBox16.Items.Add(drd("des"))
            ListBox17.Items.Add(drd("did"))
            ListBox18.Items.Add(drd("des"))
            ListBox19.Items.Add(drd("did"))
            ListBox20.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()
    End Sub


    Public Sub refreshall2()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        ListBox21.Items.Clear()
        ListBox22.Items.Clear()
        ListBox23.Items.Clear()
        ListBox24.Items.Clear()
        ListBox25.Items.Clear()
        ListBox26.Items.Clear()


        openconn()
        cmd = New SqlCommand("select * from salesman order by smname", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox1.Items.Add(drd("smid"))
            ListBox2.Items.Add(drd("smname"))
        End While
        drd.Close()

        cmd = New SqlCommand("select * from tailor order by tname", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox21.Items.Add(drd("tid"))
            ListBox22.Items.Add(drd("tname"))
            ListBox23.Items.Add(drd("tid"))
            ListBox24.Items.Add(drd("tname"))
            ListBox25.Items.Add(drd("tid"))
            ListBox26.Items.Add(drd("tname"))
        End While
        drd.Close()
        closeconn()
    End Sub

    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.GotFocus
        TextBox2.SelectionStart = 0
        TextBox2.SelectionLength = Len(TextBox2.Text)
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.SelectionStart = 0
        TextBox3.SelectionLength = Len(TextBox3.Text)
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
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

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
        TextBox3.Text = Format(Val(TextBox3.Text), "#.00")
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

    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        TextBox4.Text = StrConv(TextBox4.Text, VbStrConv.Uppercase)
    End Sub

    Private Sub TextBox5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus
        TextBox5.SelectionStart = 0
        TextBox5.SelectionLength = Len(TextBox5.Text)
    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
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

    Private Sub TextBox6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.GotFocus
        TextBox6.SelectionStart = 0
        TextBox6.SelectionLength = Len(TextBox6.Text)
    End Sub

    Private Sub TextBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox6.KeyDown
        If ListBox2.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox2.Visible = True
                ListBox2.Height = 250
                ListBox2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox6.Text = ""
            ListBox2.Visible = False
            ListBox1.SelectedItem = Nothing
            ListBox2.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        ListBox2.Visible = True
        ListBox2.Height = 250

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox2.Items.Count - 1
            str1 = StrConv(TextBox6.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox2.Items.Item(start), 1, length) Then
                ListBox2.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox2.KeyDown
        If e.KeyCode = 38 And ListBox2.SelectedIndex = 0 Then
            TextBox6.Focus()
        End If
    End Sub

    Private Sub ListBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox6.Text = ListBox2.Text
            ListBox2.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox6.Text = ""
            ListBox2.Visible = False
            ListBox1.SelectedItem = Nothing
            ListBox2.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged

    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        If editdelivery = True Then
            Dispose()
            deliveryregister.MdiParent = mdi
            deliveryregister.Show()
            deliveryregister.clickshowtbn()
        Else
            Dispose()
        End If
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        'If Val(TextBox8.Text) <> 0 Then
        '    If Trim(TextBox31.Text) = "" And ListBox24.Text = "" Then
        '        MsgBox("Please select Tailor", vbCritical, "Alert!!!")
        '        TextBox31.Focus()
        '        Exit Sub
        '    End If
        'End If

        'If Val(TextBox10.Text) <> 0 Then
        '    If Trim(TextBox32.Text) = "" And ListBox26.Text = "" Then
        '        MsgBox("Please select Tailor", vbCritical, "Alert!!!")
        '        TextBox32.Focus()
        '        Exit Sub
        '    End If
        'End If


        If Trim(TextBox2.Text) <> "" And Trim(TextBox4.Text) <> "" And ListBox2.Text <> "" And Len(TextBox5.Text) = 10 And Val(TextBox16.Text) <> 0 And DateTimePicker1.Value.Date <= DateTimePicker2.Value.Date Then

            If editdelivery = True Then
                DeleteTrans()
            Else
                TextBox1.Text = autonum("billno", "delivery")
            End If

            openconn()
            For a As Integer = 0 To DataGridView1.Rows.Count - 1
                If Val(DataGridView1.Rows(a).Cells("qty").Value) <> 0 Then

                    cmd = New SqlCommand("insert into delivery(billno,billdate,cstbillno,anybalance,cstname,mobile,smid,smname,deliverydate,item,did,description,qty,totalqty,tid,tname,stitchingcharges,stitchingrec,stitchingbal,remarks,status)values(@billno,@billdate,@cstbillno,@anybalance,@cstname,@mobile,@smid,@smname,@deliverydate,@item,@did,@description,@qty,@totalqty,@tid,@tname,@stitchingcharges,@stitchingrec,@stitchingbal,@remarks,@status)", cnn)
                    cmd.Parameters.AddWithValue("@billno", TextBox1.Text)
                    cmd.Parameters.AddWithValue("@billdate", DateTimePicker1.Value.Date)
                    cmd.Parameters.AddWithValue("@cstbillno", TextBox2.Text)
                    cmd.Parameters.AddWithValue("@anybalance", TextBox3.Text)
                    cmd.Parameters.AddWithValue("@cstname", TextBox4.Text)
                    cmd.Parameters.AddWithValue("@mobile", TextBox5.Text)
                    cmd.Parameters.AddWithValue("@smid", ListBox1.Text)
                    cmd.Parameters.AddWithValue("@smname", ListBox2.Text)
                    cmd.Parameters.AddWithValue("@deliverydate", DateTimePicker2.Value.Date)

                    cmd.Parameters.AddWithValue("@item", DataGridView1.Rows(a).Cells("item").Value)
                    cmd.Parameters.AddWithValue("@qty", DataGridView1.Rows(a).Cells("qty").Value)
                    cmd.Parameters.AddWithValue("@did", DataGridView1.Rows(a).Cells("did").Value)
                    cmd.Parameters.AddWithValue("@description", DataGridView1.Rows(a).Cells("des").Value)
                    cmd.Parameters.AddWithValue("@tid", DataGridView1.Rows(a).Cells("tid").Value)
                    cmd.Parameters.AddWithValue("@tname", DataGridView1.Rows(a).Cells("tname").Value)

                    cmd.Parameters.AddWithValue("@totalqty", TextBox16.Text)
                    'cmd.Parameters.AddWithValue("@stitchingcharges", TextBox27.Text)
                    cmd.Parameters.AddWithValue("@stitchingcharges", DataGridView1.Rows(a).Cells("amt").Value)
                    cmd.Parameters.AddWithValue("@stitchingrec", TextBox28.Text)
                    cmd.Parameters.AddWithValue("@stitchingbal", TextBox29.Text)
                    cmd.Parameters.AddWithValue("@remarks", TextBox30.Text)
                    cmd.Parameters.AddWithValue("@status", "PENDING")
                    cmd.ExecuteNonQuery()
                End If
            Next
            closeconn()
            loaditems()

            If editdelivery = False Then
                SENDSMS()
                print()
            End If

            If editdelivery = True Then
                Dispose()
                deliveryregister.Show()
                deliveryregister.clickshowtbn()
            Else

                TextBox1.Text = autonum("billno", "delivery")
                TextBox2.Text = ""
                TextBox3.Text = ".00"

                TextBox4.Text = ""
                TextBox5.Text = ""

                TextBox6.Text = ""
                ListBox1.SelectedItem = Nothing
                ListBox2.SelectedItem = Nothing
                ListBox2.Visible = False

                TextBox7.Text = ".00"
                TextBox8.Text = ".00"
                TextBox9.Text = ".00"
                TextBox10.Text = ".00"
                TextBox11.Text = ".00"
                TextBox12.Text = ".00"
                TextBox13.Text = ".00"
                TextBox14.Text = ".00"
                TextBox15.Text = ".00"
                TextBox16.Text = ".00"

                TextBox17.Text = ""
                ListBox3.SelectedItem = Nothing
                ListBox4.SelectedItem = Nothing
                ListBox4.Visible = False

                TextBox18.Text = ""
                ListBox5.SelectedItem = Nothing
                ListBox6.SelectedItem = Nothing
                ListBox6.Visible = False

                TextBox19.Text = ""
                ListBox7.SelectedItem = Nothing
                ListBox8.SelectedItem = Nothing
                ListBox8.Visible = False

                TextBox20.Text = ""
                ListBox9.SelectedItem = Nothing
                ListBox10.SelectedItem = Nothing
                ListBox10.Visible = False

                TextBox21.Text = ""
                ListBox11.SelectedItem = Nothing
                ListBox12.SelectedItem = Nothing
                ListBox12.Visible = False

                TextBox22.Text = ""
                ListBox13.SelectedItem = Nothing
                ListBox14.SelectedItem = Nothing
                ListBox14.Visible = False

                TextBox23.Text = ""
                ListBox15.SelectedItem = Nothing
                ListBox16.SelectedItem = Nothing
                ListBox16.Visible = False

                TextBox24.Text = ""
                ListBox17.SelectedItem = Nothing
                ListBox18.SelectedItem = Nothing
                ListBox18.Visible = False

                TextBox25.Text = ""
                ListBox19.SelectedItem = Nothing
                ListBox20.SelectedItem = Nothing
                ListBox20.Visible = False

                TextBox26.Text = ""
                ListBox21.SelectedItem = Nothing
                ListBox22.SelectedItem = Nothing
                ListBox22.Visible = False

                TextBox27.Text = ".00"
                TextBox28.Text = ".00"
                TextBox29.Text = ".00"
                TextBox30.Text = ""
                TextBox33.Text = ".00"

                TextBox34.Text = ".00"
                TextBox35.Text = ".00"
                TextBox36.Text = ".00"
                TextBox37.Text = ".00"
                TextBox38.Text = ".00"
                TextBox39.Text = ".00"

                TextBox31.Text = ""
                ListBox23.SelectedItem = Nothing
                ListBox24.SelectedItem = Nothing
                ListBox24.Visible = False

                TextBox32.Text = ""
                ListBox25.SelectedItem = Nothing
                ListBox26.SelectedItem = Nothing
                ListBox26.Visible = False

                DateTimePicker1.Focus()

                'DisableControls()
                TextBox9.Text = ".00"
                TextBox9.Enabled = False
                TextBox19.Enabled = False
                TextBox31.Enabled = False
                '------------------------------------------
                TextBox11.Text = ".00"
                TextBox11.Enabled = False

                TextBox12.Text = ".00"
                TextBox12.Enabled = False

                TextBox21.Enabled = False
                TextBox22.Enabled = False
                TextBox32.Enabled = False
            End If

        Else

            If Trim(TextBox2.Text) = "" Then
                MsgBox("Please enter Bill No.", vbCritical, "Alert!!!")
                TextBox2.Focus()
                Exit Sub
            End If

            If Trim(TextBox4.Text) = "" Then
                MsgBox("Please fill Name", vbCritical, "Alert!!!")
                TextBox4.Focus()
                Exit Sub
            End If

            If Len(TextBox5.Text) <> 10 Then
                MsgBox("Please fill proper 10 digits Mobile Number", vbCritical, "Alert!!!")
                TextBox5.Focus()
                Exit Sub
            End If

            If ListBox2.SelectedItem = Nothing Then
                MsgBox("Please select salesman", vbCritical, "Alert!!!")
                TextBox6.Focus()
                Exit Sub
            End If

            'If ListBox22.SelectedItem = Nothing Then
            '    MsgBox("Please select Tailor", vbCritical, "Alert!!!")
            '    TextBox26.Focus()
            '    Exit Sub
            'End If

            If DateTimePicker2.Value.Date < DateTimePicker1.Value.Date Then
                MsgBox("Please select correct delivery date", vbCritical, "Alert!!!")
                DateTimePicker2.Focus()
                Exit Sub
            End If
        End If

    End Sub

    Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
        Dim ch As String
        ch = MsgBox("Are You Sure To Delete?...", vbYesNo, "Confirm!!!")
        If ch = vbYes Then
            If Trim(TextBox1.Text) <> "" Then
                DeleteTrans()
                Dispose()
                deliveryregister.MdiParent = mdi
                deliveryregister.Show()
                deliveryregister.clickshowtbn()
            End If
        End If
    End Sub

    Private Sub DeleteTrans()
        openconn()
        cmd = New SqlCommand("delete from delivery where billno=" & TextBox1.Text, cnn)
        cmd.ExecuteNonQuery()
        closeconn()
    End Sub

    Public Sub displaydata()
        DataGridView1.Rows.Clear()
        loaditems()
        openconn1()
        cmd1 = New SqlCommand("select * from delivery where billno=" & TextBox1.Text, cnn1)
        drd1 = cmd1.ExecuteReader

        While drd1.Read
            If drd1("item") = "SUIT" Then
                TextBox7.Text = Format(Val(drd1("qty")), "#.00")
                TextBox34.Text = Format(Val(drd1("stitchingcharges")), "#.00")
                TextBox17.Text = drd1("description")
                ListBox3.Text = drd1("did")
                ListBox4.Text = drd1("description")
                Call ListBox4_KeyPress(ListBox4, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(0).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(0).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(0).Cells("rate").Value = Val(DataGridView1.Rows(0).Cells("amt").Value) / Val(DataGridView1.Rows(0).Cells("qty").Value)
                DataGridView1.Rows(0).Cells("did").Value = drd1("did")
                DataGridView1.Rows(0).Cells("des").Value = drd1("description")
                DataGridView1.Rows(0).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(0).Cells("tname").Value = drd1("tname")
            End If

            If drd1("item") = "SAREE" Then
                TextBox8.Text = Format(Val(drd1("qty")), "#.00")
                TextBox35.Text = Format(Val(drd1("stitchingcharges")), "#.00")
                TextBox18.Text = drd1("description")
                ListBox5.Text = drd1("did")
                ListBox6.Text = drd1("description")
                Call ListBox6_KeyPress(ListBox6, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(1).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(1).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(1).Cells("rate").Value = Val(DataGridView1.Rows(1).Cells("amt").Value) / Val(DataGridView1.Rows(1).Cells("qty").Value)
                DataGridView1.Rows(1).Cells("did").Value = drd1("did")
                DataGridView1.Rows(1).Cells("des").Value = drd1("description")
                DataGridView1.Rows(1).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(1).Cells("tname").Value = drd1("tname")

            End If

            If drd1("item") = "BLOWSE" Then
                TextBox9.Text = Format(Val(drd1("qty")), "#.00")

                TextBox19.Text = drd1("description")
                ListBox7.Text = drd1("did")
                ListBox8.Text = drd1("description")
                Call ListBox8_KeyPress(ListBox8, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(2).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(2).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(2).Cells("rate").Value = Val(DataGridView1.Rows(2).Cells("amt").Value) / Val(DataGridView1.Rows(2).Cells("qty").Value)
                DataGridView1.Rows(2).Cells("did").Value = drd1("did")
                DataGridView1.Rows(2).Cells("des").Value = drd1("description")
                DataGridView1.Rows(2).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(2).Cells("tname").Value = drd1("tname")
            End If

            If drd1("item") = "LEHANGA" Then
                TextBox10.Text = Format(Val(drd1("qty")), "#.00")
                TextBox36.Text = Format(Val(drd1("stitchingcharges")), "#.00")
                TextBox20.Text = drd1("description")
                ListBox9.Text = drd1("did")
                ListBox10.Text = drd1("description")
                Call ListBox10_KeyPress(ListBox10, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(3).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(3).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(3).Cells("rate").Value = Val(DataGridView1.Rows(3).Cells("amt").Value) / Val(DataGridView1.Rows(3).Cells("qty").Value)
                DataGridView1.Rows(3).Cells("did").Value = drd1("did")
                DataGridView1.Rows(3).Cells("des").Value = drd1("description")
                DataGridView1.Rows(3).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(3).Cells("tname").Value = drd1("tname")
            End If

            If drd1("item") = "CHOLI" Then
                TextBox11.Text = Format(Val(drd1("qty")), "#.00")

                TextBox21.Text = drd1("description")
                ListBox11.Text = drd1("did")
                ListBox12.Text = drd1("description")
                Call ListBox12_KeyPress(ListBox12, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(4).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(4).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(4).Cells("rate").Value = Val(DataGridView1.Rows(4).Cells("amt").Value) / Val(DataGridView1.Rows(4).Cells("qty").Value)
                DataGridView1.Rows(4).Cells("did").Value = drd1("did")
                DataGridView1.Rows(4).Cells("des").Value = drd1("description")
                DataGridView1.Rows(4).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(4).Cells("tname").Value = drd1("tname")
            End If

            If drd1("item") = "DUPATTA" Then
                TextBox12.Text = Format(Val(drd1("qty")), "#.00")

                TextBox22.Text = drd1("description")
                ListBox13.Text = drd1("did")
                ListBox14.Text = drd1("description")
                Call ListBox14_KeyPress(ListBox14, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(5).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(5).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(5).Cells("rate").Value = Val(DataGridView1.Rows(5).Cells("amt").Value) / Val(DataGridView1.Rows(5).Cells("qty").Value)
                DataGridView1.Rows(5).Cells("did").Value = drd1("did")
                DataGridView1.Rows(5).Cells("des").Value = drd1("description")
                DataGridView1.Rows(5).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(5).Cells("tname").Value = drd1("tname")
            End If


            If drd1("item") = "GOWN" Then
                TextBox13.Text = Format(Val(drd1("qty")), "#.00")
                TextBox37.Text = Format(Val(drd1("stitchingcharges")), "#.00")

                TextBox23.Text = drd1("description")
                ListBox15.Text = drd1("did")
                ListBox16.Text = drd1("description")
                Call ListBox16_KeyPress(ListBox16, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(6).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(6).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(6).Cells("rate").Value = Val(DataGridView1.Rows(6).Cells("amt").Value) / Val(DataGridView1.Rows(6).Cells("qty").Value)
                DataGridView1.Rows(6).Cells("did").Value = drd1("did")
                DataGridView1.Rows(6).Cells("des").Value = drd1("description")
                DataGridView1.Rows(6).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(6).Cells("tname").Value = drd1("tname")
            End If

            If drd1("item") = "DRESS" Then
                TextBox14.Text = Format(Val(drd1("qty")), "#.00")
                TextBox38.Text = Format(Val(drd1("stitchingcharges")), "#.00")
                TextBox24.Text = drd1("description")
                ListBox17.Text = drd1("did")
                ListBox18.Text = drd1("description")
                Call ListBox18_KeyPress(ListBox18, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(7).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(7).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(7).Cells("rate").Value = Val(DataGridView1.Rows(7).Cells("amt").Value) / Val(DataGridView1.Rows(7).Cells("qty").Value)
                DataGridView1.Rows(7).Cells("did").Value = drd1("did")
                DataGridView1.Rows(7).Cells("des").Value = drd1("description")
                DataGridView1.Rows(7).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(7).Cells("tname").Value = drd1("tname")
            End If

            If drd1("item") = "SATIN" Then
                TextBox15.Text = Format(Val(drd1("qty")), "#.00")
                TextBox39.Text = Format(Val(drd1("stitchingcharges")), "#.00")
                TextBox25.Text = drd1("description")
                ListBox19.Text = drd1("did")
                ListBox20.Text = drd1("description")
                Call ListBox20_KeyPress(ListBox20, New KeyPressEventArgs(Chr(Keys.Enter)))

                DataGridView1.Rows(8).Cells("qty").Value = drd1("qty")
                DataGridView1.Rows(8).Cells("amt").Value = drd1("stitchingcharges")
                DataGridView1.Rows(8).Cells("rate").Value = Val(DataGridView1.Rows(8).Cells("amt").Value) / Val(DataGridView1.Rows(8).Cells("qty").Value)
                DataGridView1.Rows(8).Cells("did").Value = drd1("did")
                DataGridView1.Rows(8).Cells("des").Value = drd1("description")
                DataGridView1.Rows(8).Cells("tid").Value = drd1("tid")
                DataGridView1.Rows(8).Cells("tname").Value = drd1("tname")
            End If

        End While
        drd1.Close()

        openconn()
        cmd = New SqlCommand("select * from delivery where billno=" & TextBox1.Text, cnn)
        drd = cmd.ExecuteReader
        If drd.Read Then
            TextBox1.Text = drd("billno")
            DateTimePicker1.Text = drd("billdate")
            TextBox2.Text = drd("cstbillno")
            TextBox3.Text = Format(drd("anybalance"), "#.00")
            TextBox4.Text = drd("cstname")
            TextBox5.Text = drd("mobile")

            TextBox6.Text = drd("smname")
            ListBox1.Text = drd("smid")
            ListBox2.Text = drd("smname")
            Call ListBox2_KeyPress(ListBox2, New KeyPressEventArgs(Chr(Keys.Enter)))

            DateTimePicker2.Text = drd("deliverydate")
            'TextBox16.Text = Format(drd("totalqty"), "#.00")

            TextBox26.Text = drd("tname")
            ListBox21.Text = drd("tid")
            ListBox22.Text = drd("tname")
            Call ListBox22_KeyPress(ListBox22, New KeyPressEventArgs(Chr(Keys.Enter)))

            If Val(TextBox8.Text) <> 0 Then
                TextBox31.Text = drd("tname")
                ListBox23.Text = drd("tid")
                ListBox24.Text = drd("tname")
                Call ListBox24_KeyPress(ListBox24, New KeyPressEventArgs(Chr(Keys.Enter)))
            End If

            If Val(TextBox10.Text) <> 0 Then
                TextBox32.Text = drd("tname")
                ListBox25.Text = drd("tid")
                ListBox26.Text = drd("tname")
                Call ListBox26_KeyPress(ListBox26, New KeyPressEventArgs(Chr(Keys.Enter)))
            End If

            TextBox27.Text = Format(drd("stitchingcharges"), "#.00")
            TextBox28.Text = Format(drd("stitchingrec"), "#.00")
            TextBox29.Text = Format(drd("stitchingbal"), "#.00")
            TextBox30.Text = drd("remarks")

        End If
        Call calculations()
        '  Call EnableControls()
        'ENABLE CONTROLS
        If Val(TextBox8.Text) <> 0 Then
            TextBox9.Enabled = True
            TextBox19.Enabled = True
            TextBox31.Enabled = True
        End If

        If Val(TextBox10.Text) <> 0 Then
            TextBox11.Enabled = True
            TextBox12.Enabled = True
            TextBox21.Enabled = True
            TextBox22.Enabled = True
            TextBox32.Enabled = True
        End If
    End Sub


    Sub SENDSMS()
        Dim request As HttpWebRequest = Nothing
        Dim response As HttpWebResponse = Nothing
        Dim url As String = Nothing
        Dim MYMESSAGE As String = ""

        MYMESSAGE = "Thanks for shopping at GULLU EXCLUSIVE For any feedback SMS 98765-53181 or call Toll Free 1800-212-3450"
        url = "http://sms.zipzap.in/pushsms.php?username=shikha&api_password=0a77436omfn4b7bh5&sender=GULLUX&to=" & TextBox5.Text & " & message=" & MYMESSAGE & " & priority=11"

        request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        response = DirectCast(request.GetResponse, HttpWebResponse)
        '''''MessageBox.Show("Response: " & response.StatusDescription)
        MsgBox("Message sent Successfully.", vbInformation)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call print()
    End Sub

    Private Sub print()
        print_billno = TextBox1.Text
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

        CReport.RecordSelectionFormula = "{delivery.billno} = " & print_billno
        slipprint.CrystalReportViewer1.ReportSource = CReport
        slipprint.CrystalReportViewer1.Refresh()
        CReport.PrintToPrinter(2, True, 1, 1)

        'slipprint.MdiParent = mdi
        'slipprint.Show()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        refreshall()
        refreshall2()

        TextBox1.Text = autonum("billno", "delivery")

        TextBox6.Text = ""
        ListBox1.SelectedItem = Nothing
        ListBox2.SelectedItem = Nothing
        ListBox2.Visible = False

        'TextBox7.Text = ".00"
        'TextBox8.Text = ".00"
        'TextBox9.Text = ".00"
        'TextBox10.Text = ".00"
        'TextBox11.Text = ".00"
        'TextBox12.Text = ".00"
        'TextBox13.Text = ".00"
        'TextBox14.Text = ".00"
        'TextBox15.Text = ".00"
        'TextBox16.Text = ".00"

        TextBox17.Text = ""
        ListBox3.SelectedItem = Nothing
        ListBox4.SelectedItem = Nothing
        ListBox4.Visible = False

        TextBox18.Text = ""
        ListBox5.SelectedItem = Nothing
        ListBox6.SelectedItem = Nothing
        ListBox6.Visible = False

        TextBox19.Text = ""
        ListBox7.SelectedItem = Nothing
        ListBox8.SelectedItem = Nothing
        ListBox8.Visible = False

        TextBox20.Text = ""
        ListBox9.SelectedItem = Nothing
        ListBox10.SelectedItem = Nothing
        ListBox10.Visible = False

        TextBox21.Text = ""
        ListBox11.SelectedItem = Nothing
        ListBox12.SelectedItem = Nothing
        ListBox12.Visible = False

        TextBox22.Text = ""
        ListBox13.SelectedItem = Nothing
        ListBox14.SelectedItem = Nothing
        ListBox14.Visible = False

        TextBox23.Text = ""
        ListBox15.SelectedItem = Nothing
        ListBox16.SelectedItem = Nothing
        ListBox16.Visible = False

        TextBox24.Text = ""
        ListBox17.SelectedItem = Nothing
        ListBox18.SelectedItem = Nothing
        ListBox18.Visible = False

        TextBox25.Text = ""
        ListBox19.SelectedItem = Nothing
        ListBox20.SelectedItem = Nothing
        ListBox20.Visible = False

        TextBox26.Text = ""
        ListBox21.SelectedItem = Nothing
        ListBox22.SelectedItem = Nothing
        ListBox22.Visible = False

        DateTimePicker1.Focus()
        'EnableControls()
    End Sub

    Private Sub TextBox7_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.GotFocus
        TextBox7.SelectionStart = 0
        TextBox7.SelectionLength = Len(TextBox7.Text)
    End Sub

    Private Sub TextBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox7.KeyPress
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

    Private Sub TextBox7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox7.LostFocus
        TextBox7.Text = Format(Val(TextBox7.Text), "#.00")
        DataGridView1.Rows(0).Cells("qty").Value = Format(Val(TextBox7.Text), "#.00")
        DataGridView1.Rows(0).Cells("amt").Value = Val(DataGridView1.Rows(0).Cells("qty").Value) * Val(DataGridView1.Rows(0).Cells("rate").Value)

        TextBox34.Text = Format(Val(TextBox7.Text) * Val(DataGridView1.Rows(0).Cells("rate").Value), "#.00")

        Call calculations()
    End Sub

    Private Sub TextBox8_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.GotFocus
        TextBox8.SelectionStart = 0
        TextBox8.SelectionLength = Len(TextBox8.Text)
    End Sub

    Private Sub TextBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox8.KeyPress
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

    Private Sub TextBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox8.LostFocus

        'ENABLE CONTROLS
        If Val(TextBox8.Text) <> 0 Then
            TextBox9.Enabled = True
            TextBox19.Enabled = True
            TextBox31.Enabled = True
        Else
            TextBox9.Text = ".00"
            TextBox9.Enabled = False
            TextBox19.Enabled = False
            TextBox31.Enabled = False
        End If

        'sending both items to grid
        TextBox8.Text = Format(Val(TextBox8.Text), "#.00")
        DataGridView1.Rows(1).Cells("qty").Value = Format(Val(TextBox8.Text), "#.00")
        DataGridView1.Rows(1).Cells("amt").Value = Val(DataGridView1.Rows(1).Cells("qty").Value) * Val(DataGridView1.Rows(1).Cells("rate").Value)
        TextBox35.Text = Format(Val(TextBox8.Text) * Val(DataGridView1.Rows(1).Cells("rate").Value), "#.00")


        DataGridView1.Rows(2).Cells("qty").Value = Format(Val(TextBox9.Text), "#.00")
        DataGridView1.Rows(2).Cells("amt").Value = Val(DataGridView1.Rows(2).Cells("qty").Value) * Val(DataGridView1.Rows(2).Cells("rate").Value)


        Call calculations()
    End Sub

    Private Sub TextBox9_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.GotFocus
        TextBox9.SelectionStart = 0
        TextBox9.SelectionLength = Len(TextBox9.Text)
    End Sub

    Private Sub TextBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress
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

    Private Sub TextBox9_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox9.LostFocus
        TextBox9.Text = Format(Val(TextBox9.Text), "#.00")
        DataGridView1.Rows(2).Cells("qty").Value = Format(Val(TextBox9.Text), "#.00")
        DataGridView1.Rows(2).Cells("amt").Value = Val(DataGridView1.Rows(2).Cells("qty").Value) * Val(DataGridView1.Rows(2).Cells("rate").Value)
        Call calculations()

        'DISABLE CONTROLS
        If Val(TextBox9.Text) = 0 Then
            TextBox19.Enabled = False
            ListBox7.Enabled = False
            ListBox8.Enabled = False

            ListBox7.SelectedItem = Nothing
            ListBox8.SelectedItem = Nothing
            ListBox8.Visible = False
        Else
            TextBox19.Enabled = True
            ListBox7.Enabled = True
            ListBox8.Enabled = True
            TextBox19.Focus()
        End If

    End Sub

    Private Sub TextBox10_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.GotFocus
        TextBox10.SelectionStart = 0
        TextBox10.SelectionLength = Len(TextBox10.Text)
    End Sub

    Private Sub TextBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox10.KeyPress
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

    Private Sub TextBox10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox10.LostFocus

        'ENABLE CONTROLS
        If Val(TextBox10.Text) <> 0 Then
            TextBox11.Enabled = True
            TextBox12.Enabled = True
            TextBox21.Enabled = True
            TextBox22.Enabled = True
            TextBox32.Enabled = True
        Else
            TextBox11.Text = ".00"
            TextBox11.Enabled = False

            TextBox12.Text = ".00"
            TextBox12.Enabled = False

            TextBox21.Enabled = False
            TextBox22.Enabled = False
            TextBox32.Enabled = False
        End If

        'adding all three items to grid .
        TextBox10.Text = Format(Val(TextBox10.Text), "#.00")
        DataGridView1.Rows(3).Cells("qty").Value = Format(Val(TextBox10.Text), "#.00")
        DataGridView1.Rows(3).Cells("amt").Value = Val(DataGridView1.Rows(3).Cells("qty").Value) * Val(DataGridView1.Rows(3).Cells("rate").Value)
        TextBox36.Text = Format(Val(TextBox10.Text) * Val(DataGridView1.Rows(3).Cells("rate").Value), "#.00")


        DataGridView1.Rows(4).Cells("qty").Value = Format(Val(TextBox11.Text), "#.00")
        DataGridView1.Rows(4).Cells("amt").Value = Val(DataGridView1.Rows(4).Cells("qty").Value) * Val(DataGridView1.Rows(4).Cells("rate").Value)

        DataGridView1.Rows(5).Cells("qty").Value = Format(Val(TextBox12.Text), "#.00")
        DataGridView1.Rows(5).Cells("amt").Value = Val(DataGridView1.Rows(5).Cells("qty").Value) * Val(DataGridView1.Rows(5).Cells("rate").Value)

        Call calculations()
    End Sub

    Private Sub TextBox11_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox11.GotFocus
        TextBox11.SelectionStart = 0
        TextBox11.SelectionLength = Len(TextBox11.Text)
    End Sub

    Private Sub TextBox11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox11.KeyPress
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

    Private Sub TextBox11_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox11.LostFocus
        TextBox11.Text = Format(Val(TextBox11.Text), "#.00")
        DataGridView1.Rows(4).Cells("qty").Value = Format(Val(TextBox11.Text), "#.00")
        DataGridView1.Rows(4).Cells("amt").Value = Val(DataGridView1.Rows(4).Cells("qty").Value) * Val(DataGridView1.Rows(4).Cells("rate").Value)
        Call calculations()

        'DISABLE CONTROLS
        If Val(TextBox11.Text) = 0 Then
            TextBox21.Enabled = False
            ListBox11.Enabled = False
            ListBox12.Enabled = False

            ListBox11.SelectedItem = Nothing
            ListBox12.SelectedItem = Nothing
            ListBox12.Visible = False
        Else
            TextBox21.Enabled = True
            ListBox11.Enabled = True
            ListBox12.Enabled = True
            TextBox21.Focus()
        End If

    End Sub

    Private Sub TextBox12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox12.GotFocus
        TextBox12.SelectionStart = 0
        TextBox12.SelectionLength = Len(TextBox12.Text)
    End Sub

    Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
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

    Private Sub TextBox12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox12.LostFocus
        TextBox12.Text = Format(Val(TextBox12.Text), "#.00")
        DataGridView1.Rows(5).Cells("qty").Value = Format(Val(TextBox12.Text), "#.00")
        DataGridView1.Rows(5).Cells("amt").Value = Val(DataGridView1.Rows(5).Cells("qty").Value) * Val(DataGridView1.Rows(5).Cells("rate").Value)
        Call calculations()

        'DISABLE CONTROLS
        If Val(TextBox12.Text) = 0 Then
            TextBox22.Enabled = False
            ListBox13.Enabled = False
            ListBox14.Enabled = False

            ListBox13.SelectedItem = Nothing
            ListBox14.SelectedItem = Nothing
            ListBox14.Visible = False
        Else
            TextBox22.Enabled = True
            ListBox13.Enabled = True
            ListBox14.Enabled = True
            TextBox22.Focus()
        End If
    End Sub

    Private Sub TextBox13_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.GotFocus
        TextBox13.SelectionStart = 0
        TextBox13.SelectionLength = Len(TextBox13.Text)
    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
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

    Private Sub TextBox13_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.LostFocus
        TextBox13.Text = Format(Val(TextBox13.Text), "#.00")
        DataGridView1.Rows(6).Cells("qty").Value = Format(Val(TextBox13.Text), "#.00")
        DataGridView1.Rows(6).Cells("amt").Value = Val(DataGridView1.Rows(6).Cells("qty").Value) * Val(DataGridView1.Rows(6).Cells("rate").Value)
        TextBox37.Text = Format(Val(TextBox13.Text) * Val(DataGridView1.Rows(6).Cells("rate").Value), "#.00")

        Call calculations()
    End Sub

    Private Sub TextBox14_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox14.GotFocus
        TextBox14.SelectionStart = 0
        TextBox14.SelectionLength = Len(TextBox14.Text)
    End Sub

    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress
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

    Private Sub TextBox14_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox14.LostFocus
        TextBox14.Text = Format(Val(TextBox14.Text), "#.00")
        DataGridView1.Rows(7).Cells("qty").Value = Format(Val(TextBox14.Text), "#.00")
        DataGridView1.Rows(7).Cells("amt").Value = Val(DataGridView1.Rows(7).Cells("qty").Value) * Val(DataGridView1.Rows(7).Cells("rate").Value)
        TextBox38.Text = Format(Val(TextBox14.Text) * Val(DataGridView1.Rows(7).Cells("rate").Value), "#.00")
        Call calculations()
    End Sub

    Private Sub TextBox15_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox15.GotFocus
        TextBox15.SelectionStart = 0
        TextBox15.SelectionLength = Len(TextBox15.Text)
    End Sub

    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
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

    Private Sub TextBox15_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox15.LostFocus
        TextBox15.Text = Format(Val(TextBox15.Text), "#.00")
        DataGridView1.Rows(8).Cells("qty").Value = Format(Val(TextBox15.Text), "#.00")
        DataGridView1.Rows(8).Cells("amt").Value = Val(DataGridView1.Rows(8).Cells("qty").Value) * Val(DataGridView1.Rows(8).Cells("rate").Value)
        TextBox39.Text = Format(Val(TextBox15.Text) * Val(DataGridView1.Rows(8).Cells("rate").Value), "#.00")
        Call calculations()

    End Sub

    Private Sub TextBox17_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox17.GotFocus
        TextBox17.SelectionStart = 0
        TextBox17.SelectionLength = Len(TextBox17.Text)
    End Sub

    Private Sub TextBox17_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox17.KeyDown
        If ListBox4.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox4.Visible = True
                ListBox4.Height = 200
                ListBox4.Focus()
            End If


            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If


        End If
    End Sub

    Private Sub TextBox17_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox17.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox4.Visible = False
            ListBox3.SelectedItem = Nothing
            ListBox4.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox17_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox17.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox17.Text <> ListBox4.Text And ListBox4.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox17.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox17.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox17.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox17.Text)

                FLAG = 2
                closeconn()
                ' refreshall()
            End If

            DataGridView1.Rows(0).Cells("did").Value = MYITEMID
            DataGridView1.Rows(0).Cells("des").Value = TextBox17.Text
        End If
    End Sub

    Private Sub TextBox17_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox17.TextChanged

        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox17.Text & "%' order by des", cnn)
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox3.Items.Add(drd("did"))
            ListBox4.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()



        ListBox4.Visible = True
        ListBox4.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox4.Items.Count - 1
            str1 = StrConv(TextBox17.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox4.Items.Item(start), 1, length) Then
                ListBox4.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Function GETITEMSYSID(ByVal des As String) As Integer

        openconn1()
        cmd1 = New SqlCommand("SELECT did FROM description WHERE des=@des", cnn1)
        cmd1.Parameters.AddWithValue("@des", des)
        drd1 = cmd1.ExecuteReader
        If drd1.Read Then
            Return drd1("did")
        Else
            Return 0
        End If
        closeconn1()

    End Function

    Private Sub ListBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox4.KeyDown
        If e.KeyCode = 38 And ListBox4.SelectedIndex = 0 Then
            TextBox17.Focus()
        End If
    End Sub

    Private Sub ListBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox17.Text = ListBox4.Text
            ListBox4.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox17.Text = ""
            ListBox4.Visible = False
            ListBox3.SelectedItem = Nothing
            ListBox4.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox4.LostFocus
        DataGridView1.Rows(0).Cells("did").Value = ListBox3.Text
        DataGridView1.Rows(0).Cells("des").Value = ListBox4.Text
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox4.SelectedIndexChanged
        ListBox3.SelectedIndex = ListBox4.SelectedIndex
    End Sub

    Private Sub TextBox18_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox18.GotFocus
        TextBox18.SelectionStart = 0
        TextBox18.SelectionLength = Len(TextBox18.Text)
    End Sub

    Private Sub TextBox18_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox18.KeyDown
        If ListBox6.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox6.Visible = True
                ListBox6.Height = 200
                ListBox6.Focus()
            End If


            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If
        End If
    End Sub

    Private Sub TextBox18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox18.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox6.Visible = False
            ListBox5.SelectedItem = Nothing
            ListBox6.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox18_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox18.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox18.Text <> ListBox6.Text And ListBox6.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox18.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox18.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox18.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox18.Text)
                FLAG = 2
                closeconn()
                ' refreshall()
            End If
        End If
        DataGridView1.Rows(1).Cells("did").Value = MYITEMID
        DataGridView1.Rows(1).Cells("des").Value = TextBox18.Text
    End Sub

    Private Sub TextBox18_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox18.TextChanged
        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox18.Text & "%' order by des", cnn)
        ListBox5.Items.Clear()
        ListBox6.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox5.Items.Add(drd("did"))
            ListBox6.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()


        ListBox6.Visible = True
        ListBox6.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox6.Items.Count - 1
            str1 = StrConv(TextBox18.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox6.Items.Item(start), 1, length) Then
                ListBox6.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox6_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox6.KeyDown
        If e.KeyCode = 38 And ListBox6.SelectedIndex = 0 Then
            TextBox18.Focus()
        End If
    End Sub

    Private Sub ListBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox6.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox18.Text = ListBox6.Text
            ListBox6.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox18.Text = ""
            ListBox6.Visible = False
            ListBox5.SelectedItem = Nothing
            ListBox6.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox6.LostFocus
        DataGridView1.Rows(1).Cells("did").Value = ListBox5.Text
        DataGridView1.Rows(1).Cells("des").Value = ListBox6.Text
    End Sub

    Private Sub ListBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox6.SelectedIndexChanged
        ListBox5.SelectedIndex = ListBox6.SelectedIndex
    End Sub

    Private Sub TextBox19_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox19.GotFocus
        TextBox19.SelectionStart = 0
        TextBox19.SelectionLength = Len(TextBox19.Text)
    End Sub

    Private Sub TextBox19_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox19.KeyDown
        If ListBox8.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox8.Visible = True
                ListBox8.Height = 200
                ListBox8.Focus()
            End If

            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If


        End If
    End Sub

    Private Sub TextBox19_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox19.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox8.Visible = False
            ListBox7.SelectedItem = Nothing
            ListBox8.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox19_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox19.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox19.Text <> ListBox8.Text And ListBox8.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox19.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox19.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox19.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox19.Text)
                FLAG = 2
                closeconn()
                ' refreshall()
            End If
        End If
        DataGridView1.Rows(2).Cells("did").Value = MYITEMID
        DataGridView1.Rows(2).Cells("des").Value = TextBox19.Text
    End Sub

    Private Sub TextBox19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox19.TextChanged

        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox19.Text & "%' order by des", cnn)
        ListBox7.Items.Clear()
        ListBox8.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox7.Items.Add(drd("did"))
            ListBox8.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()





        ListBox8.Visible = True
        ListBox8.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox8.Items.Count - 1
            str1 = StrConv(TextBox19.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox8.Items.Item(start), 1, length) Then
                ListBox8.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox8_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox8.KeyDown
        If e.KeyCode = 38 And ListBox8.SelectedIndex = 0 Then
            TextBox19.Focus()
        End If
    End Sub

    Private Sub ListBox8_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox8.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox19.Text = ListBox8.Text
            ListBox8.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox19.Text = ""
            ListBox8.Visible = False
            ListBox7.SelectedItem = Nothing
            ListBox8.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox8_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox8.LostFocus
        DataGridView1.Rows(2).Cells("did").Value = ListBox7.Text
        DataGridView1.Rows(2).Cells("des").Value = ListBox8.Text
    End Sub

    Private Sub ListBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox8.SelectedIndexChanged
        ListBox7.SelectedIndex = ListBox8.SelectedIndex
    End Sub


    Private Sub TextBox31_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox31.GotFocus
        TextBox31.SelectionStart = 0
        TextBox31.SelectionLength = Len(TextBox31.Text)
    End Sub

    Private Sub TextBox31_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox31.KeyDown
        If ListBox24.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox24.Visible = True
                ListBox24.Height = 200
                ListBox24.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox31_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox31.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox24.Visible = False
            ListBox23.SelectedItem = Nothing
            ListBox24.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox31_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox31.TextChanged
        ListBox24.Visible = True
        ListBox24.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox24.Items.Count - 1
            str1 = StrConv(TextBox31.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox24.Items.Item(start), 1, length) Then
                ListBox24.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox24_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox24.KeyDown
        If e.KeyCode = 38 And ListBox24.SelectedIndex = 0 Then
            TextBox31.Focus()
        End If
    End Sub

    Private Sub ListBox24_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox24.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox31.Text = ListBox24.Text
            ListBox24.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox24.Text = ""
            ListBox24.Visible = False
            ListBox23.SelectedItem = Nothing
            ListBox24.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox24_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox24.LostFocus
        If Val(TextBox8.Text) <> 0 Then
            DataGridView1.Rows(1).Cells("tid").Value = ListBox23.Text
            DataGridView1.Rows(1).Cells("tname").Value = ListBox24.Text
        Else
            DataGridView1.Rows(1).Cells("tid").Value = ""
            DataGridView1.Rows(1).Cells("tname").Value = ""
        End If

        If Val(TextBox9.Text) <> 0 Then
            DataGridView1.Rows(2).Cells("tid").Value = ListBox23.Text
            DataGridView1.Rows(2).Cells("tname").Value = ListBox24.Text
        Else
            DataGridView1.Rows(2).Cells("tid").Value = ""
            DataGridView1.Rows(2).Cells("tname").Value = ""
        End If

    End Sub

    Private Sub ListBox24_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox24.SelectedIndexChanged
        ListBox23.SelectedIndex = ListBox24.SelectedIndex
    End Sub

    Private Sub TextBox20_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox20.GotFocus
        TextBox20.SelectionStart = 0
        TextBox20.SelectionLength = Len(TextBox20.Text)
    End Sub

    Private Sub TextBox20_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox20.KeyDown
        If ListBox10.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox10.Visible = True
                ListBox10.Height = 200
                ListBox10.Focus()
            End If


            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If
        End If
    End Sub

    Private Sub TextBox20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox20.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox10.Visible = False
            ListBox9.SelectedItem = Nothing
            ListBox10.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox20_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox20.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox20.Text <> ListBox10.Text And ListBox10.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox20.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox20.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox20.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox20.Text)
                FLAG = 2
                closeconn()
                ' refreshall()
            End If
        End If
        DataGridView1.Rows(3).Cells("did").Value = MYITEMID
        DataGridView1.Rows(3).Cells("des").Value = TextBox20.Text
    End Sub

    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox20.TextChanged
        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox20.Text & "%' order by des", cnn)
        ListBox9.Items.Clear()
        ListBox10.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox9.Items.Add(drd("did"))
            ListBox10.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()


        ListBox10.Visible = True
        ListBox10.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox10.Items.Count - 1
            str1 = StrConv(TextBox20.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox10.Items.Item(start), 1, length) Then
                ListBox10.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox10_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox10.KeyDown
        If e.KeyCode = 38 And ListBox10.SelectedIndex = 0 Then
            TextBox20.Focus()
        End If
    End Sub

    Private Sub ListBox10_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox10.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox20.Text = ListBox10.Text
            ListBox10.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox20.Text = ""
            ListBox9.Visible = False
            ListBox10.SelectedItem = Nothing
            ListBox9.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox10_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox10.LostFocus
        DataGridView1.Rows(3).Cells("did").Value = ListBox9.Text
        DataGridView1.Rows(3).Cells("des").Value = ListBox10.Text
    End Sub

    Private Sub ListBox10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox10.SelectedIndexChanged
        ListBox9.SelectedIndex = ListBox10.SelectedIndex
    End Sub

    Private Sub TextBox21_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox21.GotFocus
        TextBox21.SelectionStart = 0
        TextBox21.SelectionLength = Len(TextBox21.Text)
    End Sub

    Private Sub TextBox21_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox21.KeyDown
        If ListBox12.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox12.Visible = True
                ListBox12.Height = 200
                ListBox12.Focus()
            End If


            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If
        End If
    End Sub

    Private Sub TextBox21_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox21.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox12.Visible = False
            ListBox11.SelectedItem = Nothing
            ListBox12.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox21_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox21.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox21.Text <> ListBox12.Text And ListBox12.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox21.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox21.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox21.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox21.Text)
                FLAG = 2
                closeconn()
                '  refreshall()
            End If
        End If
        DataGridView1.Rows(4).Cells("did").Value = MYITEMID
        DataGridView1.Rows(4).Cells("des").Value = TextBox21.Text
    End Sub

    Private Sub TextBox21_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox21.TextChanged
        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox21.Text & "%' order by des", cnn)
        ListBox11.Items.Clear()
        ListBox12.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox11.Items.Add(drd("did"))
            ListBox12.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()




        ListBox12.Visible = True
        ListBox12.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox12.Items.Count - 1
            str1 = StrConv(TextBox21.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox12.Items.Item(start), 1, length) Then
                ListBox12.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox12_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox12.KeyDown
        If e.KeyCode = 38 And ListBox12.SelectedIndex = 0 Then
            TextBox21.Focus()
        End If
    End Sub

    Private Sub ListBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox12.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox21.Text = ListBox12.Text
            ListBox12.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox21.Text = ""
            ListBox12.Visible = False
            ListBox11.SelectedItem = Nothing
            ListBox12.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox12.LostFocus
        DataGridView1.Rows(4).Cells("did").Value = ListBox11.Text
        DataGridView1.Rows(4).Cells("des").Value = ListBox12.Text
    End Sub

    Private Sub ListBox12_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox12.SelectedIndexChanged
        ListBox11.SelectedIndex = ListBox12.SelectedIndex
    End Sub

    Private Sub TextBox22_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox22.GotFocus
        TextBox22.SelectionStart = 0
        TextBox22.SelectionLength = Len(TextBox22.Text)
    End Sub

    Private Sub TextBox22_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox22.KeyDown
        If ListBox14.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox14.Visible = True
                ListBox14.Height = 200
                ListBox14.Focus()
            End If


            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If
        End If
    End Sub

    Private Sub TextBox22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox22.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox14.Visible = False
            ListBox13.SelectedItem = Nothing
            ListBox14.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox22_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox22.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox22.Text <> ListBox14.Text And ListBox14.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox22.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox22.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox22.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox22.Text)
                FLAG = 2
                closeconn()
                ' refreshall()
            End If
        End If
        DataGridView1.Rows(5).Cells("did").Value = MYITEMID
        DataGridView1.Rows(5).Cells("des").Value = TextBox22.Text
    End Sub

    Private Sub TextBox22_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox22.TextChanged

        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox22.Text & "%' order by des", cnn)
        ListBox13.Items.Clear()
        ListBox14.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox13.Items.Add(drd("did"))
            ListBox14.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()






        ListBox14.Visible = True
        ListBox14.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox14.Items.Count - 1
            str1 = StrConv(TextBox22.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox14.Items.Item(start), 1, length) Then
                ListBox14.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox14_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox14.KeyDown
        If e.KeyCode = 38 And ListBox14.SelectedIndex = 0 Then
            TextBox22.Focus()
        End If
    End Sub

    Private Sub ListBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox14.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox22.Text = ListBox14.Text
            ListBox14.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox22.Text = ""
            ListBox14.Visible = False
            ListBox13.SelectedItem = Nothing
            ListBox14.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox14_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox14.LostFocus
        DataGridView1.Rows(5).Cells("did").Value = ListBox13.Text
        DataGridView1.Rows(5).Cells("des").Value = ListBox14.Text
    End Sub

    Private Sub ListBox14_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox14.SelectedIndexChanged
        ListBox13.SelectedIndex = ListBox14.SelectedIndex
    End Sub

    Private Sub TextBox32_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox32.GotFocus
        TextBox32.SelectionStart = 0
        TextBox32.SelectionLength = Len(TextBox32.Text)
    End Sub

    Private Sub TextBox32_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox32.KeyDown
        If ListBox26.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox26.Visible = True
                ListBox26.Height = 200
                ListBox26.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox32_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox32.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox26.Visible = False
            ListBox25.SelectedItem = Nothing
            ListBox26.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox32_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox32.TextChanged
        ListBox26.Visible = True
        ListBox26.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox26.Items.Count - 1
            str1 = StrConv(TextBox32.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox26.Items.Item(start), 1, length) Then
                ListBox26.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox26_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox26.KeyDown
        If e.KeyCode = 38 And ListBox26.SelectedIndex = 0 Then
            TextBox32.Focus()
        End If
    End Sub

    Private Sub ListBox26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox26.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox32.Text = ListBox26.Text
            ListBox26.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox32.Text = ""
            ListBox26.Visible = False
            ListBox25.SelectedItem = Nothing
            ListBox26.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox26_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox26.LostFocus

        If Val(TextBox10.Text) <> 0 Then
            DataGridView1.Rows(3).Cells("tid").Value = ListBox25.Text
            DataGridView1.Rows(3).Cells("tname").Value = ListBox26.Text
        Else
            DataGridView1.Rows(3).Cells("tid").Value = ""
            DataGridView1.Rows(3).Cells("tname").Value = ""
        End If

        If Val(TextBox11.Text) <> 0 Then
            DataGridView1.Rows(4).Cells("tid").Value = ListBox25.Text
            DataGridView1.Rows(4).Cells("tname").Value = ListBox26.Text
        Else
            DataGridView1.Rows(4).Cells("tid").Value = ""
            DataGridView1.Rows(4).Cells("tname").Value = ""
        End If

        If Val(TextBox12.Text) <> 0 Then
            DataGridView1.Rows(5).Cells("tid").Value = ListBox25.Text
            DataGridView1.Rows(5).Cells("tname").Value = ListBox26.Text
        Else
            DataGridView1.Rows(5).Cells("tid").Value = ""
            DataGridView1.Rows(5).Cells("tname").Value = ""
        End If

    End Sub

    Private Sub ListBox26_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox26.SelectedIndexChanged
        ListBox25.SelectedIndex = ListBox26.SelectedIndex
    End Sub

    Private Sub TextBox23_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox23.GotFocus
        TextBox23.SelectionStart = 0
        TextBox23.SelectionLength = Len(TextBox23.Text)
    End Sub

    Private Sub TextBox23_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox23.KeyDown
        If ListBox16.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox16.Visible = True
                ListBox16.Height = 200
                ListBox16.Focus()
            End If



            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If
        End If
    End Sub

    Private Sub TextBox23_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox23.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox16.Visible = False
            ListBox15.SelectedItem = Nothing
            ListBox16.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox23_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox23.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox23.Text <> ListBox16.Text And ListBox16.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox23.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox23.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox23.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox23.Text)
                FLAG = 2
                closeconn()
                '  refreshall()
            End If
        End If
        DataGridView1.Rows(6).Cells("did").Value = MYITEMID
        DataGridView1.Rows(6).Cells("des").Value = TextBox23.Text
    End Sub

    Private Sub TextBox23_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox23.TextChanged
        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox23.Text & "%' order by des", cnn)
        ListBox15.Items.Clear()
        ListBox16.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox15.Items.Add(drd("did"))
            ListBox16.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()





        ListBox16.Visible = True
        ListBox16.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox16.Items.Count - 1
            str1 = StrConv(TextBox23.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox16.Items.Item(start), 1, length) Then
                ListBox16.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox16_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox16.KeyDown
        If e.KeyCode = 38 And ListBox16.SelectedIndex = 0 Then
            TextBox23.Focus()
        End If
    End Sub

    Private Sub ListBox16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox16.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox23.Text = ListBox16.Text
            ListBox16.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox23.Text = ""
            ListBox16.Visible = False
            ListBox15.SelectedItem = Nothing
            ListBox16.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox16_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox16.LostFocus
        DataGridView1.Rows(6).Cells("did").Value = ListBox15.Text
        DataGridView1.Rows(6).Cells("des").Value = ListBox16.Text
    End Sub

    Private Sub ListBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox16.SelectedIndexChanged
        ListBox15.SelectedIndex = ListBox16.SelectedIndex
    End Sub

    Private Sub TextBox24_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox24.GotFocus
        TextBox24.SelectionStart = 0
        TextBox24.SelectionLength = Len(TextBox24.Text)
    End Sub

    Private Sub TextBox24_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox24.KeyDown
        If ListBox18.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox18.Visible = True
                ListBox18.Height = 200
                ListBox18.Focus()
            End If


            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If
        End If
    End Sub

    Private Sub TextBox24_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox24.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox18.Visible = False
            ListBox17.SelectedItem = Nothing
            ListBox18.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox24_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox24.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox24.Text <> ListBox18.Text And ListBox18.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox24.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox24.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox24.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox24.Text)
                FLAG = 2
                closeconn()
                ' refreshall()
            End If
        End If
        DataGridView1.Rows(7).Cells("did").Value = MYITEMID
        DataGridView1.Rows(7).Cells("des").Value = TextBox24.Text
    End Sub

    Private Sub TextBox24_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox24.TextChanged

        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox24.Text & "%' order by des", cnn)
        ListBox17.Items.Clear()
        ListBox18.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox17.Items.Add(drd("did"))
            ListBox18.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()


        ListBox18.Visible = True
        ListBox18.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox18.Items.Count - 1
            str1 = StrConv(TextBox24.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox18.Items.Item(start), 1, length) Then
                ListBox18.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox18_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox18.KeyDown
        If e.KeyCode = 38 And ListBox18.SelectedIndex = 0 Then
            TextBox24.Focus()
        End If
    End Sub

    Private Sub ListBox18_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox18.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox24.Text = ListBox18.Text
            ListBox18.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox24.Text = ""
            ListBox18.Visible = False
            ListBox17.SelectedItem = Nothing
            ListBox18.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox18_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox18.LostFocus
        DataGridView1.Rows(7).Cells("did").Value = ListBox17.Text
        DataGridView1.Rows(7).Cells("des").Value = ListBox18.Text
    End Sub

    Private Sub ListBox18_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox18.SelectedIndexChanged
        ListBox17.SelectedIndex = ListBox18.SelectedIndex
    End Sub

    Private Sub TextBox25_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox25.GotFocus
        TextBox25.SelectionStart = 0
        TextBox25.SelectionLength = Len(TextBox25.Text)
    End Sub

    Private Sub TextBox25_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox25.KeyDown
        If ListBox20.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox20.Visible = True
                ListBox20.Height = 200
                ListBox20.Focus()
            End If


            'If e.KeyCode = Keys.Enter Then
            '    SendKeys.Send(vbTab)
            'End If
        End If
    End Sub

    Private Sub TextBox25_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox25.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox20.Visible = False
            ListBox19.SelectedItem = Nothing
            ListBox20.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox25_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox25.LostFocus
        Dim FLAG As Integer = 1
        Dim MYITEMID As Integer

        If TextBox25.Text <> ListBox20.Text And ListBox20.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox24.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox24.Text <> "" Then
                drd.Close()

                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox25.Text)
                cmd.ExecuteNonQuery()
                MYITEMID = GETITEMSYSID(TextBox25.Text)
                FLAG = 2
                closeconn()
                '  refreshall()
            End If
        End If
        DataGridView1.Rows(8).Cells("did").Value = MYITEMID
        DataGridView1.Rows(8).Cells("des").Value = TextBox25.Text
    End Sub

    Private Sub TextBox25_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox25.TextChanged

        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox25.Text & "%' order by des", cnn)
        ListBox19.Items.Clear()
        ListBox20.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox19.Items.Add(drd("did"))
            ListBox20.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()




        ListBox20.Visible = True
        ListBox20.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox20.Items.Count - 1
            str1 = StrConv(TextBox25.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox20.Items.Item(start), 1, length) Then
                ListBox20.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox20_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox20.KeyDown
        If e.KeyCode = 38 And ListBox20.SelectedIndex = 0 Then
            TextBox25.Focus()
        End If
    End Sub

    Private Sub ListBox20_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox20.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox25.Text = ListBox20.Text
            ListBox20.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox25.Text = ""
            ListBox20.Visible = False
            ListBox19.SelectedItem = Nothing
            ListBox20.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox20_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox20.LostFocus
        DataGridView1.Rows(8).Cells("did").Value = ListBox19.Text
        DataGridView1.Rows(8).Cells("des").Value = ListBox20.Text
    End Sub

    Private Sub ListBox20_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox20.SelectedIndexChanged
        ListBox19.SelectedIndex = ListBox20.SelectedIndex
    End Sub

    '------------------------------------------------------------------

    Private Sub TextBox26_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox26.GotFocus
        TextBox26.SelectionStart = 0
        TextBox26.SelectionLength = Len(TextBox26.Text)
    End Sub

    Private Sub TextBox26_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox26.KeyDown
        If ListBox22.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox22.Visible = True
                ListBox22.Height = 200
                ListBox22.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox26_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox26.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox26.Text = ""
            ListBox22.Visible = False
            ListBox21.SelectedItem = Nothing
            ListBox22.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox26_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox26.TextChanged
        ListBox22.Visible = True
        ListBox22.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox22.Items.Count - 1
            str1 = StrConv(TextBox26.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox22.Items.Item(start), 1, length) Then
                ListBox22.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox22_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox22.KeyDown
        If e.KeyCode = 38 And ListBox22.SelectedIndex = 0 Then
            TextBox26.Focus()
        End If
    End Sub

    Private Sub ListBox22_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox22.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox26.Text = ListBox22.Text
            ListBox22.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox26.Text = ""
            ListBox22.Visible = False
            ListBox21.SelectedItem = Nothing
            ListBox22.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox22_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox22.LostFocus
        DataGridView1.Rows(0).Cells("tid").Value = ListBox21.Text
        DataGridView1.Rows(0).Cells("tname").Value = ListBox22.Text
        DataGridView1.Rows(6).Cells("tid").Value = ListBox21.Text
        DataGridView1.Rows(6).Cells("tname").Value = ListBox22.Text
        DataGridView1.Rows(7).Cells("tid").Value = ListBox21.Text
        DataGridView1.Rows(7).Cells("tname").Value = ListBox22.Text
        DataGridView1.Rows(8).Cells("tid").Value = ListBox21.Text
        DataGridView1.Rows(8).Cells("tname").Value = ListBox22.Text

    End Sub

    Private Sub ListBox22_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox22.SelectedIndexChanged
        ListBox21.SelectedIndex = ListBox22.SelectedIndex
    End Sub

    Private Sub TextBox27_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox27.GotFocus
        TextBox27.SelectionStart = 0
        TextBox27.SelectionLength = Len(TextBox27.Text)
    End Sub

    Private Sub TextBox27_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox27.KeyPress
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

    Private Sub TextBox27_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox27.LostFocus
        TextBox27.Text = Format(Val(TextBox27.Text), "#.00")
        Call TextBox28_LostFocus(TextBox28, New KeyPressEventArgs(Chr(Keys.Enter)))
    End Sub

    Private Sub TextBox28_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox28.GotFocus
        TextBox28.SelectionStart = 0
        TextBox28.SelectionLength = Len(TextBox28.Text)
    End Sub

    Private Sub TextBox28_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox28.KeyPress
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

    Private Sub TextBox28_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox28.LostFocus
        TextBox28.Text = Format(Val(TextBox28.Text), "#.00")
        TextBox29.Text = Format(Val(TextBox27.Text) - Val(TextBox28.Text), "#.00")
    End Sub

    Private Sub TextBox30_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox30.GotFocus
        TextBox30.SelectionStart = 0
        TextBox30.SelectionLength = Len(TextBox30.Text)
    End Sub

    Private Sub TextBox30_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox30.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub loaditems()
        DataGridView1.Rows.Clear()
        DataGridView1.Rows.Add(9)

        DataGridView1.Rows(0).Cells("item").Value = "SUIT"
        DataGridView1.Rows(0).Cells("qty").Value = ".00"
        DataGridView1.Rows(0).Cells("did").Value = ""
        DataGridView1.Rows(0).Cells("des").Value = ""
        DataGridView1.Rows(0).Cells("tid").Value = ""
        DataGridView1.Rows(0).Cells("tname").Value = ""

        DataGridView1.Rows(1).Cells("item").Value = "SAREE"
        DataGridView1.Rows(1).Cells("qty").Value = ".00"
        DataGridView1.Rows(1).Cells("did").Value = ""
        DataGridView1.Rows(1).Cells("des").Value = ""
        DataGridView1.Rows(1).Cells("tid").Value = ""
        DataGridView1.Rows(1).Cells("tname").Value = ""

        DataGridView1.Rows(2).Cells("item").Value = "BLOWSE"
        DataGridView1.Rows(2).Cells("qty").Value = ".00"
        DataGridView1.Rows(2).Cells("did").Value = ""
        DataGridView1.Rows(2).Cells("des").Value = ""
        DataGridView1.Rows(2).Cells("tid").Value = ""
        DataGridView1.Rows(2).Cells("tname").Value = ""

        DataGridView1.Rows(3).Cells("item").Value = "LEHANGA"
        DataGridView1.Rows(3).Cells("qty").Value = ".00"
        DataGridView1.Rows(3).Cells("did").Value = ""
        DataGridView1.Rows(3).Cells("des").Value = ""
        DataGridView1.Rows(3).Cells("tid").Value = ""
        DataGridView1.Rows(3).Cells("tname").Value = ""

        DataGridView1.Rows(4).Cells("item").Value = "CHOLI"
        DataGridView1.Rows(4).Cells("qty").Value = ".00"
        DataGridView1.Rows(4).Cells("did").Value = ""
        DataGridView1.Rows(4).Cells("des").Value = ""
        DataGridView1.Rows(4).Cells("tid").Value = ""
        DataGridView1.Rows(4).Cells("tname").Value = ""

        DataGridView1.Rows(5).Cells("item").Value = "DUPATTA"
        DataGridView1.Rows(5).Cells("qty").Value = ".00"
        DataGridView1.Rows(5).Cells("did").Value = ""
        DataGridView1.Rows(5).Cells("des").Value = ""
        DataGridView1.Rows(5).Cells("tid").Value = ""
        DataGridView1.Rows(5).Cells("tname").Value = ""

        DataGridView1.Rows(6).Cells("item").Value = "GOWN"
        DataGridView1.Rows(6).Cells("qty").Value = ".00"
        DataGridView1.Rows(6).Cells("did").Value = ""
        DataGridView1.Rows(6).Cells("des").Value = ""
        DataGridView1.Rows(6).Cells("tid").Value = ""
        DataGridView1.Rows(6).Cells("tname").Value = ""

        DataGridView1.Rows(7).Cells("item").Value = "DRESS"
        DataGridView1.Rows(7).Cells("qty").Value = ".00"
        DataGridView1.Rows(7).Cells("did").Value = ""
        DataGridView1.Rows(7).Cells("des").Value = ""
        DataGridView1.Rows(7).Cells("tid").Value = ""
        DataGridView1.Rows(7).Cells("tname").Value = ""

        DataGridView1.Rows(8).Cells("item").Value = "SATIN"
        DataGridView1.Rows(8).Cells("qty").Value = ".00"
        DataGridView1.Rows(8).Cells("did").Value = ""
        DataGridView1.Rows(8).Cells("des").Value = ""
        DataGridView1.Rows(8).Cells("tid").Value = ""
        DataGridView1.Rows(8).Cells("tname").Value = ""

        If editdelivery = False Then
            r = 0
            openconn()
            cmd = New SqlCommand("select * from itemmaster ", cnn)
            drd = cmd.ExecuteReader
            While drd.Read
                DataGridView1.Rows(r).Cells("rate").Value = drd("charges")
                DataGridView1.Rows(r).Cells("amt").Value = Val(DataGridView1.Rows(r).Cells("qty").Value) * Val(DataGridView1.Rows(r).Cells("rate").Value)
                r = r + 1
            End While
            drd.Close()
            closeconn()
        End If

    End Sub

    Private Sub calculations()
        Dim totalqty As Double = 0
        Dim totalstitching As Double = 0

        Dim j As Integer

        For j = 0 To DataGridView1.Rows.Count - 1
            totalqty = Val(totalqty) + Val(DataGridView1.Rows(j).Cells("qty").Value)
            totalstitching = Val(totalstitching) + Val(DataGridView1.Rows(j).Cells("amt").Value)
        Next
        TextBox16.Text = Format(totalqty, "#.00")
        TextBox27.Text = Format(totalstitching, "#.00")

    End Sub

    'Private Sub autocomplete()
    '    openconn()
    '    Dim autocomp As New AutoCompleteStringCollection
    '    cmd = New SqlCommand("select * from description", cnn)
    '    drd = cmd.ExecuteReader
    '    While drd.Read
    '        autocomp.Add(drd("des"))
    '    End While
    '    TextBox17.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox17.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox17.AutoCompleteCustomSource = autocomp


    '    TextBox18.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox18.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox18.AutoCompleteCustomSource = autocomp

    '    TextBox19.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox19.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox19.AutoCompleteCustomSource = autocomp

    '    TextBox20.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox20.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox20.AutoCompleteCustomSource = autocomp

    '    TextBox21.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox21.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox21.AutoCompleteCustomSource = autocomp

    '    TextBox22.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox22.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox22.AutoCompleteCustomSource = autocomp

    '    TextBox23.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox23.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox23.AutoCompleteCustomSource = autocomp

    '    TextBox24.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox24.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox24.AutoCompleteCustomSource = autocomp


    '    TextBox25.AutoCompleteMode = AutoCompleteMode.Append
    '    TextBox25.AutoCompleteSource = AutoCompleteSource.CustomSource
    '    TextBox25.AutoCompleteCustomSource = autocomp
    '    closeconn()
    'End Sub

    Private Sub TextBox34_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox34.GotFocus
        TextBox34.SelectionStart = 0
        TextBox34.SelectionLength = Len(TextBox34.Text)
    End Sub

    Private Sub TextBox34_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox34.KeyPress
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

    Private Sub TextBox34_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox34.LostFocus
        TextBox34.Text = Format(Val(TextBox34.Text), "#.00")
        If Val(TextBox7.Text) <> 0 Then
            DataGridView1.Rows(0).Cells("rate").Value = Val(TextBox34.Text) / Val(TextBox7.Text)
            DataGridView1.Rows(0).Cells("amt").Value = Format(Val(DataGridView1.Rows(0).Cells("qty").Value) * Val(DataGridView1.Rows(0).Cells("rate").Value), "#.00")
        End If
        Call calculations()
    End Sub

    Private Sub TextBox35_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox35.GotFocus
        TextBox35.SelectionStart = 0
        TextBox35.SelectionLength = Len(TextBox35.Text)
    End Sub

    Private Sub TextBox35_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox35.KeyPress
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

    Private Sub TextBox35_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox35.LostFocus
        TextBox35.Text = Format(Val(TextBox35.Text), "#.00")

        If Val(TextBox8.Text) <> 0 Then
            DataGridView1.Rows(1).Cells("rate").Value = Val(TextBox35.Text) / Val(TextBox8.Text)
            DataGridView1.Rows(1).Cells("amt").Value = Format(Val(DataGridView1.Rows(1).Cells("qty").Value) * Val(DataGridView1.Rows(1).Cells("rate").Value), "#.00")
        End If
        Call calculations()
    End Sub

    Private Sub TextBox36_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox36.GotFocus
        TextBox36.SelectionStart = 0
        TextBox36.SelectionLength = Len(TextBox36.Text)
    End Sub

    Private Sub TextBox36_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox36.KeyPress
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

    Private Sub TextBox36_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox36.LostFocus
        TextBox36.Text = Format(Val(TextBox36.Text), "#.00")

        If Val(TextBox10.Text) <> 0 Then
            DataGridView1.Rows(3).Cells("rate").Value = Val(TextBox36.Text) / Val(TextBox10.Text)
            DataGridView1.Rows(3).Cells("amt").Value = Format(Val(DataGridView1.Rows(3).Cells("qty").Value) * Val(DataGridView1.Rows(3).Cells("rate").Value), "#.00")
        End If
        Call calculations()
    End Sub

    Private Sub TextBox37_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox37.GotFocus
        TextBox37.SelectionStart = 0
        TextBox37.SelectionLength = Len(TextBox37.Text)
    End Sub

    Private Sub TextBox37_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox37.KeyPress
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

    Private Sub TextBox37_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox37.LostFocus
        TextBox37.Text = Format(Val(TextBox37.Text), "#.00")

        If Val(TextBox13.Text) <> 0 Then
            DataGridView1.Rows(6).Cells("rate").Value = Val(TextBox37.Text) / Val(TextBox13.Text)
            DataGridView1.Rows(6).Cells("amt").Value = Format(Val(DataGridView1.Rows(6).Cells("qty").Value) * Val(DataGridView1.Rows(6).Cells("rate").Value), "#.00")
        End If
        Call calculations()
    End Sub

    Private Sub TextBox38_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox38.GotFocus
        TextBox38.SelectionStart = 0
        TextBox38.SelectionLength = Len(TextBox38.Text)
    End Sub

    Private Sub TextBox38_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox38.KeyPress
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

    Private Sub TextBox38_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox38.LostFocus
        TextBox38.Text = Format(Val(TextBox38.Text), "#.00")

        If Val(TextBox14.Text) <> 0 Then
            DataGridView1.Rows(7).Cells("rate").Value = Val(TextBox38.Text) / Val(TextBox14.Text)
            DataGridView1.Rows(7).Cells("amt").Value = Format(Val(DataGridView1.Rows(7).Cells("qty").Value) * Val(DataGridView1.Rows(7).Cells("rate").Value), "#.00")
        End If

        Call calculations()
    End Sub

    Private Sub TextBox39_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox39.GotFocus
        TextBox39.SelectionStart = 0
        TextBox39.SelectionLength = Len(TextBox39.Text)
    End Sub

    Private Sub TextBox39_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox39.KeyPress
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

    Private Sub TextBox39_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox39.LostFocus
        TextBox39.Text = Format(Val(TextBox39.Text), "#.00")

        If Val(TextBox15.Text) <> 0 Then
            DataGridView1.Rows(8).Cells("rate").Value = Val(TextBox39.Text) / Val(TextBox15.Text)
            DataGridView1.Rows(8).Cells("amt").Value = Format(Val(DataGridView1.Rows(8).Cells("qty").Value) * Val(DataGridView1.Rows(8).Cells("rate").Value), "#.00")
        End If
        Call calculations()
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged

    End Sub

    Private Sub TextBox28_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox28.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub
End Class






