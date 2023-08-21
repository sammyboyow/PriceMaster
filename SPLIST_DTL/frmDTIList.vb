Imports System.Data.SqlClient
Public Class frmDTIList
    Dim ForUpdate As Boolean = False
    Dim vPrice As String = ""
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
    Public Sub LoadDTI()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT IMH_CODE, START_DATE, END_DATE, PRICE FROM SPLIST_DTI WITH(NOLOCK) ORDER BY IMH_CODE "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        dt = New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            d.Rows.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                d.Rows.Add()
                d("IMH_CODE", i).Value = dt.Rows(i).Item("IMH_CODE").ToString
                d("START_DATE", i).Value = Format(CDate(dt.Rows(i).Item("START_DATE").ToString), "MM/dd/yyyy")
                d("END_DATE", i).Value = Format(CDate(dt.Rows(i).Item("END_DATE").ToString), "MM/dd/yyyy")
                If dt.Rows(i).Item("PRICE").ToString = Nothing Then
                    d("PRICE", i).Value = "0.00"
                Else
                    d("PRICE", i).Value = CDbl(dt.Rows(i).Item("PRICE").ToString)
                End If

                str = "SELECT DISTINCT B.Blk " & _
                    "FROM SPLIST_DTI A WITH(NOLOCK) " & _
                    "INNER JOIN SAPSET B WITH(NOLOCK) ON A.BRANCH_CODE " & _
                    "COLLATE DATABASE_DEFAULT = B.Code COLLATE DATABASE_DEFAULT " & _
                    "WHERE IMH_CODE = '" & dt.Rows(i).Item("IMH_CODE").ToString & "' AND PRICE = '" & d("PRICE", i).Value & "' "
                adapt = New SqlDataAdapter(str, cn)
                Dim dt2 As New DataTable
                adapt.Fill(dt2)

                If dt2.Rows.Count > 0 Then
                    Dim c As DataGridViewComboBoxCell
                    c = d.Rows(i).Cells("BRANCH")
                    c.ReadOnly = False
                    c.Items.Add("")
                    For ii As Integer = 0 To dt2.Rows.Count - 1
                        c.Items.Add(dt2.Rows(ii).Item("Blk").ToString)
                        c.Value = ""
                    Next
                End If
                If DateDiff(DateInterval.Weekday, Now, CDate(dt.Rows(i).Item("END_DATE").ToString)) <= 2 Then
                    d.Rows(i).DefaultCellStyle.BackColor = Color.Coral
                End If
            Next
        End If
        cn.Dispose()
    End Sub
    Public Function GetDesc(ByVal Code As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT IMH_DESC FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(Code, "'", "''") & "' "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        dt = New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item("IMH_DESC").ToString
        Else
            Return Nothing
        End If
        cn.Dispose()
    End Function
    Public Sub LoadTest()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK) "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        dt = New DataTable
        adapt.Fill(dt)

        Dim c As New AutoCompleteStringCollection()
        If dt.Rows.Count > 0 Then
            txtCode.Clear()
            c.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                c.Add(dt.Rows(i).Item("IMH_CODE").ToString)
                c.Add(dt.Rows(i).Item("IMH_DESC").ToString)
            Next
        End If
        txtCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtCode.AutoCompleteCustomSource = c
        cn.Dispose()
    End Sub
    Public Sub LoadBranch()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT B.Code, B.Blk " & _
                            "FROM " & _
                            "   (SELECT DISTINCT Company, MotherWhs " & _
                            "    FROM BscPriceLvl_Master WITH(NOLOCK) " & _
                            "   ) A " & _
                            "INNER JOIN SAPSET B WITH(NOLOCK) ON A.MotherWhs = B.Code " & _
                            "ORDER BY B.Blk"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = 0
        If dr.HasRows Then
            D2.Rows.Clear()
            While dr.Read
                D2.Rows.Add()
                D2("chk", i).Value = True
                D2("M_Branch", i).Value = dr("Blk")
                D2("Code", i).Value = dr("Code")
                i += 1
            End While
        Else
            D2.Rows.Clear()
        End If
        dr.Close()
        cn.Dispose()

    End Sub
    Public Sub chkAll_Branch()
        For i As Integer = 0 To D2.Rows.Count - 1
            D2("chk", i).Value = True
        Next
    End Sub
#End Region
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MessageBox.Show("Do you want to Save/Update DTI?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand


        Try
            If ForUpdate = True Then
                str = "DELETE SPLIST_DTI WHERE IMH_CODE = '" & Replace(txtCode.Text, "'", "''") & "' AND PRICE = '" & vPrice & "' "
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()
            End If        
            For i As Integer = 0 To D2.Rows.Count - 1
                If D2("chk", i).Value = True Then
                    'str = "SELECT TOP 1 1 FROM SPLIST_DTI WITH(NOLOCK) WHERE IMH_CODE = '" & Replace(txtCode.Text, "'", "''") & "' AND BRANCH_CODE = '" & D2("Code", i).Value & "' "
                    If ForUpdate = True Then
                        'If str Is Nothing Then
                        'str = "INSERT INTO SPLIST_DTI (IMH_CODE, START_DATE, END_DATE, PRICE, BRANCH_CODE) VALUES ('" & Replace(txtCode.Text, "'", "''") & "', " & _
                        '    "'" & dtFrom.Value & "','" & dtTo.Value & "','" & txtPrice.Text & "','" & D2("Code", i).Value & "')"
                        'Else
                        '    str = "UPDATE SPLIST_DTI  " & _
                        '       "SET START_DATE = '" & dtFrom.Value & "' , END_DATE = '" & dtTo.Value & "', PRICE = '" & txtPrice.Text & "' " & _
                        '       "WHERE IMH_CODE = '" & Replace(txtCode.Text, "'", "''") & "' AND BRANCH_CODE = '" & D2("Code", i).Value & "' "                     
                        'End If
                        str = "INSERT INTO SPLIST_DTI (IMH_CODE, START_DATE, END_DATE, PRICE, BRANCH_CODE) VALUES ('" & Replace(txtCode.Text, "'", "''") & "', " & _
                           "'" & dtFrom.Value & "','" & dtTo.Value & "','" & txtPrice.Text & "','" & D2("Code", i).Value & "')"
                        cmd = New SqlCommand(str, cn)
                        cmd.ExecuteNonQuery()
                    Else                        
                        str = "INSERT INTO SPLIST_DTI (IMH_CODE, START_DATE, END_DATE, PRICE, BRANCH_CODE) VALUES ('" & Replace(txtCode.Text, "'", "''") & "', " & _
                            "'" & dtFrom.Value & "','" & dtTo.Value & "','" & txtPrice.Text & "','" & D2("Code", i).Value & "')"
                        cmd = New SqlCommand(str, cn)
                        cmd.ExecuteNonQuery()
                    End If
                End If
            Next
            MessageBox.Show("Data Save/Update Succesfuly", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnClear.PerformClick()
            LoadDTI()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        cn.Dispose()
        ForUpdate = False
        vPrice = ""
    End Sub

    Private Sub frmDTIList_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadDTI()
        LoadTest()
        LoadBranch()
        chkAll_Branch()
        chkALL.Checked = True
    End Sub
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        btnSave.Text = "SAVE"
        dtFrom.Value = Now
        dtTo.Value = Now
        ForUpdate = False
        txtCode.Enabled = True
        txtCode.ReadOnly = False
        chkALL.Checked = True
        txtCode.Text = ""
        txtDesc.Text = ""
        txtPrice.Text = ""
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        If MessageBox.Show("Do you want to Delete DTI?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim str As String = ""
        Dim cmd As New SqlCommand

        For i As Integer = 0 To D2.Rows.Count - 1
            If D2("chk", i).Value = True Then
                str = "SELECT TOP 1 1 FROM SPLIST_DTI WITH(NOLOCK) WHERE IMH_CODE = '" & Replace(txtCode.Text, "'", "''") & "' AND BRANCH_CODE = '" & D2("Code", i).Value & "' "
                cmd = New SqlCommand(str, cn)
                str = cmd.ExecuteScalar

                Try
                    If Not str Is Nothing Then
                        str = "DELETE SPLIST_DTI WHERE IMH_CODE = '" & Replace(txtCode.Text, "'", "''") & "' AND BRANCH_CODE = '" & D2("Code", i).Value & "' "
                        cmd = New SqlCommand(str, cn)
                        cmd.ExecuteNonQuery()
                        'MessageBox.Show("Test Code Deleted", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        'MessageBox.Show("Test Code not exists", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        'Exit Sub
                    End If
                
                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Try
            End If       
        Next
        MessageBox.Show("Test Code Deleted", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
        chkAll_Branch()
        btnClear.PerformClick()
        LoadDTI()
        cn.Dispose()
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not IsNumeric(e.KeyChar) = True AndAlso Not e.KeyChar = ControlChars.Back AndAlso Not Asc(e.KeyChar) = 46 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(txtCode.Text, "'", "''") & "' OR " & _
                                "IMH_DESC = '" & Replace(txtCode.Text, "'", "''") & "' "
            Dim adapt As New SqlDataAdapter(str, cn)
            Dim dt As New DataTable
            dt = New DataTable
            adapt.Fill(dt)

            If dt.Rows.Count > 0 Then
                txtCode.Text = dt.Rows(0).Item("IMH_CODE").ToString
                txtDesc.Text = dt.Rows(0).Item("IMH_DESC").ToString
            Else
                MessageBox.Show("Test Code not found", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtCode.Text = ""
                txtDesc.Text = ""
            End If
            cn.Dispose()
        End If

    End Sub
    Private Sub d_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d.MouseDoubleClick
        If d.Rows.Count = 0 Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim adapt As New SqlDataAdapter
        Dim dt As New DataTable

        chkALL.Checked = False
        For i As Integer = 0 To D2.Rows.Count - 1
            D2("chk", i).Value = False
        Next
        str = "SELECT * FROM SPLIST_DTI WHERE IMH_CODE = '" & Replace(d("IMH_CODE", d.CurrentRow.Index).Value, "'", "''") & "' AND PRICE = '" & d("PRICE", d.CurrentRow.Index).Value & "' "
        adapt = New SqlDataAdapter(str, cn)
        dt = New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                If i = 0 Then
                    txtCode.Text = dt.Rows(i).Item("IMH_CODE").ToString
                    txtDesc.Text = GetDesc(dt.Rows(i).Item("IMH_CODE").ToString)
                    dtFrom.Value = dt.Rows(i).Item("START_DATE").ToString
                    dtTo.Value = dt.Rows(i).Item("END_DATE").ToString
                    txtPrice.Text = dt.Rows(i).Item("Price").ToString
              
                End If
                For ii As Integer = 0 To D2.Rows.Count - 1
                    If D2("Code", ii).Value = dt.Rows(i).Item("Branch_Code").ToString Then
                        D2("chk", ii).Value = True
                        'Else
                        '    D2("chk", ii).Value = False
                    End If
                Next
            Next 
        End If
        ForUpdate = True
        vPrice = txtPrice.Text
        btnSave.Text = "UPDATE"
        cn.Dispose()
    End Sub

    Private Sub chkALL_CheckedChanged(sender As Object, e As EventArgs) Handles chkALL.CheckedChanged
        If chkALL.Checked = True Then
            For i As Integer = 0 To D2.Rows.Count - 1
                D2("chk", i).Value = True
            Next
        Else
            For i As Integer = 0 To D2.Rows.Count - 1
                D2("chk", i).Value = False
            Next
        End If
    End Sub

    Private Sub d_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d.CellContentClick

    End Sub
End Class