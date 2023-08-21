<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSingle
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnX = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnPost = New System.Windows.Forms.Button()
        Me.btnClose2 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkList = New System.Windows.Forms.CheckBox()
        Me.txtListPrice = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkP3 = New System.Windows.Forms.CheckBox()
        Me.chkP2 = New System.Windows.Forms.CheckBox()
        Me.chkP1 = New System.Windows.Forms.CheckBox()
        Me.txtTestName = New System.Windows.Forms.TextBox()
        Me.txtTestCode = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtEffect = New System.Windows.Forms.DateTimePicker()
        Me.d = New System.Windows.Forms.DataGridView()
        Me.Imhcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ImhDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_BILLCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ListPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NewLPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_CURR1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NEW_PRICE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_CURR2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NEW_PRICE2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_CURR3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NEW_PRICE3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBatch = New System.Windows.Forms.Button()
        Me.lblTestCount = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.d, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(102, Byte), Integer), CType(CType(102, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnX)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1185, 36)
        Me.Panel1.TabIndex = 0
        '
        'btnX
        '
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(1139, 6)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(31, 23)
        Me.btnX.TabIndex = 3
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(306, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SINGLE TEST PRICE UPDATE SCHEDULE"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.lblTestCount)
        Me.Panel2.Controls.Add(Me.btnBatch)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.btnExport)
        Me.Panel2.Controls.Add(Me.btnClear)
        Me.Panel2.Controls.Add(Me.btnPost)
        Me.Panel2.Controls.Add(Me.btnClose2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.chkList)
        Me.Panel2.Controls.Add(Me.txtListPrice)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtTestName)
        Me.Panel2.Controls.Add(Me.txtTestCode)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.lblDate)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.dtEffect)
        Me.Panel2.Controls.Add(Me.d)
        Me.Panel2.Controls.Add(Me.cbBranch)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1185, 480)
        Me.Panel2.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(1013, 66)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 20
        Me.btnAdd.Text = "ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(174, 432)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 19
        Me.btnExport.Text = "EXPORT"
        Me.btnExport.UseVisualStyleBackColor = True
        Me.btnExport.Visible = False
        '
        'btnClear
        '
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(93, 432)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 18
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnPost
        '
        Me.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPost.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPost.Location = New System.Drawing.Point(12, 432)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(75, 23)
        Me.btnPost.TabIndex = 17
        Me.btnPost.Text = "POST"
        Me.btnPost.UseVisualStyleBackColor = True
        '
        'btnClose2
        '
        Me.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose2.Location = New System.Drawing.Point(1095, 432)
        Me.btnClose2.Name = "btnClose2"
        Me.btnClose2.Size = New System.Drawing.Size(75, 23)
        Me.btnClose2.TabIndex = 16
        Me.btnClose2.Text = "Close"
        Me.btnClose2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Test Code:"
        '
        'chkList
        '
        Me.chkList.AutoSize = True
        Me.chkList.Location = New System.Drawing.Point(751, 72)
        Me.chkList.Name = "chkList"
        Me.chkList.Size = New System.Drawing.Size(15, 14)
        Me.chkList.TabIndex = 14
        Me.chkList.UseVisualStyleBackColor = True
        '
        'txtListPrice
        '
        Me.txtListPrice.Enabled = False
        Me.txtListPrice.Location = New System.Drawing.Point(631, 69)
        Me.txtListPrice.Name = "txtListPrice"
        Me.txtListPrice.Size = New System.Drawing.Size(114, 20)
        Me.txtListPrice.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(572, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "List Price:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkP3)
        Me.GroupBox1.Controls.Add(Me.chkP2)
        Me.GroupBox1.Controls.Add(Me.chkP1)
        Me.GroupBox1.Location = New System.Drawing.Point(297, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(288, 47)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Price Level"
        Me.GroupBox1.Visible = False
        '
        'chkP3
        '
        Me.chkP3.AutoSize = True
        Me.chkP3.Location = New System.Drawing.Point(203, 19)
        Me.chkP3.Name = "chkP3"
        Me.chkP3.Size = New System.Drawing.Size(61, 17)
        Me.chkP3.TabIndex = 18
        Me.chkP3.Text = "Level 3"
        Me.chkP3.UseVisualStyleBackColor = True
        '
        'chkP2
        '
        Me.chkP2.AutoSize = True
        Me.chkP2.Location = New System.Drawing.Point(108, 20)
        Me.chkP2.Name = "chkP2"
        Me.chkP2.Size = New System.Drawing.Size(61, 17)
        Me.chkP2.TabIndex = 17
        Me.chkP2.Text = "Level 2"
        Me.chkP2.UseVisualStyleBackColor = True
        '
        'chkP1
        '
        Me.chkP1.AutoSize = True
        Me.chkP1.Location = New System.Drawing.Point(20, 20)
        Me.chkP1.Name = "chkP1"
        Me.chkP1.Size = New System.Drawing.Size(61, 17)
        Me.chkP1.TabIndex = 16
        Me.chkP1.Text = "Level 1"
        Me.chkP1.UseVisualStyleBackColor = True
        '
        'txtTestName
        '
        Me.txtTestName.Location = New System.Drawing.Point(242, 69)
        Me.txtTestName.Name = "txtTestName"
        Me.txtTestName.ReadOnly = True
        Me.txtTestName.Size = New System.Drawing.Size(324, 20)
        Me.txtTestName.TabIndex = 10
        '
        'txtTestCode
        '
        Me.txtTestCode.Location = New System.Drawing.Point(95, 69)
        Me.txtTestCode.Name = "txtTestCode"
        Me.txtTestCode.Size = New System.Drawing.Size(141, 20)
        Me.txtTestCode.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Effectivity Date:"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(1100, 16)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(30, 13)
        Me.lblDate.TabIndex = 7
        Me.lblDate.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1027, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Current Date:"
        '
        'dtEffect
        '
        Me.dtEffect.CustomFormat = "MM/dd/yyyy"
        Me.dtEffect.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtEffect.Location = New System.Drawing.Point(95, 43)
        Me.dtEffect.Name = "dtEffect"
        Me.dtEffect.Size = New System.Drawing.Size(184, 20)
        Me.dtEffect.TabIndex = 5
        '
        'd
        '
        Me.d.AllowUserToAddRows = False
        Me.d.AllowUserToResizeColumns = False
        Me.d.AllowUserToResizeRows = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.d.ColumnHeadersHeight = 27
        Me.d.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Imhcode, Me.ImhDesc, Me.IMH_BILLCODE, Me.ListPrice, Me.NewLPrice, Me.IMH_CURR1, Me.NEW_PRICE1, Me.IMH_CURR2, Me.NEW_PRICE2, Me.IMH_CURR3, Me.NEW_PRICE3})
        Me.d.EnableHeadersVisualStyles = False
        Me.d.Location = New System.Drawing.Point(12, 95)
        Me.d.MultiSelect = False
        Me.d.Name = "d"
        Me.d.RowHeadersVisible = False
        Me.d.Size = New System.Drawing.Size(1158, 331)
        Me.d.TabIndex = 4
        '
        'Imhcode
        '
        Me.Imhcode.HeaderText = "IMH_CODE"
        Me.Imhcode.Name = "Imhcode"
        Me.Imhcode.ReadOnly = True
        '
        'ImhDesc
        '
        Me.ImhDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ImhDesc.HeaderText = "IMH_DESC"
        Me.ImhDesc.Name = "ImhDesc"
        Me.ImhDesc.ReadOnly = True
        '
        'IMH_BILLCODE
        '
        Me.IMH_BILLCODE.HeaderText = "IMH_BILLCODE"
        Me.IMH_BILLCODE.Name = "IMH_BILLCODE"
        Me.IMH_BILLCODE.Width = 80
        '
        'ListPrice
        '
        Me.ListPrice.HeaderText = "LIST PRICE"
        Me.ListPrice.Name = "ListPrice"
        Me.ListPrice.ReadOnly = True
        '
        'NewLPrice
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Aquamarine
        Me.NewLPrice.DefaultCellStyle = DataGridViewCellStyle12
        Me.NewLPrice.HeaderText = "N LIST PRICE"
        Me.NewLPrice.Name = "NewLPrice"
        '
        'IMH_CURR1
        '
        Me.IMH_CURR1.HeaderText = "IMH CURR 1"
        Me.IMH_CURR1.Name = "IMH_CURR1"
        Me.IMH_CURR1.ReadOnly = True
        '
        'NEW_PRICE1
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Aquamarine
        Me.NEW_PRICE1.DefaultCellStyle = DataGridViewCellStyle13
        Me.NEW_PRICE1.HeaderText = "NEW PRICE 1"
        Me.NEW_PRICE1.Name = "NEW_PRICE1"
        '
        'IMH_CURR2
        '
        Me.IMH_CURR2.HeaderText = "IMH CURR 2"
        Me.IMH_CURR2.Name = "IMH_CURR2"
        Me.IMH_CURR2.ReadOnly = True
        '
        'NEW_PRICE2
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.Aquamarine
        Me.NEW_PRICE2.DefaultCellStyle = DataGridViewCellStyle14
        Me.NEW_PRICE2.HeaderText = "NEW PRICE 2"
        Me.NEW_PRICE2.Name = "NEW_PRICE2"
        '
        'IMH_CURR3
        '
        Me.IMH_CURR3.HeaderText = "IMH CURR 3"
        Me.IMH_CURR3.Name = "IMH_CURR3"
        Me.IMH_CURR3.ReadOnly = True
        '
        'NEW_PRICE3
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.Aquamarine
        Me.NEW_PRICE3.DefaultCellStyle = DataGridViewCellStyle15
        Me.NEW_PRICE3.HeaderText = "NEW PRICE 3"
        Me.NEW_PRICE3.Name = "NEW_PRICE3"
        '
        'cbBranch
        '
        Me.cbBranch.BackColor = System.Drawing.SystemColors.Menu
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Location = New System.Drawing.Point(95, 16)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(184, 21)
        Me.cbBranch.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mother Branch:"
        '
        'btnBatch
        '
        Me.btnBatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatch.Location = New System.Drawing.Point(1094, 66)
        Me.btnBatch.Name = "btnBatch"
        Me.btnBatch.Size = New System.Drawing.Size(75, 23)
        Me.btnBatch.TabIndex = 21
        Me.btnBatch.Text = "BATCH"
        Me.btnBatch.UseVisualStyleBackColor = True
        '
        'lblTestCount
        '
        Me.lblTestCount.AutoSize = True
        Me.lblTestCount.Location = New System.Drawing.Point(947, 432)
        Me.lblTestCount.Name = "lblTestCount"
        Me.lblTestCount.Size = New System.Drawing.Size(115, 13)
        Me.lblTestCount.TabIndex = 22
        Me.lblTestCount.Text = "TEST CODE COUNT: "
        '
        'frmSingle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1185, 516)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSingle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSingle"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.d, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents btnX As System.Windows.Forms.Button
    Friend WithEvents d As System.Windows.Forms.DataGridView
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnPost As System.Windows.Forms.Button
    Friend WithEvents btnClose2 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkList As System.Windows.Forms.CheckBox
    Friend WithEvents txtListPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkP3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkP2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkP1 As System.Windows.Forms.CheckBox
    Friend WithEvents txtTestName As System.Windows.Forms.TextBox
    Friend WithEvents txtTestCode As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtEffect As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Imhcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ImhDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_BILLCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ListPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NewLPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_CURR1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NEW_PRICE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_CURR2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NEW_PRICE2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_CURR3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NEW_PRICE3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBatch As System.Windows.Forms.Button
    Friend WithEvents lblTestCount As System.Windows.Forms.Label
End Class
