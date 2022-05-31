Imports System.Data.SqlClient
Public Class Displayfrm
    Dim cmd, cmd1 As New SqlCommand
    Dim drd, drd1 As SqlDataReader
    Dim r As Integer = 0

    Private Sub Displayfrm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RefreshAll()
        displaydata()
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

    Private Sub btnshow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnshow.Click
        displaydata()
    End Sub

    Private Sub displaydata()
        Dim srno As Integer = 1
        Dim SqlStmt As String = ""
        Dim eno As Integer = 0
        r = 0
        DataGridView1.Rows.Clear()
        openconn()

        If TextBox3.Text <> "" Then
            SqlStmt = SqlStmt & " and a.tid=" & ListBox4.Text
        End If

        cmd = New SqlCommand("SELECT     a.billno, a.billdate, a.cstbillno, a.cstname, a.mobile, a.smid, a.smname, a.item, a.stitchingcharges, SUM(a.qty) AS qty, a.description,a.tid,a.tname, a.anybalance, a.totalstitching, a.stitchingrec,  b.deliveryon,  CASE WHEN b.delivered <> 0 THEN delivered ELSE 0 END AS delivered, b.amountrec, b.totalamt FROM         delivery AS a LEFT OUTER JOIN (SELECT     billno,deliveryon, item, stitchingcharges,tid,totalamt,sum(amountrec) as amountrec , SUM(qty) AS delivered FROM          deliverystatus GROUP BY billno,deliveryon, item, stitchingcharges,tid,totalamt) AS b ON a.billno = b.billno AND a.item = b.item AND a.stitchingcharges = b.stitchingcharges and a.tid=b.tid WHERE  a.deliverydate = '" & Format(Now.Date, "yyyy-MM-dd") & "'" & SqlStmt & "      GROUP BY a.billno, a.billdate, a.cstbillno, a.cstname, a.mobile, a.smid, a.smname, a.item, a.stitchingcharges, a.description,a.tid,a.tname, a.anybalance, a.totalstitching, a.stitchingrec, b.deliveryon, b.delivered, b.amountrec, b.totalamt", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            If Val(drd("qty")) - Val(drd("delivered")) <> 0 Then
                DataGridView1.Rows.Add()
                If Val(drd("billno")) <> eno Then
                    DataGridView1.Rows(r).Cells("srno").Value = srno
                    DataGridView1.Rows(r).Cells("billno").Value = drd("billno")
                    DataGridView1.Rows(r).Cells("billdate").Value = Format(drd("billdate"), "dd/MM/yyyy")
                    DataGridView1.Rows(r).Cells("cstbillno").Value = drd("cstbillno")
                    DataGridView1.Rows(r).Cells("cstname").Value = drd("cstname")
                    DataGridView1.Rows(r).Cells("mobile").Value = drd("mobile")
                    DataGridView1.Rows(r).Cells("smname").Value = drd("smname")
                    srno = srno + 1
                End If

                If IsDBNull(drd("deliveryon")) Then
                    DataGridView1.Rows(r).Cells("deliveryon").Value = ""
                Else
                    DataGridView1.Rows(r).Cells("deliveryon").Value = Format(drd("deliveryon"), "dd/MM/yyyy")
                End If

                DataGridView1.Rows(r).Cells("tname").Value = drd("tname")
                DataGridView1.Rows(r).Cells("item").Value = drd("item")
                DataGridView1.Rows(r).Cells("des").Value = drd("description")
                DataGridView1.Rows(r).Cells("totalqty").Value = Format(Val(drd("qty")), "#.00")
                DataGridView1.Rows(r).Cells("deliveredqty").Value = Format(Val(drd("delivered")), "#.00")
                DataGridView1.Rows(r).Cells("balance").Value = Format(Val(drd("qty") - drd("delivered")), "#.00")
                eno = drd("billno")
                r = r + 1
            End If
        End While
        drd.Close()
        closeconn()
    End Sub

    Public Sub RefreshAll()
       
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        openconn()

        cmd = New SqlCommand("select * from tailor  order by tname", cnn)
        drd = cmd.ExecuteReader
        While drd.Read
            ListBox4.Items.Add(drd("tid"))
            ListBox5.Items.Add(drd("tname"))
        End While
        drd.Close()
        closeconn()
    End Sub

    Private Sub btnclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnclose.Click
        Dispose()
    End Sub
End Class