Imports System.Data.SqlClient
Imports System.Data.Odbc
'Imports Oracle.DataAccess.Client
Imports Microsoft.Office.Interop

Public Class frmPriceUpdateSceme
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
#Region "SUB PROCEDURE/FUNCTION"
    Public Sub AddItems(ByVal col As AutoCompleteStringCollection)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim str As String = ""

        str = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WHERE IMH_REC_FLAG='N' AND IMH_TYPE='S' ORDER BY IMH_DESC"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                col.Add(dr("IMH_CODE"))
                col.Add(dr("IMH_DESC"))
            End While
        End If
        dr.Close()
    End Sub

    Public Sub LoadTSGRP()
        dTSGRP.Rows.Add(True, True, True, True, True)
    End Sub
    Public Sub LoadPriceLevel()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT PRICE_LEVEL FROM ( " & _
                            "SELECT Price_Level1 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
                            "UNION ALL " & _
                            "SELECT Price_Level2 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
                            "UNION ALL " & _
                            "SELECT Price_Level3 AS PRICE_LEVEL FROM Price_Level_Hdr) A " & _
                            "WHERE PRICE_LEVEL <> '' "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            cbPriceLevel.Items.Clear()
            cbPriceLevel.Items.Add("")
            cbPriceLevel.Items.Add("ALL")
            While dr.Read
                cbPriceLevel.Items.Add(dr("PRICE_LEVEL"))
            End While
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Function ChkSPCode(ByVal SPD_CODE As String, ByVal PRICE_LEVEL As String) As Boolean
        For i As Integer = 0 To dSPLIST.Rows.Count - 1
            If dSPLIST("PRICELIST", i).Value = SPD_CODE And dSPLIST("PRICELVL", i).Value = PRICE_LEVEL Then
                ChkSPCode = True
                Exit For
            Else
                ChkSPCode = False
            End If
        Next
        Return ChkSPCode
    End Function
    Public Function GetPrice(ByVal IMH_CODE As String, UnitPrice As String, LIST_PRICE As String, PRICE_LEVEL As String, TEST_GRP As String, IS_SENIOR As String, IS_SWITCH As Boolean) As String
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

        str = "SELECT TOP 1 1 FROM PRICE_STANDARD WITH(NOLOCK) WHERE PriceList = '" & LIST_PRICE & "'"
        cmd1 = New SqlCommand(str, cn2)
        str = cmd1.ExecuteScalar

        If str Is Nothing Then
            If IS_SENIOR = 1 And W_Senior = False Then
                str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) WHERE PRICELEVEL = '" & PRICE_LEVEL & "' AND PriceList = '" & PRICE_LEVEL & "' "
            ElseIf IS_SENIOR = 1 And W_Senior = True Then
                str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) WHERE PRICELEVEL = '" & PRICE_LEVEL & "' AND PriceList = '" & LIST_PRICE & "' "
            Else
                str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) WHERE PRICELEVEL = '" & PRICE_LEVEL & "' AND PriceList = '" & LIST_PRICE & "' "
            End If

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

            If IS_SWITCH = True And W_Senior = False Then
                NEWPRICE = CDbl(NEWPRICE) + (CDbl(NEWPRICE) * 0.1)
            End If
        Else
            str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) WHERE PRICELEVEL = '" & PRICE_LEVEL & "' AND PriceList = '" & LIST_PRICE & "' "
            cmd1 = New SqlCommand(str, cn2)
            Dim dr1 As SqlDataReader = cmd1.ExecuteReader

            If dr1.HasRows Then
                While dr1.Read
                    If TEST_GRP = "ULTRASOUND" Then
                        NEWPRICE = CDbl(CDbl(UnitPrice) / dr1("IMAGING_1"))
                    ElseIf TEST_GRP = "IMAGING" Then
                        NEWPRICE = CDbl(CDbl(UnitPrice) / dr1("IMAGING_1"))
                    ElseIf TEST_GRP = "SPECIAL TESTS" Then
                        NEWPRICE = CDbl(CDbl(UnitPrice) / dr1("SPECIAL_1"))
                    Else
                        NEWPRICE = CDbl(CDbl(UnitPrice) / dr1("REGULAR_1"))
                    End If
                End While
            End If
            dr1.Close()

        End If


       

        Return NEWPRICE
        cn.Dispose()
        cn2.Dispose()
        cmd.Dispose()
        cmd1.Dispose()
    End Function
    Public Function GetUnitPrice(ByVal Basic_PriceLevel As String, ByVal IMH_CODE As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT PRICE FROM BASIC_PRICE_LVL WITH(NOLOCK) WHERE IMH_CODE = '" & IMH_CODE & "' AND PRICE_LEVEL = '" & Basic_PriceLevel & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
    Public Sub LoadBatchIMH(ByVal WHSCODE As String, ByVal Batch_id As String)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT IMH_CODE, IMH_BILLCODE FROM TMP_ITEM_MASTERH WITH(NOLOCK) " & _
                            "WHERE MOTHER_BRANCH = '" & WHSCODE & "' AND BATCH_ID = '" & Batch_id & "' " & _
                            "ORDER BY IMH_CODE "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = 0
        If dr.HasRows Then
            dIMH.Rows.Clear()
            While dr.Read
                dIMH.Rows.Add()
                dIMH("IMH_CODE", i).Value = dr("IMH_CODE")
                dIMH("IMH_BILLCODE", i).Value = dr("IMH_BILLCODE")
                i += 1
            End While
            dIMH.Rows.Add()
        Else
            dIMH.Rows.Clear()
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Function ChkTestGrp(ByVal IMH_CODE As String) As Boolean
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cmd As New SqlCommand
        Dim str As String = ""
        Dim RetValue As Boolean = False

        With cmd
            .Connection = cn
            .CommandTimeout = 0
            .CommandType = CommandType.StoredProcedure
            .CommandText = "sp_GetTestGrp"
            .Parameters.AddWithValue("@IMH_BILLCODE", IMH_CODE)
            str = .ExecuteScalar()
        End With

        If str = "REGULAR TESTS" Then
            If dTSGRP("REG", 0).Value = True Then
                RetValue = True
            Else
                RetValue = False
            End If
        ElseIf str = "ULTRASOUND" Then
            If dTSGRP("UTZ", 0).Value = True Then
                RetValue = True
            Else
                RetValue = False
            End If
        ElseIf str = "IMAGING" Then
            If dTSGRP("IMG", 0).Value = True Then
                RetValue = True
            Else
                RetValue = False
            End If
        ElseIf str = "SPECIAL TESTS" Then
            If dTSGRP("SPECIAL", 0).Value = True Then
                RetValue = True
            Else
                RetValue = False
            End If
        End If

        Return RetValue
        cn.Dispose()
        cmd.Dispose()
    End Function
    Public Sub ClearAll()
        dIMH.Rows.Clear()
        dIMH.Rows.Add()
        dSPLIST.Rows.Clear()
        cbPriceLevel.SelectedIndex = -1
        dtEFD.Value = Now
        chkAll.Checked = False
        For i As Integer = 0 To dTSGRP.Columns.Count - 1
            dTSGRP(i, 0).Value = True
        Next
    End Sub
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
    Public Function GetPrvPrice(PriceList As String, IMH_CODE As String) As String
        Dim cn As New OdbcConnection(cnStr)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT NVL(SPD_CURR_PRICE, 0) SPD_CURR_PRICE FROM SPLIST_DTL WHERE SPD_CODE = '" & PriceList & "' AND SPD_IMH_CODE = '" & IMH_CODE & "' "
        Dim cmd As New OdbcCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            str = "0"
        End If

        Return str
        cn.Dispose()
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

        xlSheet.Range("A7:N7").Select()
        xlApp.ActiveWindow.FreezePanes = True
        xlSheet.Cells(3, 1) = "SPLIST GENERATED DATE [" & Format(Now, "MM/dd/yyyy") & "]"
        xlSheet.Range("A3").EntireColumn.AutoFit()
        xlSheet.Range("A3").Font.Bold = True
        xlSheet.Range("A3").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkGreen)
        xlSheet.Range("A3").Font.Color = Color.White


        xlSheet.Cells(5, 1) = "PRICE LIST"
        xlSheet.Cells(5, 9) = "BASIC PRICE"

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
            xlSheet.Cells(xlRow, 1) = DT.Rows(i).Item("SPD_CODE").ToString
            'xlSheet.Cells(xlRow, 2) = DT.Rows(i).Item("PriceList_Desc").ToString
            xlSheet.Cells(xlRow, 2) = DT.Rows(i).Item("SPD_DESC").ToString
            xlSheet.Cells(xlRow, 3) = "'" & DT.Rows(i).Item("TEST_GROUP").ToString
            xlSheet.Cells(xlRow, 4) = "'" & DT.Rows(i).Item("SPD_IMH_CODE").ToString
            xlSheet.Cells(xlRow, 5) = "'" & Format(CDbl(DT.Rows(i).Item("SPD_CURR_PRICE").ToString), "N2")
            xlSheet.Cells(xlRow, 6) = "'" & Format(CDbl(DT.Rows(i).Item("SPD_PREV_PRICE").ToString), "N2")
            xlSheet.Cells(xlRow, 7) = "'" & Format(CDate(DT.Rows(i).Item("SPD_EFD").ToString), "MM/dd/yyyy")
            xlSheet.Cells(xlRow, 9) = "'" & DT.Rows(i).Item("PRICE_LEVEL").ToString
            xlSheet.Cells(xlRow, 10) = "'" & Format(CDbl(DT.Rows(i).Item("BASIC_PRICE").ToString), "N2")
            xlSheet.Cells(xlRow, 11) = "'" & DT.Rows(i).Item("PERCENTAGE_1").ToString
            xlSheet.Cells(xlRow, 12) = "'" & Format(CDbl(DT.Rows(i).Item("DISCOUNT_1").ToString), "N2")
            xlSheet.Cells(xlRow, 13) = "'" & DT.Rows(i).Item("PERCENTAGE_2").ToString
            xlSheet.Cells(xlRow, 14) = "'" & Format(CDbl(DT.Rows(i).Item("DISCOUNT_2").ToString), "N2")
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

    Public Function GetExceptPrice(ByVal Price_Level As String, ByVal Price_List As String, ByVal IMH_CODE As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT Price FROM SPLIST_Except WITH(NOLOCK) WHERE Price_Level = '" & Price_Level & "' AND PRICE_LIST = '" & Price_List & "' AND IMH_CODE = '" & IMH_CODE & "' "
        Dim cmd As New SqlCommand(str, cn)
        Str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
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
    Public Sub RunWorker()
        If bg1.IsBusy = True Then
            bg1.CancelAsync()
            RunWorker()
        Else
            bg1.RunWorkerAsync()
        End If
    End Sub
    Public Sub DisableAll()
        dIMH.ReadOnly = True
        dSPLIST.ReadOnly = True
        dTSGRP.ReadOnly = True
        cbPriceLevel.Enabled = False
        txtPriceDesc.Enabled = False
        txtPriceList.Enabled = False
        dtEFD.Enabled = False
        chkAll.Enabled = False
        btnPLADD.Enabled = False
        btnSave.Enabled = False
        btnClear.Enabled = False
        btnClear2.Enabled = False
        btnImport.Enabled = False
        btnClose.Enabled = False
        btnX.Enabled = False
    End Sub
    Public Sub Enable()
        dIMH.ReadOnly = False
        dSPLIST.ReadOnly = False
        dTSGRP.ReadOnly = False
        cbPriceLevel.Enabled = True
        txtPriceDesc.Enabled = True
        txtPriceList.Enabled = True
        dtEFD.Enabled = True
        chkAll.Enabled = True
        btnPLADD.Enabled = True
        btnSave.Enabled = True
        btnClear.Enabled = True
        btnClear2.Enabled = True
        btnImport.Enabled = True
        btnClose.Enabled = True
        btnX.Enabled = True
    End Sub
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
    Public Function DTI_EXCEPT(IMH_CODE As String, PRICE_LEVEL As String) As Boolean
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        'Dim str As String = "SELECT A.IMH_CODE, A.PRICE, A.BRANCH_CODE, B.Price_Level1, B.Price_Level2, B.Price_Level3 " & _
        '                    "FROM SPLIST_DTI A " & _
        '                    "INNER JOIN Price_Level_Hdr B ON A.BRANCH_CODE = B.Mother_Code " & _
        '                    "WHERE IMH_CODE = '" & IMH_CODE & "' AND CONVERT(DATE, END_DATE, 101) > CONVERT(DATE, GETDATE(), 101) AND  "
        Dim str As String = "SELECT TOP 1 1 " & _
                            "FROM SPLIST_DTI A WITH(NOLOCK) " & _
                            "INNER Join " & _
                            "	   (SELECT DISTINCT * " & _
                            "	    FROM (SELECT mother_branch, Mother_Code, Price_Level1 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
                            "             UNION " & _
                            "		      SELECT mother_branch, Mother_Code, Price_Level2 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
                            "             UNION " & _
                            "		      SELECT mother_branch, Mother_Code, Price_Level3 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
                            "		     ) A " & _
                            "	   ) B " & _
                            "ON A.BRANCH_CODE = B.Mother_Code " & _
                            "WHERE A.IMH_CODE = '" & IMH_CODE & "' AND CONVERT(DATE, A.END_DATE, 101) > CONVERT(DATE, GETDATE(), 101) AND PRICE_LEVEL = '" & PRICE_LEVEL & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            Return False
        Else
            Return True
        End If
        cmd.Dispose()
        cn.Dispose()
    End Function
    Public Function LoadMax() As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT ISNULL(MAX(CAST(BATCH_ID AS INT)), 0) + 1 FROM BATCH_SPLIST WITH(NOLOCK) "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
    Public Function GetDTI(ByVal IMH_CODE As String, PRICE_LEVEL As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = "", Branch_Code As String = ""
        Dim cmd As New SqlCommand


        str = "SELECT MOTHER_CODE " & _
              "FROM (SELECT DISTINCT PRICE_LEVEL, " & _
              "	     CASE WHEN PRICE_LEVEL = 'CENT2' OR PRICE_LEVEL = 'CENTUR' THEN '032' " & _
              "		     WHEN PRICE_LEVEL = 'CORP3' OR PRICE_LEVEL = 'CORP4' THEN '011' " & _
              "		     WHEN PRICE_LEVEL = 'HP2' OR PRICE_LEVEL = 'HP3' THEN '009' " & _
              "		     WHEN PRICE_LEVEL = 'HP3B' THEN '037' " & _
              "		     WHEN PRICE_LEVEL = 'MEGA4' OR PRICE_LEVEL = 'MEGA5' THEN '005' " & _
              "		     WHEN PRICE_LEVEL = 'OTC4' OR PRICE_LEVEL = 'OTC5' THEN '011' " & _
              "		     WHEN PRICE_LEVEL = 'PRVBC' OR PRICE_LEVEL = 'PRVBO' THEN '034' " & _
              "		     WHEN PRICE_LEVEL = 'PRVC2' OR PRICE_LEVEL = 'PRVC3' THEN '016' " & _
              "		     WHEN PRICE_LEVEL = 'PRVDC' OR PRICE_LEVEL = 'PRVDO' THEN '040' " & _
              "		     WHEN PRICE_LEVEL = 'PRVO2' OR PRICE_LEVEL = 'PRVO3' THEN '023' " & _
              "		     WHEN PRICE_LEVEL = 'PRVPC' OR PRICE_LEVEL = 'PRVPO' THEN '023' " & _
              "		     WHEN PRICE_LEVEL = 'SPO4' OR PRICE_LEVEL = 'SPO5' THEN '011' " & _
              "		     WHEN PRICE_LEVEL = 'VM' THEN '039' " & _
              "		     ELSE NULL END Mother_Code " & _
              "	     FROM (SELECT Price_Level1 AS PRICE_LEVEL FROM Price_Level_Hdr WITH(NOLOCK) " & _
              "            UNION ALL " & _
              "			   SELECT Price_Level2 AS PRICE_LEVEL FROM Price_Level_Hdr WITH(NOLOCK) " & _
              "            UNION ALL " & _
              "			   SELECT Price_Level3 AS PRICE_LEVEL FROM Price_Level_Hdr WITH(NOLOCK) " & _
              "			  ) A " & _
              "		 WHERE A.PRICE_LEVEL <> '') A " & _
              "WHERE PRICE_LEVEL = '" & PRICE_LEVEL & "' "
        cmd = New SqlCommand(str, cn)
        Branch_Code = cmd.ExecuteScalar

        str = "SELECT PRICE FROM SPLIST_DTI WITH(NOLOCK) WHERE IMH_CODE = '" & IMH_CODE & "' AND BRANCH_CODE ='" & Branch_Code & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar


        If str Is Nothing Then
            Return "0"
        Else
            Return str
        End If
        cn.Dispose()
        'str = "SELECT A.PRICE " & _
        '    "FROM SPLIST_DTI A WITH(NOLOCK) " & _
        '    "        INNER Join " & _
        '    "	(SELECT Mother_Code FROM Price_Level_Hdr WITH(NOLOCK) " & _
        '    "	 WHERE Price_Level1 = '" & PRICE_LEVEL & "' OR Price_Level2 = '" & PRICE_LEVEL & "' OR Price_Level3 = '" & PRICE_LEVEL & "' " & _
        '    "	 ) B ON A.BRANCH_CODE = B.Mother_Code " & _
        '    "WHERE CONVERT(DATE, A.END_DATE, 101) >= CONVERT(DATE, GETDATE(), 101) " & _
        '    "AND A.IMH_CODE = '" & IMH_CODE & "'"
        'cmd = New SqlCommand(str, cn)
        'str = cmd.ExecuteScalar

        'If str Is Nothing Then
        '    str = 0        
        'End If
        'str = "SELECT Mother_Code from Price_Level_Hdr WHERE Price_Level1 = '" & PRICE_LEVEL & "' OR Price_Level2 = '" & PRICE_LEVEL & "' OR Price_Level3 = '" & PRICE_LEVEL & "'"
        'cmd = New SqlCommand(str, cn)
        'Branch_Code = cmd.ExecuteScalar

        'str = "SELECT PRICE FROM SPLIST_DTI WITH(NOLOCK) " & _
        '    "WHERE IMH_CODE = '" & IMH_CODE & "' AND Branch_Code = '" & Branch_Code & "' " & _
        '    "AND CONVERT(DATE, END_DATE, 101) >= CONVERT(DATE, GETDATE(), 101) "
        'cmd = New SqlCommand(str, cn)
        'str = cmd.ExecuteScalar
        'Return str
    End Function
#End Region
    Dim W_Senior As Boolean = False
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub frmPriceUpdateSceme_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadTSGRP()
        LoadPriceLevel()
        dIMH.Rows.Add()
        'LoadTestCode()
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub dTSGRP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dTSGRP.CellContentClick
        If dTSGRP.CurrentCell.ColumnIndex = 0 Then
            If dTSGRP(0, dTSGRP.CurrentRow.Index).Value = True Then
                dTSGRP(0, dTSGRP.CurrentRow.Index).Value = False
                dTSGRP(1, dTSGRP.CurrentRow.Index).Value = False
                dTSGRP(2, dTSGRP.CurrentRow.Index).Value = False
                dTSGRP(3, dTSGRP.CurrentRow.Index).Value = False
                dTSGRP(4, dTSGRP.CurrentRow.Index).Value = False
            Else
                dTSGRP(0, dTSGRP.CurrentRow.Index).Value = True
                dTSGRP(1, dTSGRP.CurrentRow.Index).Value = True
                dTSGRP(2, dTSGRP.CurrentRow.Index).Value = True
                dTSGRP(3, dTSGRP.CurrentRow.Index).Value = True
                dTSGRP(4, dTSGRP.CurrentRow.Index).Value = True
            End If
        End If

    End Sub
    Private Sub cbPriceLevel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbPriceLevel.SelectedIndexChanged
        Dim c As New AutoCompleteStringCollection()
        If cbPriceLevel.Text <> "" Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim str As String = ""
            Dim cmd As New SqlCommand
            Dim dr As SqlDataReader

            If cbPriceLevel.Text = "ALL" Then
                txtPriceList.ReadOnly = True
                txtPriceList.Enabled = False
                str = "SELECT PriceList, PriceList_Desc FROM Price_Level_Dtl WITH(NOLOCK) " & _
                "ORDER BY PriceList, PriceList_Desc "
            Else
                txtPriceList.ReadOnly = False
                txtPriceList.Enabled = True
                str = "SELECT PriceList, PriceList_Desc FROM Price_Level_Dtl WITH(NOLOCK) WHERE PriceLevel='" & cbPriceLevel.Text & "' " & _
                      "ORDER BY PriceList, PriceList_Desc "
            End If
            cmd = New SqlCommand(str, cn)
            dr = cmd.ExecuteReader
            If dr.HasRows Then
                txtPriceDesc.Text = ""
                txtPriceList.Clear()
                c.Clear()
                While dr.Read
                    c.Add(dr("PriceList"))
                    c.Add(dr("PriceList_Desc"))
                End While
            Else
                c.Clear()
            End If
            dr.Close()
        Else
            txtPriceList.Clear()
            txtPriceDesc.Text = ""
        End If
        txtPriceList.AutoCompleteMode = AutoCompleteMode.Suggest
        txtPriceList.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtPriceList.AutoCompleteCustomSource = c
    End Sub

    Private Sub txtPriceList_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPriceList.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "select * from Price_Level_Dtl where PriceLevel = '" & cbPriceLevel.Text & "' AND PriceList = '" & txtPriceList.Text & "' OR " & _
                                "PriceLevel = '" & cbPriceLevel.Text & "' AND PriceList_Desc ='" & txtPriceList.Text & "' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                dr.Read()
                txtPriceList.Text = dr("PriceList")
                txtPriceDesc.Text = dr("PriceList_Desc")
            Else
                txtPriceList.Text = ""
                txtPriceDesc.Text = ""
                MessageBox.Show("Price List not found", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            dr.Close()
            cn.Dispose()
        End If
    End Sub

    Private Sub txtPriceList_TextChanged(sender As Object, e As EventArgs) Handles txtPriceList.TextChanged
        If txtPriceList.Text = "" Then
            txtPriceList.Text = ""
            txtPriceDesc.Text = ""
        End If
    End Sub

    Private Sub chkAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkAll.CheckedChanged
        If chkAll.Checked = True Then
            txtPriceList.Enabled = False
            txtPriceList.ReadOnly = True
            txtPriceList.Text = ""
            txtPriceDesc.Text = ""
        Else
            txtPriceList.Enabled = True
            txtPriceList.ReadOnly = False
            txtPriceList.Text = ""
            txtPriceDesc.Text = ""
        End If
    End Sub

    Private Sub btnPLADD_Click(sender As Object, e As EventArgs) Handles btnPLADD.Click
        If cbPriceLevel.Text = "" Then MessageBox.Show("Please Select Price Level", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cmd As New SqlCommand
        Dim str As String = ""

        If chkAll.Checked = True Then
            If cbPriceLevel.Text = "ALL" Then
                If MessageBox.Show("Do you want to include senior price list [Y/N]?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then                    
                    W_Senior = True
                Else
                    W_Senior = False
                End If
                str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) ORDER BY PriceLevel, PriceList "
            Else
                If MessageBox.Show("Do you want to include senior price list [Y/N]?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes 
                    W_Senior = True
                Else
                    W_Senior = False
                End If
                str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) WHERE PriceLevel = '" & cbPriceLevel.Text & "' ORDER BY PriceLevel, PriceList "
            End If

        Else          
            If txtPriceList.Text = "" Then MessageBox.Show("Please Select Price List", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
            
            str = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) WHERE PriceLevel = '" & cbPriceLevel.Text & "' AND PriceList = '" & txtPriceList.Text & "' ORDER BY PriceLevel, PriceList "
        End If
        cmd = New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = dSPLIST.RowCount
        If dr.HasRows Then
            While dr.Read
                If ChkSPCode(dr("PriceList"), cbPriceLevel.Text) = False Then
                    dSPLIST.Rows.Add()
                    dSPLIST("PRICELVL", i).Value = dr("PriceLevel")
                    dSPLIST("PRICELIST", i).Value = dr("PriceList")
                    dSPLIST("PL_DESC", i).Value = dr("PriceList_Desc")
                    dSPLIST("REG1", i).Value = dr("Regular_1")
                    dSPLIST("REG2", i).Value = dr("Regular_2")
                    dSPLIST("SP1", i).Value = dr("Special_1")
                    dSPLIST("SP2", i).Value = dr("Special_2")
                    dSPLIST("IMG1", i).Value = dr("Imaging_1")
                    dSPLIST("IMG2", i).Value = dr("Imaging_2")
                    dSPLIST("UTZ1", i).Value = dr("UTZ_1")
                    dSPLIST("UTZ2", i).Value = dr("UTZ_2")
                    dSPLIST("IS_SENIOR", i).Value = dr("IS_SENIOR")
                    If dr("IS_SENIOR") = "1" And W_Senior = True Then
                        dSPLIST.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
                    ElseIf dr("IS_SENIOR") = "1" And W_Senior = False Then
                        dSPLIST.Rows(i).DefaultCellStyle.BackColor = Color.LemonChiffon
                    End If
                    i += 1
                    'Else
                    '    MessageBox.Show("Price List Already Exist:" & dr("PriceList"), "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End While
            txtPriceList.Text = ""
            txtPriceDesc.Text = ""
        End If
        dr.Close()
        lblCnt.Text = dSPLIST.Rows.Count
    End Sub
    Private Sub dSPLIST_KeyDown(sender As Object, e As KeyEventArgs) Handles dSPLIST.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dSPLIST.RowCount = 0 Then Exit Sub
            If MessageBox.Show("Do you want to delete SPLIST ?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            dSPLIST.Rows.RemoveAt(dSPLIST.CurrentRow.Index)
            'MessageBox.Show("Price List Remove", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            lblCnt.Text = dSPLIST.Rows.Count
        ElseIf e.KeyCode = Keys.F4 Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            If MessageBox.Show("Do you want to remove non senior SPLIST [Y/N]?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

                Dim str As String = "SELECT * FROM Price_Level_Dtl WHERE IS_SENIOR = '1'"
                Dim cmd As New SqlCommand(str, cn)
                Dim dt As New DataTable
                dt.Load(cmd.ExecuteReader)

                If dt.Rows.Count > 0 Then
                    dSPLIST.Rows.Clear()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        dSPLIST.Rows.Add()
                        dSPLIST("PRICELVL", i).Value = dt.Rows(i).Item("PriceLevel").ToString()
                        dSPLIST("PRICELIST", i).Value = dt.Rows(i).Item("PriceList").ToString()
                        dSPLIST("PL_DESC", i).Value = dt.Rows(i).Item("PriceList_Desc").ToString()
                        dSPLIST("REG1", i).Value = dt.Rows(i).Item("Regular_1").ToString()
                        dSPLIST("REG2", i).Value = dt.Rows(i).Item("Regular_2").ToString()
                        dSPLIST("SP1", i).Value = dt.Rows(i).Item("Special_1").ToString()
                        dSPLIST("SP2", i).Value = dt.Rows(i).Item("Special_2").ToString()
                        dSPLIST("IMG1", i).Value = dt.Rows(i).Item("Imaging_1").ToString()
                        dSPLIST("IMG2", i).Value = dt.Rows(i).Item("Imaging_2").ToString()
                        dSPLIST("UTZ1", i).Value = dt.Rows(i).Item("UTZ_1").ToString()
                        dSPLIST("UTZ2", i).Value = dt.Rows(i).Item("UTZ_2").ToString()
                        dSPLIST("IS_SENIOR", i).Value = dt.Rows(i).Item("IS_SENIOR").ToString()
                        If dt.Rows(i).Item("IS_SENIOR").ToString() = "1" And W_Senior = True Then
                            dSPLIST.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
                        ElseIf dt.Rows(i).Item("IS_SENIOR").ToString() = "1" And W_Senior = False Then
                            dSPLIST.Rows(i).DefaultCellStyle.BackColor = Color.LemonChiffon
                        End If
                    Next
                End If
            End If
            lblCnt.Text = dSPLIST.Rows.Count
            




        End If
    End Sub

    Private Sub btnClear2_Click(sender As Object, e As EventArgs) Handles btnClear2.Click
        If MessageBox.Show("Do you want to Clear Test Codes?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        dIMH.Rows.Clear()
        dIMH.Rows.Add()
    End Sub

    Private Sub dIMH_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dIMH.CellEndEdit
        'Dim cn As New OdbcConnection(cnStr)
        'If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cn As New OdbcConnection(cnStr)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()


        Dim cmd1 As New SqlCommand
        Dim str As String = ""

        str = "SELECT IMH_CODE FROM ITEM_MASTERH WITH(NOLOCK) WHERE IMH_DESC = '" & Replace(dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value, "'", "''") & "' OR IMH_CODE = '" & Replace(dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value, "'", "''") & "' "
        cmd1 = New SqlCommand(str, cn2)
        str = cmd1.ExecuteScalar
        dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = str

        str = "SELECT TOP 1 1 " & _
            "FROM SPLIST_DTI WITH(NOLOCK) " & _
            "WHERE IMH_CODE = '" & dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value & "' "
        cmd1 = New SqlCommand(str, cn2)
        str = cmd1.ExecuteScalar

        If Not str Is Nothing Then
            str = "SELECT IMH_BILLCODE FROM ITEM_MASTERH WITH(NOLOCK) WHERE IMH_CODE = '" & dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value & "' "
            cmd1 = New SqlCommand(str, cn2)
            str = cmd1.ExecuteScalar

            dIMH("IMH_BILLCODE", dIMH.CurrentRow.Index).Value = str
            dIMH.Rows.Add()
            Exit Sub
        End If


        If dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = Nothing Then Exit Sub
        If dSPLIST.Rows.Count = 0 Then
            dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = Nothing
            dIMH("IMH_BILLCODE", dIMH.CurrentRow.Index).Value = Nothing
            MessageBox.Show("Please Select Price Level", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        End If

        If dIMH.CurrentCell.ColumnIndex = 0 Then
            str = "SELECT IMH_CODE FROM ITEM_MASTERH WITH(NOLOCK) WHERE IMH_DESC = '" & Replace(dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value, "'", "''") & "' OR IMH_CODE = '" & Replace(dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value, "'", "''") & "' "
            cmd1 = New SqlCommand(str, cn2)
            str = cmd1.ExecuteScalar
            dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = str


            Dim CurIndex As Integer = dIMH.CurrentRow.Index

            For i As Integer = 0 To dIMH.Rows.Count - 1
                If CurIndex <> i Then
                    If dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = dIMH("IMH_CODE", i).Value Then
                        MessageBox.Show("Item Already Exist", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = Nothing
                        Exit Sub
                    End If
                End If
            Next
            Dim Chk As Boolean = False
            Dim adapt As New SqlDataAdapter
            Dim dt As New DataTable

            For i As Integer = 0 To dSPLIST.Rows.Count - 1
                str = "SELECT DISTINCT A.IMH_CODE, IMH_BILLCODE " & _
                    "FROM  BASIC_PRICE_LVL A WITH(NOLOCK) " & _
                    "LEFT JOIN ITEM_MASTERH B WITH(NOLOCK) ON A.IMH_CODE = B.IMH_CODE " & _
                    "WHERE A.IMH_CODE = '" & dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value & "' AND A.PRICE_LEVEL = '" & dSPLIST("PRICELVL", i).Value & "' "
                adapt = New SqlDataAdapter(str, cn2)
                dt = New DataTable
                adapt.Fill(dt)

                If dt.Rows.Count > 0 Then
                    For ii As Integer = 0 To dt.Rows.Count - 1
                        dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = dt.Rows(ii).Item("IMH_CODE").ToString
                        dIMH("IMH_BILLCODE", dIMH.CurrentRow.Index).Value = dt.Rows(ii).Item("IMH_BILLCODE").ToString
                    Next
                    Chk = True
                Else
                    Chk = False
                End If
            Next

            If Chk = False Then
                dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = Nothing
                dIMH("IMH_BILLCODE", dIMH.CurrentRow.Index).Value = Nothing
                MessageBox.Show("Please provide Basic Price and IMH before creating SPLIST", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            Else
                dIMH.Rows.Add()
            End If

            If ChkTestGrp(dIMH("IMH_BILLCODE", dIMH.CurrentRow.Index).Value) = False Then
                dIMH("IMH_CODE", dIMH.CurrentRow.Index).Value = Nothing
                dIMH("IMH_BILLCODE", dIMH.CurrentRow.Index).Value = Nothing
                MessageBox.Show("Item with invalid test group" & vbNewLine & _
                                "Please Check Test Group", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            cn.Dispose()
        End If
    End Sub

    Private Sub dIMH_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dIMH.EditingControlShowing
        If dIMH.Columns(dIMH.CurrentCell.ColumnIndex).HeaderText = "CODE" Then
            If dIMH.CurrentCell.ColumnIndex = 0 Then
                Dim autoText As TextBox = TryCast(e.Control, TextBox)
                If autoText IsNot Nothing Then
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                    Dim DataCollection As New AutoCompleteStringCollection()
                    AddItems(DataCollection)
                    autoText.CharacterCasing = CharacterCasing.Upper
                    autoText.AutoCompleteCustomSource = DataCollection
                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                End If
            End If
        Else
            Dim text As TextBox = TryCast(e.Control, TextBox)
            text.AutoCompleteCustomSource = Nothing
            text.AutoCompleteSource = AutoCompleteSource.None
            text.AutoCompleteMode = AutoCompleteMode.None
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If dSPLIST.Rows.Count = 0 Then Exit Sub
        If MessageBox.Show("Do you want to save and generate SPLIST?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        pnLoad.Visible = True
        DisableAll()
        RunWorker()
    End Sub
    Private Sub dIMH_KeyDown(sender As Object, e As KeyEventArgs) Handles dIMH.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Do you want to remove testcode?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            dIMH.Rows.RemoveAt(dIMH.CurrentRow.Index)
        End If
    End Sub
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        frmImportIMH.ShowDialog()
    End Sub

    Private Sub dSPLIST_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dSPLIST.CellContentClick

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        dSPLIST.Rows.Clear()
        cbPriceLevel.SelectedIndex = -1
        txtPriceList.Text = ""
        txtPriceDesc.Text = ""
        chkAll.Checked = False
    End Sub

    Public Function isChk(PriceList As String) As Boolean
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT TOP 1 1 FROM SWITCH_SPLIST WHERE COMP_PRICELIST ='" & PriceList & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            Return True
        Else
            Return False
        End If



    End Function

    Private Sub bg1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bg1.DoWork
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim cn3 As New SqlConnection(cnETRS)
        If cn3.State = ConnectionState.Closed Then cn3.Open()

        Dim str As String = "", UNIT_PRICE As String = "", NEW_PRICE As String = "", PRV_PRICE As String = "", SUM_TOTAL As String = ""
        Dim Prct_1 As String = "", Prct_2 As String = "", TEST_GRP As String = "", DIF1 As String = "", DIF2 As String = ""
        Dim cmd As New SqlCommand
        Dim MaxCount As Integer = 0, ProgCount As Integer = 0

        MaxCount = dIMH.RowCount - 1
        Dim BATCH_ID As String = LoadMax()
        Dim dt As New DataTable
        Dim dt2 As New DataTable
        Dim vii As Integer = 0

        Try
            cmd = New SqlCommand("BEGIN TRAN", cn2)
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("BEGIN TRAN", cn3)
            cmd.ExecuteNonQuery()

            str = "INSERT INTO BATCH_SPLIST (BATCH_ID, EFD_DATE, IS_SYNC) " & _
                "VALUES ('" & BATCH_ID & "','" & dtEFD.Value & "','N')"
            cmd = New SqlCommand(str, cn2)
            cmd.ExecuteNonQuery()

            dt.Columns.Add(New DataColumn("SPD_CODE", GetType(String)))
            dt.Columns.Add(New DataColumn("SPD_DESC", GetType(String)))
            dt.Columns.Add(New DataColumn("TEST_GROUP", GetType(String)))
            dt.Columns.Add(New DataColumn("SPD_IMH_CODE", GetType(String)))
            dt.Columns.Add(New DataColumn("SPD_CURR_PRICE", GetType(String)))
            dt.Columns.Add(New DataColumn("SPD_PREV_PRICE", GetType(String)))
            dt.Columns.Add(New DataColumn("SPD_EFD", GetType(String)))
            dt.Columns.Add(New DataColumn("PRICE_LEVEL", GetType(String)))
            dt.Columns.Add(New DataColumn("BASIC_PRICE", GetType(String)))
            dt.Columns.Add(New DataColumn("PERCENTAGE_1", GetType(String)))
            dt.Columns.Add(New DataColumn("DISCOUNT_1", GetType(String)))
            dt.Columns.Add(New DataColumn("PERCENTAGE_2", GetType(String)))
            dt.Columns.Add(New DataColumn("DISCOUNT_2", GetType(String)))

            dt2.Columns.Add(New DataColumn("SPD_CODE", GetType(String)))
            dt2.Columns.Add(New DataColumn("SPD_IMH_CODE", GetType(String)))
            dt2.Columns.Add(New DataColumn("SPD_CURR_PRICE", GetType(String)))
            dt2.Columns.Add(New DataColumn("SPD_EFD", GetType(String)))
            dt2.Columns.Add(New DataColumn("SPD_PREV_PRICE", GetType(String)))
            dt2.Columns.Add(New DataColumn("BATCH_ID", GetType(String)))
            Dim PRC_LIST As String = "", PRICE_LEVEL2 As String = ""

     
            For i As Integer = 0 To dIMH.Rows.Count - 1 '
                If dIMH("IMH_CODE", i).Value = Nothing Then GoTo rEADNEXT
                TEST_GRP = GetTESTGRP(dIMH("IMH_BILLCODE", i).Value)
                For ii As Integer = 0 To dSPLIST.Rows.Count - 1
                    vii = ii
                    If isChk(dSPLIST("PRICELIST", ii).Value) = True Then
                        PRV_PRICE = GetPrvPrice(dSPLIST("PRICELIST", ii).Value, dIMH("IMH_CODE", i).Value)

                        '==========================================================================================
                        '============================== PRICE GENERATION ==========================================
                        If Except_By_TestGrp(dSPLIST("PRICELVL", ii).Value, dSPLIST("PRICELIST", ii).Value, dIMH("IMH_CODE", i).Value, TEST_GRP) = False Then
                            If chkException(dSPLIST("PRICELVL", ii).Value, PRC_LIST, dIMH("IMH_CODE", i).Value) = False Then
                                UNIT_PRICE = "" : NEW_PRICE = ""

                                str = "SELECT COMP_PRICELIST, PRICE_LEVEL FROM SWITCH_SPLIST WHERE ORIG_PRICELIST ='" & dSPLIST("PRICELIST", ii).Value & "' AND TESTGRP = '" & TEST_GRP & "' "
                                Dim cmd3 As New SqlCommand(str, cn2)
                                Dim dt3 As New DataTable
                                dt3.Load(cmd3.ExecuteReader)
                                cmd3.Dispose()

                                Dim IS_SWITCH As Boolean = False
                                If dt3.Rows.Count > 0 Then
                                    PRC_LIST = dt3.Rows(0).Item("COMP_PRICELIST").ToString()
                                    PRICE_LEVEL2 = dt3.Rows(0).Item("PRICE_LEVEL").ToString()
                                    IS_SWITCH = True
                                Else
                                    PRC_LIST = dSPLIST("PRICELIST", ii).Value
                                    PRICE_LEVEL2 = dSPLIST("PRICELVL", ii).Value
                                    IS_SWITCH = False
                                End If


                                If DTI_EXCEPT(dIMH("IMH_CODE", i).Value, dSPLIST("PRICELVL", ii).Value) = False Then
                                    UNIT_PRICE = GetUnitPrice(PRICE_LEVEL2, dIMH("IMH_CODE", i).Value)
                                    NEW_PRICE = GetPrice(dIMH("IMH_CODE", i).Value, UNIT_PRICE, PRC_LIST, PRICE_LEVEL2, TEST_GRP, dSPLIST("IS_SENIOR", ii).Value, IS_SWITCH)
                                Else
                                    If GetDTI(dIMH("IMH_CODE", i).Value, dSPLIST("PRICELVL", ii).Value) = "0" Then GoTo NextLine
                                    NEW_PRICE = GetDTI(dIMH("IMH_CODE", i).Value, PRICE_LEVEL2)
                                    UNIT_PRICE = NEW_PRICE
                                End If
                                If PRV_PRICE = "0" Then
                                    PRV_PRICE = NEW_PRICE
                                End If
                                dt2.Rows.Add(Replace(dSPLIST("PRICELIST", ii).Value, "'", "''"), dIMH("IMH_CODE", i).Value, NEW_PRICE, dtEFD.Value, PRV_PRICE, BATCH_ID)
                            Else
                                NEW_PRICE = GetExceptPrice(dSPLIST("PRICELVL", ii).Value, dSPLIST("PRICELIST", ii).Value, dIMH("IMH_CODE", i).Value)
                                dt2.Rows.Add(Replace(dSPLIST("PRICELIST", ii).Value, "'", "''"), dIMH("IMH_CODE", i).Value, NEW_PRICE, dtEFD.Value, PRV_PRICE, BATCH_ID)
                            End If

                            str = "SELECT A.*, CASE WHEN B.PriceList IS NOT NULL THEN 'N' ELSE 'Y' END IS_STANDARD " & _
                                  "FROM Price_Level_Dtl A WITH(NOLOCK) " & _
                                  "LEFT JOIN PRICE_STANDARD B WITH(NOLOCK) ON A.PriceList = B.PriceList " & _
                                  "WHERE A.PriceList ='" & dSPLIST("PRICELIST", ii).Value & "' AND A.PriceLevel ='" & dSPLIST("PRICELVL", ii).Value & "' "
                            'str = "SELECT * FROM Price_Level_DTL WITH(NOLOCK) WHERE PriceList = '" & dSPLIST("PRICELIST", ii).Value & "' AND PriceLevel = '" & dSPLIST("PRICELVL", ii).Value & "' "
                            cmd = New SqlCommand(str, cn)
                            Dim dr As SqlDataReader = cmd.ExecuteReader

                            If dr.HasRows Then
                                dr.Read()
                                If dr("IS_STANDARD") = "Y" Then
                                    If TEST_GRP = "ULTRASOUND" Then
                                        Prct_1 = CDbl(dr("UTZ_1")) * 100
                                        DIF1 = UNIT_PRICE * (dr("UTZ_1"))
                                        SUM_TOTAL = UNIT_PRICE + (UNIT_PRICE * dr("UTZ_1"))
                                        Prct_2 = CDbl(dr("UTZ_2")) * 100
                                        DIF2 = SUM_TOTAL * (dr("UTZ_2"))
                                    ElseIf TEST_GRP = "IMAGING" Then
                                        Prct_1 = CDbl(dr("Imaging_1")) * 100
                                        DIF1 = UNIT_PRICE * (dr("Imaging_1"))
                                        SUM_TOTAL = UNIT_PRICE + (UNIT_PRICE * dr("Imaging_1"))
                                        Prct_2 = CDbl(dr("Imaging_2")) * 100
                                        DIF2 = SUM_TOTAL * (dr("Imaging_2"))
                                    ElseIf TEST_GRP = "SPECIAL TESTS" Then
                                        Prct_1 = CDbl(dr("Special_1")) * 100
                                        DIF1 = UNIT_PRICE * dr("Special_1")
                                        SUM_TOTAL = UNIT_PRICE + (UNIT_PRICE * dr("Special_1"))
                                        Prct_2 = CDbl(dr("Special_2")) * 100
                                        DIF2 = SUM_TOTAL * dr("Special_2")
                                    Else
                                        Prct_1 = CDbl(dr("Regular_1")) * 100
                                        DIF1 = UNIT_PRICE * (dr("Regular_1"))
                                        SUM_TOTAL = UNIT_PRICE + (UNIT_PRICE * dr("Regular_1"))
                                        Prct_2 = CDbl(dr("Regular_2")) * 100
                                        DIF2 = SUM_TOTAL * (dr("Regular_2"))
                                    End If
                                Else
                                    If TEST_GRP = "ULTRASOUND" Then
                                        Prct_1 = CDbl(dr("UTZ_1")) * 100
                                        DIF1 = (UNIT_PRICE / dr("UTZ_1")) - UNIT_PRICE

                                        Prct_2 = "0.00"
                                        DIF2 = "0.00"
                                    ElseIf TEST_GRP = "IMAGING" Then
                                        Prct_1 = CDbl(dr("Imaging_1")) * 100
                                        DIF1 = (UNIT_PRICE / dr("Imaging_1")) - UNIT_PRICE

                                        Prct_2 = "0.00"
                                        DIF2 = "0.00"
                                    ElseIf TEST_GRP = "SPECIAL TESTS" Then
                                        Prct_1 = CDbl(dr("Special_1")) * 100
                                        DIF1 = (UNIT_PRICE / dr("Special_1")) - UNIT_PRICE

                                        Prct_2 = "0.00"
                                        DIF2 = "0.00"
                                    Else
                                        Prct_1 = CDbl(dr("Regular_1")) * 100
                                        DIF1 = (UNIT_PRICE / dr("Regular_1")) - UNIT_PRICE

                                        Prct_2 = "0.00"
                                        DIF2 = "0.00"
                                    End If
                                End If

                            End If
                            dr.Close()
                            Prct_1 = Prct_1 & "%"
                            Prct_2 = Prct_2 & "%"
                            dt.Rows.Add(Replace(dSPLIST("PRICELIST", ii).Value, "'", "''"), dSPLIST("PL_DESC", ii).Value.ToString, TEST_GRP, _
                                      dIMH("IMH_CODE", i).Value, NEW_PRICE, PRV_PRICE, dtEFD.Value.ToString, dSPLIST("PRICELVL", ii).Value.ToString, _
                                      UNIT_PRICE, Prct_1, DIF1, Prct_2, DIF2)
                        End If
                        '==========================================================================================
                        '==========================================================================================

                    End If

NextLine:
                Next

                dIMH.Rows(i).DefaultCellStyle.BackColor = Color.LawnGreen
                dIMH.Rows(i).Selected = True
                If W_Senior = True Then
                    str = "SELECT TOP 1 1 FROM TEST_WO_SENIOR WITH(NOLOCK) WHERE IMH_CODE = '" & dIMH("IMH_CODE", i).Value & "'"
                    cmd = New SqlCommand(str, cn)
                    str = cmd.ExecuteScalar

                    If str Is Nothing Then
                        str = "INSERT INTO TEST_WO_SENIOR VALUES ('" & dIMH("IMH_CODE", i).Value & "',GETDATE(),GETDATE(),'" & Info.EmpID & "', NULL)"
                    Else
                        str = "UPDATE TEST_WO_SENIOR SET DATE_MODIFIED = GETDATE(), MODIFIED_BY = '" & Info.EmpID & "' WHERE IMH_CODE = '" & dIMH("IMH_CODE", i).Value & "' "
                    End If
                    cmd = New SqlCommand(str, cn2)
                    cmd.ExecuteNonQuery()
                End If
ReadNext:
                If dIMH("IMH_CODE", i).Value <> "" Then
                    str = "INSERT INTO ETRS..UDPATE_LIST (TEST_CODE, UPDATE_DATE, STAT) VALUES ('" & dIMH("IMH_CODE", i).Value & "',GETDATE(),'0')"
                    cmd = New SqlCommand(str, cn3)
                    cmd.ExecuteNonQuery()

                    If W_Senior = False Then
                        str = "SELECT TOP 1 1 FROM NO_SENIOR WITH(NOLOCK) WHERE IMH_CODE = '" & dIMH("IMH_CODE", i).Value & "' "
                        cmd = New SqlCommand(str, cn2)
                        str = cmd.ExecuteScalar

                        If str Is Nothing Then
                            str = "INSERT INTO NO_SENIOR VALUES ('" & dIMH("IMH_CODE", i).Value & "',GETDATE())"
                            cmd = New SqlCommand(str, cn2)
                            cmd.ExecuteNonQuery()
                        Else
                            str = "UPDATE NO_SENIOR SET REQ_DATE= GETDATE() WHERE IMH_CODE ='" & dIMH("IMH_CODE", i).Value & "' "
                            cmd = New SqlCommand(str, cn2)
                            cmd.ExecuteNonQuery()
                        End If
                    End If
                End If
            Next
            dIMH.Rows(0).Selected = True

            Dim blkCopy As New SqlBulkCopy(cn)
            With blkCopy
                .DestinationTableName = "SPLIST_DTL"

                .BulkCopyTimeout = 0
                .ColumnMappings.Add("SPD_CODE", "SPD_CODE")
                .ColumnMappings.Add("SPD_IMH_CODE", "SPD_IMH_CODE")
                .ColumnMappings.Add("SPD_CURR_PRICE", "SPD_CURR_PRICE")
                .ColumnMappings.Add("SPD_EFD", "SPD_EFD")
                .ColumnMappings.Add("SPD_PREV_PRICE", "SPD_PREV_PRICE")
                .ColumnMappings.Add("BATCH_ID", "BATCH_ID")
                .WriteToServer(dt2)
                .Close()
            End With
            cmd = New SqlCommand("COMMIT", cn2)
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("COMMIT", cn3)
            cmd.ExecuteNonQuery()

            GenerateExcel(dt)        
            MessageBox.Show("Done saving SPLIST", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK", cn2)
            cmd.ExecuteNonQuery()
            cmd = New SqlCommand("ROLLBACK", cn3)
            cmd.ExecuteNonQuery()
            MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            dSPLIST.Rows(vii).DefaultCellStyle.BackColor = Color.Red
        End Try
    End Sub

    Private Sub bg1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bg1.RunWorkerCompleted
        '.dispose 
        'frmLoading.Dispose()
        pnLoad.Visible = False
        Enable()
        ClearAll()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub dIMH_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dIMH.CellContentClick

    End Sub
End Class