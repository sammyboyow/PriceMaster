Imports System.Data.SqlClient
Public Class frmExpGrp
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
#Region "SUB PROCEDURE / FUNCTIONS"
    Public Sub LoadPriceList()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT PriceList FROM Price_Level_Dtl WITH(NOLOCK) ORDER BY PRICELIST"
        Dim cmd As New SqlCommand(str, cn)
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        cmd.Dispose()

        Dim c As New AutoCompleteStringCollection()
        If dt.Rows.Count > 0 Then
            c.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                c.Add(dt.Rows(i).Item("PriceList").ToString())
                'c.Add(dt.Rows(i).Item("PriceList_Desc").ToString())
            Next
        Else
            c.Clear()
        End If
        txtDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtDesc.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtDesc.AutoCompleteCustomSource = c
    End Sub
    Public Sub LoadExp()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT * FROM EXCEPT_BY_TESTGRP WITH(NOLOCK)"
        Dim cmd As New SqlCommand(str, cn)
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        cmd.Dispose()

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                d2.Rows.Add()
                d2("PriceLevel", i).Value = dt.Rows(i).Item("PRICE_LEVEL").ToString()
                d2("SPD_CODE", i).Value = dt.Rows(i).Item("PRICE_LIST").ToString()
                d2("SPD_GRP", i).Value = dt.Rows(i).Item("TEST_GRP").ToString()
            Next
        Else
            d2.Rows.Clear()
        End If

    End Sub
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MessageBox.Show("Do you want to save exception [Y/N]?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub


        If txtCode.Text = "" Or cbPriceLevel.Text = "" Then
            MessageBox.Show("Please Complete details", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If d("chkReg", 0).Value = False And d("chkSP", 0).Value = False And d("chkIMG", 0).Value = False And d("chkUTZ", 0).Value = False Then
            MessageBox.Show("Please select test group", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim SP As String = "", REG As String = "", UTZ As String = "", IMG As String = ""
        Dim TEST_GROUP As New List(Of String)

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        If d("chkReg", 0).Value = True Then
            REG = "REGULAR"
            TEST_GROUP.Add(REG)
        Else
            REG = ""
        End If
        If d("chkSP", 0).Value = True Then
            SP = "SPECIAL TESTS"
            TEST_GROUP.Add(SP)
        Else
            SP = ""
        End If
        If d("chkIMG", 0).Value = True Then
            IMG = "IMAGING"
            TEST_GROUP.Add(IMG)
        Else
            IMG = ""
        End If
        If d("chkUTZ", 0).Value = True Then
            UTZ = "ULTRASOUND"
            TEST_GROUP.Add(UTZ)
        Else
            UTZ = ""
        End If

        Try
            str = "BEGIN TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()

            For i As Integer = 0 To TEST_GROUP.Count - 1
                str = "SELECT TOP 1 1 " & _
                    "FROM EXCEPT_BY_TESTGRP WITH(NOLOCK) " & _
                    "WHERE PRICE_LEVEL = '" & cbPriceLevel.Text & "' AND PRICE_LIST = '" & txtCode.Text & "' AND TEST_GRP = '" & TEST_GROUP(i).ToString() & "' "
                cmd = New SqlCommand(str, cn)
                str = cmd.ExecuteScalar

                If str Is Nothing Then
                    str = "INSERT INTO EXCEPT_BY_TESTGRP VALUES ('" & cbPriceLevel.Text & "','" & txtCode.Text & "','" & TEST_GROUP(i).ToString() & "')"
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            str = "COMMIT"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Saved successfully", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            str = "ROLLBACK"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    
    End Sub

    Private Sub frmExpGrp_Load(sender As Object, e As EventArgs) Handles Me.Load
        d.Rows.Add()
        LoadPriceList()
        LoadExp()
    End Sub

    Private Sub txtDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDesc.KeyDown
        Dim cn As New SqlConnection(cnSQL)
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dt As New DataTable
        If e.KeyCode = Keys.Return Then
            If cn.State = ConnectionState.Closed Then cn.Open()

            str = "SELECT DISTINCT PriceLevel, PriceList " & _
                "FROM Price_Level_Dtl WITH(NOLOCK) " & _
                "WHERE PriceList = '" & txtDesc.Text & "' "
            cmd = New SqlCommand(str, cn)
            dt = New DataTable
            dt.Load(cmd.ExecuteReader)
            cmd.Dispose()

            If dt.Rows.Count > 0 Then
                cbPriceLevel.Items.Clear()
                cbPriceLevel.Items.Add("")
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        txtCode.Text = dt.Rows(i).Item(1).ToString()
                    End If
                    cbPriceLevel.Items.Add(dt.Rows(i).Item(0).ToString())
                Next
                txtDesc.Text = ""
            Else
                txtCode.Text = ""
                txtDesc.Text = ""
                cbPriceLevel.Items.Clear()
                MessageBox.Show("Price List not found!", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "" Then
            LoadExp()
        Else
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT * FROM EXCEPT_BY_TESTGRP WITH(NOLOCK) WHERE PRICE_LIST LIKE '%" & txtSearch.Text & "%' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            cmd.Dispose()

            If dt.Rows.Count > 0 Then
                d2.Rows.Clear()
                For i As Integer = 0 To dt.Rows.Count - 1
                    d2.Rows.Add()
                    d2("PriceLevel", i).Value = dt.Rows(i).Item("PRICE_LEVEL").ToString()
                    d2("SPD_CODE", i).Value = dt.Rows(i).Item("PRICE_LIST").ToString()
                    d2("SPD_GRP", i).Value = dt.Rows(i).Item("TEST_GRP").ToString()
                Next
            Else
                d2.Rows.Clear()
            End If

        End If

    End Sub
End Class