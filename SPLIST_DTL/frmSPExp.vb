Imports System.Data.SqlClient
Public Class frmSPExp
#Region "SUB PROCEDURE/FUNCTION"
    Public Sub LoadSP()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT PRICELIST FROM price_level_dtl WITH(NOLOCK) ORDER BY PRICELIST "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim c As New AutoCompleteStringCollection()
        If dr.HasRows Then
            txtSPCode.Clear()
            c.Clear()
            txtSPCode.Text = ""
            While dr.Read
                c.Add(dr("PRICELIST"))
            End While
        End If
        dr.Close()

        txtSPCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtSPCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtSPCode.AutoCompleteCustomSource = c

    End Sub
    Public Sub AddItems(ByVal col As AutoCompleteStringCollection)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim str As String = ""

        str = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WHERE IMH_REC_FLAG='N' AND IMH_TYPE='S' ORDER BY IMH_DESC"
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                col.Add(dr("IMH_CODE"))
                col.Add(dr("IMH_DESC"))
            End While
        End If
        dr.Close()
    End Sub
    Public Function ValidateAlphabet(ByVal StringToCheck As String) As Boolean
        Dim RetValue As Boolean = False
        If StringToCheck = Nothing Then
            Return False
            Exit Function
        End If
        For i As Integer = 0 To StringToCheck.Length - 1
            If Not Char.IsNumber(StringToCheck(i)) AndAlso Not Asc(StringToCheck(i)) = 46 Then
                RetValue = True
                Exit For
            Else
                RetValue = False
            End If
        Next
        Return RetValue
    End Function
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbPriceLevel.Text = "" Or txtSPCode.Text = "" Then MessageBox.Show("Please Enter Price Level or Price List", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If d.Rows.Count = 0 Then MessageBox.Show("Please Enter test code to except", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub

        If MessageBox.Show("Do you want to Save transaction?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub


        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        Try           
            cmd = New SqlCommand("BEGIN TRAN", cn)
            cmd.ExecuteNonQuery()

            str = "DELETE SPLIST_Except WHERE Price_Level = '" & cbPriceLevel.Text & "' AND Price_List= '" & txtSPCode.Text & "'  "
            cmd = New SqlCommand(str, cn)
            str = cmd.ExecuteNonQuery

            For i As Integer = 0 To d.Rows.Count - 1
                If d("TEST_CODE", i).Value = Nothing Then Exit For
                str = "INSERT INTO SPLIST_Except VALUES ('" & cbPriceLevel.Text & "','" & txtSPCode.Text & "','" & d("TEST_CODE", i).Value & "', '" & d("Ex_Price", i).Value & "')"
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()
            Next
            cmd = New SqlCommand("COMMIT", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Done saving", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnClear.PerformClick()
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
       
    End Sub

    Private Sub d_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles d.CellEndEdit
        If d.CurrentCell.ColumnIndex = 2 Then
            If ValidateAlphabet(d("Ex_Price", d.CurrentRow.Index).Value) = True Then
                MessageBox.Show("Please enter numbers for price column", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                d("Ex_Price", d.CurrentRow.Index).Value = Nothing
            Else
                If d.CurrentRow.Index = d.Rows.Count - 1 Then
                    d.Rows.Add()
                End If

            End If
        End If
    End Sub
    Private Sub d_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles d.EditingControlShowing
        If d.Columns(d.CurrentCell.ColumnIndex).HeaderText = "TEST CODE" Then
            If d.CurrentCell.ColumnIndex = 0 Then
                Dim autoText As TextBox = TryCast(e.Control, TextBox)
                If autoText IsNot Nothing Then
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                    Dim DataCollection As New AutoCompleteStringCollection()
                    AddItems(DataCollection)
                    autoText.CharacterCasing = CharacterCasing.Upper
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

    Private Sub txtSPCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSPCode.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()
            Dim cn2 As New SqlConnection(cnSQL)
            If cn2.State = ConnectionState.Closed Then cn2.Open()

            Dim str As String = "SELECT PriceList, PriceList_Desc FROM Price_level_dtl WITH(NOLOCK) WHERE PriceList= '" & Replace(txtSPCode.Text, "'", "''") & "' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                dr.Read()
                txtSPCode.Text = dr("PriceList")
                txtSPDesc.Text = dr("PriceList_Desc")

                str = "SELECT DISTINCT PriceLevel FROM Price_level_dtl WHERE PriceList= '" & Replace(txtSPCode.Text, "'", "''") & "' "
                cmd = New SqlCommand(str, cn2)
                Dim dr1 As SqlDataReader = cmd.ExecuteReader
                If dr1.HasRows Then
                    cbPriceLevel.Items.Clear()
                    While dr1.Read
                        cbPriceLevel.Items.Add(dr1("PriceLevel"))
                    End While
                End If
                dr1.Close()
            End If
            dr.Close()
            cn.Dispose()
        End If
    End Sub
    Private Sub frmSPExp_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt And e.KeyCode.ToString = "F" Then
            If MessageBox.Show("Do you want to clear transaction?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            btnClear.PerformClick()
        End If
    End Sub

    Private Sub frmSPExp_Load(sender As Object, e As EventArgs) Handles Me.Load
        d.Rows.Add()
        LoadSP()
    End Sub

    Private Sub d_KeyDown(sender As Object, e As KeyEventArgs) Handles d.KeyDown
        If e.KeyCode = Keys.Return Then
            If d.CurrentCell.ColumnIndex = 0 Then
                If d("TEST_CODE", d.CurrentRow.Index).Value = Nothing Then Exit Sub

                Dim curIndex As Integer = d.CurrentRow.Index
                For i As Integer = 0 To d.Rows.Count - 1
                    If curIndex <> i Then
                        If d("TEST_CODE", i).Value = d("TEST_CODE", curIndex).Value Then
                            MessageBox.Show("Item Already Exists", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            d("TEST_CODE", d.CurrentRow.Index).Value = Nothing
                            d("TEST_DESC", d.CurrentRow.Index).Value = Nothing
                            Exit Sub
                        End If
                    End If
                Next

                Dim cn As New SqlConnection(cnSQL)
                If cn.State = ConnectionState.Closed Then cn.Open()

                Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH " & _
                                    "WHERE IMH_CODE = '" & Replace(d("TEST_CODE", d.CurrentRow.Index).Value, "'", "''") & "' " & _
                                    "OR IMH_DESC = '" & Replace(d("TEST_CODE", d.CurrentRow.Index).Value, "'", "''") & "' "
                Dim cmd As New SqlCommand(str, cn)
                Dim dr As SqlDataReader = cmd.ExecuteReader

                If dr.HasRows Then
                    While dr.Read
                        d("TEST_CODE", d.CurrentRow.Index).Value = dr("IMH_CODE")
                        d("TEST_DESC", d.CurrentRow.Index).Value = dr("IMH_DESC")
                    End While 
                Else
                    MessageBox.Show("Test Code not found", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                dr.Close()
                cn.Dispose()          
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Do you want to delete Test Code?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            d.Rows.RemoveAt(d.CurrentRow.Index)
            If d.Rows.Count = 0 Then
                d.Rows.Add()
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        d.Rows.Clear()
        d.Rows.Add()
        txtSPCode.Text = ""
        txtSPDesc.Text = ""
        cbPriceLevel.Items.Clear()
        cbPriceLevel.Text = ""
        chkIMG.Checked = False
        chkRegular.Checked = False
        chkSPECIAL.Checked = False
        chkUTZ.Checked = False
    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        If MessageBox.Show("This will clear test code on the table" & vbNewLine & "Do you want to proceed?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", IMH_BILLCODE As String = ""
        Dim cmd As New SqlCommand

        'If chkRegular.Checked = True Then
        '    IMH_BILLCODE = "'" & & "'"
        'End If
        'If chkIMG.Checked = True Then
        '    IMH_BILLCODE = "'" & & "'"
        'End If
        'If chkSPECIAL.Checked = True Then

        'End If
        'If chkUTZ.Checked = True Then

        'End If

        'str = "SELECT * FROM ITEM_MASTERH WHERE IMH_CODE IN (" & & ") "

        str = "SELECT IMH_CODE, IMH_DESC, IMH_TYPE, " & _
            "CASE WHEN IMH_BILLCODE = '1030' THEN 'ULTRASOUND' " & _
            "     WHEN IMH_BILLCODE BETWEEN '1000' AND '1020' THEN 'IMAGING' " & _
            "     WHEN IMH_BILLCODE BETWEEN '1040' AND '1100' THEN 'IMAGING' " & _
            "     WHEN IMH_BILLCODE = '9000' THEN 'IMAGING' " & _
            "     WHEN IMH_BILLCODE = '4500' THEN 'SPECIAL TESTS' " & _
            "ELSE 'REGULAR TESTS' END TestGrp " & _
            "FROM ITEM_MASTERH WHERE IMH_TYPE = 'S' " & _
            "ORDER BY IMH_CODE "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        adapt.Fill(dt)

        Dim Result() As DataRow
        '= dt.Select("TestGrp IN ()")
        If chkRegular.Checked = True And chkIMG.Checked = False And chkSPECIAL.Checked = False And chkUTZ.Checked = False Then
            Result = dt.Select("TestGrp IN ('REGULAR TESTS')")
        ElseIf chkRegular.Checked = False And chkIMG.Checked = True And chkSPECIAL.Checked = False And chkUTZ.Checked = False Then
            Result = dt.Select("TestGrp IN ('IMAGING')")
        ElseIf chkRegular.Checked = False And chkIMG.Checked = False And chkSPECIAL.Checked = True And chkUTZ.Checked = False Then
            Result = dt.Select("TestGrp IN ('SPECIAL TESTS')")
        ElseIf chkRegular.Checked = False And chkIMG.Checked = False And chkSPECIAL.Checked = False And chkUTZ.Checked = True Then
            Result = dt.Select("TestGrp IN ('ULTRASOUND')")
        ElseIf chkRegular.Checked = True And chkIMG.Checked = True And chkSPECIAL.Checked = False And chkUTZ.Checked = False Then
            Result = dt.Select("TestGrp IN ('REGULAR TESTS', 'IMAGING')")
        ElseIf chkRegular.Checked = True And chkIMG.Checked = False And chkSPECIAL.Checked = True And chkUTZ.Checked = False Then
            Result = dt.Select("TestGrp IN ('REGULAR TESTS', 'SPECIAL TESTS')")
        ElseIf chkRegular.Checked = True And chkIMG.Checked = False And chkSPECIAL.Checked = False And chkUTZ.Checked = True Then 'LAST CONDITION
            Result = dt.Select("TestGrp IN ('REGULAR TESTS', 'ULTRASOUND')")
        ElseIf chkRegular.Checked = False And chkIMG.Checked = True And chkSPECIAL.Checked = True And chkUTZ.Checked = False Then
            Result = dt.Select("TestGrp IN ('IMAGING', 'SPECIAL TESTS')")
        ElseIf chkRegular.Checked = False And chkIMG.Checked = True And chkSPECIAL.Checked = False And chkUTZ.Checked = True Then
            Result = dt.Select("TestGrp IN ('IMAGING', 'ULTRASOUND')")
        ElseIf chkRegular.Checked = False And chkIMG.Checked = False And chkSPECIAL.Checked = True And chkUTZ.Checked = True Then
            Result = dt.Select("TestGrp IN ('SPECIAL TESTS', 'ULTRASOUND')")
        ElseIf chkRegular.Checked = True And chkIMG.Checked = True And chkSPECIAL.Checked = True And chkUTZ.Checked = False Then '3 CONDITIONS START
            Result = dt.Select("TestGrp IN ('REGULAR TESTS', 'IMAGING', 'SPECIAL TESTS')")
        ElseIf chkRegular.Checked = False And chkIMG.Checked = True And chkSPECIAL.Checked = True And chkUTZ.Checked = True Then
            Result = dt.Select("TestGrp IN ('ULTRASOUND', 'IMAGING', 'SPECIAL TESTS')")
        ElseIf chkRegular.Checked = True And chkIMG.Checked = True And chkSPECIAL.Checked = False And chkUTZ.Checked = False Then
            Result = dt.Select("TestGrp IN ('REGULAR TESTS', 'IMAGING', 'ULTRASOUND')")
        ElseIf chkRegular.Checked = True And chkIMG.Checked = True And chkSPECIAL.Checked = False And chkUTZ.Checked = True Then
            Result = dt.Select("TestGrp IN ('REGULAR TESTS', 'IMAGING', 'ULTRASOUND')")
        ElseIf chkRegular.Checked = False And chkIMG.Checked = True And chkSPECIAL.Checked = True And chkUTZ.Checked = True Then
            Result = dt.Select("TestGrp IN ('SPECIAL TESTS', 'IMAGING', 'ULTRASOUND')")
        Else
            Result = Nothing
        End If

        d.Rows.Clear()
        Dim i As Integer = 0
        If dt.Rows.Count = 0 Then Exit Sub
        For Each Row As DataRow In Result
            d.Rows.Add()
            d("Test_Code", i).Value = Row(0)
            d("TEST_DESC", i).Value = Row(1)
            i += 1
        Next
        d.Rows.Add()

    End Sub

    Private Sub d_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d.CellContentClick

    End Sub
End Class