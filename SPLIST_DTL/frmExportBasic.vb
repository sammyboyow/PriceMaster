Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO
Public Class frmExportBasic
    Dim vFileName As String = ""
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim excel As String = vFileName


        Dim cmd As New SqlCommand
        Dim str As String = ""

        Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim da As New OleDbDataAdapter("Select * From [" & cbSheet.Text & "$]", cn)
        Dim dt As New DataTable
        da.Fill(dt)

        Try
            cmd = New SqlCommand("BEGIN TRAN", cn2)
            cmd.ExecuteNonQuery()

            If dt.Rows.Count > 0 Then
                For RowIndex As Integer = 0 To dt.Rows.Count - 1
                    For ColIndex As Integer = 0 To dt.Columns.Count - 1
                        If ColIndex > 1 Then
                            str = "SELECT TOP 1 1 FROM BASIC_PRICE_LVL WHERE IMH_CODE = '" & dt.Rows(RowIndex).Item("IMH_CODE").ToString & "' AND PRICE_LEVEL ='" & dt.Columns(ColIndex).ColumnName & "' "
                            cmd = New SqlCommand(str, cn2)
                            str = cmd.ExecuteScalar

                            If str Is Nothing Then
                                str = "INSERT INTO BASIC_PRICE_LVL (IMH_CODE, IMH_DESC, PRICE_LEVEL, PRICE) " & _
                                    "VALUES ('" & dt.Rows(RowIndex).Item("IMH_CODE").ToString & "','" & Replace(dt.Rows(RowIndex).Item("IMH_DESC").ToString, "'", "''") & "', " & _
                                    "'" & dt.Columns(ColIndex).ColumnName & "','" & dt.Rows(RowIndex).Item(ColIndex).ToString & "')"
                            Else
                                str = "UPDATE BASIC_PRICE_LVL " & _
                                    "SET PRICE = '" & dt.Rows(RowIndex).Item(ColIndex).ToString & "' " & _
                                    "WHERE IMH_CODE = '" & dt.Rows(RowIndex).Item("IMH_CODE").ToString & "' AND PRICE_LEVEL ='" & dt.Columns(ColIndex).ColumnName & "' "
                            End If
                            cmd = New SqlCommand(str, cn2)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                Next
            End If
            cmd = New SqlCommand("COMMIT", cn2)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Import Complete", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbSheet.Items.Clear()
            vFileName = ""
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK", cn2)
            cmd.ExecuteNonQuery()
        End Try
        cn.Dispose()
        'End If
    End Sub

    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Dim OpenFile As New OpenFileDialog
        Dim SheetName As New List(Of String)
        Dim xlApp As New Excel.Application
        Dim xlWS As Excel.Worksheet

        If OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            vFileName = ""
            Dim FileName As String = OpenFile.FileName
            vFileName = FileName
            xlApp.Workbooks.Open(FileName, 0, True)

            SheetName.Clear()
            SheetName.Add("")
            For Each xlWS In xlApp.Sheets
                SheetName.Add(xlWS.Name)
            Next
            cbSheet.Items.Clear()
            For i As Integer = 0 To SheetName.Count - 1
                cbSheet.Items.Add(SheetName(i))
            Next
            xlApp.Quit()
        End If
        


    End Sub

    Private Sub cbSheet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSheet.SelectedIndexChanged

    End Sub
End Class