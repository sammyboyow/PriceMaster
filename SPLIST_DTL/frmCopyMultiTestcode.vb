Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class frmCopyMultiTestcode
    Dim vfilename As String = ""
    Private Sub frmCopyTestcode_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmCopyTestcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpEFD.Value = Date.Now.ToShortDateString
        LoadTestCode()
    End Sub

    Public Sub LoadTestCode()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim c As New AutoCompleteStringCollection()

        Dim str As String = "SELECT TOP 1 IMH_CODE, IMH_DESC FROM ITEM_MASTERH WITH(NOLOCK) "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            c.Clear()
            txtNtcode.Clear()
            txtOtcode.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                c.Add(dt.Rows(i).Item("IMH_DESC").ToString)
                c.Add(dt.Rows(i).Item("IMH_CODE").ToString)
            Next
            txtNtcode.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtNtcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtNtcode.AutoCompleteCustomSource = c

            txtOtcode.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtOtcode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtOtcode.AutoCompleteCustomSource = c
        Else
            c.Clear()
            txtNtcode.Clear()
            txtOtcode.Clear()
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear_fields()
    End Sub
    Private Sub clear_fields()
        txtNtcode.Clear()
        txtNtdesc.Clear()
        txtOtcode.Clear()
        txtOtdesc.Clear()
        txtNBcode.Clear()
        dtpEFD.Value = Nothing
    End Sub

    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
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



            Dim dt As New DataTable


            Dim xlApp As New Excel.Application
            Dim xlWB As Excel.Workbook = xlApp.Workbooks.Open(vFileName)
            Dim xlWS As Excel.Worksheet = xlWB.Sheets(1)

            Dim i As Integer = 0

            For x As Integer = 2 To xlWS.Rows.Count - 1
                If xlWS.Cells(x, 1).Value <> Nothing Then

                    If xlWS.Cells(x, 1).Value <> Nothing Then
                        str =
                             "EXEC CopyTestCode '" & xlWS.Cells(x, 1).Value & "', '" & xlWS.Cells(x, 4).Value & "', '" & xlWS.Cells(x, 3).Value & "', " &
                             "'" & Date.Now.ToShortDateString & "', '" & imhbid & "', '" & spbid & "'"
                        cmd = New SqlCommand(str, cn)
                        cmd.CommandTimeout = 0
                        cmd.ExecuteNonQuery()

                        str = "INSERT INTO BATCH_SPLIST VALUES ('" & spbid & "','" & dtpEFD.Value.ToShortDateString & "','N') "
                        cmd.CommandTimeout = 0
                        cmd = New SqlCommand(str, cn)
                        'cmd.ExecuteNonQuery()
                    Else

                    End If

                Else
                    Exit For
                End If
            Next

            xlApp.Quit()

            str = "COMMIT TRAN"
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
        MsgBox("Done")
        cmd.Dispose()
        cn.Dispose()

        If MsgBox("View Generated SPList?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            frmViewSplistComp.txtBatchID.Text = spbid
            frmViewSplistComp.SPComp(spbid)
            frmViewSplistComp.ShowDialog()
        End If
    End Sub

    Private Sub txtNtcode_LostFocus(sender As Object, e As EventArgs) Handles txtNtcode.LostFocus
        If txtNtcode.Text = "" Then Exit Sub

        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT IMH_CODE, IMH_DESC FROM ITEM_MASTERH WHERE IMH_CODE = '" & Replace(txtNtcode.Text, "'", "''") & "' OR IMH_DESC = '" & Replace(txtNtcode.Text, "'", "''") & "' "
        Dim adapt As New SqlDataAdapter(str, cn)
        Dim dt As New DataTable
        adapt.Fill(dt)

        If dt.Rows.Count > 0 Then
            txtNtcode.Text = dt.Rows(0).Item("IMH_CODE").ToString
            txtNtdesc.Text = dt.Rows(0).Item("IMH_DESC").ToString
            txtOtcode.Focus()
        End If
        cn.Dispose()
    End Sub
    Private Sub txtNtcode_TextChanged(sender As Object, e As EventArgs) Handles txtNtcode.TextChanged
        If txtNtcode.Text = "" Then
            txtNtcode.Text = ""
        End If
    End Sub
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim OpenFile As New OpenFileDialog

        Dim xlApp As New Excel.Application
        Dim FileName As String = ""


        If OpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            vfilename = ""
            FileName = OpenFile.FileName
            vfilename = FileName


            xlApp.Workbooks.Open(FileName, 0, True)
            xlApp.Quit()
        End If
    End Sub
End Class