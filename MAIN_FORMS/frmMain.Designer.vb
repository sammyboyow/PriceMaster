<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSPLoad = New DevComponents.DotNetBar.ButtonX()
        Me.cbSPSearch = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem5 = New DevComponents.Editors.ComboItem()
        Me.ComboItem6 = New DevComponents.Editors.ComboItem()
        Me.ComboItem8 = New DevComponents.Editors.ComboItem()
        Me.ComboItem9 = New DevComponents.Editors.ComboItem()
        Me.txtSPSearch = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.d2 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.SPBATCH_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SPD_EFD_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SP_ITEM_COUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SP_IS_SYNC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SP_W_ERROR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ViewSPComp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabItem2 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tmScan = New System.Windows.Forms.Timer(Me.components)
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.ViewIMHComp = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLoad = New DevComponents.DotNetBar.ButtonX()
        Me.cbType = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.ComboItem3 = New DevComponents.Editors.ComboItem()
        Me.ComboItem4 = New DevComponents.Editors.ComboItem()
        Me.ComboItem7 = New DevComponents.Editors.ComboItem()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.d1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.BATCH_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTHER_BRANCH = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EFD_DATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ITEM_COUNT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BATCH_STAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.W_ERR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabItem1 = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.btnDTI = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.INPUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ITEMMASTERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SINGLETESTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PACKAGETESTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SINGLEIMPORTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SPECIALLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UPDATETRANSACTIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COPYTESTCODEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COPYTESTCODENEWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COPYMULTIPLETESTCODEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GENERATESPLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IMPORTBASICPRICELEVELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.USERToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SYNCTESTCODEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRICELISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRICELISTToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PRICELISTEXCEPTIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCEPTIONTESTCODEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DTIMAINTENANCEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IMPORTBASICPRICEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EXCEPTIONTESTGROUPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SYNCSPLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ITEMMASTERHToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BATCHCREATIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BASICPRICELEVELToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BASICPRICELEVELNEWToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SPLISTMASTERLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BASICPRICELEVELPROFILEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MASTERDATAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ITEMMASTERToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SPLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BASICPRICEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SPLISTToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BATCHREPORTEXPORTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.COMPUTATIONToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LOGOUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnMIN = New System.Windows.Forms.Button()
        Me.lblDateTime = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbImg = New System.Windows.Forms.PictureBox()
        Me.btnX = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SENDINSPLISTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControlPanel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.d2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ViewSPComp.SuspendLayout()
        Me.ViewIMHComp.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.d1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.pbImg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.GroupBox2)
        Me.TabControlPanel2.Controls.Add(Me.d2)
        Me.TabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(653, 344)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 5
        Me.TabControlPanel2.TabItem = Me.TabItem2
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnSPLoad)
        Me.GroupBox2.Controls.Add(Me.cbSPSearch)
        Me.GroupBox2.Controls.Add(Me.txtSPSearch)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(548, 51)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'btnSPLoad
        '
        Me.btnSPLoad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSPLoad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSPLoad.Location = New System.Drawing.Point(454, 16)
        Me.btnSPLoad.Name = "btnSPLoad"
        Me.btnSPLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnSPLoad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSPLoad.TabIndex = 8
        Me.btnSPLoad.Text = "Load"
        '
        'cbSPSearch
        '
        Me.cbSPSearch.DisplayMember = "Text"
        Me.cbSPSearch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbSPSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSPSearch.ForeColor = System.Drawing.Color.Black
        Me.cbSPSearch.FormattingEnabled = True
        Me.cbSPSearch.ItemHeight = 15
        Me.cbSPSearch.Items.AddRange(New Object() {Me.ComboItem5, Me.ComboItem6, Me.ComboItem8, Me.ComboItem9})
        Me.cbSPSearch.Location = New System.Drawing.Point(59, 19)
        Me.cbSPSearch.Name = "cbSPSearch"
        Me.cbSPSearch.Size = New System.Drawing.Size(121, 21)
        Me.cbSPSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbSPSearch.TabIndex = 5
        '
        'ComboItem6
        '
        Me.ComboItem6.Text = "BATCH ID"
        '
        'ComboItem8
        '
        Me.ComboItem8.Text = "EFFECTIVE DATE"
        '
        'ComboItem9
        '
        Me.ComboItem9.Text = "TEST"
        '
        'txtSPSearch
        '
        Me.txtSPSearch.Location = New System.Drawing.Point(186, 19)
        Me.txtSPSearch.Name = "txtSPSearch"
        Me.txtSPSearch.Size = New System.Drawing.Size(262, 20)
        Me.txtSPSearch.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(9, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Search:"
        '
        'd2
        '
        Me.d2.AllowUserToAddRows = False
        Me.d2.AllowUserToResizeColumns = False
        Me.d2.AllowUserToResizeRows = False
        Me.d2.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.d2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.d2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SPBATCH_ID, Me.SPD_EFD_DATE, Me.SP_ITEM_COUNT, Me.SP_IS_SYNC, Me.SP_W_ERROR})
        Me.d2.ContextMenuStrip = Me.ViewSPComp
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.d2.DefaultCellStyle = DataGridViewCellStyle4
        Me.d2.EnableHeadersVisualStyles = False
        Me.d2.GridColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.d2.Location = New System.Drawing.Point(15, 58)
        Me.d2.MultiSelect = False
        Me.d2.Name = "d2"
        Me.d2.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d2.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.d2.RowHeadersVisible = False
        Me.d2.Size = New System.Drawing.Size(548, 269)
        Me.d2.TabIndex = 3
        '
        'SPBATCH_ID
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SPBATCH_ID.DefaultCellStyle = DataGridViewCellStyle2
        Me.SPBATCH_ID.HeaderText = "BATCH_ID"
        Me.SPBATCH_ID.Name = "SPBATCH_ID"
        Me.SPBATCH_ID.ReadOnly = True
        '
        'SPD_EFD_DATE
        '
        Me.SPD_EFD_DATE.HeaderText = "EFD_DATE"
        Me.SPD_EFD_DATE.Name = "SPD_EFD_DATE"
        Me.SPD_EFD_DATE.ReadOnly = True
        '
        'SP_ITEM_COUNT
        '
        Me.SP_ITEM_COUNT.HeaderText = "ITEM_COUNT"
        Me.SP_ITEM_COUNT.Name = "SP_ITEM_COUNT"
        Me.SP_ITEM_COUNT.ReadOnly = True
        '
        'SP_IS_SYNC
        '
        Me.SP_IS_SYNC.HeaderText = "BATCH_STAT"
        Me.SP_IS_SYNC.Name = "SP_IS_SYNC"
        Me.SP_IS_SYNC.ReadOnly = True
        '
        'SP_W_ERROR
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.SP_W_ERROR.DefaultCellStyle = DataGridViewCellStyle3
        Me.SP_W_ERROR.HeaderText = "WITH ERROR"
        Me.SP_W_ERROR.Name = "SP_W_ERROR"
        Me.SP_W_ERROR.ReadOnly = True
        '
        'ViewSPComp
        '
        Me.ViewSPComp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailsToolStripMenuItem})
        Me.ViewSPComp.Name = "ViewSPComp"
        Me.ViewSPComp.Size = New System.Drawing.Size(138, 26)
        Me.ViewSPComp.Text = "View Details"
        '
        'ViewDetailsToolStripMenuItem
        '
        Me.ViewDetailsToolStripMenuItem.Name = "ViewDetailsToolStripMenuItem"
        Me.ViewDetailsToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.ViewDetailsToolStripMenuItem.Text = "View Details"
        '
        'TabItem2
        '
        Me.TabItem2.AttachedControl = Me.TabControlPanel2
        Me.TabItem2.Name = "TabItem2"
        Me.TabItem2.Text = "SPECIAL PRICE LIST"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'tmScan
        '
        Me.tmScan.Enabled = True
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'ViewIMHComp
        '
        Me.ViewIMHComp.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailsToolStripMenuItem1})
        Me.ViewIMHComp.Name = "ViewIMHComp"
        Me.ViewIMHComp.Size = New System.Drawing.Size(138, 26)
        Me.ViewIMHComp.Text = "View Details"
        '
        'ViewDetailsToolStripMenuItem1
        '
        Me.ViewDetailsToolStripMenuItem1.Name = "ViewDetailsToolStripMenuItem1"
        Me.ViewDetailsToolStripMenuItem1.Size = New System.Drawing.Size(137, 22)
        Me.ViewDetailsToolStripMenuItem1.Text = "View Details"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TabControl1)
        Me.Panel2.Controls.Add(Me.btnDTI)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(991, 498)
        Me.Panel2.TabIndex = 1
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.White
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.ForeColor = System.Drawing.Color.Black
        Me.TabControl1.Location = New System.Drawing.Point(11, 39)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(653, 370)
        Me.TabControl1.TabIndex = 2
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.TabItem1)
        Me.TabControl1.Tabs.Add(Me.TabItem2)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.GroupBox1)
        Me.TabControlPanel1.Controls.Add(Me.d1)
        Me.TabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(653, 344)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.TabItem1
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnLoad)
        Me.GroupBox1.Controls.Add(Me.cbType)
        Me.GroupBox1.Controls.Add(Me.txtSearch)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(548, 51)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLoad.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLoad.Location = New System.Drawing.Point(454, 16)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(75, 23)
        Me.btnLoad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLoad.TabIndex = 4
        Me.btnLoad.Text = "Load"
        '
        'cbType
        '
        Me.cbType.DisplayMember = "Text"
        Me.cbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbType.ForeColor = System.Drawing.Color.Black
        Me.cbType.FormattingEnabled = True
        Me.cbType.ItemHeight = 15
        Me.cbType.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2, Me.ComboItem3, Me.ComboItem4, Me.ComboItem7})
        Me.cbType.Location = New System.Drawing.Point(59, 19)
        Me.cbType.Name = "cbType"
        Me.cbType.Size = New System.Drawing.Size(121, 21)
        Me.cbType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbType.TabIndex = 1
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "BATCH ID"
        '
        'ComboItem3
        '
        Me.ComboItem3.Text = "MOTHER BRANCH"
        '
        'ComboItem4
        '
        Me.ComboItem4.Text = "EFFECTIVE DATE"
        '
        'ComboItem7
        '
        Me.ComboItem7.Text = "TEST"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(186, 19)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(262, 20)
        Me.txtSearch.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(9, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Search:"
        '
        'd1
        '
        Me.d1.AllowUserToAddRows = False
        Me.d1.AllowUserToResizeColumns = False
        Me.d1.AllowUserToResizeRows = False
        Me.d1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.d1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.d1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BATCH_ID, Me.MOTHER_BRANCH, Me.EFD_DATE, Me.ITEM_COUNT, Me.BATCH_STAT, Me.W_ERR})
        Me.d1.ContextMenuStrip = Me.ViewIMHComp
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.d1.DefaultCellStyle = DataGridViewCellStyle9
        Me.d1.EnableHeadersVisualStyles = False
        Me.d1.GridColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.d1.Location = New System.Drawing.Point(15, 58)
        Me.d1.MultiSelect = False
        Me.d1.Name = "d1"
        Me.d1.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d1.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.d1.RowHeadersVisible = False
        Me.d1.Size = New System.Drawing.Size(622, 269)
        Me.d1.TabIndex = 0
        '
        'BATCH_ID
        '
        Me.BATCH_ID.HeaderText = "BATCH_ID"
        Me.BATCH_ID.Name = "BATCH_ID"
        Me.BATCH_ID.ReadOnly = True
        Me.BATCH_ID.Width = 80
        '
        'MOTHER_BRANCH
        '
        Me.MOTHER_BRANCH.HeaderText = "MOTHER_BRANCH"
        Me.MOTHER_BRANCH.Name = "MOTHER_BRANCH"
        Me.MOTHER_BRANCH.ReadOnly = True
        Me.MOTHER_BRANCH.Visible = False
        Me.MOTHER_BRANCH.Width = 140
        '
        'EFD_DATE
        '
        Me.EFD_DATE.HeaderText = "EFD_DATE"
        Me.EFD_DATE.Name = "EFD_DATE"
        Me.EFD_DATE.ReadOnly = True
        '
        'ITEM_COUNT
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ITEM_COUNT.DefaultCellStyle = DataGridViewCellStyle7
        Me.ITEM_COUNT.HeaderText = "TEST_COUNT"
        Me.ITEM_COUNT.Name = "ITEM_COUNT"
        Me.ITEM_COUNT.ReadOnly = True
        '
        'BATCH_STAT
        '
        Me.BATCH_STAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.BATCH_STAT.HeaderText = "BATCH_STAT"
        Me.BATCH_STAT.Name = "BATCH_STAT"
        Me.BATCH_STAT.ReadOnly = True
        '
        'W_ERR
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.W_ERR.DefaultCellStyle = DataGridViewCellStyle8
        Me.W_ERR.HeaderText = "WITH ERROR"
        Me.W_ERR.Name = "W_ERR"
        Me.W_ERR.ReadOnly = True
        '
        'TabItem1
        '
        Me.TabItem1.AttachedControl = Me.TabControlPanel1
        Me.TabItem1.Name = "TabItem1"
        Me.TabItem1.Text = "ITEM MASTERH "
        '
        'btnDTI
        '
        Me.btnDTI.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDTI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDTI.Location = New System.Drawing.Point(867, 27)
        Me.btnDTI.Name = "btnDTI"
        Me.btnDTI.Size = New System.Drawing.Size(111, 23)
        Me.btnDTI.TabIndex = 1
        Me.btnDTI.Text = "DTI EXPIRATION"
        Me.btnDTI.UseVisualStyleBackColor = True
        Me.btnDTI.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.INPUTToolStripMenuItem, Me.MaintenanceToolStripMenuItem, Me.ReportToolStripMenuItem, Me.LOGOUTToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(989, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'INPUTToolStripMenuItem
        '
        Me.INPUTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ITEMMASTERToolStripMenuItem, Me.SPECIALLISTToolStripMenuItem, Me.UPDATETRANSACTIONToolStripMenuItem, Me.COPYTESTCODEToolStripMenuItem, Me.COPYTESTCODENEWToolStripMenuItem, Me.COPYMULTIPLETESTCODEToolStripMenuItem, Me.GENERATESPLISTToolStripMenuItem, Me.IMPORTBASICPRICELEVELToolStripMenuItem})
        Me.INPUTToolStripMenuItem.Name = "INPUTToolStripMenuItem"
        Me.INPUTToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.INPUTToolStripMenuItem.Text = "INPUT"
        '
        'ITEMMASTERToolStripMenuItem
        '
        Me.ITEMMASTERToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SINGLETESTToolStripMenuItem, Me.PACKAGETESTToolStripMenuItem, Me.SINGLEIMPORTToolStripMenuItem})
        Me.ITEMMASTERToolStripMenuItem.Name = "ITEMMASTERToolStripMenuItem"
        Me.ITEMMASTERToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.ITEMMASTERToolStripMenuItem.Text = "ITEM MASTER"
        '
        'SINGLETESTToolStripMenuItem
        '
        Me.SINGLETESTToolStripMenuItem.Name = "SINGLETESTToolStripMenuItem"
        Me.SINGLETESTToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SINGLETESTToolStripMenuItem.Text = "SINGLE TEST"
        '
        'PACKAGETESTToolStripMenuItem
        '
        Me.PACKAGETESTToolStripMenuItem.Name = "PACKAGETESTToolStripMenuItem"
        Me.PACKAGETESTToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.PACKAGETESTToolStripMenuItem.Text = "PACKAGE TEST"
        '
        'SINGLEIMPORTToolStripMenuItem
        '
        Me.SINGLEIMPORTToolStripMenuItem.Name = "SINGLEIMPORTToolStripMenuItem"
        Me.SINGLEIMPORTToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SINGLEIMPORTToolStripMenuItem.Text = "SINGLE IMPORT"
        '
        'SPECIALLISTToolStripMenuItem
        '
        Me.SPECIALLISTToolStripMenuItem.Name = "SPECIALLISTToolStripMenuItem"
        Me.SPECIALLISTToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.SPECIALLISTToolStripMenuItem.Text = "SPECIAL CUSTOMER"
        '
        'UPDATETRANSACTIONToolStripMenuItem
        '
        Me.UPDATETRANSACTIONToolStripMenuItem.Name = "UPDATETRANSACTIONToolStripMenuItem"
        Me.UPDATETRANSACTIONToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.UPDATETRANSACTIONToolStripMenuItem.Text = "UPDATE TRANSACTION"
        '
        'COPYTESTCODEToolStripMenuItem
        '
        Me.COPYTESTCODEToolStripMenuItem.Name = "COPYTESTCODEToolStripMenuItem"
        Me.COPYTESTCODEToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.COPYTESTCODEToolStripMenuItem.Text = "COPY TESTCODE"
        Me.COPYTESTCODEToolStripMenuItem.Visible = False
        '
        'COPYTESTCODENEWToolStripMenuItem
        '
        Me.COPYTESTCODENEWToolStripMenuItem.Name = "COPYTESTCODENEWToolStripMenuItem"
        Me.COPYTESTCODENEWToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.COPYTESTCODENEWToolStripMenuItem.Text = "COPY TESTCODE NEW"
        '
        'COPYMULTIPLETESTCODEToolStripMenuItem
        '
        Me.COPYMULTIPLETESTCODEToolStripMenuItem.Name = "COPYMULTIPLETESTCODEToolStripMenuItem"
        Me.COPYMULTIPLETESTCODEToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.COPYMULTIPLETESTCODEToolStripMenuItem.Text = "COPY MULTIPLE TESTCODE"
        Me.COPYMULTIPLETESTCODEToolStripMenuItem.Visible = False
        '
        'GENERATESPLISTToolStripMenuItem
        '
        Me.GENERATESPLISTToolStripMenuItem.Name = "GENERATESPLISTToolStripMenuItem"
        Me.GENERATESPLISTToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.GENERATESPLISTToolStripMenuItem.Text = "GENERATE SPLIST"
        Me.GENERATESPLISTToolStripMenuItem.Visible = False
        '
        'IMPORTBASICPRICELEVELToolStripMenuItem
        '
        Me.IMPORTBASICPRICELEVELToolStripMenuItem.Name = "IMPORTBASICPRICELEVELToolStripMenuItem"
        Me.IMPORTBASICPRICELEVELToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.IMPORTBASICPRICELEVELToolStripMenuItem.Text = "IMPORT BASIC PRICE LEVEL"
        Me.IMPORTBASICPRICELEVELToolStripMenuItem.Visible = False
        '
        'MaintenanceToolStripMenuItem
        '
        Me.MaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.USERToolStripMenuItem, Me.SYNCTESTCODEToolStripMenuItem, Me.PRICELISTToolStripMenuItem, Me.SYNCSPLISTToolStripMenuItem, Me.ITEMMASTERHToolStripMenuItem, Me.BASICPRICELEVELToolStripMenuItem, Me.BASICPRICELEVELNEWToolStripMenuItem, Me.SPLISTMASTERLISTToolStripMenuItem, Me.BASICPRICELEVELPROFILEToolStripMenuItem, Me.SENDINSPLISTToolStripMenuItem})
        Me.MaintenanceToolStripMenuItem.Name = "MaintenanceToolStripMenuItem"
        Me.MaintenanceToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.MaintenanceToolStripMenuItem.Text = "MAINTENANCE"
        '
        'USERToolStripMenuItem
        '
        Me.USERToolStripMenuItem.Name = "USERToolStripMenuItem"
        Me.USERToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.USERToolStripMenuItem.Text = "USER"
        '
        'SYNCTESTCODEToolStripMenuItem
        '
        Me.SYNCTESTCODEToolStripMenuItem.Name = "SYNCTESTCODEToolStripMenuItem"
        Me.SYNCTESTCODEToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SYNCTESTCODEToolStripMenuItem.Text = "SYNC TEST CODE"
        Me.SYNCTESTCODEToolStripMenuItem.Visible = False
        '
        'PRICELISTToolStripMenuItem
        '
        Me.PRICELISTToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PRICELISTToolStripMenuItem1, Me.PRICELISTEXCEPTIONToolStripMenuItem, Me.EXCEPTIONTESTCODEToolStripMenuItem, Me.DTIMAINTENANCEToolStripMenuItem, Me.IMPORTBASICPRICEToolStripMenuItem, Me.EXCEPTIONTESTGROUPToolStripMenuItem})
        Me.PRICELISTToolStripMenuItem.Name = "PRICELISTToolStripMenuItem"
        Me.PRICELISTToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.PRICELISTToolStripMenuItem.Text = "PRICING SCHEME"
        '
        'PRICELISTToolStripMenuItem1
        '
        Me.PRICELISTToolStripMenuItem1.Name = "PRICELISTToolStripMenuItem1"
        Me.PRICELISTToolStripMenuItem1.Size = New System.Drawing.Size(212, 22)
        Me.PRICELISTToolStripMenuItem1.Text = "PRICE LIST"
        '
        'PRICELISTEXCEPTIONToolStripMenuItem
        '
        Me.PRICELISTEXCEPTIONToolStripMenuItem.Name = "PRICELISTEXCEPTIONToolStripMenuItem"
        Me.PRICELISTEXCEPTIONToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.PRICELISTEXCEPTIONToolStripMenuItem.Text = "PRICE LIST EXCEPTION"
        '
        'EXCEPTIONTESTCODEToolStripMenuItem
        '
        Me.EXCEPTIONTESTCODEToolStripMenuItem.Name = "EXCEPTIONTESTCODEToolStripMenuItem"
        Me.EXCEPTIONTESTCODEToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.EXCEPTIONTESTCODEToolStripMenuItem.Text = "EXCEPTION (TEST CODE)"
        '
        'DTIMAINTENANCEToolStripMenuItem
        '
        Me.DTIMAINTENANCEToolStripMenuItem.Name = "DTIMAINTENANCEToolStripMenuItem"
        Me.DTIMAINTENANCEToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.DTIMAINTENANCEToolStripMenuItem.Text = "DTI MAINTENANCE"
        '
        'IMPORTBASICPRICEToolStripMenuItem
        '
        Me.IMPORTBASICPRICEToolStripMenuItem.Name = "IMPORTBASICPRICEToolStripMenuItem"
        Me.IMPORTBASICPRICEToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.IMPORTBASICPRICEToolStripMenuItem.Text = "IMPORT BASIC PRICE"
        '
        'EXCEPTIONTESTGROUPToolStripMenuItem
        '
        Me.EXCEPTIONTESTGROUPToolStripMenuItem.Name = "EXCEPTIONTESTGROUPToolStripMenuItem"
        Me.EXCEPTIONTESTGROUPToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.EXCEPTIONTESTGROUPToolStripMenuItem.Text = "EXCEPTION (TEST GROUP)"
        '
        'SYNCSPLISTToolStripMenuItem
        '
        Me.SYNCSPLISTToolStripMenuItem.Name = "SYNCSPLISTToolStripMenuItem"
        Me.SYNCSPLISTToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SYNCSPLISTToolStripMenuItem.Text = "SYNC SPLIST"
        Me.SYNCSPLISTToolStripMenuItem.Visible = False
        '
        'ITEMMASTERHToolStripMenuItem
        '
        Me.ITEMMASTERHToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BATCHCREATIONToolStripMenuItem})
        Me.ITEMMASTERHToolStripMenuItem.Name = "ITEMMASTERHToolStripMenuItem"
        Me.ITEMMASTERHToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.ITEMMASTERHToolStripMenuItem.Text = "ITEM MASTERH"
        '
        'BATCHCREATIONToolStripMenuItem
        '
        Me.BATCHCREATIONToolStripMenuItem.Name = "BATCHCREATIONToolStripMenuItem"
        Me.BATCHCREATIONToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.BATCHCREATIONToolStripMenuItem.Text = "BATCH CREATION"
        '
        'BASICPRICELEVELToolStripMenuItem
        '
        Me.BASICPRICELEVELToolStripMenuItem.Name = "BASICPRICELEVELToolStripMenuItem"
        Me.BASICPRICELEVELToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.BASICPRICELEVELToolStripMenuItem.Text = "BASIC PRICE LEVEL"
        Me.BASICPRICELEVELToolStripMenuItem.Visible = False
        '
        'BASICPRICELEVELNEWToolStripMenuItem
        '
        Me.BASICPRICELEVELNEWToolStripMenuItem.Name = "BASICPRICELEVELNEWToolStripMenuItem"
        Me.BASICPRICELEVELNEWToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.BASICPRICELEVELNEWToolStripMenuItem.Text = "BASIC PRICE LEVEL NEW"
        Me.BASICPRICELEVELNEWToolStripMenuItem.Visible = False
        '
        'SPLISTMASTERLISTToolStripMenuItem
        '
        Me.SPLISTMASTERLISTToolStripMenuItem.Name = "SPLISTMASTERLISTToolStripMenuItem"
        Me.SPLISTMASTERLISTToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SPLISTMASTERLISTToolStripMenuItem.Text = "SPLIST MASTER LIST"
        '
        'BASICPRICELEVELPROFILEToolStripMenuItem
        '
        Me.BASICPRICELEVELPROFILEToolStripMenuItem.Name = "BASICPRICELEVELPROFILEToolStripMenuItem"
        Me.BASICPRICELEVELPROFILEToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.BASICPRICELEVELPROFILEToolStripMenuItem.Text = "PRICE LEVEL PROFILE"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MASTERDATAToolStripMenuItem, Me.BASICPRICEToolStripMenuItem, Me.SPLISTToolStripMenuItem1})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ReportToolStripMenuItem.Text = "REPORT"
        '
        'MASTERDATAToolStripMenuItem
        '
        Me.MASTERDATAToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ITEMMASTERToolStripMenuItem1, Me.SPLISTToolStripMenuItem})
        Me.MASTERDATAToolStripMenuItem.Name = "MASTERDATAToolStripMenuItem"
        Me.MASTERDATAToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.MASTERDATAToolStripMenuItem.Text = "MASTER DATA"
        '
        'ITEMMASTERToolStripMenuItem1
        '
        Me.ITEMMASTERToolStripMenuItem1.Name = "ITEMMASTERToolStripMenuItem1"
        Me.ITEMMASTERToolStripMenuItem1.Size = New System.Drawing.Size(147, 22)
        Me.ITEMMASTERToolStripMenuItem1.Text = "ITEM MASTER"
        '
        'SPLISTToolStripMenuItem
        '
        Me.SPLISTToolStripMenuItem.Name = "SPLISTToolStripMenuItem"
        Me.SPLISTToolStripMenuItem.Size = New System.Drawing.Size(147, 22)
        Me.SPLISTToolStripMenuItem.Text = "SPLIST"
        '
        'BASICPRICEToolStripMenuItem
        '
        Me.BASICPRICEToolStripMenuItem.Name = "BASICPRICEToolStripMenuItem"
        Me.BASICPRICEToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.BASICPRICEToolStripMenuItem.Text = "BASIC PRICE "
        '
        'SPLISTToolStripMenuItem1
        '
        Me.SPLISTToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BATCHREPORTEXPORTToolStripMenuItem, Me.COMPUTATIONToolStripMenuItem})
        Me.SPLISTToolStripMenuItem1.Name = "SPLISTToolStripMenuItem1"
        Me.SPLISTToolStripMenuItem1.Size = New System.Drawing.Size(149, 22)
        Me.SPLISTToolStripMenuItem1.Text = "SPLIST"
        '
        'BATCHREPORTEXPORTToolStripMenuItem
        '
        Me.BATCHREPORTEXPORTToolStripMenuItem.Name = "BATCHREPORTEXPORTToolStripMenuItem"
        Me.BATCHREPORTEXPORTToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.BATCHREPORTEXPORTToolStripMenuItem.Text = "BATCH REPORT EXPORT"
        '
        'COMPUTATIONToolStripMenuItem
        '
        Me.COMPUTATIONToolStripMenuItem.Name = "COMPUTATIONToolStripMenuItem"
        Me.COMPUTATIONToolStripMenuItem.Size = New System.Drawing.Size(198, 22)
        Me.COMPUTATIONToolStripMenuItem.Text = "COMPUTATION"
        '
        'LOGOUTToolStripMenuItem
        '
        Me.LOGOUTToolStripMenuItem.Name = "LOGOUTToolStripMenuItem"
        Me.LOGOUTToolStripMenuItem.Size = New System.Drawing.Size(70, 20)
        Me.LOGOUTToolStripMenuItem.Text = "LOG-OUT"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnMIN)
        Me.Panel1.Controls.Add(Me.lblDateTime)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblVersion)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.pbImg)
        Me.Panel1.Controls.Add(Me.btnX)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(991, 100)
        Me.Panel1.TabIndex = 0
        '
        'btnMIN
        '
        Me.btnMIN.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMIN.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnMIN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMIN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMIN.Location = New System.Drawing.Point(910, 11)
        Me.btnMIN.Name = "btnMIN"
        Me.btnMIN.Size = New System.Drawing.Size(31, 23)
        Me.btnMIN.TabIndex = 10
        Me.btnMIN.Text = "--"
        Me.btnMIN.UseVisualStyleBackColor = False
        '
        'lblDateTime
        '
        Me.lblDateTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDateTime.AutoSize = True
        Me.lblDateTime.BackColor = System.Drawing.Color.Transparent
        Me.lblDateTime.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateTime.ForeColor = System.Drawing.Color.White
        Me.lblDateTime.Location = New System.Drawing.Point(802, 69)
        Me.lblDateTime.Name = "lblDateTime"
        Me.lblDateTime.Size = New System.Drawing.Size(68, 16)
        Me.lblDateTime.TabIndex = 9
        Me.lblDateTime.Text = "DateTime"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(676, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Current Date/Time:"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(232, 69)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(71, 16)
        Me.lblVersion.TabIndex = 7
        Me.lblVersion.Text = "lblVersion"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.BackColor = System.Drawing.Color.Transparent
        Me.lblUser.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.ForeColor = System.Drawing.Color.White
        Me.lblUser.Location = New System.Drawing.Point(232, 44)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(51, 16)
        Me.lblUser.TabIndex = 6
        Me.lblUser.Text = "lblUser"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(139, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Version:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(140, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Current User:"
        '
        'pbImg
        '
        Me.pbImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbImg.Location = New System.Drawing.Point(11, 8)
        Me.pbImg.Name = "pbImg"
        Me.pbImg.Size = New System.Drawing.Size(121, 82)
        Me.pbImg.TabIndex = 3
        Me.pbImg.TabStop = False
        '
        'btnX
        '
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(947, 11)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(31, 23)
        Me.btnX.TabIndex = 2
        Me.btnX.Text = "X"
        Me.btnX.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(138, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(310, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Price Master System  -  Main"
        '
        'SENDINSPLISTToolStripMenuItem
        '
        Me.SENDINSPLISTToolStripMenuItem.Name = "SENDINSPLISTToolStripMenuItem"
        Me.SENDINSPLISTToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.SENDINSPLISTToolStripMenuItem.Text = "SEND-IN SPLIST"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 598)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMain"
        Me.TabControlPanel2.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.d2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ViewSPComp.ResumeLayout(False)
        Me.ViewIMHComp.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.d1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pbImg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pbImg As System.Windows.Forms.PictureBox
    Friend WithEvents btnX As System.Windows.Forms.Button
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDateTime As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents INPUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ITEMMASTERToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SINGLETESTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PACKAGETESTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LOGOUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents USERToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SPECIALLISTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SYNCTESTCODEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SINGLEIMPORTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRICELISTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SYNCSPLISTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRICELISTToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PRICELISTEXCEPTIONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GENERATESPLISTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MASTERDATAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ITEMMASTERToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SPLISTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnMIN As System.Windows.Forms.Button
    Friend WithEvents EXCEPTIONTESTCODEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnDTI As System.Windows.Forms.Button
    Friend WithEvents tmScan As System.Windows.Forms.Timer
    Friend WithEvents BASICPRICEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DTIMAINTENANCEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents d1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem3 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem4 As DevComponents.Editors.ComboItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents d2 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ComboItem5 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem6 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem8 As DevComponents.Editors.ComboItem
    Friend WithEvents txtSPSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents IMPORTBASICPRICEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SPBATCH_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPD_EFD_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SP_ITEM_COUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SP_IS_SYNC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SP_W_ERROR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UPDATETRANSACTIONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ITEMMASTERHToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BATCHCREATIONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EXCEPTIONTESTGROUPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SPLISTToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BATCHREPORTEXPORTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Private WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Private WithEvents TabItem1 As DevComponents.DotNetBar.TabItem
    Private WithEvents cbType As DevComponents.DotNetBar.Controls.ComboBoxEx
    Private WithEvents btnLoad As DevComponents.DotNetBar.ButtonX
    Private WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Private WithEvents TabItem2 As DevComponents.DotNetBar.TabItem
    Private WithEvents btnSPLoad As DevComponents.DotNetBar.ButtonX
    Private WithEvents cbSPSearch As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents COPYTESTCODEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COPYTESTCODENEWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents IMPORTBASICPRICELEVELToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewSPComp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COMPUTATIONToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewIMHComp As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewDetailsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents COPYMULTIPLETESTCODEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BASICPRICELEVELToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BASICPRICELEVELNEWToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BATCH_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTHER_BRANCH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EFD_DATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ITEM_COUNT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BATCH_STAT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents W_ERR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SPLISTMASTERLISTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BASICPRICELEVELPROFILEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboItem7 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem9 As DevComponents.Editors.ComboItem
    Friend WithEvents SENDINSPLISTToolStripMenuItem As ToolStripMenuItem
End Class
