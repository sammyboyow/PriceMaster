Imports System.Data.SqlClient
Public Class frmGEN_SPLIST
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
    Public Sub EFF_DATE()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand

        str = "SELECT DISTINCT SPD_EFD FROM SPLIST_DTL WITH(NOLOCK) " & _
            "WHERE ISNULL(BATCH_ID, '') = '' " & _
            "ORDER BY SPD_EFD"
        cmd = New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            cbEFFDate.Items.Clear()
            cbEFFDate.Items.Add("")
            While dr.Read
                cbEFFDate.Items.Add(dr("SPD_EFD"))
            End While
        Else
            cbEFFDate.Items.Clear()
            cbEFFDate.Items.Add("")
        End If
        dr.Close()
        cn.Dispose()


    End Sub
    Public Sub LoadMax_BatchID()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT (ISNULL(MAX(BATCH_ID), 0) + 1) BATCH_ID FROM BATCH_SPLIST "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        txtBatchID.Text = str
    End Sub
    Public Sub RunWorker()
        If bg1.IsBusy = True Then
            bg1.CancelAsync()
            RunWorker()
        Else
            bg1.RunWorkerAsync()
        End If
    End Sub
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MessageBox.Show("Do you want to save SPLIST ?", "Price Master System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then Exit Sub
        If cbEFFDate.Text = "" Then MessageBox.Show("Please Enter Effectivity date", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        pb1.Visible = True
        lblPB.Visible = True
        RunWorker()
    End Sub

    Private Sub frmGEN_SPLIST_Load(sender As Object, e As EventArgs) Handles Me.Load
        EFF_DATE()
        LoadMax_BatchID()
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub bg1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bg1.DoWork
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim str As String = "", Delete_Script As String = "", MaxCount As Integer = 0
        Dim cmd As New SqlCommand

        str = "SELECT TOP 1 1 FROM BATCH_SPLIST WHERE EFD_DATE = '" & cbEFFDate.Text & "' AND BATCH_ID = '" & txtBatchID.Text & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If Not str Is Nothing Then
            MessageBox.Show("Batch effetiity date already exists", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            'str = "SELECT SPD_CODE, SPD_IMH_CODE FROM SPLIST_DTL " & _
            '    "WHERE SPD_EFD = '" & cbEFFDate.Text & "' AND BATCH_ID IS NULL " & _
            '    "ORDER BY SPD_IMH_CODE, SPD_CODE"
            'Dim da As New SqlDataAdapter(str, cn)
            'Dim dt As New DataTable
            'dt = New DataTable
            'da.Fill(dt)

            Try
                cmd = New SqlCommand("BEGIN TRAN", cn2)
                cmd.ExecuteNonQuery()

                str = "INSERT INTO BATCH_SPLIST VALUES ('" & txtBatchID.Text & "','" & cbEFFDate.Text & "','N')"
                cmd = New SqlCommand(str, cn2)
                cmd.CommandTimeout = 0
                cmd.ExecuteNonQuery()

                'If dt.Rows.Count > 0 Then
                '    str = "INSERT INTO BATCH_SPLIST VALUES ('" & txtBatchID.Text & "','" & cbEFFDate.Text & "','N')"
                '    cmd = New SqlCommand(str, cn2)
                '    cmd.CommandTimeout = 0
                '    cmd.ExecuteNonQuery()

                '    If dt.Rows.Count > 0 Then
                '        For i As Integer = 0 To dt.Rows.Count - 1
                '            Delete_Script = "DELETE SPLIST_DTL WHERE SPD_CODE = '" & dt.Rows(i).Item("SPD_CODE").ToString & "' AND SPD_IMH_CODE = '" & dt.Rows(i).Item("SPD_IMH_CODE").ToString & "' "
                '            str = "INSERT INTO DELETE_SCRIPT_SPLIST VALUES ('" & txtBatchID.Text & "','" & dt.Rows(i).Item("SPD_CODE").ToString & "','" & dt.Rows(i).Item("SPD_IMH_CODE").ToString & "','" & Replace(Delete_Script, "'", "''") & "')"
                '            cmd = New SqlCommand(str, cn2)
                '            cmd.CommandTimeout = 0
                '            cmd.ExecuteNonQuery()

                '            str = "UPDATE SPLIST_DTL SET BATCH_ID = '" & txtBatchID.Text & "' WHERE SPD_CODE = '" & dt.Rows(i).Item("SPD_CODE").ToString & "' AND SPD_IMH_CODE = '" & dt.Rows(i).Item("SPD_IMH_CODE").ToString & "' "
                '            cmd = New SqlCommand(str, cn2)
                '            cmd.CommandTimeout = 0
                '            cmd.ExecuteNonQuery()
                '        Next                      
                '    End If
                'End If
                cmd = New SqlCommand("COMMIT", cn2)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Done Generating SPLIST", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                cmd = New SqlCommand("ROLLBACK", cn2)
                cmd.ExecuteNonQuery()
                MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
       
            'str = "SELECT SPD_CODE, SPD_IMH_CODE FROM SPLIST_DTL WHERE SPD_EFD = '" & cbEFFDate.Text & "' AND BATCH_ID IS NULL "
            'cmd = New SqlCommand(str, cn)
            'Dim dr As SqlDataReader = cmd.ExecuteReader

            'If dr.HasRows Then
            '    Try
            '        cmd = New SqlCommand("BEGIN TRAN", cn2)
            '        cmd.ExecuteNonQuery()

            '        str = "INSERT INTO BATCH_SPLIST VALUES ('" & txtBatchID.Text & "','" & cbEFFDate.Text & "','N')"
            '        Dim da As New SqlDataAdapter(str, cn)
            '        Dim dt As New DataTable
            '        dt = New DataTable
            '        da.Fill(dt)

            '        If dt.Rows.Count > 0 Then
            '            For i As Integer = 0 To dt.Rows.Count - 1
            '                Delete_Script = "DELETE SPLIST_DTL WHERE SPD_CODE = '" & dt.Rows(i).Item("SPD_CODE").ToString & "' AND SPD_IMH_CODE = '" & dt.Rows(i).Item("SPD_IMH_CODE").ToString & "' "
            '                cmd = New SqlCommand(str, cn2)
            '                cmd.CommandTimeout = 0
            '                cmd.ExecuteNonQuery()
            '            Next
            '            str = "UPDATE SPLIST_DTL SET BATCH_ID = '" & txtBatchID.Text & "' WHERE SPD_CODE = '" & dr("SPD_CODE") & "' AND SPD_IMH_CODE = '" & dr("SPD_IMH_CODE") & "' "
            '            cmd = New SqlCommand(str, cn2)
            '            cmd.CommandTimeout = 0
            '            cmd.ExecuteNonQuery()
            '        End If

            '        'cmd = New SqlCommand(str, cn2)
            '        'cmd.ExecuteNonQuery()

            '        'While dr.Read
            '        '    Delete_Script = "DELETE SPLIST_DTL WHERE SPD_CODE = '" & dr("SPD_CODE") & "' AND SPD_IMH_CODE = '" & dr("SPD_IMH_CODE") & "' "

            '        '    str = "INSERT INTO DELETE_SCRIPT_SPLIST VALUES ('" & txtBatchID.Text & "','" & dr("SPD_CODE") & "','" & dr("SPD_IMH_CODE") & "','" & Replace(Delete_Script, "'", "''") & "')"
            '        '    cmd = New SqlCommand(str, cn2)
            '        '    cmd.CommandTimeout = 0
            '        '    cmd.ExecuteNonQuery()

            '        '    str = "UPDATE SPLIST_DTL SET BATCH_ID = '" & txtBatchID.Text & "' WHERE SPD_CODE = '" & dr("SPD_CODE") & "' AND SPD_IMH_CODE = '" & dr("SPD_IMH_CODE") & "' "
            '        '    cmd = New SqlCommand(str, cn2)
            '        '    cmd.CommandTimeout = 0
            '        '    cmd.ExecuteNonQuery()
            '        'End While

            '        cmd = New SqlCommand("COMMIT", cn2)
            '        cmd.ExecuteNonQuery()
            '        MessageBox.Show("Done Generating SPLIST", "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Catch ex As Exception
            '        cmd = New SqlCommand("ROLLBACK", cn2)
            '        cmd.ExecuteNonQuery()
            '        MessageBox.Show(ex.Message, "Price Master System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    End Try


            cn.Dispose()
        End If
    End Sub

    Private Sub bg1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bg1.RunWorkerCompleted
        pb1.Visible = False
        lblPB.Visible = False
        LoadMax_BatchID()
        EFF_DATE()
    End Sub
End Class