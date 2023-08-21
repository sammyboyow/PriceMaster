Imports System.Data.SqlClient
Public Class frmSelectBasicPrice

    Public dgv As DataGridView

    Private Sub frmSelectBasicPrice_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmSelectBasicPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpEfd.Value = GetCurrDT()
        load_basicpricelist()
    End Sub
    Sub load_basicpricelist()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String =
                "SELECT D.PriceLevel, D.PriceList_Desc " & _
                "FROM dbo.Price_Level_Hdr H " & _
                "INNER JOIN dbo.Price_Level_Dtl D ON D.PriceLevel = H.Price_Level1 OR D.PriceLevel = H.Price_Level2 OR D.PriceLevel = H.Price_Level3 " & _
                "INNER JOIN [172.30.0.17].HPCOMMON.DBO.SAPSet S ON S.Code = H.Mother_Code COLLATE DATABASE_DEFAULT " & _
                "WHERE H.PriceType = 'N' AND S.STAT = 'O' AND S.SlsStat = 'O' AND D.PriceLevel = D.PriceList " & _
                "GROUP BY D.PriceLevel, D.PriceList_Desc " & _
                "ORDER BY 1 "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        Dim i As Integer = 0
        D.Rows.Clear()
        If dr.HasRows Then
            While dr.Read()
                D.Rows.Add()
                D("BasicPricelvl", i).Value = dr("PriceLevel")
                D("Description", i).Value = dr("PriceList_Desc")
                i += 1
            End While
        End If
        dr.Close()
        cmd.Dispose()
        cn.Dispose()
    End Sub

    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        If D.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To D.Rows.Count - 1
            D("Chk", i).Value = ChkAll.Checked
        Next
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        CheckForIllegalCrossThreadCalls = False
        If Not BW1.IsBusy Then BW1.RunWorkerAsync()
        pbBW.Visible = True

       
    End Sub
    Sub InsertPLvl()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()
        Dim str As String = ""
        Dim cmd As New SqlCommand
        Dim bscpricelvl As String = ""
        Dim test As String = ""
        Dim spbid As Integer = 0
        Dim imhbid As Integer = 0

        spbid = GetBatchID_SPLIST()
        imhbid = GetBatchID_IMH()
        'BASIC PRICE LEVEL
        For i As Integer = 0 To D.Rows.Count - 1
            If D("Chk", i).Value = True Then
                If bscpricelvl = "" Then
                    bscpricelvl = "'" & D("BasicPriceLvl", i).Value & "'"
                Else
                    bscpricelvl += ",'" & D("BasicPriceLvl", i).Value & "'"
                End If
            End If
        Next
        'TEST AND PRICE

        'Dim EE As String = frmBasicPriceLvl.D.Rows.Count
        'For i As Integer = 0 To frmBasicPriceLvl.D.Rows.Count - 1
        '    If frmBasicPriceLvl.D("Chk", i).Value = True Then
        '        If test = "" Then
        '            test = "'" & frmBasicPriceLvl.D("IMH_CODE", i).Value & "'"
        '        Else
        '            test += test & ",'" & frmBasicPriceLvl.D("IMH_CODE", i).Value & "'"
        '        End If
        '    End If
        'Next

        For i As Integer = 0 To dgv.Rows.Count - 1
            If dgv("Chk", i).Value = True Then
                If test = "" Then
                    test = "'" & dgv("IMH_CODE", i).Value & "'"
                Else
                    test += test & ",'" & dgv("IMH_CODE", i).Value & "'"
                End If
            End If
        Next
        'INSERT INTO TEMP TABLE BEFORE GENERATION.
        Try
            str = "BEGIN TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()

            str = "TRUNCATE TABLE TMPPrice_Level_Dtl"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()

            str = "TRUNCATE TABLE TMPBASIC_PRICE_LVL"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()

            str = "INSERT INTO TMPPrice_Level_Dtl (PriceLevel,PriceList,PriceList_Desc,Regular_1,Regular_2,Special_1,Special_2,Imaging_1,Imaging_2,UTZ_1,UTZ_2,IS_SENIOR)" & _
                "SELECT PriceLevel,PriceList,PriceList_Desc,Regular_1,Regular_2,Special_1,Special_2,Imaging_1,Imaging_2,UTZ_1,UTZ_2,IS_SENIOR " & _
                "FROM Price_Level_Dtl WHERE PriceLevel in (" & bscpricelvl & ")"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()

            str = "INSERT INTO TMPBASIC_PRICE_LVL (IMH_CODE,IMH_DESC,PRICE_LEVEL,PRICE)" & _
               "SELECT IMH_CODE,IMH_DESC,PRICE_LEVEL,PRICE " & _
               "FROM BASIC_PRICE_LVL_TEMPLATE WHERE Price_Level in (" & bscpricelvl & ") AND IMH_CODE IN (" & test & ")"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()


            str =
                "EXEC CREATE_IMH '" & Info.POSID & "', '" & dtpEfd.Value & "', '" & imhbid & "'"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()

            str =
                "EXEC CREATE_SPLIST '" & Info.POSID & "', '" & dtpEfd.Value & "', '" & spbid & "'"
            cmd = New SqlCommand(str, cn)
            cmd.CommandTimeout = 0
            cmd.ExecuteNonQuery()
            str = "COMMIT TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            str = "IF @@TRANCOUNT > 0 ROLLBACK TRAN"
            cmd = New SqlCommand(str, cn)
            cmd.ExecuteNonQuery()
            MsgBox("Error encountered upon generation : " & ex.Message, MsgBoxStyle.Critical)
        End Try

        cmd.Dispose()
        cn.Dispose()
        pbBW.Visible = False
        MsgBox("Done", MsgBoxStyle.Information)
    End Sub

    Private Sub BW1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BW1.DoWork
        Dim Cnt As Integer = 0
        If D.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To D.Rows.Count - 1
            If D("Chk", i).Value = True Then
                Cnt = 1
                Exit For
            End If
        Next
        If Cnt = 0 Then MsgBox("No selected Basic Price Level in list!") : Exit Sub
        InsertPLvl()


    End Sub
End Class