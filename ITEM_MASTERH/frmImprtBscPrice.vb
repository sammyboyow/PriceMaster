Imports System.Data.SqlClient
Imports Microsoft.Office.Interop
Imports System
Imports System.Windows


Public Class frmImprtBscPrice
    Dim vFileName As String = ""
    Private Sub frmImprtBscPrice_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmImprtBscPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F4 Then
            If MsgBox("Do you want to remove non senior SPLIST [Y/N]?", "Price Master System", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = Windows.Forms.DialogResult.Yes Then
                For x As Integer = D.Rows.Count - 1 To 0 Step -1
                    If D.Rows(x).Cells("Chk").Value = True Then
                        D.Rows.Remove(D.Rows(x))
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub frmImprtBscPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadPricelvl()
        btnLoad.PerformClick()
        dtpefd.Value = Date.Now.ToShortDateString
    End Sub
    Sub loadPricelvl()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        str = "SELECT DISTINCT PRICELEVEL FROM PRICE_LEVEL_DTL ORDER BY 1"
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        cboPricelvl.Items.Clear()
        If dr.HasRows Then
            cboPricelvl.Items.Add("ALL")
            While dr.Read
                cboPricelvl.Items.Add(dr("PRICELEVEL"))
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader
        Dim i As Integer = 0

        If cboPricelvl.Text <> "" And cboPricelvl.Text <> "ALL" Then str = str & " AND PRICELEVEL = '" & cboPricelvl.Text & "' "
        If cboPricelist.Text <> "" And cboPricelist.Text <> "ALL" Then str = str & " AND (PRICELIST LIKE '%" & cboPricelist.Text & "%' OR PRICELIST_DESC LIKE '%" & cboPricelist.Text & "%') "
        str =
            "SELECT PriceLevel,PriceList,PriceList_Desc,Regular_1,Regular_2,Special_1,Special_2,Imaging_1,Imaging_2,UTZ_1,UTZ_2,IS_SENIOR " & _
            "FROM dbo.Price_Level_Dtl WITH(NOLOCK) WHERE 1 = 1 " & str
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader
        D.Rows.Clear()

        If dr.HasRows Then
            While dr.Read
                D.Rows.Add()
                D("PriceLevel", i).Value = dr("PriceLevel")
                D("PriceList", i).Value = dr("PriceList")
                D("PriceListDesc", i).Value = dr("PriceList_Desc")
                D("Regular_1", i).Value = dr("Regular_1")
                D("Regular_2", i).Value = dr("Regular_2")
                D("Special_1", i).Value = dr("Special_1")
                D("Special_2", i).Value = dr("Special_2")
                D("Imaging_1", i).Value = dr("Imaging_1")
                D("Imaging_2", i).Value = dr("Imaging_2")
                D("UTZ_1", i).Value = dr("UTZ_1")
                D("UTZ_2", i).Value = dr("UTZ_2")
                D("IS_SENIOR", i).Value = dr("IS_SENIOR")
                If dr("IS_SENIOR") = "1" And ChkSenior.Checked = True Then
                    D.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
                ElseIf dr("IS_SENIOR") = "1" And ChkSenior.Checked = False Then
                    D.Rows(i).DefaultCellStyle.BackColor = Color.LemonChiffon
                End If
                i += 1
            End While
        Else

            MsgBox("No records found.", MsgBoxStyle.Information)
        End If
        cmd.Dispose()
        cn.Dispose()

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

            cboSheet.Items.Clear()
            For i As Integer = 0 To SheetName.Count - 1
                cboSheet.Items.Add(SheetName(i))
            Next
            xlApp.Quit()
        End If
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

        dt.Columns.Add(New DataColumn("IMH_CODE", GetType(String)))
        dt.Columns.Add(New DataColumn("IMH_DESC", GetType(String)))
        dt.Columns.Add(New DataColumn("PRICE_LEVEL", GetType(String)))
        dt.Columns.Add(New DataColumn("PRICE", GetType(String)))
        For x As Integer = 2 To xlWS.Rows.Count - 1
            If xlWS.Cells(x, 1).Value <> Nothing Then
                For y As Integer = 3 To xlWS.Columns.Count - 1
                    If xlWS.Cells(1, y).Value <> Nothing Then
                        dt.Rows.Add(xlWS.Cells(x, 1).Value, xlWS.Cells(x, 2).Value, xlWS.Cells(1, y).Value, xlWS.Cells(x, y).Value)

                        'MsgBox(xlWS.Cells(x, 1).Value & "-" & xlWS.Cells(x, 2).Value & "-" & xlWS.Cells(1, y).Value & "-" & xlWS.Cells(x, y).Value)
                    Else
                        Exit For
                    End If
                Next
            Else
                Exit For
            End If
        Next
        str = "TRUNCATE TABLE TMPBASIC_PRICE_LVL"
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        cmd.ExecuteNonQuery()
        Using bulkCopy As New SqlBulkCopy(cn)
            With bulkCopy
                .DestinationTableName = "TMPBASIC_PRICE_LVL"
                .BulkCopyTimeout = 0
                .ColumnMappings.Add("IMH_CODE", "IMH_CODE")
                .ColumnMappings.Add("IMH_DESC", "IMH_DESC")
                .ColumnMappings.Add("PRICE_LEVEL", "PRICE_LEVEL")
                .ColumnMappings.Add("PRICE", "PRICE")
                .WriteToServer(dt)
                .Close()
            End With
        End Using

        cmd.Dispose()
        cn.Dispose()

        xlApp.Quit()
        dt.Dispose()
    End Sub

    Private Sub ImportPricelist()
        Dim dt As New DataTable

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand

        dt.Columns.Add(New DataColumn("PriceLevel", GetType(String)))
        dt.Columns.Add(New DataColumn("PriceList", GetType(String)))
        dt.Columns.Add(New DataColumn("PriceList_Desc", GetType(String)))
        dt.Columns.Add(New DataColumn("Regular_1", GetType(String)))
        dt.Columns.Add(New DataColumn("Regular_2", GetType(String)))
        dt.Columns.Add(New DataColumn("Special_1", GetType(String)))
        dt.Columns.Add(New DataColumn("Special_2", GetType(String)))
        dt.Columns.Add(New DataColumn("Imaging_1", GetType(String)))
        dt.Columns.Add(New DataColumn("Imaging_2", GetType(String)))
        dt.Columns.Add(New DataColumn("UTZ_1", GetType(String)))
        dt.Columns.Add(New DataColumn("UTZ_2", GetType(String)))
        dt.Columns.Add(New DataColumn("IS_SENIOR", GetType(String)))

        For i As Integer = 0 To D.Rows.Count - 1
            dt.Rows.Add(D("PriceLevel", i).Value,
                        D("PriceList", i).Value,
                        D("PriceListDesc", i).Value,
                        D("Regular_1", i).Value,
                        D("Regular_2", i).Value,
                        D("Special_1", i).Value,
                        D("Special_2", i).Value,
                        D("Imaging_1", i).Value,
                        D("Imaging_2", i).Value,
                        D("UTZ_1", i).Value,
                        D("UTZ_2", i).Value,
                        D("IS_SENIOR", i).Value)
        Next

        str = "TRUNCATE TABLE TMPPrice_Level_Dtl"
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        cmd.ExecuteNonQuery()
        Using bulkCopy As New SqlBulkCopy(cn)
            With bulkCopy
                .DestinationTableName = "TMPPrice_Level_Dtl"
                .BulkCopyTimeout = 0
                .ColumnMappings.Add("PriceLevel", "PriceLevel")
                .ColumnMappings.Add("PriceList", "PriceList")
                .ColumnMappings.Add("PriceList_Desc", "PriceList_Desc")
                .ColumnMappings.Add("Regular_1", "Regular_1")
                .ColumnMappings.Add("Regular_2", "Regular_2")
                .ColumnMappings.Add("Special_1", "Special_1")
                .ColumnMappings.Add("Special_2", "Special_2")
                .ColumnMappings.Add("Imaging_1", "Imaging_1")
                .ColumnMappings.Add("Imaging_2", "Imaging_2")
                .ColumnMappings.Add("UTZ_1", "UTZ_1")
                .ColumnMappings.Add("UTZ_2", "UTZ_2")
                .ColumnMappings.Add("IS_SENIOR", "IS_SENIOR")

                .WriteToServer(dt)
                .Close()
            End With
        End Using

        If ChkSenior.Checked = False Then
            str =
            "UPDATE TMPPrice_Level_Dtl SET Regular_1 = CASE WHEN Regular_1 LIKE '-%' THEN 0.00 ELSE Regular_1 END, " & _
            "Regular_2 = CASE WHEN Regular_2 LIKE '-%' THEN 0.00 ELSE Regular_2 END, " & _
            "Special_1 = CASE WHEN Special_1 LIKE '-%' THEN 0.00 ELSE Special_1 END, " & _
            "Special_2 = CASE WHEN Special_2 LIKE '-%' THEN 0.00 ELSE Special_2 END, " & _
            "Imaging_1 = CASE WHEN Imaging_1 LIKE '-%' THEN 0.00 ELSE Imaging_1 END, " & _
            "Imaging_2 = CASE WHEN Imaging_2 LIKE '-%' THEN 0.00 ELSE Imaging_2 END, " & _
            "UTZ_1 = CASE WHEN UTZ_1 LIKE '-%' THEN 0.00 ELSE UTZ_1 END, " & _
            "UTZ_2 = CASE WHEN UTZ_2 LIKE '-%' THEN 0.00 ELSE UTZ_2 END " & _
            "WHERE IS_SENIOR = 1 "
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
        End If

        cmd.Dispose()
        cn.Dispose()
        dt.Dispose()

    End Sub
    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        If D.Rows.Count < 1 Then Exit Sub
        For i As Integer = 0 To D.Rows.Count - 1
            D("Chk", i).Value = ChkAll.CheckState
        Next
    End Sub

    Private Sub btnRemoveItem_Click(sender As Object, e As EventArgs) Handles btnRemoveItem.Click
        If D.Rows.Count = 0 Then MsgBox("NO items to remove.", MsgBoxStyle.Information) : Exit Sub
        Dim Chk As Boolean = False
        For i As Integer = 0 To D.Rows.Count - 1
            If D("Chk", i).Value = True Then Chk = True : Exit For
        Next
        If Chk = False Then MsgBox("No selected item!", MsgBoxStyle.Information)
        For x As Integer = D.Rows.Count - 1 To 0 Step -1
            If D.Rows(x).Cells("Chk").Value Then
                D.Rows.Remove(D.Rows(x))
            End If
        Next

    End Sub

    Private Sub cboPricelvl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPricelvl.SelectedIndexChanged
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader

        If cboPricelvl.Text <> "ALL" And cboPricelvl.Text <> "" Then str = str & " AND PRICELEVEL = '" & cboPricelvl.Text & "' "

        str = "SELECT DISTINCT PRICELIST FROM PRICE_LEVEL_DTL WHERE 1 = 1 " & str & " ORDER BY 1"
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        cboPricelist.Items.Clear()
        If dr.HasRows Then
            cboPricelist.Items.Add("ALL")
            While dr.Read
                cboPricelist.Items.Add(dr("PRICELIST"))
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub
    'Sub con()
    '    bool()
    '    con1()
    '    con2()
    '    con3()

    '   bool = functi(sqlconnection con)
    '   bool = functi(sqlconnection con2)
    '  bool=  functi(sqlconnection con3)

    '    rollback()
    'End Sub
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        If chkNewProc.Checked = True Then
            If MsgBox("Are you sure to use new procedure of price update?.", MsgBoxStyle.YesNoCancel, "Question") <> MsgBoxResult.Yes Then
                Exit Sub
            End If
        End If

        CheckForIllegalCrossThreadCalls = False
        If Not BW1.IsBusy Then BW1.RunWorkerAsync()
        pbBW.Visible = True
    End Sub
    Private Sub Generate()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand

        Dim spbid As String = ""
        Dim imhbid As String = ""

        spbid = GetBatchID_SPLIST()
        imhbid = GetBatchID_IMH()
        Try
            str = "BEGIN TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            str =
                "EXEC CREATE_IMH '" & Info.POSID & "', '" & dtpefd.Value & "', '" & imhbid & "'"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            str =
                "EXEC CREATE_SPLIST '" & Info.POSID & "', '" & dtpefd.Value & "', '" & spbid & "'"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            str =
                "COMMIT TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            str = "IF @@TRANCOUNT>1 ROLLBACK TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            cmd.Dispose()
            cn.Dispose()
            MsgBox(ex.Message)
            Exit Sub
        End Try
        pbBW.Visible = False
        MsgBox("Done" & "-" & DateTime.Now)
        cmd.Dispose()
        cn.Dispose()
        If MsgBox("View Generated SPList?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            frmViewSplistComp.txtBatchID.Text = spbid
            frmViewSplistComp.SPComp(spbid)
            frmViewSplistComp.Show()
        End If
    End Sub

    Private Sub BW1_DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs) Handles BW1.DoWork
        btnGenerate.Enabled = False
        Importexcel()
        ImportPricelist()
        Generate()
        btnGenerate.Enabled = True
    End Sub

    Private Sub D_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles D.CellContentClick

    End Sub

    Private Sub cboSheet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSheet.SelectedIndexChanged

    End Sub
End Class