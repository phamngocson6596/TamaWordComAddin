Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class MyPanel
    Public WithEvents OneCn As New ADODB.Connection

    Private Sub MyPanel_Load(sender As Object, e As EventArgs) Handles Me.Load

        'https://itsourcecode.com/tutorials/visual-basic-tutorial/connect-access-database-in-vb-net/#h-database-access-in-vb-net
        'https://itsourcecode.com/tutorials/visual-basic-tutorial/regular-expression-in-vb-net/
        'https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
    End Sub


    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function



    'Dim pdfSignLink As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If SignListview.Items.Count = 0 Then Exit Sub

        Dim iYear As String = SignListview.SelectedItems(0).SubItems("SignYear").Text
        Dim files() As String = IO.Directory.GetFiles("Z:\z.kh\SignRegister\SCAN\" & iYear, "*pdf")
        Dim pdfSignLink As String = ""
        For Each item As String In files
            If item.StartsWith(SignListview.SelectedItems(0).SubItems(3).Text.ToString, StringComparison.CurrentCultureIgnoreCase) Then
                pdfSignLink = item
                'SignListbox.Items.Add(item)
            End If
        Next

        FileSystem.FileOpen(1, "Z:\z.kh\SignRegister\SCAN\2022\13-05062022125549.pdf", 1)
        'Dim pdfSignLink As String = "Z:\z.kh\SignRegister\SCAN\" & SignListview.SelectedItems(0).SubItems(2).Text.ToString & "\" & SignListview.SelectedItems(0).SubItems(3).Text.ToString & "*" '& SignListbox.SelectedItem.ToString & ".pdf"
        'IO.File.Open(pdfSignLink, IO.FileMode.Open)
        'If PrintPDFWorker.IsBusy <> True Then PrintPDFWorker.RunWorkerAsync()
        'ThisAddIn.AddinCustomTaskPanes(Globals.ThisAddIn.Application.ActiveDocument).Visible = False
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles PrintPDFWorker.DoWork
        'https://www.gemboxsoftware.com/pdf/free-version
        'ComponentInfo.SetLicense("FREE-LIMITED-KEY")

        'Using document = PdfDocument.Load(pdfSignLink)
        '    document.Print()
        'End Using

    End Sub


    Private Sub SignSearch_TextChanged(sender As Object, e As EventArgs)
        Dim files() As String = IO.Directory.GetFiles("Z:\z.kh\SignatureAuthority", "*pdf")
        If SignSearch.Text = "" Then
            'IO.File.op
        End If
        For Each item As String In files
            If item.StartsWith(SignSearch.Text, StringComparison.CurrentCultureIgnoreCase) Then
                'SignListbox.Items.Add(item)
            End If
        Next
    End Sub

    Private Sub FindBossButton_Click(sender As Object, e As EventArgs) Handles FindBossButton.Click
        Dim iCn As New ADODB.Connection With {
            .ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Z:\z.kh\SignRegister\BankBoss.accdb"}
        iCn.Open()

        Dim iText As String = "SELECT * FROM BankBoss WHERE [NGƯỜI ĐĂNG KÝ] LIKE '%" & SignSearch.Text & "%'"
        Dim iRs As ADODB.Recordset = iCn.Execute(iText)

        SignListview.Items.Clear()

        Do Until iRs.EOF
            SignListview.Items.Add(New ListViewItem({iRs.Fields("NGƯỜI ĐĂNG KÝ").Value, iRs.Fields("TÊN NGÂN HÀNG").Value, iRs.Fields("Năm").Value, iRs.Fields("STT").Value}))
            iRs.MoveNext()
        Loop
        SignListview.Columns.Item(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        SignListview.Columns.Item(1).Width = 0
        SignListview.Columns.Item(2).Width = 0

        iCn.Close()
    End Sub

    Private Sub SignListview_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SignListview.SelectedIndexChanged
        InfoTextbox.ResetText()

        For Each bigitem As ListViewItem In SignListview.SelectedItems
            For Each mini In bigitem.SubItems
                InfoTextbox.Text &= mini.text.ToString & " "
            Next
        Next
    End Sub


    Private Sub TenTextboxFind_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
