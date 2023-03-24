Imports System.Runtime.InteropServices
Imports AcroPDFLib

Public Class XNTTHN
    Dim MainCn As New ADODB.Connection
    Dim MainRs As New ADODB.Recordset
    Private Sub XNTTHN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SendMessage(TenTextbox.Handle, &H1501, 0, "Tên quan chức")
        SendMessage(UbndTextbox.Handle, &H1501, 0, "Địa phương")
        MainCn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\z.kh\XNTTHN.accdb"
    End Sub
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function

    Private Sub FindButton_Click(sender As Object, e As EventArgs) Handles FindButton.Click
        If MainCn.State = ADODB.ObjectStateEnum.adStateClosed Then MainCn.Open()
        Dim CntString As String = "SELECT * FROM [THÔNG TIN XÁC NHẬN TÌNH TRẠNG HÔN NHÂN] WHERE [NGƯỜI KÝ] LIKE '%" & TenTextbox.Text & "%'" &
                                    "AND [UBND XÃ/PHƯỜNG] LIKE '%" & UbndTextbox.Text & "%'"
        MainRs.Open(CntString, MainCn)

        If MainRs.EOF And MainRs.BOF Then
            InfoLabel.Text = "Không thấy gì"
            Exit Sub
        End If
        InfoLabel.Text = MainRs.Fields("UBND XÃ/PHƯỜNG").Value & " : " & MainRs.Fields("NGƯỜI KÝ").Value &
         " : " & MainRs.Fields("Tệp").Value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            AxAcroPDF1.LoadFile(MainRs.Fields("Tệp").Value)
            AxAcroPDF1.src = MainRs.Fields("Tệp").Value
            AxAcroPDF1.setShowToolbar(False)
            AxAcroPDF1.setView("FitH")
            AxAcroPDF1.setLayoutMode("SinglePage")
            AxAcroPDF1.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub OleDbConectionNew()

    End Sub
End Class