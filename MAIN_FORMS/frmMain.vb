Imports System.Data.SqlClient
Imports Oracle.DataAccess.Client
Imports System.Data.Odbc
Imports System.IO.StreamReader
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Public Class frmMain
    Dim txtBatchID As New TextBox

#Region "PROCEDURE/FUNCTION"
    Public Sub CreateImag(ByVal EmpCode As String)
        Dim cn As New SqlConnection("Data Source=192.171.10.51;Initial Catalog=HPCOMMON;Integrated Security=False;UID=sapdb;Pwd=sapdb;Max Pool Size=1000")
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim ms As MemoryStream = New MemoryStream()
        Dim imgBytes As Byte() = Nothing

        Dim str As String = "SELECT * FROM EMPPic WITH(NOLOCK) WHERE EMPCODE = '" & EmpCode & "'"
        Dim cmd As New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                Try
                    imgBytes = dr("EmpImg")
                    ms = New MemoryStream(imgBytes)
                    pbImg.Image = Nothing
                    pbImg.Image = Image.FromStream(ms)
                    pbImg.SizeMode = PictureBoxSizeMode.StretchImage
                Catch ex As Exception
                End Try
            End While
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Function chkDTI() As Boolean
        Try
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT TOP 1 1 " & _
                                "FROM SPLIST_DTI WITH(NOLOCK) " & _
                                "WHERE DATEDIFF(WEEK, GETDATE(), END_DATE) <= 2"
            Dim cmd As New SqlCommand(str, cn)
            str = cmd.ExecuteScalar

            If str Is Nothing Then
                Return False
            Else
                Return True
            End If
            cn.Dispose()
            cmd.Dispose()
            cn.Close()
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub LoadFields(Batch_ID As String)
        txtBatchID.Text = Batch_ID
        frmConfig_Udpate.txtSearch.Enabled = False
        frmConfig_Udpate.cbCat.Enabled = False
        frmConfig_Udpate.cbSearchType.Enabled = False
        frmConfig_Udpate.btnLoad.Enabled = False
        frmConfig_Udpate.btnClear.Enabled = False

        If ProcessName = "ITEM_MASTERH" Then
            frmConfig_Udpate.cbSearchType.SelectedIndex = 1
            frmConfig_Udpate.cbCat.SelectedIndex = 1
        Else
            frmConfig_Udpate.cbSearchType.SelectedIndex = 2
            frmConfig_Udpate.cbCat.SelectedIndex = 1
        End If
       
        frmConfig_Udpate.vtxtSearch.Text = txtBatchID.Text
        frmConfig_Udpate.LoadData(frmConfig_Udpate.vtxtSearch.Text)
        frmConfig_Udpate.ShowDialog()
    End Sub
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
        frmLogin.Show()
        frmLogin.txtUserName.Text = ""
        frmLogin.txtPassword.Text = ""
        frmLogin.txtUserName.Focus()
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.Opacity = 0.8
        Try
            Me.Top = 0
            Me.Left = 0
            Me.Height = Screen.PrimaryScreen.WorkingArea.Height
            Me.Width = Screen.PrimaryScreen.WorkingArea.Width

            RoundImag()
            CreateImag(Info.EmpID)
            lblDateTime.Text = Format(Now, "MM/dd/yyyy hh:mm:ss tt")
            lblUser.Text = Info.UserName
            lblVersion.Text = Info.Version
            MenuStrip1.ForeColor = Color.Black
            LoadIMH()
            LoadSPLIST()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Format(Now, "MM/dd/yyyy hh:mm:ss tt")
    End Sub

    Private Sub SINGLETESTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SINGLETESTToolStripMenuItem.Click
        frmSingle.ShowDialog()
    End Sub

    Private Sub PACKAGETESTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PACKAGETESTToolStripMenuItem.Click
        frmPackage.ShowDialog()
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Me.Dispose()
        frmLogin.Show()
        frmLogin.txtUserName.Text = ""
        frmLogin.txtPassword.Text = ""
        frmLogin.txtUserName.Focus()
    End Sub

    Private Sub USERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USERToolStripMenuItem.Click
        frmUserMaint.ShowDialog()
    End Sub

    Private Sub SYNCTESTCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SYNCTESTCODEToolStripMenuItem.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New OdbcConnection(cnStr)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim str As String = ""
        Dim cmd1 As New SqlCommand
        Dim adapt As New OdbcDataAdapter

        adapt = New OdbcDataAdapter("SELECT IMH_CODE,IMH_DESC,IMH_TYPE,IMH_PDGROUP,IMH_BILLCODE,IMH_HOSTCODE,IMH_STKUOM,IMH_STKITEM_FLAG,IMH_TAXABLE,IMH_YTD_SQTY, " & _
                                "IMH_YTD_SAMT,IMH_STD_COST,IMH_CURR_P1,IMH_EFD_P1,IMH_PREV_P1,IMH_CURR_P2,IMH_EFD_P2,IMH_PREV_P2,IMH_CURR_P3,IMH_EFD_P3,IMH_PREV_P3, " & _
                                "IMH_FIXED_PRICE,IMH_REC_FLAG,IMH_UPDATE_BY,IMH_UPDATE_ON,IMH_INSURANCE_CODE,IMH_DEPT_CODE,MODIFIED_ON FROM ITEM_MASTERH ", cn2)
        Dim dt As New DataTable
        dt = New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            Dim blkCopy As New SqlBulkCopy(cn)
            With blkCopy
                .DestinationTableName = "ITEM_MASTERH"

                Try
                    str = "TRUNCATE TABLE ITEM_MASTERH"
                    cmd1 = New SqlCommand(str, cn)
                    cmd1.ExecuteNonQuery()

                    .BulkCopyTimeout = 0
                    .WriteToServer(dt)
                    .Close()
                    MessageBox.Show("Test Code Sync Complete", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Try
            End With
            cn.Dispose()
            cn2.Dispose()
        End If
    End Sub

    Private Sub SINGLEIMPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SINGLEIMPORTToolStripMenuItem.Click
        frmSingleIMH.ShowDialog()
    End Sub

    Private Sub PRICELISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRICELISTToolStripMenuItem.Click

    End Sub

    Private Sub SYNCSPLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SYNCSPLISTToolStripMenuItem.Click
        frmSyncPriceList.ShowDialog()
    End Sub

    Private Sub SPECIALLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SPECIALLISTToolStripMenuItem.Click
        frmPriceUpdateSceme.ShowDialog()
    End Sub

    Private Sub PRICELISTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PRICELISTToolStripMenuItem1.Click
        frmPriceList.ShowDialog()
    End Sub

    Private Sub PRICELISTEXCEPTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRICELISTEXCEPTIONToolStripMenuItem.Click
        'frmSPExp.ShowDialog()
        frmGenExcept.ShowDialog()
    End Sub

    Private Sub GENERATESPLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GENERATESPLISTToolStripMenuItem.Click
        frmGEN_SPLIST.ShowDialog()
    End Sub

    Private Sub ITEMMASTERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITEMMASTERToolStripMenuItem.Click

    End Sub

    Private Sub ITEMMASTERToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ITEMMASTERToolStripMenuItem1.Click
        frmMD_IMH.ShowDialog()
    End Sub

    Private Sub SPLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SPLISTToolStripMenuItem.Click
        frmMD_SPLIST.ShowDialog()
    End Sub

    Private Sub INPUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INPUTToolStripMenuItem.Click

    End Sub

    Private Sub btnMIN_Click(sender As Object, e As EventArgs) Handles btnMIN.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub EXCEPTIONTESTCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCEPTIONTESTCODEToolStripMenuItem.Click
        frmSPExp.ShowDialog()
    End Sub

    Private Sub tmScan_Tick(sender As Object, e As EventArgs) Handles tmScan.Tick
        'If chkDTI() = True Then
        '    btnDTI.Visible = True
        '    If btnDTI.BackColor = Color.White Then
        '        btnDTI.BackColor = Color.Red
        '        btnDTI.ForeColor = Color.White
        '    Else
        '        btnDTI.BackColor = Color.White
        '        btnDTI.ForeColor = Color.Black
        '    End If
        'Else
        '    btnDTI.Visible = False
        '    btnDTI.BackColor = Color.White
        '    btnDTI.ForeColor = Color.Black
        'End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub BASICPRICEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BASICPRICEToolStripMenuItem.Click
        frmBasicPrice.ShowDialog()
    End Sub

    Private Sub DTIMAINTENANCEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DTIMAINTENANCEToolStripMenuItem.Click
        frmDTIList.ShowDialog()
    End Sub
#Region "ITEM MASTERH"
    Public Function GetCode(Blk As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT CODE FROM [172.30.0.17].HPCOMMON.dbo.SAPSET WHERE BLK = '" & Blk & "' "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        dt = New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item("CODE").ToString
        Else
            Return Nothing
        End If
        cn.Dispose()
    End Function
    Public Sub LoadIMH()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim strdt As String = ""
        If cbType.Text = "BATCH ID" Then
            str = "AND A.BATCH_ID = '" & Replace(txtSearch.Text, "'", "''") & "' "
        ElseIf cbType.Text = "MOTHER BRANCH" Then
            str = "AND MOTHER_BRANCH = '" & GetCode(Replace(txtSearch.Text, "'", "''")) & "' "
        ElseIf cbType.Text = "EFFECTIVE DATE" Then
            strdt =
                " HAVING MAX(CASE WHEN A.IMH_EFD_P1 > A.IMH_EFD_P2 AND A.IMH_EFD_P1 > A.IMH_EFD_P3 THEN A.IMH_EFD_P1 " & _
                "WHEN A.IMH_EFD_P2 > A.IMH_EFD_P1 AND A.IMH_EFD_P2 > A.IMH_EFD_P3 THEN A.IMH_EFD_P2 " & _
                "WHEN A.IMH_EFD_P3 > A.IMH_EFD_P2 AND A.IMH_EFD_P3 > A.IMH_EFD_P1 THEN A.IMH_EFD_P3 " & _
                "Else  A.IMH_EFD_P1 " & _
                "END) = '" & Replace(txtSearch.Text, "'", "''") & "' "
        ElseIf cbType.Text = "TEST" Then
            str = "AND A.IMH_CODE = '" & Replace(txtSearch.Text, "'", "''") & "' "
        End If
        str =
                        "SELECT DISTINCT TOP 100  A.BATCH_ID, COUNT(DISTINCT imh_code) cnt, " &
                        "				MAX(CASE WHEN A.IMH_EFD_P1 > A.IMH_EFD_P2 AND A.IMH_EFD_P1 > A.IMH_EFD_P3 THEN A.IMH_EFD_P1 " &
                        "						 WHEN A.IMH_EFD_P2 > A.IMH_EFD_P1 AND A.IMH_EFD_P2 > A.IMH_EFD_P3 THEN A.IMH_EFD_P2 " &
                        "						 WHEN A.IMH_EFD_P3 > A.IMH_EFD_P2 AND A.IMH_EFD_P3 > A.IMH_EFD_P1 THEN A.IMH_EFD_P3 " &
                        "						 ELSE A.IMH_EFD_P1 " &
                        "					END) IMH_EFD_P1, " &
                        "				COUNT(C.BATCH_ID) ERR_COUNT, " &
                        "		CASE WHEN IS_SYNC = 'Y' THEN 'DONE' " &
                        "			 WHEN IS_SYNC = 'X' THEN 'CANCELLED' " &
                        "			 WHEN IS_SYNC = 'P' THEN 'PENDING' " &
                        "			 WHEN IS_SYNC = 'N' THEN 'FOR SYNC' " &
                        "			 ELSE A.IS_SYNC " &
                        "		END STATUS " &
                        "FROM TMP_ITEM_MASTERH A WITH (NOLOCK) " &
                        "LEFT JOIN (SELECT DISTINCT BATCH_ID FROM ERR_LOGS WITH (NOLOCK)	WHERE PROCESS = 'ITEM_MASTERH' AND STAT = 'O') C ON A.BATCH_ID = C.BATCH_ID " &
                        "WHERE 1 = 1 " & str & " " &
                        "GROUP BY A.BATCH_ID, IS_SYNC " &
                        " " & strdt & " " &
                        "ORDER BY CAST(A.BATCH_ID  AS INTEGER) DESC "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            d1.Rows.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                d1.Rows.Add()
                If dt.Rows(i).Item("STATUS").ToString = "CANCELLED" Then
                    d1.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(238, 58, 89)
                    d1.Rows(i).DefaultCellStyle.ForeColor = Color.White
                ElseIf dt.Rows(i).Item("STATUS").ToString = "PENDING" Then
                    d1.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(226, 123, 71)
                    d1.Rows(i).DefaultCellStyle.ForeColor = Color.White
                ElseIf dt.Rows(i).Item("STATUS").ToString = "FOR SYNC" Then
                    d1.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(70, 178, 158)
                    d1.Rows(i).DefaultCellStyle.ForeColor = Color.White
                Else
                    d1.Rows(i).DefaultCellStyle.BackColor = Color.White
                    d1.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                If dt.Rows(i).Item("ERR_COUNT").ToString > 0 Then
                    d1("W_ERR", i).Value = "Y"
                Else
                    d1("W_ERR", i).Value = "N"
                End If
                d1("BATCH_ID", i).Value = dt.Rows(i).Item("BATCH_ID").ToString
                'd1("MOTHER_BRANCH", i).Value = dt.Rows(i).Item("Blk").ToString
                d1("EFD_DATE", i).Value = Format(CDate(dt.Rows(i).Item("IMH_EFD_P1").ToString), "MM/dd/yyyy")
                d1("ITEM_COUNT", i).Value = dt.Rows(i).Item("cnt").ToString
                d1("BATCH_STAT", i).Value = dt.Rows(i).Item("STATUS").ToString
            Next
        End If
        cn.Dispose()
    End Sub
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        LoadIMH()

    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Return Then
            btnLoad.PerformClick()
        End If
    End Sub
    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If cbType.Text = "BATCH ID" Then
            If Not IsNumeric(e.KeyChar) = True AndAlso Not e.KeyChar = ControlChars.Back Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub cbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbType.SelectedIndexChanged
        If cbType.Text = "" Or cbType.Text = "BATCH ID" Or cbType.Text = "TEST" Then
            txtSearch.Clear()
            Exit Sub
        End If

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim adapt As New SqlDataAdapter
        Dim c As New AutoCompleteStringCollection()
        If cbType.Text = "MOTHER BRANCH" Then
            str = "SELECT Blk " & _
                  "FROM [172.30.0.17].HPCOMMON.dbo.SAPSet WHERE STAT = 'O' AND HcLabIPAdd IS NOT NULL " & _
                  "ORDER BY Blk"
        ElseIf cbType.Text = "EFFECTIVE DATE" Then
            str = "SELECT DISTINCT IMH_EFD_P1 FROM TMP_ITEM_MASTERH " & _
                  "ORDER BY IMH_EFD_P1 DESC"
        End If
        adapt = New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        dt = New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            c.Clear()
            txtSearch.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                If cbType.Text = "MOTHER BRANCH" Then
                    c.Add(dt.Rows(i).Item("Blk").ToString)
                Else
                    c.Add(Format(CDate(dt.Rows(i).Item("IMH_EFD_P1").ToString), "MM/dd/yyyy"))
                End If
            Next
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSearch.AutoCompleteCustomSource = c
        End If
    End Sub
#End Region
#Region "SPLIST DTL"

    Public Sub LoadSPLIST()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""

        If cbSPSearch.Text = "BATCH ID" Then
            str = "AND A.BATCH_ID = '" & Replace(txtSPSearch.Text, "'", "''") & "' "
        ElseIf cbSPSearch.Text = "EFFECTIVE DATE" Then
            str = "AND CAST(SPD_EFD AS DATE) = '" & Replace(txtSPSearch.Text, "'", "''") & "' "
        ElseIf cbSPSearch.Text = "TEST" Then
            str = "AND A.SPD_IMH_CODE = '" & Replace(txtSPSearch.Text, "'", "''") & "' "
        End If

        str =
            "SELECT TOP 100  A.BATCH_ID, SPD_EFD, COUNT(1) cnt, " &
            "		CASE WHEN IS_SYNC = 'Y' THEN 'DONE' " &
            "			 WHEN IS_SYNC = 'X' THEN 'CANCELLED' " &
            "			 WHEN IS_SYNC = 'P' THEN 'PENDING' " &
            "			 WHEN IS_SYNC = 'N' THEN 'FOR SYNC' " &
            "			 ELSE B.IS_SYNC " &
            "		END  IS_SYNC, " &
            "		COUNT(C.BATCH_ID) ERR_COUNT " &
            "FROM SPLIST_DTL A WITH (NOLOCK) " &
            "INNER JOIN BATCH_SPLIST B WITH (NOLOCK) ON A.BATCH_ID = B.BATCH_ID " &
            "LEFT JOIN (SELECT DISTINCT BATCH_ID	FROM ERR_LOGS WITH (NOLOCK)	WHERE PROCESS = 'SPLIST_DTL' AND STAT = 'O'	) C ON A.BATCH_ID = C.BATCH_ID " &
            "WHERE 1 = 1 " & str & " " &
            "GROUP BY A.BATCH_ID, SPD_EFD, B.IS_SYNC " &
            "ORDER BY CAST(A.BATCH_ID AS INT) DESC "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        dt = New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            d2.Rows.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                d2.Rows.Add()
                If dt.Rows(i).Item("IS_SYNC").ToString = "CANCELLED" Then
                    d2.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(238, 58, 89)
                    d2.Rows(i).DefaultCellStyle.ForeColor = Color.White
                ElseIf dt.Rows(i).Item("IS_SYNC").ToString = "PENDING" Then
                    d2.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(226, 123, 71)
                    d2.Rows(i).DefaultCellStyle.ForeColor = Color.White
                ElseIf dt.Rows(i).Item("IS_SYNC").ToString = "FOR SYNC" Then
                    d2.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(70, 178, 158)
                    d2.Rows(i).DefaultCellStyle.ForeColor = Color.White
                Else
                    d2.Rows(i).DefaultCellStyle.BackColor = Color.White
                    d2.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                End If
                If dt.Rows(i).Item("ERR_COUNT").ToString = "0" Then
                    d2("SP_W_ERROR", i).Value = "N"
                Else
                    d2("SP_W_ERROR", i).Value = "Y"
                End If
                d2("SPBATCH_ID", i).Value = dt.Rows(i).Item("BATCH_ID").ToString
                d2("SPD_EFD_DATE", i).Value = Format(CDate(dt.Rows(i).Item("SPD_EFD").ToString), "MM/dd/yyyy")
                d2("SP_ITEM_COUNT", i).Value = dt.Rows(i).Item("cnt").ToString
                d2("SP_IS_SYNC", i).Value = dt.Rows(i).Item("IS_SYNC").ToString
            Next
        End If
        cn.Dispose()
    End Sub

    Private Sub cbSPSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSPSearch.SelectedIndexChanged

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim c As New AutoCompleteStringCollection()

        If cbSPSearch.Text = "EFFECTIVE DATE" Then
            str = "SELECT DISTINCT SPD_EFD " & _
                "FROM SPLIST_DTL A WITH(NOLOCK) " & _
                "ORDER BY SPD_EFD DESC"
            Dim adapt As New SqlDataAdapter(str, cn)
            Dim dt As New DataTable
            adapt.Fill(dt)

            If dt.Rows.Count > 0 Then
                c.Clear()
                For i As Integer = 0 To dt.Rows.Count - 1
                    c.Add(dt.Rows(i).Item("SPD_EFD").ToString)
                Next
            End If
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSearch.AutoCompleteCustomSource = c
        Else
            c.Clear()
            txtSPSearch.Clear()
        End If
    End Sub
    Private Sub btnSPLoad_Click(sender As Object, e As EventArgs) Handles btnSPLoad.Click
        LoadSPLIST()
        'Dim cn As New SqlConnection(cnSQL)
        'If cn.State = ConnectionState.Closed Then cn.Open()

        'Dim WHERE As String = ""

        'If cbSPSearch.Text = "BATCH ID" Then
        '    WHERE = "WHERE A.BATCH_ID = '" & Replace(txtSPSearch.Text, "'", "''") & "' "
        'ElseIf cbSPSearch.Text = "EFFECTIVE DATE" Then
        '    WHERE = "WHERE CONVERT(DATE, SPD_EFD, 101) = '" & Replace(txtSPSearch.Text, "'", "''") & "' "
        'Else
        '    LoadSPLIST()
        '    Exit Sub
        'End If

        'Dim str As String = "SELECT A.BATCH_ID, SPD_EFD, COUNT(1) cnt, " & _
        '                    "CASE WHEN B.IS_SYNC = 'Y' THEN 'DONE' " & _
        '                    "	  WHEN B.IS_SYNC = 'X' THEN 'CANCELLED' " & _
        '                    "	  ELSE 'FOR SYNC' END IS_SYNC, COUNT(C.BATCH_ID) ERR_COUNT " & _
        '                    "FROM SPLIST_DTL A WITH(NOLOCK) " & _
        '                    "INNER JOIN BATCH_SPLIST B WITH(NOLOCK) ON A.BATCH_ID = B.BATCH_ID " & _
        '                    "Left Join " & _
        '                    "	 (SELECT * " & _
        '                    "	  FROM ERR_LOGS WITH(NOLOCK) " & _
        '                    "	  WHERE PROCESS = 'SPLIST_DTL' AND STAT = 'O' " & _
        '                    "	 ) C ON A.BATCH_ID = C.BATCH_ID " & _
        '                    "" & WHERE & " " & _
        '                    "GROUP BY A.BATCH_ID, SPD_EFD, B.IS_SYNC " & _
        '                    "ORDER BY CAST(A.BATCH_ID AS INT) DESC "
        'Dim adapt As New SqlDataAdapter(str, cn)
        'Dim dt As New DataTable
        'dt = New DataTable
        'adapt.Fill(dt)

        'If dt.Rows.Count > 0 Then
        '    d2.Rows.Clear()
        '    For i As Integer = 0 To dt.Rows.Count - 1
        '        d2.Rows.Add()
        '        If dt.Rows(i).Item("IS_SYNC").ToString = "FOR SYNC" Then
        '            d2.Rows(i).DefaultCellStyle.BackColor = Color.Coral
        '        ElseIf dt.Rows(i).Item("IS_SYNC").ToString = "CANCELLED" Then
        '            d2.Rows(i).DefaultCellStyle.BackColor = Color.Red
        '        Else
        '            d2.Rows(i).DefaultCellStyle.BackColor = Color.White
        '        End If
        '        If dt.Rows(i).Item("ERR_COUNT").ToString = "0" Then
        '            d2("SP_W_ERROR", i).Value = "N"
        '        Else
        '            d2("SP_W_ERROR", i).Value = "Y"
        '        End If
        '        d2("SPBATCH_ID", i).Value = dt.Rows(i).Item("BATCH_ID").ToString
        '        d2("SPD_EFD_DATE", i).Value = Format(CDate(dt.Rows(i).Item("SPD_EFD").ToString), "MM/dd/yyyy")
        '        d2("SP_ITEM_COUNT", i).Value = dt.Rows(i).Item("cnt").ToString
        '        d2("SP_IS_SYNC", i).Value = dt.Rows(i).Item("IS_SYNC").ToString
        '    Next
        '    MessageBox.Show("Done loading", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        '    d2.Rows.Clear()
        '    MessageBox.Show("Data Not found", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Exit Sub
        'End If
        'cn.Dispose()
    End Sub

    Private Sub txtSPSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSPSearch.KeyDown
        If e.KeyCode = Keys.Return Then
            btnSPLoad.PerformClick()
        End If
    End Sub

    Private Sub txtSPSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSPSearch.KeyPress
        If cbSPSearch.Text = "BATCH ID" Then
            If Not IsNumeric(e.KeyChar) = True AndAlso Not e.KeyChar = ControlChars.Back Then
                e.Handled = True
            End If
        End If
    End Sub
#End Region

    Private Sub IMPORTBASICPRICEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPORTBASICPRICEToolStripMenuItem.Click
        frmExportBasic.ShowDialog()
    End Sub

    Private Sub d1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d1.MouseDoubleClick
        If d1.RowCount = 0 Then Exit Sub
        ProcessName = "ITEM_MASTERH"
        LoadFields(d1("BATCH_ID", d1.CurrentRow.Index).Value)
    End Sub

    Private Sub d1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d1.CellContentClick

    End Sub

    Private Sub d2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d2.CellContentClick

    End Sub

    Private Sub d2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d2.MouseDoubleClick
        If d2.RowCount = 0 Then Exit Sub
        ProcessName = "SPLIST_DTL"
        LoadFields(d2("SPBATCH_ID", d2.CurrentRow.Index).Value)
    End Sub

    Private Sub UPDATETRANSACTIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UPDATETRANSACTIONToolStripMenuItem.Click
        frmConfig_Udpate.ShowDialog()
    End Sub

    Private Sub btnDTI_Click(sender As Object, e As EventArgs) Handles btnDTI.Click
        frmDTIList.ShowDialog()
    End Sub


    Private Sub BATCHCREATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BATCHCREATIONToolStripMenuItem.Click
        frmIMH_IMPORT.ShowDialog()
    End Sub

    Private Sub EXCEPTIONTESTGROUPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EXCEPTIONTESTGROUPToolStripMenuItem.Click
        frmExpGrp.ShowDialog()
    End Sub

    Private Sub BATCHREPORTEXPORTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BATCHREPORTEXPORTToolStripMenuItem.Click
        frmSPLIST_REPORT.ShowDialog()
    End Sub

    Private Sub COPYTESTCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COPYTESTCODEToolStripMenuItem.Click
        frmCopy.ShowDialog()
    End Sub

    Private Sub COPYTESTCODENEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COPYTESTCODENEWToolStripMenuItem.Click
        frmCopyTestcode.ShowDialog()
    End Sub

    Private Sub IMPORTBASICPRICELEVELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPORTBASICPRICELEVELToolStripMenuItem.Click
        frmImprtBscPrice.Show()
    End Sub

    Private Sub ViewDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ViewDetailsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ViewDetailsToolStripMenuItem.Click
        If d2.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = d2.CurrentRow.Index
        With frmViewSplistComp
            .SPComp(d2("SPBATCH_ID", i).Value)
            .txtBatchID.text = d2("SPBATCH_ID", i).Value
            .ShowDialog()
        End With
    End Sub

    Private Sub COMPUTATIONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COMPUTATIONToolStripMenuItem.Click
        frmViewSplistComp.Show()
    End Sub

    Private Sub ViewDetailsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewDetailsToolStripMenuItem1.Click
        If d1.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = d1.CurrentRow.Index
        With frmViewIMHComp
            .IMHComp(d1("BATCH_ID", i).Value)
            .txtBatchID.Text = d1("BATCH_ID", i).Value
            .ShowDialog()
        End With
    End Sub

    Private Sub ViewSPComp_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ViewSPComp.Opening

    End Sub

    Private Sub COPYMULTIPLETESTCODEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles COPYMULTIPLETESTCODEToolStripMenuItem.Click
        frmCopyMultiTestcode.Show()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub ViewIMHComp_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ViewIMHComp.Opening

    End Sub

    Private Sub BASICPRICELEVELToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BASICPRICELEVELToolStripMenuItem.Click
        frmBasicPriceLvl.Show()

    End Sub

    Private Sub BASICPRICELEVELNEWToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BASICPRICELEVELNEWToolStripMenuItem.Click
        frmModBasicPriceLvl.Show()
    End Sub

    Private Sub SPLISTMASTERLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SPLISTMASTERLISTToolStripMenuItem.Click
        frmSPlistMasterList.Show()
    End Sub

    Private Sub BASICPRICELEVELPROFILEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BASICPRICELEVELPROFILEToolStripMenuItem.Click
        frmPriceLvlProfile.Show()
    End Sub

    Private Sub SENDINSPLISTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SENDINSPLISTToolStripMenuItem.Click
        frmSendOutSplistMaintenance.Show()
    End Sub
End Class