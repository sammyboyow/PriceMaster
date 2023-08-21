Imports System.Data.SqlClient
Imports System.Data.Odbc
Public Class frmSPPrv
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
    Public SELECTED As String = "", MotherBranch As String = "", SPD_IMH_CODE As String = ""
    Public ListPrice As Double
    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        Me.Dispose()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim intIndex As Integer = SearchGrid(txtSearch.Text, 0) 'Change the 0 to what column you want to search for
        d.Rows(intIndex).Selected = True 'This will select the row...'
        d.CurrentCell = d.Rows(intIndex).Cells(0) 'This ensures that the arrow will move if you have row headers visible. In order to select the cell change the zero to the column your searching to match up top
    End Sub
#Region "SUB PROCEDURE/FUNCTION"
    Public Function GetSPH(ByVal SPH_CODE As String) As String
        Dim cn As New OdbcConnection(cnHCLAB)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT SPH_DESC FROM SPLIST_HDR WHERE SPH_CODE = '" & SPH_CODE & "' "
        Dim cmd As New OdbcCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
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
    Public Function GetPrv_Price(ByVal PriceList As String) As String
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT TOP 1 SPD_CURR_PRICE from SPLIST_DTL WHERE WHS_CODE = '" & MotherBranch & "' AND SPD_IMH_CODE = '" & SPD_IMH_CODE & "' AND SPD_CODE IN ('" & PriceList & "') " & _
                            "ORDER BY SPD_EFD DESC"
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
    Public Sub LoadData()
        Dim cn As New SqlConnection(cnSAP)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim cn2 As New SqlConnection(cnSAP)
        If cn2.State = ConnectionState.Closed Then cn2.Open()

        Dim SPL_Price As Double = 0.0
        Dim str As String = "EXEC sp_MotherGrp '" & MotherBranch & "','" & SPD_IMH_CODE & "' "
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        If dr.HasRows Then
            dr.Read()
            str = "SELECT * FROM PriceLvlNew WITH(NOLOCK) WHERE PriceLevel IN (" & SELECTED & ") "
            cmd = New SqlCommand(str, cn2)
            Dim dr1 As SqlDataReader = cmd.ExecuteReader

            Dim i As Integer = 0
            If dr1.HasRows Then
                d.Rows.Clear()
                While dr1.Read
                    If dr("MotherGrp") = "ULTRASOUND" Then
                        SPL_Price = (ListPrice * (1 + dr1("UTZ"))) * (1 + dr1("UTZ2"))
                    ElseIf dr("MotherGrp") = "IMAGING" Then
                        SPL_Price = (ListPrice * (1 + dr1("Imaging"))) * (1 + dr1("Imaging2"))
                    ElseIf dr("MotherGrp") = "SPECIAL TESTS" Then
                        SPL_Price = (ListPrice * (1 + dr1("STest"))) * (1 + dr1("STest2"))
                    Else
                        SPL_Price = (ListPrice * (1 + dr1("Regular"))) * (1 + dr1("Regular2"))
                    End If
                    d.Rows.Add()
                    d("SPD_CODE", i).Value = dr1("PriceList")
                    d("IMH_CODE", i).Value = GetSPH(dr1("PriceList"))
                    d("CURR_PRICE", i).Value = Format(SPL_Price, "N2")
                    d("PREV_PRICE", i).Value = GetPrv_Price(dr1("PriceList"))
                    i += 1
                End While
            Else
                d.Rows.Clear()
            End If
            dr1.Close()
        End If
        dr.Close()
        cn.Dispose()
    End Sub
#End Region

    Private Sub frmSPPrv_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        btnSearch.PerformClick()
    End Sub
End Class