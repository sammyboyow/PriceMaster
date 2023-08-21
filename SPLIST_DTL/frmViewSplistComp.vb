Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmViewSplistComp

    Private Sub frmViewSplistComp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmViewSplistComp_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        SPComp(txtBatchID.Text)
    End Sub

    Public Sub SPComp(ByVal BatchID As String)

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim i As Integer = 0
        D.Columns.Clear()
        str =
            "SELECT S.SPD_CODE, S.SPD_IMH_CODE , S.SPD_CURR_PRICE,  S.SPD_CURR_PRICE, S.SPD_EFD , S.SPD_PREV_PRICE,  S.SPD_PREV_PRICE, S.MODIFIED_ON , S.BATCH_ID , S.SPD_DESC, S.TEST_GROUP, S.PRICE_LEVEL, S.BASIC_PRICE,   S.PERCENTAGE1,  S.PERCENTAGE2 " & _
            "FROM SPLIST_DTL S WITH (NOLOCK) " & _
            "LEFT JOIN dbo.PRICE_LEVEL_ORDER L ON L.PRICELEVEL = S.PRICE_LEVEL " & _
            "WHERE S.BATCH_ID = '" & BatchID & "' " & _
            "ORDER BY S.SPD_IMH_CODE, L.ORDR,S.SPD_CODE "
            '"SELECT	ISNULL(SPD_CODE,'')SPD_CODE,ISNULL(SPD_IMH_CODE,'')SPD_IMH_CODE,ISNULL(SPD_CURR_PRICE,0)SPD_CURR_PRICE, " & _
        '"		ISNULL(SPD_EFD,'')SPD_EFD,ISNULL(SPD_PREV_PRICE,0)SPD_PREV_PRICE,ISNULL(MODIFIED_ON,'')MODIFIED_ON, " & _
        '"		ISNULL(BATCH_ID,'')BATCH_ID,ISNULL(SPD_DESC,'')SPD_DESC,ISNULL(TEST_GROUP,'')TEST_GROUP,ISNULL(PRICE_LEVEL,'')PRICE_LEVEL, " & _
        '"		ISNULL(BASIC_PRICE,0)BASIC_PRICE,ISNULL(PERCENTAGE1,0)PERCENTAGE1,ISNULL(PERCENTAGE2,0)PERCENTAGE2 " & _
        '"FROM SPLIST_DTL WITH (NOLOCK) " & _
        '"WHERE ISNULL(BATCH_ID,'') = REPLACE('" & BatchID & "','''','''''') ORDER BY SPD_IMH_CODE,PRICE_LEVEL"
        cmd = New SqlCommand(str, cn)
        Dim dt As New DataTable
        dt.Clear()
        dt.Load(cmd.ExecuteReader)



        D.DataSource = dt


        cmd.Dispose()
        cn.Dispose()
        'Dim cn As New SqlConnection(cnSQL)
        'If cn.State = ConnectionState.Closed Then cn.Open()
        'Dim str As String = ""
        'Dim cmd As New SqlCommand
        'Dim dr As SqlDataReader
        'Dim i As Integer = 0

        'str =
        '    "SELECT	ISNULL(SPD_CODE,'')SPD_CODE,ISNULL(SPD_IMH_CODE,'')SPD_IMH_CODE,ISNULL(SPD_CURR_PRICE,0)SPD_CURR_PRICE, " & _
        '    "		ISNULL(SPD_EFD,'')SPD_EFD,ISNULL(SPD_PREV_PRICE,0)SPD_PREV_PRICE,ISNULL(MODIFIED_ON,'')MODIFIED_ON, " & _
        '    "		ISNULL(BATCH_ID,'')BATCH_ID,ISNULL(SPD_DESC,'')SPD_DESC,ISNULL(TEST_GROUP,'')TEST_GROUP,ISNULL(PRICE_LEVEL,'')PRICE_LEVEL, " & _
        '    "		ISNULL(BASIC_PRICE,0)BASIC_PRICE,ISNULL(PERCENTAGE1,0)PERCENTAGE1,ISNULL(PERCENTAGE2,0)PERCENTAGE2 " & _
        '    "FROM SPLIST_DTL WITH (NOLOCK) " & _
        '    "WHERE ISNULL(BATCH_ID,'') = REPLACE('" & BatchID & "','''','''''') ORDER BY SPD_IMH_CODE,PRICE_LEVEL"
        'cmd = New SqlCommand(str, cn)
        'cmd.CommandTimeout = 0
        'dr = cmd.ExecuteReader
        'D.Rows.Clear()
        'If dr.HasRows Then
        '    While dr.Read
        '        D.Rows.Add()
        '        D("SPD_CODE", i).Value = dr("SPD_CODE")
        '        D("SPD_DESC", i).Value = dr("SPD_DESC")
        '        D("TEST_GROUP", i).Value = dr("TEST_GROUP")
        '        D("SPD_IMH_CODE", i).Value = dr("SPD_IMH_CODE")
        '        D("SPD_CURR_PRICE", i).Value = dr("SPD_CURR_PRICE")
        '        D("SPD_EFD", i).Value = dr("SPD_EFD")
        '        D("SPD_PREV_PRICE", i).Value = dr("SPD_PREV_PRICE")
        '        D("PRICE_LEVEL", i).Value = dr("PRICE_LEVEL")
        '        D("BASIC_PRICE", i).Value = dr("BASIC_PRICE")
        '        D("PERCENTAGE1", i).Value = dr("PERCENTAGE1")
        '        D("PERCENTAGE2", i).Value = dr("PERCENTAGE2")
        '        'D("MODIFIED_ON", i).Value = dr("MODIFIED_ON")
        '        D("BATCH_ID", i).Value = dr("BATCH_ID")
        '        i += 1
        '    End While
        'End If

        'dr.Close()
        'cmd.Dispose()
        'cn.Dispose()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

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
            "UPDATE dbo.BATCH_SPLIST SET IS_SYNC = 'N' WHERE BATCH_ID = '" & txtBatchID.Text & "' AND IS_SYNC = 'P' "
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