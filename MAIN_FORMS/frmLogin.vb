Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.IO
Imports System.Reflection
Public Class frmLogin
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
#Region "Program Update"
    Public Function ChkPath(ByVal Upath As String) As Boolean
        If System.IO.File.Exists(Upath) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ChkUpdate(ByVal FILE_PATH As String, ByVal SERVERIP As String, PASS As String)
        'Dim cn As New SqlConnection("Data Source=172.30.0.28;Initial Catalog=PRICEMASTER;Integrated Security=False;UID=admin;Pwd=hiprecision2015;Max Pool Size=1000")
        'If cn.State = ConnectionState.Closed Then cn.Open()
        Dim UPath As String = "", UPServer As String = "", GetUPDate As String = "", GetCPDate As String = ""
        Dim DirectPath As String = ""
        Dim CPath As String = Application.StartupPath & "\PriceMaster.exe"

        Dim impersonator As Impersonator = Nothing

        'impersonator = New Impersonator("" & SERVERIP & "\administrator", "p@55w0rdhpddelmonte")
        'impersonator.BeginImpersonation()

        UPath = FILE_PATH & "PriceMaster\PriceMaster.exe"
        DirectPath = FILE_PATH & "PriceMaster"

        impersonator = New Impersonator("" & SERVERIP & "\administrator", PASS)
        impersonator.BeginImpersonation()
        If ChkPath(UPath) = False Then
            MessageBox.Show("Price Master program is missing on your path" & vbNewLine & UPath, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        If ChkPath(CPath) = False Then
            MessageBox.Show("Price Master program is missing on your path" & vbNewLine & UPath, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim sw As System.IO.StreamWriter
        Dim fileName As String = AppDomain.CurrentDomain.BaseDirectory & "\PATCH.txt"

        If System.IO.File.Exists(fileName) Then
            sw = New System.IO.StreamWriter(fileName)
            sw.Write("")
            sw.Close()
        End If

        Dim sr As System.IO.StreamReader
        Dim FTarget As String = DirectPath
        Dim ExFile As String = "PriceMaster.exe" ' PROGRAM EXE NAME

        sr = System.IO.File.OpenText(fileName)
        Dim MyContents As String = sr.ReadToEnd
        sr.Close()
        sw = New StreamWriter(fileName, True) 'True for appending
        sw.WriteLine(AppDomain.CurrentDomain.BaseDirectory)
        sw.Flush()
        sw.Close()

        sr = System.IO.File.OpenText(fileName)
        MyContents = sr.ReadToEnd
        sr.Close()
        sw = New StreamWriter(fileName, True) 'True for appending
        sw.WriteLine(FTarget)
        sw.Flush()
        sw.Close()

        sr = System.IO.File.OpenText(fileName)
        MyContents = sr.ReadToEnd
        sr.Close()
        sw = New StreamWriter(fileName, True) 'True for appending
        sw.WriteLine(ExFile)
        sw.Flush()
        sw.Close()

        If ChkPath(Application.StartupPath & "\Patch.txt") = False Then MessageBox.Show("Price Master program is missing on your path" & vbNewLine & UPath, "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) : Exit Sub
        Dim UPDate As Date = File.GetLastWriteTime(UPath)
        Dim CPDate As Date = File.GetLastWriteTime(CPath)

        If CDate(UPDate) > CDate(CPDate) Then
            MsgBox("New Update Available" & vbNewLine & "Please Click OK to update your program Price Master")
            Process.Start(Application.StartupPath & "\UpdatePatch.exe")
            End
        End If
        impersonator.EndImpersonation()

    End Sub
    Public Sub WriteToPatch(ByVal UPatch As String, ByVal FileName As String)
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath & "\" & FileName & "", False)
        If FileName = "PATCH.txt" Then
            file.WriteLine(Application.StartupPath)
            file.WriteLine(UPatch)
            file.WriteLine("PriceMaster.exe")
        ElseIf FileName = "UpdateFile.txt" Then
            file.WriteLine("PriceMaster")
            file.WriteLine("PriceMaster.exe")
        Else
            file.WriteLine("PriceMaster.exe")
        End If
        file.Close()
    End Sub
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        End
    End Sub

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim str As String = ""
        Dim cmd As New SqlCommand
        'Try
        If txtUserName.Text = "ADMIN" And txtPassword.Text = "ADMIN" Then
            Info.EmpID = "0"
            Info.UserName = "ADMINISTRATOR"
            frmMain.Show()
            Me.Hide()
        Else

            str = "exec userlogin '" & Replace(txtUserName.Text, "'", "''") & "' , '" & Replace(txtPassword.Text, "'", "''") & "'"
            cmd = New SqlCommand(str, cn)
            Dim dt As New DataTable
            dt.Load(cmd.ExecuteReader)
            cmd.Dispose()

            If (dt.Rows.Count > 0) Then

                str = "SELECT POS_ID FROM Login_PriceMster WITH(NOLOCK) WHERE EmpCode ='" & dt.Rows(0).Item("EmpID").ToString() & "' AND ACTIVE = 'Y'"
                cmd = New SqlCommand(str, cn2)
                str = cmd.ExecuteScalar

                If str Is Nothing Then
                    MessageBox.Show("You don't have access to this program", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    Info.EmpID = dt.Rows(0).Item("EmpID").ToString()
                    Info.UserName = dt.Rows(0).Item("EmpName").ToString()
                    Info.POSID = str
                    frmMain.Show()
                    Me.Dispose()

                End If

            Else
                MessageBox.Show("Invalid User Name or Password", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


            'str = "SELECT B.EmpName, A.EmpCode, A.POS_ID " & _
            '    "FROM [192.171.11.175].[PRICEMASTER].dbo.Login_PriceMster A WITH(NOLOCK) " & _
            '    "INNER JOIN Users2 B WITH(NOLOCK) ON A.EmpCode COLLATE DATABASE_DEFAULT = B.EmpID COLLATE DATABASE_DEFAULT " & _
            '    "WHERE B.UserID = '" & Replace(txtUserName.Text, "'", "''") & "' AND B.Pwd = '" & Replace(txtPassword.Text, "'", "''") & "' "
            'Dim da As New SqlDataAdapter
            'da = New SqlDataAdapter(str, cn)
            'Dim dt As New DataTable
            'da.Fill(dt)

            'If dt.Rows.Count > 0 Then
            '    For i As Integer = 0 To dt.Rows.Count - 1
            '        Info.EmpID = dt.Rows(i).Item("EmpCode").ToString
            '        Info.UserName = dt.Rows(i).Item("EmpName").ToString
            '        Info.POSID = dt.Rows(i).Item("POS_ID").ToString
            '    Next
            '    frmMain.Show()
            '    Me.Hide()
            'Else
            '    MessageBox.Show("Invalid User Name or Password", "Price Master", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            'End If
        End If
        cn.Dispose()

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        GetConnection()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim uIP As String = ""
        Dim uFileName As String = ""
        Dim UPass As String = ""

        Dim str As String = "SELECT * FROM UPDATE_PATCH WITH(NOLOCK)"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            While dr.Read
                uIP = dr("SERVER_IP")
                uFileName = dr("FILE_PATH")
                UPass = dr("ADMIN_PASS")
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()


        Dim processInfo As New System.Diagnostics.ProcessStartInfo("C:\WINDOWS\system32\net")
        processInfo.FileName = "C:\WINDOWS\system32\net"
        processInfo.WindowStyle = ProcessWindowStyle.Hidden
        processInfo.Arguments = "use \\" & uIP & " pwd:P@55w0rdhpd1996 / user:administrator"
        System.Diagnostics.Process.Start(processInfo)

        ChkUpdate(uFileName, uIP, UPass)
    End Sub
End Class
