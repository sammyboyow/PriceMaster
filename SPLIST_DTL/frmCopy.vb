Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports Microsoft.Office.Interop

Public Class frmCopy
#Region "GLOBAL VARIABLES"

#End Region

#Region "SUB PROCEDURE / FUNCTION"
    Public Function Except_By_TestGrp(ByVal Price_Level As String, PriceList As String, IMH_CODE As String, TestGrp As String) As Boolean
        Dim RetValue As Boolean = False

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        'With cmd
        '    .Connection = cn
        '    .CommandType = CommandType.StoredProcedure
        '    .CommandText = "sp_GetTestGrp"
        '    .Parameters.AddWithValue("@IMH_CODE", IMH_CODE)
        '    TESTGRP = .ExecuteScalar

        '    .Dispose()            
        'End With

        str = "SELECT TOP 1 1 FROM EXCEPT_BY_TESTGRP WHERE PRICE_LEVEL = '" & Price_Level & "' AND PRICE_LIST = '" & PriceList & "' AND TEST_GRP ='" & TestGrp & "' "
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
    Public Sub GenerateExcel(ByVal DT As DataTable)
        'Dim SaveFile As New SaveFileDialog

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", DocEntry As String = ""
        Dim cmd As New SqlCommand

        str = "SELECT (ISNULL(MAX(DOCENTRY), 0) + 1) DocEntry FROM REPORT_GENERATED WITH(NOLOCK) "
        cmd = New SqlCommand(str, cn)
        DocEntry = cmd.ExecuteScalar

        Dim xlApp As New Excel.Application
        Dim xlWB As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        xlWB = xlApp.Workbooks.Add(misValue)
        xlSheet = xlWB.Sheets("Sheet1")

        If (Not System.IO.Directory.Exists("D:\Excel Files")) Then
            'CREATE PATH 
            System.IO.Directory.CreateDirectory("D:\Excel Files")
        End If


        'xlApp.Visible = True
        xlSheet.Range("A7:N7").Select()
        xlApp.ActiveWindow.FreezePanes = True
        xlSheet.Cells(3, 1) = "SPLIST GENERATED DATE [" & Format(Now, "MM/dd/yyyy") & "]"
        xlSheet.Range("A3").EntireColumn.AutoFit()
        xlSheet.Range("A3").Font.Bold = True
        xlSheet.Range("A3").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen)
        xlSheet.Range("A3").Font.Color = Color.White


        xlSheet.Cells(5, 1) = "PRICE LIST"
        xlSheet.Cells(5, 9) = "BASIC PRICE"

        'xlSheet.Range(xlSheet.Cells(5, 1), xlSheet.Cells(5, 2)).Merge()
        'xlSheet.Range(xlSheet.Cells(5, 1), xlSheet.Cells(5, 2)).HorizontalAlignment = Excel.Constants.xlCenter

        xlSheet.Cells(6, 1) = "SPD_CODE"
        xlSheet.Cells(6, 2) = "SPD_DESC"
        xlSheet.Cells(6, 3) = "TEST GROUP"
        xlSheet.Cells(6, 4) = "SPD_IMH_CODE"
        xlSheet.Cells(6, 5) = "SPD_CURR_PRICE"
        xlSheet.Cells(6, 6) = "SPD_PRV_PRICE"
        xlSheet.Cells(6, 7) = "SPD_EFD"
        xlSheet.Cells(6, 8) = "   "
        xlSheet.Cells(6, 9) = "PRICE_LEVEL"
        xlSheet.Cells(6, 10) = "BASIC_PRICE"
        xlSheet.Cells(6, 11) = "PERCENTAGE 1"
        xlSheet.Cells(6, 12) = "DISCOUNT 1"
        xlSheet.Cells(6, 13) = "PERCENTAGE 2"
        xlSheet.Cells(6, 14) = "DISCOUNT 2"

        xlSheet.Range(xlSheet.Cells(6, 1), xlSheet.Cells(6, 14)).EntireColumn.AutoFit()
        xlSheet.Range(xlSheet.Cells(6, 1), xlSheet.Cells(6, 14)).Font.Bold = True
        xlSheet.Range(xlSheet.Cells(6, 1), xlSheet.Cells(6, 14)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        xlSheet.Range(xlSheet.Cells(6, 1), xlSheet.Cells(6, 14)).HorizontalAlignment = Excel.Constants.xlCenter
        xlSheet.Range(xlSheet.Cells(6, 1), xlSheet.Cells(6, 14)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen)
        xlSheet.Range(xlSheet.Cells(6, 1), xlSheet.Cells(6, 14)).Font.Color = Color.White
        xlSheet.Range("H6").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Bisque)
        xlSheet.Range("H6").ColumnWidth = 6


        Dim xlRow As Integer = 7
        For i As Integer = 0 To DT.Rows.Count - 1
            xlSheet.Cells(xlRow, 1) = DT.Rows(i).Item(0).ToString
            xlSheet.Cells(xlRow, 2) = DT.Rows(i).Item(1).ToString
            xlSheet.Cells(xlRow, 3) = "'" & DT.Rows(i).Item(2).ToString
            xlSheet.Cells(xlRow, 4) = "'" & DT.Rows(i).Item(3).ToString
            xlSheet.Cells(xlRow, 5) = "'" & Format(CDbl(DT.Rows(i).Item(4).ToString), "N2")
            xlSheet.Cells(xlRow, 6) = "'" & Format(CDbl(DT.Rows(i).Item(5).ToString), "N2")
            xlSheet.Cells(xlRow, 7) = "'" & Format(CDate(DT.Rows(i).Item(6).ToString), "MM/dd/yyyy")
            xlSheet.Cells(xlRow, 9) = "'" & DT.Rows(i).Item(7).ToString
            xlSheet.Cells(xlRow, 10) = "'" & Format(CDbl(DT.Rows(i).Item(8).ToString), "N2")
            xlSheet.Cells(xlRow, 11) = "'" & DT.Rows(i).Item(9).ToString
            xlSheet.Cells(xlRow, 12) = "'" & Format(CDbl(DT.Rows(i).Item(10).ToString), "N2")
            xlSheet.Cells(xlRow, 13) = "'" & DT.Rows(i).Item(11).ToString
            xlSheet.Cells(xlRow, 14) = "'" & Format(CDbl(DT.Rows(i).Item(12).ToString), "N2")
            xlRow += 1
        Next
        xlSheet.Range("A5:G5").Merge()
        xlSheet.Range("A5:G5").Font.Color = Color.Blue
        xlSheet.Range("A5:G5").HorizontalAlignment = Excel.Constants.xlCenter
        xlSheet.Range("A5:G5").Font.Bold = True
        xlSheet.Range("A5:G5").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
        xlSheet.Range("A5:G5").Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        xlSheet.Range("I5:N5").Font.Color = Color.Blue
        xlSheet.Range("I5:N5").Merge()
        xlSheet.Range("I5:N5").HorizontalAlignment = Excel.Constants.xlCenter
        xlSheet.Range("I5:N5").Font.Bold = True
        xlSheet.Range("I5:N5").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow)
        xlSheet.Range("I5:N5").Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        xlSheet.Range(xlSheet.Cells(7, 1), xlSheet.Cells(xlRow, 7)).EntireColumn.AutoFit()
        xlSheet.Range(xlSheet.Cells(7, 9), xlSheet.Cells(xlRow, 14)).EntireColumn.AutoFit()
        xlSheet.Range(xlSheet.Cells(7, 1), xlSheet.Cells(xlRow, 7)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        xlSheet.Range(xlSheet.Cells(7, 9), xlSheet.Cells(xlRow, 14)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        xlSheet.Range(xlSheet.Cells(7, 1), xlSheet.Cells(xlRow, 7)).HorizontalAlignment = Excel.Constants.xlCenter
        xlSheet.Range(xlSheet.Cells(7, 9), xlSheet.Cells(xlRow, 14)).HorizontalAlignment = Excel.Constants.xlCenter

        xlSheet.Range(xlSheet.Cells(7, 8), xlSheet.Cells(xlRow, 8)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Bisque)

        xlSheet.Range("O7:O" & xlRow).ColumnWidth = 10
        xlSheet.Range("O7:O" & xlRow).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Transparent)
        Dim FileName As String = "D:\Excel Files\SPLIST_ " & DocEntry & "_" & Replace(Format(Now, "MM/dd/yyyy"), "/", "") & ".xls"
        xlSheet.SaveAs(FileName)

        'xlWB.Close()
        'xlApp.Quit()
        str = "INSERT INTO REPORT_GENERATED VALUES ('" & DocEntry & "','" & FileName & "',GETDATE())"
        cmd = New SqlCommand(str, cn)
        cmd.ExecuteNonQuery()
        xlApp.Visible = True
        releaseObject(xlApp)
        releaseObject(xlWB)
        releaseObject(xlSheet)
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
    Public Sub LoadTestCode()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim c As New AutoCompleteStringCollection()

        Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK) "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            c.Clear()
            txtNewCode.Clear()
            txtOld.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                c.Add(dt.Rows(i).Item("IMH_DESC").ToString)
                c.Add(dt.Rows(i).Item("IMH_CODE").ToString)
            Next
            txtNewCode.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtNewCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtNewCode.AutoCompleteCustomSource = c

            txtOld.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtOld.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtOld.AutoCompleteCustomSource = c
        Else
            c.Clear()
            txtNewCode.Clear()
            txtOld.Clear()
        End If
    End Sub
    
    Public Function GetBasicPrice(Old_TestCode As String, Price_Level As String, IP As String) As String
        Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = 192.171.11.100)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon1 & ";UID=HCLAB;PWD=HCLAB"

        Dim cn As New OdbcConnection(cnStr2)
        If cn.State = ConnectionState.Closed Then cn.Open()

        If Price_Level = "GOVT3" Then
            Dim cn2 = ""
        End If

        Dim str As String = "SELECT SPD_CURR_PRICE FROM SPLIST_DTL WHERE SPD_CODE = '" & Price_Level & "' AND SPD_IMH_CODE = '" & Old_TestCode & "' "
        Dim cmd As New OdbcCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
    Public Function GetTESTGRP(IMH_BILLCODE As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", RetValue As String = ""
        Dim cmd As New SqlCommand

        With cmd
            .Connection = cn
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_GetTestGrp"
            .Parameters.AddWithValue("@IMH_BillCode", IMH_BILLCODE)
            RetValue = .ExecuteScalar
        End With
        cmd.Dispose()
        cn.Dispose()

        Return RetValue
    End Function
    Public Function GetPrice(ByVal IMH_CODE As String, UnitPrice As String, LIST_PRICE As String, PRICE_LEVEL As String, TEST_GRP As String) As String
        'Dim strsamplecon1 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = 192.171.3.103)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        'Dim cnStr As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon1 & ";UID=HCLAB;PWD=HCLAB"
        'Dim cn As New OdbcConnection(cnStr)
        'If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()
        Dim cmd1 As New SqlCommand

        Dim IMH_BILLCODE As String = ""
        Dim cmd As New OdbcCommand
        Dim str As String = ""

        Dim NEWPRICE As String = ""

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

        Return NEWPRICE
        'cn.Dispose()
        cn2.Dispose()
        cmd.Dispose()
        cmd1.Dispose()
    End Function
#End Region

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MessageBox.Show("Do you want to save transaction?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New OdbcConnection
        
        Dim str As String = "", BATCH_ID_IMH As String = "", BATCH_ID_SPLIST As String = "", BASIC_PRICE As String = "", TESTGRP As String = "", NewPrice As String = ""
        Dim Prct_1 As String = "", Prct_2 As String = "", TEST_GRP As String = "", DIF1 As String = "", DIF2 As String = "", SUM_TOTAL As String = ""
        Dim dtSPLIST As New DataTable


        Dim cmd As New SqlCommand
        Dim adapt As New SqlDataAdapter
        Dim cmd2 As New OdbcCommand
        'Dim dr As OdbcDataReader


        str =
            "SELECT B.Code, A.Mother_Branch, B.HcLabIPAdd " & _
            "FROM (SELECT DISTINCT Mother_Branch " & _
            "	  FROM Price_Level_Hdr WITH(NOLOCK) " & _
            "	  WHERE PriceType = 'N' " & _
            "	 ) A " & _
            "INNER JOIN sapset B WITH(NOLOCK) ON A.Mother_Branch COLLATE DATABASE_DEFAULT = B.Blk COLLATE DATABASE_DEFAULT"
        adapt = New SqlDataAdapter(str, cn)
        Dim dtIP As New DataTable
        adapt.Fill(dtIP)

        If dtIP.Rows.Count > 0 Then
            Try
                cmd = New SqlCommand("BEGIN TRAN", cn)
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To dtIP.Rows.Count - 1
                    BATCH_ID_IMH = GetBatchID_IMH()
                    '" & dtIP.Rows(i).Item("HcLabIPAdd").ToString & "
                    Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = " & dtIP.Rows(i).Item("HcLabIPAdd").ToString & ")(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
                    Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon2 & ";UID=HCLAB;PWD=HCLAB"

                    Try
                        cn2 = New OdbcConnection(cnStr2)
                        If cn2.State = ConnectionState.Closed Then cn2.Open()
                        'IMH GENERATION
                        str = "SELECT IMH_TYPE, IMH_PDGROUP, IMH_STKITEM_FLAG, IMH_TAXABLE, IMH_YTD_SQTY, IMH_YTD_SAMT, " & _
                           "IMH_STD_COST, IMH_FIXED_PRICE, IMH_CURR_P1, IMH_CURR_P2, IMH_CURR_P3, IMH_REC_FLAG, IMH_UPDATE_BY, IMH_UPDATE_ON " & _
                           "FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(txtOld.Text, "'", "''") & "' "
                        cmd2 = New OdbcCommand(str, cn2)
                        Dim dt2 As New DataTable
                        dt2.Load(cmd2.ExecuteReader)
                        'dr = cmd2.ExecuteReader

                        If dt2.Rows.Count > 0 Then
                            str = "INSERT INTO TMP_ITEM_MASTERH (MOTHER_BRANCH, IMH_CODE, IMH_DESC, IMH_TYPE, IMH_PDGROUP, IMH_BILLCODE, IMH_STKITEM_FLAG, IMH_TAXABLE, IMH_YTD_SQTY, IMH_YTD_SAMT, IMH_STD_COST, " & _
                                "IMH_CURR_P1, IMH_EFD_P1, IMH_PREV_P1, IMH_CURR_P2, IMH_EFD_P2, IMH_PREV_P2, IMH_CURR_P3, IMH_EFD_P3, IMH_PREV_P3, IMH_FIXED_PRICE, IMH_REC_FLAG, IMH_UPDATE_BY, IMH_UPDATE_ON, IS_SYNC, BATCH_ID)" & _
                                "VALUES ('" & dtIP.Rows(i).Item("Code").ToString & "','" & Replace(txtNewCode.Text, "'", "''") & "','" & Replace(txtNewDesc.Text, "'", "''") & "','" & Replace(dt2.Rows(0).Item("IMH_TYPE").ToString(), "'", "''") & "', " & _
                                "'" & Replace(dt2.Rows(0).Item("IMH_PDGROUP").ToString(), "'", "''") & "','" & Replace(txtBillCode.Text, "'", "''") & "','" & Replace(dt2.Rows(0).Item("IMH_STKITEM_FLAG").ToString(), "'", "''") & "','" & Replace(dt2.Rows(0).Item("IMH_TAXABLE").ToString(), "'", "''") & "', " & _
                                "'" & Replace(dt2.Rows(0).Item("IMH_YTD_SQTY").ToString(), "'", "''") & "'," & Replace(CInt(dt2.Rows(0).Item("IMH_YTD_SAMT").ToString()), "'", "''") & ",'" & Replace(dt2.Rows(0).Item("IMH_STD_COST").ToString(), "'", "''") & "'," & Replace(dt2.Rows(0).Item("IMH_CURR_P1").ToString(), "'", "''") & ", " & _
                                "'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "'," & Replace(CInt(dt2.Rows(0).Item("IMH_CURR_P1").ToString()), ",", "") & "," & Replace(dt2.Rows(0).Item("IMH_CURR_P2").ToString(), "'", "''") & ",'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "', " & _
                                "" & Replace(CInt(dt2.Rows(0).Item("IMH_CURR_P1").ToString()), "'", "''") & "," & Replace(dt2.Rows(0).Item("IMH_CURR_P3").ToString(), "'", "''") & ",'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "'," & Replace(CInt(dt2.Rows(0).Item("IMH_CURR_P3").ToString()), "'", "''") & ", " & _
                                "'" & Replace(dt2.Rows(0).Item("IMH_FIXED_PRICE").ToString(), "'", "''") & "','" & Replace(dt2.Rows(0).Item("IMH_REC_FLAG").ToString(), "'", "''") & "','KISSEL',GETDATE(),'N', '" & BATCH_ID_IMH & "')"
                            cmd = New SqlCommand(str, cn)
                            cmd.ExecuteNonQuery()
                        End If
                        'If dr.HasRows Then
                        '    dr.Read()
                        '    str = "INSERT INTO TMP_ITEM_MASTERH (MOTHER_BRANCH, IMH_CODE, IMH_DESC, IMH_TYPE, IMH_PDGROUP, IMH_BILLCODE, IMH_STKITEM_FLAG, IMH_TAXABLE, IMH_YTD_SQTY, IMH_YTD_SAMT, IMH_STD_COST, " & _
                        '        "IMH_CURR_P1, IMH_EFD_P1, IMH_PREV_P1, IMH_CURR_P2, IMH_EFD_P2, IMH_PREV_P2, IMH_CURR_P3, IMH_EFD_P3, IMH_PREV_P3, IMH_FIXED_PRICE, IMH_REC_FLAG, IMH_UPDATE_BY, IMH_UPDATE_ON, IS_SYNC, BATCH_ID)" & _
                        '        "VALUES ('" & dtIP.Rows(i).Item("Code").ToString & "','" & Replace(txtNewCode.Text, "'", "''") & "','" & Replace(txtNewDesc.Text, "'", "''") & "','" & Replace(dr("IMH_TYPE"), "'", "''") & "', " & _
                        '        "'" & Replace(dr("IMH_PDGROUP"), "'", "''") & "','" & Replace(txtBillCode.Text, "'", "''") & "','" & Replace(dr("IMH_STKITEM_FLAG"), "'", "''") & "','" & Replace(dr("IMH_TAXABLE"), "'", "''") & "', " & _
                        '        "'" & Replace(dr("IMH_YTD_SQTY"), "'", "''") & "'," & Replace(CInt(dr("IMH_YTD_SAMT")), "'", "''") & ",'" & Replace(dr("IMH_STD_COST"), "'", "''") & "'," & Replace(dr("IMH_CURR_P1"), "'", "''") & ", " & _
                        '        "'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "'," & Replace(CInt(dr("IMH_CURR_P1")), ",", "") & "," & Replace(dr("IMH_CURR_P2"), "'", "''") & ",'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "', " & _
                        '        "" & Replace(CInt(dr("IMH_CURR_P1")), "'", "''") & "," & Replace(dr("IMH_CURR_P3"), "'", "''") & ",'" & Replace(Format(dtEffect.Value, "MM/dd/yyyy"), "'", "''") & "'," & Replace(CInt(dr("IMH_CURR_P3")), "'", "''") & ", " & _
                        '        "'" & Replace(dr("IMH_FIXED_PRICE"), "'", "''") & "','" & Replace(dr("IMH_REC_FLAG"), "'", "''") & "','KISSEL',GETDATE(),'N', '" & BATCH_ID_IMH & "')"
                        '    cmd = New SqlCommand(str, cn)
                        '    cmd.ExecuteNonQuery()
                        'Else
                        '    MessageBox.Show("Old Test Code not found for Mother Branch:" & dtIP.Rows(i).Item("Mother_Branch").ToString, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'End If
                        'dr.Close()
                        cn2.Dispose()
                    Catch ex As Exception

                    End Try                   
                Next
                '================================================================================================
                '================================================================================================
                BATCH_ID_SPLIST = ""
                BATCH_ID_SPLIST = GetBatchID_SPLIST()

                Try
                    str = "INSERT INTO BATCH_SPLIST VALUES ('" & BATCH_ID_SPLIST & "','" & dtEffect.Value.ToString & "','N') "
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()

                    'GENERATION OF SPLIST_DTL 
                    str = "SELECT * " & _
                         "FROM Price_Level_Dtl WITH(NOLOCK) " & _
                         "ORDER BY PriceLevel "
                    adapt = New SqlDataAdapter(str, cn)
                    Dim dtBP As New DataTable
                    adapt.Fill(dtBP)

                    If dtBP.Rows.Count > 0 Then
                        dtSPLIST.Columns.Add(New DataColumn("SPD_CODE", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("SPD_DESC", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("TEST_GROUP", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("SPD_IMH_CODE", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("SPD_CURR_PRICE", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("SPD_PRV_PRICE", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("SPD_EFD", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("PRICE_LEVEL", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("BASIC_PRICE", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("PERCENTAGE 1", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("DISCOUNT_1", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("PERCENTAGE_2", GetType(String)))
                        dtSPLIST.Columns.Add(New DataColumn("DISCOUNT_2", GetType(String)))
                        For ii As Integer = 0 To dtBP.Rows.Count - 1
                            TESTGRP = GetTESTGRP(txtBillCode.Text)
                            If Except_By_TestGrp(dtBP.Rows(ii).Item("PriceLevel").ToString, dtBP.Rows(ii).Item("PriceList").ToString, txtNewCode.Text, TEST_GRP) = False Then
                                BASIC_PRICE = GetBasicPrice(txtOld.Text, dtBP.Rows(ii).Item("PriceLevel").ToString, "192.171.11.100")
                                'BASIC_PRICE = GetBasicPrice(txtOld.Text, "OTC5", "192.171.3.103")
                                If BASIC_PRICE = "0" Or BASIC_PRICE = "" Then GoTo ReadNext
                                NewPrice = GetPrice(txtNewCode.Text, BASIC_PRICE, dtBP.Rows(ii).Item("PriceList").ToString, dtBP.Rows(ii).Item("PriceLevel").ToString, TESTGRP)

                                str = "INSERT INTO SPLIST_DTL (SPD_CODE, SPD_IMH_CODE, SPD_CURR_PRICE, SPD_EFD, SPD_PREV_PRICE, BATCH_ID) " & _
                                    "VALUES ('" & Replace(dtBP.Rows(ii).Item("PriceList").ToString, "'", "''") & "','" & txtNewCode.Text & "', " & _
                                    "'" & NewPrice & "','" & dtEffect.Value & "','" & NewPrice & "','" & BATCH_ID_SPLIST & "')"
                                cmd = New SqlCommand(str, cn)
                                cmd.ExecuteNonQuery()

                                If TESTGRP = "ULTRASOUND" Then
                                    Prct_1 = CDbl(dtBP.Rows(ii).Item("UTZ_1").ToString) * 100
                                    DIF1 = BASIC_PRICE * (dtBP.Rows(ii).Item("UTZ_1").ToString)
                                    SUM_TOTAL = BASIC_PRICE + (BASIC_PRICE * dtBP.Rows(ii).Item("UTZ_1").ToString)
                                    Prct_2 = CDbl(dtBP.Rows(ii).Item("UTZ_2").ToString) * 100
                                    DIF2 = SUM_TOTAL * (dtBP.Rows(ii).Item("UTZ_2").ToString)
                                ElseIf TESTGRP = "IMAGING" Then
                                    Prct_1 = CDbl(dtBP.Rows(ii).Item("Imaging_1").ToString) * 100
                                    DIF1 = BASIC_PRICE * (dtBP.Rows(ii).Item("Imaging_1").ToString)
                                    SUM_TOTAL = BASIC_PRICE + (BASIC_PRICE * dtBP.Rows(ii).Item("Imaging_1").ToString)
                                    Prct_2 = CDbl(dtBP.Rows(ii).Item("Imaging_2").ToString) * 100
                                    DIF2 = SUM_TOTAL * (dtBP.Rows(ii).Item("Imaging_2").ToString)
                                ElseIf TESTGRP = "SPECIAL TESTS" Then
                                    Prct_1 = CDbl(dtBP.Rows(ii).Item("Special_1").ToString) * 100
                                    DIF1 = BASIC_PRICE * dtBP.Rows(ii).Item("Special_1").ToString
                                    SUM_TOTAL = BASIC_PRICE + (BASIC_PRICE * dtBP.Rows(ii).Item("Special_1").ToString)
                                    Prct_2 = CDbl(dtBP.Rows(ii).Item("Special_2").ToString) * 100
                                    DIF2 = SUM_TOTAL * dtBP.Rows(ii).Item("Special_2").ToString
                                Else
                                    Prct_1 = CDbl(dtBP.Rows(ii).Item("Regular_1").ToString) * 100
                                    DIF1 = BASIC_PRICE * (dtBP.Rows(ii).Item("Regular_1").ToString)
                                    SUM_TOTAL = BASIC_PRICE + (BASIC_PRICE * dtBP.Rows(ii).Item("Regular_1").ToString)
                                    Prct_2 = CDbl(dtBP.Rows(ii).Item("Regular_2").ToString) * 100
                                    DIF2 = SUM_TOTAL * (dtBP.Rows(ii).Item("Regular_2").ToString)
                                End If
                                Prct_1 = Prct_1 & "%"
                                Prct_2 = Prct_2 & "%"
                                dtSPLIST.Rows.Add(Replace(dtBP.Rows(ii).Item("PriceList").ToString, "'", "''"), dtBP.Rows(ii).Item("PriceList_Desc").ToString, TESTGRP, _
                                                  txtNewCode.Text, NewPrice, NewPrice, dtEffect.Value.ToString, dtBP.Rows(ii).Item("PriceLevel").ToString, _
                                                  BASIC_PRICE, Prct_1, DIF1, Prct_2, DIF2)
                            End If
ReadNext:
                        Next
                    End If
                    '================================================================================================
                    '================================================================================================
                    'GENERATION OF REPORT
                    GenerateExcel(dtSPLIST)
                Catch ex As Exception

                End Try                               
COMMIT:        
                str = "INSERT INTO COPY_TEST_LOGS (NEW_CODE, OLD_CODE, POST_BY, POST_DATE) VALUES ('" & txtNewCode.Text & "','" & txtOld.Text & "','" & Info.UserName & "',GETDATE())"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()

                cmd = New SqlCommand("COMMIT", cn)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Done Copying Test Code" & vbNewLine & "System Will automatically sync details accross branch", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                cmd = New SqlCommand("ROLLBACK", cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
        cn.Dispose()
    End Sub

    Private Sub frmCopy_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTestCode()
    End Sub

    Private Sub txtOld_LostFocus(sender As Object, e As EventArgs) Handles txtOld.LostFocus
        If txtOld.Text = "" Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT IMH_CODE FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(txtOld.Text, "'", "''") & "' OR IMH_DESC = '" & Replace(txtOld.Text, "'", "''") & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If Not str Is Nothing Then
            txtOld.Text = str
        Else
            txtOld.Text = ""
        End If
        cn.Dispose()
    End Sub

    Private Sub txtOld_TextChanged(sender As Object, e As EventArgs) Handles txtOld.TextChanged
    End Sub

    Private Sub txtNewCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNewCode.KeyDown
        If e.KeyCode = Keys.Return Then
            If txtNewCode.Text = "" Then Exit Sub

            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(txtNewCode.Text, "'", "''") & "' OR IMH_DESC = '" & Replace(txtNewCode.Text, "'", "''") & "' "
            Dim adapt As New SqlDataAdapter(str, cn)
            Dim dt As New DataTable
            adapt.Fill(dt)

            If dt.Rows.Count > 0 Then
                txtNewCode.Text = dt.Rows(0).Item("IMH_CODE").ToString
                txtNewDesc.Text = dt.Rows(0).Item("IMH_DESC").ToString
                txtOld.Focus()
            End If

            cn.Dispose()
        End If
    End Sub

    Private Sub txtNewCode_LostFocus(sender As Object, e As EventArgs) Handles txtNewCode.LostFocus
        If txtNewCode.Text = "" Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(txtNewCode.Text, "'", "''") & "' OR IMH_DESC = '" & Replace(txtNewCode.Text, "'", "''") & "' "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            txtNewCode.Text = dt.Rows(0).Item("IMH_CODE").ToString
            txtNewDesc.Text = dt.Rows(0).Item("IMH_DESC").ToString
            txtOld.Focus()
        End If

        cn.Dispose()
    End Sub

    Private Sub txtNewCode_TextChanged(sender As Object, e As EventArgs) Handles txtNewCode.TextChanged
        If txtNewCode.Text = "" Then
            txtNewDesc.Text = ""
        End If
    End Sub
End Class