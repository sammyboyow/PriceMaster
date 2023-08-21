Imports System.Data.SqlClient
Imports Oracle.DataAccess.Client
Imports System.Data.Odbc
Public Class frmSyncPriceList
#Region "SUB PROCEDURE/FUNCTION"
    Public Sub LoadBranch()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT BLK FROM SAPSET WITH(NOLOCK) WHERE STAT= 'O' ORDER BY BLK "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = 0
        If dr.HasRows Then
            d.Rows.Clear()
            While dr.Read
                d.Rows.Add()
                d("Branch", i).Value = dr("Blk")
                i += 1
            End While
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Sub LloadPriceList()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT PriceList FROM Price_Level_Dtl WITH(NOLOCK) "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim c As New AutoCompleteStringCollection()
        If dr.HasRows Then
            txtSPCode.Clear()
            c.Clear()
            c.Add("")
            While dr.Read
                c.Add(dr("PriceList"))
            End While
        End If
        txtSPCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtSPCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtSPCode.AutoCompleteCustomSource = c
        dr.Close()
        cn.Dispose()
    End Sub
    Public Function CountItem(ByVal SPD_CODE As String) As String
        Dim cn As New OdbcConnection(cnStr)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT COUNT(1) CNT FROM SPLIST_DTL WHERE SPD_CODE = '" & SPD_CODE & "'"
        Dim cmd As New OdbcCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
        cmd.Dispose()
    End Function
    Public Function GetPrice(ByVal IMH_CODE As String, UnitPrice As String, LIST_PRICE As String, PRICE_LEVEL As String) As String
        Dim strsamplecon1 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = 192.171.3.103)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        Dim cnStr As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon1 & ";UID=HCLAB;PWD=HCLAB"
        Dim cn As New OdbcConnection(cnStr)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim str As String = "SELECT IMH_BILLCODE FROM ITEM_MASTERH WHERE IMH_CODE = '" & IMH_CODE & "' "
        Dim cmd As New OdbcCommand(str, cn)
        str = cmd.ExecuteScalar

        Dim TEST_GRP As String = "", NEWPRICE As String = ""
        If str = "1030" Then
            TEST_GRP = "ULTRASOUND"
        ElseIf str >= "1000" And str <= "1020" Then
            TEST_GRP = "IMAGING"
        ElseIf str >= "1040" And str <= "1100" Then
            TEST_GRP = "IMAGING"
        ElseIf str = "9000" Then
            TEST_GRP = "IMAGING"
        ElseIf str = "4500" Then
            TEST_GRP = "SPECIAL TESTS"
        Else
            TEST_GRP = "REGULAR TESTS"
        End If

        str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) WHERE PRICELEVEL = '" & PRICE_LEVEL & "' AND PriceList = '" & LIST_PRICE & "' "
        Dim cmd1 As New SqlCommand(str, cn2)
        Dim dr1 As SqlDataReader = cmd1.ExecuteReader

        If dr1.HasRows Then
            While dr1.Read
                If TEST_GRP = "ULTRASOUND" Then
                    NEWPRICE = (CDbl(UnitPrice) + (CDbl(UnitPrice) * dr1("UTZ_1")))
                    NEWPRICE = (CDbl(NEWPRICE) + (CDbl(NEWPRICE) * dr1("UTZ_2")))
                ElseIf TEST_GRP = "IMAGING" Then
                    NEWPRICE = (CDbl(UnitPrice) + (CDbl(UnitPrice) * dr1("IMAGING_1")))
                    NEWPRICE = (CDbl(NEWPRICE) + (CDbl(NEWPRICE) * dr1("IMAGING_2")))
                ElseIf TEST_GRP = "SPECIAL TESTS" Then
                    NEWPRICE = (CDbl(UnitPrice) + (CDbl(UnitPrice) * dr1("SPECIAL_1")))
                    NEWPRICE = (CDbl(NEWPRICE) + (CDbl(NEWPRICE) * dr1("SPECIAL_2")))
                Else
                    NEWPRICE = (CDbl(UnitPrice) + (CDbl(UnitPrice) * dr1("REGULAR_1")))
                    NEWPRICE = (CDbl(NEWPRICE) + (CDbl(NEWPRICE) * dr1("REGULAR_2")))
                End If
            End While
        End If
        dr1.Close()

        Return NEWPRICE
        cn.Dispose()
        cn2.Dispose()
        cmd.Dispose()
        cmd1.Dispose()
    End Function
    Public Function GetIP(ByVal Blk As String) As String
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT HcLabIPAdd  FROM SAPSET WITH(NOLOCK) WHERE BLK = '" & Blk & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            If Blk = "TEST" Then
                str = "192.171.3.103"
            End If
        End If
        Return str
        cn.Dispose()
    End Function
    Public Sub RunWorker()
        If BG1.IsBusy = True Then
            BG1.CancelAsync()
            RunWorker()
        Else
            BG1.RunWorkerAsync()
        End If
    End Sub
#End Region
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
    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        If txtSPCode.Text = "" Or txtSPDesc.Text = "" Then MessageBox.Show("Pleae Enter SPLIST details", "Price Update Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        Dim cn As New OracleConnection
        Dim cn2 As New OracleConnection
        Dim cn4 As New OracleConnection(cnORA)
        If cn4.State = ConnectionState.Closed Then cn4.Open()

        Dim cn3 As New SqlConnection(cnSQL)
        If cn3.State = ConnectionState.Closed Then cn3.Open()
        Dim cmd1 As New SqlCommand

        Dim str As String = "", UnitPrice As String = "", PriceGenerated As String = ""
        Dim TestCode As New List(Of String)
        Dim cmd As New OracleCommand

        'str = "SELECT COUNT(1) cnt FROM SPLIST_HDR WHERE SPH_CODE= '" & txtSPCode.Text & "' "
        'cmd = New OracleCommand(str, cn4)
        'str = cmd.ExecuteScalar

        'If str > 0 Then
        '    Exit Sub
        'Else
        '====================================================================================================
        '====================================================================================================
        str = "SELECT SPD_IMH_CODE FROM SPLIST_DTL WHERE SPD_CODE = '" & txtPriceLevel.Text & "' ORDER BY SPD_IMH_CODE "
        cmd = New OracleCommand(str, cn4)
        Dim dr As OracleDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            TestCode.Clear()
            While dr.Read
                TestCode.Add(dr("SPD_IMH_CODE"))
            End While
        End If
        dr.Close()
        cmd.Dispose()

        cmd1 = New SqlCommand("BEGIN TRAN", cn3)
        cmd1.ExecuteNonQuery()
        Try
            For i As Integer = 0 To TestCode.Count - 1
                'str = "SELECT SPD_CURR_PRICE FROM SPLIST_DTL WHERE SPD_CODE = '" & txtPriceLevel.Text & "' AND SPD_IMH_CODE = '" & TestCode(i) & "' "
                str = "SELECT SPD_CURR_PRICE FROM SPLIST_DTL WHERE SPD_CODE = '" & txtPriceLevel.Text & "' AND SPD_IMH_CODE = '17KET9' "
                cmd = New OracleCommand(str, cn4)
                UnitPrice = cmd.ExecuteScalar

                PriceGenerated = GetPrice(TestCode(i).ToString, UnitPrice, txtSPCode.Text, txtPriceLevel.Text)

                str = "INSERT INTO SPLIST_DTL_TMP(SPD_CODE, SPD_IMH_CODE, SPD_CURR_PRICE, SPD_EFD) VALUES ('" & txtSPCode.Text & "','" & TestCode(i) & "','" & PriceGenerated & "','" & dtEFD.Value & "')"
                cmd1 = New SqlCommand(str, cn3)
                cmd1.ExecuteNonQuery()
            Next
            cmd1 = New SqlCommand("COMMIT", cn3)
            cmd1.ExecuteNonQuery()
            cmd1.Dispose()

        Catch ex As Exception
            cmd1 = New SqlCommand("ROLLBACK", cn3)
            cmd1.ExecuteNonQuery()
            MessageBox.Show(ex.Message, "Price Update Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        '====================================================================================================
        '====================================================================================================


        For i As Integer = 0 To d.RowCount - 1
            If d("chk", i).Value = False Then GoTo ReadNext
            Try
                Dim BRANCH As String = d("Branch", i).Value
                cn = New OracleConnection("USER ID=HCLAB; password=HCLAB; data source= " & _
                        "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST=192.171.3.103)(PORT = 1521)) " & _
                        "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME =HCLAB)))")
                If cn.State = ConnectionState.Closed Then cn.Open()

                cn2 = New OracleConnection("USER ID=HCLAB; password=HCLAB; data source= " & _
                                   "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST=192.171.3.103)(PORT = 1521)) " & _
                                   "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME =HCLAB)))")
                If cn2.State = ConnectionState.Closed Then cn2.Open()

                'cn = New OracleConnection("USER ID=HCLAB; password=HCLAB; data source= " & _
                '            "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST=" & GetIP(d("Branch", i).Value) & ")(PORT = 1521)) " & _
                '            "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME =HCLAB)))")
                'If cn.State = ConnectionState.Closed Then cn.Open()

                'cn2 = New OracleConnection("USER ID=HCLAB; password=HCLAB; data source= " & _
                '                   "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST=" & GetIP(d("Branch", i).Value) & ")(PORT = 1521)) " & _
                '                   "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME =HCLAB)))")
                'If cn2.State = ConnectionState.Closed Then cn2.Open()

                str = "SELECT COUNT(1) cnt FROM SPLIST_HDR WHERE SPH_CODE= '" & txtSPCode.Text & "' "
                cmd = New OracleCommand(str, cn)
                str = cmd.ExecuteScalar

                If str > 0 Then
                    GoTo ReadNext
                Else
                    If cn3.State = ConnectionState.Closed Then cn.Open()
                    '====================================================================================================
                    '=====================INSERT RECORD TO SPLIST USING BULK COPY========================================
                    str = "SELECT SPD_CODE, SPD_IMH_CODE, SPD_CURR_PRICE, " & _
                          "(CAST(DATEPART(DAY, SPD_EFD) AS VARCHAR(20)) + '-' + DATENAME(MONTH, SPD_EFD) + " & _
                          "'-' + RIGHT(CAST(DATEPART(YY, SPD_EFD) AS VARCHAR(20)), 2))SPD_EFD " & _
                          "FROM SPLIST_DTL_TMP WITH(NOLOCK) WHERE SPD_CODE = '" & txtSPCode.Text & "' "
                    Dim da As New SqlDataAdapter(str, cn3)
                    Dim dt As New DataTable
                    da.Fill(dt)

                    'cmd1 = New SqlCommand(str, cn3)
                    'dr1 = cmd1.ExecuteReader

                    Dim blkCopy As New OracleBulkCopy(cn2)

                    With blkCopy
                        .DestinationTableName = "SPLIST_DTL_TEMP"

                        str = "ALTER TABLE SPLIST_DTL_TEMP DISABLE ALL TRIGGERS"
                        cmd = New OracleCommand(str, cn2)
                        cmd.ExecuteNonQuery()

                        str = "INSERT INTO SPLIST_HDR_TEMP (SPH_CODE, SPH_DESC) VALUES ('" & txtSPCode.Text & "','" & Replace(txtSPDesc.Text, "'", "''") & "')"
                        cmd = New OracleCommand(str, cn)
                        cmd.ExecuteNonQuery()

                        .BulkCopyTimeout = 0
                        .WriteToServer(dt)
                        .Close()

                        str = "ALTER TABLE SPLIST_DTL_TEMP ENABLE ALL TRIGGERS"
                        cmd = New OracleCommand(str, cn2)
                        cmd.ExecuteNonQuery()                     
                    End With
                    '====================================================================================================
                    '====================================================================================================
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Price Update Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
ReadNext:
            cn.Dispose()
            cn2.Dispose()
        Next
        str = "DELETE SPLIST_DTL_TMP WHERE SPD_CODE = '" & txtSPCode.Text & "' "
        cmd1 = New SqlCommand(str, cn3)
        cmd1.ExecuteNonQuery()
        'End If
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub frmSyncPriceList_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBranch()
        LloadPriceList()
        chkAll.Checked = True
        For i As Integer = 0 To d.RowCount - 1
            d("chk", i).Value = True
        Next
        btnRun.Visible = True
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked = True Then
            For i As Integer = 0 To d.Rows.Count - 1
                d("chk", i).Value = True
            Next
        Else
            For i As Integer = 0 To d.Rows.Count - 1
                d("chk", i).Value = False
            Next
        End If
    End Sub

    Private Sub txtSPCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSPCode.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT * FROM Price_Level_Dtl WHERE PriceList= '" & txtSPCode.Text & "' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    txtSPDesc.Text = dr("PriceList_Desc")
                    txtPriceLevel.Text = dr("PriceLevel")
                    txtItemCount.Text = CountItem(dr("PriceLevel"))
                End While
            Else
                txtSPCode.Text = ""
                txtSPDesc.Text = ""
                txtPriceLevel.Text = ""
                txtItemCount.Text = ""
            End If
            dr.Close()
            cn.Dispose()
        End If
    End Sub

    Private Sub txtSPCode_TextChanged(sender As Object, e As EventArgs) Handles txtSPCode.TextChanged

    End Sub

    Private Sub btnSPLIST_Click(sender As Object, e As EventArgs) Handles btnSPLIST.Click
        If MessageBox.Show("Do you want to create splist [Y/N]?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        RunWorker()
    End Sub

    Private Sub BG1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BG1.DoWork
        'Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST =192.171.11.100)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST =192.171.11.100) " & _
                               "(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)));UID=HCLAB;PWD=HCLAB"

        Dim cn As New OdbcConnection(cnStr2)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim cn3 As New SqlConnection(cnSQL)
        If cn3.State = ConnectionState.Closed Then cn3.Open()

        Dim dt As New DataTable
        dt.Columns.Add(New DataColumn("SPD_CODE", GetType(String)))
        dt.Columns.Add(New DataColumn("SPD_IMH_CODE", GetType(String)))
        dt.Columns.Add(New DataColumn("SPD_CURR_PRICE", GetType(String)))
        dt.Columns.Add(New DataColumn("SPD_EFD", GetType(String)))
        dt.Columns.Add(New DataColumn("SPD_PREV_PRICE", GetType(String)))
        dt.Columns.Add(New DataColumn("BATCH_ID", GetType(String)))


        
        Dim str As String = "SELECT A.SPD_CODE, A.SPD_IMH_CODE, B.IMH_DESC, B.IMH_BILLCODE, A.SPD_CURR_PRICE " & _
                            "FROM SPLIST_DTL A " & _
                            "INNER JOIN ITEM_MASTERH B ON A.SPD_IMH_CODE = B.IMH_CODE " & _
                            "WHERE SPD_CODE = '" & txtPriceLevel.Text & "' "
        Dim cmd As New OdbcCommand(str, cn)
        Dim dt2 As New DataTable
        dt2.Load(cmd.ExecuteReader)

        Dim TEST_GRP As String = ""
        Dim PRV_PRICE As String = ""
        Dim UNIT_PRICE As String = ""
        Dim NEW_PRICE As String = ""
        Dim EFD_DATE As String = ""
        Dim BATCH_ID As String = GetBatch()

        Try
            If dt2.Rows.Count > 0 Then
                For i As Integer = 0 To dt2.Rows.Count - 1
                    'If dt2.Rows(i).Item("SPD_IMH_CODE").ToString() = "CBCPLT" Then
                    '    MsgBox("ok")
                    'End If
                    If chkException(txtPriceLevel.Text, txtSPCode.Text, dt2.Rows(i).Item("SPD_IMH_CODE").ToString()) = False Then
                        TEST_GRP = GetTESTGRP(dt2.Rows(i).Item("IMH_BILLCODE").ToString())
                        If Except_By_TestGrp(txtPriceLevel.Text, txtSPCode.Text, dt2.Rows(i).Item("SPD_IMH_CODE").ToString(), TEST_GRP) = False Then
                            PRV_PRICE = "0.00"
                            UNIT_PRICE = dt2.Rows(i).Item("SPD_CURR_PRICE").ToString()
                            NEW_PRICE = GetPrice(dt2.Rows(i).Item("SPD_IMH_CODE").ToString, UNIT_PRICE, txtSPCode.Text, txtPriceLevel.Text, TEST_GRP)
                            EFD_DATE = dtEFD.Value
                            dt.Rows.Add(txtSPCode.Text, dt2.Rows(i).Item("SPD_IMH_CODE").ToString(), NEW_PRICE, dtEFD.Value, PRV_PRICE, BATCH_ID)
                        End If
                    Else
                        PRV_PRICE = "0.00"
                        UNIT_PRICE = dt2.Rows(i).Item("SPD_CURR_PRICE").ToString()
                        NEW_PRICE = GetExceptPrice(txtPriceLevel.Text, txtSPCode.Text, dt2.Rows(i).Item("SPD_IMH_CODE").ToString())
                        EFD_DATE = dtEFD.Value
                        dt.Rows.Add(txtSPCode.Text, dt2.Rows(i).Item("SPD_IMH_CODE").ToString(), NEW_PRICE, dtEFD.Value, PRV_PRICE, BATCH_ID)
                    End If

                Next

                Dim blkCopy As New SqlBulkCopy(cn3)

                With blkCopy
                    .DestinationTableName = "SPLIST_DTL"

                    .BulkCopyTimeout = 0
                    .ColumnMappings.Add("SPD_CODE", "SPD_CODE")
                    .ColumnMappings.Add("SPD_IMH_CODE", "SPD_IMH_CODE")
                    .ColumnMappings.Add("SPD_CURR_PRICE", "SPD_CURR_PRICE")
                    .ColumnMappings.Add("SPD_EFD", "SPD_EFD")
                    .ColumnMappings.Add("SPD_PREV_PRICE", "SPD_PREV_PRICE")
                    .ColumnMappings.Add("BATCH_ID", "BATCH_ID")
                    .WriteToServer(dt)
                    .Close()
                End With

                str = "INSERT INTO BATCH_SPLIST VALUES ('" & BATCH_ID & "','" & dtEFD.Value & "','N')"
                Dim cmd2 = New SqlCommand(str, cn2)
                cmd2.ExecuteNonQuery()
                MsgBox("Done generating SPLIST")
            Else
                MsgBox("No SPLIST found!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try    
    End Sub
    Public Function Except_By_TestGrp(ByVal Price_Level As String, PriceList As String, IMH_CODE As String, TestGrp As String) As Boolean
        Dim RetValue As Boolean = False

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        str = "SELECT TOP 1 1 FROM EXCEPT_BY_TESTGRP WITH(NOLOCK) WHERE PRICE_LEVEL = '" & Price_Level & "' AND PRICE_LIST = '" & PriceList & "' AND TEST_GRP ='" & TestGrp & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            RetValue = False
        Else
            RetValue = True
        End If

        cmd.Dispose()
        cn.Dispose()
        Return RetValue
    End Function
    Public Function GetBatch() As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT MAX(CAST(BATCH_ID AS INT)) + 1 FROM BATCH_SPLIST WITH(NOLOCK)"
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
    End Function

    Public Function GetPrice(ByVal IMH_CODE As String, UnitPrice As String, LIST_PRICE As String, PRICE_LEVEL As String, TEST_GRP As String) As String
        'Dim strsamplecon1 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = 192.171.3.103)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        'Dim cnStr As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon1 & ";UID=HCLAB;PWD=HCLAB"
        Dim cn As New OdbcConnection(cnStr)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()
        Dim cmd1 As New SqlCommand

        Dim IMH_BILLCODE As String = ""
        Dim cmd As New OdbcCommand
        Dim str As String = ""

        Dim NEWPRICE As String = ""

        Try
            str = "SELECT PRICE FROM SPLIST_Except WITH(NOLOCK) WHERE Price_List = '" & LIST_PRICE & "' and IMH_CODE = '" & IMH_CODE & "' AND Price_Level = '" & PRICE_LEVEL & "'"
            cmd1 = New SqlCommand(str, cn2)
            str = cmd1.ExecuteScalar

            If str Is Nothing Then
                str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) WHERE PRICELEVEL = '" & PRICE_LEVEL & "' AND PriceList = '" & LIST_PRICE & "' "
                cmd1 = New SqlCommand(str, cn2)
                Dim dr1 As SqlDataReader = cmd1.ExecuteReader

                If dr1.HasRows Then
                    While dr1.Read
                        If TEST_GRP = "ULTRASOUND" Then
                            NEWPRICE = (CDbl(UnitPrice) + (CDbl(UnitPrice) * dr1("UTZ_1")))
                            NEWPRICE = (CDbl(NEWPRICE) + (CDbl(NEWPRICE) * dr1("UTZ_2")))
                        ElseIf TEST_GRP = "IMAGING" Then
                            NEWPRICE = (CDbl(UnitPrice) + (CDbl(UnitPrice) * dr1("IMAGING_1")))
                            NEWPRICE = (CDbl(NEWPRICE) + (CDbl(NEWPRICE) * dr1("IMAGING_2")))
                        ElseIf TEST_GRP = "SPECIAL TESTS" Then
                            NEWPRICE = (CDbl(UnitPrice) + (CDbl(UnitPrice) * dr1("SPECIAL_1")))
                            NEWPRICE = (CDbl(NEWPRICE) + (CDbl(NEWPRICE) * dr1("SPECIAL_2")))
                        Else
                            NEWPRICE = (CDbl(UnitPrice) + (CDbl(UnitPrice) * dr1("REGULAR_1")))
                            NEWPRICE = (CDbl(NEWPRICE) + (CDbl(NEWPRICE) * dr1("REGULAR_2")))
                        End If
                    End While
                End If
                dr1.Close()
            Else
                NEWPRICE = str
            End If
        Catch ex As Exception
            NEWPRICE = "0.00"
        End Try

        Return NEWPRICE
        cn.Dispose()
        cn2.Dispose()
        cmd.Dispose()
        cmd1.Dispose()
    End Function
    Public Function GetTESTGRP(IMH_CODE As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", RetValue As String = ""
        Dim cmd As New SqlCommand

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_GetTestGrp"
            .Parameters.AddWithValue("@IMH_BillCode", IMH_CODE)
            RetValue = .ExecuteScalar
        End With
        cmd.Dispose()
        cn.Dispose()

        Return RetValue
    End Function
    Public Function chkException(PriceLevel As String, PriceList As String, IMH_CODE As String) As Boolean
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT TOP 1 1 FROM SPLIST_Except WITH(NOLOCK) " & _
                            "WHERE Price_Level = '" & PriceLevel & "' AND PricE_List = '" & PriceList & "' AND IMH_CODE = '" & IMH_CODE & "' "
        Dim RetValue As Boolean = False

        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            RetValue = False
        Else
            RetValue = True
        End If
        Return RetValue
        cn.Dispose()
    End Function
    Public Function GetExceptPrice(ByVal Price_Level As String, ByVal Price_List As String, ByVal IMH_CODE As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT Price FROM SPLIST_Except WITH(NOLOCK) WHERE Price_Level = '" & Price_Level & "' AND PRICE_LIST = '" & Price_List & "' AND IMH_CODE = '" & IMH_CODE & "' "
        Dim cmd As New SqlCommand(str, cn)
        Str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
End Class