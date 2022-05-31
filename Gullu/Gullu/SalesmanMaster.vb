Imports System.Data.SqlClient

Public Class SalesmanMaster
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader

    Private Sub SalesmanMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = autonum("smid", "salesman")
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

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        
        If Trim(TextBox2.Text) <> "" And Len(TextBox3.Text) = 10 Then
            TextBox1.Text = autonum("smid", "salesman")
            openconn()
            cmd = New SqlCommand("select * from salesman where smname ='" & TextBox2.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False Then
                drd.Close()
                cmd = New SqlCommand("insert into salesman(smid,smname,mobile)values(@smid,@smname,@mobile)", cnn)
                cmd.Parameters.AddWithValue("@smid", TextBox1.Text)
                cmd.Parameters.AddWithValue("@smname", TextBox2.Text)
                cmd.Parameters.AddWithValue("@mobile", TextBox3.Text)
                cmd.ExecuteNonQuery()
                closeconn()

                TextBox1.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox1.Text = autonum("smid", "salesman")
                TextBox2.Focus()
            Else
                drd.Close()
                closeconn()
                MsgBox(TextBox2.Text & " Already Exist", MsgBoxStyle.Critical)
                TextBox2.Focus()
            End If

        Else

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

        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
    End Sub

End Class