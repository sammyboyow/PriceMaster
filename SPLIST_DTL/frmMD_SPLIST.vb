Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports Microsoft.Office.Interop
Public Class frmMD_SPLIST
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
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        'Dim str As String = "SELECT CODE, Blk, LISGRP, HcLabIPAdd " & _
        '            "FROM HPCOMMON..SAPSET WITH(NOLOCK) " & _
        '            "WHERE STAT = 'O' AND  HcLabIPAdd IS NOT NULL  AND HcLabIPAdd <> '0' " & _
        '            "AND LisGrp IS NOT NULL " & _
        '            "ORDER BY Blk"
        Dim str As String = "SELECT DISTINCT Mother_Branch " & _
                            "FROM Price_Level_Hdr WITH(NOLOCK) " & _
                            "WHERE PriceType = 'N' " & _
                            "ORDER BY Mother_Branch"
        Dim cmd As New SqlCommand(Str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            cbBranch.Items.Clear()
            cbBranch.Items.Add("")
            While dr.Read
                cbBranch.Items.Add(dr("Mother_Branch"))
            End While
        Else
            d.Rows.Clear()
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Sub LoadSP_PRICELIST()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT PriceLevel FROM Price_Level_Dtl WITH(NOLOCK) ORDER BY PriceLevel"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim c As New AutoCompleteStringCollection()
        If dr.HasRows Then
            c.Clear()
            While dr.Read
                c.Add(dr("PriceLevel"))
            End While
        Else
            c.Clear()
        End If
        dr.Close()
        cn.Dispose()
        txtSPCODE.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtSPCODE.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtSPCODE.AutoCompleteCustomSource = c
    End Sub
    Public Sub GetDelete(dt As DataTable)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", BATCH_ID As String = "", DELETE_SCRIPT As String = ""
        Dim cmd As New SqlCommand

        Try
            str = "SELECT (ISNULL(MAX(BATCH_ID), 0) + 1) BATCH_ID FROM BATCH_SPLIST WITH(NOLOCK)"
            cmd = New SqlCommand(str, cn)
            BATCH_ID = cmd.ExecuteScalar

            cmd = New SqlCommand("BEGIN TRAN", cn)
            cmd.ExecuteNonQuery()

            For i As Integer = 0 To dt.Rows.Count - 1
                DELETE_SCRIPT = "DELETE SPLIST_DTL WHERE SPD_CODE = '" & dt.Rows(i).Item("SPD_CODE").ToString & "' AND SPD_IMH_CODE = '" & dt.Rows(i).Item("SPD_IMH_CODE").ToString & "' "
                str = "INSERT INTO DELETE_SCRIPT_SPLIST VALUES ('" & BATCH_ID & "','" & dt.Rows(i).Item("SPD_CODE").ToString & "', " & _
                    "'" & dt.Rows(i).Item("SPD_IMH_CODE").ToString & "','" & DELETE_SCRIPT & "')"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()
            Next
            cmd = New SqlCommand("COMMIT TRAN", cn)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK TRAN", cn)
            cmd.ExecuteNonQuery()
        End Try
        cn.Dispose()
        cmd.Dispose()
    End Sub
    Dim vdt As New DataTable
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim saveFile As New SaveFileDialog

        If System.IO.Directory.Exists("D:\Excel Files") = False Then
            System.IO.Directory.CreateDirectory("D:\Excel Files")
        End If
        saveFile.InitialDirectory = "D:\EXCEL FILES"
        saveFile.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx"

        Dim xlApp As New Excel.Application
        Dim xlWB As Excel.Workbook
        Dim xlWS As Excel.Worksheet

        Dim MisValue As Object = System.Reflection.Missing.Value
        xlWB = xlApp.Workbooks.Add(MisValue)
        xlWS = xlWB.Sheets("Sheet1")

        If saveFile.ShowDialog = Windows.Forms.DialogResult.No Then Exit Sub

        xlWS.Cells(3, 1) = "SPD_CODE"
        xlWS.Cells(3, 2) = "SPD_IMH_CODE"
        xlWS.Cells(3, 3) = "CURR_PRICE"
        xlWS.Cells(3, 4) = "EFD_DATE"
        xlWS.Cells(3, 5) = "SPD_PREV_PRICE"
        xlWS.Range("A3:E3").EntireColumn.AutoFit()
        xlWS.Range("A3:E3").Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        xlWS.Range("A3:E3").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LawnGreen)
        xlWS.Range("A3:E3").Font.Bold = True
        xlWS.Range("A3:E3").Font.Color = Color.Blue

        Dim xlRow As Integer = 4
        For i As Integer = 0 To d.RowCount - 1
            xlWS.Cells(xlRow, 1) = d("SPD_CODE", i).Value
            xlWS.Cells(xlRow, 2) = d("SPD_IMH_CODE", i).Value
            xlWS.Cells(xlRow, 3) = d("SPD_CURR_PRICE", i).Value
            xlWS.Cells(xlRow, 4) = d("EFD_DATE", i).Value
            xlWS.Cells(xlRow, 5) = d("SPD_PRV_PRICE", i).Value
            xlRow += 1
        Next
        xlWS.Range(xlWS.Cells(4, 1), xlWS.Cells(xlRow, 5)).EntireColumn.AutoFit()
        xlWS.Range(xlWS.Cells(4, 1), xlWS.Cells(xlRow, 5)).HorizontalAlignment = Excel.Constants.xlCenter
        xlWS.Range(xlWS.Cells(4, 1), xlWS.Cells(xlRow, 5)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        xlWS.SaveAs(saveFile.FileName)
        MsgBox("Done Generationg Report")
        xlWB.Close()
        xlApp.Quit()

        releaseObject(xlWS)
        releaseObject(xlWB)
        releaseObject(xlApp)
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
    Private Sub frmMD_SPLIST_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBranch()
        LoadSP_PRICELIST()
    End Sub

    Private Sub cbBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBranch.SelectedIndexChanged
        If cbBranch.Text = "" Then
            cbBranchList.Items.Clear()
            d.Rows.Clear()
            txtSPCODE.Text = ""
            txtSPDESC.Text = ""
            txtSearch.Text = ""
        Else
            Dim cn As New SqlConnection(cnSAP)
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim str As String = ""
            Dim adapt As New SqlDataAdapter
            Dim dt2 As New DataTable

            str = "SELECT Blk, HcLabIPAdd " & _
                "FROM SAPSet " & _
                "WHERE LisGrp = (SELECT LisGrp FROM SAPSet WHERE blk = '" & cbBranch.Text & "') AND STAT = 'O' AND Code <> '008' " & _
                "ORDER BY Blk"
            adapt = New SqlDataAdapter(str, cn)
            dt2 = New DataTable
            adapt.Fill(dt2)

            If dt2.Rows.Count > 0 Then
                cbBranchList.Items.Clear()
                cbBranchList.Items.Add("")
                For i As Integer = 0 To dt2.Rows.Count - 1
                    cbBranchList.Items.Add(dt2.Rows(i).Item("Blk").ToString)
                Next
            Else
                cbBranchList.Items.Clear()
            End If
        End If
    End Sub

    Private Sub txtSPCODE_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSPCODE.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT PriceList, PriceList_Desc FROM Price_Level_Dtl " & _
                                "WHERE PriceList = '" & Replace(txtSPCODE.Text, "'", "''") & "' OR PriceList_Desc = '" & Replace(txtSPCODE.Text, "'", "''") & "' " & _
                                "ORDER BY PriceList"
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                dr.Read()
                txtSPCODE.Text = dr("PriceList")
                txtSPDESC.Text = dr("PriceList_Desc")
            Else
                txtSPCODE.Text = ""
                txtSPDESC.Text = ""
            End If
            dr.Close()
            cn.Dispose()
        End If
    End Sub

    Private Sub txtSPCODE_TextChanged(sender As Object, e As EventArgs) Handles txtSPCODE.TextChanged
        If txtSPCODE.Text = "" Then
            txtSPDESC.Text = ""
        End If
    End Sub
    Private Sub btnLOAD_Click(sender As Object, e As EventArgs) Handles btnLOAD.Click
        If cbBranch.Text = "" Then MessageBox.Show("Please select branch to Load", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        'Dim cnODBC As String = "Driver={Microsoft ODBC for Oracle}; " & _
        '                       "Server=(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST =" & GetLISHCLAB(cbBranch.Text) & ")(PORT = 1521))(CONNECT_DATA =(SID = HCLAB))); " & _
        '                       "UID=HCLAB;PWD=HCLAB"
        'Dim cn As New OdbcConnection(cnODBC)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim adapt As New SqlDataAdapter
        Dim str As String = ""
        Dim dt2 As New DataTable
        Dim SPD_CODE = ""
        vdt = New DataTable

        Try          
            If chkALL.Checked = True Then
                str = "SELECT PriceList FROM Price_Level_Dtl WITH(NOLOCK) WHERE PriceLevel = '" & txtSPCODE.Text & "' "
                adapt = New SqlDataAdapter(str, cn2)
                Dim dt As New DataTable
                dt = New DataTable
                adapt.Fill(dt)

                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        If i = 0 Then
                            SPD_CODE = "'" & dt.Rows(i).Item("PriceList").ToString & "'"
                        Else
                            SPD_CODE = SPD_CODE & ",'" & dt.Rows(i).Item("PriceList").ToString & "'"
                        End If
                    Next
                End If
            Else
                SPD_CODE = "'" & txtSPCODE.Text & "'"
            End If

            str = "SELECT * FROM CONSOLIDATED_SPLIST WITH(NOLOCK) WHERE SPD_CODE IN (" & SPD_CODE & ") AND BRANCH_CODE = '" & GetCode(cbBranch.Text) & "' ORDER BY SPD_IMH_CODE, SPD_CODE "
            'str = "SELECT * FROM SPLIST_DTL WHERE SPD_CODE IN (" & SPD_CODE & ") ORDER BY SPD_IMH_CODE, SPD_CODE"
            Dim da As New SqlDataAdapter(str, cn)
            da.Fill(vdt)
            If vdt.Rows.Count > 0 Then
                d.Rows.Clear()
                For i As Integer = 0 To vdt.Rows.Count - 1
                    d.Rows.Add()
                    d("SPD_CODE", i).Value = IIf(IsDBNull(vdt.Rows(i).Item("SPD_CODE").ToString) = True, Nothing, vdt.Rows(i).Item("SPD_CODE").ToString)
                    d("SPD_IMH_CODE", i).Value = IIf(IsDBNull(vdt.Rows(i).Item("SPD_IMH_CODE").ToString) = True, Nothing, vdt.Rows(i).Item("SPD_IMH_CODE").ToString)
                    d("SPD_CURR_PRICE", i).Value = IIf(IsDBNull(Format(CDbl(vdt.Rows(i).Item("SPD_CURR_PRICE").ToString), "N2")) = True, "0", Format(CDbl(vdt.Rows(i).Item("SPD_CURR_PRICE").ToString), "N2"))
                    d("EFD_DATE", i).Value = IIf(IsDBNull(Format(CDate(vdt.Rows(i).Item("SPD_EFD").ToString), "MM/dd/yyyy")) = True, Nothing, Format(CDate(vdt.Rows(i).Item("SPD_EFD").ToString), "MM/dd/yyyy"))
                    d("SPD_PRV_PRICE", i).Value = IIf(IsDBNull(Format(CDbl(vdt.Rows(i).Item("SPD_PREV_PRICE").ToString), "N2")) = True, "0", Format(CDbl(vdt.Rows(i).Item("SPD_PREV_PRICE").ToString), "N2"))
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim Result() As DataRow
            Try
                Result = vdt.Select("SPD_IMH_CODE LIKE '%" & Replace(txtSearch.Text, "'", "''") & "%'")
                If Result.Count > 0 Then
                    d.Rows.Clear()
                    Dim i As Integer = 0
                    For Each row As DataRow In Result
                        d.Rows.Add()
                        d("SPD_CODE", i).Value = row(0)
                        d("SPD_IMH_CODE", i).Value = row(1)
                        d("SPD_CURR_PRICE", i).Value = row(2)
                        d("EFD_DATE", i).Value = Format(CDate(row(3)), "MM/dd/yyyy")
                        d("SPD_PRV_PRICE", i).Value = Format(CDbl(row(4)), "N2")
                        i += 1
                    Next
                Else
                    d.Rows.Clear()
                End If
            Catch ex As Exception
                d.Rows.Clear()
            End Try
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "" Then
            Dim Result() As DataRow
            Result = vdt.Select("")
            If Result.Count > 0 Then
                d.Rows.Clear()
                Dim i As Integer = 0
                For Each row As DataRow In Result
                    d.Rows.Add()
                    d("SPD_CODE", i).Value = row(0)
                    d("SPD_IMH_CODE", i).Value = row(1)
                    d("SPD_CURR_PRICE", i).Value = row(2)
                    d("EFD_DATE", i).Value = Format(CDate(row(3)), "MM/dd/yyyy")
                    d("SPD_PRV_PRICE", i).Value = Format(CDbl(row(4)), "N2")
                    i += 1
                Next
            Else
                d.Rows.Clear()
            End If
        End If
    End Sub
End Class