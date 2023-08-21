<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectBasicPrice
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
        Me.D = New System.Windows.Forms.DataGridView()
        Me.Chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.BasicPriceLvl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.dtpEfd = New System.Windows.Forms.DateTimePicker()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.ChkSenior = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.BW1 = New System.ComponentModel.BackgroundWorker()
        Me.pbBW = New System.Windows.Forms.PictureBox()
        CType(Me.D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbBW, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'D
        '
        Me.D.AllowUserToAddRows = False
        Me.D.AllowUserToDeleteRows = False
        Me.D.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chk, Me.BasicPriceLvl, Me.Description})
        Me.D.Location = New System.Drawing.Point(12, 12)
        Me.D.Name = "D"
        Me.D.RowHeadersVisible = False
        Me.D.Size = New System.Drawing.Size(350, 358)
        Me.D.TabIndex = 0
        '
        'Chk
        '
        Me.Chk.HeaderText = ""
        Me.Chk.Name = "Chk"
        Me.Chk.Width = 30
        '
        'BasicPriceLvl
        '
        Me.BasicPriceLvl.HeaderText = "BasicPriceLvl"
        Me.BasicPriceLvl.Name = "BasicPriceLvl"
        Me.BasicPriceLvl.ReadOnly = True
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 200
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkAll.ForeColor = System.Drawing.Color.Black
        Me.ChkAll.Location = New System.Drawing.Point(20, 16)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(15, 14)
        Me.ChkAll.TabIndex = 1
        Me.ChkAll.UseVisualStyleBackColor = False
        '
        'dtpEfd
        '
        Me.dtpEfd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpEfd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dtpEfd.ForeColor = System.Drawing.Color.Black
        Me.dtpEfd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEfd.Location = New System.Drawing.Point(105, 405)
        Me.dtpEfd.Name = "dtpEfd"
        Me.dtpEfd.Size = New System.Drawing.Size(104, 22)
        Me.dtpEfd.TabIndex = 2
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGenerate.ForeColor = System.Drawing.Color.Black
        Me.btnGenerate.Location = New System.Drawing.Point(287, 376)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(75, 51)
        Me.btnGenerate.TabIndex = 3
        Me.btnGenerate.Text = "&Generate"
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'ChkSenior
        '
        Me.ChkSenior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChkSenior.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.ChkSenior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkSenior.Checked = True
        Me.ChkSenior.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSenior.CheckValue = "Y"
        Me.ChkSenior.ForeColor = System.Drawing.Color.Black
        Me.ChkSenior.Location = New System.Drawing.Point(12, 376)
        Me.ChkSenior.Name = "ChkSenior"
        Me.ChkSenior.Size = New System.Drawing.Size(139, 23)
        Me.ChkSenior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkSenior.TabIndex = 884
        Me.ChkSenior.Text = "Include Senior Discount"
        '
        'LabelX5
        '
        Me.LabelX5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(12, 404)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(87, 23)
        Me.LabelX5.TabIndex = 891
        Me.LabelX5.Text = "Effectivity Date :"
        '
        'BW1
        '
        '
        'pbBW
        '
        Me.pbBW.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbBW.BackColor = System.Drawing.Color.Transparent
        Me.pbBW.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbBW.ForeColor = System.Drawing.Color.Black
        Me.pbBW.Image = Global.PriceMaster.My.Resources.Resources.lg1
        Me.pbBW.ImageLocation = ""
        Me.pbBW.Location = New System.Drawing.Point(159, 153)
        Me.pbBW.Name = "pbBW"
        Me.pbBW.Size = New System.Drawing.Size(50, 47)
        Me.pbBW.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbBW.TabIndex = 892
        Me.pbBW.TabStop = False
        Me.pbBW.Visible = False
        '
        'frmSelectBasicPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 439)
        Me.Controls.Add(Me.pbBW)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.ChkSenior)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.dtpEfd)
        Me.Controls.Add(Me.ChkAll)
        Me.Controls.Add(Me.D)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmSelectBasicPrice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Basic Price Level"
        CType(Me.D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents D As System.Windows.Forms.DataGridView
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents dtpEfd As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents Chk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents BasicPriceLvl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChkSenior As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pbBW As System.Windows.Forms.PictureBox
    Friend WithEvents BW1 As System.ComponentModel.BackgroundWorker
End Class
