Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web
Imports System.Text.RegularExpressions

Public Class Delivery
    Dim DT As DateTime = New DateTime()
    Dim cmd, cmd1 As New SqlCommand
    Dim drd, drd1 As SqlDataReader
    Dim r As Integer = 0
    Dim MYId As Integer

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
            lblsrno.Text = autonum("billno", "delivery")
            TextBox1.Text = autonum("billno", "delivery")
            lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
            btndel.Visible = False
            Button3.Visible = False
            TextBox15.ReadOnly = False
            ' AddKarigerList()
        End If
        openconn()
        cmd = New SqlCommand("select * from deliverystatus where billno=" & TextBox1.Text, cnn)
        drd = cmd.ExecuteReader
        If drd.Read Then
            btndel.Visible = False
        End If
        drd.Close()
        closeconn()
        refreshall()
    End Sub
    Public Sub refreshall()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        ListBox8.Items.Clear()
        ListBox9.Items.Clear()
        openconn()
        cmd = New SqlCommand("select * from salesman order by smname", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox1.Items.Add(drd("smid"))
            ListBox2.Items.Add(drd("smname"))
        End While
        drd.Close()

        'cmd = New SqlCommand("select * from tailor order by tname", cnn)
        'drd = cmd.ExecuteReader
        'While drd.Read
        '    ListBox4.Items.Add(drd("tid"))
        '    ListBox5.Items.Add(drd("tname"))
        'End While
        'drd.Close()
        cmd = New SqlCommand("select * from itemmaster order by itemname", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox8.Items.Add(drd("itemid"))
            ListBox9.Items.Add(drd("itemname"))
        End While
        drd.Close()
        closeconn()
    End Sub
    Private Sub DateTimePicker1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub TextBox15_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox15.GotFocus
        TextBox15.SelectionStart = 0
        TextBox15.SelectionLength = Len(TextBox15.Text)
    End Sub
    Private Sub TextBox15_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox15.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub DateTimePicker2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateTimePicker2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub
    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        If DateTimePicker2.Value.Date < DateTimePicker1.Value.Date Then
            MsgBox("Previous days delivery is not allowed.", MsgBoxStyle.Critical, "Alert!!!")
            DateTimePicker2.Focus()
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

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        TextBox2.Text = StrConv(TextBox2.Text, VbStrConv.Uppercase)
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.SelectionStart = 0
        TextBox3.SelectionLength = Len(TextBox3.Text)
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown

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

    'Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.LostFocus
    '    If Len(TextBox3.Text) <> 10 Then
    '        MsgBox("Please fill proper 10 digits Mobile Number", vbCritical, "Alert!!!")
    '        TextBox3.Focus()
    '    End If
    'End Sub

    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        TextBox4.SelectionStart = 0
        TextBox4.SelectionLength = Len(TextBox4.Text)
    End Sub

    Private Sub TextBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox4.KeyDown
        If ListBox2.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox2.Visible = True
                ListBox2.Height = 200
                ListBox2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox4.Text = ""
            ListBox2.Visible = False
            ListBox1.SelectedItem = Nothing
            ListBox2.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged
        ListBox2.Visible = True
        ListBox2.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox2.Items.Count - 1
            str1 = StrConv(TextBox4.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox2.Items.Item(start), 1, length) Then
                ListBox2.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub
    Private Sub ListBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox2.KeyDown
        If e.KeyCode = 38 And ListBox2.SelectedIndex = 0 Then
            TextBox4.Focus()
        End If
    End Sub
    Private Sub ListBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox4.Text = ListBox2.Text
            ListBox2.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox4.Text = ""
            ListBox2.Visible = False
            ListBox1.SelectedItem = Nothing
            ListBox2.SelectedItem = Nothing
        End If
    End Sub
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub TextBox5_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox5.GotFocus
        TextBox5.SelectionStart = 0
        TextBox5.SelectionLength = Len(TextBox5.Text)
    End Sub

    Private Sub TextBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyDown
        If e.KeyCode = Keys.F7 Then
            ItemMaster.Label2.Text = "Delivery"
            ItemMaster.Show()
            ItemMaster.BringToFront()
        End If
        If ListBox9.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox9.Visible = True
                ListBox9.Height = 200
                ListBox9.Focus()
            End If
        End If

    End Sub

    Private Sub TextBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox5.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox5.Text = ""
            ListBox9.Visible = False
            ListBox8.SelectedItem = Nothing
            ListBox9.SelectedItem = Nothing
            TextBox28.Focus()
        End If
    End Sub

    Private Sub TextBox5_Leave(sender As Object, e As System.EventArgs) Handles TextBox5.Leave
    End Sub
    Private Sub TextBox5_LostFocus(sender As Object, e As System.EventArgs) Handles TextBox5.LostFocus
    End Sub
    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        ListBox9.Visible = True
        ListBox9.Height = 200
        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox9.Items.Count - 1
            str1 = StrConv(TextBox5.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox9.Items.Item(start), 1, length) Then
                ListBox9.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub
    Private Sub ListBox9_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox9.KeyDown
        If e.KeyCode = 38 And ListBox9.SelectedIndex = 0 Then
            TextBox5.Focus()
        End If
    End Sub
    Private Sub ListBox9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox9.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox5.Text = ListBox9.Text
            ListBox9.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox5.Text = ""
            ListBox9.Visible = False
            ListBox8.SelectedItem = Nothing
            ListBox9.SelectedItem = Nothing
        End If
    End Sub
    Private Sub ListBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox9.SelectedIndexChanged
        ListBox8.SelectedIndex = ListBox9.SelectedIndex
    End Sub
    Private Sub TextBox14_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox14.GotFocus
        TextBox14.SelectionStart = 0
        TextBox14.SelectionLength = Len(TextBox14.Text)
    End Sub
    Private Sub TextBox14_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox14.KeyDown
        If ListBox6.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox7.Visible = True
                ListBox7.Height = 200
                ListBox7.Focus()
            End If
        End If
    End Sub
    Private Sub TextBox14_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox14.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
        If Asc(e.KeyChar) = 27 Then
            ListBox7.Visible = False
            ListBox6.SelectedItem = Nothing
            ListBox7.SelectedItem = Nothing
        End If
    End Sub
    Private Sub TextBox14_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox14.LostFocus
        If TextBox14.Text <> ListBox7.Text And ListBox7.SelectedItem = Nothing Then
            openconn()
            cmd = New SqlCommand("select * from description where des ='" & TextBox14.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False And TextBox14.Text <> "" Then
                drd.Close()
                cmd = New SqlCommand("INSERT INTO  description (des) VALUES  (@des)", cnn)
                cmd.Parameters.AddWithValue("@des", TextBox14.Text)
                cmd.ExecuteNonQuery()
                closeconn()
            End If
        End If
        If ListBox7.SelectedItem = Nothing Then
            MYId = GETID(TextBox14.Text)
        Else
            MYId = GETID(ListBox7.Text)
        End If
    End Sub

    Function GETID(ByVal des As String) As Integer
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

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox14.TextChanged
        openconn()
        cmd = New SqlCommand("select * from description where des like '" & TextBox14.Text & "%' order by des", cnn)
        ListBox6.Items.Clear()
        ListBox7.Items.Clear()

        drd = cmd.ExecuteReader
        While drd.Read
            ListBox6.Items.Add(drd("did"))
            ListBox7.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()

        If ListBox7.Items.Count = 0 Then
            ListBox7.Visible = False
        Else
            ListBox7.Visible = True
            ListBox7.Height = 200
        End If

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox7.Items.Count - 1
            str1 = StrConv(TextBox14.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox7.Items.Item(start), 1, length) Then
                ListBox7.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox7_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox7.KeyDown
        If e.KeyCode = 38 And ListBox7.SelectedIndex = 0 Then
            TextBox14.Focus()
        End If
    End Sub

    Private Sub ListBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox7.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox14.Text = ListBox7.Text
            ListBox7.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox14.Text = ""
            ListBox7.Visible = False
            ListBox6.SelectedItem = Nothing
            ListBox7.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox7_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox7.LostFocus
        MYId = GETID(ListBox7.Text)
    End Sub

    Private Sub ListBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox7.SelectedIndexChanged
        ListBox6.SelectedIndex = ListBox7.SelectedIndex
    End Sub

    Private Sub TextBox6_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.GotFocus
        TextBox6.SelectionStart = 0
        TextBox6.SelectionLength = Len(TextBox6.Text)
    End Sub

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox6.KeyPress
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

    Private Sub TextBox6_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox6.LostFocus

        TextBox6.Text = Format(Val(TextBox6.Text), "#.00")
        If ListBox9.Text <> "" And ListBox7.Text <> "" Then
            openconn()
            cmd = New SqlCommand("select * from ratemaster where itemid=" & ListBox8.Text & " and did=" & ListBox6.Text, cnn)
            drd = cmd.ExecuteReader
            If drd.Read Then
                TextBox7.Text = Format(Val(drd("rate")), "#.00")
                TextBox12.Text = Format(Val(TextBox6.Text) * Val(TextBox7.Text), "#.00")
            Else
                TextBox7.Text = ".00"
                TextBox12.Text = ".00"
            End If
            drd.Close()
            closeconn()
        End If
    End Sub

    Private Sub TextBox13_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox13.GotFocus
        TextBox13.SelectionStart = 0
        TextBox13.SelectionLength = Len(TextBox13.Text)
    End Sub

    Private Sub TextBox13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox13.KeyDown
        If ListBox5.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox5.Visible = True
                ListBox5.Height = 200
                ListBox5.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox13.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox13.Text = ""
            ListBox5.Visible = False
            ListBox4.SelectedItem = Nothing
            ListBox5.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox13_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.TextChanged
        ListBox5.Visible = True
        ListBox5.Height = 200

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox5.Items.Count - 1
            str1 = StrConv(TextBox13.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox5.Items.Item(start), 1, length) Then
                ListBox5.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox5_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox5.KeyDown
        If e.KeyCode = 38 And ListBox5.SelectedIndex = 0 Then
            TextBox13.Focus()
        End If
    End Sub

    Private Sub ListBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox5.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox13.Text = ListBox5.Text
            ListBox5.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox13.Text = ""
            ListBox5.Visible = False
            ListBox4.SelectedItem = Nothing
            ListBox5.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox5.SelectedIndexChanged
        ListBox4.SelectedIndex = ListBox5.SelectedIndex
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
        TextBox12.Text = Format(Val(TextBox6.Text) * Val(TextBox7.Text), "#.00")
    End Sub

    'Private Sub TextBox12_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox12.GotFocus
    '    TextBox12.SelectionStart = 0
    '    TextBox12.SelectionLength = Len(TextBox12.Text)
    'End Sub

    'Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox12.KeyPress
    '    If Asc(e.KeyChar) = 13 Then
    '        SendKeys.Send("{tab}")
    '    End If
    'End Sub

    'Private Sub TextBox12_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox12.LostFocus
    '    TextBox12.Text = Format(Val(TextBox12.Text), "#.00")
    'End Sub

    Private Sub srnofetch()
        Dim srno As Integer = 0
        Dim count As Integer
        Dim r4 As DataGridViewRow
        For Each r4 In DataGridView1.Rows
            count = DataGridView1.Rows.Count
            'MsgBox(count)
            Label7.Text = count
            'MsgBox(Label7.Text)
        Next
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim count As Integer = 0
        Dim numRows As Integer = Val(TextBox6.Text)
        'If Integer.TryParse(TextBox6.Text, numRows) Then
        'If (numRows >= 1) Then
        For i As Integer = 1 To numRows
            If ListBox9.SelectedItem <> "" And Val(TextBox6.Text) <> 0 Then

                DataGridView1.Rows.Add()
                r = DataGridView1.Rows.Count - 1
                srnofetch()
                DataGridView1.Rows(r).Cells("Srno").Value = Label7.Text
                DataGridView1.Rows(r).Cells("itemid").Value = ListBox8.Text
                DataGridView1.Rows(r).Cells("item").Value = ListBox9.Text
                DataGridView1.Rows(r).Cells("did").Value = MYId
                DataGridView1.Rows(r).Cells("description").Value = TextBox14.Text
                DataGridView1.Rows(r).Cells("DeliveryDate").Value = (DateTimePicker2.Value.ToString("dd/MM/yyyy"))
                DataGridView1.Rows(r).Cells("qty").Value = 1
                ' DataGridView1.Rows(r).Cells("tid").Value = ListBox4.Text
                ' DataGridView1.Rows(r).Cells("tname").Value = ListBox5.Text
                DataGridView1.Rows(r).Cells("stitchingcharges").Value = TextBox7.Text
                DataGridView1.Rows(r).Cells("totalcharges").Value = TextBox12.Text
                Try
                    DataGridView1.Rows(r).Cells("Saleman").Value = TextBox4.Text
                Catch ex As Exception

                End Try

                DataGridView1.Rows(r).Cells("salemanid").Value = ListBox1.Text

                '  TextBox11.Text = Format(Val(TextBox11.Text) + Val(TextBox6.Text), "#.00")


            End If
        Next

        TextBox5.Text = ""
        ListBox8.SelectedItem = Nothing
        ListBox9.SelectedItem = Nothing
        ListBox9.Visible = False
        TextBox4.Text = ""
        TextBox14.Text = ""
        ListBox6.SelectedItem = Nothing
        ListBox7.SelectedItem = Nothing
        ListBox7.Visible = False
        ListBox2.Visible = False
        TextBox6.Text = ".00"
        TextBox7.Text = ".00"
        TextBox12.Text = ".00"

        TextBox13.Text = ""
        ListBox4.SelectedItem = Nothing
        ListBox5.SelectedItem = Nothing
        ListBox5.Visible = False
        TextBox5.Focus()
        Call calculations()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If ListBox2.Visible = False Then
            If e.ColumnIndex = 9 Then
                If (MsgBox("Are You Sure To Change SaleMan Name ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
                    DataGridView1.CurrentRow.Cells("saleman").Value = TextBox4.Text
                    DataGridView1.CurrentRow.Cells("salemanid").Value = ListBox1.Text
                End If
            End If
        Else
            MsgBox("Kindly Select the SaleMan Name")
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'If DataGridView1.Rows.Count > 0 Then
        '    TextBox5.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("item").Value
        '    ListBox8.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("itemid").Value
        '    ListBox9.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("item").Value
        '    Call ListBox9_KeyPress(ListBox9, New KeyPressEventArgs(Chr(Keys.Enter)))

        '    TextBox14.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("description").Value
        '    ListBox6.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("did").Value
        '    ListBox7.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("description").Value
        '    Call ListBox7_KeyPress(ListBox7, New KeyPressEventArgs(Chr(Keys.Enter)))

        '    TextBox6.Text = Format(Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("qty").Value), "#.00")
        '    TextBox7.Text = Format(Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("stitchingcharges").Value), "#.00")
        '    TextBox12.Text = Format(Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("totalcharges").Value), "#.00")

        '    TextBox13.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("tname").Value
        '    ListBox4.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("tid").Value
        '    ListBox5.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("tname").Value
        '    Call ListBox5_KeyPress(ListBox5, New KeyPressEventArgs(Chr(Keys.Enter)))

        '    'TextBox11.Text = Format(Val(TextBox11.Text) - Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("qty").Value), "#.00")
        '    DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        '    Call calculations()
        'End If
    End Sub

    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        If e.KeyCode = 46 Then
            If DataGridView1.Rows.Count > 0 Then
                TextBox11.Text = Format(Val(TextBox11.Text) - Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("qty").Value), "#.00")
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
                Call calculations()
            End If
        End If
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
        TextBox8.Text = Format(Val(TextBox8.Text), "#.00")
    End Sub


    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        Dim fetchdelivystatus As DataTable
        fetchdelivystatus = getdata("select * from Delivery where billno in (select billno  from deliverystatus) and billno=" & TextBox1.Text & " ")
        Try


            If fetchdelivystatus.Rows.Count > 0 Then
                MsgBox("Can't Edit Bill AlReady in Delivery!!!")
                Exit Sub
            Else

            End If
        Catch ex As Exception

        End Try
        Dim fetchbillno1 As DataTable
        fetchbillno1 = getdata("select cstbillno from delivery where cstbillno =" & TextBox15.Text & " and billno<>" & TextBox1.Text)
        Try
            If fetchbillno1.Rows.Count > 0 Then
                MsgBox("Bill No AlReady Exits!!")
                Exit Sub
            Else
            End If
        Catch ex As Exception
        End Try
        If Trim(TextBox15.Text) <> "" And Len(TextBox3.Text) = 10 And DataGridView1.Rows.Count > 0 Then
            If editdelivery = True Then
                DeleteTrans()
            Else
                lblsrno.Text = autonum("billno", "delivery")
                TextBox1.Text = autonum("billno", "DeliveryTable")
                lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
            End If

            If editdelivery = True Then
                openconn()
                cmd = New SqlCommand("Update DeliveryTable set billno=@billno,billdate=@billdate,cstbillno=@cstbillno,cstname=@cstname,mobile=@mobile,updateusername=@updateusername,pcname=@pcname,updatelogtime=@updatelogtime,finyear=@finyear,srno2=@srno2,totalqty=@totalqty,totalbalance=@totalbalance,Remarks1=@Remarks1 where srno2 = @srno2", cnn)
                cmd.Parameters.AddWithValue("@srno2", Val(lblsrno.Text))
                cmd.Parameters.AddWithValue("@billno", TextBox1.Text)
                cmd.Parameters.AddWithValue("@billdate", CDate(DateTimePicker1.Value.Date))
                cmd.Parameters.AddWithValue("@cstbillno", TextBox15.Text)
                cmd.Parameters.AddWithValue("@cstname", Trim(TextBox2.Text))
                cmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
                cmd.Parameters.AddWithValue("@updateusername", Trim(mdi.lblusername.Text))
                cmd.Parameters.AddWithValue("@updatelogtime", Now.ToString())

                cmd.Parameters.AddWithValue("@totalqty", Val(TextBox11.Text))
                cmd.Parameters.AddWithValue("@totalbalance", Val(TextBox8.Text))

                cmd.Parameters.AddWithValue("@pcname", Trim(mdi.lblPcname.Text))

                cmd.Parameters.AddWithValue("@finyear", "22-23")

                cmd.Parameters.AddWithValue("@Remarks1", TextBox9.Text)
                cmd.ExecuteNonQuery()
                closeconn()
            Else
                lblsrno.Text = autonum("billno", "delivery")
                TextBox1.Text = autonum("billno", "DeliveryTable")
                lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
                openconn()
                cmd = New SqlCommand("insert into DeliveryTable(billno,billdate,cstbillno,cstname,mobile,updateusername,username,pcname,updatelogtime,logintime,finyear,srno2,totalqty,totalbalance,Remarks1)values(@billno,@billdate,@cstbillno,@cstname,@mobile,@updateusername,@username,@pcname,@updatelogtime,@logintime,@finyear,@srno2,@totalqty,@totalbalance,@Remarks1)", cnn)
                cmd.Parameters.AddWithValue("@billno", TextBox1.Text)
                cmd.Parameters.AddWithValue("@billdate", CDate(DateTimePicker1.Value.Date))
                cmd.Parameters.AddWithValue("@cstbillno", TextBox15.Text)
                cmd.Parameters.AddWithValue("@cstname", Trim(TextBox2.Text))
                cmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
                cmd.Parameters.AddWithValue("@updateusername", Trim(mdi.lblusername.Text))
                cmd.Parameters.AddWithValue("@updatelogtime", Now.ToString)
                cmd.Parameters.AddWithValue("@username", Trim(mdi.lblusername.Text))
                cmd.Parameters.AddWithValue("@pcname", Trim(mdi.lblPcname.Text))
                cmd.Parameters.AddWithValue("@logintime", Now.ToString)
                cmd.Parameters.AddWithValue("@finyear", "22-23")
                cmd.Parameters.AddWithValue("@srno2", lblsrno.Text)
                cmd.Parameters.AddWithValue("@totalqty", Val(TextBox11.Text))
                cmd.Parameters.AddWithValue("@totalbalance", Val(TextBox8.Text))
                cmd.Parameters.AddWithValue("@Remarks1", TextBox9.Text)
                cmd.ExecuteNonQuery()
                closeconn()

            End If
            openconn()
            For a As Integer = 0 To DataGridView1.Rows.Count - 1
                cmd = New SqlCommand("insert into delivery(billno,billdate,cstbillno,cstname,mobile,smid,smname,deliverydate,salemanid,salemanname,itemid,item,did,description,qty,tid,tname,stitchingcharges,totalqty,totalstitching,stitchingrec,stitchingbal,anybalance,srno,Usernmae,srno2,Remarks1)values(@billno,@billdate,@cstbillno,@cstname,@mobile,@smid,@smname,@deliverydate,@salemanid,@salemanname,@itemid,@item,@did,@description,@qty,@tid,@tname,@stitchingcharges,@totalqty,@totalstitching,@stitchingrec,@stitchingbal,@anybalance,@srno,@Usernmae,@srno2,@Remarks1)", cnn)
                cmd.Parameters.AddWithValue("@billno", TextBox1.Text)
                cmd.Parameters.AddWithValue("@billdate", CDate(DateTimePicker1.Value.Date))
                cmd.Parameters.AddWithValue("@cstbillno", TextBox15.Text)
                cmd.Parameters.AddWithValue("@cstname", Trim(TextBox2.Text))
                cmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
                cmd.Parameters.AddWithValue("@smid", Val(ListBox1.Text))
                cmd.Parameters.AddWithValue("@smname", Trim(ListBox2.Text))
                cmd.Parameters.AddWithValue("@deliverydate", CDate(DataGridView1.Rows(a).Cells("DeliveryDate").Value))
                cmd.Parameters.AddWithValue("@salemanid", Val(DataGridView1.Rows(a).Cells("salemanid").Value))
                cmd.Parameters.AddWithValue("@salemanname", Trim(DataGridView1.Rows(a).Cells("Saleman").Value))
                cmd.Parameters.AddWithValue("@itemid", Val(DataGridView1.Rows(a).Cells("itemid").Value))
                cmd.Parameters.AddWithValue("@item", Trim(DataGridView1.Rows(a).Cells("item").Value))
                cmd.Parameters.AddWithValue("@did", DataGridView1.Rows(a).Cells("did").Value)
                cmd.Parameters.AddWithValue("@description", Trim(DataGridView1.Rows(a).Cells("description").Value))
                cmd.Parameters.AddWithValue("@qty", Val(DataGridView1.Rows(a).Cells("qty").Value))
                cmd.Parameters.AddWithValue("@tid", Val(DataGridView1.Rows(a).Cells("tid").Value))
                cmd.Parameters.AddWithValue("@tname", Trim(DataGridView1.Rows(a).Cells("tname").Value))
                cmd.Parameters.AddWithValue("@stitchingcharges", DataGridView1.Rows(a).Cells("stitchingcharges").Value)
                cmd.Parameters.AddWithValue("@totalqty", Val(TextBox11.Text))
                cmd.Parameters.AddWithValue("@totalstitching", TextBox27.Text)
                cmd.Parameters.AddWithValue("@stitchingrec", TextBox28.Text)
                cmd.Parameters.AddWithValue("@stitchingbal", TextBox29.Text)
                cmd.Parameters.AddWithValue("@anybalance", TextBox8.Text)
                cmd.Parameters.AddWithValue("@srno", Val(DataGridView1.Rows(a).Cells("Srno").Value))
                cmd.Parameters.AddWithValue("@srno2", Val(lblsrno.Text))
                cmd.Parameters.AddWithValue("@Usernmae", mdi.lblusername.Text)

                cmd.Parameters.AddWithValue("@Remarks1", TextBox9.Text)
                cmd.ExecuteNonQuery()
            Next
            closeconn()


            openconn()
            For a As Integer = 0 To DataGridView1.Rows.Count - 1
                cmd = New SqlCommand("insert into StockDetail(Stockrecno,slipno,vohtype,alrefno,billdate,cstbillno,cstname,mobile,delivereyDated,itemid,item,did,description,receiptqty,salemanid,saleman,Totalqty,totalamt,username,Remarks1,Deliverddate,alreadyqty,selctdelivedqty,totalrecqty,totalrecbal,totalbalance,entryno)values(@Stockrecno,@slipno,@vohtype,@alrefno,@billdate,@cstbillno,@cstname,@mobile,@delivereyDated,@itemid,@item,@did,@description,@receiptqty,@salemanid,@saleman,@Totalqty,@totalamt,@username,@Remarks1,@Deliverddate,@alreadyqty,@selctdelivedqty,@totalrecqty,@totalrecbal,@totalbalance,@entryno)", cnn)
                cmd.Parameters.AddWithValue("@Stockrecno", lblstocksrno.Text)
                cmd.Parameters.AddWithValue("@vohtype", "Receipt")
                cmd.Parameters.AddWithValue("@alrefno", "Receipt-" & TextBox1.Text)
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
                cmd.Parameters.AddWithValue("@Totalqty", Val(TextBox11.Text))
                cmd.Parameters.AddWithValue("@username", mdi.lblusername.Text)
                cmd.Parameters.AddWithValue("@totalamt", TextBox8.Text)
                cmd.Parameters.AddWithValue("@Remarks1", TextBox9.Text)
                cmd.Parameters.AddWithValue("@Deliverddate", "")

                cmd.Parameters.AddWithValue("@alreadyqty", "00")
                cmd.Parameters.AddWithValue("@selctdelivedqty", "")


                cmd.Parameters.AddWithValue("@totalrecqty", "00")
                cmd.Parameters.AddWithValue("@totalrecbal", "00")
                cmd.Parameters.AddWithValue("@totalbalance", "00")
                cmd.Parameters.AddWithValue("@entryno", 0)


                cmd.ExecuteNonQuery()
            Next
            closeconn()

            If editdelivery = False Then
                print()
                'SENDSMS()
            End If

            If editdelivery = True Then

                Dispose()
                'deliveryregister.Show()
                ' deliveryregister.clickshowtbn()
            Else
                lblsrno.Text = autonum("billno", "delivery")
                TextBox1.Text = autonum("billno", "DeliveryTable")
                TextBox2.Text = ""
                TextBox15.Text = ""
                TextBox3.Text = ""
                TextBox9.Text = ""
                TextBox4.Text = ""
                ListBox1.SelectedItem = Nothing
                ListBox2.SelectedItem = Nothing
                ListBox2.Visible = False

                TextBox11.Text = ".00"
                TextBox27.Text = ".00"
                TextBox28.Text = ".00"
                TextBox29.Text = ".00"
                TextBox8.Text = ".00"

                DataGridView1.Rows.Clear()
                DateTimePicker1.Focus()

            End If
        Else
            If DataGridView1.Rows.Count < 1 Then
                MsgBox("PLease Fill Items")
                Exit Sub
            End If
            If Trim(TextBox2.Text) = "" Then
                MsgBox("Please fill Name", vbCritical, "Alert!!!")
                TextBox2.Focus()
                Exit Sub
            End If
            If Len(TextBox3.Text) <> 10 Then
                MsgBox("Please fill proper 10 digits Mobile Number", vbCritical, "Alert!!!")
                TextBox3.Focus()
                Exit Sub
            End If
            fetchbillno()
        End If
    End Sub

    Public Sub displaydata()
        Dim deliverydate As Date
        openconn()

        cmd = New SqlCommand("select * from delivery where billno=" & TextBox1.Text & " and Usernmae ='" & mdi.lblusername.Text & "'", cnn)
        drd = cmd.ExecuteReader
        If drd.Read Then
            lblsrno.Text = drd("srno2")
            TextBox1.Text = drd("billno")
            DateTimePicker1.Text = drd("billdate")
            TextBox15.Text = drd("cstbillno")
            DateTimePicker2.Text = drd("deliverydate")
            TextBox2.Text = drd("cstname")
            TextBox3.Text = drd("mobile")
            TextBox4.Text = drd("smname")
            ListBox1.Text = drd("smid")
            ListBox2.Text = drd("smname")
            Call ListBox2_KeyPress(ListBox2, New KeyPressEventArgs(Chr(Keys.Enter)))
            TextBox11.Text = Format(drd("totalqty"), "#.00")
            TextBox27.Text = Format(drd("totalstitching"), "#.00")
            TextBox28.Text = Format(drd("stitchingrec"), "#.00")
            TextBox29.Text = Format(drd("stitchingbal"), "#.00")
            TextBox8.Text = Format(drd("anybalance"), "#.00")
            TextBox9.Text = drd("Remarks1")

        End If
        drd.Close()

        r = 0
        cmd = New SqlCommand("select * from delivery where billno=" & TextBox1.Text & " and Usernmae ='" & mdi.lblusername.Text & "'", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            deliverydate = drd("deliverydate")
            DataGridView1.Rows.Add()
            DataGridView1.Rows(r).Cells("salemanid").Value = drd("salemanid")
            DataGridView1.Rows(r).Cells("saleman").Value = drd("salemanname")
            DataGridView1.Rows(r).Cells("itemid").Value = drd("itemid")
            DataGridView1.Rows(r).Cells("item").Value = drd("item")
            DataGridView1.Rows(r).Cells("did").Value = drd("did")
            DataGridView1.Rows(r).Cells("DeliveryDate").Value = deliverydate.ToString("dd/MM/yyyy")
            DataGridView1.Rows(r).Cells("description").Value = drd("description")
            DataGridView1.Rows(r).Cells("qty").Value = Format(drd("qty"), "#.00")
            DataGridView1.Rows(r).Cells("tid").Value = drd("tid")
            DataGridView1.Rows(r).Cells("srno").Value = drd("Srno")
            DataGridView1.Rows(r).Cells("tname").Value = drd("tname")
            DataGridView1.Rows(r).Cells("stitchingcharges").Value = Format(drd("stitchingcharges"), "#.00")
            DataGridView1.Rows(r).Cells("totalcharges").Value = Format(Val(drd("qty")) * Val(drd("stitchingcharges")), "#.00")
            r = r + 1
        End While
        drd.Close()
        closeconn()

        Call calculations()
    End Sub

    Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
        Dim ch As String
        ch = MsgBox("Are You Sure To Delete?...", vbYesNo, "Confirm!!!")
        If ch = vbYes Then
            If Trim(TextBox1.Text) <> "" Then
                DeleteTrans2()
                Dispose()
                deliveryregister.MdiParent = mdi
                deliveryregister.Show()
                deliveryregister.clickshowtbn()
            End If
        End If
    End Sub
    Private Sub DeleteTrans2()
        openconn()
        cmd = New SqlCommand("delete from DeliveryTable where srno2=" & lblsrno.Text & "", cnn)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("delete from delivery where billno=" & TextBox1.Text & "", cnn)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("delete from StockDetail where slipno=" & TextBox1.Text & "  and vohtype='Receipt'", cnn)
        cmd.ExecuteNonQuery()
        closeconn()
        TextBox1.Text = autonum("billno", "delivery")
        lblsrno.Text = autonum("billno", "delivery")
        lblstocksrno.Text = autonum("Stockrecno", "StockDetail")
        editdelivery = False
    End Sub
    Private Sub DeleteTrans()
        openconn()
        cmd = New SqlCommand("delete from delivery where srno2=" & lblsrno.Text & "", cnn)
        cmd.ExecuteNonQuery()
        cmd = New SqlCommand("delete from StockDetail where slipno=" & TextBox1.Text & "  and vohtype='Receipt'", cnn)
        cmd.ExecuteNonQuery()
        closeconn()
    End Sub

    Sub SENDSMS()
        Dim request As HttpWebRequest = Nothing
        Dim response As HttpWebResponse = Nothing

        Dim MYMESSAGE As String = ""
        Dim url As String = Nothing

        MYMESSAGE = "Thanks for shopping at GULLU EXCLUSIVE For any feedback SMS 98765-53181 or call Toll Free 1800-212-3450"
        url = "http://sms.zipzap.in/pushsms.php?username=shikha&api_password=0a77436omfn4b7bh5&sender=GULLUX&to=" & TextBox3.Text & " & message=" & MYMESSAGE & " & priority=11"

        request = DirectCast(WebRequest.Create(url), HttpWebRequest)
        response = DirectCast(request.GetResponse, HttpWebResponse)
        '''''MessageBox.Show("Response: " & response.StatusDescription)
        MsgBox("Message sent Successfully.", vbInformation)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call print()
    End Sub

    Private Sub print()
        print_billno = Val(lblsrno.Text)
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
        'CReport.SetParameterValue = "{Command.srno}=" & print_billno
        CReport.RecordSelectionFormula = "{Command.srno2}=" & print_billno & " and {Command.cstbillno}= " & TextBox15.Text


        'CReport.RecordSelectionFormula = "{delivery.billno} = " & print_billno

        slipprint.CrystalReportViewer1.ReportSource = CReport
        slipprint.CrystalReportViewer1.Refresh()
        CReport.PrintToPrinter(2, True, 1, 1)
        'slipprint.MdiParent = mdi
        'slipprint.Show()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        If editdelivery = True Then
            Dispose()
            'deliveryregister.MdiParent = mdi
            'deliveryregister.Show()
            'deliveryregister.clickshowtbn()
        Else
            editdelivery = False

            Dispose()
        End If
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        refreshall()
        TextBox4.Text = ""
        ListBox1.SelectedItem = Nothing
        ListBox2.SelectedItem = Nothing
        ListBox2.Visible = False

        TextBox14.Text = ""
        ListBox6.SelectedItem = Nothing
        ListBox7.SelectedItem = Nothing
        ListBox7.Visible = False

        TextBox13.Text = ""
        ListBox4.SelectedItem = Nothing
        ListBox5.SelectedItem = Nothing
        ListBox5.Visible = False
    End Sub

    Private Sub calculations()
        Dim totalqty As Double = 0
        Dim totalstitching As Double = 0

        Dim j As Integer
        For j = 0 To DataGridView1.Rows.Count - 1
            totalqty = Val(totalqty) + Val(DataGridView1.Rows(j).Cells("qty").Value)
            totalstitching = Val(totalstitching) + Val(DataGridView1.Rows(j).Cells("totalcharges").Value)
        Next
        TextBox11.Text = Format(totalqty, "#.00")
        TextBox27.Text = Format(totalstitching, "#.00")
        TextBox29.Text = Format(Val(TextBox27.Text) - Val(TextBox28.Text), "#.00")
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub TextBox3_LostFocus(sender As Object, e As System.EventArgs) Handles TextBox3.LostFocus

    End Sub

    Private Sub TextBox3_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox3_Validated(sender As Object, e As System.EventArgs) Handles TextBox3.Validated
        If Len(TextBox3.Text) <> 10 Then
            MsgBox("Kinldy Enter 10 Digit Mobiile No")
            Exit Sub
        Else

        End If
    End Sub

    Private Sub TextBox15_LostFocus(sender As Object, e As System.EventArgs) Handles TextBox15.LostFocus

    End Sub

    Private Sub TextBox15_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox15.TextChanged

    End Sub
    Private Sub fetchbillno()



        Dim fetchbillno As DataTable
        fetchbillno = getdata("select cstbillno from delivery where cstbillno =" & TextBox15.Text & " and billno<>" & TextBox1.Text)
        Try


            If fetchbillno.Rows.Count > 0 Then
                MsgBox("Bill No AlReady Exits!!")
                Exit Sub
            Else

            End If
        Catch ex As Exception

        End Try


    End Sub
    Private Sub TextBox15_Validated(sender As Object, e As System.EventArgs) Handles TextBox15.Validated
        fetchbillno()
        If Trim(TextBox15.Text) = "" Then
            MsgBox("Enter The Bill No")
            Exit Sub
        Else

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
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox2_Validated(sender As Object, e As System.EventArgs) Handles TextBox2.Validated
        If Trim(TextBox2.Text) = "" Then
            MsgBox("Enter The Customer Name")
            Exit Sub

        End If
    End Sub

    Private Sub TextBox5_Validated(sender As Object, e As System.EventArgs) Handles TextBox5.Validated

    End Sub

    Private Sub TextBox14_Validated(sender As Object, e As System.EventArgs) Handles TextBox14.Validated

    End Sub

    Private Sub TextBox6_Validated(sender As Object, e As System.EventArgs) Handles TextBox6.Validated

    End Sub

    Private Sub DataGridView1_CellValidated(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValidated

        If IsDate(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value) = False Or CDate(DataGridView1.CurrentRow.Cells(5).Value) < Now.Date Then

            MsgBox("Invaild Date")
            DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value = DateTimePicker2.Value.ToString("dd/MM/yyyy")
        Else
            'DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value = DateTimePicker2.Value.ToString("dd/MM/yyyy")
        End If
    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

    End Sub

    Private Sub DataGridView1_CellValidating(sender As Object, e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating

    End Sub
    Private Sub tb_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub
    Private Sub DataGridView1_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        If TypeOf e.Control Is TextBox Then
            Dim tb As TextBox = TryCast(e.Control, TextBox)

            If DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name = "Salemanname" Then
                AddHandler tb.KeyPress, AddressOf tb_KeyPress
            End If

        End If
    End Sub

    Private Sub TextBox8_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox8.TextChanged

    End Sub

    Private Sub TextBox9_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub TextBox9_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Private Sub TextBox9_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TextBox9_KeyPress1(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox9.KeyPress


        If Asc(e.KeyChar) = 13 Then
            e.Handled = False
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBox9_TextChanged_1(sender As System.Object, e As System.EventArgs) Handles TextBox9.TextChanged

    End Sub
End Class
