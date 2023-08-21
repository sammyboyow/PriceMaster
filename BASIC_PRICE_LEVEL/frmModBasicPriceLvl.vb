Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmModBasicPriceLvl
    Dim dtTestDesc As DataTable = Nothing
    Dim dtTestCode As DataTable = Nothing
    Dim vFileName As String = Nothing
    Private Sub frmModBasicPriceLvl_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmModBasicPriceLvl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTestDesc()
        LoadTestCode()
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
                "WHERE IMH_TYPE = 'S' AND S.SlsStat = 'O' AND S.STAT = 'O' AND C.IMH_BILLCODE NOT IN ('5000','5010') " & _
                "GROUP BY C.IMH_CODE,C.IMH_DESC " & _
                "ORDER BY 2 "
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
                "WHERE IMH_TYPE = 'S' AND S.SlsStat = 'O' AND S.STAT = 'O' AND C.IMH_BILLCODE NOT IN ('5000','5010') " & _
                "GROUP BY C.IMH_CODE,C.IMH_DESC " & _
                "ORDER BY 1 "
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



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim i As Integer = D.Rows.Count
        str =
            "SELECT C.IMH_CODE,C.IMH_DESC,MAX(C.MODIFIED_ON)MODIFIED_ON,C.IMH_BILLCODE, " & _
            "		CASE WHEN C.IMH_BILLCODE = '1030' THEN 'ULTRASOUND' " & _
            "		WHEN (C.IMH_BILLCODE BETWEEN '1000' AND '1020') OR C.IMH_BILLCODE = '9000' OR C.IMH_BILLCODE = '1120' OR (C.IMH_BILLCODE BETWEEN '1040' AND '1100') THEN 'IMAGING' " & _
            "		WHEN C.IMH_BILLCODE = '4500' THEN 'SPECIAL TESTS' " & _
            "		ELSE 'REGULAR TESTS' END IMH_BILLCODEDESC " & _
            "FROM dbo.CONSOLIDATED_IMH C WITH(NOLOCK) " & _
            "INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSet S WITH (NOLOCK) ON S.CODE = C.BRANCH_CODE COLLATE DATABASE_DEFAULT " & _
            "WHERE S.STAT = 'O' AND S.SlsStat = 'O' AND IMH_TYPE = 'S' AND C.IMH_CODE = '" & cboTCode.Text & "' " & _
            "GROUP BY C.IMH_CODE,C.IMH_DESC,C.IMH_BILLCODE,  " & _
            "		CASE WHEN C.IMH_BILLCODE = '1030' THEN 'ULTRASOUND' " & _
            "		WHEN (C.IMH_BILLCODE BETWEEN '1000' AND '1020') OR C.IMH_BILLCODE = '9000' OR C.IMH_BILLCODE = '1120' OR (C.IMH_BILLCODE BETWEEN '1040' AND '1100') THEN 'IMAGING' " & _
            "		WHEN C.IMH_BILLCODE = '4500' THEN 'SPECIAL TESTS' " & _
            "		ELSE 'REGULAR TESTS' END "
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                D.Rows.Add()
                D("TestCode", i).Value = dr("IMH_CODE")
                D("TestName", i).Value = dr("IMH_DESC")
                D("ModifiedOn", i).Value = dr("MODIFIED_ON")
                D("BillCode", i).Value = dr("IMH_BILLCODE")
                D("BillDesc", i).Value = dr("IMH_BILLCODEDESC")
                i += 1
            End While
        End If

        dr.Close()
        cmd.Dispose()
        cn.Dispose()
        RecCount()
    End Sub


    Private Sub D_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles D.MouseDoubleClick
        SelTest()
    End Sub


    Private Sub ChkAll_CheckedChanged_1(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged

        If D.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To D.Rows.Count - 1
            D("Chk", i).Value = ChkAll.Checked
        Next

    End Sub

    Private Sub ChkAll1_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll1.CheckedChanged
        If D1.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To D1.Rows.Count - 1
            D1("Chk1", i).Value = ChkAll1.Checked
        Next
    End Sub
    Private Sub SelTest()

        If D.Rows.Count = 0 Then Exit Sub
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand()
        Dim dr As SqlDataReader
        Dim i As Integer = 0
        D1.Rows.Clear()
        str =
            "SELECT B.DOCENTRY,B.IMH_CODE,B.IMH_DESC,B.PRICE_LEVEL,B.PRICE,B.MODIFIEDON,B.MODIFIEDBY,B.ADDON,B.ADDBY " & _
            "FROM dbo.BSC_PRICELVL_PROFILE_DTL B " & _
            "LEFT JOIN dbo.PRICE_LEVEL_ORDER L ON L.PRICELEVEL = B.PRICE_LEVEL " & _
            "WHERE IMH_CODE = '" & D("TestCode", D.CurrentRow.Index).Value & "' AND DOCENTRY = '" & lblDocEntry.Text & "' " & _
            "ORDER BY L.ORDR  "
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            While dr.Read
                D1.Rows.Add()
                D1("DOCENTRY", i).Value = dr("DOCENTRY")
                D1("TestCode1", i).Value = dr("IMH_CODE")
                D1("TestName1", i).Value = dr("IMH_DESC")
                D1("PriceLevel", i).Value = dr("PRICE_LEVEL")
                D1("Price", i).Value = dr("PRICE")
                D1("MODIFIED_ON", i).Value = dr("MODIFIEDON")
                D1("MODIFIED_BY", i).Value = dr("MODIFIEDBY")
                D1("ADDON", i).Value = dr("ADDON")
                D1("ADDBY", i).Value = dr("ADDBY")

                i += 1
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
        'If D.Rows.Count = 0 Then Exit Sub
        'Dim cn As New SqlConnection(cnSQL)
        'If cn.State = ConnectionState.Closed Then cn.Open()
        'Dim str As String = ""
        'Dim cmd As New SqlCommand()
        'Dim dr As SqlDataReader
        'Dim i As Integer = 0
        'D1.Rows.Clear()
        'str =
        '    "SELECT C.IMH_CODE,C.IMH_DESC,B.PRICE_LEVEL,B.PRICE,B.MODIFIEDON,B.MODIFIEDBY,B.ADDON,B.ADDBY,L.ORDR " & _
        '    "FROM dbo.CONSOLIDATED_IMH C WITH(NOLOCK) " & _
        '    "INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSet S WITH (NOLOCK) ON S.CODE = C.BRANCH_CODE COLLATE DATABASE_DEFAULT " & _
        '    "LEFT JOIN dbo.BSC_PRICELVL_MASTERLIST B ON B.IMH_CODE = C.IMH_CODE " & _
        '    "LEFT JOIN dbo.PRICE_LEVEL_ORDER L ON L.PRICELEVEL = B.PRICE_LEVEL " & _
        '    "WHERE IMH_TYPE = 'S' AND S.STAT = 'O' AND S.SlsStat = 'O' AND C.IMH_CODE = '" & D("TestCode", D.CurrentRow.Index).Value & "' " & _
        '    "GROUP BY C.IMH_CODE,C.IMH_DESC,B.PRICE_LEVEL,B.PRICE,B.MODIFIEDON,B.MODIFIEDBY,B.ADDON,B.ADDBY,L.ORDR " & _
        '    "ORDER BY L.ORDR "
        'cmd = New SqlCommand(str, cn)
        'dr = cmd.ExecuteReader
        'If dr.HasRows Then
        '    While dr.Read
        '        D1.Rows.Add()
        '        D1("TestCode1", i).Value = dr("IMH_CODE")
        '        D1("TestName1", i).Value = dr("IMH_DESC")
        '        D1("PriceLevel", i).Value = dr("PRICE_LEVEL")
        '        D1("Price", i).Value = dr("PRICE")
        '        D1("MODIFIED_ON", i).Value = dr("MODIFIEDON")
        '        D1("MODIFIED_BY", i).Value = dr("MODIFIEDBY")
        '        D1("ADDON", i).Value = dr("ADDON")
        '        D1("ADDBY", i).Value = dr("ADDBY")

        '        i += 1
        '    End While
        'End If
        'dr.Close()
        'cmd.Dispose()
        'cn.Dispose()
    End Sub
    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        SelTest()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If D.Rows.Count > 0 Then
            If MsgBox("Are you sure to Clear all fields?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                ClearFields()
            End If
        End If

    End Sub

    Private Sub ClearFields()
        cboTCode.Text = ""
        cboTDesc.Text = ""
        D.Rows.Clear()
        D1.Rows.Clear()
        ChkAll.Checked = False
        ChkAll1.Checked = False
        cboSheet.Items.Clear()
        lblXlFname.Text = "No Excel"

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim chkd As Integer = 0
        Dim noval As Integer = 0
        Dim noplvl As Integer = 0
        For x As Integer = 0 To D1.Rows.Count - 1
            If D1("Chk1", x).Value = True Then
                If D1("Price", x).Value = "0" Or D1("Price", x).Value = "" Or D1("Price", x).Value Is Nothing Or D1("Price", x).Value = "0.00" Then
                    noval += 1
                End If
                If D1("Pricelevel", x).Value = "" Or D1("Pricelevel", x).Value Is Nothing Then
                    noplvl += 1
                End If
                chkd += 1
            End If
        Next
        If chkd = 0 Then
            MsgBox("No selected price level to save!")
            Exit Sub
        End If
        If chkd = 0 Then
            MsgBox("No tagged price level to save!")
            Exit Sub
        End If
        If noval <> 0 Then
            If MsgBox("There is 0 or blank price in the list, do you still want to proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Try
            str = "BEGIN TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To D1.Rows.Count - 1
                If D1("Chk1", i).Value = True Then
                    str = "SELECT TOP 1 1 " & _
                        "FROM BSC_PRICELVL_PROFILE_DTL " & _
                        "WHERE IMH_CODE = '" & D1("TestCode1", i).Value & "' AND PRICE_LEVEL = '" & D1("Pricelevel", i).Value & "' AND DOCENTRY = '" & lblDocEntry.Text & "' "
                    cmd = New SqlCommand(str, cn)
                    str = cmd.ExecuteScalar()
                    If str = "1" Then
                        str =
                            "UPDATE BSC_PRICELVL_PROFILE_DTL " & _
                            "SET PRICE = '" & D1("Price", i).Value & "', MODIFIEDON = GETDATE(), MODIFIEDBY = '" & Info.EmpID & "' " & _
                            "WHERE IMH_CODE = '" & D1("TestCode1", i).Value & "' AND PRICE_LEVEL = '" & D1("Pricelevel", i).Value & "' " & _
                            "AND DOCENTRY = '" & lblDocEntry.Text & "' "
                    Else
                        str =
                            "INSERT INTO BSC_PRICELVL_PROFILE_DTL (IMH_CODE,IMH_DESC,PRICE_LEVEL,PRICE,ADDON,ADDBY) " & _
                            "VALUES('" & D1("TestCode1", i).Value & "','" & D1("TestName1", i).Value & "', " & _
                            "'" & D1("PriceLevel", i).Value & "','" & D1("Price", i).Value & "',GETDATE(),'" & Info.EmpID & "' ) "
                    End If
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
        Catch ex As Exception
            str = "IF @@TRANCOUNT > 0 ROLLBACK TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()
            MsgBox("ERROR UPON SAVING. ERROR DETAILS : " & ex.Message & "")
        End Try
        str = "COMMIT TRAN"
        cmd = New SqlCommand(str, cn)
        cmd.ExecuteNonQuery()
        MsgBox("Saved.", MsgBoxStyle.Information)
        cmd.Dispose()
        cn.Dispose()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub cboTDesc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTDesc.SelectedIndexChanged

    End Sub

    Private Sub cboTCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTCode.SelectedIndexChanged

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim i As Integer = 0
        str =
            "SELECT C.IMH_CODE, MAX(C.IMH_DESC) IMH_DESC, MAX(C.MODIFIED_ON) MODIFIED_ON, C.IMH_BILLCODE, " & _
            "	   CASE WHEN C.IMH_BILLCODE = '1030' THEN 'ULTRASOUND' " & _
            "			WHEN (C.IMH_BILLCODE BETWEEN '1000' AND '1020') OR C.IMH_BILLCODE = '9000' OR C.IMH_BILLCODE = '1120' OR (C.IMH_BILLCODE BETWEEN '1040' AND '1100') THEN 'IMAGING' " & _
            "			WHEN C.IMH_BILLCODE = '4500' THEN 'SPECIAL TESTS' " & _
            "			ELSE 'REGULAR TESTS' " & _
            "	   END IMH_BILLCODEDESC " & _
            "FROM dbo.BSC_PRICELVL_PROFILE_DTL D  WITH (NOLOCK) " & _
            "INNER JOIN dbo.CONSOLIDATED_IMH C ON D.IMH_CODE = C.IMH_CODE " & _
            "INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSet S WITH (NOLOCK) ON S.CODE = C.BRANCH_CODE COLLATE DATABASE_DEFAULT " & _
            "WHERE S.STAT = 'O' AND S.SlsStat = 'O' AND IMH_TYPE = 'S' AND D.DOCENTRY = '" & lblDocEntry.Text & "' " & _
            "GROUP BY C.IMH_CODE, C.IMH_BILLCODE, CASE WHEN C.IMH_BILLCODE = '1030' THEN 'ULTRASOUND' WHEN (C.IMH_BILLCODE BETWEEN '1000' AND '1020') OR C.IMH_BILLCODE = '9000' OR C.IMH_BILLCODE = '1120' OR (C.IMH_BILLCODE BETWEEN '1040' AND '1100') THEN 'IMAGING' WHEN C.IMH_BILLCODE = '4500' THEN 'SPECIAL TESTS' ELSE 'REGULAR TESTS' END " & _
            "ORDER BY 1 "
        '"SELECT C.IMH_CODE,C.IMH_DESC,MAX(C.MODIFIED_ON)MODIFIED_ON,C.IMH_BILLCODE, " & _
        '"		CASE WHEN C.IMH_BILLCODE = '1030' THEN 'ULTRASOUND' " & _
        '"		WHEN (C.IMH_BILLCODE BETWEEN '1000' AND '1020') OR C.IMH_BILLCODE = '9000' OR C.IMH_BILLCODE = '1120' OR (C.IMH_BILLCODE BETWEEN '1040' AND '1100') THEN 'IMAGING' " & _
        '"		WHEN C.IMH_BILLCODE = '4500' THEN 'SPECIAL TESTS' " & _
        '"		ELSE 'REGULAR TESTS' END IMH_BILLCODEDESC " & _
        '"FROM dbo.CONSOLIDATED_IMH C WITH(NOLOCK) " & _
        '"INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSet S WITH (NOLOCK) ON S.CODE = C.BRANCH_CODE COLLATE DATABASE_DEFAULT " & _
        '"WHERE S.STAT = 'O' AND S.SlsStat = 'O' AND IMH_TYPE = 'S' " & _
        '"GROUP BY C.IMH_CODE,C.IMH_DESC,C.IMH_BILLCODE, " & _
        '"		CASE WHEN C.IMH_BILLCODE = '1030' THEN 'ULTRASOUND' " & _
        '"		WHEN (C.IMH_BILLCODE BETWEEN '1000' AND '1020') OR C.IMH_BILLCODE = '9000' OR C.IMH_BILLCODE = '1120' OR (C.IMH_BILLCODE BETWEEN '1040' AND '1100') THEN 'IMAGING' " & _
        '"		WHEN C.IMH_BILLCODE = '4500' THEN 'SPECIAL TESTS' " & _
        '"		ELSE 'REGULAR TESTS' END "
        cmd = New SqlCommand(str, cn)
        dr = cmd.ExecuteReader
        D.Rows.Clear()

        If dr.HasRows Then
            While dr.Read
                D.Rows.Add()
                D("TestCode", i).Value = dr("IMH_CODE")
                D("TestName", i).Value = dr("IMH_DESC")
                D("ModifiedOn", i).Value = dr("MODIFIED_ON")
                D("BillCode", i).Value = dr("IMH_BILLCODE")
                D("BillDesc", i).Value = dr("IMH_BILLCODEDESC")
                i += 1
            End While
        End If

        dr.Close()
        cmd.Dispose()
        cn.Dispose()
        RecCount()
    End Sub
    Sub RecCount()
        If D.Rows.Count = 0 Then lblRecCnt.Text = "0" : Exit Sub
        lblRecCnt.Text = D.Rows.Count

    End Sub
    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btn.Click

        With frmSelBscPrcLvl
            .Show()
            .lblDocEntry.Text = lblDocEntry.Text
            .tmpmodbscpricedg = D
        End With

        'MsgBox("Function under maintenance!")
        'Dim tcode As String = ""
        'Dim cn As New SqlConnection(cnSQL)
        'If cn.State = ConnectionState.Closed Then cn.Open()
        'Dim str As String = ""
        'Dim cmd As New SqlCommand
        'Dim dr As SqlDataReader
        'For i As Integer = 0 To D.Rows.Count - 1
        '    If D("Chk", i).Value = True Then
        '        If tcode = "" Then
        '            tcode = D("TestCode", i).Value
        '        Else
        '            tcode += ",'" & D("TestCode", i).Value & "'"

        '        End If
        '    End If
        'Next

        'str = ""
        'cmd = New SqlCommand(str, cn)

        'cmd.Dispose()
        'cn.Dispose()

    End Sub

    Private Sub btnRLine_Click(sender As Object, e As EventArgs) Handles btnRLine.Click
        If D1.Rows.Count = 0 Then MsgBox("NO items to remove.", MsgBoxStyle.Information) : Exit Sub
        Dim Chk As Boolean = False
        For i As Integer = 0 To D1.Rows.Count - 1
            If D1("Chk1", i).Value = True Then Chk = True : Exit For
        Next
        If Chk = False Then MsgBox("No selected item!", MsgBoxStyle.Information) : Exit Sub
        For x As Integer = D1.Rows.Count - 1 To 0 Step -1
            If D1.Rows(x).Cells("Chk1").Value Then
                D1.Rows.Remove(D1.Rows(x))
            End If
        Next
        MsgBox("Line Removed.")
    End Sub
    Private Sub btnALine_Click(sender As Object, e As EventArgs) Handles btnALine.Click
        If D.Rows.Count = 0 Then MsgBox("No Test Selected") : Exit Sub
        For x As Integer = 0 To D1.Rows.Count - 1
            If Not D1("TestCode1", x).Value = "" Or Not D1("TestCode1", x).Value Is Nothing Then
                D1.Rows.Add(New String() {False, D1("TestCode1", x).Value, D1("TestName1", x).Value})
                Exit Sub
            End If
        Next
        Dim i As Integer = D.CurrentRow.Index
        D1.Rows.Add(New String() {False, D("TestCode", i).Value, D("TestName", i).Value})
    End Sub
    Private Sub D1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles D1.CellContentClick
    End Sub
    Private Sub D1_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles D1.CellEndEdit
        Dim cnt As Integer = 0
        For i As Integer = 0 To D1.Rows.Count - 1
            If Not IsDBNull(D1("Pricelevel", D1.CurrentRow.Index).Value) Then
                If D1("Pricelevel", D1.CurrentRow.Index).Value <> "" Then
                    Dim eeee As String = D1("Pricelevel", i).Value.ToString.ToUpper
                    Dim eeeeee As String = D1("Pricelevel", D1.CurrentRow.Index).Value.ToString.ToUpper
                    If D1("Pricelevel", i).Value.ToString.ToUpper = D1("Pricelevel", D1.CurrentRow.Index).Value.ToString.ToUpper Then
                        cnt += 1
                    End If
                End If
            End If
        Next
        If cnt >= 2 Then
            MsgBox("Price level already encoded", MsgBoxStyle.Exclamation)
            D1("Pricelevel", D1.CurrentRow.Index).Value = ""
        End If
    End Sub

    Private Sub btnCopPrice_Click(sender As Object, e As EventArgs) Handles btnCopPrice.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand()
        Dim i As Integer = D.CurrentRow.Index
        str = "SELECT TOP 1 1 FROM BSC_PRICELVL_PROFILE_DTL WHERE IMH_CODE = '" & D("TestCode", i).Value & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar()

        If str = "1" Then
            If MsgBox("Do you want to replace existing Price of """ & D("TestCode", i).Value & """ in Price level Profile?", MsgBoxStyle.YesNo, MsgBoxStyle.Critical) = MsgBoxResult.Yes Then
                str = "SELECT TOP 1 1 FROM BSC_PRICELVL_MASTERLIST WHERE IMH_CODE = '" & D("TestCode", i).Value & "' "
                cmd = New SqlCommand(str, cn)
                str = cmd.ExecuteScalar()
                If str = "1" Then

                    str = "BEGIN TRAN"
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()

                    Try

                        str = "DELETE BSC_PRICELVL_PROFILE_DTL WHERE IMH_CODE = '" & D("TestCode", i).Value & "'"
                        cmd = New SqlCommand(str, cn)
                        cmd.ExecuteNonQuery()

                        str =
                            "INSERT INTO dbo.BSC_PRICELVL_PROFILE_DTL (DOCENTRY,IMH_CODE,IMH_DESC,PRICE_LEVEL,PRICE,MODIFIEDON,MODIFIEDBY,ADDON,ADDBY) " & _
                            "SELECT '" & lblDocEntry.Text & "'DocEntry,IMH_CODE,IMH_DESC,PRICE_LEVEL,PRICE,GETDATE()  MODIFIEDON, " & _
                            "'" & Info.EmpID & "'MODIFIEDBY,GETDATE() ADDON,'" & Info.EmpID & "' ADDBY FROM dbo.BSC_PRICELVL_MASTERLIST WHERE IMH_CODE = '" & D("TestCode", i).Value & "' "
                        cmd = New SqlCommand(str, cn)
                        cmd.ExecuteNonQuery()

                        str = "COMMIT TRAN"
                        cmd = New SqlCommand(str, cn)
                        cmd.ExecuteNonQuery()

                    Catch ex As Exception
                        str = "IF @@TRANCOUNT > 1 ROLLBACK TRAN"
                        cmd = New SqlCommand(str, cn)
                        cmd.ExecuteNonQuery()
                        cmd.Dispose()
                        cn.Dispose()
                        MsgBox(ex.Message)
                        Exit Sub
                    End Try


                End If
            End If

        Else
            str =
                "INSERT INTO dbo.BSC_PRICELVL_PROFILE_DTL (DOCENTRY,IMH_CODE,IMH_DESC,PRICE_LEVEL,PRICE,MODIFIEDON,MODIFIEDBY,ADDON,ADDBY) " & _
                "SELECT '" & lblDocEntry.Text & "'DocEntry,IMH_CODE,IMH_DESC,PRICE_LEVEL,PRICE,GETDATE()  MODIFIEDON, " & _
                "'" & Info.EmpID & "'MODIFIEDBY,GETDATE() ADDON,'" & Info.EmpID & "' ADDBY FROM dbo.BSC_PRICELVL_MASTERLIST WHERE IMH_CODE = '" & D("TestCode", i).Value & "'"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()
        End If

        cmd.Dispose()
        cn.Dispose()
        MsgBox("Done", MsgBoxStyle.Information)
    End Sub
    Private Sub Importexcel()
        Dim dt As New DataTable

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand

        Dim xlApp As New Excel.Application
        Dim xlWB As Excel.Workbook = xlApp.Workbooks.Open(vFileName)
        Dim xlWS As Excel.Worksheet = xlWB.Sheets(cboSheet.Text)

        Dim i As Integer = 0
        dt.Columns.Add(New DataColumn("DOCENTRY", GetType(String)))
        dt.Columns.Add(New DataColumn("IMH_CODE", GetType(String)))
        dt.Columns.Add(New DataColumn("IMH_DESC", GetType(String)))
        dt.Columns.Add(New DataColumn("PRICE_LEVEL", GetType(String)))
        dt.Columns.Add(New DataColumn("PRICE", GetType(String)))
        dt.Columns.Add(New DataColumn("ADDON", GetType(String)))
        dt.Columns.Add(New DataColumn("ADDBY", GetType(String)))
        For x As Integer = 2 To xlWS.Rows.Count - 1
            If xlWS.Cells(x, 1).Value <> Nothing Then
                For y As Integer = 3 To xlWS.Columns.Count - 1
                    If xlWS.Cells(1, y).Value <> Nothing Then
                        If Not xlWS.Cells(x, y).Value = 0 Then
                            dt.Rows.Add(lblDocEntry.Text, xlWS.Cells(x, 1).Value, xlWS.Cells(x, 2).Value, xlWS.Cells(1, y).Value, xlWS.Cells(x, y).Value, DateTime.Now, Info.EmpID)
                        End If
                        'MsgBox(xlWS.Cells(x, 1).Value & "-" & xlWS.Cells(x, 2).Value & "-" & xlWS.Cells(1, y).Value & "-" & xlWS.Cells(x, y).Value)
                    Else
                        Exit For
                    End If
                Next
            Else
                Exit For
            End If
        Next
        str = "DELETE BSC_PRICELVL_PROFILE_DTL WHERE DOCENTRY = '" & lblDocEntry.Text & "'"
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        cmd.ExecuteNonQuery()
        Using bulkCopy As New SqlBulkCopy(cn)
            With bulkCopy
                .DestinationTableName = "BSC_PRICELVL_PROFILE_DTL"
                .BulkCopyTimeout = 0
                .ColumnMappings.Add("DOCENTRY", "DOCENTRY")
                .ColumnMappings.Add("IMH_CODE", "IMH_CODE")
                .ColumnMappings.Add("IMH_DESC", "IMH_DESC")
                .ColumnMappings.Add("PRICE_LEVEL", "PRICE_LEVEL")
                .ColumnMappings.Add("PRICE", "PRICE")
                .ColumnMappings.Add("ADDON", "ADDON")
                .ColumnMappings.Add("ADDBY", "ADDBY")
                .WriteToServer(dt)
                .Close()
            End With
        End Using

        cmd.Dispose()
        cn.Dispose()

        xlApp.Quit()
        dt.Dispose()
        cboSheet.Items.Clear()
        lblXlFname.Text = "No Excel"
        MsgBox("Done saving excel Data.")
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim OpenFile As New OpenFileDialog
        Dim SheetName As New List(Of String)
        Dim xlApp As New Excel.Application
        Dim xlWS As Excel.Worksheet
        Dim FileName As String = ""


        If OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            vFileName = ""
            FileName = OpenFile.FileName
            vFileName = FileName
            lblXlFname.Text = FileName

            xlApp.Workbooks.Open(FileName, 0, True)

            SheetName.Clear()
            SheetName.Add("")
            For Each xlWS In xlApp.Sheets
                SheetName.Add(xlWS.Name)
            Next
            cboSheet.Text = ""
            cboSheet.Items.Clear()
            For i As Integer = 0 To SheetName.Count - 1
                cboSheet.Items.Add(SheetName(i))
            Next
            xlApp.Quit()
        End If
    End Sub

    Private Sub btnSaveXlData_Click(sender As Object, e As EventArgs) Handles btnSaveXlData.Click
        If cboSheet.Text = "" Then MsgBox("No Selected Excel Sheet.") : Exit Sub
        If MsgBox("Saving Excel Data will overwrite existing record of current docentry, do you still want to proceed?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Importexcel()
        End If

    End Sub

    Private Sub D1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles D1.DataError

    End Sub
End Class