Imports System.Data.SqlClient
Public Class Login
    Dim cmd As SqlCommand
    Dim drd As SqlDataReader

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        openconn()
        cmd = New SqlCommand("select * from UserMaster order by UserId", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox1.Items.Add(drd("UserId"))
            ListBox2.Items.Add(drd("UserName"))
        End While
        drd.Close()
        closeconn()

        If ListBox2.Items.Count <> 0 Then
            ListBox2.SelectedIndex = 0
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        ListBox1.SelectedIndex = ListBox2.SelectedIndex
    End Sub

    Private Sub ListBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ListBox2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        TextBox1.SelectionStart = 0
        TextBox1.SelectionLength = Len(TextBox1.Text)
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Dispose()
        Application.Exit()
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        currentuser = ListBox2.Text
        openconn()
        cmd = New SqlCommand("select * from UserMaster where UserId=" & ListBox1.Text & " and Password='" & TextBox1.Text & "'", cnn)

        drd = cmd.ExecuteReader
        If drd.Read Then
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "dd/MM/yyyy")
            loginflag = "Y"
            Dispose()
            mdi.lblPcname.Text = Environment.MachineName
            mdi.lblusername.Text = currentuser
            ' Displayfrm.MdiParent = mdi
            '  Displayfrm.Show()
        Else
            MsgBox("Error : Invaild User Name or Password", MsgBoxStyle.Critical)
            TextBox1.Text = ""
            TextBox1.Focus()
        End If
        drd.Close()
        closeconn()
    End Sub

End Class
