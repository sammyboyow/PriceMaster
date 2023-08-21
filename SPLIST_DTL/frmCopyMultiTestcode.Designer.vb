<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCopyMultiTestcode
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
        Me.txtNtcode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNtdesc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtNBcode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.dtpEFD = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtOtcode = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtOtdesc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.StyleManager1 = New DevComponents.DotNetBar.StyleManager(Me.components)
        Me.btnImport = New System.Windows.Forms.Button()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.dtpEFD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtNtcode
        '
        Me.txtNtcode.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNtcode.Border.Class = "TextBoxBorder"
        Me.txtNtcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNtcode.DisabledBackColor = System.Drawing.Color.White
        Me.txtNtcode.FocusHighlightColor = System.Drawing.Color.SteelBlue
        Me.txtNtcode.ForeColor = System.Drawing.Color.Black
        Me.txtNtcode.Location = New System.Drawing.Point(121, 3)
        Me.txtNtcode.Name = "txtNtcode"
        Me.txtNtcode.PreventEnterBeep = True
        Me.txtNtcode.Size = New System.Drawing.Size(100, 22)
        Me.txtNtcode.TabIndex = 0
        Me.txtNtcode.WatermarkText = "e.g. CBC"
        '
        'txtNtdesc
        '
        Me.txtNtdesc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNtdesc.Border.Class = "TextBoxBorder"
        Me.txtNtdesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNtdesc.DisabledBackColor = System.Drawing.Color.White
        Me.txtNtdesc.FocusHighlightColor = System.Drawing.Color.SteelBlue
        Me.txtNtdesc.ForeColor = System.Drawing.Color.Black
        Me.txtNtdesc.Location = New System.Drawing.Point(227, 3)
        Me.txtNtdesc.Name = "txtNtdesc"
        Me.txtNtdesc.PreventEnterBeep = True
        Me.txtNtdesc.Size = New System.Drawing.Size(298, 22)
        Me.txtNtdesc.TabIndex = 1
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(14, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(101, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "New Testcode :"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(14, 32)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(101, 23)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "New Test BillCode :"
        Me.LabelX2.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'txtNBcode
        '
        Me.txtNBcode.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNBcode.Border.Class = "TextBoxBorder"
        Me.txtNBcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNBcode.DisabledBackColor = System.Drawing.Color.White
        Me.txtNBcode.FocusHighlightColor = System.Drawing.Color.SteelBlue
        Me.txtNBcode.ForeColor = System.Drawing.Color.Black
        Me.txtNBcode.Location = New System.Drawing.Point(121, 32)
        Me.txtNBcode.Name = "txtNBcode"
        Me.txtNBcode.PreventEnterBeep = True
        Me.txtNBcode.Size = New System.Drawing.Size(100, 22)
        Me.txtNBcode.TabIndex = 3
        Me.txtNBcode.WatermarkText = "e.g. 4500"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.dtpEFD)
        Me.GroupPanel1.Controls.Add(Me.LabelX3)
        Me.GroupPanel1.Controls.Add(Me.txtNtcode)
        Me.GroupPanel1.Controls.Add(Me.LabelX2)
        Me.GroupPanel1.Controls.Add(Me.txtNtdesc)
        Me.GroupPanel1.Controls.Add(Me.txtNBcode)
        Me.GroupPanel1.Controls.Add(Me.LabelX1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.ShowFocusRectangle = True
        Me.GroupPanel1.Size = New System.Drawing.Size(540, 84)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 5
        Me.GroupPanel1.Text = "New Test Details"
        '
        'dtpEFD
        '
        Me.dtpEFD.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.dtpEFD.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpEFD.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEFD.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtpEFD.ButtonDropDown.Visible = True
        Me.dtpEFD.ForeColor = System.Drawing.Color.Black
        Me.dtpEFD.IsPopupCalendarOpen = False
        Me.dtpEFD.Location = New System.Drawing.Point(318, 31)
        '
        '
        '
        '
        '
        '
        Me.dtpEFD.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEFD.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpEFD.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpEFD.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtpEFD.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEFD.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtpEFD.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtpEFD.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtpEFD.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtpEFD.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEFD.MonthCalendar.DisplayMonth = New Date(2019, 5, 1, 0, 0, 0, 0)
        '
        '
        '
        Me.dtpEFD.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpEFD.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpEFD.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpEFD.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpEFD.MonthCalendar.TodayButtonVisible = True
        Me.dtpEFD.Name = "dtpEFD"
        Me.dtpEFD.Size = New System.Drawing.Size(207, 22)
        Me.dtpEFD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtpEFD.TabIndex = 6
        Me.dtpEFD.WatermarkText = "01/01/1900"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(227, 31)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(85, 23)
        Me.LabelX3.TabIndex = 5
        Me.LabelX3.Text = "Effectivity Date :"
        Me.LabelX3.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.CanvasColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel2.Controls.Add(Me.txtOtcode)
        Me.GroupPanel2.Controls.Add(Me.txtOtdesc)
        Me.GroupPanel2.Controls.Add(Me.LabelX6)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(12, 102)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.ShowFocusRectangle = True
        Me.GroupPanel2.Size = New System.Drawing.Size(540, 55)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 7
        Me.GroupPanel2.Text = "Old Test Details"
        '
        'txtOtcode
        '
        Me.txtOtcode.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtOtcode.Border.Class = "TextBoxBorder"
        Me.txtOtcode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOtcode.DisabledBackColor = System.Drawing.Color.White
        Me.txtOtcode.FocusHighlightColor = System.Drawing.Color.SteelBlue
        Me.txtOtcode.ForeColor = System.Drawing.Color.Black
        Me.txtOtcode.Location = New System.Drawing.Point(121, 3)
        Me.txtOtcode.Name = "txtOtcode"
        Me.txtOtcode.PreventEnterBeep = True
        Me.txtOtcode.Size = New System.Drawing.Size(100, 22)
        Me.txtOtcode.TabIndex = 0
        Me.txtOtcode.WatermarkText = "e.g. CBC"
        '
        'txtOtdesc
        '
        Me.txtOtdesc.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtOtdesc.Border.Class = "TextBoxBorder"
        Me.txtOtdesc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOtdesc.DisabledBackColor = System.Drawing.Color.White
        Me.txtOtdesc.FocusHighlightColor = System.Drawing.Color.SteelBlue
        Me.txtOtdesc.ForeColor = System.Drawing.Color.Black
        Me.txtOtdesc.Location = New System.Drawing.Point(227, 3)
        Me.txtOtdesc.Name = "txtOtdesc"
        Me.txtOtdesc.PreventEnterBeep = True
        Me.txtOtdesc.Size = New System.Drawing.Size(298, 22)
        Me.txtOtdesc.TabIndex = 1
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(14, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(101, 23)
        Me.LabelX6.TabIndex = 2
        Me.LabelX6.Text = "Old Testcode :"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnCopy
        '
        Me.btnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCopy.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCopy.ForeColor = System.Drawing.Color.Black
        Me.btnCopy.Location = New System.Drawing.Point(12, 167)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 23)
        Me.btnCopy.TabIndex = 8
        Me.btnCopy.Text = "&Copy"
        Me.btnCopy.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(476, 167)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'StyleManager1
        '
        Me.StyleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
        Me.StyleManager1.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(43, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(154, Byte), Integer)))
        '
        'btnImport
        '
        Me.btnImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnImport.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnImport.ForeColor = System.Drawing.Color.Black
        Me.btnImport.Location = New System.Drawing.Point(93, 167)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 10
        Me.btnImport.Text = "&Import"
        Me.btnImport.UseVisualStyleBackColor = False
        '
        'frmCopyMultiTestcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 202)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupPanel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCopyMultiTestcode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Copy Testcode"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.dtpEFD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtNtcode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNtdesc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNBcode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents dtpEFD As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtOtcode As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtOtdesc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Public WithEvents StyleManager1 As DevComponents.DotNetBar.StyleManager
    Friend WithEvents btnImport As System.Windows.Forms.Button
End Class
