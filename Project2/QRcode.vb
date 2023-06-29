Imports System.Drawing
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word
Imports ZXing

Public Class QRcode
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim result As String = QrAnalyzer(TextBox1.Text)
        If result = "Sai định dạng" Then
            Label1.Text = "Sai định dạng"
            Label1.BackColor = Color.MistyRose
        Else
            Label1.Text = "Thành công"
            Label1.BackColor = Color.LightBlue
        End If
    End Sub
    Private Function QrAnalyzer(text As String) As String
        Dim regex As Regex = New Regex("^(?<cccd>\d+)\|(?<cmnd>\d*)\|(?<name>[^|]+)\|\d{4}(?<YoB>\d{4})\|(?<sex>(Nam|Nữ))\|(?<address>[^|]+)\|(?<dateOfIssue>\d+)$")
        Dim match As Match = regex.Match(text.TrimEnd)

        If match.Success Then
            Dim customer As New NotaryCustomer
            customer.CCCD = match.Groups("cccd").Value
            customer.CMND = match.Groups("cmnd").Value
            customer.Ten = match.Groups("name").Value.ToUpper()
            customer.Sn = match.Groups("YoB").Value
            customer.TT = match.Groups("address").Value

            If match.Groups("sex").Value = "Nam" Then
                customer.Gt = "Ông"
            Else
                customer.Gt = "Bà"
            End If

            Dim final As String = customer.ExportCustomer()
            customer = Nothing
            Return final
        Else
            Return "Sai định dạng"
        End If
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Computer.Clipboard.SetText(QrAnalyzer(TextBox1.Text))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim iApp = Globals.ThisAddIn.Application

        Dim iRange As Word.Range = iApp.Selection.Range
        iRange.ParagraphFormat.TabStops.ClearAll()
        iRange.ParagraphFormat.TabStops.Add(Position:=iApp.CentimetersToPoints(5.25), Alignment:=WdAlignmentTabAlignment.wdLeft, Leader:=WdTabLeader.wdTabLeaderSpaces)

        Try
            If Regex.IsMatch(iRange.Text, "\s$") Then iRange.MoveEnd(WdUnits.wdCharacter, -1)
        Catch ex As Exception
        End Try

        If Trim(iRange.Text) = "" Then
            iRange.InsertParagraphAfter()
            iRange.MoveEnd(Word.WdUnits.wdParagraph, -1)
        End If
        iRange.Text = QrAnalyzer(TextBox1.Text)
    End Sub

    Private Sub TextBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TextBox1.MouseDoubleClick
        TextBox1.SelectAll()
    End Sub

    Private Sub TextBox1_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            Dim filePath As String = files(0) ' Assuming only one file is dropped

            ' Read the QR code
            Dim barcodeReader As New BarcodeReader()
            Dim result As Result = barcodeReader.Decode(New Bitmap(filePath))

            If result IsNot Nothing Then
                Dim qrCodeText As String = result.Text
                TextBox1.Text = qrCodeText
            Else
                Label1.Text = "Failed to read QR code"
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim a As New OpenFileDialog
        a.ShowDialog()
        Dim filePath = a.FileName.ToString()
        Dim barcodeReader As New BarcodeReader()
        Dim result As Result = barcodeReader.Decode(New Bitmap(filePath))

        If result IsNot Nothing Then
            Dim qrCodeText As String = result.Text
            TextBox1.Text = qrCodeText
            Label1.Text = "Thành công"
            Label1.BackColor = Color.LightBlue
        Else
            Label1.Text = "Failed to read QR code"
            Label1.BackColor = Color.MistyRose
        End If

    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_DragDrop(sender As Object, e As DragEventArgs)
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim files As String() = CType(e.Data.GetData(DataFormats.FileDrop), String())
            Dim filePath As String = files(0) ' Assuming only one file is dropped

            ' Display the dragged image
            'PictureBox1.Image = Image.FromFile(filePath)

            ' Read the QR code
            Dim barcodeReader As New BarcodeReader()
            'Dim result As Result = barcodeReader.Decode(DirectCast(PictureBox1.Image, Bitmap))

            'If result IsNot Nothing Then
            'Dim qrCodeText As String = result.Text
            'Label1.Text = qrCodeText
            'Else
            'Label1.Text = "Failed to read QR code"
            'End If
        End If
    End Sub
End Class