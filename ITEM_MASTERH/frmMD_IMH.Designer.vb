<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMD_IMH
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
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnClose2 = New System.Windows.Forms.Button()
        Me.d = New System.Windows.Forms.DataGridView()
        Me.ITEM_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VALID = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.UNIT_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CURR_PRICE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRV_PRICE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CURR_PRICE2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRV_PRICE2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CURR_PRICE3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRV_PRICE3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbBranch = New System.Windows.Forms.ComboBox()
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
        Me.Panel1.Size = New System.Drawing.Size(1050, 36)
        Me.Panel1.TabIndex = 0
        '
        'btnX
        '
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(1015, 4)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(25, 21)
        Me.btnX.TabIndex = 7
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "MASTER DATA (ITEM MASTER)"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnExport)
        Me.Panel2.Controls.Add(Me.btnClose2)
        Me.Panel2.Controls.Add(Me.d)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtCode)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cbBranch)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1050, 480)
        Me.Panel2.TabIndex = 1
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.White
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Location = New System.Drawing.Point(15, 427)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(63, 23)
        Me.btnExport.TabIndex = 9
        Me.btnExport.Text = "EXPORT"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnClose2
        '
        Me.btnClose2.BackColor = System.Drawing.Color.White
        Me.btnClose2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose2.Location = New System.Drawing.Point(974, 427)
        Me.btnClose2.Name = "btnClose2"
        Me.btnClose2.Size = New System.Drawing.Size(63, 23)
        Me.btnClose2.TabIndex = 8
        Me.btnClose2.Text = "CLOSE"
        Me.btnClose2.UseVisualStyleBackColor = False
        '
        'd
        '
        Me.d.AllowUserToAddRows = False
        Me.d.AllowUserToResizeColumns = False
        Me.d.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkGreen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.d.ColumnHeadersHeight = 25
        Me.d.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.d.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ITEM_CODE, Me.ITEM_DESC, Me.VALID, Me.UNIT_PRICE, Me.CURR_PRICE1, Me.PRV_PRICE1, Me.CURR_PRICE2, Me.PRV_PRICE2, Me.CURR_PRICE3, Me.PRV_PRICE3})
        Me.d.EnableHeadersVisualStyles = False
        Me.d.Location = New System.Drawing.Point(15, 86)
        Me.d.MultiSelect = False
        Me.d.Name = "d"
        Me.d.ReadOnly = True
        Me.d.RowHeadersVisible = False
        Me.d.Size = New System.Drawing.Size(1022, 335)
        Me.d.TabIndex = 7
        '
        'ITEM_CODE
        '
        Me.ITEM_CODE.HeaderText = "ITEM CODE"
        Me.ITEM_CODE.Name = "ITEM_CODE"
        Me.ITEM_CODE.ReadOnly = True
        '
        'ITEM_DESC
        '
        Me.ITEM_DESC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ITEM_DESC.HeaderText = "DESCRIPTION"
        Me.ITEM_DESC.Name = "ITEM_DESC"
        Me.ITEM_DESC.ReadOnly = True
        '
        'VALID
        '
        Me.VALID.HeaderText = "ACTIVE"
        Me.VALID.Name = "VALID"
        Me.VALID.ReadOnly = True
        Me.VALID.Width = 50
        '
        'UNIT_PRICE
        '
        Me.UNIT_PRICE.HeaderText = "UNIT_PRICE"
        Me.UNIT_PRICE.Name = "UNIT_PRICE"
        Me.UNIT_PRICE.ReadOnly = True
        Me.UNIT_PRICE.Width = 90
        '
        'CURR_PRICE1
        '
        Me.CURR_PRICE1.HeaderText = "CURR_PRICE1"
        Me.CURR_PRICE1.Name = "CURR_PRICE1"
        Me.CURR_PRICE1.ReadOnly = True
        Me.CURR_PRICE1.Width = 90
        '
        'PRV_PRICE1
        '
        Me.PRV_PRICE1.HeaderText = "PRV_PRICE1"
        Me.PRV_PRICE1.Name = "PRV_PRICE1"
        Me.PRV_PRICE1.ReadOnly = True
        Me.PRV_PRICE1.Width = 90
        '
        'CURR_PRICE2
        '
        Me.CURR_PRICE2.HeaderText = "CURR_PRICE2"
        Me.CURR_PRICE2.Name = "CURR_PRICE2"
        Me.CURR_PRICE2.ReadOnly = True
        Me.CURR_PRICE2.Width = 90
        '
        'PRV_PRICE2
        '
        Me.PRV_PRICE2.HeaderText = "PRV_PRICE2"
        Me.PRV_PRICE2.Name = "PRV_PRICE2"
        Me.PRV_PRICE2.ReadOnly = True
        Me.PRV_PRICE2.Width = 90
        '
        'CURR_PRICE3
        '
        Me.CURR_PRICE3.HeaderText = "CURR_PRICE3"
        Me.CURR_PRICE3.Name = "CURR_PRICE3"
        Me.CURR_PRICE3.ReadOnly = True
        Me.CURR_PRICE3.Width = 90
        '
        'PRV_PRICE3
        '
        Me.PRV_PRICE3.HeaderText = "PRV_PRICE3"
        Me.PRV_PRICE3.Name = "PRV_PRICE3"
        Me.PRV_PRICE3.ReadOnly = True
        Me.PRV_PRICE3.Width = 90
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(42, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Search:"
        '
        'txtCode
        '
        Me.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCode.Location = New System.Drawing.Point(92, 45)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(439, 20)
        Me.txtCode.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(42, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Branch:"
        '
        'cbBranch
        '
        Me.cbBranch.BackColor = System.Drawing.SystemColors.ControlLight
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Location = New System.Drawing.Point(92, 17)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(140, 21)
        Me.cbBranch.TabIndex = 0
        '
        'frmMD_IMH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 516)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMD_IMH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMD_IMH"
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
    Friend WithEvents btnClose2 As System.Windows.Forms.Button
    Friend WithEvents d As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents ITEM_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_DESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VALID As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UNIT_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CURR_PRICE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRV_PRICE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CURR_PRICE2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRV_PRICE2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CURR_PRICE3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRV_PRICE3 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
