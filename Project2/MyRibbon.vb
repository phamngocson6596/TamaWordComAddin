Imports System.Windows.Forms
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Tools.Ribbon
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Diagnostics

Public Class MyRibbon
    Dim iApp As Word.Application
    Dim WithEvents iTaskpanel As Microsoft.Office.Tools.CustomTaskPane
    Private Sub MyRibbon_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load

        iApp = Globals.ThisAddIn.Application
    End Sub

    Private Sub PageNumButton_Click(sender As Object, e As RibbonControlEventArgs) Handles PageNumButton.Click
        If Not IsLicenseValid() Then Exit Sub

        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Đánh số trang")

        Dim DefaultNumbering As Integer = 1
        Dim Activedocument = iApp.ActiveDocument
        iApp.ScreenUpdating = False

        With Activedocument.Sections.First.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).PageNumbers
            .NumberStyle = Word.WdPageNumberStyle.wdPageNumberStyleArabic
            .IncludeChapterNumber = False
            .RestartNumberingAtSection = True
            .StartingNumber = DefaultNumbering
            .Add(PageNumberAlignment:=Word.WdPageNumberAlignment.wdAlignPageNumberRight, FirstPage:=True)
        End With

        With Activedocument.Sections.Last.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).PageNumbers
            .Add(PageNumberAlignment:=Word.WdPageNumberAlignment.wdAlignPageNumberRight, FirstPage:=True)
        End With

        With iApp.Selection.PageSetup
            .HeaderDistance = iApp.CentimetersToPoints(0.8)
            .FooterDistance = iApp.CentimetersToPoints(0.8)
        End With

        iApp.ScreenUpdating = True
        objUndo.EndCustomRecord()

    End Sub

    Private Sub DayMonthButton2_Click(sender As Object, e As RibbonControlEventArgs) Handles DayMonthButton2.Click, DayMonthButton.Click
        If Not IsLicenseValid() Then Exit Sub

        On Error Resume Next
        iApp.ScreenUpdating = False

        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Ngày tháng tự động")

        Dim iselection = iApp.Selection
        iselection.TypeText(Text:="ngày ")
        iselection.Fields.Add(iselection.Range, Word.WdFieldType.wdFieldEmpty, "DATE  \@ ""dd"" ", True)
        iselection.TypeText(Text:=" tháng ")
        iselection.Fields.Add(iselection.Range, Word.WdFieldType.wdFieldEmpty, "DATE  \@ ""MM"" ", True)
        iselection.TypeText(Text:=" năm ")
        iselection.Fields.Add(iselection.Range, Word.WdFieldType.wdFieldEmpty, "DATE  \@ ""yyyy"" ", True)

        objUndo.EndCustomRecord()

        iApp.ScreenUpdating = True

    End Sub

    Private Sub DayMonthButton1_Click(sender As Object, e As RibbonControlEventArgs) Handles DayMonthButton1.Click

        If Not IsLicenseValid() Then Exit Sub

        On Error Resume Next

        iApp.ScreenUpdating = False
        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Ngày tháng tự động")

        Dim iselection = iApp.Selection
        iselection.Fields.Add(iselection.Range, Word.WdFieldType.wdFieldEmpty, "DATE  \@ ""dd/MM/yyyy"" ", True)

        objUndo.EndCustomRecord()
        iApp.ScreenUpdating = True

    End Sub
    Private Sub MoneyButton_Click(sender As Object, e As RibbonControlEventArgs) Handles MoneyButton.Click
        If Not IsLicenseValid() Then Exit Sub

        Dim iRange = iApp.Selection.Range
        Dim iText = iRange.Text
        If iText = "" Then
            Dim messageNow = MsgBox("Chưa chọn cái gì mà đã bấm lung tung!")
            Exit Sub
        End If
        Dim onlyNum As String = Regex.Replace(iText, "\D+", "")
        If onlyNum = "" Then
            Dim messageMore = MsgBox("Chọn chỗ nào có phần số ấy!")
            Exit Sub
        End If
        Dim MoneyText As String = NumtoStr(onlyNum) & " đồng"
        MoneyText = Replace(MoneyText, Left(MoneyText, 1), UCase(Left(MoneyText, 1)), Count:=1)

        My.Computer.Clipboard.SetText(MoneyText)

    End Sub
    Private Sub dienNgay(dateToReplace As String)
        If Not IsLicenseValid() Then Exit Sub

        Dim iDoc = iApp.ActiveDocument
        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Ngày lời chứng")

        Dim soluongdem = SearchDocForPattern("^Hôm nay.*\(ngày.*?tháng.*?năm.*?\)")
        If soluongdem = 1 Then
            Dim iRange As Word.Range = iApp.Selection.Range
            iRange.Find.Execute(FindText:="Hôm nay*\)", ReplaceWith:=dateToReplace, Forward:=False, MatchWildcards:=True)
        Else
            Dim imessage = MsgBox("Không định vị được chính xác vị trí, ngày tháng đã được lưu vào bộ nhớ tạm, bấm Ctrl+V để dán.")
            My.Computer.Clipboard.SetText(dateToReplace)
        End If

        objUndo.EndCustomRecord()

    End Sub
    Private Sub NgayloichungButton_Click(sender As Object, e As RibbonControlEventArgs) Handles NgayloichungButton.Click

        Dim thang As String = NumtoStr(Month(Today))
        Dim nam As String = NumtoStr(Year(Today))
        Dim ngay As String = NumtoStr(DateAndTime.Day(Today))
        Dim ngaythanghomnay As String = $"Hôm nay, ngày {DateAndTime.Today.ToString("dd/MM/yyyy")} (ngày {Trim(ngay)}, tháng {Trim(thang)}, năm {Trim(nam)})"

        Call dienNgay(ngaythanghomnay)

    End Sub
    Private Sub SoQuyenButton_Click(sender As Object, e As RibbonControlEventArgs) Handles SoQuyenButton.Click
        If Not IsLicenseValid() Then Exit Sub

        Dim iDoc = iApp.ActiveDocument
        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Điền số quyển")

        Dim soluongdem = SearchDocForPattern("TP/CC-SCC/HĐGD")
        If soluongdem = 1 Then
            Dim iRange As Word.Range = iApp.Selection.Range
            Dim isoquyen As String = $"quyển số {Month(Today)}/{Year(Today)} TP/CC-SCC/HĐGD"
            iRange.Find.Execute(FindText:="quyển số*GD", ReplaceWith:=isoquyen, Forward:=False, MatchWildcards:=True)
        Else
        End If
        objUndo.EndCustomRecord()

    End Sub
    Function OneLineDS(rng As Word.Range) As String
        Dim bigOne As String = ""
        For Each tempPara In rng.Paragraphs
            bigOne &= Trim(Regex.Replace(tempPara.range.text, "\s$|\t|(?<=;)\s|(?<=:)\s|\s+(?=:)", "")) & ";"
        Next
        Return bigOne
    End Function

    Private Sub DsFindButton_Click(sender As Object, e As RibbonControlEventArgs) Handles DsFindButton.Click
        If Not IsLicenseValid() Then Exit Sub

        Call DeleteTaskPanel(iApp.ActiveDocument)
        Call ShowTaskpanel(iApp.ActiveDocument)
        Dim NewCustomTaskPane As Microsoft.Office.Tools.CustomTaskPane = ThisAddIn.AddinCustomTaskPanes(iApp.ActiveDocument)

        Dim iPanel As Control = New DsFind With {
            .Left = 3, .Top = 8}

        NewCustomTaskPane.Control.Controls.Add(iPanel)

    End Sub

    Private Sub DsAnalyzeButton_Click(sender As Object, e As RibbonControlEventArgs) Handles DsAnalyzeButton.Click
        If Not IsLicenseValid() Then Exit Sub

        Dim iRange As Word.Range = iApp.Selection.Range
        Dim iTextFull As String = OneLineDS(iRange)
        Dim iText0space As String = RemoveSpace(iTextFull)

        Call DeleteTaskPanel(iApp.ActiveDocument)
        Call ShowTaskpanel(iApp.ActiveDocument)
        Dim NewCustomTaskPane As Microsoft.Office.Tools.CustomTaskPane = ThisAddIn.AddinCustomTaskPanes(iApp.ActiveDocument)

        Dim iPanel As Control = New DsInfomationTable With {
            .Left = 3, .Top = 8}

        With iPanel.Controls("DsFrame").Controls
            Dim gioitinh As String = Regex.Match(iText0space, "Ông(?=:)|Bà(?=:)|Trẻ|Ông/Bà|(?<=Do|Hoặc|là|và)(Ông|Bà)", RegexOptions.IgnoreCase).Value
            .Item("GtTextbox").Text = gioitinh
            If gioitinh = "" Then Exit Sub
            .Item("TenTextbox").Text = Regex.Match(iTextFull, "(?<=" & gioitinh & ".*?:).*?(?=;|,)").Value
            .Item("SnTextbox").Text = Regex.Match(iText0space, "(?<=(sinh|năm)(ngày)?:).*?(?=;|,)", RegexOptions.IgnoreCase).Value
            .Item("CccdTextbox").Text = Regex.Match(iText0space, "(?<=:)\d{12}(?=(,|;|\(|\)|do|cấp))", RegexOptions.IgnoreCase).Value
            .Item("CmndTextbox").Text = Regex.Match(iText0space, "(?<=:)\d{9}(?=(,|;|\(|\)|do|cấp))", RegexOptions.IgnoreCase).Value
            .Item("CmsqTextbox").Text = Regex.Match(iText0space, "(?<=(sỹ|sĩ)quan(số)?:).*?(?=(,|;|\(|\)|do|cấp))", RegexOptions.IgnoreCase).Value
            .Item("HcTextbox").Text = Regex.Match(iText0space, "(?<=(hộchiếu|passport)(số)?:).*?(?=(,|;|\(|\)|do|cấp))", RegexOptions.IgnoreCase).Value
            .Item("TtTextbox").Text = Regex.Match(iTextFull, "(?<=(thường trú|cư trú|tạm trú|địa chỉ)( tại)?:).*?(?=;)", RegexOptions.IgnoreCase).Value
        End With

        NewCustomTaskPane.Control.Controls.Add(iPanel)

    End Sub
    Private Sub ShowTaskpanel(ByVal doc As Word.Document)
        If Not ThisAddIn.AddinCustomTaskPanes.ContainsKey(doc) Then
            iTaskpanel = Globals.ThisAddIn.CustomTaskPanes.Add(New MyPanel, "VPCC LHA")
            iTaskpanel.Width = 320
            iTaskpanel.Visible = True
            ThisAddIn.AddinCustomTaskPanes.Add(doc, iTaskpanel)
        Else
            iTaskpanel = ThisAddIn.AddinCustomTaskPanes(doc)
            iTaskpanel.Visible = True
        End If

    End Sub
    Private Sub DeleteTaskPanel(ByVal doc As Word.Document)
        Try
            Globals.ThisAddIn.CustomTaskPanes.Remove(ThisAddIn.AddinCustomTaskPanes(doc))
            ThisAddIn.AddinCustomTaskPanes.Remove(doc)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RemoveDocsTaskpanel(ByVal doc As Word.Document)
        If ThisAddIn.AddinCustomTaskPanes.ContainsKey(doc) Then
            Globals.ThisAddIn.CustomTaskPanes.Remove(ThisAddIn.AddinCustomTaskPanes.Item(doc))
            ThisAddIn.AddinCustomTaskPanes.Remove(doc)
        End If
    End Sub
    Private Sub iTaskpanel_VisibleChanged(sender As Object, e As EventArgs) Handles iTaskpanel.VisibleChanged
    End Sub

    Private Sub DataLocationButton_Click(sender As Object, e As RibbonControlEventArgs) Handles DataLocationButton.Click

        If DatabaseLink.ShowDialog() = DialogResult.Cancel Then Exit Sub

        My.Settings.DataLocation = DatabaseLink.FileName.ToString
        My.Settings.Save()

        Call RemoveDocsTaskpanel(iApp.ActiveDocument)

        'https://learn.microsoft.com/en-us/dotnet/framework/configure-apps/file-schema/appsettings/appsettings-element-for-configuration
    End Sub

    Private Sub CcvGroup_ButtonClick(sender As Object, e As RibbonControlEventArgs) Handles CcvGroup.ButtonClick
        If Not IsLicenseValid() Then Exit Sub

        iApp.ScreenUpdating = False
        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Điền CCV")
        On Error GoTo ketthuc

        Dim tencongchungvien As String = sender.label
        If sender Is CcvBlandButton Then tencongchungvien = StrDup(35, " ")

        Dim iDoc = iApp.ActiveDocument
        Dim soluongdem = SearchDocForPattern("^Tôi.*?chứng viên.*?phạm vi trách nhiệm của mình")
        If soluongdem = 1 Then
            Dim iRange As Word.Range = iApp.Selection.Range
            Dim iRange2 As Word.Range = iDoc.Range(iRange.Start, iRange.End)
            Dim iKetqua As String = iRange.Text

            Dim congchungvien As String = $"Tôi, {tencongchungvien}, công chứng viên"
            iRange.Find.Execute(FindText:="Tôi*chứng viên", ReplaceWith:=congchungvien, Forward:=False, MatchWildcards:=True)
            iRange2.Find.Replacement.Font.Bold = True
            iRange2.Find.Execute(FindText:=tencongchungvien, ReplaceWith:=tencongchungvien, Forward:=False, MatchWildcards:=True)
        End If


        Dim soluongdem2 = SearchDocForPattern("CÔNG CHỨNG VIÊN", False)

        On Error Resume Next
        iApp.Selection.Tables(1).Delete()
        On Error GoTo ketthuc

        Dim iRange3 As Word.Range = iApp.Selection.Range
        Dim iTable As Word.Table = iDoc.Tables.Add(iRange3, 1, 2)
        With iTable.Cell(1, 1).Range
            .Text = My.Settings.TenThuKy

            Dim iFont As New Word.Font With {
            .Name = My.Settings.TenThuKy_Font.Name,
            .Size = My.Settings.TenThuKy_Font.Size,
            .Bold = My.Settings.TenThuKy_Font.Bold,
            .Italic = My.Settings.TenThuKy_Font.Italic}

            .Font = iFont
            .ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            .ParagraphFormat.SpaceBefore = 0
            .ParagraphFormat.Space1()
            .ParagraphFormat.LeftIndent = iApp.CentimetersToPoints(1.25)
        End With
        With iTable.Cell(1, 2).Range
            .ParagraphFormat.SpaceBefore = 0
            .ParagraphFormat.Space1()
            .ParagraphFormat.LineSpacing = iApp.LinesToPoints(7)
            .ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            .Font.Bold = True
            .Font.Italic = False
            .Font.Name = "Times New Roman"
            .Font.Size = "13"
            .Text = $"CÔNG CHỨNG VIÊN{vbCr}{UCase(tencongchungvien)}"
            .Find.Replacement.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle
            .Find.Execute(FindText:=tencongchungvien, ReplaceWith:=tencongchungvien, Forward:=False, MatchCase:=False)
        End With
ketthuc:
        objUndo.EndCustomRecord()
        iApp.ScreenUpdating = True

    End Sub

    Private Sub SettingGroup_ItemsLoading(sender As Object, e As RibbonControlEventArgs) Handles SettingGroup.ItemsLoading
        DataLocationButton.SuperTip = $"Thay đổi đường dẫn đến thư mục khách quen.{vbCr}Đường dẫn hiện tại: {My.Settings.DataLocation}"
        If My.Settings.PermanentLisence = "I'm Tama" Then
            LsCheck.Label = "Permanent Lisence"
        Else
            LsCheck.Label = "VPCC LHA"
        End If
    End Sub

    Private Sub LeMiniButton_Click(sender As Object, e As RibbonControlEventArgs) Handles LeSmallButton.Click, LeBigButton.Click, LeMiniButton.Click
        If Not IsLicenseValid() Then Exit Sub

        Dim idoc As Word.Document = iApp.ActiveDocument
        Dim leftMargin As Single = 3
        Dim topMargin As Single = 2

        If sender Is LeSmallButton Then
            leftMargin = 2.5
            topMargin = leftMargin * 2 / 3
        ElseIf sender Is LeMiniButton Then
            leftMargin = 2
            topMargin = leftMargin * 2 / 3
        End If

        iApp.ScreenUpdating = False
        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Căn lề")

        With idoc.PageSetup
            .TopMargin = iApp.CentimetersToPoints(topMargin)
            .BottomMargin = iApp.CentimetersToPoints(topMargin)
            .LeftMargin = iApp.CentimetersToPoints(leftMargin)
            .RightMargin = iApp.CentimetersToPoints(topMargin)
            .Gutter = iApp.CentimetersToPoints(0)
            .HeaderDistance = iApp.CentimetersToPoints(0.5)
            .FooterDistance = iApp.CentimetersToPoints(0.8)
            .PageWidth = iApp.CentimetersToPoints(21)
            .PageHeight = iApp.CentimetersToPoints(29.7)
        End With

        objUndo.EndCustomRecord()
        iApp.ScreenUpdating = True

    End Sub

    Private Sub BlackNWhiteButton_Click(sender As Object, e As RibbonControlEventArgs) Handles BlackNWhiteButton.Click
        If Not IsLicenseValid() Then Exit Sub

        iApp.ScreenUpdating = False
        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Trắng Đen")

        Dim iRange As Word.Range = iApp.ActiveDocument.Range
        With iRange
            .Font.Color = Word.WdColor.wdColorAutomatic
            .Font.Hidden = False
            .HighlightColorIndex = Word.WdColorIndex.wdAuto
        End With
        iApp.ActiveDocument.Sections.First.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Font.Color = Word.WdColor.wdColorAutomatic
        iApp.ActiveDocument.Sections.First.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Font.Name = "Times New Roman"
        iApp.ActiveDocument.Sections.Last.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Font.Color = Word.WdColor.wdColorAutomatic
        iApp.ActiveDocument.Sections.Last.Footers(Word.WdHeaderFooterIndex.wdHeaderFooterPrimary).Range.Font.Name = "Times New Roman"

        objUndo.EndCustomRecord()
        iApp.ScreenUpdating = True

    End Sub

    Private Sub OngBaButton_Click(sender As Object, e As RibbonControlEventArgs) Handles OngBaButton.Click
        If Not IsLicenseValid() Then Exit Sub

        iApp.ScreenUpdating = False
        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Ông/Bà")

        Dim iText As String =
            "Ông" & vbTab & ":" & vbCr &
            "Sinh năm" & vbTab & ":" & vbCr &
            "Căn cước công dân số" & vbTab & ":" & vbCr &
            "Thường trú" & vbTab & ":" & vbCr &
            "Bà" & vbTab & ":" & vbCr &
            "Sinh năm" & vbTab & ":" & vbCr &
            "Căn cước công dân số" & vbTab & ":" & vbCr &
            "Thường trú" & vbTab & ":"

        Dim iRange As Word.Range = iApp.Selection.Range

        Try
            For Each iTable As Word.Table In iRange.Tables
                iTable.Delete()
            Next
        Catch ex As Exception
        End Try

        iRange.ParagraphFormat.TabStops.ClearAll()
        iRange.ParagraphFormat.TabStops.Add(Position:=iApp.CentimetersToPoints(5.25), Alignment:=Word.WdAlignmentTabAlignment.wdLeft, Leader:=Word.WdTabLeader.wdTabLeaderSpaces)

        Try
            If Regex.IsMatch(iRange.Text, "\s$") Then iRange.MoveEnd(Word.WdUnits.wdCharacter, -1)
        Catch ex As Exception
        End Try

        If Trim(iRange.Text) = "" Then
            iRange.InsertParagraphAfter()
            iRange.MoveEnd(Word.WdUnits.wdParagraph, -1)
        End If

        iRange.Text = iText

        With iRange.ParagraphFormat
            .FirstLineIndent = iApp.CentimetersToPoints(0)
            .RightIndent = iApp.CentimetersToPoints(0)
        End With

        With iRange.Font
            .Bold = False
            .Italic = False
            .Name = "Times New Roman"
        End With

        objUndo.EndCustomRecord()
        iApp.ScreenUpdating = True

    End Sub

    Private Sub ScoutNameButton_Click(sender As Object, e As RibbonControlEventArgs) Handles ScoutNameButton.Click
        Dim iForm As New ChuKyForm
        iForm.ShowDialog()
    End Sub

    Private Sub SignButton_Click(sender As Object, e As RibbonControlEventArgs) Handles SignButton.Click
        'Dim files() As String = IO.Directory.GetFiles("Z:\z.kh\SignatureAuthority", "*pdf")
        Call ShowTaskpanel(iApp.ActiveDocument)

        Dim i As ListView = ThisAddIn.AddinCustomTaskPanes(iApp.ActiveDocument).Control.Controls("SignPanel").Controls("SignListview")
        i.Items.Clear()
        'For Each file As String In files
        'i.Items.Add(Regex.Match(file, "(?<=SignatureAuthority\\).*(?=\.pdf)").Value) 'Regex.Match(file, (?<=\\).*?$).Value
        'Next
        ThisAddIn.AddinCustomTaskPanes(iApp.ActiveDocument).Control.Controls("SignPanel").Left = 3
        ThisAddIn.AddinCustomTaskPanes(iApp.ActiveDocument).Control.Controls("SignPanel").BringToFront()

    End Sub

    Private Sub SotoSotrangButton_Click(sender As Object, e As RibbonControlEventArgs) Handles SotoSotrangButton.Click
        Dim a As New SotoSotrang
        a.ShowDialog()
    End Sub

    Private Sub AutoDateButton_Click(sender As Object, e As RibbonControlEventArgs) Handles AutoDateButton.Click
        Dim a As New NotaryCustomer
        Dim i As String
        For Each pair As KeyValuePair(Of String, String) In a.GetPropertyValues
            i &= pair.Key & " ; " & pair.Value & vbCr
        Next
        MsgBox(i)
    End Sub

    Private Sub CcvGroup_ItemsLoading(sender As Object, e As RibbonControlEventArgs) Handles CcvGroup.ItemsLoading
    End Sub

    Private Function IsLicenseValid() As Boolean
        IsLicenseValid = False

        Try
            Dim fileName As String
            Dim fileNumber As Integer
            Dim fileLine As String
            Dim fso As Object
            Dim ts As Object

            fso = CreateObject("Scripting.FileSystemObject")
            fileName = "Z:\z.kh\file.txt"

            If My.Settings.PermanentLisence = "I'm Tama" Then Return True

            ' Check if the file exists
            If fso.FileExists(fileName) Then
                fileNumber = FreeFile()
                FileOpen(fileNumber, fileName, OpenMode.Input)

                ' Read the file line by line
                Do Until EOF(fileNumber)
                    fileLine = LineInput(fileNumber)
                    If InStr(fileLine, "Hello Tama") > 0 Then
                        FileClose(fileNumber)
                        Return True
                    End If
                Loop
                FileClose(fileNumber)
            End If

            Dim iLSBox As New LicenseForm
            iLSBox.ShowDialog()
            If Trim(iLSBox.GetLicense) = "I'm Tama" Then
                My.Settings.PermanentLisence = iLSBox.GetLicense
                My.Settings.Save()
                Return True
            ElseIf Trim(iLSBox.GetLicense) = "Hello Tama" Then
                ts = fso.CreateTextFile(fileName)
                ts.WriteLine(iLSBox.GetLicense)
                ts.Close()
                Return True
            End If

        Catch ex As Exception
            ' Handle exceptions here
        End Try
    End Function



    Private Sub LsCheck_Click(sender As Object, e As RibbonControlEventArgs) Handles LsCheck.Click
        My.Settings.PermanentLisence = "no"
        My.Settings.Save()
        MsgBox("Xin chào " & Regex.Replace(My.Settings.TenThuKy, "\(|\)", "") & "." & vbCr & "Chúc ngày mới tốt lành.")
    End Sub

    Private Sub CcvGroup_Click(sender As Object, e As RibbonControlEventArgs) Handles CcvGroup.Click

    End Sub

    Private Sub DropDown2_SelectionChanged(sender As Object, e As RibbonControlEventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As RibbonControlEventArgs) Handles AuthorityButton.Click
        If Not IsLicenseValid() Then Exit Sub

        iApp.ScreenUpdating = False
        Dim objUndo As Word.UndoRecord = iApp.UndoRecord
        objUndo.StartCustomRecord("Ký tên")
        On Error GoTo ketthuc

        Dim iDoc = iApp.ActiveDocument

        Dim soluongdem2 = SearchDocForPattern("CÔNG CHỨNG VIÊN", False)

        On Error Resume Next
        iApp.Selection.Tables(1).Delete()
        On Error GoTo ketthuc

        Dim iRange3 As Word.Range = iApp.Selection.Range
        Dim iTable As Word.Table = iDoc.Tables.Add(iRange3, 1, 2)
        With iTable.Cell(1, 1).Range
            .Text = My.Settings.TenThuKy

            Dim iFont As New Word.Font With {
            .Name = My.Settings.TenThuKy_Font.Name,
            .Size = My.Settings.TenThuKy_Font.Size,
            .Bold = My.Settings.TenThuKy_Font.Bold,
            .Italic = My.Settings.TenThuKy_Font.Italic}

            .Font = iFont
            .ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            .ParagraphFormat.SpaceBefore = 0
            .ParagraphFormat.Space1()
            .ParagraphFormat.LeftIndent = iApp.CentimetersToPoints(1.25)
        End With
        With iTable.Cell(1, 2).Range
            .ParagraphFormat.SpaceBefore = 0
            .ParagraphFormat.Space1()
            .ParagraphFormat.LineSpacing = iApp.LinesToPoints(7)
            .ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            .Font.Bold = True
            .Font.Italic = False
            .Font.Name = "Times New Roman"
            .Font.Size = "13"
            .Text = "CÔNG CHỨNG VIÊN"
        End With

ketthuc:
        objUndo.EndCustomRecord()
        iApp.ScreenUpdating = True

    End Sub

    Private Sub DayWithTimeButton_Click(sender As Object, e As RibbonControlEventArgs) Handles DayWithTimeButton.Click
        Dim now As DateTime = DateTime.Now
        Dim formattedTime As String = now.ToString("HH:mm")

        Dim ngay = NumtoStr(DateAndTime.Day(DateAndTime.Today))
        Dim thang As String = NumtoStr(Month(DateAndTime.Today))
        Dim nam As String = NumtoStr(Year(DateAndTime.Today))
        Dim ngaythanghomnay As String = $"Hôm nay, vào lúc {formattedTime.Split(":")(0)} giờ {formattedTime.Split(":")(1)} phút, ngày {DateAndTime.Today.ToString("dd/MM/yyyy")} (ngày {Trim(ngay)} tháng {Trim(thang)}, năm {Trim(nam)})"

        Call dienNgay(ngaythanghomnay)

    End Sub

    Private Sub ChuaNgayButton_Click(sender As Object, e As RibbonControlEventArgs) Handles ChuaNgayButton.Click
        Dim thang As String = NumtoStr(Month(Today))
        Dim nam As String = NumtoStr(Year(Today))
        Dim ngay As String = StrDup(20, ".")
        Dim ngaythanghomnay As String = $"Hôm nay, ngày {StrDup(20, ".")} (ngày {Trim(ngay)}, tháng {Trim(thang)}, năm {Trim(nam)})"

        Call dienNgay(ngaythanghomnay)
    End Sub
End Class
