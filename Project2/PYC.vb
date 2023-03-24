Imports System.ComponentModel
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports GemBox.Document
Public Class PYC
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Ten = Trim(TenPYCTextbox.Text)
        Diachi = Trim(DcPYCTextbox.Text)
        Noidung = Trim(NoidungPYCTextbox.Text)
        Sdt = Trim(SdtPYCTextbox.Text)

        Dim printDialog As New PrintDialog() With {.AllowSomePages = True}
        If (printDialog.ShowDialog() = DialogResult.OK) Then

            Dim printerSettings As PrinterSettings = printDialog.PrinterSettings
            printOptions = New PrintOptions()

            ' Set PrintOptions properties based on PrinterSettings properties.
            printOptions.CopyCount = printerSettings.Copies
            printOptions.FromPage = If(printerSettings.FromPage = 0, 0, printerSettings.FromPage - 1)
            printOptions.ToPage = If(printerSettings.ToPage = 0, Integer.MaxValue, printerSettings.ToPage - 1)

            PrinterName = printerSettings.PrinterName

            If BackgroundWorker1.IsBusy <> True Then BackgroundWorker1.RunWorkerAsync()
        End If
        Me.Dispose()
    End Sub
    Dim Ten, Diachi, Noidung, Sdt As String
    Dim PrinterName As String

    Private Sub PYC_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FocusTimer.Start()
    End Sub

    Dim printOptions As PrintOptions

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ComponentInfo.SetLicense("FREE-LIMITED-KEY")
        Dim iGemDoc As DocumentModel = DocumentModel.Load("Z:\z.kh\PYC_BM.docx")
        If Ten <> "" Then iGemDoc.Bookmarks("Ten").GetContent(False).LoadText(Ten, New CharacterFormat() With {
                                                            .FontName = "Times New Roman", .Bold = True})
        If Diachi <> "" Then iGemDoc.Bookmarks("Diachi").GetContent(False).LoadText(Diachi, New CharacterFormat() With {
                                                            .FontName = "Times New Roman"})
        If Sdt <> "" Then iGemDoc.Bookmarks("Sdt").GetContent(False).LoadText(Sdt, New CharacterFormat() With {
                                                            .FontName = "Times New Roman"})
        If Noidung <> "" Then iGemDoc.Bookmarks("Noidung").GetContent(False).LoadText(Noidung, New CharacterFormat() With {
                                                            .FontName = "Times New Roman"})

        iGemDoc.Print(PrinterName, printOptions)
    End Sub

    Private Sub FocusTimer_Tick(sender As Object, e As EventArgs) Handles FocusTimer.Tick
        FocusTimer.Stop()
        NoidungPYCTextbox.Focus()
    End Sub
End Class
