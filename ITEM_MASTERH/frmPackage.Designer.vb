<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPackage
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnX = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.d = New System.Windows.Forms.DataGridView()
        Me.Pkg_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pkg_Desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prv_Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cur_Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClearDtl = New System.Windows.Forms.Button()
        Me.lblDescr = New System.Windows.Forms.Label()
        Me.dPackage = New System.Windows.Forms.DataGridView()
        Me.TestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrvPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTestCode = New System.Windows.Forms.TextBox()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTestDesc = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtEffect = New System.Windows.Forms.DateTimePicker()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.d, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dPackage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnX)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1234, 42)
        Me.Panel1.TabIndex = 0
        '
        'btnX
        '
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(1179, 9)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(31, 23)
        Me.btnX.TabIndex = 5
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(308, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "PACKAGE PRICE UPDATE SCHEDULE"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.lblDate)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.dtEffect)
        Me.Panel2.Controls.Add(Me.cbBranch)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 42)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1234, 499)
        Me.Panel2.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnClear)
        Me.GroupBox2.Controls.Add(Me.btnPost)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.txtSearch)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.d)
        Me.GroupBox2.Location = New System.Drawing.Point(603, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(607, 423)
        Me.GroupBox2.TabIndex = 23
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PACKAGE LIST"
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(97, 394)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 24
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPost
        '
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(16, 394)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(75, 23)
        Me.btnPost.TabIndex = 20
        Me.btnPost.Text = "POST"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(272, 23)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 23
        Me.btnSearch.Text = "SEARCH"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(63, 26)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(203, 20)
        Me.txtSearch.TabIndex = 22
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Search:"
        '
        'd
        '
        Me.d.AllowUserToAddRows = False
        Me.d.AllowUserToResizeColumns = False
        Me.d.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.d.ColumnHeadersHeight = 25
        Me.d.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pkg_ID, Me.Pkg_Desc, Me.Prv_Price, Me.Cur_Price})
        Me.d.EnableHeadersVisualStyles = False
        Me.d.Location = New System.Drawing.Point(16, 61)
        Me.d.Name = "d"
        Me.d.ReadOnly = True
        Me.d.RowHeadersVisible = False
        Me.d.Size = New System.Drawing.Size(573, 327)
        Me.d.TabIndex = 20
        '
        'Pkg_ID
        '
        Me.Pkg_ID.HeaderText = "PACKAGE CODE"
        Me.Pkg_ID.Name = "Pkg_ID"
        Me.Pkg_ID.ReadOnly = True
        Me.Pkg_ID.Width = 120
        '
        'Pkg_Desc
        '
        Me.Pkg_Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Pkg_Desc.HeaderText = "PACKAGE DESCRIPTION"
        Me.Pkg_Desc.Name = "Pkg_Desc"
        Me.Pkg_Desc.ReadOnly = True
        '
        'Prv_Price
        '
        Me.Prv_Price.HeaderText = "PRV PRICE"
        Me.Prv_Price.Name = "Prv_Price"
        Me.Prv_Price.ReadOnly = True
        '
        'Cur_Price
        '
        Me.Cur_Price.HeaderText = "CUR PRICE"
        Me.Cur_Price.Name = "Cur_Price"
        Me.Cur_Price.ReadOnly = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClearDtl)
        Me.GroupBox1.Controls.Add(Me.lblDescr)
        Me.GroupBox1.Controls.Add(Me.dPackage)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtTestCode)
        Me.GroupBox1.Controls.Add(Me.txtPrice)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTestDesc)
        Me.GroupBox1.Location = New System.Drawing.Point(20, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 423)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PACKAGE DETAILS"
        '
        'btnClearDtl
        '
        Me.btnClearDtl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearDtl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearDtl.Location = New System.Drawing.Point(382, 394)
        Me.btnClearDtl.Name = "btnClearDtl"
        Me.btnClearDtl.Size = New System.Drawing.Size(75, 23)
        Me.btnClearDtl.TabIndex = 25
        Me.btnClearDtl.Text = "CLEAR"
        Me.btnClearDtl.UseVisualStyleBackColor = True
        '
        'lblDescr
        '
        Me.lblDescr.AutoSize = True
        Me.lblDescr.ForeColor = System.Drawing.Color.Red
        Me.lblDescr.Location = New System.Drawing.Point(14, 394)
        Me.lblDescr.Name = "lblDescr"
        Me.lblDescr.Size = New System.Drawing.Size(39, 13)
        Me.lblDescr.TabIndex = 20
        Me.lblDescr.Text = "Label8"
        Me.lblDescr.Visible = False
        '
        'dPackage
        '
        Me.dPackage.AllowUserToAddRows = False
        Me.dPackage.AllowUserToResizeColumns = False
        Me.dPackage.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dPackage.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dPackage.ColumnHeadersHeight = 25
        Me.dPackage.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TestCode, Me.TestDesc, Me.PrvPrice, Me.CurPrice})
        Me.dPackage.EnableHeadersVisualStyles = False
        Me.dPackage.Location = New System.Drawing.Point(17, 61)
        Me.dPackage.Name = "dPackage"
        Me.dPackage.RowHeadersVisible = False
        Me.dPackage.Size = New System.Drawing.Size(521, 327)
        Me.dPackage.TabIndex = 19
        '
        'TestCode
        '
        Me.TestCode.HeaderText = "TEST CODE"
        Me.TestCode.Name = "TestCode"
        Me.TestCode.ReadOnly = True
        '
        'TestDesc
        '
        Me.TestDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TestDesc.HeaderText = "TEST DESCRIPTION"
        Me.TestDesc.Name = "TestDesc"
        Me.TestDesc.ReadOnly = True
        '
        'PrvPrice
        '
        Me.PrvPrice.HeaderText = "PRV PRICE"
        Me.PrvPrice.Name = "PrvPrice"
        Me.PrvPrice.ReadOnly = True
        '
        'CurPrice
        '
        Me.CurPrice.HeaderText = "CUR PRICE"
        Me.CurPrice.Name = "CurPrice"
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(463, 394)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(402, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Price:"
        '
        'txtTestCode
        '
        Me.txtTestCode.Location = New System.Drawing.Point(79, 26)
        Me.txtTestCode.Name = "txtTestCode"
        Me.txtTestCode.Size = New System.Drawing.Size(101, 20)
        Me.txtTestCode.TabIndex = 13
        '
        'txtPrice
        '
        Me.txtPrice.Location = New System.Drawing.Point(442, 26)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(96, 20)
        Me.txtPrice.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Test Code:"
        '
        'txtTestDesc
        '
        Me.txtTestDesc.Location = New System.Drawing.Point(186, 26)
        Me.txtTestDesc.Name = "txtTestDesc"
        Me.txtTestDesc.ReadOnly = True
        Me.txtTestDesc.Size = New System.Drawing.Size(207, 20)
        Me.txtTestDesc.TabIndex = 14
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(1143, 23)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(30, 13)
        Me.lblDate.TabIndex = 12
        Me.lblDate.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1070, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Current Date:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(310, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Effectivity Date:"
        '
        'dtEffect
        '
        Me.dtEffect.CustomFormat = "MM/dd/yyyy"
        Me.dtEffect.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEffect.Location = New System.Drawing.Point(396, 19)
        Me.dtEffect.Name = "dtEffect"
        Me.dtEffect.Size = New System.Drawing.Size(184, 20)
        Me.dtEffect.TabIndex = 9
        '
        'cbBranch
        '
        Me.cbBranch.BackColor = System.Drawing.SystemColors.Menu
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Location = New System.Drawing.Point(103, 20)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(184, 21)
        Me.cbBranch.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mother Branch:"
        '
        'frmPackage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1234, 541)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmPackage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPackage"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.d, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dPackage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnX As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtEffect As System.Windows.Forms.DateTimePicker
    Friend WithEvents dPackage As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtTestDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtTestCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents d As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrvPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pkg_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pkg_Desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Prv_Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cur_Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblDescr As System.Windows.Forms.Label
    Friend WithEvents btnClearDtl As System.Windows.Forms.Button
End Class
