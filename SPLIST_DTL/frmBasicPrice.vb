Imports System.Data.SqlClient

Public Class frmBasicPrice
    Dim vdt As New DataTable
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub cbType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbType.SelectedIndexChanged
        Dim c As New AutoCompleteStringCollection()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim dr As SqlDataReader


        If cbType.Text = "" Then
            txtSearch.Clear()
        ElseIf cbType.Text = "PRICE LEVEL" Then
            str = "SELECT DISTINCT PRICE_LEVEL FROM BASIC_PRICE_LVL WITH(NOLOCK) "
            cmd = New SqlCommand(str, cn)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                c.Clear()
                txtSearch.Clear()
                While dr.Read
                    c.Add(dr("PRICE_LEVEL"))
                End While
            Else
                c.Clear()
                txtSearch.Clear()
            End If
            dr.Close()
        ElseIf cbType.Text = "TEST CODE" Then
            str = "SELECT DISTINCT IMH_CODE, IMH_DESC FROM BASIC_PRICE_LVL "
            cmd = New SqlCommand(str, cn)
            dr = cmd.ExecuteReader

            If dr.HasRows Then
                c.Clear()
                txtSearch.Clear()
                While dr.Read
                    c.Add(dr("IMH_CODE"))
                    c.Add(dr("IMH_DESC"))
                End While
            Else
                c.Clear()
                txtSearch.Clear()
            End If
            dr.Close()
        End If
        If cbType.Text <> "" Then
            txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtSearch.AutoCompleteCustomSource = c
        End If
        cn.Dispose()
        cn.Close()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = ""
        Dim adapt As New SqlDataAdapter



        If cbType.Text = "" Then
            MessageBox.Show("Please Select Search Type", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        ElseIf cbType.Text = "PRICE LEVEL" Then
            str = "SELECT * FROM BASIC_PRICE_LVL WHERE PRICE_LEVEL = '" & Trim(Replace(txtSearch.Text, "'", "''")) & "' ORDER BY PRICE_LEVEL, IMH_CODE "
        ElseIf cbType.Text = "TEST CODE" Then
            str = "SELECT * FROM BASIC_PRICE_LVL WHERE IMH_CODE = '" & Trim(Replace(txtSearch.Text, "'", "''")) & "' OR IMH_DESC = '" & Trim(Replace(txtSearch.Text, "'", "''")) & "' ORDER BY PRICE_LEVEL, IMH_CODE "
        End If
        adapt = New SqlDataAdapter(str, cn)
        vdt = New DataTable
        adapt.Fill(vdt)

        If vdt.Rows.Count > 0 Then
            d.Rows.Clear()
            For i As Integer = 0 To vdt.Rows.Count - 1
                d.Rows.Add()
                d("IMH_CODE", i).Value = vdt.Rows(i).Item("IMH_CODE").ToString
                d("IMH_DESC", i).Value = vdt.Rows(i).Item("IMH_DESC").ToString
                d("PRICE_LEVEL", i).Value = vdt.Rows(i).Item("PRICE_LEVEL").ToString
                d("PRICE", i).Value = vdt.Rows(i).Item("PRICE").ToString
            Next
        Else
            d.Rows.Clear()
        End If
    End Sub
    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        If txtFind.Text = "" Then
            If vdt.Rows.Count > 0 Then
                d.Rows.Clear()
                For i As Integer = 0 To vdt.Rows.Count - 1
                    d.Rows.Add()
                    d("IMH_CODE", i).Value = vdt.Rows(i).Item("IMH_CODE").ToString
                    d("IMH_DESC", i).Value = vdt.Rows(i).Item("IMH_DESC").ToString
                    d("PRICE_LEVEL", i).Value = vdt.Rows(i).Item("PRICE_LEVEL").ToString
                    d("PRICE", i).Value = vdt.Rows(i).Item("PRICE").ToString
                Next
            Else
                d.Rows.Clear()
            End If
        Else
            'Dim Row() As DataRow = vdt.Select("PRICE_LEVEL LIKE '%" & Replace(txtFind.Text, "'", "''") & _
            '                                  "%' OR IMH_CODE LIKE '%" & Replace(txtFind.Text, "'", "''") & "%' OR IMH_DESC LIKE '%" & Replace(txtFind.Text, "'", "''") & "%' ")
            Dim Row() As DataRow = vdt.Select("PRICE_LEVEL LIKE '%" & Replace(txtFind.Text, "'", "''") & "%' ")

            If Row.Count > 0 Then
                Dim i As Integer = 0
                d.Rows.Clear()
                For Each vRow As DataRow In Row
                    d.Rows.Add()
                    d("IMH_CODE", i).Value = vRow("IMH_CODE")
                    d("IMH_DESC", i).Value = vRow("IMH_DESC")
                    d("PRICE_LEVEL", i).Value = vRow("PRICE_LEVEL")
                    d("PRICE", i).Value = vRow("PRICE")
                    i += 1
                Next
            Else
                d.Rows.Clear()
                MessageBox.Show("No Data Found", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "" Then
            txtFind.Text = ""
            vdt = New DataTable
            d.Rows.Clear()
        End If
    End Sub
End Class