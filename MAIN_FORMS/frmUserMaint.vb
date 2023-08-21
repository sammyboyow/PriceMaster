Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.IO.StreamReader
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.IO
Imports System.Reflection
Public Class frmUserMaint
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
    Public Sub CreateImag(ByVal EmpCode As String)
        Dim cn As New SqlConnection("Data Source=192.171.10.51;Initial Catalog=HPCOMMON;Integrated Security=False;UID=sapdb;Pwd=sapdb;Max Pool Size=1000")
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim ms As MemoryStream = New MemoryStream()
        Dim imgBytes As Byte() = Nothing

        Dim str As String = "SELECT * FROM EMPPic WITH(NOLOCK) WHERE EMPCODE = '" & EmpCode & "'"
        Dim cmd As New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                Try
                    imgBytes = dr("EmpImg")
                    ms = New MemoryStream(imgBytes)
                    pbIMG.Image = Nothing
                    pbIMG.Image = Image.FromStream(ms)
                    pbIMG.SizeMode = PictureBoxSizeMode.StretchImage
                Catch ex As Exception
                End Try
            End While
        End If

        dr.Close()
        cn.Dispose()
    End Sub
    Public Sub LoadEmp()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT EMPID FROM USERS2 WITH(NOLOCK) ORDER BY EMPID "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim c As New AutoCompleteStringCollection()
        If dr.HasRows Then
            c.Clear()
            While dr.Read
                c.Add(dr("EMPID"))
            End While
        Else
            c.Clear()
        End If
        dr.Close()
        cn.Dispose()

        txtEmpID.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtEmpID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtEmpID.AutoCompleteCustomSource = c
    End Sub
    Public Sub LoadUser()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT a.EmpCode, b.EmpName " & _
                            "FROM Login_PriceMster A WITH(NOLOCK) " & _
                            "INNER JOIN [172.30.0.17].HPCOMMON.dbo.USERS2 B WITH(NOLOCK) ON A.EmpCode COLLATE DATABASE_DEFAULT = B.EmpID COLLATE DATABASE_DEFAULT " & _
                            "WHERE a.Active = 'Y' " & _
                            "ORDER BY B.EmpName "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader()

        Dim i As Integer = 0
        If dr.HasRows Then
            d.Rows.Clear()
            While dr.Read
                d.Rows.Add()
                d("EmpID", i).Value = dr("EmpCode")
                d("EmpName", i).Value = dr("EmpName")
                i += 1
            End While
        Else
            d.Rows.Clear()
        End If
        dr.Close()
        cn.Dispose()
    End Sub
    Private Function SearchGrid(ByVal strItem As String, ByVal intColumn As Integer) As Integer
        Dim intIndex As Integer = 0
        For i As Integer = 0 To d.Rows.Count - 1
            If d.Rows(i).Cells(intColumn).Value.ToString.Contains(strItem) Then 'Or change "Contains" to "Equals"
                intIndex = i
                Exit For
            End If
        Next
        Return intIndex
    End Function
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub
    Private Sub frmUserMaint_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadEmp()
        LoadUser()
        RoundImag()
    End Sub
    Private Sub txtEmpID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmpID.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSAP)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT EmpName, UserName, Pwd FROM USERS2 WITH(NOLOCK) WHERE EMPID = '" & txtEmpID.Text & "' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                While dr.Read
                    txtEmpName.Text = dr("EmpName")
                    txtUserName.Text = dr("UserName")
                    txtPass.Text = dr("Pwd")
                End While
                CreateImag(txtEmpID.Text)
            Else
                pbIMG.Image = Nothing
                btnClear.PerformClick()
            End If
            dr.Close()
            cn.Dispose()

        End If
    End Sub
    Private Sub txtEmpID_TextChanged(sender As Object, e As EventArgs) Handles txtEmpID.TextChanged
        If txtEmpID.Text = "" Then
            txtEmpName.Text = ""
            txtUserName.Text = ""
            txtPass.Text = ""
            pbIMG.Image = Nothing
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtEmpID.Text = "" Then Exit Sub
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New OdbcConnection(cnHCLAB)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim str As String = "", POSID As String = ""
        Dim cmd As New SqlCommand
        Dim cmd2 As New OdbcCommand

        str = "SELECT TOP 1 1 FROM Login_PriceMster WITH(NOLOCK) WHERE EMPCODE = '" & Replace(txtEmpID.Text, "'", "''") & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            str = "SELECT NVL(USER_NAME, ' ') USER_NAME FROM POS_USER_ACCOUNT WHERE USER_NAME = '" & Replace(txtPOSID.Text, "'", "''") & "' "
            cmd2 = New OdbcCommand(str, cn2)
            POSID = cmd2.ExecuteScalar

            str = "INSERT INTO Login_PriceMster VALUES ('" & txtEmpID.Text & "','011','Y',GETDATE(),'" & POSID & "')"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()
        Else
            str = "UPDATE Login_PriceMster SET Active = 'Y' WHERE EmpCode = '" & txtEmpID.Text & "' "
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()
        End If
        LoadUser()
        btnClear.PerformClick()
        cn.Dispose()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtEmpName.Text = ""
        txtUserName.Text = ""
        txtPass.Text = ""
        txtEmpID.Text = ""
    End Sub
    Private Sub btnDisable_Click(sender As Object, e As EventArgs) Handles btnDisable.Click
        If txtEmpID.Text = "" Then Exit Sub
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cmd As New SqlCommand
        Dim str As String = ""

        str = "SELECT TOP 1 1 FROM Login_PriceMster WHERE EmpCode = '" & txtEmpID.Text & "' "
        cmd = New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If Not str Is Nothing Then
            str = "UPDATE Login_PriceMster SET Active ='N' WHERE EmpCode ='" & txtEmpID.Text & "' "
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Account Deleted", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        cn.Dispose()
        btnClear.PerformClick()
        LoadUser()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Dim intIndex As Integer = SearchGrid(txtSearch.Text, 0) 'Change the 0 to what column you want to search for
        d.Rows(intIndex).Selected = True 'This will select the row...'
        d.CurrentCell = d.Rows(intIndex).Cells(0) 'This ensures that the arrow will move if you have row headers visible. In order to select the cell change the zero to the column your searching to match up top
    End Sub
    Private Sub d_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles d.MouseDoubleClick
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT EmpName, UserName, Pwd FROM USERS2 WITH(NOLOCK) WHERE EMPID = '" & d("EmpID", d.CurrentRow.Index).Value & "' "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                txtEmpName.Text = dr("EmpName")
                txtUserName.Text = dr("UserName")
                txtPass.Text = dr("Pwd")
            End While
            txtEmpID.Text = d("EmpID", d.CurrentRow.Index).Value
            CreateImag(txtEmpID.Text)
        Else
            pbIMG.Image = Nothing
            btnClear.PerformClick()
        End If
        dr.Close()
        cn.Dispose()
    End Sub
End Class