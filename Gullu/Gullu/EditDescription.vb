Imports System.Data.SqlClient

Public Class EditDescription
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader

    Private Sub EditDescription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshAll()
    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox3.GotFocus
        TextBox3.SelectionStart = 0
        TextBox3.SelectionLength = Len(TextBox3.Text)
    End Sub

    Private Sub TextBox3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyDown
        If ListBox2.Items.Count <> 0 Then
            If e.KeyCode = 40 Then
                ListBox2.Focus()
            End If
        End If
    End Sub

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox3.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim start, length As Integer
        Dim str1 As String
        For start = 0 To ListBox2.Items.Count - 1
            str1 = StrConv(TextBox3.Text, VbStrConv.Uppercase)
            length = Len(str1)
            If str1 = Mid(ListBox2.Items.Item(start), 1, length) Then
                ListBox2.SelectedIndex = start
                Exit Sub
            End If
        Next
    End Sub

    Private Sub ListBox2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListBox2.KeyDown
        If e.KeyCode = 38 And ListBox2.SelectedIndex = 0 Then
            TextBox3.Focus()
        End If
    End Sub

    Private Sub ListBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
        openconn()
        cmd = New SqlCommand("select * from description where did=" & ListBox1.Text, cnn)
        drd = cmd.ExecuteReader
        If drd.Read Then
            TextBox1.Text = drd("did")
            TextBox2.Text = drd("des")
        End If
        drd.Close()
        cmd = New SqlCommand("select * from delivery where did=" & ListBox1.Text, cnn)
        drd = cmd.ExecuteReader
        If drd.Read = False Then
            btndel.Visible = True
            drd.Close()
        Else
            btndel.Visible = False
            drd.Close()
            Exit Sub
        End If
        closeconn()

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

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If ListBox2.Text <> "" And Trim(TextBox2.Text) <> "" Then
            openconn()
            cmd = New SqlCommand("update description set did=@did,des=@des where itemid=" & ListBox1.Text, cnn)
            cmd.Parameters.AddWithValue("@did", TextBox1.Text)
            cmd.Parameters.AddWithValue("@des", TextBox2.Text)

            'cmd = New SqlCommand("update delivery set description='" & TextBox2.Text & "' where itemid=" & ListBox1.Text, cnn)
            'cmd.ExecuteNonQuery()

            'cmd = New SqlCommand("update deliverystatus set des='" & TextBox2.Text & "' where did=" & ListBox1.Text, cnn)
            'cmd.ExecuteNonQuery()

            closeconn()
            RefreshAll()
        Else
            If Trim(TextBox2.Text) = "" Then
                MsgBox("Please fill description", vbCritical, "Alert!!!")
                TextBox2.Focus()
            End If
        End If
    End Sub

    Private Sub btndel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btndel.Click
        If ListBox2.Text <> "" Then
            openconn()
            cmd = New SqlCommand("delete from description where did=" & ListBox1.Text, cnn)
            cmd.ExecuteNonQuery()
            closeconn()
            RefreshAll()
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
    End Sub

    Public Sub RefreshAll()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()

        openconn()
        cmd = New SqlCommand("select * from description order by des", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox1.Items.Add(drd("did"))
            ListBox2.Items.Add(drd("des"))
        End While
        drd.Close()
        closeconn()

        If ListBox2.Items.Count <> 0 Then
            ListBox2.SelectedIndex = 0
        End If
        TextBox3.Focus()
    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class