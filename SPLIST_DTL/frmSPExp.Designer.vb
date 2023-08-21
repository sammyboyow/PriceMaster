<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSPExp
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnX = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkRegular = New System.Windows.Forms.CheckBox()
        Me.chkSPECIAL = New System.Windows.Forms.CheckBox()
        Me.chkIMG = New System.Windows.Forms.CheckBox()
        Me.chkUTZ = New System.Windows.Forms.CheckBox()
        Me.btnADD = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbPriceLevel = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtSPCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSPDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.d = New System.Windows.Forms.DataGridView()
        Me.TEST_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEST_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ex_Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(691, 33)
        Me.Panel1.TabIndex = 0
        '
        'btnX
        '
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(652, 6)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(25, 21)
        Me.btnX.TabIndex = 6
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(155, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "SPLIST EXCEPTION"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.btnADD)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.d)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(691, 495)
        Me.Panel2.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkRegular)
        Me.GroupBox2.Controls.Add(Me.chkSPECIAL)
        Me.GroupBox2.Controls.Add(Me.chkIMG)
        Me.GroupBox2.Controls.Add(Me.chkUTZ)
        Me.GroupBox2.Location = New System.Drawing.Point(308, 13)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(206, 68)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'chkRegular
        '
        Me.chkRegular.AutoSize = True
        Me.chkRegular.Location = New System.Drawing.Point(12, 17)
        Me.chkRegular.Name = "chkRegular"
        Me.chkRegular.Size = New System.Drawing.Size(78, 17)
        Me.chkRegular.TabIndex = 6
        Me.chkRegular.Text = "REGULAR"
        Me.chkRegular.UseVisualStyleBackColor = True
        '
        'chkSPECIAL
        '
        Me.chkSPECIAL.AutoSize = True
        Me.chkSPECIAL.Location = New System.Drawing.Point(11, 43)
        Me.chkSPECIAL.Name = "chkSPECIAL"
        Me.chkSPECIAL.Size = New System.Drawing.Size(76, 17)
        Me.chkSPECIAL.TabIndex = 7
        Me.chkSPECIAL.Text = "SPECIALL"
        Me.chkSPECIAL.UseVisualStyleBackColor = True
        '
        'chkIMG
        '
        Me.chkIMG.AutoSize = True
        Me.chkIMG.Location = New System.Drawing.Point(94, 43)
        Me.chkIMG.Name = "chkIMG"
        Me.chkIMG.Size = New System.Drawing.Size(72, 17)
        Me.chkIMG.TabIndex = 9
        Me.chkIMG.Text = "IMAGING"
        Me.chkIMG.UseVisualStyleBackColor = True
        '
        'chkUTZ
        '
        Me.chkUTZ.AutoSize = True
        Me.chkUTZ.Location = New System.Drawing.Point(94, 17)
        Me.chkUTZ.Name = "chkUTZ"
        Me.chkUTZ.Size = New System.Drawing.Size(101, 17)
        Me.chkUTZ.TabIndex = 8
        Me.chkUTZ.Text = "ULTRASOUND"
        Me.chkUTZ.UseVisualStyleBackColor = True
        '
        'btnADD
        '
        Me.btnADD.BackColor = System.Drawing.SystemColors.Menu
        Me.btnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnADD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnADD.Location = New System.Drawing.Point(520, 31)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(57, 23)
        Me.btnADD.TabIndex = 10
        Me.btnADD.Text = "ADD"
        Me.btnADD.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbPriceLevel)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnClear)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.txtSPCode)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSPDesc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 13)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(274, 155)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'cbPriceLevel
        '
        Me.cbPriceLevel.BackColor = System.Drawing.SystemColors.Menu
        Me.cbPriceLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPriceLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbPriceLevel.FormattingEnabled = True
        Me.cbPriceLevel.Location = New System.Drawing.Point(75, 74)
        Me.cbPriceLevel.Name = "cbPriceLevel"
        Me.cbPriceLevel.Size = New System.Drawing.Size(80, 21)
        Me.cbPriceLevel.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Price Level:"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Menu
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.Location = New System.Drawing.Point(156, 105)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.Menu
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(75, 105)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtSPCode
        '
        Me.txtSPCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSPCode.Location = New System.Drawing.Point(75, 21)
        Me.txtSPCode.Name = "txtSPCode"
        Me.txtSPCode.Size = New System.Drawing.Size(80, 20)
        Me.txtSPCode.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "SP Desc:"
        '
        'txtSPDesc
        '
        Me.txtSPDesc.Enabled = False
        Me.txtSPDesc.Location = New System.Drawing.Point(75, 48)
        Me.txtSPDesc.Name = "txtSPDesc"
        Me.txtSPDesc.ReadOnly = True
        Me.txtSPDesc.Size = New System.Drawing.Size(190, 20)
        Me.txtSPDesc.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "SP Code:"
        '
        'd
        '
        Me.d.AllowUserToAddRows = False
        Me.d.AllowUserToResizeColumns = False
        Me.d.AllowUserToResizeRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.d.ColumnHeadersHeight = 25
        Me.d.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TEST_CODE, Me.TEST_DESC, Me.Ex_Price})
        Me.d.EnableHeadersVisualStyles = False
        Me.d.Location = New System.Drawing.Point(308, 87)
        Me.d.Name = "d"
        Me.d.RowHeadersVisible = False
        Me.d.Size = New System.Drawing.Size(369, 389)
        Me.d.TabIndex = 2
        '
        'TEST_CODE
        '
        Me.TEST_CODE.HeaderText = "TEST CODE"
        Me.TEST_CODE.Name = "TEST_CODE"
        '
        'TEST_DESC
        '
        Me.TEST_DESC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.TEST_DESC.HeaderText = "TEST DESC"
        Me.TEST_DESC.Name = "TEST_DESC"
        Me.TEST_DESC.ReadOnly = True
        '
        'Ex_Price
        '
        Me.Ex_Price.HeaderText = "PRICE"
        Me.Ex_Price.Name = "Ex_Price"
        '
        'frmSPExp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 528)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmSPExp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSPExp"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.d, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnX As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtSPCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSPDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents d As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbPriceLevel As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkRegular As System.Windows.Forms.CheckBox
    Friend WithEvents chkSPECIAL As System.Windows.Forms.CheckBox
    Friend WithEvents chkIMG As System.Windows.Forms.CheckBox
    Friend WithEvents chkUTZ As System.Windows.Forms.CheckBox
    Friend WithEvents btnADD As System.Windows.Forms.Button
    Friend WithEvents TEST_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEST_DESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ex_Price As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
