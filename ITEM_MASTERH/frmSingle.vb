Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports Oracle.DataAccess.Client
Imports Microsoft.Office.Interop
Public Class frmSingle
#Region "MoveForm"
    Dim isActive As Boolean = False
    Dim MoveForm As Boolean
    Dim MoveForm_MousePosition As Point
    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region
#Region "SUB PROCEDURE / FUNCTION"
    Public Sub LoadBranch()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT B.Blk " & _
                            "FROM " & _
                            "   (SELECT DISTINCT Company, MotherWhs " & _
                            "    FROM BscPriceLvl_Master WITH(NOLOCK) " & _
                            "   ) A " & _
                            "INNER JOIN SAPSET B WITH(NOLOCK) ON A.MotherWhs = B.Code " & _
                            "ORDER BY B.Blk"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            cbBranch.Items.Clear()
            cbBranch.Items.Add("")
            cbBranch.Items.Add("TEST")
            While dr.Read
                cbBranch.Items.Add(dr("Blk"))
            End While
        Else
            cbBranch.Items.Clear()
        End If
        dr.Close()
        cn.Dispose()

    End Sub
    Public Function GetBillCode(IMH_CODE As String) As String
        Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST =192.171.11.100)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        'Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = 192.171.11.100)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon2 & ";UID=HCLAB;PWD=HCLAB"
        Dim cn As New OdbcConnection(cnStr2)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT IMH_BILLCODE FROM ITEM_MASTERH WHERE IMH_CODE = '" & IMH_CODE & "' "
        Dim cmd As New OdbcCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
    End Function
    Public Sub LoadTestCodes(ByVal BranchCode As String)
        If cbBranch.Text = "" Then txtTestCode.Clear() : Exit Sub
        If cbBranch.Text = "TEST" Then
            BranchCode = "011"
        End If
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT ISNULL(IMH_CODE, '') IMH_CODE, ISNULL(IMH_DESC, '') IMH_DESC " & _
                            "FROM ITEM_MASTERH WITH(NOLOCK) " & _
                            "WHERE IMH_TYPE = 'S' " & _
                            "ORDER BY IMH_CODE "
        Dim cmd As New SqlCommand(str, cn)
        Dim DT As New DataTable
        DT.Load(cmd.ExecuteReader)

        Dim c As New AutoCompleteStringCollection()
        If DT.Rows.Count > 0 Then
            c.Clear()
            For i As Integer = 0 To DT.Rows.Count - 1
                c.Add(DT.Rows(i).Item("IMH_CODE").ToString)
                c.Add(DT.Rows(i).Item("IMH_DESC").ToString)
            Next
        End If
        'Dim dr As SqlDataReader = cmd.ExecuteReader

        'Dim c As New AutoCompleteStringCollection()
        'If dr.HasRows Then
        '    c.Clear()
        '    While dr.Read
        '        c.Add(dr("IMH_CODE"))
        '        c.Add(dr("IMH_DESC"))
        '    End While
        'Else
        '    c.Clear()
        'End If
        'dr.Close()
        txtTestCode.Clear()
        txtTestCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtTestCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTestCode.AutoCompleteCustomSource = c
        cn.Dispose()
    End Sub
    Public Function GetODBC(ByVal Branch As String) As String
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT HcLabIPAdd FROM SAPSet WITH(NOLOCK) WHERE BLK = '" & Branch & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If cbBranch.Text = "TEST" Then
            Return "192.171.3.103"
        Else
            Return str
        End If

        cn.Dispose()
    End Function
#End Region
    Public vBATCH_ID As String = ""
    Private Sub frmSingle_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBranch()
        lblDate.Text = Format(Now, "MM/dd/yyyy")
    End Sub

    Private Sub cbBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBranch.SelectedIndexChanged
        LoadTestCodes(GetCode(cbBranch.Text))
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub txtTestCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTestCode.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT ISNULL(IMH_CODE, '') IMH_CODE, ISNULL(IMH_DESC, '') IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK) " & _
                                "WHERE IMH_CODE = '" & Replace(txtTestCode.Text, "'", "''") & "' " & _
                                "OR IMH_DESC ='" & Replace(txtTestCode.Text, "'", "''") & "' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    txtTestCode.Text = dr("IMH_CODE")
                    txtTestName.Text = dr("IMH_DESC")
                End While
            Else
                MessageBox.Show("Test Code not found", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtTestCode.Text = ""
                txtTestName.Text = ""
            End If
            dr.Close()
            cn.Dispose()
        End If
    End Sub

    Private Sub txtTestCode_TextChanged(sender As Object, e As EventArgs) Handles txtTestCode.TextChanged
        If txtTestCode.Text = "" Then
            txtTestName.Text = ""
        End If
    End Sub

    Private Sub btnClose2_Click(sender As Object, e As EventArgs) Handles btnClose2.Click
        Me.Dispose()
    End Sub

    Private Sub chkList_CheckedChanged(sender As Object, e As EventArgs) Handles chkList.CheckedChanged
        If chkList.Checked = True Then
            txtListPrice.Enabled = True
        Else
            txtListPrice.Enabled = False
        End If
    End Sub
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'If txtTestCode.Text = "" Or cbBranch.Text = "" Then MessageBox.Show("Please Complete Details before adding Test Code", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        'If chkP1.Checked = False And chkP2.Checked = False And chkP3.Checked = False Then MessageBox.Show("Please choose Price Level", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        'Dim ListPrice As Double = 0.0

        For i As Integer = 0 To d.Rows.Count - 1
            If d("Imhcode", i).Value = txtTestCode.Text Then
                MessageBox.Show("Test Code Already Exists", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
        Next

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = " & GetODBC(cbBranch.Text) & ")(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon2 & ";UID=HCLAB;PWD=HCLAB"


        Dim cn3 As New OdbcConnection(cnStr2)
        If cn3.State = ConnectionState.Closed Then cn3.Open()

        Dim str As String = "", Price_Level1 As String = "", Price_Level2 As String = "", Price_Level3 As String = "", ListPrice As String = "", TI_ORDER_ENABLE As String = ""
        Dim Old_Price1 As String = "", Old_Price2 As String = "", Old_Price3 As String = "", old_ListPrice As String = "", IMH_BILLCODE As String = ""
        Dim Price_Level As New List(Of String)
        Dim BILLCODE As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        Dim TEST_CODE As String = Trim(txtTestCode.Text)

        str = "SELECT NVL(TI_ORDER_ENABLE, 'N') TI_ORDER_ENABLE  FROM TEST_ITEM WHERE TI_CODE = '" & TEST_CODE & "'"
        Dim cmd2 As New OdbcCommand(str, cn3)
        TI_ORDER_ENABLE = cmd2.ExecuteScalar

        If TI_ORDER_ENABLE = "N" Then
            If MessageBox.Show("Test code is not order item" & vbNewLine & "Do you want to proceed [Y/N]?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If


        str = "SELECT TOP 1 1 FROM SPLIST_DTI WHERE IMH_CODE = '" & txtTestCode.Text & "' AND BRANCH_CODE = '" & GetCode(cbBranch.Text) & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            str = "SELECT TOP 1 * FROM Price_Level_Hdr WITH(NOLOCK) WHERE MOTHER_CODE ='" & GetCode(cbBranch.Text) & "' AND PriceType = 'N' "
            cmd = New SqlCommand(str, cn)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                Price_Level.Clear()
                While dr.Read
                    Price_Level.Add(dr("Price_Level1"))
                    Price_Level.Add(dr("Price_Level2"))
                    Price_Level.Add(dr("Price_Level3"))
                End While
            Else
                MessageBox.Show("Please Create Bsic Price", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            dr.Close()

            For i As Integer = 0 To Price_Level.Count - 1
                str = "SELECT Price FROM BASIC_PRICE_LVL WHERE PRICE_LEVEL = '" & Price_Level(i) & "' AND RTRIM(IMH_CODE) = '" & TEST_CODE & "' "
                cmd = New SqlCommand(str, cn)
                dr = cmd.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    If i = 0 Then
                        Price_Level1 = dr("Price")
                    ElseIf i = 1 Then
                        Price_Level2 = dr("Price")
                    ElseIf i = 2 Then
                        Price_Level3 = dr("Price")
                    End If
                Else
                    If i = 0 Then
                        Price_Level1 = "0.00"
                    ElseIf i = 1 Then
                        Price_Level2 = "0.00"
                    ElseIf i = 2 Then
                        Price_Level3 = "0.00"
                    End If
                End If
                dr.Close()
            Next

            BILLCODE = GetBillCode(txtTestCode.Text)
            str = "SELECT NVL(IMH_CODE, ' ') IMH_CODE, NVL(IMH_DESC, ' ') IMH_DESC, NVL(IMH_BILLCODE, '') IMH_BILLCODE, " & _
                "NVL(IMH_CURR_P1, 0.00)IMH_CURR_P1, NVL(IMH_CURR_P2, 0.00) IMH_CURR_P2, NVL(IMH_CURR_P3, 0.00) IMH_CURR_P3, NVL(IMH_YTD_SAMT, 0.00) IMH_YTD_SAMT " & _
                "FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(TEST_CODE, "'", "''") & "' AND IMH_REC_FLAG = 'N' "
            Dim adapt As New OdbcDataAdapter(str, cn3)
            Dim dt As New DataTable
            dt = New DataTable
            adapt.Fill(dt)
            'Dim cmd1 As New OdbcCommand(str, cn3)
            'Dim dr1 As OdbcDataReader = cmd1.ExecuteReader

            If dt.Rows.Count > 0 Then
                'While dr1.Read
                If txtListPrice.Text = "" Then
                    ListPrice = CDbl(Price_Level1)
                Else
                    ListPrice = Format(CDbl(txtListPrice.Text), "N2")
                End If

                If dt.Rows(0).Item("IMH_YTD_SAMT").ToString = 0 Then
                    old_ListPrice = ListPrice
                Else
                    old_ListPrice = dt.Rows(0).Item("IMH_YTD_SAMT").ToString
                End If

                If dt.Rows(0).Item("IMH_CURR_P1").ToString = "0" Then
                    Old_Price1 = Price_Level1
                Else
                    Old_Price1 = dt.Rows(0).Item("IMH_CURR_P1").ToString
                End If
                If dt.Rows(0).Item("IMH_CURR_P2").ToString = "0" Then
                    Old_Price2 = Price_Level2
                Else
                    Old_Price2 = dt.Rows(0).Item("IMH_CURR_P2").ToString
                End If
                If dt.Rows(0).Item("IMH_CURR_P3").ToString = "0" Then
                    Old_Price3 = Price_Level3
                Else
                    Old_Price3 = dt.Rows(0).Item("IMH_CURR_P3").ToString
                End If
                'dt.Rows(0).Item("IMH_BILLCODE").ToString()
                d.Rows.Add(TEST_CODE, txtTestName.Text, BILLCODE, Format(CDbl(old_ListPrice), "N2"), CInt(ListPrice), CInt(Old_Price1), _
                           Price_Level1, CInt(Old_Price2), Price_Level2, CInt(Old_Price3), Price_Level3)
                'End While
                If TI_ORDER_ENABLE = "N" Then
                    d.Rows(d.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
                End If
            Else
                MessageBox.Show("Test Code Not Found or Disabled", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If
            dr.Close()
        Else
            str = "SELECT IMH_BILLCODE, IMH_YTD_SAMT, IMH_CURR_P1, IMH_CURR_P2, IMH_CURR_P3  FROM ITEM_MASTERH WHERE IMH_CODE = '" & TEST_CODE & "' "
            Dim da As New OdbcDataAdapter(str, cn3)
            Dim dt2 As New DataTable
            da.Fill(dt2)

            If dt2.Rows(0).Item("IMH_YTD_SAMT").ToString = 0 Then
                old_ListPrice = CDbl(IIf(ListPrice = "", 0, ListPrice))
            Else
                old_ListPrice = dt2.Rows(0).Item("IMH_YTD_SAMT").ToString
            End If
            If dt2.Rows(0).Item("IMH_CURR_P1").ToString = "0" Then
                Old_Price1 = Price_Level1
            Else
                Old_Price1 = dt2.Rows(0).Item("IMH_CURR_P1").ToString
            End If
            If dt2.Rows(0).Item("IMH_CURR_P2").ToString = "0" Then
                Old_Price2 = Price_Level2
            Else
                Old_Price2 = dt2.Rows(0).Item("IMH_CURR_P2").ToString
            End If
            If dt2.Rows(0).Item("IMH_CURR_P3").ToString = "0" Then
                Old_Price3 = Price_Level3
            Else
                Old_Price3 = dt2.Rows(0).Item("IMH_CURR_P3").ToString
            End If
            If txtListPrice.Text = "" Then
                ListPrice = CDbl(IIf(Price_Level1 = "", 0, Price_Level1))
            Else
                ListPrice = Format(CDbl(txtListPrice.Text), "N2")
            End If
            
            str = "SELECT DISTINCT PRICE " & _
                "FROM SPLIST_DTI A WITH(NOLOCK) " & _
                "INNER JOIN ITEM_MASTERH B WITH(NOLOCK) ON A.IMH_CODE = B.IMH_CODE " & _
                "WHERE A.IMH_CODE = '" & txtTestCode.Text & "' AND A.BRANCH_CODE = '" & GetCode(cbBranch.Text) & "' "
            Dim adapt As New SqlDataAdapter(str, cn)
            Dim dt As New DataTable
            adapt.Fill(dt)

            If old_ListPrice = "" Then
                old_ListPrice = dt.Rows(0).Item("PRICE").ToString            
            End If
            If ListPrice = "" Then
                ListPrice = dt.Rows(0).Item("PRICE").ToString
            End If

            If dt.Rows.Count > 0 Then
                d.Rows.Add(txtTestCode.Text, txtTestName.Text, dt2.Rows(0).Item("IMH_BILLCODE").ToString, Format(CDbl(old_ListPrice), "N2"), CInt(ListPrice), CInt(Old_Price1), _
                           dt.Rows(0).Item("PRICE").ToString, CInt(Old_Price2), dt.Rows(0).Item("PRICE").ToString, CInt(Old_Price3), dt.Rows(0).Item("PRICE").ToString)
            End If
            If TI_ORDER_ENABLE = "N" Then
                d.Rows(d.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Red
            End If
        End If
        cn.Dispose()
        cn3.Dispose()
    End Sub
    Private Sub d_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles d.CellEndEdit
        If chkP1.Checked = True Then
            d("NewLPrice", d.CurrentRow.Index).Value = d("NEW_PRICE1", d.CurrentRow.Index).Value
        End If
    End Sub

    Private Sub d_KeyDown(sender As Object, e As KeyEventArgs) Handles d.KeyDown
        If e.KeyCode = Keys.Delete Then
            If d.Rows.Count = 0 Then Exit Sub
            If MessageBox.Show("Do you want to remove Rows?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                d.Rows.RemoveAt(d.CurrentRow.Index)
                If d.Rows.Count = 0 Then
                    chkP1.Enabled = True
                    chkP2.Enabled = True
                    chkP3.Enabled = True
                    cbBranch.Enabled = True
                End If                
            End If
        End If
    End Sub

    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If d.Rows.Count = 0 Then MessageBox.Show("Please Generate details to post", "Priec Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If cbBranch.Text = "" Then MessageBox.Show("Please Select Monther Branch", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If DateDiff(DateInterval.Day, Now, dtEffect.Value) < 0 Then MessageBox.Show("Effectivity date must be less than or equal current date", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub

        If MessageBox.Show("Do you want to post transaction?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cmd As New SqlCommand

        Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = " & GetODBC(cbBranch.Text) & ")(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon1 & ";UID=HCLAB;PWD=HCLAB"

        Dim cn2 As New OdbcConnection(cnStr2)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim cmd1 As New OdbcCommand


        Dim str As String = "", BATCH_ID As String = ""
        
        str = "SELECT MAX(BATCH_ID) + 1 FROM TMP_ITEM_MASTERH WITH(NOLOCK) "
        cmd = New SqlCommand(str, cn)
        BATCH_ID = cmd.ExecuteScalar

        Try
            cmd = New SqlCommand("BEGIN TRAN", cn)
            cmd.ExecuteNonQuery()

            For i As Integer = 0 To d.RowCount - 1
                str = "SELECT IMH_TYPE, IMH_PDGROUP, IMH_BILLCODE, IMH_STKITEM_FLAG, IMH_TAXABLE, IMH_YTD_SQTY, IMH_YTD_SAMT, " & _
                    "IMH_STD_COST, IMH_FIXED_PRICE, IMH_REC_FLAG, IMH_UPDATE_BY, IMH_UPDATE_ON " & _
                    "FROM ITEM_MASTERH WHERE IMH_CODE = '" & d("Imhcode", i).Value & "' "
                cmd1 = New OdbcCommand(str, cn2)
                Dim dr As OdbcDataReader = cmd1.ExecuteReader

                If dr.HasRows Then
                    dr.Read()
                    str = "INSERT INTO TMP_ITEM_MASTERH (MOTHER_BRANCH, IMH_CODE, IMH_DESC, IMH_TYPE, IMH_PDGROUP, IMH_BILLCODE, IMH_STKITEM_FLAG, IMH_TAXABLE, IMH_YTD_SQTY, IMH_YTD_SAMT, IMH_STD_COST, " & _
                    "IMH_CURR_P1, IMH_EFD_P1, IMH_PREV_P1, IMH_CURR_P2, IMH_EFD_P2, IMH_PREV_P2, IMH_CURR_P3, IMH_EFD_P3, IMH_PREV_P3, IMH_FIXED_PRICE, IMH_REC_FLAG, IMH_UPDATE_BY, IMH_UPDATE_ON, IS_SYNC, BATCH_ID)" & _
                    "VALUES ('" & GetCode(cbBranch.Text) & "','" & Replace(d("Imhcode", i).Value, "'", "''") & "','" & Replace(d("ImhDesc", i).Value, "'", "''") & "','" & Replace(dr("IMH_TYPE"), "'", "''") & "', " & _
                    "'" & Replace(dr("IMH_PDGROUP"), "'", "''") & "','" & Replace(dr("IMH_BILLCODE"), "'", "''") & "','" & Replace(dr("IMH_STKITEM_FLAG"), "'", "''") & "','" & Replace(dr("IMH_TAXABLE"), "'", "''") & "', " & _
                    "'" & Replace(dr("IMH_YTD_SQTY"), "'", "''") & "'," & Replace(CInt(d("NewLPrice", i).Value), "'", "''") & ",'" & Replace(dr("IMH_STD_COST"), "'", "''") & "'," & Replace(d("NEW_PRICE1", i).Value, "'", "''") & ", " & _
                    "'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "'," & Replace(CInt(d("IMH_CURR1", i).Value), ",", "") & "," & Replace(d("NEW_PRICE2", i).Value, "'", "''") & ",'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "', " & _
                    "" & Replace(CInt(d("IMH_CURR2", i).Value), "'", "''") & "," & Replace(d("NEW_PRICE3", i).Value, "'", "''") & ",'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "'," & Replace(CInt(d("IMH_CURR3", i).Value), "'", "''") & ", " & _
                    "'" & Replace(dr("IMH_FIXED_PRICE"), "'", "''") & "','" & Replace(dr("IMH_REC_FLAG"), "'", "''") & "','KISSEL',GETDATE(),'N', '" & BATCH_ID & "')"
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()
                End If
                dr.Close()
            Next
            cmd = New SqlCommand("COMMIT", cn)
            cmd.ExecuteNonQuery()
            btnClear.PerformClick()
            MessageBox.Show("Done posting schedule", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

        cn.Dispose()
        cn2.Dispose()
        cmd.Dispose()
        cmd1.Dispose()
    End Sub

    Private Sub txtTestName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTestName.KeyDown
        If e.KeyCode = Keys.Return Then
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cbBranch.SelectedIndex = -1
        cbBranch.Enabled = True
        dtEffect.Value = Now
        chkP1.Checked = False
        chkP2.Checked = False
        chkP3.Checked = False
        chkP1.Enabled = True
        chkP2.Enabled = True
        chkP3.Enabled = True
        txtTestCode.Clear()
        txtTestName.Text = ""
        txtListPrice.Text = ""
        txtListPrice.Enabled = False
        chkList.Checked = False
        d.Rows.Clear()
        d.ReadOnly = False
    End Sub

    'Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

    '    Dim Savefile As New SaveFileDialog

    '    Dim xlApp As New Excel.Application
    '    Dim xlWB As Excel.Workbook
    '    Dim xlWS As Excel.Worksheet
    '    Dim misValue As Object = System.Reflection.Missing.Value
    '    Dim path As String = "D:\Excel Files"
    '    Dim Row As Integer = 0
    '    'Dim startInfo As ProcessStartInfo

    '    xlWB = xlApp.Workbooks.Add(misValue)
    '    xlWS = xlWB.Sheets("sheet1")

    '    'CHECK IF PATH EXIST
    '    If (Not System.IO.Directory.Exists(path)) Then
    '        'CREATE PATH 
    '        System.IO.Directory.CreateDirectory(path)
    '    End If
    '    Savefile.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
    '    Savefile.InitialDirectory = path

    '    If Savefile.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        xlWS.Cells(2, 1) = "MOTHER BRANCH:"
    '        xlWS.Cells(2, 2) = cbBranch.Text


    '    End If
    'End Sub
    'Private Sub releaseObject(ByVal obj As Object)
    '    Try
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
    '        obj = Nothing
    '    Catch ex As Exception
    '        obj = Nothing
    '    Finally
    '        GC.Collect()
    '    End Try
    'End Sub

    Private Sub d_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d.CellContentClick

    End Sub

    Private Sub d_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d.MouseDoubleClick
        If d.CurrentCell.ColumnIndex = 0 Then
            If d.Rows.Count = 0 Then Exit Sub
            frmSPPrv.SELECTED = GetPriceLvl(cbBranch.Text, chkP1.CheckState, chkP2.CheckState, chkP3.CheckState)
            Dim IMH_CODE2 As String = d("Imhcode", d.CurrentRow.Index).Value
            frmSPPrv.SPD_IMH_CODE = IMH_CODE2
            frmSPPrv.MotherBranch = GetCode(cbBranch.Text)
            frmSPPrv.ListPrice = d("NewLPrice", d.CurrentRow.Index).Value
            frmSPPrv.ShowDialog()
        End If
    End Sub

    Private Sub btnBatch_Click(sender As Object, e As EventArgs) Handles btnBatch.Click
        If cbBranch.Text = "" Then
            vBranch = ""
        Else
            vBranch = cbBranch.Text
        End If
        BATCH_LIST.ShowDialog()

    End Sub
End Class