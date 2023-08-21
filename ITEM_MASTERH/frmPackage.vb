Imports System.Data.SqlClient
Imports System.Data.Odbc
Public Class frmPackage
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
#Region "SUB PROCEDURE/FUNCTION"
    Public Sub LoadBranch()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT B.Blk " & _
                            "FROM " & _
                            "   (SELECT DISTINCT Company, MotherWhs " & _
                            "    FROM BscPriceLvl_Master WITH(NOLOCK) " & _
                            "   ) A " & _
                            "INNER JOIN SAPSET B WITH(NOLOCK) ON A.MotherWhs = B.Code " & _
                            "ORDER BY B.Blk"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            cbBranch.Items.Clear()
            cbBranch.Items.Add("")
            cbBranch.Items.Add("TEST")
            While dr.Read
                cbBranch.Items.Add(dr("Blk"))
            End While
        Else
            cbBranch.Items.Clear()
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Function GetCode(ByVal Branch As String) As String
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT CODE FROM SAPSET WITH(NOLOCK) WHERE BLK = '" & Branch & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            If cbBranch.Text = "TEST" Then
                Return "011"
            Else
                Return Nothing
            End If
        Else
            Return str
        End If

        cn.Dispose()
    End Function
    Public Sub LoadTestCodes(ByVal BranchCode As String)
        If cbBranch.Text = "" Then txtTestCode.Clear() : Exit Sub
        If cbBranch.Text = "TEST" Then
            BranchCode = "011"
        End If
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT ISNULL(IMH_CODE, '') IMH_CODE, ISNULL(IMH_DESC, '') IMH_DESC " & _
                            "FROM ITEM_MASTERH WITH(NOLOCK) " & _
                            "WHERE WHSCODE = '" & BranchCode & "' AND IMH_TYPE = 'P' " & _
                            "ORDER BY IMH_CODE "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim c As New AutoCompleteStringCollection()
        If dr.HasRows Then
            c.Clear()
            While dr.Read
                c.Add(dr("IMH_CODE"))
                c.Add(dr("IMH_DESC"))
            End While
        Else
            c.Clear()
        End If
        dr.Close()
        txtTestCode.Clear()
        txtTestCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtTestCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTestCode.AutoCompleteCustomSource = c
        cn.Dispose()
    End Sub
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim total As Double = 0.0
        For i As Integer = 0 To dPackage.Rows.Count - 1
            total = total + dPackage("CurPrice", i).Value
        Next
        If total <> txtPrice.Text Then
            MessageBox.Show("Package header price is not equal to details total price", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            If CDbl(txtPrice.Text) > total Then
                lblDescr.Text = "Total Price is higher than detailed Price: " & (CDbl(txtPrice.Text) - total)
            ElseIf total > CDbl(txtPrice.Text) Then
                lblDescr.Text = "Details price is higher than Total price: " & (total - CDbl(txtPrice.Text))
            End If
            lblDescr.Visible = True
            Exit Sub
        Else
            lblDescr.Visible = False
        End If

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        str = "SELECT TOP 1 1 FROM TMP_PKG_HDR WITH(NOLOCK) WHERE PKG_CODE = '" & Replace(txtTestCode.Text, "'", "''") & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Dim SEQ As Integer = 10
        If str Is Nothing Then
            Try
                cmd = New SqlCommand("BEGIN TRAN", cn)
                cmd.ExecuteNonQuery()

                str = "INSERT INTO TMP_PKG_HDR VALUES ('" & Replace(txtTestCode.Text, "'", "''") & "','" & Replace(txtTestDesc.Text, "'", "''") & "','" & CDbl(txtPrice.Text) & "','" & CDbl(total) & "')"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()

                For i As Integer = 0 To dPackage.Rows.Count - 1
                    str = "INSERT INTO TMP_PKG_DTL VALUES ('" & Replace(txtTestCode.Text, "'", "''") & "','" & SEQ & "','" & dPackage("TestCode", i).Value & "','" & dPackage("PrvPrice", i).Value & "','" & dPackage("CurPrice", i).Value & "')"
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()
                    SEQ = SEQ + 10
                Next

                cmd = New SqlCommand("COMMIT", cn)
                cmd.ExecuteNonQuery()

                d.Rows.Add(txtTestCode.Text, txtTestDesc.Text, txtPrice.Text, total)
                dPackage.Rows.Clear()
                txtTestCode.Text = ""
                txtTestDesc.Text = ""
                txtPrice.Text = ""
                cbBranch.Enabled = False
            Catch ex As Exception
                cmd = New SqlCommand("ROLLBACK", cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            MessageBox.Show("Package Already Encoded", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

    End Sub

    Private Sub frmPackage_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBranch()
    End Sub

    Private Sub cbBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbBranch.SelectedIndexChanged

        LoadTestCodes(GetCode(cbBranch.Text))
        txtPrice.Text = ""
        dPackage.Rows.Clear()
        txtTestCode.Text = ""
        txtTestDesc.Text = ""
    End Sub

    Private Sub txtPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPrice.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSAP)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT DISTINCT IMD_PKG_ITEM, IMH_DESC, IMD_PKG_PRICE " & _
                                "FROM ITEM_MASTERH A " & _
                                "INNER JOIN ITEM_MASTERD B ON IMH_CODE = IMD_PKG_ITEM AND A.WHSCODE = B.WHSCODE " & _
                                "WHERE IMD_PKG_CODE = '" & Replace(txtTestCode.Text, "'", "''") & "' AND A.WHSCODE ='" & GetCode(cbBranch.Text) & "' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            Dim i As Integer = 0
            If dr.HasRows Then
                dPackage.Rows.Clear()
                While dr.Read
                    dPackage.Rows.Add()
                    dPackage("TestCode", i).Value = dr("IMD_PKG_ITEM")
                    dPackage("TestDesc", i).Value = dr("IMH_DESC")
                    dPackage("PrvPrice", i).Value = Format(CDbl(dr("IMD_PKG_PRICE")), "N2")
                    dPackage("CurPrice", i).Value = "0.00"
                    i += 1
                End While
            Else
                dPackage.Rows.Clear()
            End If
            dr.Close()
            cn.Dispose()
        End If
    End Sub
    Private Sub txtTestCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTestCode.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSAP)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT ISNULL(IMH_CODE, '') IMH_CODE, ISNULL(IMH_DESC, '') IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK) " & _
                                "WHERE IMH_CODE = '" & Replace(txtTestCode.Text, "'", "''") & "' AND WHSCODE = '" & Replace(GetCode(cbBranch.Text), "'", "''") & "' AND IMH_TYPE ='P' " & _
                                "OR IMH_DESC ='" & Replace(txtTestCode.Text, "'", "''") & "' AND  WHSCODE = '" & Replace(GetCode(cbBranch.Text), "'", "''") & "' AND IMH_TYPE ='P' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    txtTestCode.Text = dr("IMH_CODE")
                    txtTestDesc.Text = dr("IMH_DESC")
                End While
            Else
                MessageBox.Show("Test Code not found", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtTestCode.Text = ""
                txtTestDesc.Text = ""
            End If
            dr.Close()
            cn.Dispose()
        End If
    End Sub

    Private Sub txtTestCode_TextChanged(sender As Object, e As EventArgs) Handles txtTestCode.TextChanged
        If txtTestCode.Text = "" Then
            txtTestDesc.Text = ""
            txtPrice.Text = ""
            dPackage.Rows.Clear()
        End If
    End Sub

    Private Sub dPackage_KeyDown(sender As Object, e As KeyEventArgs) Handles dPackage.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Do you want to delete Test Code?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            dPackage.Rows.RemoveAt(dPackage.CurrentRow.Index)
        End If
    End Sub
    Private Sub dPackage_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles dPackage.MouseDoubleClick
        If dPackage.CurrentCell.ColumnIndex = 2 Then
            dPackage("CurPrice", dPackage.CurrentRow.Index).Value = dPackage("PrvPrice", dPackage.CurrentRow.Index).Value
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If d.Rows.Count = 0 Then
            txtSearch.Text = ""
            MessageBox.Show("No data to search", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        For Each row As DataGridViewRow In d.Rows
            If UCase(Mid(row.Cells(0).Value, 1, Len(txtSearch.Text))) = UCase(txtSearch.Text) Then
                d.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                d.CurrentCell = row.Cells(0)
            End If
        Next
    End Sub

    Private Sub txtPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrice.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) AndAlso Asc(e.KeyChar) <> 46 Then
            e.Handled = True
            MessageBox.Show("Please Enter Numbers Only", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
    Private Sub d_KeyDown(sender As Object, e As KeyEventArgs) Handles d.KeyDown
        If e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Do you want to delete Test Code?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = ""
            Dim cmd As New SqlCommand

            Try
                cmd = New SqlCommand("BEGIN TRAN", cn)
                cmd.ExecuteNonQuery()

                str = "DELETE TMP_PKG_HDR WHERE PKG_CODE = '" & Replace(d("Pkg_ID", d.CurrentRow.Index).Value, "'", "''") & "' "
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()

                str = "DELETE TMP_PKG_DTL WHERE PKG_CODE = '" & Replace(d("Pkg_ID", d.CurrentRow.Index).Value, "'", "''") & "' "
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()

                cmd = New SqlCommand("COMMIT", cn)
                cmd.ExecuteNonQuery()

                MessageBox.Show("Package Deleted", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
                d.Rows.RemoveAt(d.CurrentRow.Index)

                If d.Rows.Count = 0 Then
                    cbBranch.Enabled = True
                End If
            Catch ex As Exception
                cmd = New SqlCommand("ROLLBACK", cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
            cn.Dispose()
        End If
    End Sub

    Private Sub btnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If cbBranch.Text = "" Then MessageBox.Show("Please Select Mother Branch", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If d.Rows.Count = 0 Then MessageBox.Show("No details to Post", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub

        If MessageBox.Show("Do you want to Post Schedule?", "Price Master", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        Try
            cmd = New SqlCommand("BEGIN TRAN", cn2)
            cmd.ExecuteNonQuery()

            For i As Integer = 0 To d.Rows.Count - 1
                str = "SELECT ISNULL(MAX(DocEntry), 0) + 1 FROM IMH_PKG_HDR WITH(NOLOCK) "
                cmd = New SqlCommand(str, cn)
                Dim DocEntry As String = cmd.ExecuteScalar

                If DocEntry Is Nothing Then
                    MessageBox.Show("System Sequence Error Please Contact IT-RANJIE for assistance", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If

                Dim Branch As String = ""
                If cbBranch.Text = "TEST" Then
                    Branch = "TEST"
                Else
                    Branch = GetCode(cbBranch.Text)
                End If
                str = "INSERT INTO IMH_PKG_HDR VALUES ('" & DocEntry & "','" & Branch & "','" & dtEffect.Value & "','" & d("Pkg_ID", i).Value & "' " & _
                    ",'" & d("Pkg_Desc", i).Value & "','" & d("Prv_Price", i).Value & "','" & d("Cur_Price", i).Value & "',GETDATE(),'" & Info.POSID & "')"
                cmd = New SqlCommand(str, cn2)
                cmd.ExecuteNonQuery()

                str = "SELECT * FROM TMP_PKG_DTL WITH(NOLOCK) WHERE PKG_CODE ='" & Replace(d("Pkg_ID", i).Value, "'", "''") & "' "
                cmd = New SqlCommand(str, cn)
                Dim dr = cmd.ExecuteReader

                If dr.HasRows Then
                    While dr.Read
                        str = "INSERT INTO IMH_PKG_DTL VALUES ('" & DocEntry & "','" & d("Pkg_ID", i).Value & "','" & dr("PKG_ITEM") & "' " & _
                            ",'" & dr("PKG_ITEM_SEQ") & "','" & dr("PKG_ITM_PRV_PRICE") & "','" & dr("PKG_ITM_CUR_PRICE") & "')"
                        cmd = New SqlCommand(str, cn2)
                        cmd.ExecuteNonQuery()
                    End While
                End If
                dr.Close()

                str = "DELETE TMP_PKG_HDR WHERE PKG_CODE= '" & d("Pkg_ID", i).Value & "' "
                cmd = New SqlCommand(str, cn2)
                cmd.ExecuteNonQuery()

                str = "DELETE TMP_PKG_DTL WHERE PKG_CODE= '" & d("Pkg_ID", i).Value & "' "
                cmd = New SqlCommand(str, cn2)
                cmd.ExecuteNonQuery()
            Next

            cmd = New SqlCommand("COMMIT", cn2)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Done Posting", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
            d.Rows.Clear()
            cbBranch.Enabled = True
            cbBranch.SelectedIndex = -1
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK", cn2)
            cmd.ExecuteNonQuery()
            MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        cn.Dispose()
        cn2.Dispose()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        For i As Integer = 0 To d.Rows.Count - 1
            Dim str As String = ""
            Dim cmd As New SqlCommand

            Try
                cmd = New SqlCommand("BEGIN TRAN", cn)
                cmd.ExecuteNonQuery()

                str = "DELETE TMP_PKG_HDR WHERE PKG_CODE = '" & Replace(d("Pkg_ID", i).Value, "'", "''") & "' "
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()

                str = "DELETE TMP_PKG_DTL WHERE PKG_CODE = '" & Replace(d("Pkg_ID", i).Value, "'", "''") & "' "
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()

                cmd = New SqlCommand("COMMIT", cn)
                cmd.ExecuteNonQuery()

                d.Rows.RemoveAt(i)
                If d.Rows.Count = 0 Then
                    cbBranch.Enabled = True
                End If
            Catch ex As Exception
                cmd = New SqlCommand("ROLLBACK", cn)
                cmd.ExecuteNonQuery()
                MessageBox.Show(ex.Message, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Next
        cn.Dispose()
    End Sub

    Private Sub btnClearDtl_Click(sender As Object, e As EventArgs) Handles btnClearDtl.Click
        dPackage.Rows.Clear()
        txtTestCode.Text = ""
        txtTestDesc.Text = ""
        txtPrice.Text = ""
        lblDescr.Visible = False
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged

    End Sub
End Class