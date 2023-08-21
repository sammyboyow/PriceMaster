Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports Oracle.DataAccess.Client
Imports Microsoft.Office.Interop
Imports System.IO
Public Class frmSingleIMH
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

        Dim str As String = "SELECT DISTINCT B.Blk " & _
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
    Private Function SearchGrid(ByVal strItem As String, ByVal intColumn As Integer) As Integer
        Dim intIndex As Integer = 0
        For i As Integer = 0 To D1.Rows.Count - 1
            If D1.Rows(i).Cells(intColumn).Value = Nothing Then Exit For
            If D1.Rows(i).Cells(intColumn).Value.Contains(strItem) Then 'Or change "Contains" to "Equals"
                intIndex = i
                Exit For
            End If
        Next
        Return intIndex
    End Function
    Public Function GetbranchCode(ByVal Branch As String) As String
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT CODE FROM SAPSET WITH(NOLOCK) WHERE Blk = '" & Branch & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If Branch = "TEST" Then
            str = "TEST"
        End If

        Return str
        cn.Dispose()
    End Function
    Public Sub ERROR_LOGS(ERR_MSG As String)
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "INSERT INTO ERR_LOGS VALUES ('" & Replace(ERR_MSG, "'", "''") & "',GETDATE())"
        Dim cmd As New SqlCommand(str, cn)
        cmd.ExecuteNonQuery()

        cn.Dispose()
    End Sub
#End Region
    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim OpenFileDialog As New OpenFileDialog

        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "All Files (*.*)|*.*|Excel files (*.xlsx)|*.xlsx|CSV Files (*.csv)|*.csv|XLS Files (*.xls)|*xls"
        OpenFileDialog.InitialDirectory = "D:\"

        If OpenFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim FileName As String = OpenFileDialog.FileName
            Dim FI As New FileInfo(OpenFileDialog.FileName)
            Dim excel As String = FI.FullName


            Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")

            Dim da As New OleDbDataAdapter("Select * From [Sheet1$]", cn)
            Dim dt As New DataTable
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                D1.DataSource = Nothing
                dt = dt.Rows.Cast(Of DataRow)().Where(Function(row) Not row.ItemArray.All(Function(field) TypeOf field Is System.DBNull OrElse String.Compare(TryCast(field, String).Trim(), String.Empty) = 0)).CopyToDataTable()
                D1.DataSource = dt
            End If
            cn.Dispose()

            If D1.RowCount > 0 Then
                For i As Integer = 0 To D1.Rows.Count - 1
                    D1((D1.ColumnCount - 1), i).Value = Format(Now, "dd/MM/yyyy hh:mm:ss")
                Next
            End If

            lblCount.Text = D1.RowCount
            D1.AutoResizeColumns()
            D1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        End If
    End Sub

    Private Sub frmSingleIMH_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadBranch()
    End Sub

    Private Sub btnClose2_Click(sender As Object, e As EventArgs) Handles btnClose2.Click
        Me.Dispose()
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        cbBranch.Text = ""
        D1.DataSource = Nothing
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        Dim intIndex As Integer = SearchGrid(txtFind.Text, 0) 'Change the 0 to what column you want to search for
        D1.Rows(intIndex).Selected = True 'This will select the row...'
        D1.CurrentCell = D1.Rows(intIndex).Cells(0) 'This ensures that the arrow will move if you have row headers visible. In order to select the cell change the zero to the column your searching to match up top
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cnstr As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST =192.171.11.100)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
        Dim cnHCLAB2 As String = "Driver={Microsoft ODBC for Oracle};Server=" & cnstr & ";UID=HCLAB;PWD=HCLAB"

        Dim str As String = "", BranchCode As String = "", BATCH_ID As String = ""
        Dim cmd As New SqlCommand

        Try
            cmd = New SqlCommand("BEGIN TRAN", cn)
            cmd.ExecuteNonQuery()

            str = "SELECT ISNULL(MAX(BATCH_ID), 0) BATCH_ID FROM TMP_ITEM_MASTERH WITH(NOLOCK)"
            cmd = New SqlCommand(str, cn)
            str = cmd.ExecuteScalar

            BATCH_ID = CInt(str) + 1
            BranchCode = GetbranchCode(cbBranch.Text)

            For i As Integer = 0 To D1.Rows.Count - 1
                If D1(0, i).Value = Nothing Or D1(0, i).Value = "" Then Exit For
                str = "SELECT TOP 1 1 FROM TMP_ITEM_MASTERH WITH(NOLOCK) WHERE IMH_CODE = '" & D1(0, i).Value & "' AND IS_SYNC='N' AND MOTHER_BRANCH = '" & BranchCode & "' "
                cmd = New SqlCommand(str, cn)
                str = cmd.ExecuteScalar

                If str Is Nothing Then
                    str = "INSERT INTO TMP_ITEM_MASTERH (MOTHER_BRANCH, IMH_CODE, IMH_DESC, IMH_TYPE, IMH_PDGROUP, IMH_BILLCODE, IMH_STKITEM_FLAG, IMH_TAXABLE, IMH_YTD_SQTY, IMH_YTD_SAMT, IMH_STD_COST, " & _
                        "IMH_CURR_P1, IMH_EFD_P1, IMH_PREV_P1, IMH_CURR_P2, IMH_EFD_P2, IMH_PREV_P2, IMH_CURR_P3, IMH_EFD_P3, IMH_PREV_P3, IMH_FIXED_PRICE, IMH_REC_FLAG, IMH_UPDATE_BY, IMH_UPDATE_ON, IS_SYNC, BATCH_ID)" & _
                        "VALUES ('" & BranchCode & "','" & Replace(D1(0, i).Value, "'", "''") & "','" & Replace(D1(1, i).Value, "'", "''") & "','" & Replace(D1(2, i).Value, "'", "''") & "', " & _
                        "'" & Replace(D1(3, i).Value, "'", "''") & "','" & Replace(D1(4, i).Value, "'", "''") & "','" & Replace(D1(5, i).Value, "'", "''") & "','" & Replace(D1(6, i).Value, "'", "''") & "', " & _
                        "'" & Replace(D1(7, i).Value, "'", "''") & "','" & Replace(D1(8, i).Value, "'", "''") & "','" & Replace(D1(9, i).Value, "'", "''") & "','" & Replace(D1(10, i).Value, "'", "''") & "', " & _
                        "'" & Replace(D1(11, i).Value, "'", "''") & "','" & Replace(D1(12, i).Value, "'", "''") & "','" & Replace(D1(13, i).Value, "'", "''") & "','" & Replace(D1(14, i).Value, "'", "''") & "', " & _
                        "'" & Replace(D1(15, i).Value, "'", "''") & "','" & Replace(D1(16, i).Value, "'", "''") & "','" & Replace(D1(17, i).Value, "'", "''") & "','" & Replace(D1(18, i).Value, "'", "''") & "', " & _
                        "'" & Replace(D1(19, i).Value, "'", "''") & "','" & Replace(D1(20, i).Value, "'", "''") & "','" & Replace(D1(21, i).Value, "'", "''") & "',GETDATE(),'N', '" & BATCH_ID & "')"
                    cmd = New SqlCommand(str, cn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            cmd = New SqlCommand("COMMIT", cn)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Done Importing Data", "Call Center", MessageBoxButtons.OK, MessageBoxIcon.Information)
            btnClear.PerformClick()
        Catch ex As Exception
            cmd = New SqlCommand("ROLLBACK", cn)
            cmd.ExecuteNonQuery()
            ERROR_LOGS(ex.Message)
            MessageBox.Show(ex.Message, "Call Center", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
        cn.Dispose()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class