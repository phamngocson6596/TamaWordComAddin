Imports System.Configuration
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class DsInfomationTable
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Public WithEvents OneCn As New ADODB.Connection
    Public Sub FillTableWithCustomer(ctm As NotaryCustomer)
        GtTextbox.Text = ctm.Gt
        TenTextbox.Text = ctm.Ten
        SnTextbox.Text = ctm.Sn
        CccdTextbox.Text = ctm.CCCD
        CmndTextbox.Text = ctm.CMND
        HcTextbox.Text = ctm.HC
        CmsqTextbox.Text = ctm.CMSQ
        SddcnTextbox.Text = ctm.SDDCN
        TtTextbox.Text = ctm.TT
        IDTextbox.Text = ctm.ID

    End Sub
    Private Sub FillCustomer(ctm As NotaryCustomer)
        ctm.Gt = Trim(GtTextbox.Text.ToString)
        ctm.Ten = Trim(TenTextbox.Text.ToString)
        ctm.Sn = Trim(SnTextbox.Text.ToString)
        ctm.CCCD = Trim(CccdTextbox.Text.ToString)
        ctm.CMND = Trim(CmndTextbox.Text.ToString)
        ctm.HC = Trim(HcTextbox.Text.ToString)
        ctm.CMSQ = Trim(CmsqTextbox.Text.ToString)
        ctm.SDDCN = Trim(SddcnTextbox.Text.ToString)
        ctm.TT = Trim(TtTextbox.Text.ToString)
        ctm.ID = Trim(IDTextbox.Text.ToString)
    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        If IDTextbox.Text <> "" Then
            Call UpdateClick()
            Exit Sub
        End If

        Dim iCustomer As New NotaryCustomer
        FillCustomer(iCustomer)

        If Not iCustomer.IsLegitCustomer Then
            SendMessage(TenTextbox.Handle, &H1501, 0, "Điền: Tên + CMT")
            Me.Parent.Controls("InfoTextbox").Text = "Thất bại!"
            Exit Sub
        End If

        If iCustomer.IsCustomerAvailabled() = True Then
            Me.Parent.Controls("InfoTextbox").Text = "Đã có khách: " & iCustomer.Ten & " trong dữ liệu!"
            Exit Sub
        End If

        Dim insertLine As String = "INSERT INTO [KH (3)] (Gt, Ten, Sn, CCCD, CMND, HC, CMSQ, SDDCN, TT) VALUES ('" _
        & Trim(GtTextbox.Text) & "','" & Trim(TenTextbox.Text) & "','" & Trim(SnTextbox.Text) & "','" _
        & RemoveSpace(CccdTextbox.Text) & "','" & RemoveSpace(CmndTextbox.Text) & "','" & RemoveSpace(HcTextbox.Text) & "','" _
        & RemoveSpace(CmsqTextbox.Text) & "','" & RemoveSpace(SddcnTextbox.Text) & "','" & Trim(TtTextbox.Text) & "')"

        If OneCn.State = ADODB.ObjectStateEnum.adStateClosed Then OneCn.Open()

        OneCn.Execute(insertLine)
        OneCn.Close()
    End Sub
    Private Sub UpdateClick()

        If Trim(TenTextbox.Text) = "" Or (Trim(CccdTextbox.Text) = "" And Trim(CmndTextbox.Text) = "" And Trim(HcTextbox.Text) = "" And Trim(CmsqTextbox.Text) = "" _
        And Trim(SddcnTextbox.Text) = "") Then
            Me.Parent.Controls("InfoTextbox").Text = "Thất bại! Yêu cầu: Tên + CMT"
            Exit Sub
        End If

        Dim iCustomer As NotaryCustomer = Me.Tag
        Dim UpdateString As String = "UPDATE [KH (3)] SET "
        Dim ThongBaoString As String = ""
        Dim SoThayDoi As Byte = 0

        For Each tb As TextBox In DsFrame.Controls.OfType(Of TextBox)()
            If Trim(tb.Text) <> iCustomer.GetPropertyValues(tb.Tag) Then
                UpdateString &= tb.Tag & "='" & tb.Text & "',"
                ThongBaoString &= tb.Tag & ": " & iCustomer.GetPropertyValues(tb.Tag) & "->" & tb.Text & vbCr
                SoThayDoi += 1
            End If
        Next

        If SoThayDoi = 0 Then
            Me.Parent.Controls("InfoTextbox").Text = "Không có thay đổi nào! Nhập thay đổi ở các mục và bấm 'Lưu khách'"
            Exit Sub
        End If

        Dim msg As MsgBoxResult = MsgBox("Cập nhật thông tin khách hàng: " & vbCr & ThongBaoString, vbOKCancel)
        If Not msg = vbOK Then Exit Sub

        UpdateString = Regex.Replace(UpdateString, ",$", "")
        UpdateString &= "WHERE [ID] =" & IDTextbox.Text

        If OneCn.State = ADODB.ObjectStateEnum.adStateClosed Then OneCn.Open()

        OneCn.Execute(UpdateString)
        OneCn.Close()

    End Sub

    Private Sub DsInfomationTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim datalocation As String = ConfigurationManager.AppSettings("DataLocation")
        OneCn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & datalocation

    End Sub

    Private Sub OneCnExecuteCompleted(RecordsAffected As Integer, pError As ADODB.Error,
                                      ByRef adStatus As ADODB.EventStatusEnum, pCommand As ADODB.Command,
                                      pRecordset As ADODB.Recordset, pConnection As ADODB.Connection) Handles OneCn.ExecuteComplete
        If InStr(pCommand.CommandText, "INSERT INTO") > 0 And RecordsAffected = 1 Then
            Me.Parent.Controls("InfoTextbox").Text = "Thành công!"
        End If
        If InStr(pCommand.CommandText, "UPDATE") > 0 And RecordsAffected = 1 Then
            Me.Parent.Controls("InfoTextbox").Text = "Đã cập nhật thành công!"

            Me.Dispose()
        End If

    End Sub

    Private Sub PYCButton_Click(sender As Object, e As EventArgs) Handles PYCButton.Click
        Dim iPYC As Control = New PYC
        iPYC.Controls("TenPYCTextbox").Text = TenTextbox.Text
        iPYC.Controls("DcPYCTextbox").Text = TtTextbox.Text

        Me.Parent.Controls.Add(iPYC)
        iPYC.Dock = DockStyle.Bottom

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

End Class
