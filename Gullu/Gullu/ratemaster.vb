Imports System.Data.SqlClient
Public Class ratemaster
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader

    Private Sub ratemaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = autonum("id", "ratemaster")
        refreshall()
    End Sub


    Public Sub refreshall()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        openconn()
        cmd = New SqlCommand("select * from itemmaster order by itemname", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox1.Items.Add(drd("itemid"))
            ListBox2.Items.Add(drd("itemname"))
        End While
        drd.Close()

        cmd = New SqlCommand("select * from description order by des", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox3.Items.Add(drd("did"))
            ListBox4.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()
    End Sub

    

    Private Sub TextBox2_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        TextBox2.SelectionStart = 0
        TextBox2.SelectionLength = Len(TextBox2.Text)
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If ListBox2.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox2.Visible = True
                ListBox2.Height = 130
                ListBox2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox2.Text = ""
            ListBox2.Visible = False
            ListBox1.SelectedItem = Nothing
            ListBox2.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        ListBox2.Visible = True
        ListBox2.Height = 130


        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox2.Items.Count - 1
            str1 = StrConv(TextBox2.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox2.Items.Item(start), 1, length) Then
                ListBox2.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox2.KeyDown
        If e.KeyCode = 38 And ListBox2.SelectedIndex = 0 Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub ListBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox2.Text = ListBox2.Text
            ListBox2.Visible = False
        End If
        If Asc(e.KeyChar) = 27 Then
            TextBox2.Text = ""
            ListBox2.Visible = False
            ListBox1.SelectedItem = Nothing
            ListBox2.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.SelectionStart = 0
        TextBox3.SelectionLength = Len(TextBox3.Text)
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If ListBox4.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox4.Visible = True
                ListBox4.Height = 100
                ListBox4.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If

        If Asc(e.KeyChar) = 27 Then
            ListBox4.Visible = False
            ListBox3.SelectedItem = Nothing
            ListBox4.SelectedItem = Nothing
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        ListBox4.Visible = True
        ListBox4.Height = 100

        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox4.Items.Count - 1
            str1 = StrConv(TextBox3.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox4.Items.Item(start), 1, length) Then
                ListBox4.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub


    Private Sub ListBox4_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox4.KeyDown
        If e.KeyCode = 38 And ListBox4.SelectedIndex = 0 Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub ListBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox4.KeyPress
        If Asc(e.KeyChar) = 13 Then
            TextBox3.Text = ListBox4.Text
            ListBox4.Visible = False
        End If

        If Asc(e.KeyChar) = 27 Then
            TextBox3.Text = ""
            ListBox4.Visible = False
            ListBox3.SelectedItem = Nothing
            ListBox4.SelectedItem = Nothing
        End If
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox4.SelectedIndexChanged
        ListBox3.SelectedIndex = ListBox4.SelectedIndex
    End Sub

    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.GotFocus
        TextBox4.SelectionStart = 0
        TextBox4.SelectionLength = Len(TextBox4.Text)
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox4.KeyPress
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

    Private Sub TextBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox4.LostFocus
        TextBox4.Text = Format(Val(TextBox4.Text), "#.00")
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If ListBox2.SelectedItem <> "" And ListBox4.SelectedItem <> "" And Val(TextBox4.Text) <> 0 Then
            TextBox1.Text = autonum("id", "ratemaster")
            openconn()
            cmd = New SqlCommand("select * from ratemaster where itemid =" & ListBox1.Text & " and did=" & ListBox3.Text & " and rate=" & TextBox4.Text, cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False Then
                drd.Close()
                cmd = New SqlCommand("insert into ratemaster(id,itemid,itemname,did,des,rate)values(@id,@itemid,@itemname,@did,@des,@rate)", cnn)
                cmd.Parameters.AddWithValue("@id", TextBox1.Text)
                cmd.Parameters.AddWithValue("@itemid", ListBox1.Text)
                cmd.Parameters.AddWithValue("@itemname", ListBox2.Text)
                cmd.Parameters.AddWithValue("@did", ListBox3.Text)
                cmd.Parameters.AddWithValue("@des", ListBox4.Text)
                cmd.Parameters.AddWithValue("@rate", TextBox4.Text)
                cmd.ExecuteNonQuery()
                closeconn()

                TextBox1.Text = autonum("id", "ratemaster")
                TextBox2.Text = ""
                ListBox1.SelectedItem = Nothing
                ListBox2.SelectedItem = Nothing
                ListBox2.Visible = False

                TextBox3.Text = ""
                ListBox3.SelectedItem = Nothing
                ListBox4.SelectedItem = Nothing
                ListBox4.Visible = False

                TextBox4.Text = ".00"
                TextBox2.Focus()
            Else
                drd.Close()
                closeconn()
                MsgBox("Already Exist", MsgBoxStyle.Critical)
                TextBox2.Focus()
            End If
        End If
    End Sub
End Class