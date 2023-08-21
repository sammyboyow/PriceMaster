<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIMH_IMPORT
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnX = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnADD = New DevComponents.DotNetBar.ButtonX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIMHDesc = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPost = New DevComponents.DotNetBar.ButtonX()
        Me.d1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.IMH_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMH_DESC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblTestCount = New System.Windows.Forms.Label()
        Me.btnIMPORT = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.d1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Size = New System.Drawing.Size(743, 32)
        Me.Panel1.TabIndex = 0
        '
        'btnX
        '
        Me.btnX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnX.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnX.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnX.Location = New System.Drawing.Point(703, 5)
        Me.btnX.Name = "btnX"
        Me.btnX.Size = New System.Drawing.Size(29, 23)
        Me.btnX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnX.TabIndex = 0
        Me.btnX.Text = "x"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ITEM MASTERH IMPORT"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.btnIMPORT)
        Me.Panel2.Controls.Add(Me.lblTestCount)
        Me.Panel2.Controls.Add(Me.btnADD)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtIMHDesc)
        Me.Panel2.Controls.Add(Me.txtCode)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.btnPost)
        Me.Panel2.Controls.Add(Me.d1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 32)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(743, 463)
        Me.Panel2.TabIndex = 1
        '
        'btnADD
        '
        Me.btnADD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnADD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnADD.Location = New System.Drawing.Point(80, 92)
        Me.btnADD.Name = "btnADD"
        Me.btnADD.Size = New System.Drawing.Size(75, 23)
        Me.btnADD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnADD.TabIndex = 10
        Me.btnADD.Text = "ADD"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "IMH DESC:"
        '
        'txtIMHDesc
        '
        Me.txtIMHDesc.Location = New System.Drawing.Point(80, 66)
        Me.txtIMHDesc.Name = "txtIMHDesc"
        Me.txtIMHDesc.Size = New System.Drawing.Size(256, 20)
        Me.txtIMHDesc.TabIndex = 8
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(80, 40)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.ReadOnly = True
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "IMH CODE:"
        '
        'btnPost
        '
        Me.btnPost.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPost.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPost.Location = New System.Drawing.Point(658, 410)
        Me.btnPost.Name = "btnPost"
        Me.btnPost.Size = New System.Drawing.Size(75, 23)
        Me.btnPost.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPost.TabIndex = 5
        Me.btnPost.Text = "POST"
        '
        'd1
        '
        Me.d1.AllowUserToAddRows = False
        Me.d1.AllowUserToResizeColumns = False
        Me.d1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.d1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.d1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.d1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IMH_CODE, Me.IMH_DESC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.d1.DefaultCellStyle = DataGridViewCellStyle2
        Me.d1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.d1.Location = New System.Drawing.Point(342, 28)
        Me.d1.MultiSelect = False
        Me.d1.Name = "d1"
        Me.d1.ReadOnly = True
        Me.d1.RowHeadersVisible = False
        Me.d1.Size = New System.Drawing.Size(390, 377)
        Me.d1.TabIndex = 4
        '
        'IMH_CODE
        '
        Me.IMH_CODE.HeaderText = "IMH_CODE"
        Me.IMH_CODE.Name = "IMH_CODE"
        Me.IMH_CODE.ReadOnly = True
        '
        'IMH_DESC
        '
        Me.IMH_DESC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.IMH_DESC.HeaderText = "IMH_DESCRIPTION"
        Me.IMH_DESC.Name = "IMH_DESC"
        Me.IMH_DESC.ReadOnly = True
        '
        'lblTestCount
        '
        Me.lblTestCount.AutoSize = True
        Me.lblTestCount.Location = New System.Drawing.Point(339, 410)
        Me.lblTestCount.Name = "lblTestCount"
        Me.lblTestCount.Size = New System.Drawing.Size(112, 13)
        Me.lblTestCount.TabIndex = 11
        Me.lblTestCount.Text = "TEST CODE COUNT:"
        '
        'btnIMPORT
        '
        Me.btnIMPORT.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnIMPORT.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnIMPORT.Location = New System.Drawing.Point(161, 92)
        Me.btnIMPORT.Name = "btnIMPORT"
        Me.btnIMPORT.Size = New System.Drawing.Size(75, 23)
        Me.btnIMPORT.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnIMPORT.TabIndex = 12
        Me.btnIMPORT.Text = "IMPORT"
        '
        'frmIMH_IMPORT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 495)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmIMH_IMPORT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmIMH_IMPORT"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.d1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnX As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPost As DevComponents.DotNetBar.ButtonX
    Friend WithEvents d1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtIMHDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnADD As DevComponents.DotNetBar.ButtonX
    Friend WithEvents IMH_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMH_DESC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblTestCount As System.Windows.Forms.Label
    Friend WithEvents btnIMPORT As DevComponents.DotNetBar.ButtonX
End Class
