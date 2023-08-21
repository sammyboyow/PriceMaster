Imports System.Data.SqlClient

Public Class frmImportIMH
#Region "SUB PROCEDURE"
    Public Sub LoadBatch()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        '"INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSET B WITH(NOLOCK) ON A.MOTHER_BRANCH COLLATE DATABASE_DEFAULT = B.CODE COLLATE DATABASE_DEFAULT " & _
        Dim str As String = "SELECT BATCH_ID, MOTHER_BRANCH, COUNT(1) CNT " & _
                            "FROM TMP_ITEM_MASTERH WITH(NOLOCK)  " & _
                            "GROUP BY BATCH_ID, MOTHER_BRANCH  " & _
                            "ORDER BY BATCH_ID DESC "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = 0
        If dr.HasRows Then
            d.Rows.Clear()
            While dr.Read
                d.Rows.Add()
                d("BATCH_ID", i).Value = dr("BATCH_ID")
                d("BRANCH", i).Value = dr("MOTHER_BRANCH")
                d("ITEM_COUNT", i).Value = dr("CNT")
                i += 1
            End While
        End If
        dr.Close()
        cn.Dispose()

    End Sub
    Public Function GetCode(ByVal Blk As String) As String
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT CODE FROM SAPSET WHERE BLK = '" & Blk & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
#End Region
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Dispose()
    End Sub
    Private Sub frmImportIMH_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBatch()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If d.Rows.Count = 0 Then Exit Sub
        If d("BATCH_ID", d.CurrentRow.Index).Value = Nothing Then Exit Sub
        frmPriceUpdateSceme.LoadBatchIMH(d("BRANCH", d.CurrentRow.Index).Value, d("BATCH_ID", d.CurrentRow.Index).Value)
        Me.Dispose()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then LoadBatch()

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = "SELECT A.BATCH_ID, B.BLK, COUNT(1) CNT " & _
                           "FROM TMP_ITEM_MASTERH A WITH(NOLOCK)  " & _
                           "INNER JOIN [192.171.3.29].HPCOMMON.DBO.SAPSET B WITH(NOLOCK) ON A.MOTHER_BRANCH COLLATE DATABASE_DEFAULT = B.CODE COLLATE DATABASE_DEFAULT " & _
                           "WHERE MOTHER_BRANCH = '" & Replace(txtSearch.Text, "'", "''") & "' OR BATCH_ID = '" & Replace(txtSearch.Text, "'", "''") & "' " & _
                           "GROUP BY BATCH_ID, BLK " & _
                           "ORDER BY BATCH_ID, BLK"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = 0
        If dr.HasRows Then
            d.Rows.Clear()
            While dr.Read
                d.Rows.Add()
                d("BATCH_ID", i).Value = dr("BATCH_ID")
                d("BRANCH", i).Value = dr("MOTHER_BRANCH")
                d("ITEM_COUNT", i).Value = dr("CNT")
                i += 1
            End While
        End If
        dr.Close()
        cn.Dispose()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "" Then
            LoadBatch()
        End If
    End Sub

    Private Sub d_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d.MouseDoubleClick
        If d.CurrentCell.ColumnIndex = 0 Or d.CurrentCell.ColumnIndex = 1 Then
            btnSelect.PerformClick()
        End If
    End Sub
End Class