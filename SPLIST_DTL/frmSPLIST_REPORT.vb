Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.Office.Interop

Public Class frmSPLIST_REPORT

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

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Public Sub AutoComplete()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT CAST(BATCH_ID AS INT) BATCH_ID " & _
                            "FROM BATCH_SPLIST WITH(NOLOCK) " & _
                            "ORDER BY CAST(BATCH_ID AS INT) DESC"
        Dim cmd As New SqlCommand(str, cn)
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)

        If dt.Rows.Count > 1 Then
            Dim c As New AutoCompleteStringCollection

            For i As Integer = 0 To dt.Rows.Count - 1
                c.Add(dt.Rows(i).Item("BATCH_ID").ToString())
            Next

            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearch.AutoCompleteCustomSource = c
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dt As New DataTable

        Try
            str = "SELECT SPD_EFD, SPD_CODE, COUNT(1) CNT " & _
                  "FROM SPLIST_DTL WITH(NOLOCK) " & _
                  "WHERE BATCH_ID = '" & txtSearch.Text & "' " & _
                  "GROUP BY SPD_EFD, SPD_CODE " & _
                  "ORDER BY SPD_CODE"
            cmd = New SqlCommand(str, cn)
            dt.Load(cmd.ExecuteReader)
            cmd.Dispose()

            If dt.Rows.Count > 0 Then
                d1.Rows.Clear()
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        txtEFF.Text = dt.Rows(i).Item("SPD_EFD").ToString
                        txtBATCHID.Text = txtSearch.Text
                    End If

                    d1.Rows.Add()
                    d1("SPD_CODE", i).Value = dt.Rows(i).Item("SPD_CODE").ToString
                    d1("COUNT", i).Value = dt.Rows(i).Item("CNT").ToString
                Next
            Else
                txtEFF.Text = ""
                txtBATCHID.Text = ""
                d1.Rows.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        txtSearch.Text = ""
        d2.Rows.Clear()
        cn.Close()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Return Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub frmSPLIST_REPORT_Load(sender As Object, e As EventArgs) Handles Me.Load
        AutoComplete()
    End Sub

    Private Sub d1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d1.CellContentClick

    End Sub

    Private Sub d1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d1.MouseDoubleClick

        If d1.CurrentCell.ColumnIndex <> 1 Then
            Exit Sub
        End If

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        Try

            str = "SELECT DISTINCT A.SPD_IMH_CODE, B.IMH_BILLCODE  " & _
                  "FROM SPLIST_DTL A WITH(NOLOCK) " & _
                  "INNER JOIN ITEM_MASTERH B WITH(NOLOCK) ON A.SPD_IMH_CODE = B.IMH_CODE " & _
                  "WHERE BATCH_ID = '" & txtBATCHID.Text & "' AND SPD_CODE = '" & d1("SPD_CODE", d1.CurrentRow.Index).Value & "' " & _
                  "ORDER BY A.SPD_IMH_CODE "
            cmd = New SqlCommand(str, cn)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            cmd.Dispose()

            If dt.Rows.Count > 0 Then
                d2.Rows.Clear()

                For i As Integer = 0 To dt.Rows.Count - 1
                    d2.Rows.Add()

                    d2("IMH_CODE", i).Value = dt.Rows(i).Item("SPD_IMH_CODE").ToString
                    d2("BILL_CODE", i).Value = dt.Rows(i).Item("IMH_BILLCODE").ToString
                Next
            Else
                d2.Rows.Clear()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        d2.Rows.Clear()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If MessageBox.Show("Do you want to generate file?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim xlApp As New Excel.Application
        Dim xlWB As Excel.Workbook
        Dim xlSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        Try

            Dim str As String = "EXEC spSPREPORT '" & txtBATCHID.Text & "'"
            Dim cmd As New SqlCommand(str, cn)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            cmd.Dispose()


            If dt.Rows.Count > 0 Then
                xlWB = xlApp.Workbooks.Add(misValue)
                xlSheet = xlWB.Sheets("Sheet1")

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

                For i As Integer = 0 To dt.Rows.Count - 1
                    xlSheet.Cells(xlRow, 1) = dt.Rows(i).Item(0).ToString
                    xlSheet.Cells(xlRow, 2) = dt.Rows(i).Item(1).ToString
                    xlSheet.Cells(xlRow, 3) = "'" & dt.Rows(i).Item(2).ToString
                    xlSheet.Cells(xlRow, 4) = "'" & dt.Rows(i).Item(3).ToString
                    xlSheet.Cells(xlRow, 5) = "'" & Format(CDbl(dt.Rows(i).Item(4).ToString), "N2")
                    xlSheet.Cells(xlRow, 6) = "'" & Format(CDbl(dt.Rows(i).Item(5).ToString), "N2")
                    xlSheet.Cells(xlRow, 7) = "'" & Format(CDate(dt.Rows(i).Item(6).ToString), "MM/dd/yyyy")
                    xlSheet.Cells(xlRow, 9) = "'" & dt.Rows(i).Item(7).ToString
                    xlSheet.Cells(xlRow, 10) = "'" & Format(CDbl(dt.Rows(i).Item(8).ToString), "N2")
                    xlSheet.Cells(xlRow, 11) = "'" & dt.Rows(i).Item(9).ToString
                    xlSheet.Cells(xlRow, 12) = "'" & Format(CDbl(dt.Rows(i).Item(10).ToString), "N2")
                    xlSheet.Cells(xlRow, 13) = "'" & dt.Rows(i).Item(11).ToString
                    xlSheet.Cells(xlRow, 14) = "'" & Format(CDbl(dt.Rows(i).Item(12).ToString), "N2")
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

                xlApp.Visible = True
                releaseObject(xlApp)
                releaseObject(xlWB)
                releaseObject(xlSheet)

            End If
            MessageBox.Show("Done", "Price Master", MessageBoxButtons.OK)
            d1.Rows.Clear()
            d2.Rows.Clear()
            txtEFF.Text = ""
            txtBATCHID.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
      
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
End Class