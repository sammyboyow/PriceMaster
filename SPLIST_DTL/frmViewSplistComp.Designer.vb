<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewSplistComp
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.D = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SPD_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TEST_GROUP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_IMH_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_CURR_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_EFD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_PREV_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Blank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PRICE_LEVEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BASIC_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERCENTAGE1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PERCENTAGE2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BATCH_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBatchID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnExport = New DevComponents.DotNetBar.ButtonX()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnForSync = New System.Windows.Forms.Button()
        CType(Me.D, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Metro
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'D
        '
        Me.D.AllowUserToAddRows = False
        Me.D.AllowUserToDeleteRows = False
        Me.D.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.D.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.D.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.D.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SPD_CODE, Me.SPD_DESC, Me.TEST_GROUP, Me.SPD_IMH_CODE, Me.SPD_CURR_PRICE, Me.SPD_EFD, Me.SPD_PREV_PRICE, Me.Blank, Me.PRICE_LEVEL, Me.BASIC_PRICE, Me.PERCENTAGE1, Me.PERCENTAGE2, Me.BATCH_ID})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.D.DefaultCellStyle = DataGridViewCellStyle3
        Me.D.EnableHeadersVisualStyles = False
        Me.D.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.D.Location = New System.Drawing.Point(12, 51)
        Me.D.Name = "D"
        Me.D.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.D.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.D.RowHeadersVisible = False
        Me.D.Size = New System.Drawing.Size(1144, 392)
        Me.D.TabIndex = 0
        '
        'SPD_CODE
        '
        Me.SPD_CODE.HeaderText = "SPD_CODE"
        Me.SPD_CODE.Name = "SPD_CODE"
        Me.SPD_CODE.ReadOnly = True
        '
        'SPD_DESC
        '
        Me.SPD_DESC.HeaderText = "SPD_DESC"
        Me.SPD_DESC.Name = "SPD_DESC"
        Me.SPD_DESC.ReadOnly = True
        '
        'TEST_GROUP
        '
        Me.TEST_GROUP.HeaderText = "TEST_GROUP"
        Me.TEST_GROUP.Name = "TEST_GROUP"
        Me.TEST_GROUP.ReadOnly = True
        '
        'SPD_IMH_CODE
        '
        Me.SPD_IMH_CODE.HeaderText = "SPD_IMH_CODE"
        Me.SPD_IMH_CODE.Name = "SPD_IMH_CODE"
        Me.SPD_IMH_CODE.ReadOnly = True
        '
        'SPD_CURR_PRICE
        '
        Me.SPD_CURR_PRICE.HeaderText = "SPD_CURR_PRICE"
        Me.SPD_CURR_PRICE.Name = "SPD_CURR_PRICE"
        Me.SPD_CURR_PRICE.ReadOnly = True
        '
        'SPD_EFD
        '
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.SPD_EFD.DefaultCellStyle = DataGridViewCellStyle2
        Me.SPD_EFD.HeaderText = "SPD_EFD"
        Me.SPD_EFD.Name = "SPD_EFD"
        Me.SPD_EFD.ReadOnly = True
        '
        'SPD_PREV_PRICE
        '
        Me.SPD_PREV_PRICE.HeaderText = "SPD_PREV_PRICE"
        Me.SPD_PREV_PRICE.Name = "SPD_PREV_PRICE"
        Me.SPD_PREV_PRICE.ReadOnly = True
        '
        'Blank
        '
        Me.Blank.HeaderText = "Blank"
        Me.Blank.Name = "Blank"
        Me.Blank.ReadOnly = True
        Me.Blank.Width = 5
        '
        'PRICE_LEVEL
        '
        Me.PRICE_LEVEL.HeaderText = "PRICE_LEVEL"
        Me.PRICE_LEVEL.Name = "PRICE_LEVEL"
        Me.PRICE_LEVEL.ReadOnly = True
        '
        'BASIC_PRICE
        '
        Me.BASIC_PRICE.HeaderText = "BASIC_PRICE"
        Me.BASIC_PRICE.Name = "BASIC_PRICE"
        Me.BASIC_PRICE.ReadOnly = True
        '
        'PERCENTAGE1
        '
        Me.PERCENTAGE1.HeaderText = "PERCENTAGE1"
        Me.PERCENTAGE1.Name = "PERCENTAGE1"
        Me.PERCENTAGE1.ReadOnly = True
        '
        'PERCENTAGE2
        '
        Me.PERCENTAGE2.HeaderText = "PERCENTAGE2"
        Me.PERCENTAGE2.Name = "PERCENTAGE2"
        Me.PERCENTAGE2.ReadOnly = True
        '
        'BATCH_ID
        '
        Me.BATCH_ID.HeaderText = "BATCH_ID"
        Me.BATCH_ID.Name = "BATCH_ID"
        Me.BATCH_ID.ReadOnly = True
        '
        'txtBatchID
        '
        Me.txtBatchID.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtBatchID.Border.Class = "TextBoxBorder"
        Me.txtBatchID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBatchID.DisabledBackColor = System.Drawing.Color.White
        Me.txtBatchID.FocusHighlightColor = System.Drawing.Color.SteelBlue
        Me.txtBatchID.ForeColor = System.Drawing.Color.Black
        Me.txtBatchID.Location = New System.Drawing.Point(69, 13)
        Me.txtBatchID.Name = "txtBatchID"
        Me.txtBatchID.PreventEnterBeep = True
        Me.txtBatchID.Size = New System.Drawing.Size(100, 22)
        Me.txtBatchID.TabIndex = 1
        Me.txtBatchID.WatermarkText = "e.g. 143"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(51, 23)
        Me.LabelX1.TabIndex = 3
        Me.LabelX1.Text = "Batch ID :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnExport
        '
        Me.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExport.Location = New System.Drawing.Point(1062, 449)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(94, 23)
        Me.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExport.TabIndex = 872
        Me.btnExport.Text = "Export to Excel"
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnLoad.FlatAppearance.BorderSize = 2
        Me.btnLoad.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue
        Me.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson
        Me.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ForeColor = System.Drawing.Color.Black
        Me.btnLoad.Image = Global.PriceMaster.My.Resources.Resources.refresh
        Me.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLoad.Location = New System.Drawing.Point(1067, 12)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(89, 33)
        Me.btnLoad.TabIndex = 871
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnForSync
        '
        Me.btnForSync.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnForSync.ForeColor = System.Drawing.Color.Black
        Me.btnForSync.Location = New System.Drawing.Point(12, 449)
        Me.btnForSync.Name = "btnForSync"
        Me.btnForSync.Size = New System.Drawing.Size(112, 23)
        Me.btnForSync.TabIndex = 874
        Me.btnForSync.Text = "Tag as For Sync"
        Me.btnForSync.UseVisualStyleBackColor = False
        '
        'frmViewSplistComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 484)
        Me.Controls.Add(Me.btnForSync)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtBatchID)
        Me.Controls.Add(Me.D)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmViewSplistComp"
        Me.Text = "Special Price List Computation"
        CType(Me.D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents D As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtBatchID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SPD_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_DESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TEST_GROUP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_IMH_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_CURR_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_EFD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_PREV_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Blank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PRICE_LEVEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BASIC_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERCENTAGE1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PERCENTAGE2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BATCH_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnForSync As System.Windows.Forms.Button
End Class
