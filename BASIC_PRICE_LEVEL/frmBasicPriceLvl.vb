Imports System.Data.SqlClient
Public Class frmBasicPriceLvl
    Dim dtTestDesc As DataTable = Nothing
    Dim dtTestCode As DataTable = Nothing
    Private Sub frmBasicPriceLvl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Sub load_fields(ByVal Testcode As String, ByVal Ad As Integer)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim i As Integer = 0
        Dim ValCnt As Integer = 0


        If D.Rows.Count = 0 Then
            i = D.Rows.Count
        Else
            i = D.CurrentRow.Index
        End If
        For Val As Integer = 0 To D.Rows.Count - 1
            If D("IMH_CODE", Val).Value = Testcode Then
                ValCnt += 1
            End If
        Next

        If ValCnt > 1 Then
            MsgBox("Test already exist in the list!")
            D("IMH_CODE", i).Value = ""
            D("IMH_DESC", i).Value = ""
            cmd.Dispose()
            cn.Dispose()
            Exit Sub
        End If

        'If Testcode = "" Then : Testcode = "NULL" : Else : Testcode = "''" & Testcode & "''" : End If
        str = " EXEC SP_BASIC_PRICE_LVL_TEMPLATE '" & Testcode & "' "
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            If D.Rows.Count = 0 Then
                Dim AddColumn As New DataGridViewCheckBoxColumn
                With AddColumn
                    .HeaderText = ""
                    .Name = "Chk"
                    .Width = 30
                End With
                D.Columns.Insert(0, AddColumn)
                For ii As Integer = 0 To dr.FieldCount - 1

                    D.Columns.Add(dr.GetName(ii), dr.GetName(ii))
                    If D.Columns(ii).Name = "IMH_DESC" Then : D.Columns(ii).Width = 180
                    ElseIf D.Columns(ii).Name = "IMH_CODE" Then : D.Columns(ii).Width = 70
                    ElseIf D.Columns(ii).Name = "Chk" Then : D.Columns(ii).Width = 30
                    Else : D.Columns(ii).Width = 60 : End If

                Next
            End If
            While dr.Read
                If Ad = 1 Then D.Rows.Add()
                D.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                For ii As Integer = 0 To dr.FieldCount - 1
                    Dim aa = dr.GetName(ii)
                    D(dr.GetName(ii), i).Value = dr(ii)
                Next
                i += 1
            End While
        Else
            If D.Rows.Count = 0 Then
                Dim AddColumn As New DataGridViewCheckBoxColumn
                With AddColumn
                    .HeaderText = ""
                    .Name = "Chk"
                    .Width = 30
                End With
                D.Columns.Insert(0, AddColumn)
                For ii As Integer = 0 To dr.FieldCount - 1
                    D.Columns.Add(dr.GetName(ii), dr.GetName(ii))
                    If D.Columns(ii).Name = "IMH_DESC" Then : D.Columns(ii).Width = 180
                    ElseIf D.Columns(ii).Name = "IMH_CODE" Then : D.Columns(ii).Width = 70
                    ElseIf D.Columns(ii).Name = "Chk" Then : D.Columns(ii).Width = 30
                    Else : D.Columns(ii).Width = 60 : End If
                Next
            End If

        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        D.Rows.Clear()
        D.Columns.Clear()
        load_fields(cboTCode.Text, 1)
    End Sub

    Private Sub D_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles D.CellEndEdit
        If D.CurrentCell.ColumnIndex = D.Columns("IMH_CODE").Index Or D.CurrentCell.ColumnIndex = D.Columns("IMH_DESC").Index Then

            gettest()
            Dim i As Integer = D.CurrentRow.Index
            If Not D("IMH_CODE", i).Value = "" Or Not D("IMH_CODE", i).Value Is Nothing Then
                load_fields(D("IMH_CODE", i).Value, 0)
            End If
        ElseIf D.CurrentCell.ColumnIndex = D.Columns("Chk").Index Then
            'ElseIf Not D(D.Columns(D.CurrentCell.ColumnIndex).Name, D.CurrentRow.Index).Value Is Nothing Then
        Else
            Dim i As Integer = D.CurrentRow.Index
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim str As String = ""
            Dim cmd As New SqlCommand
            If MsgBox("Do you want to save " & D(D.Columns(D.CurrentCell.ColumnIndex).Name, i).Value & " to " & D.Columns(D.CurrentCell.ColumnIndex).Name & " ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Try


                    str = "SELECT TOP 1 1 " & _
                        "FROM BASIC_PRICE_LVL_TEMPLATE " & _
                        "WHERE IMH_CODE = '" & D("IMH_CODE", i).Value & "' AND PRICE_LEVEL = '" & D.Columns(D.CurrentCell.ColumnIndex).Name & "'"

                    cmd = New SqlCommand(str, cn)
                    str = cmd.ExecuteScalar()
                    If str = "1" Then
                        str =
                            "UPDATE BASIC_PRICE_LVL_TEMPLATE " & _
                            "SET PRICE = '" & D(D.Columns(D.CurrentCell.ColumnIndex).Name, i).Value & "' WHERE " & _
                            "IMH_CODE = '" & D("IMH_CODE", i).Value & "' AND PRICE_LEVEL = '" & D.Columns(D.CurrentCell.ColumnIndex).Name & "'"
                    Else
                        str =
                            "INSERT INTO BASIC_PRICE_LVL_TEMPLATE VALUES('" & D("IMH_CODE", i).Value & "','" & D("IMH_DESC", i).Value & "', " & _
                            "'" & D.Columns(D.CurrentCell.ColumnIndex).Name & "','" & D(D.Columns(D.CurrentCell.ColumnIndex).Name, i).Value & "' ) "

                    End If
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()

                Catch ex As Exception
                    MsgBox("ERROR UPON SAVING. ERROR DETAILS : " & ex.Message & "")
                End Try
                MsgBox("Saved.", MsgBoxStyle.Information)
            Else
                str = "SELECT PRICE " & _
                        "FROM BASIC_PRICE_LVL_TEMPLATE " & _
                        "WHERE IMH_CODE = '" & D("IMH_CODE", i).Value & "' AND PRICE_LEVEL = '" & D.Columns(D.CurrentCell.ColumnIndex).Name & "'"

                cmd = New SqlCommand(str, cn)
                str = cmd.ExecuteScalar()
                D(D.Columns(D.CurrentCell.ColumnIndex).Name, i).Value = str
            End If
            cmd.Dispose()
            cn.Dispose()
        End If
    End Sub

    Private Sub D_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles D.EditingControlShowing
        If D.Columns(D.CurrentCell.ColumnIndex).HeaderText = "IMH_CODE" Or D.Columns(D.CurrentCell.ColumnIndex).HeaderText = "IMH_DESC" Then
            If D.CurrentCell.ColumnIndex = 0 Then
                Dim autoText As TextBox = TryCast(e.Control, TextBox)

                If autoText IsNot Nothing Then
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                    Dim DataCollection As New AutoCompleteStringCollection()
                    AddItems(DataCollection)
                    autoText.AutoCompleteCustomSource = DataCollection
                    autoText.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                End If
            End If
        Else
            Dim text As TextBox = TryCast(e.Control, TextBox)
            text.AutoCompleteCustomSource = Nothing
            text.AutoCompleteSource = AutoCompleteSource.None
            text.AutoCompleteMode = AutoCompleteMode.None
        End If
    End Sub
    Public Sub AddItems(ByVal col As AutoCompleteStringCollection)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cmd As New SqlCommand
        Dim str As String = ""
        Dim dt As New DataTable

        str =
            "SELECT C.IMH_CODE,MAX(C.IMH_DESC) IMH_DESC " & _
            "FROM dbo.CONSOLIDATED_IMH C " & _
            "INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSET S ON S.CODE = C.BRANCH_CODE COLLATE DATABASE_DEFAULT " & _
            "WHERE S.STAT = 'O' AND S.SlsStat = 'O' " & _
            "AND C.IMH_TYPE = 'S' " & _
            "GROUP BY C.IMH_CODE " & _
            "ORDER BY 1 "
        cmd = New SqlCommand(str, cn)
        dt.Load(cmd.ExecuteReader)
        If dt.Rows.Count > 0 Then
            col.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                col.Add(dt.Rows(i).Item("IMH_CODE").ToString())
                col.Add(dt.Rows(i).Item("IMH_DESC").ToString())
            Next
        Else
            col.Clear()
        End If
        cn.Dispose()
    End Sub

    Private Sub D_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles D.CellContentClick

    End Sub

    Private Sub D_KeyDown(sender As Object, e As KeyEventArgs) Handles D.KeyDown

        'If e.KeyCode = Keys.Enter And (D.CurrentCell.ColumnIndex = D.Columns("IMH_CODE").Index Or D.CurrentCell.ColumnIndex = D.Columns("IMH_DESC").Index) Then
        '    gettest()
        'ElseIf e.KeyCode = Keys.Enter Then

        '    Dim cn As New SqlConnection(cnSQL)
        '    If cn.State = ConnectionState.Closed Then cn.Open()
        '    Dim str As String = ""
        '    Dim cmd As New SqlCommand
        '    Dim dr As SqlDataReader
        '    Dim i As Integer = 0

        '    str = "SELECT TOP 1 1 FROM BASIC_PRICE_LVL_TEMPLATE WHERE IMH_CODE = '" & D("IMH_CODE", i).Value & "'"

        '    cmd = New SqlCommand(str, cn)
        '    str = cmd.ExecuteScalar()
        '    If str = "1" Then
        '        'str = "UPDATE BASIC_PRICE_LVL_TEMPLATE SET " & D.Columns(D.CurrentCell.ColumnIndex).HeaderText & " "
        '        Dim ee As String = D.Columns(D.CurrentCell.ColumnIndex).HeaderText
        '    Else

        '    End If
        '    'dr.Close()
        '    cmd.Dispose()
        '    cn.Dispose()
        'End If
    End Sub
    Sub gettest()

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim i As Integer = D.CurrentRow.Index
        Dim str As String =
                "SELECT C.IMH_CODE,C.IMH_DESC " & _
                "FROM dbo.CONSOLIDATED_IMH C " & _
                "INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSET S ON S.CODE = C.BRANCH_CODE COLLATE DATABASE_DEFAULT " & _
                "WHERE S.STAT = 'O' AND S.SlsStat = 'O' " & _
                "AND C.IMH_TYPE = 'S' AND (C.IMH_CODE = '" & D("IMH_CODE", i).Value & "' OR C.IMH_DESC = '" & D("IMH_CODE", i).Value & "') " & _
                "GROUP BY C.IMH_CODE,C.IMH_DESC " & _
                "ORDER BY 1 "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        With frmSelectTest
            .D.Rows.Clear()
            Dim ii As Integer = .D.Rows.Count
            If dr.HasRows Then
                While dr.Read
                    .D.Rows.Add()
                    .D("IMH_CODE", ii).Value = dr("IMH_CODE")
                    .D("IMH_DESC", ii).Value = dr("IMH_DESC")
                    Dim EE As String = dr("IMH_DESC")
                    ii += 1

                    D("IMH_CODE", i).Value = dr("IMH_CODE")
                    D("IMH_DESC", i).Value = dr("IMH_DESC")
                End While
                If ii > 1 Then
                    .ShowDialog()
               
                End If
            End If
          
        End With

        cmd.Dispose()
        cn.Dispose()

    End Sub
    Private Sub btnPlus_Click(sender As Object, e As EventArgs) Handles btnPlus.Click
        If D.Columns.Count = 0 Then
            load_fields("xxxxxxx", 0)
        Else
            D.Rows.Add()
        End If
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        If D.Rows.Count = 0 Then Exit Sub
        Dim x As Integer = D.CurrentRow.Index
        D.Rows.Remove(D.Rows(x))
        'For x As Integer = D.Rows.Count - 1 To 0 Step -1
        '    D.Rows.Remove(D.Rows(x))
        'Next
    End Sub

    Private Sub txtCodeDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCodeDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLoad.PerformClick()
        End If

    End Sub

    Private Sub btnSelectBscPricelvl_Click(sender As Object, e As EventArgs) Handles btnSelectBscPricelvl.Click
        Dim Cnt As Integer = 0
        If D.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To D.Rows.Count - 1
            If D("Chk", i).Value = True Then
                Cnt = 1
                Exit For
            End If
        Next
        If Cnt = 0 Then MsgBox("No selected Test in list!") : Exit Sub
        frmSelectBasicPrice.dgv = D
        frmSelectBasicPrice.Show()
    End Sub
    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        If D.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To D.Rows.Count - 1
            D("Chk", i).Value = ChkAll.Checked
        Next
    End Sub
    Private Sub frmBasicPriceLvl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnPlus.PerformClick()
        LoadTestDesc()
        LoadTestCode()
    End Sub
    Private Sub cboTCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTCode.SelectedValueChanged
        If cboTCode.SelectedIndex <> -1 Then
            cboTDesc.Text = cboTCode.SelectedValue.ToString
        End If
    End Sub
    Private Sub cboTDesc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTDesc.SelectedValueChanged
        If cboTDesc.SelectedIndex <> -1 Then
            cboTCode.Text = cboTDesc.SelectedValue.ToString
        End If
    End Sub
    Private Sub txtCodeDesc_TextChanged(sender As Object, e As EventArgs) Handles txtCodeDesc.TextChanged

    End Sub

    Private Sub vbtnLoad_Click(sender As Object, e As EventArgs) Handles vbtnLoad.Click

    End Sub

    Public Sub LoadTestDesc()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        If dtTestDesc Is Nothing Then
            dtTestDesc = New DataTable
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim str As String = ""
            str =
                "SELECT C.IMH_CODE, C.IMH_DESC IMH_DESC  " & _
                "FROM dbo.CONSOLIDATED_IMH C WITH (NOLOCK) " & _
                "INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSet S WITH (NOLOCK) ON S.CODE = C.BRANCH_CODE COLLATE DATABASE_DEFAULT " & _
                "WHERE IMH_TYPE = 'S' AND S.SlsStat = 'O' AND S.STAT = 'O' " & _
                "GROUP BY C.IMH_CODE,C.IMH_DESC "
            Dim cmd As New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dtTestDesc.Load(dr)
            dr.Close()
            cmd.Dispose()
            cn.Dispose()
        End If

        cboTDesc.Items.Add("")
        cboTDesc.DataSource = dtTestDesc
        cboTDesc.DisplayMember = "IMH_DESC"
        cboTDesc.ValueMember = "IMH_CODE"
        cboTDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboTDesc.AutoCompleteSource = AutoCompleteSource.ListItems
        cboTDesc.Text = ""
        cboTCode.Text = ""

    End Sub
    Public Sub LoadTestCode()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        If dtTestCode Is Nothing Then
            dtTestCode = New DataTable
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim str As String = ""
            str =
                "SELECT C.IMH_CODE, C.IMH_DESC IMH_DESC  " & _
                "FROM dbo.CONSOLIDATED_IMH C WITH (NOLOCK) " & _
                "INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSet S WITH (NOLOCK) ON S.CODE = C.BRANCH_CODE COLLATE DATABASE_DEFAULT " & _
                "WHERE IMH_TYPE = 'S' AND S.SlsStat = 'O' AND S.STAT = 'O' " & _
                "GROUP BY C.IMH_CODE,C.IMH_DESC "
            Dim cmd As New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            Dim dr As SqlDataReader = cmd.ExecuteReader
            dtTestCode.Load(dr)
            dr.Close()
            cmd.Dispose()
            cn.Dispose()
        End If

        cboTCode.Items.Add("")
        cboTCode.DataSource = dtTestCode
        cboTCode.DisplayMember = "IMH_CODE"
        cboTCode.ValueMember = "IMH_DESC"
        cboTCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cboTCode.AutoCompleteSource = AutoCompleteSource.ListItems
        cboTDesc.Text = ""
        cboTCode.Text = ""

    End Sub

    Private Sub cboTCode_KeyDown(sender As Object, e As KeyEventArgs) Handles cboTCode.KeyDown, cboTDesc.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLoad.PerformClick()
        End If
    End Sub
End Class