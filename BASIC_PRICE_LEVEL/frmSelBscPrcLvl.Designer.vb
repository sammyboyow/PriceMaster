<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSelBscPrcLvl
    Inherits DevComponents.DotNetBar.Metro.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.D = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.PriceLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceList = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceListDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Regular_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Regular_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Special_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Special_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imaging_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Imaging_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UTZ_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UTZ_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IS_SENIOR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IS_MEMBER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IS_SENDIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.cboPricelvl = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cboPricelist = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ChkSenior = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.lblXlFname = New DevComponents.DotNetBar.LabelX()
        Me.cboSheet = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.dtpefd = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.BW1 = New System.ComponentModel.BackgroundWorker()
        Me.pbBW = New System.Windows.Forms.PictureBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.btnRemoveItem = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.lblDocEntry = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.chkSendin = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblCount = New DevComponents.DotNetBar.LabelX()
        Me.chkSendinOnly = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtpefd, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.D.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.D.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chk, Me.PriceLevel, Me.PriceList, Me.PriceListDesc, Me.Regular_1, Me.Regular_2, Me.Special_1, Me.Special_2, Me.Imaging_1, Me.Imaging_2, Me.UTZ_1, Me.UTZ_2, Me.IS_SENIOR, Me.IS_MEMBER, Me.IS_SENDIN})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.D.DefaultCellStyle = DataGridViewCellStyle2
        Me.D.EnableHeadersVisualStyles = False
        Me.D.GridColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.D.Location = New System.Drawing.Point(12, 51)
        Me.D.Name = "D"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.D.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.D.RowHeadersVisible = False
        Me.D.Size = New System.Drawing.Size(1141, 499)
        Me.D.TabIndex = 0
        '
        'Chk
        '
        Me.Chk.HeaderText = ""
        Me.Chk.Name = "Chk"
        Me.Chk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Chk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Chk.Width = 30
        '
        'PriceLevel
        '
        Me.PriceLevel.HeaderText = "PriceLevel"
        Me.PriceLevel.Name = "PriceLevel"
        Me.PriceLevel.ReadOnly = True
        Me.PriceLevel.Width = 70
        '
        'PriceList
        '
        Me.PriceList.HeaderText = "PriceList"
        Me.PriceList.Name = "PriceList"
        Me.PriceList.ReadOnly = True
        '
        'PriceListDesc
        '
        Me.PriceListDesc.HeaderText = "PriceListDesc"
        Me.PriceListDesc.Name = "PriceListDesc"
        Me.PriceListDesc.ReadOnly = True
        Me.PriceListDesc.Width = 200
        '
        'Regular_1
        '
        Me.Regular_1.HeaderText = "Regular_1"
        Me.Regular_1.Name = "Regular_1"
        Me.Regular_1.ReadOnly = True
        Me.Regular_1.Width = 65
        '
        'Regular_2
        '
        Me.Regular_2.HeaderText = "Regular_2"
        Me.Regular_2.Name = "Regular_2"
        Me.Regular_2.ReadOnly = True
        Me.Regular_2.Width = 65
        '
        'Special_1
        '
        Me.Special_1.HeaderText = "Special_1"
        Me.Special_1.Name = "Special_1"
        Me.Special_1.ReadOnly = True
        Me.Special_1.Width = 65
        '
        'Special_2
        '
        Me.Special_2.HeaderText = "Special_2"
        Me.Special_2.Name = "Special_2"
        Me.Special_2.ReadOnly = True
        Me.Special_2.Width = 65
        '
        'Imaging_1
        '
        Me.Imaging_1.HeaderText = "Imaging_1"
        Me.Imaging_1.Name = "Imaging_1"
        Me.Imaging_1.ReadOnly = True
        Me.Imaging_1.Width = 65
        '
        'Imaging_2
        '
        Me.Imaging_2.HeaderText = "Imaging_2"
        Me.Imaging_2.Name = "Imaging_2"
        Me.Imaging_2.ReadOnly = True
        Me.Imaging_2.Width = 65
        '
        'UTZ_1
        '
        Me.UTZ_1.HeaderText = "UTZ_1"
        Me.UTZ_1.Name = "UTZ_1"
        Me.UTZ_1.ReadOnly = True
        Me.UTZ_1.Width = 65
        '
        'UTZ_2
        '
        Me.UTZ_2.HeaderText = "UTZ_2"
        Me.UTZ_2.Name = "UTZ_2"
        Me.UTZ_2.ReadOnly = True
        Me.UTZ_2.Width = 65
        '
        'IS_SENIOR
        '
        Me.IS_SENIOR.HeaderText = "SENIOR"
        Me.IS_SENIOR.Name = "IS_SENIOR"
        Me.IS_SENIOR.ReadOnly = True
        Me.IS_SENIOR.Width = 60
        '
        'IS_MEMBER
        '
        Me.IS_MEMBER.HeaderText = "MEMBER"
        Me.IS_MEMBER.Name = "IS_MEMBER"
        Me.IS_MEMBER.Width = 60
        '
        'IS_SENDIN
        '
        Me.IS_SENDIN.HeaderText = "SENDIN"
        Me.IS_SENDIN.Name = "IS_SENDIN"
        Me.IS_SENDIN.Width = 60
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(107, 14)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(64, 23)
        Me.LabelX1.TabIndex = 871
        Me.LabelX1.Text = "Price Level :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(270, 13)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(85, 23)
        Me.LabelX2.TabIndex = 873
        Me.LabelX2.Text = "Price List/Desc :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkAll.ForeColor = System.Drawing.Color.Black
        Me.ChkAll.Location = New System.Drawing.Point(21, 54)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(15, 14)
        Me.ChkAll.TabIndex = 875
        Me.ChkAll.UseVisualStyleBackColor = False
        '
        'cboPricelvl
        '
        Me.cboPricelvl.DisplayMember = "Text"
        Me.cboPricelvl.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPricelvl.ForeColor = System.Drawing.Color.Black
        Me.cboPricelvl.FormattingEnabled = True
        Me.cboPricelvl.ItemHeight = 17
        Me.cboPricelvl.Location = New System.Drawing.Point(177, 14)
        Me.cboPricelvl.Name = "cboPricelvl"
        Me.cboPricelvl.Size = New System.Drawing.Size(87, 23)
        Me.cboPricelvl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboPricelvl.TabIndex = 877
        '
        'cboPricelist
        '
        Me.cboPricelist.DisplayMember = "Text"
        Me.cboPricelist.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboPricelist.ForeColor = System.Drawing.Color.Black
        Me.cboPricelist.FormattingEnabled = True
        Me.cboPricelist.ItemHeight = 17
        Me.cboPricelist.Location = New System.Drawing.Point(361, 14)
        Me.cboPricelist.Name = "cboPricelist"
        Me.cboPricelist.Size = New System.Drawing.Size(248, 23)
        Me.cboPricelist.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboPricelist.TabIndex = 878
        '
        'ChkSenior
        '
        Me.ChkSenior.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.ChkSenior.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ChkSenior.Checked = True
        Me.ChkSenior.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSenior.CheckValue = "Y"
        Me.ChkSenior.ForeColor = System.Drawing.Color.Black
        Me.ChkSenior.Location = New System.Drawing.Point(615, 13)
        Me.ChkSenior.Name = "ChkSenior"
        Me.ChkSenior.Size = New System.Drawing.Size(139, 23)
        Me.ChkSenior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ChkSenior.TabIndex = 883
        Me.ChkSenior.Text = "Include Senior Discount"
        '
        'LabelX3
        '
        Me.LabelX3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(147, 572)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(159, 23)
        Me.LabelX3.TabIndex = 884
        Me.LabelX3.Text = "F4 : Remove Non-Senior Price"
        '
        'lblXlFname
        '
        Me.lblXlFname.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblXlFname.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.lblXlFname.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblXlFname.ForeColor = System.Drawing.Color.Black
        Me.lblXlFname.Location = New System.Drawing.Point(340, 535)
        Me.lblXlFname.Name = "lblXlFname"
        Me.lblXlFname.Size = New System.Drawing.Size(655, 23)
        Me.lblXlFname.TabIndex = 885
        Me.lblXlFname.Text = "No Excel"
        Me.lblXlFname.Visible = False
        '
        'cboSheet
        '
        Me.cboSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboSheet.DisplayMember = "Text"
        Me.cboSheet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSheet.ForeColor = System.Drawing.Color.Black
        Me.cboSheet.FormattingEnabled = True
        Me.cboSheet.ItemHeight = 17
        Me.cboSheet.Location = New System.Drawing.Point(216, 535)
        Me.cboSheet.Name = "cboSheet"
        Me.cboSheet.Size = New System.Drawing.Size(118, 23)
        Me.cboSheet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboSheet.TabIndex = 886
        Me.cboSheet.Visible = False
        '
        'LabelX4
        '
        Me.LabelX4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(147, 535)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(63, 23)
        Me.LabelX4.TabIndex = 887
        Me.LabelX4.Text = "Excel Sheet :"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        Me.LabelX4.Visible = False
        '
        'dtpefd
        '
        Me.dtpefd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpefd.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.dtpefd.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpefd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpefd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpefd.ButtonDropDown.Visible = True
        Me.dtpefd.ForeColor = System.Drawing.Color.Black
        Me.dtpefd.IsPopupCalendarOpen = False
        Me.dtpefd.Location = New System.Drawing.Point(638, 573)
        '
        '
        '
        '
        '
        '
        Me.dtpefd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpefd.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpefd.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpefd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpefd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpefd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpefd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpefd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpefd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpefd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpefd.MonthCalendar.DisplayMonth = New Date(2019, 6, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dtpefd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpefd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpefd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpefd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpefd.MonthCalendar.TodayButtonVisible = True
        Me.dtpefd.Name = "dtpefd"
        Me.dtpefd.Size = New System.Drawing.Size(103, 22)
        Me.dtpefd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpefd.TabIndex = 889
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
        Me.LabelX5.Location = New System.Drawing.Point(545, 571)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(87, 23)
        Me.LabelX5.TabIndex = 890
        Me.LabelX5.Text = "Effectivity Date :"
        Me.LabelX5.TextAlignment = System.Drawing.StringAlignment.Far
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
        Me.pbBW.Location = New System.Drawing.Point(473, 181)
        Me.pbBW.Name = "pbBW"
        Me.pbBW.Size = New System.Drawing.Size(187, 187)
        Me.pbBW.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbBW.TabIndex = 891
        Me.pbBW.TabStop = False
        Me.pbBW.Visible = False
        '
        'btnGenerate
        '
        Me.btnGenerate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGenerate.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnGenerate.FlatAppearance.BorderSize = 2
        Me.btnGenerate.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue
        Me.btnGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson
        Me.btnGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerate.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerate.ForeColor = System.Drawing.Color.Black
        Me.btnGenerate.Image = Global.PriceMaster.My.Resources.Resources.icons8_process_50
        Me.btnGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGenerate.Location = New System.Drawing.Point(1038, 556)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(115, 39)
        Me.btnGenerate.TabIndex = 888
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerate.UseVisualStyleBackColor = False
        '
        'btnRemoveItem
        '
        Me.btnRemoveItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnRemoveItem.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnRemoveItem.FlatAppearance.BorderSize = 2
        Me.btnRemoveItem.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue
        Me.btnRemoveItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson
        Me.btnRemoveItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveItem.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveItem.ForeColor = System.Drawing.Color.Black
        Me.btnRemoveItem.Image = Global.PriceMaster.My.Resources.Resources.delete
        Me.btnRemoveItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRemoveItem.Location = New System.Drawing.Point(12, 568)
        Me.btnRemoveItem.Name = "btnRemoveItem"
        Me.btnRemoveItem.Size = New System.Drawing.Size(129, 31)
        Me.btnRemoveItem.TabIndex = 876
        Me.btnRemoveItem.Text = "Remove Selected"
        Me.btnRemoveItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRemoveItem.UseVisualStyleBackColor = False
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
        Me.btnLoad.Location = New System.Drawing.Point(1038, 5)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(115, 39)
        Me.btnLoad.TabIndex = 870
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLoad.UseVisualStyleBackColor = False
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImport.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.btnImport.FlatAppearance.BorderSize = 2
        Me.btnImport.FlatAppearance.CheckedBackColor = System.Drawing.Color.SteelBlue
        Me.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Crimson
        Me.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImport.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.ForeColor = System.Drawing.Color.Black
        Me.btnImport.Image = Global.PriceMaster.My.Resources.Resources.icons8_import_32
        Me.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImport.Location = New System.Drawing.Point(12, 531)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(129, 31)
        Me.btnImport.TabIndex = 13
        Me.btnImport.Text = "Import Excel File"
        Me.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImport.UseVisualStyleBackColor = False
        Me.btnImport.Visible = False
        '
        'lblDocEntry
        '
        Me.lblDocEntry.AutoSize = True
        Me.lblDocEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDocEntry.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocEntry.ForeColor = System.Drawing.Color.Black
        Me.lblDocEntry.Location = New System.Drawing.Point(74, 17)
        Me.lblDocEntry.Name = "lblDocEntry"
        Me.lblDocEntry.Size = New System.Drawing.Size(18, 20)
        Me.lblDocEntry.TabIndex = 894
        Me.lblDocEntry.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(9, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 893
        Me.Label6.Text = "Docentry :"
        '
        'LabelX6
        '
        Me.LabelX6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelX6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(324, 573)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(159, 23)
        Me.LabelX6.TabIndex = 895
        Me.LabelX6.Text = "F3 : Remove Member Price"
        '
        'chkSendin
        '
        Me.chkSendin.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.chkSendin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkSendin.ForeColor = System.Drawing.Color.Black
        Me.chkSendin.Location = New System.Drawing.Point(777, 13)
        Me.chkSendin.Name = "chkSendin"
        Me.chkSendin.Size = New System.Drawing.Size(96, 23)
        Me.chkSendin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkSendin.TabIndex = 896
        Me.chkSendin.Text = "Include Sendin"
        '
        'lblCount
        '
        Me.lblCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.lblCount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCount.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.Location = New System.Drawing.Point(802, 571)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(159, 23)
        Me.lblCount.TabIndex = 897
        Me.lblCount.Text = "Count: 0"
        '
        'chkSendinOnly
        '
        Me.chkSendinOnly.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.chkSendinOnly.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkSendinOnly.ForeColor = System.Drawing.Color.Black
        Me.chkSendinOnly.Location = New System.Drawing.Point(879, 13)
        Me.chkSendinOnly.Name = "chkSendinOnly"
        Me.chkSendinOnly.Size = New System.Drawing.Size(96, 23)
        Me.chkSendinOnly.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkSendinOnly.TabIndex = 898
        Me.chkSendinOnly.Text = "Sendin Only"
        '
        'frmSelBscPrcLvl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1165, 607)
        Me.Controls.Add(Me.chkSendinOnly)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.chkSendin)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.lblDocEntry)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.pbBW)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.dtpefd)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.ChkSenior)
        Me.Controls.Add(Me.cboPricelist)
        Me.Controls.Add(Me.cboPricelvl)
        Me.Controls.Add(Me.btnRemoveItem)
        Me.Controls.Add(Me.ChkAll)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.D)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.cboSheet)
        Me.Controls.Add(Me.lblXlFname)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "frmSelBscPrcLvl"
        Me.Text = "Select Basic Price Level"
        CType(Me.D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtpefd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbBW, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents D As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnRemoveItem As System.Windows.Forms.Button
    Friend WithEvents cboPricelvl As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cboPricelist As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ChkSenior As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblXlFname As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboSheet As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents dtpefd As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pbBW As System.Windows.Forms.PictureBox
    Friend WithEvents BW1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblDocEntry As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkSendin As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Chk As DataGridViewCheckBoxColumn
    Friend WithEvents PriceLevel As DataGridViewTextBoxColumn
    Friend WithEvents PriceList As DataGridViewTextBoxColumn
    Friend WithEvents PriceListDesc As DataGridViewTextBoxColumn
    Friend WithEvents Regular_1 As DataGridViewTextBoxColumn
    Friend WithEvents Regular_2 As DataGridViewTextBoxColumn
    Friend WithEvents Special_1 As DataGridViewTextBoxColumn
    Friend WithEvents Special_2 As DataGridViewTextBoxColumn
    Friend WithEvents Imaging_1 As DataGridViewTextBoxColumn
    Friend WithEvents Imaging_2 As DataGridViewTextBoxColumn
    Friend WithEvents UTZ_1 As DataGridViewTextBoxColumn
    Friend WithEvents UTZ_2 As DataGridViewTextBoxColumn
    Friend WithEvents IS_SENIOR As DataGridViewTextBoxColumn
    Friend WithEvents IS_MEMBER As DataGridViewTextBoxColumn
    Friend WithEvents IS_SENDIN As DataGridViewTextBoxColumn
    Friend WithEvents lblCount As DevComponents.DotNetBar.LabelX
    Friend WithEvents chkSendinOnly As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
