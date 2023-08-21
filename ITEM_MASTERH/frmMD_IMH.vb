Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports Microsoft.Office.Interop
Public Class frmMD_IMH
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
    Dim vdt As New DataTable
#Region "SUB PROCEDURE /FUNCTIONS"
    Public Sub LoadBranch()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT CODE, Blk, LISGRP, HcLabIPAdd " & _
                    "FROM SAPSET WITH(NOLOCK) " & _
                    "WHERE STAT = 'O' AND  HcLabIPAdd IS NOT NULL  AND HcLabIPAdd <> '0' " & _
                    "AND LisGrp IS NOT NULL " & _
                    "ORDER BY Blk"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            cbBranch.Items.Clear()
            cbBranch.Items.Add("")
            While dr.Read
                cbBranch.Items.Add(dr("Blk"))
            End While
        Else
            d.Rows.Clear()
        End If
        dr.Close()
        cn.Dispose()        
    End Sub
    Public Sub LoadIMH()
        Dim cnODBC As String = "Driver={Microsoft ODBC for Oracle}; " & _
                                                  "Server=(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST =" & GetLISHCLAB(cbBranch.Text) & ")(PORT = 1521))(CONNECT_DATA =(SID = HCLAB))); " & _
                                                  "UID=HCLAB;PWD=HCLAB"
        Dim cn As New OdbcConnection(cnODBC)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT NVL(IMH_CODE, '') IMH_CODE, NVL(IMH_DESC, '') IMH_DESC, NVL(IMH_YTD_SAMT, '0.00') IMH_YTD_SAMT, " & _
                            "NVL(IMH_CURR_P1, '0.00') IMH_CURR_P1, NVL(IMH_PREV_P1, '0.00') IMH_PREV_P1, NVL(IMH_CURR_P2, '0.00') IMH_CURR_P2, " & _
                            "NVL(IMH_PREV_P2, '0.00') IMH_PREV_P2, NVL(IMH_CURR_P3, '0.00') IMH_CURR_P3, NVL(IMH_PREV_P3, '0.00') IMH_PREV_P3, " & _
                            "NVL(IMH_REC_FLAG, '0.00') IMH_REC_FLAG " & _
                            "FROM ITEM_MASTERH " & _
                            "ORDER BY IMH_CODE"

        '"WHERE IMH_CODE IS NOT NULL AND IMH_DESC IS NOT NULL AND IMH_DESC NOT LIKE 'HSF%' " & _
        Dim da As New OdbcDataAdapter(str, cn)
        vdt = New DataTable
        da.Fill(vdt)

        If vdt.Rows.Count > 1 Then
            Dim ii As Integer = 0
            For i As Integer = 0 To vdt.Rows.Count - 1
                d.Rows.Add()
                d("ITEM_CODE", i).Value = vdt.Rows(i).Item("IMH_CODE").ToString
                d("ITEM_DESC", i).Value = vdt.Rows(i).Item("IMH_DESC").ToString
                If vdt.Rows(i).Item("IMH_REC_FLAG").ToString = "N" Then
                    d("VALID", i).Value = True
                    d.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
                Else
                    d("VALID", i).Value = False
                    d.Rows(i).DefaultCellStyle.BackColor = Color.White
                End If
                'd("VALID", i).Value = vdt.Rows(i).Item("").ToString
                d("UNIT_PRICE", i).Value = vdt.Rows(i).Item("IMH_YTD_SAMT").ToString
                d("CURR_PRICE1", i).Value = vdt.Rows(i).Item("IMH_CURR_P1").ToString
                d("PRV_PRICE1", i).Value = vdt.Rows(i).Item("IMH_PREV_P1").ToString
                d("CURR_PRICE2", i).Value = vdt.Rows(i).Item("IMH_CURR_P2").ToString
                d("PRV_PRICE2", i).Value = vdt.Rows(i).Item("IMH_PREV_P2").ToString
                d("CURR_PRICE3", i).Value = vdt.Rows(i).Item("IMH_CURR_P3").ToString
                d("PRV_PRICE3", i).Value = vdt.Rows(i).Item("IMH_PREV_P3").ToString
            Next
        End If
        cn.Dispose()
    End Sub
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmMD_IMH_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBranch()        
    End Sub
 
    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        If txtCode.Text <> "" Then
            Dim Result() As DataRow

            Try
                Result = vdt.Select("IMH_CODE LIKE '%" & Replace(txtCode.Text, "'", "''") & "%' OR IMH_DESC LIKE '%" & Replace(txtCode.Text, "'", "''") & "%' ")

                If Result.Count > 0 Then
                    d.Rows.Clear()
                    Dim i As Integer = 0
                    For Each row As DataRow In Result
                        d.Rows.Add()
                        d("ITEM_CODE", i).Value = row("IMH_CODE")
                        d("ITEM_DESC", i).Value = row("IMH_DESC")
                        If row(9) = "N" Then
                            d("VALID", i).Value = True
                            d.Rows(i).DefaultCellStyle.BackColor = Color.White
                        Else
                            d("VALID", i).Value = False
                            d.Rows(i).DefaultCellStyle.BackColor = Color.Bisque
                        End If
                        d("UNIT_PRICE", i).Value = Format(IIf(IsDBNull(CDbl(row("IMH_YTD_SAMT"))) = True, "0.0", CDbl(row("IMH_YTD_SAMT"))), "N2")
                        d("CURR_PRICE1", i).Value = Format(IIf(IsDBNull(CDbl(row("IMH_CURR_P1"))) = True, "0.0", CDbl(row("IMH_CURR_P1"))), "N2")
                        d("PRV_PRICE1", i).Value = Format(IIf(IsDBNull(CDbl(row("IMH_PREV_P1"))) = True, "0.0", CDbl(row("IMH_PREV_P1"))), "N2")
                        d("CURR_PRICE2", i).Value = Format(IIf(IsDBNull(CDbl(row("IMH_CURR_P2"))) = True, "0.0", CDbl(row("IMH_CURR_P2"))), "N2")
                        d("PRV_PRICE2", i).Value = Format(IIf(IsDBNull(CDbl(row("IMH_PREV_P2"))) = True, "0.0", CDbl(row("IMH_PREV_P2"))), "N2")
                        d("CURR_PRICE3", i).Value = Format(IIf(IsDBNull(CDbl(row("IMH_CURR_P3"))) = True, "0.0", CDbl(row("IMH_CURR_P3"))), "N2")
                        d("PRV_PRICE3", i).Value = Format(IIf(IsDBNull(CDbl(row("IMH_PREV_P3"))) = True, "0.0", CDbl(row("IMH_PREV_P3"))), "N2")
                        'd("UNIT_PRICE", i).Value = Format(CDbl(row(2)), "N2")
                        'd("CURR_PRICE1", i).Value = Format(CDbl(row(3)), "N2")
                        'd("PRV_PRICE1", i).Value = Format(CDbl(row(4)), "N2")
                        'd("CURR_PRICE2", i).Value = Format(CDbl(row(5)), "N2")
                        'd("PRV_PRICE2", i).Value = Format(CDbl(row(6)), "N2")
                        'd("CURR_PRICE3", i).Value = Format(CDbl(row(7)), "N2")
                        'd("PRV_PRICE3", i).Value = Format(CDbl(row(8)), "N2")
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

    Private Sub cbBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBranch.SelectedIndexChanged
        If cbBranch.Text <> "" Then
            LoadIMH()
        Else
            d.Rows.Clear()
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim saveFile As New SaveFileDialog

        Dim xlApp As New Excel.Application
        Dim xlWB As Excel.Workbook
        Dim xlWS As Excel.Worksheet

        Dim misValue As Object = System.Reflection.Missing.Value
        xlWB = xlApp.Workbooks.Add(misValue)
        xlWS = xlWB.Sheets("Sheet1")

        If (Not System.IO.Directory.Exists("D:\Excel Files")) Then
            'CREATE PATH 
            System.IO.Directory.CreateDirectory("D:\Excel Files")
        End If

        saveFile.InitialDirectory = "D:\EXCEL FILES"
        saveFile.Filter = "Excel files (*.xls or .xlsx)|.xls;*.xlsx"
        If saveFile.ShowDialog = Windows.Forms.DialogResult.No Then Exit Sub

        'xlApp.Visible = True
        xlWS.Cells(3, 1) = "ITEM CODE"
        xlWS.Cells(3, 2) = "ITEM DESC"
        xlWS.Cells(3, 3) = "IMH_REC_FLAG"
        xlWS.Cells(3, 4) = "UNIT PRICE"
        xlWS.Cells(3, 5) = "CURR PRICE1"
        xlWS.Cells(3, 6) = "PREVIOUS PRICE2"
        xlWS.Cells(3, 7) = "CURR PRICE2"
        xlWS.Cells(3, 8) = "PREVIOUS PRICE2"
        xlWS.Cells(3, 9) = "CURR PRICE3"
        xlWS.Cells(3, 10) = "PREVIOUS PRICE3"
        xlWS.Range("A3:J3").EntireColumn.AutoFit()
        xlWS.Range("A3:J3").Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        xlWS.Range("A3:J3").HorizontalAlignment = Excel.Constants.xlCenter
        xlWS.Range("A3:J3").Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LawnGreen)
        xlWS.Range("A3:J3").Font.Bold = True
        xlWS.Range("A3:J3").Font.Color = Color.Blue

        Dim xlRow As Integer = 4

        For i As Integer = 0 To d.Rows.Count - 1
            xlWS.Cells(xlRow, 1) = "'" & d("ITEM_CODE", i).Value
            xlWS.Cells(xlRow, 2) = "'" & d("ITEM_DESC", i).Value
            If d("VALID", i).Value = True Then
                xlWS.Cells(xlRow, 3) = "N"
                'xlWS.Range(xlWS.Cells(xlRow, 1), xlWS.Cells(xlRow, 10)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            Else
                xlWS.Cells(xlRow, 3) = "X"
                xlWS.Range(xlWS.Cells(xlRow, 1), xlWS.Cells(xlRow, 10)).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red)
            End If
            xlWS.Cells(xlRow, 4) = "'" & d("UNIT_PRICE", i).Value
            xlWS.Cells(xlRow, 5) = "'" & d("CURR_PRICE1", i).Value
            xlWS.Cells(xlRow, 6) = "'" & d("PRV_PRICE1", i).Value
            xlWS.Cells(xlRow, 7) = "'" & d("CURR_PRICE2", i).Value
            xlWS.Cells(xlRow, 8) = "'" & d("PRV_PRICE2", i).Value
            xlWS.Cells(xlRow, 9) = "'" & d("CURR_PRICE3", i).Value
            xlWS.Cells(xlRow, 10) = "'" & d("PRV_PRICE3", i).Value
            xlRow += 1
        Next
        xlWS.Range(xlWS.Cells(4, 1), xlWS.Cells(xlRow, 10)).EntireColumn.AutoFit()
        xlWS.Range(xlWS.Cells(4, 1), xlWS.Cells(xlRow, 10)).Borders.LineStyle = Excel.XlLineStyle.xlContinuous
        xlWS.Range(xlWS.Cells(4, 1), xlWS.Cells(xlRow, 2)).HorizontalAlignment = Excel.Constants.xlLeft
        xlWS.Range(xlWS.Cells(4, 3), xlWS.Cells(xlRow, 10)).HorizontalAlignment = Excel.Constants.xlCenter
        xlWS.SaveAs(saveFile.FileName)
        MsgBox("Done Generationg Report")


        xlWB.Close()        
        xlApp.Quit()

        releaseObject(xlWB)
        releaseObject(xlWS)
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
    Private Sub d_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d.CellContentClick

    End Sub

    Private Sub btnClose2_Click(sender As Object, e As EventArgs) Handles btnClose2.Click
        Me.Dispose()
    End Sub
End Class