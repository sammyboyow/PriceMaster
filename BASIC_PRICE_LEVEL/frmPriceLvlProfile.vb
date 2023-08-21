Imports System.Data.SqlClient
Public Class frmPriceLvlProfile

    Private Sub frmPriceLvlProfile_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmPriceLvlProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand()
        Dim dr As SqlDataReader
        Dim i As Integer = 0
        If txtDocentry.Text <> "" Then str = str & " AND DOCENTRY = '" & txtDocentry.Text & "' "
        If txtProName.Text <> "" Then str = str & " AND PROFILENAME LIKE '%" & txtProName.Text & "%' "

        str =
            "SELECT DOCENTRY,PROFILENAME,REMARKS,ADDON,ADDBY " &
            "FROM BSC_PRICELVL_PROFILE_HDR WHERE  CAST(ADDON AS DATE) BETWEEN '" & dtpFrom.Text & "' AND '" & dtpTo.Text & "' " & str
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        D.Rows.Clear()
        If dr.HasRows Then
            While dr.Read
                D.Rows.Add()
                D("DOCENTRY", i).Value = dr("DOCENTRY")
                D("PROFILENAME", i).Value = dr("PROFILENAME")
                D("REMARKS", i).Value = dr("REMARKS")
                D("ADDON", i).Value = dr("ADDON")
                D("ADDBY", i).Value = dr("ADDBY")
                i += 1
            End While
        End If

        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If D.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = D.CurrentRow.Index
        With frmModBasicPriceLvl
            .Show()
            .lblDocEntry.Text = D("DocEntry", i).Value
        End With
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtMProName.Clear()
        txtMRemarks.Clear()
        lblDocEntry.Text = 0
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If D.Rows.Count = 0 Then Exit Sub

        Dim i As Integer = D.CurrentRow.Index
        lblDocEntry.Text = D("DocEntry", i).Value
        txtMProName.Text = D("ProfileName", i).Value
        txtMRemarks.Text = D("Remarks", i).Value
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = "'"
        Dim cmd As New SqlCommand
        Try
            str = "SELECT TOP 1 1 FROM BSC_PRICELVL_PROFILE_HDR WHERE DOCENTRY = '" & lblDocEntry.Text & "' "
            cmd = New SqlCommand(str, cn)
            str = cmd.ExecuteScalar()
            If str = "1" Then
                str =
                    "UPDATE dbo.BSC_PRICELVL_PROFILE_HDR " & _
                    "SET PROFILENAME = '" & Replace(txtMProName.Text, "'", "''") & "', REMARKS = '" & Replace(txtMRemarks.Text, "'", "''") & "' WHERE DOCENTRY = '" & lblDocEntry.Text & "'"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()
            Else
                str =
                    "INSERT INTO dbo.BSC_PRICELVL_PROFILE_HDR (DOCENTRY, PROFILENAME, REMARKS, ADDON, ADDBY) " & _
                    "VALUES ((SELECT ISNULL(MAX(DOCENTRY),0) + 1 FROM dbo.BSC_PRICELVL_PROFILE_HDR),'" & Replace(txtMProName.Text, "'", "''") & "', " & _
                    "'" & Replace(txtMRemarks.Text, "'", "''") & "',GETDATE(),'" & Info.EmpID & "')"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            cmd.Dispose()
            cn.Dispose()
            MsgBox(ex.Message)
            Exit Sub
        End Try
        btnLoad.PerformClick()
        cmd.Dispose()
        cn.Dispose()
        btnClear.PerformClick()
        MsgBox("Done.")
        
    End Sub

    Private Sub D_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles D.CellContentClick

    End Sub

    Private Sub D_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles D.MouseDoubleClick
        btnEdit.PerformClick()
    End Sub
End Class