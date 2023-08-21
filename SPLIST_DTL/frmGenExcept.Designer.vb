<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGenExcept
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnX = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.d = New System.Windows.Forms.DataGridView()
        Me.ITEM_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BASIC_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CURR_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DISC_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtSPDDesc = New System.Windows.Forms.TextBox()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.txtSPDCode = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(595, 33)
        Me.Panel1.TabIndex = 0
        '
        'btnX
        '
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(553, 4)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(31, 23)
        Me.btnX.TabIndex = 8
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 18)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "GENERATE EXCEPTION"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.d)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.btnAdd)
        Me.Panel2.Controls.Add(Me.txtSPDDesc)
        Me.Panel2.Controls.Add(Me.cbBranch)
        Me.Panel2.Controls.Add(Me.txtSPDCode)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(595, 393)
        Me.Panel2.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(14, 363)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(67, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(516, 363)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(67, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'd
        '
        Me.d.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.d.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.d.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITEM_CODE, Me.BASIC_PRICE, Me.CURR_PRICE, Me.DISC_PRICE})
        Me.d.Location = New System.Drawing.Point(14, 80)
        Me.d.MultiSelect = False
        Me.d.Name = "d"
        Me.d.ReadOnly = True
        Me.d.RowHeadersVisible = False
        Me.d.Size = New System.Drawing.Size(569, 277)
        Me.d.TabIndex = 6
        '
        'ITEM_CODE
        '
        Me.ITEM_CODE.HeaderText = "ITEM CODE"
        Me.ITEM_CODE.Name = "ITEM_CODE"
        Me.ITEM_CODE.ReadOnly = True
        '
        'BASIC_PRICE
        '
        Me.BASIC_PRICE.HeaderText = "BASIC_PRICE"
        Me.BASIC_PRICE.Name = "BASIC_PRICE"
        Me.BASIC_PRICE.ReadOnly = True
        Me.BASIC_PRICE.Width = 130
        '
        'CURR_PRICE
        '
        Me.CURR_PRICE.HeaderText = "CURR PRICE"
        Me.CURR_PRICE.Name = "CURR_PRICE"
        Me.CURR_PRICE.ReadOnly = True
        Me.CURR_PRICE.Width = 130
        '
        'DISC_PRICE
        '
        Me.DISC_PRICE.HeaderText = "DISC_PRICE"
        Me.DISC_PRICE.Name = "DISC_PRICE"
        Me.DISC_PRICE.ReadOnly = True
        Me.DISC_PRICE.Width = 130
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Splist_Code:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(33, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Branch:"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(507, 41)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(76, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "GENERATE"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'txtSPDDesc
        '
        Me.txtSPDDesc.Enabled = False
        Me.txtSPDDesc.Location = New System.Drawing.Point(214, 44)
        Me.txtSPDDesc.Name = "txtSPDDesc"
        Me.txtSPDDesc.ReadOnly = True
        Me.txtSPDDesc.Size = New System.Drawing.Size(287, 20)
        Me.txtSPDDesc.TabIndex = 2
        '
        'cbBranch
        '
        Me.cbBranch.BackColor = System.Drawing.SystemColors.Control
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Location = New System.Drawing.Point(83, 17)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(125, 21)
        Me.cbBranch.TabIndex = 1
        '
        'txtSPDCode
        '
        Me.txtSPDCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSPDCode.Location = New System.Drawing.Point(83, 44)
        Me.txtSPDCode.Name = "txtSPDCode"
        Me.txtSPDCode.Size = New System.Drawing.Size(125, 20)
        Me.txtSPDCode.TabIndex = 0
        '
        'frmGenExcept
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 426)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmGenExcept"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmGenExcept"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.d, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnX As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents d As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtSPDDesc As System.Windows.Forms.TextBox
    Friend WithEvents cbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents txtSPDCode As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ITEM_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BASIC_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CURR_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DISC_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
