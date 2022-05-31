
Imports System.Data.SqlClient
Public Class ItemMaster
    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader
    Dim changers As String = "No"
    Private Sub ItemMaster_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        
    End Sub

   

    Private Sub TextBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

    Private Sub TextBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox2.LostFocus
        TextBox2.Text = StrConv(TextBox2.Text, VbStrConv.Uppercase)
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

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click
        If Trim(TextBox2.Text) = "" Then
            MsgBox("Kinldy Enter The Itemmaster")
            Exit Sub
        End If
        TextBox1.Text = autonum("itemid", "itemmaster")

        openconn()

        cmd = New SqlCommand("insert into itemmaster(itemid,itemname,charges)values(@itemid,@itemname,@charges)", cnn)
        cmd.Parameters.AddWithValue("@itemid", Val(TextBox1.Text))
        cmd.Parameters.AddWithValue("@itemname", Trim(TextBox2.Text))
        cmd.Parameters.AddWithValue("@charges", TextBox4.Text)
        cmd.ExecuteNonQuery()

        'cmd = New SqlCommand("update delivery set itemname='" & TextBox2.Text & "' where itemid=" & ListBox1.Text, cnn)
        'cmd.ExecuteNonQuery()

        closeconn()
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox1.Text = autonum("itemid", "itemmaster")
        If Label2.Text = "Delivery" Then
            Delivery.refreshall()
            Me.Close()

        End If

    End Sub

 
    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
    End Sub

   

End Class