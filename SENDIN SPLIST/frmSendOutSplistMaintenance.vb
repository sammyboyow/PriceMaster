Imports System.Data.SqlClient
Public Class frmSendOutSplistMaintenance

    Private Sub frmSendOutSplistMaintenance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmSendOutSplistMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Load_BranchGrp()
        Load_Source()
        Load_Test()
    End Sub
    Private Sub Load_BranchGrp()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand()
        Dim dr As SqlDataReader
        Dim i As Integer = 0
        str = "SELECT DISTINCT LISGRP FROM SAPSETN WHERE SLSSTAT = 'O'"
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader
        DLISGrp.Rows.Clear()
        If dr.HasRows Then
            While dr.Read
                DLISGrp.Rows.Add()
                DLISGrp("Group", i).Value = dr("LISGRP")
                i += 1
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub
    Private Sub Load_Source()
        Dim cn As New SqlConnection(cnsql)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand()
        Dim dr As SqlDataReader
        Dim i As Integer = 0
        str =
            "SELECT S.DOCENTRY,S.DBCODE,O.U_CardName DBNAME, S.Active " &
            "FROM dbo.SENDIN_SPLIST_SOURCE S " &
            "LEFT JOIN [172.30.0.17].HPCOMMON.DBO.OCRD O ON O.CardCode = S.DBCODE COLLATE DATABASE_DEFAULT " &
            "GROUP BY S.DOCENTRY,S.DBCODE,O.U_CardName ,S.ACTIVE "
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader
        DSource.Rows.Clear()
        If dr.HasRows Then
            While dr.Read
                DSource.Rows.Add()
                DSource("SrcDocentry", i).Value = dr("Docentry")
                DSource("SrcCode", i).Value = dr("DBCODE")
                DSource("SrcName", i).Value = dr("DBNAME")
                DSource("SrcActive", i).Value = dr("Active")
                i += 1
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub
    Private Sub Load_Test()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand()
        Dim dr As SqlDataReader
        Dim i As Integer = 0
        str =
            "SELECT T.DOCENTRY,T.IMH_CODE,H.IMH_DESC " &
            "FROM dbo.SENDIN_SPLIST_TEST T " &
            "LEFT JOIN ( SELECT DISTINCT H.IMH_CODE,MAX(H.IMH_DESC)IMH_DESC " &
            "			FROM [172.30.0.17].HPCOMMON.DBO.ITEM_MASTERH H " &
            "			INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSET S ON S.CODE = H.WHSCODE " &
            "			WHERE S.SlsStat = 'O' " &
            "			GROUP BY H.IMH_CODE) H ON H.IMH_CODE = T.IMH_CODE COLLATE DATABASE_DEFAULT "
        cmd = New SqlCommand(str, cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader
        Dtest.Rows.Clear()
        If dr.HasRows Then
            While dr.Read
                Dtest.Rows.Add()
                Dtest("TstDocentry", i).Value = dr("DOCENTRY")
                Dtest("TstCode", i).Value = dr("IMH_CODE")
                Dtest("TstName", i).Value = dr("IMH_DESC")
                i += 1
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub
End Class