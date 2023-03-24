Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Public Class SotoSotrang
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles SotoTextbox.TextChanged
        If iTrangEnter = 1 Then Exit Sub
        SotrangTextbox.Text = SotoTextbox.Text
    End Sub
    Private iTrangEnter As Byte
    Private Sub SotoTextbox_Enter(sender As Object, e As EventArgs) Handles SotrangTextbox.Enter, TextBox1.Enter
        iTrangEnter = 1
    End Sub

    Private Sub SotoTextbox_Leave(sender As Object, e As EventArgs) Handles SotoTextbox.Leave, SotrangTextbox.Leave, TextBox1.Leave
        If Len(sender.Text) = 1 Then sender.Text = "0" & sender.Text
    End Sub

    Private Sub SotrangTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles SotrangTextbox.KeyPress, SotoTextbox.KeyPress, TextBox1.KeyPress
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Call Run()
    End Sub

    Private Sub SotoTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles SotoTextbox.KeyDown, SotrangTextbox.KeyDown, CheckBox1.KeyDown, NumericUpDown1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.SuppressKeyPress = True
                Call Run()
        End Select
    End Sub
    Private Sub Run()
        Dim iSoto As String = Trim(NumtoStr(SotoTextbox.Text))
        Dim iSotrang As String = Trim(NumtoStr(SotrangTextbox.Text))
        If Len(SotoTextbox.Text) = 1 Then SotoTextbox.Text = "0" & SotoTextbox.Text
        If Len(SotrangTextbox.Text) = 1 Then SotrangTextbox.Text = "0" & SotrangTextbox.Text
        Dim iSotoSotrang As String = SotoTextbox.Text & " (" & iSoto & ") tờ, " & SotrangTextbox.Text & " (" & iSotrang & ") trang"

        Dim iDem As Integer = SearchDocForPattern("Văn bản.*lập.thành.*\(.*\).*\(.*\).*\(.*\).*lưu")
        Dim iRange As Word.Range = Globals.ThisAddIn.Application.Selection.Range
        iRange.MoveEnd(Word.WdUnits.wdCharacter, -1)
        If iDem <> 0 Then iRange.Text = Regex.Replace(iRange.Text, "(?<=gồm )\d.*?trang", iSotoSotrang)

        If CheckBox1.Checked Then
            Dim ActiveDocument As Word.Document = Globals.ThisAddIn.Application.ActiveDocument
            With ActiveDocument.Sections(1).Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).PageNumbers
                .NumberStyle = Word.WdPageNumberStyle.wdPageNumberStyleArabic
                .IncludeChapterNumber = False
                .RestartNumberingAtSection = True
                .StartingNumber = NumericUpDown1.Value
                .Add(PageNumberAlignment:=Word.WdPageNumberAlignment.wdAlignPageNumberRight, FirstPage:=True)
            End With
        End If

        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.Height = 170
        Else
            Me.Height = 140
        End If
    End Sub

    Private Sub SotrangTextbox_TextChanged(sender As Object, e As EventArgs) Handles SotrangTextbox.TextChanged
        NumericUpDown1.Value = Integer.Parse(SotrangTextbox.Text)
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        TextBox1.Text = NumericUpDown1.Value
    End Sub

    Private Sub SotoSotrang_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class