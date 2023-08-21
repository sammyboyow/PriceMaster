Imports System.Data.SqlClient
Imports System.Data.Odbc
Public Class frmGenExcept
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
    Public Sub loadBranch()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT CODE, BLK, HCLABIPADD FROM SAPSet " & _
                            "WHERE STAT = 'O' AND HCLABIPADD IS NOT NULL AND HCLABIPADD <> '0' " & _
                            "ORDER BY BLK"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            cbBranch.Items.Clear()
            cbBranch.Items.Add("")
            While dr.Read
                cbBranch.Items.Add(dr("BLK"))
            End While
        End If
        dr.Close()
        cn.Dispose()

    End Sub
    Public Sub LoadSPLIST()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT PriceList, PriceList_Desc FROM Price_Level_Dtl " & _
                            "ORDER BY PriceList, PriceList_Desc"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim c As New AutoCompleteStringCollection()
        If dr.HasRows Then
            c.Clear()
            c.Add("")
            While dr.Read
                c.Add(dr("PriceList"))
                c.Add(dr("PriceList_Desc"))
            End While
        End If
        dr.Close()

        txtSPDCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtSPDCode.AutoCompleteSource = AutoCompleteSource.CustomSource
        txtSPDCode.AutoCompleteCustomSource = c

    End Sub
    Public Function GetIPADD(BLK As String) As String
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT hclabIPADD FROM SAPSET WHERE BLK = '" & BLK & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
#End Region
#Region "STRUNCTURES / ENUMS"
    Public Structure Basic_Computation
        Dim Price_Level As String
        Dim Reg_1 As String
        Dim Reg_2 As String
        Dim Imag_1 As String
        Dim Imag_2 As String
        Dim SP_1 As String
        Dim SP_2 As String
        Dim UTZ_1 As String
        Dim UTZ_2 As String
    End Structure
    Dim Computations As New Basic_Computation
#End Region
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim cn As New SqlConnection(cnSQL)

    End Sub

    Private Sub frmGenExcept_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadBranch()
        LoadSPLIST()
    End Sub

    Private Sub txtSPDCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSPDCode.KeyDown
        If e.KeyCode = Keys.Return Then
            Dim cn As New SqlConnection(cnSQL)
            If cn.State = ConnectionState.Closed Then cn.Open()

            Dim str As String = "SELECT PriceList, PriceList_Desc FROM Price_Level_Dtl WHERE PriceList = '" & Replace(txtSPDCode.Text, "'", "''") & "' "
            Dim cmd As New SqlCommand(str, cn)
            Dim dr As SqlDataReader = cmd.ExecuteReader

            If dr.HasRows Then
                txtSPDCode.Text = ""
                txtSPDDesc.Text = ""
                While dr.Read
                    txtSPDCode.Text = dr("PriceList")
                    txtSPDDesc.Text = dr("PriceList_Desc")
                End While
            End If
            dr.Close()
            cn.Dispose()
        End If
    End Sub

    Private Sub txtSPDCode_TextChanged(sender As Object, e As EventArgs) Handles txtSPDCode.TextChanged
        If txtSPDCode.Text = "" Then
            txtSPDDesc.Text = ""
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim cn As New OdbcConnection(Replace(cnStr, "192.171.11.100", GetIPADD(cbBranch.Text)))
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSQL)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim str As String = "", PriceLevel As String = "", TEST_GRP As String = "", SUB_TOTAL As String = "", SUM_TOTAL As String = ""
        Dim cmd As New OdbcCommand
        Dim cmd2 As New SqlCommand
        Dim dr As SqlDataReader
        Dim dr2 As OdbcDataReader

        d.Rows.Clear()

        str = "SELECT PriceLevel, Regular_1, Regular_2, Special_1, Special_2, Imaging_1, Imaging_2, UTZ_1, UTZ_2 FROM Price_Level_Dtl WITH(NOLOCK) WHERE PRICELIST = '" & txtSPDCode.Text & "' "
        cmd2 = New SqlCommand(str, cn2)
        dr = cmd2.ExecuteReader

        If dr.HasRows Then
            dr.Read()
            Computations.Price_Level = dr("PriceLevel")
            Computations.Reg_1 = dr("Regular_1")
            Computations.Reg_2 = dr("Regular_2")
            Computations.SP_1 = dr("Special_1")
            Computations.SP_2 = dr("Special_2")
            Computations.Imag_1 = dr("Imaging_1")
            Computations.Imag_2 = dr("Imaging_2")
            Computations.UTZ_1 = dr("UTZ_1")
            Computations.UTZ_2 = dr("UTZ_2")
        End If
        dr.Close()

        str = "SELECT A.SPD_CODE, A.SPD_IMH_CODE, A.SPD_CURR_PRICE, B.SPD_CODE, B.SPD_IMH_CODE, B.SPD_CURR_PRICE AS SPD_CURR_PRICE_1 " & _
            "FROM (SELECT * " & _
            "        FROM SPLIST_DTL " & _
            "      WHERE SPD_CODE = '" & Computations.Price_Level & "' " & _
            "      ) A " & _
            "Left Join " & _
            "      (SELECT * " & _
            "        FROM SPLIST_DTL " & _
            "       WHERE SPD_CODE = '" & txtSPDCode.Text & "' " & _
            "      ) B ON A.SPD_IMH_CODE = B.SPD_IMH_CODE " & _
            "WHERE B.SPD_CODE IS NOT NULL"
        cmd = New OdbcCommand(str, cn)
        dr2 = cmd.ExecuteReader

        If dr2.HasRows Then
            While dr2.Read
                str = "EXEC sp_GetTestGrp '" & dr2("SPD_IMH_CODE") & "' "
                cmd2 = New SqlCommand(str, cn2)
                TEST_GRP = cmd2.ExecuteScalar

                If TEST_GRP = "IMAGING" Then
                    SUB_TOTAL = dr2("SPD_CURR_PRICE") + (dr2("SPD_CURR_PRICE") * CDbl(Computations.Imag_1))
                    SUM_TOTAL = SUB_TOTAL + (SUB_TOTAL * CDbl(Computations.Imag_2))
                ElseIf TEST_GRP = "ULTRASOUND" Then
                    SUB_TOTAL = dr2("SPD_CURR_PRICE") + (dr2("SPD_CURR_PRICE") * CDbl(Computations.UTZ_1))
                    SUM_TOTAL = SUB_TOTAL + (SUB_TOTAL * CDbl(Computations.UTZ_2))
                ElseIf TEST_GRP = "SPECIAL TESTS" Then
                    SUB_TOTAL = dr2("SPD_CURR_PRICE") + (dr2("SPD_CURR_PRICE") * CDbl(Computations.SP_1))
                    SUM_TOTAL = SUB_TOTAL + (SUB_TOTAL * CDbl(Computations.SP_2))
                Else
                    SUB_TOTAL = dr2("SPD_CURR_PRICE") + (dr2("SPD_CURR_PRICE") * CDbl(Computations.Reg_1))
                    SUM_TOTAL = SUB_TOTAL + (SUB_TOTAL * CDbl(Computations.Reg_2))
                End If

                If (CDbl(SUM_TOTAL) < dr2("SPD_CURR_PRICE_1")) Or (CDbl(SUM_TOTAL) > dr2("SPD_CURR_PRICE_1")) Then
                    Dim CurrRow As Integer = d.Rows.Count
                    d.Rows.Add()
                    d("ITEM_CODE", CurrRow).Value = dr2("SPD_IMH_CODE")
                    d("BASIC_PRICE", CurrRow).Value = dr2("SPD_CURR_PRICE")
                    d("CURR_PRICE", CurrRow).Value = dr2("SPD_CURR_PRICE_1")
                    d("DISC_PRICE", CurrRow).Value = Format(CDbl(SUM_TOTAL), "N2")
                End If
            End While
        End If
        dr2.Close()
        cn.Dispose()
        cn2.Dispose()
    End Sub
End Class