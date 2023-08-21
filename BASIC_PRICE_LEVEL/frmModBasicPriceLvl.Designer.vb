<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModBasicPriceLvl
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnLoad = New DevComponents.DotNetBar.ButtonX()
        Me.btnAdd = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.cboTDesc = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cboTCode = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.ChkAll1 = New System.Windows.Forms.CheckBox()
        Me.D = New System.Windows.Forms.DataGridView()
        Me.Chk = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BillDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ModifiedOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.D1 = New System.Windows.Forms.DataGridView()
        Me.DocEntry = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Chk1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.TestCode1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TestName1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pricelevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modified_On = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Modified_By = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddOn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSelect = New DevComponents.DotNetBar.ButtonX()
        Me.btnClear = New DevComponents.DotNetBar.ButtonX()
        Me.btnSave = New DevComponents.DotNetBar.ButtonX()
        Me.btnClose = New DevComponents.DotNetBar.ButtonX()
        Me.btn = New DevComponents.DotNetBar.ButtonX()
        Me.btnALine = New DevComponents.DotNetBar.ButtonX()
        Me.btnRLine = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.lblDocEntry = New System.Windows.Forms.Label()
        Me.btnCopPrice = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.cboSheet = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.lblXlFname = New DevComponents.DotNetBar.LabelX()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.btnSaveXlData = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.lblRecCnt = New DevComponents.DotNetBar.LabelX()
        CType(Me.D, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.D1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLoad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLoad.Location = New System.Drawing.Point(537, 13)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Load"
        '
        'btnAdd
        '
        Me.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAdd.Location = New System.Drawing.Point(618, 13)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(119, 12)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(61, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "Test Code :"
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'cboTDesc
        '
        Me.cboTDesc.DisplayMember = "Text"
        Me.cboTDesc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTDesc.ForeColor = System.Drawing.Color.Black
        Me.cboTDesc.FormattingEnabled = True
        Me.cboTDesc.ItemHeight = 17
        Me.cboTDesc.Location = New System.Drawing.Point(286, 13)
        Me.cboTDesc.Name = "cboTDesc"
        Me.cboTDesc.Size = New System.Drawing.Size(245, 23)
        Me.cboTDesc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTDesc.TabIndex = 9
        '
        'cboTCode
        '
        Me.cboTCode.DisplayMember = "Text"
        Me.cboTCode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboTCode.ForeColor = System.Drawing.Color.Black
        Me.cboTCode.FormattingEnabled = True
        Me.cboTCode.ItemHeight = 17
        Me.cboTCode.Location = New System.Drawing.Point(186, 12)
        Me.cboTCode.Name = "cboTCode"
        Me.cboTCode.Size = New System.Drawing.Size(94, 23)
        Me.cboTCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboTCode.TabIndex = 10
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkAll.ForeColor = System.Drawing.Color.Black
        Me.ChkAll.Location = New System.Drawing.Point(21, 45)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(15, 14)
        Me.ChkAll.TabIndex = 11
        Me.ChkAll.UseVisualStyleBackColor = False
        '
        'ChkAll1
        '
        Me.ChkAll1.AutoSize = True
        Me.ChkAll1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ChkAll1.ForeColor = System.Drawing.Color.Black
        Me.ChkAll1.Location = New System.Drawing.Point(627, 45)
        Me.ChkAll1.Name = "ChkAll1"
        Me.ChkAll1.Size = New System.Drawing.Size(15, 14)
        Me.ChkAll1.TabIndex = 12
        Me.ChkAll1.UseVisualStyleBackColor = False
        '
        'D
        '
        Me.D.AllowUserToAddRows = False
        Me.D.AllowUserToDeleteRows = False
        Me.D.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.D.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Chk, Me.TestCode, Me.TestName, Me.BillCode, Me.BillDesc, Me.ModifiedOn})
        Me.D.Location = New System.Drawing.Point(12, 41)
        Me.D.Name = "D"
        Me.D.RowHeadersVisible = False
        Me.D.Size = New System.Drawing.Size(600, 381)
        Me.D.TabIndex = 13
        '
        'Chk
        '
        Me.Chk.HeaderText = ""
        Me.Chk.Name = "Chk"
        Me.Chk.Width = 30
        '
        'TestCode
        '
        Me.TestCode.HeaderText = "TestCode"
        Me.TestCode.Name = "TestCode"
        Me.TestCode.ReadOnly = True
        Me.TestCode.Width = 70
        '
        'TestName
        '
        Me.TestName.HeaderText = "TestName"
        Me.TestName.Name = "TestName"
        Me.TestName.ReadOnly = True
        Me.TestName.Width = 210
        '
        'BillCode
        '
        Me.BillCode.HeaderText = "BillCode"
        Me.BillCode.Name = "BillCode"
        Me.BillCode.ReadOnly = True
        Me.BillCode.Width = 60
        '
        'BillDesc
        '
        Me.BillDesc.HeaderText = "BillDesc"
        Me.BillDesc.Name = "BillDesc"
        Me.BillDesc.ReadOnly = True
        Me.BillDesc.Width = 130
        '
        'ModifiedOn
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ModifiedOn.DefaultCellStyle = DataGridViewCellStyle3
        Me.ModifiedOn.HeaderText = "ModifiedOn"
        Me.ModifiedOn.Name = "ModifiedOn"
        Me.ModifiedOn.ReadOnly = True
        Me.ModifiedOn.Width = 80
        '
        'D1
        '
        Me.D1.AllowUserToAddRows = False
        Me.D1.AllowUserToDeleteRows = False
        Me.D1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.D1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.D1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DocEntry, Me.Chk1, Me.TestCode1, Me.TestName1, Me.Pricelevel, Me.Price, Me.Modified_On, Me.Modified_By, Me.AddOn, Me.AddBy})
        Me.D1.Location = New System.Drawing.Point(618, 41)
        Me.D1.Name = "D1"
        Me.D1.RowHeadersVisible = False
        Me.D1.Size = New System.Drawing.Size(613, 381)
        Me.D1.TabIndex = 14
        '
        'DocEntry
        '
        Me.DocEntry.HeaderText = "DocEntry"
        Me.DocEntry.Name = "DocEntry"
        Me.DocEntry.Visible = False
        '
        'Chk1
        '
        Me.Chk1.HeaderText = ""
        Me.Chk1.Name = "Chk1"
        Me.Chk1.Width = 30
        '
        'TestCode1
        '
        Me.TestCode1.HeaderText = "TestCode"
        Me.TestCode1.Name = "TestCode1"
        Me.TestCode1.ReadOnly = True
        Me.TestCode1.Width = 70
        '
        'TestName1
        '
        Me.TestName1.HeaderText = "TestName"
        Me.TestName1.Name = "TestName1"
        Me.TestName1.ReadOnly = True
        Me.TestName1.Width = 80
        '
        'Pricelevel
        '
        Me.Pricelevel.HeaderText = "Pricelevel"
        Me.Pricelevel.Name = "Pricelevel"
        Me.Pricelevel.Width = 70
        '
        'Price
        '
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.Width = 80
        '
        'Modified_On
        '
        DataGridViewCellStyle4.Format = "G"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Modified_On.DefaultCellStyle = DataGridViewCellStyle4
        Me.Modified_On.HeaderText = "ModifiedOn"
        Me.Modified_On.Name = "Modified_On"
        Me.Modified_On.ReadOnly = True
        Me.Modified_On.Width = 130
        '
        'Modified_By
        '
        Me.Modified_By.HeaderText = "ModifiedBy"
        Me.Modified_By.Name = "Modified_By"
        Me.Modified_By.ReadOnly = True
        '
        'AddOn
        '
        Me.AddOn.HeaderText = "AddOn"
        Me.AddOn.Name = "AddOn"
        Me.AddOn.ReadOnly = True
        Me.AddOn.Width = 130
        '
        'AddBy
        '
        Me.AddBy.HeaderText = "AddBy"
        Me.AddBy.Name = "AddBy"
        Me.AddBy.ReadOnly = True
        '
        'btnSelect
        '
        Me.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSelect.Location = New System.Drawing.Point(12, 428)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 23)
        Me.btnSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSelect.TabIndex = 15
        Me.btnSelect.Text = "Select"
        '
        'btnClear
        '
        Me.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnClear.Location = New System.Drawing.Point(537, 428)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnClear.TabIndex = 16
        Me.btnClear.Text = "Clear"
        '
        'btnSave
        '
        Me.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSave.Location = New System.Drawing.Point(618, 428)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSave.TabIndex = 17
        Me.btnSave.Text = "Save"
        '
        'btnClose
        '
        Me.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnClose.Location = New System.Drawing.Point(1156, 428)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "Close"
        '
        'btn
        '
        Me.btn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn.Location = New System.Drawing.Point(699, 465)
        Me.btn.Name = "btn"
        Me.btn.Size = New System.Drawing.Size(149, 23)
        Me.btn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn.TabIndex = 19
        Me.btn.Text = "Proceed in price generation"
        '
        'btnALine
        '
        Me.btnALine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnALine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnALine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnALine.Location = New System.Drawing.Point(1062, 13)
        Me.btnALine.Name = "btnALine"
        Me.btnALine.Size = New System.Drawing.Size(88, 23)
        Me.btnALine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnALine.TabIndex = 20
        Me.btnALine.Text = "Add New Line"
        '
        'btnRLine
        '
        Me.btnRLine.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRLine.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnRLine.Location = New System.Drawing.Point(1156, 13)
        Me.btnRLine.Name = "btnRLine"
        Me.btnRLine.Size = New System.Drawing.Size(75, 23)
        Me.btnRLine.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnRLine.TabIndex = 21
        Me.btnRLine.Text = "Remove Line"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(12, 12)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(61, 23)
        Me.LabelX2.TabIndex = 22
        Me.LabelX2.Text = "DocEntry :"
        '
        'lblDocEntry
        '
        Me.lblDocEntry.AutoSize = True
        Me.lblDocEntry.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDocEntry.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDocEntry.ForeColor = System.Drawing.Color.Black
        Me.lblDocEntry.Location = New System.Drawing.Point(79, 12)
        Me.lblDocEntry.Name = "lblDocEntry"
        Me.lblDocEntry.Size = New System.Drawing.Size(18, 20)
        Me.lblDocEntry.TabIndex = 23
        Me.lblDocEntry.Text = "0"
        '
        'btnCopPrice
        '
        Me.btnCopPrice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCopPrice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopPrice.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCopPrice.Location = New System.Drawing.Point(93, 428)
        Me.btnCopPrice.Name = "btnCopPrice"
        Me.btnCopPrice.Size = New System.Drawing.Size(143, 23)
        Me.btnCopPrice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCopPrice.TabIndex = 24
        Me.btnCopPrice.Text = "Copy Price from Masterlist"
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
        Me.LabelX4.Location = New System.Drawing.Point(150, 465)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(63, 23)
        Me.LabelX4.TabIndex = 890
        Me.LabelX4.Text = "Excel Sheet :"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'cboSheet
        '
        Me.cboSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboSheet.DisplayMember = "Text"
        Me.cboSheet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboSheet.ForeColor = System.Drawing.Color.Black
        Me.cboSheet.FormattingEnabled = True
        Me.cboSheet.ItemHeight = 17
        Me.cboSheet.Location = New System.Drawing.Point(219, 465)
        Me.cboSheet.Name = "cboSheet"
        Me.cboSheet.Size = New System.Drawing.Size(118, 23)
        Me.cboSheet.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cboSheet.TabIndex = 889
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
        Me.lblXlFname.Location = New System.Drawing.Point(343, 465)
        Me.lblXlFname.Name = "lblXlFname"
        Me.lblXlFname.Size = New System.Drawing.Size(188, 23)
        Me.lblXlFname.TabIndex = 888
        Me.lblXlFname.Text = "No Excel"
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
        Me.btnImport.Location = New System.Drawing.Point(12, 457)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(129, 31)
        Me.btnImport.TabIndex = 891
        Me.btnImport.Text = "Import Excel File"
        Me.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImport.UseVisualStyleBackColor = False
        '
        'btnSaveXlData
        '
        Me.btnSaveXlData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSaveXlData.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveXlData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSaveXlData.Location = New System.Drawing.Point(537, 465)
        Me.btnSaveXlData.Name = "btnSaveXlData"
        Me.btnSaveXlData.Size = New System.Drawing.Size(156, 23)
        Me.btnSaveXlData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSaveXlData.TabIndex = 892
        Me.btnSaveXlData.Text = "Save Excel Data"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(242, 428)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(38, 23)
        Me.LabelX3.TabIndex = 893
        Me.LabelX3.Text = "Count :"
        '
        'lblRecCnt
        '
        Me.lblRecCnt.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        '
        '
        '
        Me.lblRecCnt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblRecCnt.ForeColor = System.Drawing.Color.Black
        Me.lblRecCnt.Location = New System.Drawing.Point(286, 428)
        Me.lblRecCnt.Name = "lblRecCnt"
        Me.lblRecCnt.Size = New System.Drawing.Size(62, 23)
        Me.lblRecCnt.TabIndex = 894
        Me.lblRecCnt.Text = "0"
        '
        'frmModBasicPriceLvl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1243, 500)
        Me.Controls.Add(Me.lblRecCnt)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.btnSaveXlData)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.cboSheet)
        Me.Controls.Add(Me.lblXlFname)
        Me.Controls.Add(Me.btnCopPrice)
        Me.Controls.Add(Me.lblDocEntry)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.btnRLine)
        Me.Controls.Add(Me.btnALine)
        Me.Controls.Add(Me.btn)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.ChkAll1)
        Me.Controls.Add(Me.ChkAll)
        Me.Controls.Add(Me.cboTCode)
        Me.Controls.Add(Me.cboTDesc)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.D)
        Me.Controls.Add(Me.D1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmModBasicPriceLvl"
        Me.Text = "Basic Price Level Maintenance"
        CType(Me.D, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.D1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoad As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAdd As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents cboTDesc As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cboTCode As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ChkAll As System.Windows.Forms.CheckBox
    Friend WithEvents ChkAll1 As System.Windows.Forms.CheckBox
    Friend WithEvents D As System.Windows.Forms.DataGridView
    Friend WithEvents D1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnSelect As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnClear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSave As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnClose As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnALine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnRLine As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Chk As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDocEntry As System.Windows.Forms.Label
    Friend WithEvents btnCopPrice As DevComponents.DotNetBar.ButtonX
    Friend WithEvents DocEntry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Chk1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents TestCode1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TestName1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pricelevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modified_On As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Modified_By As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddOn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cboSheet As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents lblXlFname As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnSaveXlData As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblRecCnt As DevComponents.DotNetBar.LabelX
End Class
