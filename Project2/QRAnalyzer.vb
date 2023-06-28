Imports System.Text.RegularExpressions
Imports System
Imports Microsoft.Office.Interop.Word

Module Program
    Sub Main()
        Dim sampleValue As String = "051089011148|025729879|Phạm Huỳnh Trung|29101989|Nam|441/53 Điện Biên Phủ, Phường 25, Bình Thạnh, TP.Hồ Chí Minh|27122021"

        Dim pattern As String = "^(?<cccd>\d+)\|(?<cmnd>\d+)\|(?<name>[^|]+)\|(?<YoB>\d+)\|(Nam|Nữ)\|(?<address>[^|]+)\|(?<dateOfIssue>\d+)$"
        Dim regex As Regex = New Regex(pattern)
        Dim match As Match = regex.Match(sampleValue)

        If match.Success Then
            Dim cccd As String = match.Groups("cccd").Value
            Dim cmnd As String = match.Groups("cmnd").Value
            Dim name As String = match.Groups("name").Value
            Dim YoB As String = match.Groups("YoB").Value
            Dim sex As String = match.Groups(5).Value
            Dim address As String = match.Groups("address").Value
            Dim dateOfIssue As String = match.Groups("dateOfIssue").Value

            Console.WriteLine($"CCCD: {cccd}")
            Console.WriteLine($"CMND: {cmnd}")
            Console.WriteLine($"Name: {name}")
            Console.WriteLine($"Year of Birth: {YoB}")
            Console.WriteLine($"Sex: {sex}")
            Console.WriteLine($"Address: {address}")
            Console.WriteLine($"Date of Issue: {dateOfIssue}")
        Else
            Console.WriteLine("No match found.")
        End If
    End Sub
End Module

Public Class QRAnalyzer
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim result As String = QrAnalyzer(TextBox1.Text)
        If result = "Sai định dạng" Then
            Label1.Text = "Sai định dạng"
        Else
            Label1.Text = "Thành công"
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
End Class