﻿Public Class Impersonator
    Private _username As String
    Private _password As String
    Private _domainname As String

    Private _tokenHandle As New IntPtr(0)
    Private _dupeTokenHandle As New IntPtr(0)
    Private _impersonatedUser As System.Security.Principal.WindowsImpersonationContext

#Region "Constructor"
    Public Sub New(ByVal username As String, _
                           ByVal password As String)
        Dim nameparts() As String = username.Split(Convert.ToChar("\"))
        If nameparts.Length > 1 Then
            _domainname = nameparts(0)
            _username = nameparts(1)
        Else
            _username = username
        End If
        _password = password
    End Sub

    Public Sub New(ByVal username As String, _
                           ByVal password As String, _
                           ByVal domainname As String)
        _username = username
        _password = password
        _domainname = domainname
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property username() As String
        Get
            Return _username
        End Get
    End Property

    Public ReadOnly Property domainname() As String
        Get
            Return _domainname
        End Get
    End Property

    Public ReadOnly Property currentWindowsUsername() As String
        Get
            Return System.Security.Principal.WindowsIdentity.GetCurrent().Name
        End Get
    End Property
#End Region

#Region "Impersonation"
    Public Sub BeginImpersonation()
        'Const LOGON32_PROVIDER_DEFAULT As Integer = 0
        'Const LOGON32_LOGON_INTERACTIVE As Integer = 2
        Const LOGON32_LOGON_NEW_CREDENTIALS As Integer = 9
        Const LOGON32_PROVIDER_WINNT50 As Integer = 3
        Const SecurityImpersonation As Integer = 2

        Dim win32ErrorNumber As Integer

        _tokenHandle = IntPtr.Zero
        _dupeTokenHandle = IntPtr.Zero

        If Not LogonUser(_username, _domainname, _password, LOGON32_LOGON_NEW_CREDENTIALS, LOGON32_PROVIDER_WINNT50, _tokenHandle) Then
            win32ErrorNumber = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
            Throw New ImpersonationException(win32ErrorNumber, GetErrorMessage(win32ErrorNumber), _username, _domainname)
        End If

        If Not DuplicateToken(_tokenHandle, SecurityImpersonation, _dupeTokenHandle) Then
            win32ErrorNumber = System.Runtime.InteropServices.Marshal.GetLastWin32Error()

            CloseHandle(_tokenHandle)
            Throw New ImpersonationException(win32ErrorNumber, "Unable to duplicate token!", _username, _domainname)
        End If

        Dim newId As New System.Security.Principal.WindowsIdentity(_dupeTokenHandle)
        _impersonatedUser = newId.Impersonate()
    End Sub

    Public Sub EndImpersonation()
        If Not _impersonatedUser Is Nothing Then
            _impersonatedUser.Undo()
            _impersonatedUser = Nothing

            If Not System.IntPtr.op_Equality(_tokenHandle, IntPtr.Zero) Then
                CloseHandle(_tokenHandle)
            End If
            If Not System.IntPtr.op_Equality(_dupeTokenHandle, IntPtr.Zero) Then
                CloseHandle(_dupeTokenHandle)
            End If
        End If
    End Sub
#End Region

#Region "Exception Class"
    Public Class ImpersonationException
        Inherits System.Exception

        Public ReadOnly win32ErrorNumber As Integer

        Public Sub New(ByVal win32ErrorNumber As Integer, ByVal msg As String, ByVal username As String, ByVal domainname As String)
            MyBase.New(String.Format("Impersonation of {1}\{0} failed! [{2}] {3}", username, domainname, win32ErrorNumber, msg))
            Me.win32ErrorNumber = win32ErrorNumber
        End Sub
    End Class
#End Region

#Region "External Declarations and Helpers"
    Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String], _
                  ByVal lpszDomain As [String], ByVal lpszPassword As [String], _
                  ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer, _
                  ByRef phToken As IntPtr) As Boolean


    Private Declare Auto Function DuplicateToken Lib "advapi32.dll" (ByVal ExistingTokenHandle As IntPtr, _
                        ByVal SECURITY_IMPERSONATION_LEVEL As Integer, _
                        ByRef DuplicateTokenHandle As IntPtr) As Boolean


    Private Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Boolean

    <System.Runtime.InteropServices.DllImport("kernel32.dll")> _
    Private Shared Function FormatMessage(ByVal dwFlags As Integer, ByRef lpSource As IntPtr, _
                ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByRef lpBuffer As [String], _
                ByVal nSize As Integer, ByRef Arguments As IntPtr) As Integer
    End Function

    Private Function GetErrorMessage(ByVal errorCode As Integer) As String
        Dim FORMAT_MESSAGE_ALLOCATE_BUFFER As Integer = &H100
        Dim FORMAT_MESSAGE_IGNORE_INSERTS As Integer = &H200
        Dim FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000

        Dim messageSize As Integer = 255
        Dim lpMsgBuf As String = ""
        Dim dwFlags As Integer = FORMAT_MESSAGE_ALLOCATE_BUFFER Or FORMAT_MESSAGE_FROM_SYSTEM Or FORMAT_MESSAGE_IGNORE_INSERTS

        Dim ptrlpSource As IntPtr = IntPtr.Zero
        Dim prtArguments As IntPtr = IntPtr.Zero

        Dim retVal As Integer = FormatMessage(dwFlags, ptrlpSource, errorCode, 0, lpMsgBuf, messageSize, prtArguments)
        If 0 = retVal Then
            Throw New System.Exception("Failed to format message for error code " + errorCode.ToString() + ". ")
        End If

        Return lpMsgBuf
    End Function

#End Region

End Class
