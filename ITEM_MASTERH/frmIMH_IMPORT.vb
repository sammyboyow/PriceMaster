
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports Microsoft.Office.Interop
Imports System.Threading
Public Class frmIMH_IMPORT
    'Dim strsamplecon2 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = " & GetODBC(cbBranch.Text) & ")(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
    'Dim cnStr2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon1 & ";UID=HCLAB;PWD=HCLAB"
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
#Region "FUNCTION / SUB PROCEDURE"
    Public Sub loadTest()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK) WHERE IMH_REC_FLAG <> 'X' ORDER BY IMH_DESC "
        Dim da As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        da.Fill(dt)

        Dim c As New AutoCompleteStringCollection()
        If dt.Rows.Count > 0 Then
            c.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                c.Add(dt.Rows(i).Item("IMH_CODE").ToString)
                c.Add(dt.Rows(i).Item("IMH_DESC").ToString)
            Next
        Else
            c.Clear()
        End If

        cn.Close()
        txtIMHDesc.AutoCompleteCustomSource = c
        txtIMHDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtIMHDesc.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub
#End Region

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub txtIMHDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIMHDesc.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK) WHERE IMH_CODE = '" & txtIMHDesc.Text & "' OR IMH_DESC = '" & txtIMHDesc.Text & "' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            cmd.Dispose()

            If dt.Rows.Count > 0 Then
                txtCode.Text = dt.Rows(0).Item(0).ToString
                txtIMHDesc.Text = dt.Rows(0).Item(1).ToString
            End If
            cn.Close()
        End If
    End Sub

    Private Sub txtIMHDesc_TextChanged(sender As Object, e As EventArgs) Handles txtIMHDesc.TextChanged

    End Sub

    Private Sub frmIMH_IMPORT_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadTest()
    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        If txtCode.Text <> "" Then
            Dim vchk As Boolean = False

            For i As Integer = 0 To d1.Rows.Count - 1
                If txtCode.Text = d1(0, i).Value Then
                    vchk = True
                    Exit For
                Else
                    vchk = False
                End If
            Next
            If vchk = False Then
                d1.Rows.Add()
                d1("IMH_CODE", d1.Rows.Count - 1).Value = txtCode.Text
                d1("IMH_DESC", d1.Rows.Count - 1).Value = txtIMHDesc.Text
            Else
                MessageBox.Show("Test code already exists", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            txtCode.Text = ""
            txtIMHDesc.Text = ""
        Else
            MessageBox.Show("Please Enter test code", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        lblTestCount.Text = "TEST CODE COUNT: " & d1.Rows.Count
    End Sub

    Private Sub d1_KeyDown(sender As Object, e As KeyEventArgs) Handles d1.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Do you want to remove test code [Y/N]?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                d1.Rows.RemoveAt(d1.CurrentRow.Index)
            End If
            lblTestCount.Text = d1.Rows.Count
        End If
    End Sub

    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If MessageBox.Show("Do you want to save transaction [Y/N]?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", BATCH_ID As String = ""
        Dim cmd As New SqlCommand

        str = "SELECT (ISNULL(MAX(BATCH_ID), 0) + 1) BATCH_ID FROM BATCH_IMH_IMPORT"
        cmd = New SqlCommand(str, cn)
        BATCH_ID = cmd.ExecuteScalar

        If d1.Rows.Count > 0 Then
            Try
                str = "BEGIN TRAN"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To d1.Rows.Count - 1
                    str = "INSERT INTO BATCH_IMH_IMPORT (BATCH_ID, BATCH_IMH_CODE, DATE_GENERATED) VALUES ('" & BATCH_ID & "','" & d1("IMH_CODE", i).Value & "', GETDATE())"
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()
                Next

                str = "COMMIT"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Batch saved successfuly", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
                d1.Rows.Clear()
            Catch ex As Exception
                str = "ROLLBACK"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            MessageBox.Show("Please provide test code to post", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub d1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d1.CellContentClick

    End Sub

    Private Sub btnIMPORT_Click(sender As Object, e As EventArgs) Handles btnIMPORT.Click
        Dim FName As String
        Dim File As New OpenFileDialog()

        File.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        File.InitialDirectory = "D:\"

        If d1.Rows.Count > 0 Then MsgBox("Please Clear Data First!") : Exit Sub
        If File.ShowDialog = Windows.Forms.DialogResult.OK Then
            btnIMPORT.Enabled = False
            btnPost.Enabled = True

            FName = File.FileName

            Dim xlApp As New Excel.Application
            Dim xlWB As Excel.Workbook = xlApp.Workbooks.Open(FName)
            Dim xlWS As Excel.Worksheet = xlWB.Sheets(1)

            Dim i As Integer = 0
            For x As Integer = 1 To xlWS.Rows.Count - 1
                If xlWS.Cells(x, 1).Value <> Nothing Then
                    d1.Rows.Add()
                    d1(0, i).Value = xlWS.Cells(x, 1).Value
                    d1(1, i).Value = xlWS.Cells(x, 2).Value
                    i += 1
                    Thread.Sleep(100)
                Else
                    Exit For
                End If
            Next
            xlWB.Close()
            xlWS.Application.Quit()
            releaseObject(xlApp)
            releaseObject(xlWS)
            releaseObject(xlWB)
        End If
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