Imports System.Data.SqlClient
Public Class frmConfig_Udpate
    Public vtxtSearch As New TextBox

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
#Region "SUB PROCEDURE / FUNCTION"
    Public Sub LoadFlds()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim AutoComp As Boolean = False
        Dim str As String = ""
        Dim adapt As New SqlDataAdapter
        Dim dt As New DataTable
        Dim c As New AutoCompleteStringCollection()

        If cbSearchType.Text = "ITEM MASTERH" Then
            If cbCat.Text = "EFD_DATE" Then
                str = "SELECT DISTINCT IMH_EFD_P1 " & _
                    "FROM TMP_ITEM_MASTERH WITH(NOLOCK) " & _
                    "ORDER BY IMH_EFD_P1 DESC"
                adapt = New SqlDataAdapter(str, cn)
                dt = New DataTable
                adapt.Fill(dt)

                If dt.Rows.Count > 0 Then
                    c.Clear()
                    txtSearch.Clear()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        c.Add(Format(CDate(dt.Rows(i).Item("IMH_EFD_P1").ToString), "MM/dd/yyyy"))
                    Next
                    AutoComp = True
                Else
                    AutoComp = False
                End If
            Else
                AutoComp = False
            End If
        ElseIf cbSearchType.Text = "SPLIST DTL" Then
            If cbCat.Text = "EFD_DATE" Then
                str = "SELECT DISTINCT SPD_EFD " & _
                    "FROM SPLIST_DTL WITH(NOLOCK) " & _
                    "ORDER BY SPD_EFD DESC"
                adapt = New SqlDataAdapter(str, cn)
                dt = New DataTable
                adapt.Fill(dt)

                If dt.Rows.Count > 0 Then
                    c.Clear()
                    txtSearch.Clear()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        c.Add(Format(CDate(dt.Rows(i).Item("SPD_EFD").ToString), "MM/dd/yyyy"))
                    Next
                    AutoComp = True
                Else
                    AutoComp = False
                End If
            Else
                AutoComp = False
            End If
        Else
            AutoComp = False
        End If
        If AutoComp = True Then
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSearch.AutoCompleteCustomSource = c
        Else
            c.Clear()
            txtSearch.Clear()
        End If
        cn.Dispose()
    End Sub
    Public Sub LoadData(strSearch As String)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", Where As String = ""
        Dim adapt As New SqlDataAdapter
        Dim dt As New DataTable

        If ProcessName = "ITEM_MASTERH" Then
            If cbCat.Text = "BATCH_ID" Then
                Where = "WHERE BATCH_ID = '" & strSearch & "' "
            ElseIf cbCat.Text = "EFD_DATE" Then
                Where = "WHERE IMH_EFD_P1 = '" & strSearch & "' "
            End If
            str = "SELECT * FROM TMP_ITEM_MASTERH WITH(NOLOCK) " & Where & " " & _
                "ORDER BY IMH_CODE "
            adapt = New SqlDataAdapter(str, cn)
            dt = New DataTable
            adapt.Fill(dt)

            If dt.Rows.Count > 0 Then
                d.Rows.Clear()
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        txtBatchID.Text = dt.Rows(i).Item("Batch_ID").ToString
                        txtEFDate.Text = Format(CDate(dt.Rows(i).Item("IMH_EFD_P1").ToString), "MM/dd/yyyy")
                    End If
                    d.Rows.Add()
                    d("BRANCH", i).Value = dt.Rows(i).Item("MOTHER_BRANCH").ToString
                    d("IMH_CODE", i).Value = dt.Rows(i).Item("IMH_CODE").ToString
                    d("IMH_DESC", i).Value = dt.Rows(i).Item("IMH_DESC").ToString
                Next
                If dt.Rows(0).Item("IS_SYNC").ToString = "Y" Then
                    btnCancel.Enabled = False
                ElseIf dt.Rows(0).Item("IS_SYNC").ToString = "N" Then
                    btnCancel.Enabled = True
                Else
                    btnCancel.Enabled = False
                End If

                str = "SELECT DISTINCT ERR_BRANCH FROM ERR_LOGS WITH(NOLOCK) WHERE BATCH_ID = '" & txtBatchID.Text & "' AND STAT = 'O' ORDER BY ERR_BRANCH "
                adapt = New SqlDataAdapter(str, cn)
                dt = New DataTable
                adapt.Fill(dt)

                cbErrList.Items.Clear()
                If dt.Rows.Count > 0 Then
                    cbErrList.Items.Add("")
                    For i As Integer = 0 To dt.Rows.Count - 1
                        cbErrList.Items.Add(dt.Rows(i).Item("ERR_BRANCH").ToString)
                    Next
                End If

            Else
                d.Rows.Clear()
            End If
        Else
            If cbCat.Text = "BATCH_ID" Then
                Where = "WHERE A.BATCH_ID = '" & strSearch & "' "
            ElseIf cbCat.Text = "EFD_DATE" Then
                Where = "WHERE SPD_EFD = '" & strSearch & "' "
            End If
            str = "SELECT DISTINCT A.BATCH_ID, A.SPD_EFD, A.SPD_IMH_CODE, B.IMH_DESC, C.IS_SYNC " & _
                "FROM SPLIST_DTL A WITH(NOLOCK) " & _
                "INNER JOIN CONSOLIDATED_IMH B WITH(NOLOCK) ON A.SPD_IMH_CODE = B.IMH_CODE " & _
                "INNER JOIN BATCH_SPLIST C WITH(NOLOCK) ON A.BATCH_ID = C.BATCH_ID " & Where & " " & _
                "ORDER BY A.SPD_IMH_CODE "
            adapt = New SqlDataAdapter(str, cn)
            dt = New DataTable
            adapt.Fill(dt)

            If dt.Rows.Count > 0 Then
                d.Rows.Clear()
                For i As Integer = 0 To dt.Rows.Count - 1
                    If i = 0 Then
                        txtBatchID.Text = dt.Rows(i).Item("Batch_ID").ToString
                        txtEFDate.Text = Format(CDate(dt.Rows(i).Item("SPD_EFD").ToString), "MM/dd/yyyy")
                    End If
                    d.Rows.Add()
                    d("IMH_CODE", i).Value = dt.Rows(i).Item("SPD_IMH_CODE").ToString
                    d("IMH_DESC", i).Value = dt.Rows(i).Item("IMH_DESC").ToString
                Next
                If dt.Rows(0).Item("IS_SYNC").ToString = "Y" Then
                    btnCancel.Enabled = False
                ElseIf dt.Rows(0).Item("IS_SYNC").ToString = "N" Then
                    btnCancel.Enabled = True
                Else
                    btnCancel.Enabled = False
                End If
                str = "SELECT DISTINCT ERR_BRANCH FROM ERR_LOGS WITH(NOLOCK) WHERE BATCH_ID = '" & txtBatchID.Text & "' AND STAT = 'O' ORDER BY ERR_BRANCH "
                adapt = New SqlDataAdapter(str, cn)
                dt = New DataTable
                adapt.Fill(dt)

                cbErrList.Items.Clear()
                If dt.Rows.Count > 0 Then
                    cbErrList.Items.Add("")
                    For i As Integer = 0 To dt.Rows.Count - 1
                        cbErrList.Items.Add(dt.Rows(i).Item("ERR_BRANCH").ToString)
                    Next
                End If
              
            Else
                d.Rows.Clear()
            End If
        End If

        txtSearch.Text = strSearch
    End Sub
    Public Sub ClearAll()
        cbCat.SelectedIndex = -1
        cbSearchType.SelectedIndex = -1
        ProcessName = ""
        txtSearch.Text = ""
        txtBatchID.Text = ""
        txtEFDate.Text = ""
        d.Rows.Clear()
    End Sub
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        ProcessName = ""
        Me.Dispose()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        'If vtxtSearch.Text = "" Then
        '    vtxtSearch.Text = txtSearch.Text
        'End If
        If cbSearchType.Text = "" Or cbCat.Text = "" Or txtSearch.Text = "" Then MessageBox.Show("Please Complete Details", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If cbSearchType.Text = "ITEM MASTERH" Then
            ProcessName = "ITEM_MASTERH"
        Else
            ProcessName = "SPLIST_DTL"
        End If
        LoadData(txtSearch.Text)
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress

        If cbCat.Text = "BATCH_ID" Then
            If Not IsNumeric(e.KeyChar) = True AndAlso Not e.KeyChar = ControlChars.Back _
                AndAlso Not Asc(e.KeyChar) = 46 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub cbSearchType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSearchType.SelectedIndexChanged
        If ProcessName = "" Then
            LoadFlds()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If cbSearchType.Text = "" Or cbCat.Text = "" Or txtSearch.Text = "" Then MessageBox.Show("Please complete Details", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub

        If MessageBox.Show("Do you want to Cancel " & ProcessName & " [Y/N]?", "Price Mster", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        Try
            If cbSearchType.Text = "ITEM MASTERH" Then
                str = "SELECT TOP 1 1 FROM TMP_ITEM_MASTERH WHERE BATCH_ID = '" & txtBatchID.Text & "' AND IS_SYNC ='N'"
                cmd = New SqlCommand(str, cn)
                str = cmd.ExecuteScalar

                If Not str Is Nothing Then
                    str = "UPDATE TMP_ITEM_MASTERH SET IS_SYNC = 'X' WHERE BATCH_ID = '" & txtBatchID.Text & "' "
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Transaction Cancelled", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearAll()
                Else
                    MessageBox.Show("Data not found or Status is already sync", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                str = "SELECT TOP 1 1 " & _
                    "FROM SPLIST_DTL A WITH(NOLOCK) " & _
                    "INNER JOIN BATCH_SPLIST B WITH(NOLOCK) ON A.BATCH_ID = B.BATCH_ID"
                cmd = New SqlCommand(str, cn)
                str = cmd.ExecuteScalar

                If Not str Is Nothing Then
                    str = "UPDATE BATCH_SPLIST SET IS_SYNC ='X' WHERE BATCH_ID = '" & txtBatchID.Text & "' "
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Transaction Cancelled", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearAll()
                Else
                    MessageBox.Show("Data not found or Status is already sync", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAll()
    End Sub

    Private Sub cbCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbCat.SelectedIndexChanged
        LoadFlds()
    End Sub

    Private Sub frmConfig_Udpate_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class