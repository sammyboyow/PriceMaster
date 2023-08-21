<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBasicPriceLvl
    Inherits DevComponents.DotNetBar.Metro.MetroForm

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
        Me.D = New System.Windows.Forms.DataGridView()
        Me.txtCodeDesc = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnPlus = New System.Windows.Forms.Button()
        Me.btnMinus = New System.Windows.Forms.Button()
        Me.btnSelectBscPricelvl = New System.Windows.Forms.Button()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.TCBscPrc = New System.Windows.Forms.TabControl()
        Me.TPView = New System.Windows.Forms.TabPage()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.vbtnLoad = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.vtxtCodeDesc = New System.Windows.Forms.TextBox()
        Me.vChkAll = New System.Windows.Forms.CheckBox()
        Me.vD = New System.Windows.Forms.DataGridView()
        Me.TPBscPrcMntnc = New System.Windows.Forms.TabPage()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboTCode = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cboTDesc = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TCBscPrc.SuspendLayout()
        Me.TPView.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.vD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPBscPrcMntnc.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'D
        '
        Me.D.AllowUserToAddRows = False
        Me.D.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.D.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D.Dock = System.Windows.Forms.DockStyle.Fill
        Me.D.Location = New System.Drawing.Point(3, 42)
        Me.D.Name = "D"
        Me.D.RowHeadersVisible = False
        Me.D.Size = New System.Drawing.Size(1241, 408)
        Me.D.TabIndex = 0
        '
        'txtCodeDesc
        '
        Me.txtCodeDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtCodeDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtCodeDesc.BackColor = System.Drawing.Color.White
        Me.txtCodeDesc.ForeColor = System.Drawing.Color.Black
        Me.txtCodeDesc.Location = New System.Drawing.Point(765, 9)
        Me.txtCodeDesc.Name = "txtCodeDesc"
        Me.txtCodeDesc.Size = New System.Drawing.Size(156, 22)
        Me.txtCodeDesc.TabIndex = 2
        Me.txtCodeDesc.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Test Code / Description :"
        '
        'btnLoad
        '
        Me.btnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.ForeColor = System.Drawing.Color.Black
        Me.btnLoad.Location = New System.Drawing.Point(527, 9)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.TabIndex = 5
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnPlus
        '
        Me.btnPlus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPlus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPlus.ForeColor = System.Drawing.Color.Black
        Me.btnPlus.Location = New System.Drawing.Point(1186, 3)
        Me.btnPlus.Name = "btnPlus"
        Me.btnPlus.Size = New System.Drawing.Size(23, 23)
        Me.btnPlus.TabIndex = 6
        Me.btnPlus.Text = "+"
        Me.btnPlus.UseVisualStyleBackColor = False
        '
        'btnMinus
        '
        Me.btnMinus.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMinus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinus.ForeColor = System.Drawing.Color.Black
        Me.btnMinus.Location = New System.Drawing.Point(1215, 3)
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.Size = New System.Drawing.Size(23, 23)
        Me.btnMinus.TabIndex = 7
        Me.btnMinus.Text = "-"
        Me.btnMinus.UseVisualStyleBackColor = False
        '
        'btnSelectBscPricelvl
        '
        Me.btnSelectBscPricelvl.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectBscPricelvl.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSelectBscPricelvl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelectBscPricelvl.ForeColor = System.Drawing.Color.Black
        Me.btnSelectBscPricelvl.Location = New System.Drawing.Point(5, 7)
        Me.btnSelectBscPricelvl.Name = "btnSelectBscPricelvl"
        Me.btnSelectBscPricelvl.Size = New System.Drawing.Size(152, 23)
        Me.btnSelectBscPricelvl.TabIndex = 8
        Me.btnSelectBscPricelvl.Text = "&Select Basic Price Level(s)"
        Me.btnSelectBscPricelvl.UseVisualStyleBackColor = False
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkAll.ForeColor = System.Drawing.Color.Black
        Me.ChkAll.Location = New System.Drawing.Point(8, 48)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(15, 14)
        Me.ChkAll.TabIndex = 9
        Me.ChkAll.UseVisualStyleBackColor = False
        '
        'TCBscPrc
        '
        Me.TCBscPrc.Controls.Add(Me.TPView)
        Me.TCBscPrc.Controls.Add(Me.TPBscPrcMntnc)
        Me.TCBscPrc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TCBscPrc.ForeColor = System.Drawing.Color.Black
        Me.TCBscPrc.Location = New System.Drawing.Point(0, 0)
        Me.TCBscPrc.Name = "TCBscPrc"
        Me.TCBscPrc.SelectedIndex = 0
        Me.TCBscPrc.Size = New System.Drawing.Size(1255, 514)
        Me.TCBscPrc.TabIndex = 10
        '
        'TPView
        '
        Me.TPView.Controls.Add(Me.Panel4)
        Me.TPView.Controls.Add(Me.Panel3)
        Me.TPView.Controls.Add(Me.vChkAll)
        Me.TPView.Controls.Add(Me.vD)
        Me.TPView.ForeColor = System.Drawing.Color.Black
        Me.TPView.Location = New System.Drawing.Point(4, 22)
        Me.TPView.Name = "TPView"
        Me.TPView.Padding = New System.Windows.Forms.Padding(3)
        Me.TPView.Size = New System.Drawing.Size(1247, 488)
        Me.TPView.TabIndex = 0
        Me.TPView.Text = "View Basic Price level"
        Me.TPView.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.ForeColor = System.Drawing.Color.Black
        Me.Panel4.Location = New System.Drawing.Point(3, 450)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1241, 35)
        Me.Panel4.TabIndex = 13
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.vbtnLoad)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.vtxtCodeDesc)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.ForeColor = System.Drawing.Color.Black
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1241, 39)
        Me.Panel3.TabIndex = 12
        '
        'vbtnLoad
        '
        Me.vbtnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.vbtnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.vbtnLoad.ForeColor = System.Drawing.Color.Black
        Me.vbtnLoad.Location = New System.Drawing.Point(312, 7)
        Me.vbtnLoad.Name = "vbtnLoad"
        Me.vbtnLoad.Size = New System.Drawing.Size(75, 23)
        Me.vbtnLoad.TabIndex = 5
        Me.vbtnLoad.Text = "&Load"
        Me.vbtnLoad.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(132, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Test Code / Description :"
        '
        'vtxtCodeDesc
        '
        Me.vtxtCodeDesc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.vtxtCodeDesc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.vtxtCodeDesc.BackColor = System.Drawing.Color.White
        Me.vtxtCodeDesc.ForeColor = System.Drawing.Color.Black
        Me.vtxtCodeDesc.Location = New System.Drawing.Point(150, 8)
        Me.vtxtCodeDesc.Name = "vtxtCodeDesc"
        Me.vtxtCodeDesc.Size = New System.Drawing.Size(156, 22)
        Me.vtxtCodeDesc.TabIndex = 2
        '
        'vChkAll
        '
        Me.vChkAll.AutoSize = True
        Me.vChkAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.vChkAll.ForeColor = System.Drawing.Color.Black
        Me.vChkAll.Location = New System.Drawing.Point(8, 48)
        Me.vChkAll.Name = "vChkAll"
        Me.vChkAll.Size = New System.Drawing.Size(15, 14)
        Me.vChkAll.TabIndex = 11
        Me.vChkAll.UseVisualStyleBackColor = False
        '
        'vD
        '
        Me.vD.AllowUserToAddRows = False
        Me.vD.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.vD.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.vD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.vD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vD.Location = New System.Drawing.Point(3, 3)
        Me.vD.Name = "vD"
        Me.vD.RowHeadersVisible = False
        Me.vD.Size = New System.Drawing.Size(1241, 482)
        Me.vD.TabIndex = 10
        '
        'TPBscPrcMntnc
        '
        Me.TPBscPrcMntnc.Controls.Add(Me.ChkAll)
        Me.TPBscPrcMntnc.Controls.Add(Me.D)
        Me.TPBscPrcMntnc.Controls.Add(Me.Panel1)
        Me.TPBscPrcMntnc.Controls.Add(Me.Panel2)
        Me.TPBscPrcMntnc.ForeColor = System.Drawing.Color.Black
        Me.TPBscPrcMntnc.Location = New System.Drawing.Point(4, 22)
        Me.TPBscPrcMntnc.Name = "TPBscPrcMntnc"
        Me.TPBscPrcMntnc.Padding = New System.Windows.Forms.Padding(3)
        Me.TPBscPrcMntnc.Size = New System.Drawing.Size(1247, 488)
        Me.TPBscPrcMntnc.TabIndex = 1
        Me.TPBscPrcMntnc.Text = "Basic Price Level Maintenance"
        Me.TPBscPrcMntnc.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cboTCode)
        Me.Panel1.Controls.Add(Me.cboTDesc)
        Me.Panel1.Controls.Add(Me.btnMinus)
        Me.Panel1.Controls.Add(Me.btnPlus)
        Me.Panel1.Controls.Add(Me.btnLoad)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtCodeDesc)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1241, 39)
        Me.Panel1.TabIndex = 11
        '
        'cboTCode
        '
        Me.cboTCode.DisplayMember = "Text"
        Me.cboTCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTCode.ForeColor = System.Drawing.Color.Black
        Me.cboTCode.FormattingEnabled = True
        Me.cboTCode.ItemHeight = 17
        Me.cboTCode.Location = New System.Drawing.Point(150, 8)
        Me.cboTCode.Name = "cboTCode"
        Me.cboTCode.Size = New System.Drawing.Size(94, 23)
        Me.cboTCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTCode.TabIndex = 12
        '
        'cboTDesc
        '
        Me.cboTDesc.DisplayMember = "Text"
        Me.cboTDesc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTDesc.ForeColor = System.Drawing.Color.Black
        Me.cboTDesc.FormattingEnabled = True
        Me.cboTDesc.ItemHeight = 17
        Me.cboTDesc.Location = New System.Drawing.Point(250, 9)
        Me.cboTDesc.Name = "cboTDesc"
        Me.cboTDesc.Size = New System.Drawing.Size(271, 23)
        Me.cboTDesc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTDesc.TabIndex = 11
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnSelectBscPricelvl)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.ForeColor = System.Drawing.Color.Black
        Me.Panel2.Location = New System.Drawing.Point(3, 450)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1241, 35)
        Me.Panel2.TabIndex = 8
        '
        'frmBasicPriceLvl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1255, 514)
        Me.Controls.Add(Me.TCBscPrc)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmBasicPriceLvl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Basic Price Level Maintenance"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TCBscPrc.ResumeLayout(False)
        Me.TPView.ResumeLayout(False)
        Me.TPView.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.vD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPBscPrcMntnc.ResumeLayout(False)
        Me.TPBscPrcMntnc.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents D As System.Windows.Forms.DataGridView
    Friend WithEvents txtCodeDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnPlus As System.Windows.Forms.Button
    Friend WithEvents btnMinus As System.Windows.Forms.Button
    Friend WithEvents btnSelectBscPricelvl As System.Windows.Forms.Button
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents TCBscPrc As System.Windows.Forms.TabControl
    Friend WithEvents TPBscPrcMntnc As System.Windows.Forms.TabPage
    Friend WithEvents TPView As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents vChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents vD As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents vbtnLoad As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents vtxtCodeDesc As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cboTCode As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cboTDesc As DevComponents.DotNetBar.Controls.ComboBoxEx
End Class
