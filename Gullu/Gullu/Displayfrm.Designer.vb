<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Displayfrm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Displayfrm))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.srno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.billno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.billdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cstbillno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cstname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mobile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.smname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deliveryon = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.des = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.deliveredqty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.balance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totalamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amountrec = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.balanceamt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.ListBox4 = New System.Windows.Forms.ListBox()
        Me.ListBox5 = New System.Windows.Forms.ListBox()
        Me.btnshow = New System.Windows.Forms.Button()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srno, Me.billno, Me.billdate, Me.cstbillno, Me.cstname, Me.mobile, Me.smname, Me.tname, Me.deliveryon, Me.item, Me.des, Me.totalqty, Me.deliveredqty, Me.balance, Me.totalamt, Me.amountrec, Me.balanceamt})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 93)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1075, 359)
        Me.DataGridView1.TabIndex = 408
        '
        'srno
        '
        Me.srno.HeaderText = "Sr No"
        Me.srno.Name = "srno"
        Me.srno.ReadOnly = True
        Me.srno.Width = 70
        '
        'billno
        '
        Me.billno.HeaderText = "Slip no"
        Me.billno.Name = "billno"
        Me.billno.ReadOnly = True
        Me.billno.Width = 80
        '
        'billdate
        '
        Me.billdate.HeaderText = "Dated"
        Me.billdate.Name = "billdate"
        Me.billdate.ReadOnly = True
        Me.billdate.Width = 70
        '
        'cstbillno
        '
        Me.cstbillno.HeaderText = "Billno"
        Me.cstbillno.Name = "cstbillno"
        Me.cstbillno.ReadOnly = True
        Me.cstbillno.Width = 70
        '
        'cstname
        '
        Me.cstname.HeaderText = "Customer"
        Me.cstname.Name = "cstname"
        Me.cstname.ReadOnly = True
        '
        'mobile
        '
        Me.mobile.HeaderText = "Mobile"
        Me.mobile.Name = "mobile"
        Me.mobile.ReadOnly = True
        Me.mobile.Width = 80
        '
        'smname
        '
        Me.smname.HeaderText = "SaleMan"
        Me.smname.Name = "smname"
        Me.smname.ReadOnly = True
        '
        'tname
        '
        Me.tname.HeaderText = "Tailor"
        Me.tname.Name = "tname"
        Me.tname.ReadOnly = True
        '
        'deliveryon
        '
        Me.deliveryon.HeaderText = "Delivery On"
        Me.deliveryon.Name = "deliveryon"
        Me.deliveryon.ReadOnly = True
        Me.deliveryon.Visible = False
        '
        'item
        '
        Me.item.HeaderText = "Item"
        Me.item.Name = "item"
        Me.item.ReadOnly = True
        Me.item.Width = 80
        '
        'des
        '
        Me.des.HeaderText = "Description"
        Me.des.Name = "des"
        Me.des.ReadOnly = True
        '
        'totalqty
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.totalqty.DefaultCellStyle = DataGridViewCellStyle7
        Me.totalqty.HeaderText = "TotalQty"
        Me.totalqty.Name = "totalqty"
        Me.totalqty.ReadOnly = True
        Me.totalqty.Width = 70
        '
        'deliveredqty
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.deliveredqty.DefaultCellStyle = DataGridViewCellStyle8
        Me.deliveredqty.HeaderText = "Delivered Qty"
        Me.deliveredqty.Name = "deliveredqty"
        Me.deliveredqty.ReadOnly = True
        '
        'balance
        '
        Me.balance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.balance.DefaultCellStyle = DataGridViewCellStyle9
        Me.balance.HeaderText = "Balance Qty"
        Me.balance.Name = "balance"
        Me.balance.ReadOnly = True
        Me.balance.Width = 90
        '
        'totalamt
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.totalamt.DefaultCellStyle = DataGridViewCellStyle10
        Me.totalamt.HeaderText = "Total Amt"
        Me.totalamt.Name = "totalamt"
        Me.totalamt.ReadOnly = True
        Me.totalamt.Visible = False
        '
        'amountrec
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.amountrec.DefaultCellStyle = DataGridViewCellStyle11
        Me.amountrec.HeaderText = "Amount Rec"
        Me.amountrec.Name = "amountrec"
        Me.amountrec.ReadOnly = True
        Me.amountrec.Visible = False
        '
        'balanceamt
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.balanceamt.DefaultCellStyle = DataGridViewCellStyle12
        Me.balanceamt.HeaderText = "Balance Amt"
        Me.balanceamt.Name = "balanceamt"
        Me.balanceamt.ReadOnly = True
        Me.balanceamt.Visible = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Snow
        Me.Label6.Location = New System.Drawing.Point(8, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 20)
        Me.Label6.TabIndex = 419
        Me.Label6.Text = "Tailor"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(88, 44)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(106, 20)
        Me.TextBox3.TabIndex = 418
        '
        'ListBox4
        '
        Me.ListBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox4.FormattingEnabled = True
        Me.ListBox4.Location = New System.Drawing.Point(75, 63)
        Me.ListBox4.Name = "ListBox4"
        Me.ListBox4.Size = New System.Drawing.Size(13, 15)
        Me.ListBox4.TabIndex = 421
        Me.ListBox4.Visible = False
        '
        'ListBox5
        '
        Me.ListBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox5.FormattingEnabled = True
        Me.ListBox5.Location = New System.Drawing.Point(88, 63)
        Me.ListBox5.Name = "ListBox5"
        Me.ListBox5.Size = New System.Drawing.Size(106, 15)
        Me.ListBox5.TabIndex = 420
        Me.ListBox5.Visible = False
        '
        'btnshow
        '
        Me.btnshow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnshow.Image = CType(resources.GetObject("btnshow.Image"), System.Drawing.Image)
        Me.btnshow.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnshow.Location = New System.Drawing.Point(935, 44)
        Me.btnshow.Name = "btnshow"
        Me.btnshow.Size = New System.Drawing.Size(71, 36)
        Me.btnshow.TabIndex = 422
        Me.btnshow.Text = "&Show"
        Me.btnshow.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnshow.UseVisualStyleBackColor = True
        '
        'btnclose
        '
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.Image = CType(resources.GetObject("btnclose.Image"), System.Drawing.Image)
        Me.btnclose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnclose.Location = New System.Drawing.Point(1012, 44)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(71, 36)
        Me.btnclose.TabIndex = 423
        Me.btnclose.Text = "&Close"
        Me.btnclose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.AccessibleDescription = ""
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(1048, 1)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox4.TabIndex = 427
        Me.PictureBox4.TabStop = False
        Me.PictureBox4.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(39, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 426
        Me.Label1.Text = "DISPLAY FORM"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(20, 9)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 425
        Me.PictureBox1.TabStop = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(-1, -1)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1172, 34)
        Me.FlowLayoutPanel1.TabIndex = 424
        '
        'Displayfrm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1091, 462)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.btnshow)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.ListBox4)
        Me.Controls.Add(Me.ListBox5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.DataGridView1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Displayfrm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = " Display form"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents ListBox4 As System.Windows.Forms.ListBox
    Friend WithEvents ListBox5 As System.Windows.Forms.ListBox
    Friend WithEvents btnshow As System.Windows.Forms.Button
    Friend WithEvents btnclose As System.Windows.Forms.Button
    Friend WithEvents srno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents billno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents billdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cstbillno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cstname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents smname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deliveryon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents des As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents deliveredqty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents balance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents totalamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amountrec As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents balanceamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
End Class
