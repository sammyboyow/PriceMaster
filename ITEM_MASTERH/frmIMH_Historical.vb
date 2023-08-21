Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmIMH_Historical
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
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", WHERE As String = ""
        Dim adapt As New SqlDataAdapter
        Dim dt As New DataTable

        If cbType.Text = "MOTHER BRANCH" Then
            WHERE = "WHERE MOTHER_BRANCH ='" & txtSearchType.Text & "' "
        ElseIf cbType.Text = "EFFECTIVE DATE" Then
            WHERE = "WHERE IMH_EFD_P1 ='" & txtSearchType.Text & "' "
        Else
            MessageBox.Show("Please Select Search type", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Try
            str = "SELECT * FROM TMP_ITEM_MASTERH WITH(NOLOCK) " & WHERE & ""
            adapt = New SqlDataAdapter(str, cn)
            dt = New DataTable
            adapt.Fill(dt)

            Dim xlApp As New Excel.Application
            Dim xlWB As Excel.Workbook
            Dim xlWS As Excel.Worksheet

            Dim MisValue As Object = System.Reflection.Missing.Value
            xlWB = xlApp.Workbooks.Add(MisValue)
            xlWS = xlWB.Sheets("Sheet1")

            If dt.Rows.Count > 0 Then
                xlWS.Cells(2, 1) = ""
                xlWS.Cells(2, 2) = ""
                xlWS.Cells(2, 3) = ""
                xlWS.Cells(2, 4) = ""
                xlWS.Cells(2, 4) = ""
                xlWS.Cells(2, 4) = ""
                xlWS.Cells(2, 4) = ""
                xlWS.Cells(2, 4) = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    'str = ""
                Next
            End If



        Catch ex As Exception

        End Try
    
        cn.Close()
    End Sub
End Class