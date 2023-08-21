Imports System.Data.Odbc
Imports System.IO
Imports System.Reflection

Public Class frmSplash
    Dim versionNumber As Version
    Dim i As Integer = 0
    Private Sub frmSplash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblAppName.Text = My.Application.Info.AssemblyName
        versionNumber = Assembly.GetExecutingAssembly().GetName().Version
        Info.Version = versionNumber.Major & "." & versionNumber.Minor & "." & versionNumber.Revision
        lblVersion.Text = "Version:" & versionNumber.Major & "." & versionNumber.Minor & "." & versionNumber.Revision
        GetConnection()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If i = 1 Then
            Me.Hide()
            frmLogin.Show()
            frmLogin.txtUserName.Focus()
        End If
        i += 1
    End Sub
End Class