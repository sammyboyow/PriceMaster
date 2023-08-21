<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMD_SPLIST
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
        Me.cbBranch = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSPCODE = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnLOAD = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkALL = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.d = New System.Windows.Forms.DataGridView()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.txtSPDESC = New System.Windows.Forms.TextBox()
        Me.cbBranchList = New System.Windows.Forms.ComboBox()
        Me.SPD_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_IMH_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_CURR_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EFD_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_PRV_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.Panel1.Size = New System.Drawing.Size(582, 33)
        Me.Panel1.TabIndex = 0
        '
        'btnX
        '
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(538, 5)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(31, 23)
        Me.btnX.TabIndex = 7
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(187, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "MASTER DATA (SPLIST)"
        '
        'cbBranch
        '
        Me.cbBranch.BackColor = System.Drawing.SystemColors.Control
        Me.cbBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbBranch.FormattingEnabled = True
        Me.cbBranch.Location = New System.Drawing.Point(106, 10)
        Me.cbBranch.Name = "cbBranch"
        Me.cbBranch.Size = New System.Drawing.Size(121, 21)
        Me.cbBranch.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Mother Branch:"
        '
        'txtSPCODE
        '
        Me.txtSPCODE.Location = New System.Drawing.Point(61, 37)
        Me.txtSPCODE.Name = "txtSPCODE"
        Me.txtSPCODE.Size = New System.Drawing.Size(121, 20)
        Me.txtSPCODE.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cbBranchList)
        Me.Panel2.Controls.Add(Me.btnLOAD)
        Me.Panel2.Controls.Add(Me.btnClose)
        Me.Panel2.Controls.Add(Me.btnExport)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.chkALL)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtSPDESC)
        Me.Panel2.Controls.Add(Me.txtSPCODE)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.cbBranch)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 33)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(582, 494)
        Me.Panel2.TabIndex = 1
        '
        'btnLOAD
        '
        Me.btnLOAD.BackColor = System.Drawing.Color.White
        Me.btnLOAD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLOAD.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLOAD.Location = New System.Drawing.Point(504, 34)
        Me.btnLOAD.Name = "btnLOAD"
        Me.btnLOAD.Size = New System.Drawing.Size(63, 23)
        Me.btnLOAD.TabIndex = 12
        Me.btnLOAD.Text = "LOAD"
        Me.btnLOAD.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.White
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(504, 461)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(63, 23)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.White
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(15, 461)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(63, 23)
        Me.btnExport.TabIndex = 10
        Me.btnExport.Text = "EXPORT"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Splist:"
        '
        'chkALL
        '
        Me.chkALL.AutoSize = True
        Me.chkALL.Location = New System.Drawing.Point(459, 40)
        Me.chkALL.Name = "chkALL"
        Me.chkALL.Size = New System.Drawing.Size(45, 17)
        Me.chkALL.TabIndex = 5
        Me.chkALL.Text = "ALL"
        Me.chkALL.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.d)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 392)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'd
        '
        Me.d.AllowUserToAddRows = False
        Me.d.AllowUserToResizeColumns = False
        Me.d.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.d.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.d.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SPD_CODE, Me.SPD_IMH_CODE, Me.SPD_CURR_PRICE, Me.EFD_DATE, Me.SPD_PRV_PRICE})
        Me.d.EnableHeadersVisualStyles = False
        Me.d.Location = New System.Drawing.Point(9, 48)
        Me.d.MultiSelect = False
        Me.d.Name = "d"
        Me.d.ReadOnly = True
        Me.d.RowHeadersVisible = False
        Me.d.Size = New System.Drawing.Size(523, 338)
        Me.d.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Search:"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(56, 22)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(260, 20)
        Me.txtSearch.TabIndex = 4
        '
        'txtSPDESC
        '
        Me.txtSPDESC.Enabled = False
        Me.txtSPDESC.Location = New System.Drawing.Point(188, 37)
        Me.txtSPDESC.Name = "txtSPDESC"
        Me.txtSPDESC.ReadOnly = True
        Me.txtSPDESC.Size = New System.Drawing.Size(265, 20)
        Me.txtSPDESC.TabIndex = 3
        '
        'cbBranchList
        '
        Me.cbBranchList.BackColor = System.Drawing.SystemColors.Control
        Me.cbBranchList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbBranchList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbBranchList.FormattingEnabled = True
        Me.cbBranchList.Location = New System.Drawing.Point(233, 10)
        Me.cbBranchList.Name = "cbBranchList"
        Me.cbBranchList.Size = New System.Drawing.Size(121, 21)
        Me.cbBranchList.TabIndex = 13
        '
        'SPD_CODE
        '
        Me.SPD_CODE.HeaderText = "SPD CODE"
        Me.SPD_CODE.Name = "SPD_CODE"
        Me.SPD_CODE.ReadOnly = True
        Me.SPD_CODE.Width = 80
        '
        'SPD_IMH_CODE
        '
        Me.SPD_IMH_CODE.HeaderText = "IMH_CODE"
        Me.SPD_IMH_CODE.Name = "SPD_IMH_CODE"
        Me.SPD_IMH_CODE.ReadOnly = True
        Me.SPD_IMH_CODE.Width = 120
        '
        'SPD_CURR_PRICE
        '
        Me.SPD_CURR_PRICE.HeaderText = "CURR_PRICE"
        Me.SPD_CURR_PRICE.Name = "SPD_CURR_PRICE"
        Me.SPD_CURR_PRICE.ReadOnly = True
        Me.SPD_CURR_PRICE.Width = 90
        '
        'EFD_DATE
        '
        Me.EFD_DATE.HeaderText = "EFD_DATE"
        Me.EFD_DATE.Name = "EFD_DATE"
        Me.EFD_DATE.ReadOnly = True
        '
        'SPD_PRV_PRICE
        '
        Me.SPD_PRV_PRICE.HeaderText = "PRV_PRICE"
        Me.SPD_PRV_PRICE.Name = "SPD_PRV_PRICE"
        Me.SPD_PRV_PRICE.ReadOnly = True
        Me.SPD_PRV_PRICE.Width = 90
        '
        'frmMD_SPLIST
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 527)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmMD_SPLIST"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMD_SPLIST"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSPCODE As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkALL As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents d As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents txtSPDESC As System.Windows.Forms.TextBox
    Friend WithEvents btnX As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnLOAD As System.Windows.Forms.Button
    Friend WithEvents cbBranchList As System.Windows.Forms.ComboBox
    Friend WithEvents SPD_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_IMH_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_CURR_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EFD_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_PRV_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
