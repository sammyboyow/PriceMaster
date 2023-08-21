Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.IO
Module Module1
#Region "CONNECTION STRINGS"
    Public cnONLINE As String = ""
    Public cnHCLAB As String = ""
    Public cnSAP As String = ""
    Public cnSQL As String = ""
    Public cnSQL2 As String = ""
    Public cnORA As String = "USER ID=HCLAB; password=HCLAB; data source= " & _
                             "(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST=192.171.3.103)(PORT = 1521)) " & _
                             "(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME =HCLAB)))"
    Public strsamplecon1 As String = "(DESCRIPTION=(ADDRESS = (PROTOCOL = TCP)(HOST = 192.171.11.100)(PORT = 1521))(CONNECT_DATA =(SID = HCLAB)))"
    Public cnStr As String = "Driver={Microsoft ODBC for Oracle};Server=" & strsamplecon1 & ";UID=HCLAB;PWD=HCLAB"
    Public cnETRS As String = ""
#End Region
#Region "STRUCTURE"
    Public Structure Menu
        Dim cnONLINE As String
        Dim cnSAP As String
        Dim cnSQL As String
    End Structure
    Public Config As New Menu
    Public Structure PInfo
        Dim EmpID As String
        Dim UserName As String
        Dim Version As String
        Dim POSID As String
    End Structure
    Public Info As New PInfo
#End Region
#Region "GLOBAL VARIABLES"
    Public ImgType As String = ""
    Public ProcessName As String = ""
    Public vBranch As String = ""
#End Region
#Region "SUB PROCEDURE/ FUNCTION"
    Public Sub RoundImag()
        Dim gp As New System.Drawing.Drawing2D.GraphicsPath()

        gp.AddEllipse(0, 0, frmMain.pbImg.Width - 3, frmMain.pbImg.Height - 3)
        Dim rg As New Region(gp)
        frmMain.pbImg.Region = rg
        frmMain.pbImg.SizeMode = PictureBoxSizeMode.StretchImage

        gp.AddEllipse(0, 0, frmUserMaint.pbIMG.Width - 3, frmUserMaint.pbIMG.Height - 3)
        frmUserMaint.pbIMG.Region = rg
        frmUserMaint.pbIMG.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub
    Public Sub GetConnection()
        Dim txtpath As String = Application.StartupPath & "\Config.dll"
        Dim i As Integer = 0
        If System.IO.File.Exists(txtpath) Then
            Dim ObjRdr As New System.IO.StreamReader(txtpath)
            Config.cnSQL = ObjRdr.ReadLine()
            Config.cnONLINE = ObjRdr.ReadLine()
            ObjRdr.Close()
            ObjRdr.Dispose()
        End If

        cnONLINE = "DSN=" & Config.cnONLINE & ";UID=HCLAB;PWD=HCLAB;"
        cnHCLAB = "DSN=HCLAB;UID=HCLAB;PWD=HCLAB;"
        cnSQL2 = "Data Source=192.171.11.249;Initial Catalog=PRICEMASTER;Integrated Security=False;UID=sapdb;Pwd=sapdb;Max Pool Size=1000"
        'cnSQL = "Data Source=" & Config.cnSQL & ";Initial Catalog=PRICEMASTER;Integrated Security=False;UID=administrator;Pwd=hiprecision2018;Max Pool Size=1000;connection Timeout = 0"
        cnSQL = "Data Source=" & Config.cnSQL & ";Initial Catalog=PRICEMASTER;Integrated Security=False;UID=admin;Pwd=hiprecision2015;Max Pool Size=1000;connection Timeout = 0"
        cnETRS = "Data Source=172.30.0.95;Initial Catalog=PRICEMASTER;Integrated Security=False;UID=administrator;Pwd=hiprecision2018;Max Pool Size=1000;connection Timeout = 0"
        cnSAP = "Data Source=172.30.0.17;Initial Catalog=HPCOMMON;Integrated Security=False;UID=sapdb;Pwd=sapdb;Max Pool Size=1000"
    End Sub
    Public Function GetCode(ByVal Branch As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT CODE FROM SAPSET WITH(NOLOCK) WHERE BLK = '" & Branch & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        If str Is Nothing Then
            If Branch = "TEST" Then
                Return "011"
            Else
                Return Nothing
            End If
        Else
            Return str
        End If

        cn.Dispose()
    End Function
    Public Function GetPriceLvl(ByVal MotherGrp As String, chk1 As Boolean, chk2 As Boolean, chk3 As Boolean) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT * FROM BscPriceLvl_Master WITH(NOLOCK) WHERE DocEntry = '2' AND MotherWhs ='" & GetCode(MotherGrp) & "'"
        Dim cmd As New SqlCommand(str, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader

        Dim PrcLvl As String = ""
        If dr.HasRows Then
            dr.Read()
            If chk1 = True And chk2 = False And chk3 = False Then
                PrcLvl = "'" & dr("PLVL1") & "'"
            ElseIf chk1 = False And chk2 = True And chk3 = False Then
                PrcLvl = "'" & "PLVL2" & "'"
            ElseIf chk1 = False And chk2 = False And chk3 = True Then
                PrcLvl = "'" & "PLVL3" & "'"
            ElseIf chk1 = True And chk2 = True And chk3 = False Then
                PrcLvl = "'" & dr("PLVL1") & "','" & dr("PLVL2") & "'"
            ElseIf chk1 = True And chk2 = False And chk3 = True Then
                PrcLvl = "'" & dr("PLVL1") & "','" & dr("PLVL3") & "'"
            ElseIf chk1 = False And chk2 = True And chk3 = True Then
                PrcLvl = "'" & dr("PLVL2") & "','" & dr("PLVL3") & "'"
            ElseIf chk1 = True And chk2 = True And chk3 = True Then
                PrcLvl = "'" & dr("PLVL1") & "','" & dr("PLVL2") & dr("PLVL3") & "'"
            Else
                PrcLvl = ""
            End If
        End If
        dr.Close()
        cn.Dispose()
        Return PrcLvl
    End Function
    Public Function GetLISHCLAB(ByVal BLK As String) As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT HcLabIPAdd " & _
                    "FROM SAPSET WITH(NOLOCK) " & _
                    "WHERE BLK = '" & BLK & "' "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str

        cn.Dispose()
    End Function
    Public Function GetBatchID_SPLIST() As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT (ISNULL(MAX(CAST(BATCH_ID AS INT)), 0) + 1) BATCH_ID FROM SPLIST_DTL "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
#End Region
    Public Function GetBatchID_IMH() As String
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT (ISNULL(MAX(BATCH_ID), 0) + 1) BATCH_ID FROM TMP_ITEM_MASTERH "
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar

        Return str
        cn.Dispose()
    End Function
    Public Function GetCurrDT()
        Dim cn As New SqlConnection(cnSQL)
        If cn.State = ConnectionState.Closed Then cn.Open()

        Dim str As String = "SELECT GETDATE()"
        Dim cmd As New SqlCommand(str, cn)
        str = cmd.ExecuteScalar
        cn.Dispose()
        Return str
    End Function
End Module
