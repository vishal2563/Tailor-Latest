Imports System.Data.SqlClient

Public Class DescriptionMaster
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader

    Private Sub Description_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = autonum("did", "description")
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
        If Trim(TextBox2.Text) <> "" Then
            TextBox1.Text = autonum("did", "description")
            openconn()
            cmd = New SqlCommand("select * from description where des='" & TextBox2.Text & "'", cnn)
            drd = cmd.ExecuteReader
            If drd.Read = False Then
                drd.Close()

                cmd = New SqlCommand("insert into description(des)values(@des)", cnn)
                'cmd.Parameters.AddWithValue("@did", TextBox1.Text)
                cmd.Parameters.AddWithValue("@des", TextBox2.Text)

                cmd.ExecuteNonQuery()
                closeconn()

                TextBox1.Text = ""
                TextBox2.Text = ""

                TextBox1.Text = autonum("did", "description")
                TextBox2.Focus()
            Else
                drd.Close()
                closeconn()
                MsgBox(" Already Exist", MsgBoxStyle.Critical)
                TextBox2.Focus()
            End If
        Else
            If Trim(TextBox2.Text) = "" Then
                MsgBox("Please fill Description", vbCritical, "Alert!!!")
                TextBox2.Focus()
            End If
        End If
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
    End Sub


End Class