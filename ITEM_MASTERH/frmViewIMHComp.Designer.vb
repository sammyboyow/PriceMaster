<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewIMHComp
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.D = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.MOTHER_BRANCH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_PDGROUP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_BILLCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_YTD_SAMT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_CURR_P1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_EFD_P1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_PREV_P1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_CURR_P2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_EFD_P2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_PREV_P2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_CURR_P3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_EFD_P3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_PREV_P3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_FIXED_PRICE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_REC_FLAG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_UPDATE_BY = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_UPDATE_ON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODIFIED_ON = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BATCH_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtBatchID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnExport = New DevComponents.DotNetBar.ButtonX()
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
        Me.D.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MOTHER_BRANCH, Me.IMH_CODE, Me.IMH_DESC, Me.IMH_TYPE, Me.IMH_PDGROUP, Me.IMH_BILLCODE, Me.IMH_YTD_SAMT, Me.IMH_CURR_P1, Me.IMH_EFD_P1, Me.IMH_PREV_P1, Me.IMH_CURR_P2, Me.IMH_EFD_P2, Me.IMH_PREV_P2, Me.IMH_CURR_P3, Me.IMH_EFD_P3, Me.IMH_PREV_P3, Me.IMH_FIXED_PRICE, Me.IMH_REC_FLAG, Me.IMH_UPDATE_BY, Me.IMH_UPDATE_ON, Me.MODIFIED_ON, Me.BATCH_ID})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.D.DefaultCellStyle = DataGridViewCellStyle5
        Me.D.EnableHeadersVisualStyles = False
        Me.D.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.D.Location = New System.Drawing.Point(12, 51)
        Me.D.Name = "D"
        Me.D.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.D.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.D.RowHeadersVisible = False
        Me.D.Size = New System.Drawing.Size(1144, 421)
        Me.D.TabIndex = 0
        '
        'MOTHER_BRANCH
        '
        Me.MOTHER_BRANCH.Frozen = True
        Me.MOTHER_BRANCH.HeaderText = "MOTHER_BRANCH"
        Me.MOTHER_BRANCH.Name = "MOTHER_BRANCH"
        Me.MOTHER_BRANCH.ReadOnly = True
        '
        'IMH_CODE
        '
        Me.IMH_CODE.Frozen = True
        Me.IMH_CODE.HeaderText = "IMH_CODE"
        Me.IMH_CODE.Name = "IMH_CODE"
        Me.IMH_CODE.ReadOnly = True
        '
        'IMH_DESC
        '
        Me.IMH_DESC.Frozen = True
        Me.IMH_DESC.HeaderText = "IMH_DESC"
        Me.IMH_DESC.Name = "IMH_DESC"
        Me.IMH_DESC.ReadOnly = True
        '
        'IMH_TYPE
        '
        Me.IMH_TYPE.HeaderText = "IMH_TYPE"
        Me.IMH_TYPE.Name = "IMH_TYPE"
        Me.IMH_TYPE.ReadOnly = True
        '
        'IMH_PDGROUP
        '
        Me.IMH_PDGROUP.HeaderText = "IMH_PDGROUP"
        Me.IMH_PDGROUP.Name = "IMH_PDGROUP"
        Me.IMH_PDGROUP.ReadOnly = True
        '
        'IMH_BILLCODE
        '
        Me.IMH_BILLCODE.HeaderText = "IMH_BILLCODE"
        Me.IMH_BILLCODE.Name = "IMH_BILLCODE"
        Me.IMH_BILLCODE.ReadOnly = True
        '
        'IMH_YTD_SAMT
        '
        Me.IMH_YTD_SAMT.HeaderText = "IMH_YTD_SAMT"
        Me.IMH_YTD_SAMT.Name = "IMH_YTD_SAMT"
        Me.IMH_YTD_SAMT.ReadOnly = True
        '
        'IMH_CURR_P1
        '
        Me.IMH_CURR_P1.HeaderText = "IMH_CURR_P1"
        Me.IMH_CURR_P1.Name = "IMH_CURR_P1"
        Me.IMH_CURR_P1.ReadOnly = True
        '
        'IMH_EFD_P1
        '
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.IMH_EFD_P1.DefaultCellStyle = DataGridViewCellStyle2
        Me.IMH_EFD_P1.HeaderText = "IMH_EFD_P1"
        Me.IMH_EFD_P1.Name = "IMH_EFD_P1"
        Me.IMH_EFD_P1.ReadOnly = True
        '
        'IMH_PREV_P1
        '
        Me.IMH_PREV_P1.HeaderText = "IMH_PREV_P1"
        Me.IMH_PREV_P1.Name = "IMH_PREV_P1"
        Me.IMH_PREV_P1.ReadOnly = True
        '
        'IMH_CURR_P2
        '
        Me.IMH_CURR_P2.HeaderText = "IMH_CURR_P2"
        Me.IMH_CURR_P2.Name = "IMH_CURR_P2"
        Me.IMH_CURR_P2.ReadOnly = True
        '
        'IMH_EFD_P2
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.IMH_EFD_P2.DefaultCellStyle = DataGridViewCellStyle3
        Me.IMH_EFD_P2.HeaderText = "IMH_EFD_P2"
        Me.IMH_EFD_P2.Name = "IMH_EFD_P2"
        Me.IMH_EFD_P2.ReadOnly = True
        '
        'IMH_PREV_P2
        '
        Me.IMH_PREV_P2.HeaderText = "IMH_PREV_P2"
        Me.IMH_PREV_P2.Name = "IMH_PREV_P2"
        Me.IMH_PREV_P2.ReadOnly = True
        '
        'IMH_CURR_P3
        '
        Me.IMH_CURR_P3.HeaderText = "IMH_CURR_P3"
        Me.IMH_CURR_P3.Name = "IMH_CURR_P3"
        Me.IMH_CURR_P3.ReadOnly = True
        '
        'IMH_EFD_P3
        '
        DataGridViewCellStyle4.Format = "d"
        Me.IMH_EFD_P3.DefaultCellStyle = DataGridViewCellStyle4
        Me.IMH_EFD_P3.HeaderText = "IMH_EFD_P3"
        Me.IMH_EFD_P3.Name = "IMH_EFD_P3"
        Me.IMH_EFD_P3.ReadOnly = True
        '
        'IMH_PREV_P3
        '
        Me.IMH_PREV_P3.HeaderText = "IMH_PREV_P3"
        Me.IMH_PREV_P3.Name = "IMH_PREV_P3"
        Me.IMH_PREV_P3.ReadOnly = True
        '
        'IMH_FIXED_PRICE
        '
        Me.IMH_FIXED_PRICE.HeaderText = "IMH_FIXED_PRICE"
        Me.IMH_FIXED_PRICE.Name = "IMH_FIXED_PRICE"
        Me.IMH_FIXED_PRICE.ReadOnly = True
        '
        'IMH_REC_FLAG
        '
        Me.IMH_REC_FLAG.HeaderText = "IMH_REC_FLAG"
        Me.IMH_REC_FLAG.Name = "IMH_REC_FLAG"
        Me.IMH_REC_FLAG.ReadOnly = True
        '
        'IMH_UPDATE_BY
        '
        Me.IMH_UPDATE_BY.HeaderText = "IMH_UPDATE_BY"
        Me.IMH_UPDATE_BY.Name = "IMH_UPDATE_BY"
        Me.IMH_UPDATE_BY.ReadOnly = True
        '
        'IMH_UPDATE_ON
        '
        Me.IMH_UPDATE_ON.HeaderText = "IMH_UPDATE_ON"
        Me.IMH_UPDATE_ON.Name = "IMH_UPDATE_ON"
        Me.IMH_UPDATE_ON.ReadOnly = True
        '
        'MODIFIED_ON
        '
        Me.MODIFIED_ON.HeaderText = "MODIFIED_ON"
        Me.MODIFIED_ON.Name = "MODIFIED_ON"
        Me.MODIFIED_ON.ReadOnly = True
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
        'btnExport
        '
        Me.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExport.Location = New System.Drawing.Point(12, 449)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(94, 23)
        Me.btnExport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExport.TabIndex = 872
        Me.btnExport.Text = "Export to Excel"
        '
        'btnForSync
        '
        Me.btnForSync.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnForSync.ForeColor = System.Drawing.Color.Black
        Me.btnForSync.Location = New System.Drawing.Point(12, 479)
        Me.btnForSync.Name = "btnForSync"
        Me.btnForSync.Size = New System.Drawing.Size(112, 23)
        Me.btnForSync.TabIndex = 873
        Me.btnForSync.Text = "Tag as For Sync"
        Me.btnForSync.UseVisualStyleBackColor = False
        '
        'frmViewIMHComp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 514)
        Me.Controls.Add(Me.btnForSync)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtBatchID)
        Me.Controls.Add(Me.D)
        Me.Controls.Add(Me.btnExport)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmViewIMHComp"
        Me.Text = "IMH Basic Price"
        CType(Me.D, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents D As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtBatchID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnExport As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MOTHER_BRANCH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_DESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_PDGROUP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_BILLCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_YTD_SAMT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_CURR_P1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_EFD_P1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_PREV_P1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_CURR_P2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_EFD_P2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_PREV_P2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_CURR_P3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_EFD_P3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_PREV_P3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_FIXED_PRICE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_REC_FLAG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_UPDATE_BY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_UPDATE_ON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODIFIED_ON As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BATCH_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnForSync As System.Windows.Forms.Button
End Class
