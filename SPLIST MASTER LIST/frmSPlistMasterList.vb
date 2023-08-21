Imports System.Data.SqlClient

Public Class frmSPlistMasterList
    Dim dtTestDesc As DataTable = Nothing
    Dim dtTestCode As DataTable = Nothing
    Private Sub frmSPlistMasterList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmSPlistMasterList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_spd_code()
        LoadTestDesc()
        LoadTestCode()
    End Sub
    Sub load_splist(ByVal Pricelvl As String, ByVal Testcode As String)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim i As Integer = 0
        str = " EXEC SP_SPLIST_MASTERLIST '" & Pricelvl & "','" & Testcode & "' "
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        D.Columns.Clear()

        If dr.HasRows Then
            'If D.Rows.Count = 0 Then
            '    'Dim AddColumn As New DataGridViewCheckBoxColumn
            '    'With AddColumn
            '    '    .HeaderText = ""
            '    '    .Name = "Chk"
            '    '    .Width = 30
            '    'End With
            '    'D.Columns.Insert(0, AddColumn)
            '    For ii As Integer = 0 To dr.FieldCount - 1

            '        D.Columns.Add(dr.GetName(ii), dr.GetName(ii))
            '        If D.Columns(ii).Name = "IMH_DESC" Then : D.Columns(ii).Width = 180
            '        ElseIf D.Columns(ii).Name = "IMH_CODE" Then : D.Columns(ii).Width = 70
            '        ElseIf D.Columns(ii).Name = "Chk" Then : D.Columns(ii).Width = 30
            '        Else : D.Columns(ii).Width = 90 : End If

            '    Next
            'End If
            For ii As Integer = 0 To dr.FieldCount - 1

                D.Columns.Add(dr.GetName(ii), dr.GetName(ii))
                If D.Columns(ii).Name = "TestCode" Then : D.Columns(ii).Width = 70
                ElseIf D.Columns(ii).Name = "TestDesc" Then : D.Columns(ii).Width = 150
                ElseIf D.Columns(ii).Name = "Chk" Then : D.Columns(ii).Width = 30
                Else : D.Columns(ii).Width = 70 : End If

            Next
            D.Rows.Clear()
            While dr.Read
                D.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
                'If D.Rows.Count = 0 Then
                '    D.Rows.Add()
                'End If
                D.Rows.Add()
                For ii As Integer = 0 To dr.FieldCount - 1
                    Dim aa = dr.GetName(ii)
                    D(dr.GetName(ii), i).Value = dr(ii)
                Next
                i += 1
            End While
            MsgBox("Done")
        Else
            MsgBox("No Test Loaded")
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub
    Sub load_spd_code()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        str =
            "SELECT DISTINCT PRICELEVEL " & _
            "FROM dbo.Price_Level_Dtl " & _
            "WHERE PriceLevel NOT IN ('CENT3','CORP5','HP4','OTC6','PRVC4','PRVO4','SPO6') " & _
            "ORDER BY 1 "
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                cboPricelvl.Items.Add(dr("PRICELEVEL"))
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        load_splist(cboPricelvl.Text, cboTCode.Text)
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
    Private Sub cboTDesc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTDesc.SelectedValueChanged
        If cboTDesc.SelectedIndex <> -1 Then
            cboTCode.Text = cboTDesc.SelectedValue.ToString
        End If

    End Sub
    Private Sub cboTCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboTCode.SelectedValueChanged
        If cboTCode.SelectedIndex <> -1 Then
            cboTDesc.Text = cboTCode.SelectedValue.ToString
        End If

    End Sub

    Private Sub cboPricelvl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPricelvl.SelectedIndexChanged

    End Sub

    Private Sub cboTCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTCode.SelectedIndexChanged

    End Sub

    Private Sub cboTDesc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTDesc.SelectedIndexChanged

    End Sub
End Class