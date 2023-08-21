Imports System.Data.SqlClient
Imports System.Data.Odbc
Public Class BATCH_LIST
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
    Public Sub LoadBatch()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT BATCH_ID, DATE_GENERATED, COUNT(1) CNT " & _
                            "FROM (SELECT BATCH_ID, BATCH_IMH_CODE, CAST(DATE_GENERATED AS DATE) DATE_GENERATED " & _
                            "        FROM BATCH_IMH_IMPORT " & _
                            "	  ) A " & _
                            "GROUP BY BATCH_ID, DATE_GENERATED " & _
                            "ORDER BY BATCH_ID DESC"
        Dim cmd As New SqlCommand(str, cn)
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        cmd.Dispose()

        If dt.Rows.Count > 0 Then
            d.Rows.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                d.Rows.Add()
                d(0, i).Value = dt.Rows(i).Item("BATCH_ID").ToString
                d(1, i).Value = dt.Rows(i).Item("CNT").ToString
                d(2, i).Value = Format(CDate(dt.Rows(i).Item("DATE_GENERATED").ToString), "MM-dd-yyyy")
            Next
        Else
            d.Rows.Clear()
        End If
    End Sub
    Public Function GetODBC(ByVal Branch As String) As String
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT HcLabIPAdd FROM SAPSet WITH(NOLOCK) WHERE BLK = '" & Branch & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If frmSingle.cbBranch.Text = "TEST" Then
            Return "192.171.3.103"
        Else
            Return str
        End If

        cn.Dispose()
    End Function
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
    Public Sub runWorker()
        If bg1.IsBusy = True Then
            bg1.CancelAsync()
        Else
            bg1.RunWorkerAsync()
        End If
    End Sub
#End Region

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub


    Private Sub BATCH_LIST_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False
        LoadBatch()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If vBranch <> "" Then

            frmSingle.d.Rows.Clear()

            Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = " & GetODBC(vBranch) & ")(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
            Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon2 & ";UID=HCLAB;PWD=HCLAB"

            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim cn3 As New OdbcConnection(cnStr2)
            If cn3.State = ConnectionState.Closed Then cn3.Open()

            Dim str As String = "", Price_Level1 As String = "", Price_Level2 As String = "", Price_Level3 As String = "", ListPrice As String = ""
            Dim Old_Price1 As String = "", Old_Price2 As String = "", Old_Price3 As String = "", old_ListPrice As String = "", IMH_BILLCODE As String = ""
            Dim Price_Level As New List(Of String)
            Dim BILLCODE As String = ""
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader
            Dim dt2 As New DataTable

            str = "SELECT BATCH_IMH_CODE FROM BATCH_IMH_IMPORT WITH(NOLOCK) WHERE BATCH_ID = '" & d(0, d.CurrentRow.Index).Value & "' "
            cmd = New SqlCommand(str, cn)
            dt2 = New DataTable
            dt2.Load(cmd.ExecuteReader)
            cmd.Dispose()


            For ii As Integer = 0 To dt2.Rows.Count - 1
                Dim TEST_CODE As String = Trim(dt2.Rows(ii).Item(0).ToString)

                str = "SELECT TOP 1 * FROM Price_Level_Hdr WITH(NOLOCK) WHERE MOTHER_CODE ='" & GetCode(vBranch) & "' AND PriceType = 'N' "
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

                BILLCODE = GetBillCode(TEST_CODE)

                str = "SELECT NVL(IMH_CODE, ' ') IMH_CODE, NVL(IMH_DESC, ' ') IMH_DESC, NVL(IMH_BILLCODE, '') IMH_BILLCODE, " & _
                    "NVL(IMH_CURR_P1, 0.00)IMH_CURR_P1, NVL(IMH_CURR_P2, 0.00) IMH_CURR_P2, NVL(IMH_CURR_P3, 0.00) IMH_CURR_P3, NVL(IMH_YTD_SAMT, 0.00) IMH_YTD_SAMT " & _
                    "FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(TEST_CODE, "'", "''") & "' "
                Dim adapt As New OdbcDataAdapter(str, cn3)
                Dim dt As New DataTable
                dt = New DataTable
                adapt.Fill(dt)
                'Dim cmd1 As New OdbcCommand(str, cn3)
                'Dim dr1 As OdbcDataReader = cmd1.ExecuteReader

                If dt.Rows.Count > 0 Then
                    'While dr1.Read

                    ListPrice = CDbl(Price_Level1)
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
                    frmSingle.d.Rows.Add(TEST_CODE, dt.Rows(0).Item("IMH_DESC").ToString, BILLCODE, Format(CDbl(old_ListPrice), "N2"), CInt(ListPrice), CInt(Old_Price1), _
                               Price_Level1, CInt(Old_Price2), Price_Level2, CInt(Old_Price3), Price_Level3)
                    'End While

                Else
                    MessageBox.Show("Test Code Not Found -- " & TEST_CODE, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    frmSingle.d.Rows.Add(TEST_CODE, "NOT FOUND", BILLCODE, Format(CDbl(0), "N2"), CInt(0), CInt(0), _
                              Price_Level1, CInt(0), Price_Level2, CInt(0), 0)
                    frmSingle.d.Rows(ii).DefaultCellStyle.BackColor = Color.Red
                    'Exit Sub
                End If
                dr.Close()
            Next
            frmSingle.lblTestCount.Text = "TEST CODE COUNT: " & frmSingle.d.Rows.Count
        Else
            MessageBox.Show("Please select mother branch before importing test code", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Me.Dispose()

        'runWorker()      
    End Sub

    Private Sub bg1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bg1.DoWork
        'If vBranch <> "" Then

        '    Panel3.Visible = True

        '    frmSingle.d.Rows.Clear()

        '    Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = " & GetODBC(vBranch) & ")(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        '    Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon2 & ";UID=HCLAB;PWD=HCLAB"

        '    Dim cn As New SqlConnection(cnSQL)
        '    If cn.State = ConnectionState.Closed Then cn.Open()

        '    Dim cn3 As New OdbcConnection(cnStr2)
        '    If cn3.State = ConnectionState.Closed Then cn3.Open()

        '    Dim str As String = "", Price_Level1 As String = "", Price_Level2 As String = "", Price_Level3 As String = "", ListPrice As String = ""
        '    Dim Old_Price1 As String = "", Old_Price2 As String = "", Old_Price3 As String = "", old_ListPrice As String = "", IMH_BILLCODE As String = ""
        '    Dim Price_Level As New List(Of String)
        '    Dim BILLCODE As String = ""
        '    Dim cmd As New SqlCommand
        '    Dim dr As SqlDataReader
        '    Dim dt2 As New DataTable

        '    str = "SELECT BATCH_IMH_CODE FROM BATCH_IMH_IMPORT WITH(NOLOCK) WHERE BATCH_ID = '" & d(0, d.CurrentRow.Index).Value & "' "
        '    cmd = New SqlCommand(str, cn)
        '    dt2 = New DataTable
        '    dt2.Load(cmd.ExecuteReader)
        '    cmd.Dispose()


        '    For ii As Integer = 0 To dt2.Rows.Count - 1
        '        Dim TEST_CODE As String = Trim(dt2.Rows(ii).Item(0).ToString)

        '        str = "SELECT TOP 1 * FROM Price_Level_Hdr WITH(NOLOCK) WHERE MOTHER_CODE ='" & GetCode(vBranch) & "' AND PriceType = 'N' "
        '        cmd = New SqlCommand(str, cn)
        '        dr = cmd.ExecuteReader

        '        If dr.HasRows Then
        '            Price_Level.Clear()
        '            While dr.Read
        '                Price_Level.Add(dr("Price_Level1"))
        '                Price_Level.Add(dr("Price_Level2"))
        '                Price_Level.Add(dr("Price_Level3"))
        '            End While
        '        Else
        '            MessageBox.Show("Please Create Bsic Price", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            Exit Sub
        '        End If
        '        dr.Close()

        '        For i As Integer = 0 To Price_Level.Count - 1
        '            str = "SELECT Price FROM BASIC_PRICE_LVL WHERE PRICE_LEVEL = '" & Price_Level(i) & "' AND RTRIM(IMH_CODE) = '" & TEST_CODE & "' "
        '            cmd = New SqlCommand(str, cn)
        '            dr = cmd.ExecuteReader

        '            If dr.HasRows Then
        '                dr.Read()
        '                If i = 0 Then
        '                    Price_Level1 = dr("Price")
        '                ElseIf i = 1 Then
        '                    Price_Level2 = dr("Price")
        '                ElseIf i = 2 Then
        '                    Price_Level3 = dr("Price")
        '                End If
        '            Else
        '                If i = 0 Then
        '                    Price_Level1 = "0.00"
        '                ElseIf i = 1 Then
        '                    Price_Level2 = "0.00"
        '                ElseIf i = 2 Then
        '                    Price_Level3 = "0.00"
        '                End If
        '            End If
        '            dr.Close()
        '        Next

        '        BILLCODE = GetBillCode(TEST_CODE)

        '        str = "SELECT NVL(IMH_CODE, ' ') IMH_CODE, NVL(IMH_DESC, ' ') IMH_DESC, NVL(IMH_BILLCODE, '') IMH_BILLCODE, " & _
        '            "NVL(IMH_CURR_P1, 0.00)IMH_CURR_P1, NVL(IMH_CURR_P2, 0.00) IMH_CURR_P2, NVL(IMH_CURR_P3, 0.00) IMH_CURR_P3, NVL(IMH_YTD_SAMT, 0.00) IMH_YTD_SAMT " & _
        '            "FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(TEST_CODE, "'", "''") & "' "
        '        Dim adapt As New OdbcDataAdapter(str, cn3)
        '        Dim dt As New DataTable
        '        dt = New DataTable
        '        adapt.Fill(dt)
        '        'Dim cmd1 As New OdbcCommand(str, cn3)
        '        'Dim dr1 As OdbcDataReader = cmd1.ExecuteReader

        '        If dt.Rows.Count > 0 Then
        '            'While dr1.Read

        '            ListPrice = CDbl(Price_Level1)
        '            If dt.Rows(0).Item("IMH_YTD_SAMT").ToString = 0 Then
        '                old_ListPrice = ListPrice
        '            Else
        '                old_ListPrice = dt.Rows(0).Item("IMH_YTD_SAMT").ToString
        '            End If

        '            If dt.Rows(0).Item("IMH_CURR_P1").ToString = "0" Then
        '                Old_Price1 = Price_Level1
        '            Else
        '                Old_Price1 = dt.Rows(0).Item("IMH_CURR_P1").ToString
        '            End If
        '            If dt.Rows(0).Item("IMH_CURR_P2").ToString = "0" Then
        '                Old_Price2 = Price_Level2
        '            Else
        '                Old_Price2 = dt.Rows(0).Item("IMH_CURR_P2").ToString
        '            End If
        '            If dt.Rows(0).Item("IMH_CURR_P3").ToString = "0" Then
        '                Old_Price3 = Price_Level3
        '            Else
        '                Old_Price3 = dt.Rows(0).Item("IMH_CURR_P3").ToString
        '            End If
        '            'dt.Rows(0).Item("IMH_BILLCODE").ToString()
        '            frmSingle.d.Rows.Add(TEST_CODE, dt.Rows(0).Item("IMH_DESC").ToString, BILLCODE, Format(CDbl(old_ListPrice), "N2"), CInt(ListPrice), CInt(Old_Price1), _
        '                       Price_Level1, CInt(Old_Price2), Price_Level2, CInt(Old_Price3), Price_Level3)
        '            'End While

        '        Else
        '            MessageBox.Show("Test Code Not Found -- " & TEST_CODE, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '            frmSingle.d.Rows.Add(TEST_CODE, "NOT FOUND", BILLCODE, Format(CDbl(0), "N2"), CInt(0), CInt(0), _
        '                      Price_Level1, CInt(0), Price_Level2, CInt(0), 0)
        '            frmSingle.d.Rows(ii).DefaultCellStyle.BackColor = Color.Red
        '            'Exit Sub
        '        End If
        '        dr.Close()
        '    Next
        '    frmSingle.lblTestCount.Text = "TEST CODE COUNT: " & frmSingle.d.Rows.Count
        'Else
        '    MessageBox.Show("Please select mother branch before importing test code", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        'End If

    End Sub

    Private Sub d_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d.MouseDoubleClick
        If d.RowCount > 0 Then
            btnSelect.PerformClick()
        End If
    End Sub
End Class