Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Word
Imports System.Text.RegularExpressions
Imports System.Reflection

Public Class DsFind
    Public WithEvents OneCn As New ADODB.Connection

    Private Sub MeLoad(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim datalocation As String = My.Settings.DataLocation
        OneCn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & datalocation

        FocusTimer.Start()
        'https://itsourcecode.com/tutorials/visual-basic-tutorial/connect-access-database-in-vb-net/#h-database-access-in-vb-net
        'https://itsourcecode.com/tutorials/visual-basic-tutorial/regular-expression-in-vb-net/
        'https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
    End Sub

    Private Sub FindButton_Click(sender As Object, e As EventArgs) Handles FindButton.Click

        Call FillTheListbox(GetDsRecordset())

        OneCn.Close()

    End Sub
    Private Function GetDsRecordset() As ADODB.Recordset
        If TenTextboxFind.Text = "" And CmtTextbox.Text = "" Then
            DsListview.Items.Clear()
            Dim xRs As New ADODB.Recordset
            Return xRs
        End If

        If OneCn.State = ADODB.ObjectStateEnum.adStateClosed Then OneCn.Open()
        Dim iTen As String = Trim(TenTextboxFind.Text)
        Dim iCMT As String = RemoveSpace(CmtTextbox.Text)
        Dim iText As String = "SELECT * FROM [KH (3)] WHERE " _
                & "[Ten] LIKE '%" & iTen & "%'" _
                & "AND" _
                & "([CMND] LIKE '%" & iCMT & "%'" _
                & "OR [CCCD] LIKE '%" & iCMT & "%'" _
                & "OR [HC] LIKE '%" & iCMT & "%'" _
                & "OR [CMSQ] LIKE '%" & iCMT & "%'" _
                & "OR [SDDCN] LIKE '%" & iCMT & "%')"

        Dim iRs As ADODB.Recordset = OneCn.Execute(iText)

        Return iRs

    End Function
    Private Sub FillTheListbox(ByRef rs As ADODB.Recordset)
        If Not rs.State = ADODB.ObjectStateEnum.adStateOpen Then
            rs = Nothing
            Exit Sub
        End If

        DsListview.Items.Clear()

        Dim listRow As Integer = 0

        DsListview.BeginUpdate()
        Do Until rs.EOF

            Dim customer As New NotaryCustomer
            customer.GetInfoFromRS(rs)

            Dim listViewItem As New ListViewItem({customer.Ten, customer.Sn, customer.CMT}) With {
                .Tag = customer
            }
            DsListview.Items.Add(listViewItem)

            listRow += 1
            rs.MoveNext()
        Loop
        DsListview.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent)
        DsListview.EndUpdate()
        If DsListview.Items.Count > 0 Then DsListview.Items(0).Selected = True

        rs = Nothing
        OneCn.Close()

    End Sub
    Private Sub TenTextboxFind_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TenTextboxFind.KeyPress, CmtTextbox.KeyPress
        SearchTimer.Stop()
        SearchTimer.Start()
    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs) Handles SearchTimer.Tick
        SearchTimer.Stop()

        Me.Parent.Controls("InfoTextbox").ResetText()
        Me.Parent.Controls("InfoTextbox").Enabled = False

        Call FillTheListbox(GetDsRecordset())

    End Sub
    Private Sub TenTexbox_KeyDown(sender As Object, e As KeyEventArgs) Handles TenTextboxFind.KeyDown, CmtTextbox.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.SuppressKeyPress = True
                Call ExportDS()
            Case Keys.Down
                Try
                    e.SuppressKeyPress = True
                    DsListview.Items(DsListview.SelectedItems(0).Index + 1).Selected = True
                Catch ex As Exception
                End Try
            Case Keys.Up
                Try
                    e.SuppressKeyPress = True
                    DsListview.Items(DsListview.SelectedItems(0).Index - 1).Selected = True
                Catch ex As Exception
                End Try
            Case Keys.Escape
                ThisAddIn.AddinCustomTaskPanes(Globals.ThisAddIn.Application.ActiveDocument).Visible = False
        End Select
    End Sub

    Private Sub ExportButton_Click(sender As Object, e As EventArgs) Handles ExportButton.Click
        Call ExportDS()
    End Sub
    Private Sub ExportDS()
        If DsListview.Items.Count = 0 Then Exit Sub

        Dim iCustomer As NotaryCustomer = DsListview.SelectedItems(0).Tag

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
        iRange.Text = iCustomer.ExportCustomer

    End Sub
    Private Sub DsListview_MouseClick(sender As Object, e As MouseEventArgs) Handles DsListview.MouseClick
        If e.Button = MouseButtons.Right Then
            RightClickMenu.Show(CType(sender, System.Windows.Forms.Control), e.Location)
        End If
    End Sub
    Private Sub DsListview_KeyDown(sender As Object, e As KeyEventArgs) Handles DsListview.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                e.SuppressKeyPress = True
                Call ExportDS()
        End Select
    End Sub

    Private Sub DsListview_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DsListview.MouseDoubleClick
        If e.Button = MouseButtons.Left Then
            Call ExportDS()
        End If

    End Sub

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As Int32
    End Function
    Private Sub OneCnExecuteCompleted(RecordsAffected As Integer, pError As ADODB.Error,
                                      ByRef adStatus As ADODB.EventStatusEnum, pCommand As ADODB.Command,
                                      pRecordset As ADODB.Recordset, pConnection As ADODB.Connection) Handles OneCn.ExecuteComplete
        If InStr(pCommand.CommandText, "INSERT INTO") > 0 And RecordsAffected = 1 Then
            Me.Parent.Controls("InfoTextbox").Text = "Thành công!"
        End If
        If InStr(pCommand.CommandText, "DELETE") > 0 And RecordsAffected = 1 Then
            Me.Parent.Controls("InfoTextbox").Text = "Đã xóa đương sự ra khỏi cơ sở dữ liệu!"
            DsListview.SelectedItems(0).Remove()
        End If
        If InStr(pCommand.CommandText, "UPDATE") > 0 And RecordsAffected = 1 Then
            Me.Parent.Controls("InfoTextbox").Text = "Đã cập nhật thành công!"
            Call FillTheListbox(GetDsRecordset())
            FindDsFrame.BringToFront()
        End If

    End Sub

    Private Sub ViewDetailButton_Click(sender As Object, e As EventArgs) Handles ViewDetailButton.Click
        If DsListview.Items.Count = 0 Then Exit Sub

        Dim iCustomer As NotaryCustomer = DsListview.SelectedItems(0).Tag

        Me.Parent.Controls("InfoTextbox").Text = iCustomer.ExportCustomer(Type:=NotaryCustomer.ExportType.OneLine)
        Me.Parent.Controls("InfoTextbox").Enabled = True
        Me.Parent.Controls("InfoTextbox").Height = TextRenderer.MeasureText(Me.Parent.Controls("InfoTextbox").Text, Me.Parent.Controls("InfoTextbox").Font, New System.Drawing.Size(Me.Parent.Controls("InfoTextbox").ClientSize.Width, 1000), TextFormatFlags.WordBreak).Height

    End Sub
    Private Sub ListDeleteButton_Click(sender As Object, e As EventArgs) Handles ListDeleteButton.Click
        If DsListview.Items.Count = 0 Then Exit Sub

        Dim iCustomer As NotaryCustomer = DsListview.SelectedItems(0).Tag

        Dim msg As MsgBoxResult = MsgBox("Xóa khách hàng " & iCustomer.Ten & " ra khỏi cơ sở dữ liệu?", vbOKCancel)
        If Not msg = vbOK Then Exit Sub

        Dim sql As String = "DELETE FROM [KH (3)] WHERE [ID] =" & iCustomer.ID
        If OneCn.State = ADODB.ObjectStateEnum.adStateClosed Then OneCn.Open()
        OneCn.Execute(sql)
        OneCn.Close()
    End Sub
    Private Sub ListUpdateButton_Click(sender As Object, e As EventArgs) Handles ListUpdateButton.Click
        Me.Parent.Controls("InfoTextbox").ResetText()
        If DsListview.Items.Count = 0 Then Exit Sub

        Dim iCustomer As NotaryCustomer = DsListview.SelectedItems(0).Tag
        Dim iPanel = New DsInfomationTable With {.Tag = iCustomer}

        iPanel.FillTableWithCustomer(iCustomer)

        iPanel.Controls("DsFrame").Controls("TenTextbox").Text = iCustomer.GetPropertyValues("Ten")
        Me.Parent.Controls.Add(iPanel)
        iPanel.BringToFront()

    End Sub

    Private Sub PYCButton_Click(sender As Object, e As EventArgs) Handles PYCButton.Click
        Dim iCustomer As NotaryCustomer = DsListview.SelectedItems(0).Tag

        Dim iPYC As Control = New PYC
        iPYC.Controls("TenPYCTextbox").Text = iCustomer.Ten
        iPYC.Controls("DcPYCTextbox").Text = iCustomer.TT

        Me.Parent.Controls.Add(iPYC)
        iPYC.Dock = DockStyle.Bottom

    End Sub


    Private Sub FocusTimer_Tick(sender As Object, e As EventArgs) Handles FocusTimer.Tick
        FocusTimer.Stop()
        Me.Controls("FindDsFrame").Controls("TenTextboxFind").Focus()

    End Sub

    Private Sub TenTextboxFind_TextChanged(sender As Object, e As EventArgs) Handles TenTextboxFind.TextChanged

    End Sub

End Class
