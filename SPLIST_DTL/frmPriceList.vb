Imports System.Data.SqlClient
Public Class frmPriceList
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
    Public Sub LoadHdr()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT * FROM Price_Level_Hdr WITH(NOLOCK) ORDER BY DOCENTRY "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = 0
        If dr.HasRows Then
            d1.Rows.Clear()
            While dr.Read
                d1.Rows.Add()
                d1("Mother", i).Value = dr("Mother_Branch")
                d1("Company", i).Value = dr("Company")
                d1("P1", i).Value = dr("Price_Level1")
                d1("P2", i).Value = dr("Price_Level2")
                d1("P3", i).Value = dr("Price_Level3")
                i += 1
            End While
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Sub LoadBranch()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT BLK FROM SAPSET WHERE STAT = 'O' ORDER BY BLK "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim c As New AutoCompleteStringCollection()
        If dr.HasRows Then
            txtBranchName.Clear()
            c.Clear()
            While dr.Read
                c.Add(dr("BLK"))
            End While
        End If
        dr.Close()
        cn.Dispose()
        txtBranchName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtBranchName.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtBranchName.AutoCompleteCustomSource = c
        txtBranchName.CharacterCasing = CharacterCasing.Upper
    End Sub
    Private Function SearchGrid(ByVal strItem As String, ByVal intColumn As Integer) As Integer
        Dim intIndex As Integer = 0
        For i As Integer = 0 To d1.Rows.Count - 1
            If d1.Rows(i).Cells(intColumn).Value = Nothing Then Exit For
            If d1.Rows(i).Cells(intColumn).Value.Contains(strItem) Then 'Or change "Contains" to "Equals"
                intIndex = i
                Exit For
            End If
        Next
        Return intIndex
    End Function
    Private Function SearchGrid2(ByVal strItem As String, ByVal intColumn As Integer) As Integer
        Dim intIndex As Integer = 0
        For i As Integer = 0 To d2.Rows.Count - 1
            If d2.Rows(i).Cells(intColumn).Value = Nothing Then Exit For
            If d2.Rows(i).Cells(intColumn).Value.Contains(strItem) Then 'Or change "Contains" to "Equals"
                intIndex = i
                Exit For
            End If
        Next
        Return intIndex
    End Function
    Public Sub LoadPriceLevel()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT DISTINCT PRICE_LEVEL FROM ( " & _
                            "SELECT Price_Level1 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
                            "UNION ALL " & _
                            "SELECT Price_Level2 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
                            "UNION ALL " & _
                            "SELECT Price_Level3 AS PRICE_LEVEL FROM Price_Level_Hdr) A"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            cbPriceLevel.Items.Clear()
            cbPriceLevel.Items.Add("")
            While dr.Read
                cbPriceLevel.Items.Add(dr("PRICE_LEVEL"))
            End While
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Sub LoadDtl()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT * FROM Price_Level_Dtl WITH(NOLOCK) ORDER BY PRICELEVEL"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim i As Integer = 0
        If dr.HasRows Then
            d2.Rows.Clear()
            While dr.Read
                d2.Rows.Add()
                d2("PRICE_LEVEL", i).Value = dr("PriceLevel")
                d2("PRICE_LIST", i).Value = dr("PriceList")
                'd2("PL_OLD", i).Value = dr("Old_PriceList")
                d2("PL_DESC", i).Value = dr("PriceList_Desc")
                i += 1
            End While
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Public Function LoadDisc(ByVal Percenatge As String, ByVal DiscountType As String) As String
        Dim Discount As String = ""

        If Percenatge = "" Then
            Percenatge = "0"
        End If
        If DiscountType = "--" Then
            Percenatge = "-" & Percenatge
            Discount = CDbl(Percenatge) / 100
        Else
            Percenatge = "+" & Percenatge
            Discount = CDbl(Percenatge) / 100
        End If
        Percenatge = "0"
        Return Discount
    End Function
    Public Function LoadDiscPrc(ByVal Number As String) As String
        Dim Disc As Double = 0
        Number = Math.Abs(CDbl(Number))
        Disc = CDbl(Number * 100)
        Return Disc
    End Function
    Public Sub LoadTest()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT ISNULL(IMH_CODE, '') IMH_CODE, ISNULL(IMH_DESC, '') IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK)"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim c As New AutoCompleteStringCollection()
        If dr.HasRows Then
            txtBPTestDesc.Clear()
            c.Clear()
            While dr.Read
                c.Add(dr("IMH_CODE"))
                c.Add(dr("IMH_DESC"))
            End While
        End If
        dr.Close()

        txtBPTestDesc.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtBPTestDesc.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtBPTestDesc.AutoCompleteCustomSource = c

    End Sub
    Public Sub AddPriceLevel(ByVal col As AutoCompleteStringCollection)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim str As String = ""

        str = "SELECT DISTINCT PRICE_LEVEL " & _
              "FROM (SELECT Price_Level1 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
              "      UNION ALL " & _
              "      SELECT Price_Level2 AS PRICE_LEVEL FROM Price_Level_Hdr " & _
              "      UNION ALL " & _
              "      SELECT Price_Level3 AS PRICE_LEVEL FROM Price_Level_Hdr) A "
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                col.Add(dr("PRICE_LEVEL"))
            End While
        End If
        dr.Close()
    End Sub
    Public Function ValidateAlphabet(ByVal StringToCheck As String) As Boolean
        Dim RetValue As Boolean = False
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
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", PriceType As String = ""
        Dim cmd As New SqlCommand

        If cbPriceType.Text = "NEW" Then
            PriceType = "N"
        Else
            PriceType = "O"
        End If

        str = "INSERT INTO Price_Level_Hdr VALUES ('" & Replace(txtBranchName.Text, "'", "''") & "','" & txtBranchCode.Text & "' " & _
            ",'" & Replace(txtCompany.Text, "'", "''") & "','" & Replace(txtP1.Text, "'", "''") & "','" & Replace(txtP2.Text, "'", "''") & "','" & Replace(txtP3.Text, "'", "''") & "', GETDATE(), '" & PriceType & "')"
        cmd = New SqlCommand(str, cn)
        cmd.ExecuteNonQuery()
        MessageBox.Show("Done Saving", "Price Update Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
    
        cn.Dispose()
        LoadHdr()
        btnClear.PerformClick()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtBranchCode.Clear()
        txtBranchName.Text = ""
        txtCompany.Text = ""
        txtP1.Text = ""
        txtP2.Text = ""
        txtP3.Text = ""
    End Sub

    Private Sub frmPriceList_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadHdr()
        LoadBranch()
        LoadPriceLevel()
        LoadDtl()
        LoadTest()
        dBP.Rows.Add()
    End Sub

    Private Sub txtBranchName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranchName.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSAP)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT CODE FROM SAPSET WITH(NOLOCK) WHERE BLK = '" & Replace(txtBranchName.Text, "'", "''") & "' "
            Dim cmd As New SqlCommand(str, cn)
            str = cmd.ExecuteScalar

            If str Is Nothing Then
                txtBranchCode.Text = ""
                txtBranchName.Text = ""
            Else
                txtBranchCode.Text = str
            End If
            cn.Dispose()
        End If
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        Dim intIndex As Integer = SearchGrid(txtFind.Text, 1) 'Change the 0 to what column you want to search for
        d1.Rows(intIndex).Selected = True 'This will select the row...'
        d1.CurrentCell = d1.Rows(intIndex).Cells(1) 'This ensures that the arrow will move if you have row headers visible. In order to select the cell change the zero to the column your searching to match up top
    End Sub

    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        If cbPriceLevel.Text = "" Or txtPriceList.Text = "" Or txtPriceListDesc.Text = "" Then Exit Sub

        If MessageBox.Show("Do you want to add Splist?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "", REG_1 As String = "", REG_2 As String = "", SP_1 As String = "", SP_2 As String = ""
        Dim UTZ_1 As String = "", UTZ_2 As String = "", IMG_1 As String = "", IMG_2 As String = "", cbStat As String = ""
        Dim cmd As New SqlCommand

        If cbSenior.Text = "" Or cbSenior.Text = "NO" Then
            cbStat = "0"
        Else
            cbStat = "1"
        End If

        REG_1 = LoadDisc(cbReg1.Text, chkReg1.Text) : REG_2 = LoadDisc(cbReg2.Text, chkReg2.Text)
        SP_1 = LoadDisc(cbSP1.Text, chkSP1.Text) : SP_2 = LoadDisc(cbSP2.Text, chkSP2.Text)
        IMG_1 = LoadDisc(cbIMG1.Text, chkIMG1.Text) : IMG_2 = LoadDisc(cbIMG2.Text, chkIMG2.Text)
        UTZ_1 = LoadDisc(cbUTZ1.Text, chkUTZ1.Text) : UTZ_2 = LoadDisc(cbUTZ2.Text, chkUTZ2.Text)


        str = "SELECT TOP 1 1 FROM Price_Level_Dtl WHERE PriceList ='" & Replace(txtPriceList.Text, "'", "''") & "' AND PriceLevel = '" & cbPriceLevel.Text & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Try
            cmd = New SqlCommand("BEGIN TRAN", cn)
            cmd.ExecuteNonQuery()
            If str Is Nothing Then
                str = "INSERT INTO Price_Level_Dtl VALUES ('" & cbPriceLevel.Text & "','" & txtPriceList.Text & "', " & _
                      "'" & txtPriceListDesc.Text & "','" & Format(CDbl(REG_1), "N4") & "','" & Format(CDbl(REG_2), "N4") & "','" & Format(CDbl(SP_1), "N4") & "', " & _
                      "'" & Format(CDbl(SP_2), "N4") & "','" & Format(CDbl(IMG_1), "N4") & "','" & Format(CDbl(IMG_2), "N4") & "', " & _
                      "'" & Format(CDbl(UTZ_1), "N4") & "','" & Format(CDbl(UTZ_2), "N4") & "','" & cbStat & "')"
            Else
                str = "UPDATE Price_Level_Dtl " & _
                      "SET REGULAR_1 = '" & Format(CDbl(REG_1), "N4") & "', REGULAR_2 = '" & Format(CDbl(REG_2), "N4") & "',  " & _
                      "SPECIAL_1 = '" & Format(CDbl(SP_1), "N4") & "', SPECIAL_2 = '" & Format(CDbl(SP_2), "N4") & "', " & _
                      "IMAGING_1 = '" & Format(CDbl(IMG_1), "N4") & "', IMAGING_2 = '" & Format(CDbl(IMG_2), "N4") & "', " & _
                      "UTZ_1 = '" & Format(CDbl(UTZ_1), "N4") & "', UTZ_2 = '" & Format(CDbl(UTZ_2), "N4") & "', IS_SENIOR = '" & cbStat & "' " & _
                      "WHERE PriceLevel = '" & cbPriceLevel.Text & "' AND PriceList= '" & txtPriceList.Text & "' "
            End If
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()

            cmd = New SqlCommand("COMMIT", cn)
            cmd.ExecuteNonQuery()
            btnClear.PerformClick()
            MessageBox.Show("Price List Saved", "Price Update Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
            cbReg1.Text = ""
            cbReg2.Text = ""
            cbSP1.Text = ""
            cbSP2.Text = ""
            cbIMG1.Text = "'"
            cbIMG2.Text = ""
            cbUTZ1.Text = ""
            cbUTZ2.Text = "'"
            LoadDtl()
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show(ex.Message, "Price Update Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        cmd.Dispose()
        cn.Dispose()
    End Sub

    Private Sub btnClear2_Click(sender As Object, e As EventArgs) Handles btnClear2.Click
        cbPriceLevel.Text = ""
        txtBranchCode.Text = ""
        txtBranchName.Text = ""
        txtPriceList.Text = ""
        'txtOldPriceList.Text = ""
        txtPriceListDesc.Text = ""
        cbReg1.SelectedIndex = -1
        chkReg1.Checked = False
        cbReg2.SelectedIndex = -1
        chkReg2.Checked = False
        cbSP1.SelectedIndex = -1
        chkSP1.Checked = False
        cbSP2.SelectedIndex = -1
        chkSP2.Checked = False
        cbIMG1.SelectedIndex = -1
        chkIMG1.Checked = False
        cbIMG2.SelectedIndex = -1
        chkIMG2.Checked = False
        cbUTZ1.SelectedIndex = -1
        chkUTZ1.Checked = False
        cbUTZ2.SelectedIndex = -1
        chkUTZ2.Checked = False
        cbPriceLevel.Enabled = True
        txtPriceList.Enabled = True
        'txtOldPriceList.Enabled = True
        txtPriceListDesc.Enabled = True
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'Dim intIndex As Integer = SearchGrid2(txtSearch.Text, 1)
        'd2.Rows(intIndex).Selected = True
        'd2.CurrentCell = d2.Rows(intIndex).Cells(1)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand
        If txtSearch.Text <> "" Then
            str = "SELECT PriceLevel, PriceList, PriceList_Desc " & _
                "FROM Price_Level_Dtl WITH(NOLOCK) " & _
                "WHERE PriceLevel LIKE '%" & txtSearch.Text & "%' OR PriceList LIKE '%" & txtSearch.Text & "%' " & _
                "ORDER BY PriceList"
            cmd = New SqlCommand(str, cn)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)

            cmd.Dispose()

            If dt.Rows.Count > 0 Then
                d2.Rows.Clear()
                For i As Integer = 0 To dt.Rows.Count - 1
                    d2.Rows.Add()
                    d2("PRICE_LEVEL", i).Value = dt.Rows(i).Item("PriceLevel").ToString()
                    d2("PRICE_LIST", i).Value = dt.Rows(i).Item("PriceList").ToString()
                    d2("PL_DESC", i).Value = dt.Rows(i).Item("PriceList_Desc").ToString()
                Next
            Else
                d2.Rows.Clear()
            End If
            'Dim dr As SqlDataReader = cmd.ExecuteReader

            'Dim i As Integer = 0
            'If dr.HasRows Then
            '    d2.Rows.Clear()
            '    While dr.Read
            '        d2.Rows.Add()
            '        d2("PRICE_LEVEL", i).Value = dr("PriceLevel")
            '        d2("PRICE_LIST", i).Value = dr("PriceList")
            '        d2("PL_DESC", i).Value = dr("PriceList_Desc")
            '        i += 1
            '    End While
            'Else
            '    d2.Rows.Clear()
            'End If
            'dr.Close()
            cn.Dispose()
        Else
            LoadDtl()
        End If



    End Sub

    Private Sub txtBranchName_TextChanged(sender As Object, e As EventArgs) Handles txtBranchName.TextChanged

    End Sub

    Private Sub chkReg1_CheckedChanged(sender As Object, e As EventArgs) Handles chkReg1.CheckedChanged
        If chkReg1.Checked = True Then
            chkReg1.Text = "+"
        Else
            chkReg1.Text = "--"
        End If
    End Sub

    Private Sub chkReg2_CheckedChanged(sender As Object, e As EventArgs) Handles chkReg2.CheckedChanged
        If chkReg2.Checked = True Then
            chkReg2.Text = "+"
        Else
            chkReg2.Text = "--"
        End If
    End Sub

    Private Sub chkIMG1_CheckedChanged(sender As Object, e As EventArgs) Handles chkIMG1.CheckedChanged
        If chkIMG1.Checked = True Then
            chkIMG1.Text = "+"
        Else
            chkIMG1.Text = "--"
        End If
    End Sub

    Private Sub chkIMG2_CheckedChanged(sender As Object, e As EventArgs) Handles chkIMG2.CheckedChanged
        If chkIMG2.Checked = True Then
            chkIMG2.Text = "+"
        Else
            chkIMG2.Text = "--"
        End If
    End Sub

    Private Sub chkSP1_CheckedChanged(sender As Object, e As EventArgs) Handles chkSP1.CheckedChanged
        If chkSP1.Checked = True Then
            chkSP1.Text = "+"
        Else
            chkSP1.Text = "--"
        End If

    End Sub

    Private Sub chkSP2_CheckedChanged(sender As Object, e As EventArgs) Handles chkSP2.CheckedChanged
        If chkSP2.Checked = True Then
            chkSP2.Text = "+"
        Else
            chkSP2.Text = "--"
        End If
    End Sub

    Private Sub chkUTZ1_CheckedChanged(sender As Object, e As EventArgs) Handles chkUTZ1.CheckedChanged
        If chkUTZ1.Checked = True Then
            chkUTZ1.Text = "+"
        Else
            chkUTZ1.Text = "--"
        End If
    End Sub

    Private Sub chkUTZ2_CheckedChanged(sender As Object, e As EventArgs) Handles chkUTZ2.CheckedChanged
        If chkUTZ2.Checked = True Then
            chkUTZ2.Text = "+"
        Else
            chkUTZ2.Text = "--"
        End If
    End Sub

    Private Sub d2_ColumnDataPropertyNameChanged(sender As Object, e As DataGridViewColumnEventArgs) Handles d2.ColumnDataPropertyNameChanged

    End Sub
    Private Sub d2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d2.MouseDoubleClick
        If d2.Rows.Count = 0 Then Exit Sub
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        
        str = "SELECT DISTINCT B.* FROM Price_Level_Hdr A WITH(NOLOCK) " & _
            "INNER JOIN Price_Level_Dtl B WITH(NOLOCK) ON A.Price_Level1 = B.PriceLevel OR A.Price_Level2 = B.PriceLevel OR A.Price_Level3 = B.PriceLevel " & _
            "WHERE B.PriceList = '" & d2("PRICE_LIST", d2.CurrentRow.Index).Value & "' "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                cbPriceLevel.Text = dr("PriceLevel")
                txtPriceList.Text = dr("PriceList")
                'txtOldPriceList.Text = dr("Old_PriceList")
                txtPriceListDesc.Text = dr("PriceList_Desc")
                cbPriceLevel.Enabled = False
                txtPriceList.Enabled = False
                'txtOldPriceList.Enabled = False
                txtPriceListDesc.Enabled = False

                cbReg1.Text = LoadDiscPrc(dr("Regular_1"))
                If Replace(dr("Regular_1"), "-", "") > 0 Then
                    If InStr(dr("Regular_1"), "-") > 0 Then
                        chkReg1.Checked = False
                    Else
                        chkReg1.Checked = True
                    End If
                Else
                    chkReg1.Text = "--"
                    chkReg1.Checked = False
                End If

                If Replace(dr("Regular_2"), "-", "") > 0 Then
                    cbReg2.Text = LoadDiscPrc(dr("Regular_2"))
                    If InStr(dr("Regular_2"), "-") > 0 Then
                        chkReg2.Checked = False
                    Else
                        chkReg2.Checked = True
                    End If
                Else
                    chkReg2.Text = "--"
                    chkReg2.Checked = False
                End If

                If Replace(dr("Special_1"), "-", "") > 0 Then
                    cbSP1.Text = LoadDiscPrc(dr("Special_1"))
                    If InStr(dr("Special_1"), "-") > 0 Then
                        chkSP1.Checked = False
                    Else
                        chkSP1.Checked = True
                    End If
                Else
                    chkSP1.Text = "--"
                    chkSP1.Checked = False
                End If

                If Replace(dr("Special_2"), "-", "") > 0 Then
                    cbSP2.Text = LoadDiscPrc(dr("Special_2"))
                    If InStr(dr("Special_2"), "-") > 0 Then
                        chkSP2.Checked = False
                    Else
                        chkSP2.Checked = True
                    End If
                Else
                    chkSP2.Text = "--"
                    chkSP2.Checked = False
                End If

                If Replace(dr("Imaging_1"), "-", "") > 0 Then
                    cbIMG1.Text = LoadDiscPrc(dr("Imaging_1"))
                    If InStr(dr("Imaging_1"), "-") > 0 Then
                        chkIMG1.Checked = False
                    Else
                        chkIMG1.Checked = True
                    End If
                Else
                    chkIMG1.Text = "--"
                    chkIMG1.Checked = False
                End If

                If Replace(dr("Imaging_2"), "-", "") > 0 Then
                    cbIMG2.Text = LoadDiscPrc(dr("Imaging_2"))
                    If InStr(dr("Imaging_2"), "-") > 0 Then
                        chkIMG2.Checked = False
                    Else
                        chkIMG2.Checked = True
                    End If
                Else
                    chkIMG2.Text = "--"
                    chkIMG2.Checked = False
                End If

                If Replace(dr("UTZ_1"), "-", "") > 0 Then
                    cbUTZ1.Text = LoadDiscPrc(dr("UTZ_1"))
                    If InStr(dr("UTZ_1"), "-") > 0 Then
                        chkUTZ1.Checked = False
                    Else
                        chkUTZ1.Checked = True
                    End If
                Else
                    chkUTZ1.Text = "--"
                    chkUTZ1.Checked = False
                End If

                If Replace(dr("UTZ_2"), "-", "") > 0 Then
                    cbUTZ2.Text = LoadDiscPrc(dr("UTZ_2"))
                    If InStr(dr("UTZ_2"), "-") > 0 Then
                        chkUTZ2.Checked = False
                    Else
                        chkUTZ2.Checked = True
                    End If
                Else
                    chkUTZ2.Text = "--"
                    chkUTZ2.Checked = False
                End If
            End While
        End If
        dr.Close()
        cn.Dispose()
    End Sub

    Private Sub d2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles d2.CellContentClick

    End Sub

    Private Sub btnPLSave_Click(sender As Object, e As EventArgs) Handles btnPLSave.Click
        If txtBPTestCode.Text = "" Or dBP.Rows.Count = 0 Then MessageBox.Show("Please complete details before saving", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        If MessageBox.Show("Do you want to Save Basic Price Level for " & txtBPTestDesc.Text & "?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand
        Try
            cmd = New SqlCommand("BEGIN TRAN", cn)
            cmd.ExecuteNonQuery()

            For i As Integer = 0 To dBP.Rows.Count - 1
                If dBP("BLPRICE_LEVEL", i).Value = Nothing Then GoTo ReadNext

                str = "SELECT TOP 1 1 FROM BASIC_PRICE_LVL WITH(NOLOCK) WHERE IMH_CODE = '" & txtBPTestCode.Text & "' AND PRICE_LEVEL = '" & dBP("BLPRICE_LEVEL", i).Value & "' "
                cmd = New SqlCommand(str, cn)
                str = cmd.ExecuteScalar

                If str Is Nothing Then
                    str = "INSERT INTO BASIC_PRICE_LVL VALUES ('" & txtBPTestCode.Text & "','" & Replace(txtBPTestDesc.Text, "'", "''") & "','" & dBP("BLPRICE_LEVEL", i).Value & "','" & dBP("BASIC_PRICE", i).Value & "')"
                Else
                    str = "UPDATE BASIC_PRICE_LVL " & _
                        "SET PRICE = '" & dBP("BASIC_PRICE", i).Value & "' " & _
                        "WHERE IMH_CODE = '" & txtBPTestCode.Text & "' AND PRICE_LEVEL = '" & dBP("BLPRICE_LEVEL", i).Value & "' "
                End If
                cmd = New SqlCommand(str, cn)
                cmd.ExecuteNonQuery()
ReadNext:
            Next
            cmd = New SqlCommand("COMMIT", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Save successful", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnClear3.PerformClick()
            dBP.Rows.Add()
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
    Private Sub dBP_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dBP.CellEndEdit
        If dBP.CurrentCell.ColumnIndex = 1 Then
            Dim CurrIndex As Integer = dBP.CurrentRow.Index
            For i As Integer = 0 To dBP.RowCount - 1
                If CurrIndex <> i Then
                    If dBP("BLPRICE_LEVEL", dBP.CurrentRow.Index).Value = dBP("BLPRICE_LEVEL", i).Value Then
                        MessageBox.Show("Price Level Already exists", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        dBP("BLPRICE_LEVEL", dBP.CurrentRow.Index).Value = Nothing
                        dBP("BASIC_PRICE", dBP.CurrentRow.Index).Value = Nothing
                        Exit Sub
                    End If
                End If
            Next
            If dBP.CurrentCell.ColumnIndex = 1 Then
                If dBP("BASIC_PRICE", dBP.CurrentRow.Index).Value <> Nothing Then
                    If ValidateAlphabet(dBP("BASIC_PRICE", dBP.CurrentRow.Index).Value) = True Then
                        dBP("BASIC_PRICE", dBP.CurrentRow.Index).Value = Nothing
                    End If
                End If
            End If
            If dBP("BASIC_PRICE", dBP.CurrentRow.Index).Value <> Nothing Then
                dBP.Rows.Add()
            End If
        End If
    End Sub
    Private Sub dBP_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dBP.EditingControlShowing
        If dBP.Columns(dBP.CurrentCell.ColumnIndex).HeaderText = "PRICE LEVEL" Then
            If dBP.CurrentCell.ColumnIndex = 0 Then
                Dim autoText As TextBox = TryCast(e.Control, TextBox)
                If autoText IsNot Nothing Then
                    autoText.AutoCompleteMode = AutoCompleteMode.Suggest
                    autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
                    Dim DataCollection As New AutoCompleteStringCollection()
                    AddPriceLevel(DataCollection)
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

    Private Sub dBP_KeyDown(sender As Object, e As KeyEventArgs) Handles dBP.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()


            Dim str As String = "SELECT DISTINCT PRICE_LEVEL " & _
              "FROM (SELECT Price_Level1 AS PRICE_LEVEL FROM Price_Level_Hdr WITH(NOLOCK) " & _
              "      UNION ALL " & _
              "      SELECT Price_Level2 AS PRICE_LEVEL FROM Price_Level_Hdr WITH(NOLOCK) " & _
              "      UNION ALL " & _
              "      SELECT Price_Level3 AS PRICE_LEVEL FROM Price_Level_Hdr WITH(NOLOCK)) A WHERE PRICE_LEVEL = '" & dBP("BLPRICE_LEVEL", dBP.CurrentRow.Index).Value & "' "
            Dim cmd As New SqlCommand(str, cn)
            str = cmd.ExecuteScalar

            If str Is Nothing Then
                MessageBox.Show("Price Level not found", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                dBP("BLPRICE_LEVEL", dBP.CurrentRow.Index).Value = str
            End If
            cn.Dispose()
            cmd.Dispose()
        ElseIf e.KeyCode = Keys.Delete Then
            If MessageBox.Show("Do you want to remove this row?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
            dBP.Rows.RemoveAt(dBP.CurrentRow.Index)
            If dBP.Rows.Count = 0 Then
                dBP.Rows.Add()
            End If
        End If
    End Sub
    Private Sub txtBPTestDesc_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBPTestDesc.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT ISNULL(IMH_CODE, '') IMH_CODE , ISNULL(IMH_DESC, '') IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK) WHERE IMH_CODE = '" & Replace(txtBPTestDesc.Text, "'", "''") & "' " & _
                                "OR IMH_DESC= '" & Replace(txtBPTestDesc.Text, "'", "''") & "' AND IMH_REC_FLAG= 'N' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    txtBPTestCode.Text = dr("IMH_CODE")
                    txtBPTestDesc.Text = dr("IMH_DESC")
                End While
            Else
                txtBPTestDesc.Text = ""
                txtBPTestCode.Text = ""
            End If
            dr.Close()

        End If
    End Sub

    Private Sub txtBPTestDesc_TextChanged(sender As Object, e As EventArgs) Handles txtBPTestDesc.TextChanged
        If txtBPTestDesc.Text = "" Then
            txtBPTestCode.Text = ""
        End If
    End Sub

    Private Sub dBP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dBP.CellContentClick

    End Sub

    Private Sub dBP_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dBP.CellValidating

    End Sub

    Private Sub btnClear3_Click(sender As Object, e As EventArgs) Handles btnClear3.Click
        dBP.Rows.Clear()
        txtBPTestCode.Text = ""
        txtBPTestDesc.Text = ""
    End Sub
End Class