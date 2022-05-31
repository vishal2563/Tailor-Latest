Imports System.Data.SqlClient
Public Class mdi

    Dim cmd As New SqlCommand
    Dim drd As SqlDataReader

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        myglobal()
        Login.ShowDialog(Me)
        If loginflag = "N" Then
            Dispose()
        End If
    End Sub

    Private Sub SalesManMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesManMasterToolStripMenuItem.Click
        SalesmanMaster.MdiParent = Me
        SalesmanMaster.Show()
        SalesmanMaster.BringToFront()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub EditSalesManMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditSalesManMasterToolStripMenuItem.Click
        editsalesman.MdiParent = Me
        editsalesman.Show()
        editsalesman.BringToFront()
    End Sub

    Private Sub DeliveryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryToolStripMenuItem.Click
        Delivery.MdiParent = Me
        editdelivery = False
        Delivery.Show()
        Delivery.BringToFront()
    End Sub

    Private Sub TailorMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TailorMasterToolStripMenuItem.Click
        tailormaster.MdiParent = Me
        tailormaster.Show()
        tailormaster.BringToFront()
    End Sub

    Private Sub EditTailorMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditTailorMasterToolStripMenuItem.Click
        edittailormaster.MdiParent = Me
        edittailormaster.Show()
        edittailormaster.BringToFront()
    End Sub

    Private Sub DeliveryRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryRegisterToolStripMenuItem.Click
        deliveryregister.MdiParent = Me
        deliveryregister.Show()
        deliveryregister.BringToFront()
    End Sub

    Private Sub UserMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserMasterToolStripMenuItem.Click
        Form1.MdiParent = Me
        Form1.Show()
        Form1.BringToFront()
    End Sub

    Private Sub EditUserMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditUserMasterToolStripMenuItem.Click
        editusermaster.MdiParent = Me
        editusermaster.Show()
        editusermaster.BringToFront()
    End Sub

    Private Sub DescriptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DescriptionToolStripMenuItem.Click
        DescriptionMaster.MdiParent = Me
        DescriptionMaster.Show()
        DescriptionMaster.BringToFront()
    End Sub

    Private Sub DeliveryStatusRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryStatusRegisterToolStripMenuItem.Click
        DeliveryStatusRegister.MdiParent = Me
        DeliveryStatusRegister.Show()
        DeliveryStatusRegister.BringToFront()
    End Sub

    Private Sub EditDescriptionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditDescriptionToolStripMenuItem.Click
        EditDescription.MdiParent = Me
        EditDescription.Show()
        EditDescription.BringToFront()
    End Sub

    Private Sub TItemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TItemToolStripMenuItem.Click
        EDITITEM.MdiParent = Me
        EDITITEM.Show()
        EDITITEM.BringToFront()
    End Sub

    Private Sub RateMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RateMasterToolStripMenuItem.Click
        ratemaster.MdiParent = Me
        ratemaster.Show()
        ratemaster.BringToFront()
    End Sub

    Private Sub DeliveryDetailRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeliveryDetailRegisterToolStripMenuItem.Click
        DeliveryDetail.MdiParent = Me
        DeliveryDetail.Show()
        DeliveryDetail.BringToFront()
    End Sub

    Private Sub EditRateMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditRateMasterToolStripMenuItem.Click
        EditRateMaster.MdiParent = Me
        EditRateMaster.Show()
        EditRateMaster.BringToFront()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        ItemMaster.MdiParent = Me
        ItemMaster.Show()
        ItemMaster.BringToFront()
    End Sub

    Private Sub DeliveryToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles DeliveryToolStripMenuItem1.Click
        DeliveryStatus.MdiParent = Me
        editdeliverystatus = False
        DeliveryStatus.Show()
        DeliveryStatus.BringToFront()
    End Sub

    Private Sub DeliveryStatusReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DeliveryStatusReportToolStripMenuItem.Click
        DeleiveryStatusReport.MdiParent = Me
        DeleiveryStatusReport.Show()
        DeleiveryStatusReport.BringToFront()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Login.ShowDialog(Me)
    End Sub

    Private Sub PendingDeliveryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles PendingDeliveryToolStripMenuItem.Click
        PendingBalanceReportvb.MdiParent = Me
        PendingBalanceReportvb.Show()
        PendingBalanceReportvb.BringToFront()
    End Sub
End Class
