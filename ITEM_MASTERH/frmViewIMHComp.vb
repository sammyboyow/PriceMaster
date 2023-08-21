Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmViewIMHComp

    Private Sub frmViewSplistComp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub frmViewSplistComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        IMHComp(txtBatchID.Text)
    End Sub

    Public Sub IMHComp(ByVal BatchID As String)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim i As Integer = 0

        str =
            "SELECT	ISNULL(S.Blk,'')MOTHER_BRANCH,ISNULL(H.IMH_CODE,'')IMH_CODE,ISNULL(H.IMH_DESC,'')IMH_DESC,ISNULL(H.IMH_TYPE,'')IMH_TYPE,ISNULL(H.IMH_PDGROUP,'')IMH_PDGROUP, " & _
            "		ISNULL(H.IMH_BILLCODE,'')IMH_BILLCODE,ISNULL(H.IMH_YTD_SAMT,0)IMH_YTD_SAMT,ISNULL(H.IMH_CURR_P1,0)IMH_CURR_P1,ISNULL(H.IMH_EFD_P1,'')IMH_EFD_P1,ISNULL(H.IMH_PREV_P1,0)IMH_PREV_P1, " & _
            "		ISNULL(H.IMH_CURR_P2,0)IMH_CURR_P2,ISNULL(H.IMH_EFD_P2,'')IMH_EFD_P2,ISNULL(H.IMH_PREV_P2,0)IMH_PREV_P2,ISNULL(H.IMH_CURR_P3,0)IMH_CURR_P3,ISNULL(H.IMH_EFD_P3,'')IMH_EFD_P3, " & _
            "		ISNULL(H.IMH_PREV_P3,0)IMH_PREV_P3,ISNULL(H.IMH_FIXED_PRICE,'')IMH_FIXED_PRICE,ISNULL(H.IMH_REC_FLAG,'')IMH_REC_FLAG,ISNULL(H.IMH_UPDATE_BY,'')IMH_UPDATE_BY, " & _
            "		ISNULL(H.IMH_UPDATE_ON,'')IMH_UPDATE_ON,ISNULL(H.MODIFIED_ON,'')MODIFIED_ON,ISNULL(H.BATCH_ID,'')BATCH_ID " & _
            "FROM dbo.TMP_ITEM_MASTERH H " & _
            "LEFT JOIN [172.30.0.17].HPCOMMON.DBO.SAPSET S ON S.CODE = H.MOTHER_BRANCH COLLATE DATABASE_DEFAULT " & _
            "WHERE H.BATCH_ID = '" & BatchID & "' "
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader
        D.Rows.Clear()
        If dr.HasRows Then
            While dr.Read
                D.Rows.Add()
                D("MOTHER_BRANCH", i).Value = dr("MOTHER_BRANCH")
                D("IMH_CODE", i).Value = dr("IMH_CODE")
                D("IMH_DESC", i).Value = dr("IMH_DESC")
                D("IMH_TYPE", i).Value = dr("IMH_TYPE")
                D("IMH_PDGROUP", i).Value = dr("IMH_PDGROUP")
                D("IMH_BILLCODE", i).Value = dr("IMH_BILLCODE")
                D("IMH_YTD_SAMT", i).Value = dr("IMH_YTD_SAMT")
                D("IMH_CURR_P1", i).Value = dr("IMH_CURR_P1")
                D("IMH_EFD_P1", i).Value = dr("IMH_EFD_P1")
                D("IMH_PREV_P1", i).Value = dr("IMH_PREV_P1")
                D("IMH_CURR_P2", i).Value = dr("IMH_CURR_P2")
                D("IMH_EFD_P2", i).Value = dr("IMH_EFD_P2")
                D("IMH_PREV_P2", i).Value = dr("IMH_PREV_P2")
                D("IMH_CURR_P3", i).Value = dr("IMH_CURR_P3")
                D("IMH_EFD_P3", i).Value = dr("IMH_EFD_P3")
                D("IMH_PREV_P3", i).Value = dr("IMH_PREV_P3")
                D("IMH_FIXED_PRICE", i).Value = dr("IMH_FIXED_PRICE")
                D("IMH_REC_FLAG", i).Value = dr("IMH_REC_FLAG")
                D("IMH_UPDATE_BY", i).Value = dr("IMH_UPDATE_BY")
                D("IMH_UPDATE_ON", i).Value = dr("IMH_UPDATE_ON")
                D("MODIFIED_ON", i).Value = dr("MODIFIED_ON")
                D("BATCH_ID", i).Value = dr("BATCH_ID")
                i += 1
            End While
        End If

        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        D.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Try
            Dim rng As Integer = 0
            For i As Integer = 0 To D.Rows.Count - 1
                rng += 1
            Next
            If D.Rows.Count = 0 Then MsgBox("Nothing to Export") : Exit Sub
            Dim xlexcel As Microsoft.Office.Interop.Excel.Application = New Excel.Application
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook = xlexcel.Workbooks.Add

            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlWorkBook.Sheets.Add()
            xlWorkSheet = xlWorkBook.Sheets(1)

            xlWorkSheet.Activate()

            xlWorkSheet.Range("A2:M2").Font.Bold = True
            xlWorkSheet.Range("A3:M3").Font.Bold = True






            xlWorkSheet.Range("A1").Select()
            xlWorkSheet.Range("A2:A2").Value = "PRICE LIST"
            xlWorkSheet.Range("A2:G2").MergeCells = True

            xlWorkSheet.Range("I2").Select()
            xlWorkSheet.Range("I2:I2").Value = "BASIC PRICE"
            xlWorkSheet.Range("I2:M2").MergeCells = True
            xlWorkSheet.Range("H:H").ColumnWidth = 3.0
            xlWorkSheet.Range("A:M").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            xlWorkSheet.Range("A:M").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            copyAlltoClipboard()
            xlWorkSheet.Range("A2:M" & rng + 3).Borders.LineStyle = 1

            xlWorkSheet.Range("A:Z").NumberFormat = "@"
            Dim cr As Excel.Range = DirectCast(xlWorkSheet.Cells(3, 1), Excel.Range)
            cr.Select()
            xlWorkSheet.PasteSpecial(cr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, True)

            xlWorkSheet.Range("H3:H3").Value = ""
            xlWorkSheet.Range("A2:A2").Interior.Color = RGB(141, 180, 226)
            xlWorkSheet.Range("I2:I2").Interior.Color = RGB(141, 180, 226)
            xlWorkSheet.Range("A3:G3").Interior.Color = RGB(250, 191, 143)
            xlWorkSheet.Range("I3:M3").Interior.Color = RGB(250, 191, 143)
            xlWorkSheet.Cells.Select()

            xlWorkSheet.Columns.EntireColumn.WrapText = False
            xlWorkSheet.Columns.EntireColumn.AutoFit()

            xlexcel.Visible = True
            MsgBox("Done", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        D.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText
    End Sub
    Private Sub copyAlltoClipboard()
        If D.RowCount = 0 Then Exit Sub
        D.SelectAll()
        Dim dataObj As DataObject = D.GetClipboardContent()
        If dataObj IsNot Nothing Then
            Clipboard.SetDataObject(dataObj)
        End If
    End Sub

    Private Sub btnForSync_Click(sender As Object, e As EventArgs) Handles btnForSync.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim i As Integer = 0
        Try


            str = "BEGIN TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            str =
                "UPDATE dbo.TMP_ITEM_MASTERH SET IS_SYNC = 'N' WHERE BATCH_ID = '" & txtBatchID.Text & "' AND IS_SYNC = 'P' "
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            str =
                "INSERT INTO dbo.FOR_SYNC_LOGS(BATCH_ID,EMPID,SYNC_TIME) " &
                "VALUES('" & txtBatchID.Text & "','" & Info.EmpID & "',GETDATE()) "
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            str = "COMMIT TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            MsgBox("DONE.")
            Me.Dispose()

        Catch ex As Exception
            str = "IF @@TRANCOUNT > 0 ROLLBACK TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            MsgBox(ex.Message)
        End Try
        
        cmd.Dispose()
        cn.Dispose()
    End Sub
End Class