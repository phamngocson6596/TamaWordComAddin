Imports System.Configuration
Imports System.Drawing
Imports System.Windows.Forms

Public Class ChuKyForm
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim installed_fonts As New Text.InstalledFontCollection
        lstFont.Items.Clear()
        For Each font_family In installed_fonts.Families
            lstFont.Items.Add(font_family.Name)
        Next font_family
        lstFont.SelectedIndex = 0

        TenThuKyTextbox.Text = My.Settings.TenThuKy
        lstFont.Text = My.Settings.TenThuKy_Font.Name
        txtSize.Text = My.Settings.TenThuKy_Font.Size
        chkBold.Checked = My.Settings.TenThuKy_Font.Bold
        chkItalic.Checked = My.Settings.TenThuKy_Font.Italic

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles _
            TenThuKyTextbox.TextChanged, lstFont.TextChanged, txtSize.TextChanged, chkBold.Click, chkItalic.Click
        txtSample.Text = TenThuKyTextbox.Text
        Call ShowSample()
    End Sub

    Private Sub ShowSample()
        ' Compose the font style.

        Dim font_style As FontStyle = FontStyle.Regular
        If chkBold.Checked Then font_style = font_style Or
            FontStyle.Bold
        If chkItalic.Checked Then font_style = font_style Or
            FontStyle.Italic
        ' Get the font size.
        Dim font_size As Single = 8
        Try
            font_size = Single.Parse(txtSize.Text)
        Catch ex As Exception
        End Try

        ' Get the font family name.
        Dim family_name As String = "Times New Roman"
        If Not (lstFont.SelectedItem Is Nothing) Then
            family_name = lstFont.SelectedItem.ToString
        End If
        ' Make the new font.
        Dim new_font As New Font(
            family_name, font_size, font_style)

        ' Set the sample's font.
        txtSample.Font = new_font
        ChoosenFont = new_font
    End Sub
    Dim ChoosenFont As Font
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.Hide()

        Try
            My.Settings.TenThuKy = TenThuKyTextbox.Text
            My.Settings.TenThuKy_Font = ChoosenFont
            My.Settings.Save()

            MsgBox("Thành công")
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Close()

        End Try

    End Sub

    Private Sub CancleButton_Click(sender As Object, e As EventArgs) Handles CancleButton.Click
        Me.Close()
    End Sub

    Private Sub old()
        Try
            Dim Configuration As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Configuration.AppSettings.Settings("TenThuKy").Value = TenThuKyTextbox.Text
            Configuration.AppSettings.Settings("TenThuKy_Font_Name").Value = lstFont.SelectedItem.ToString
            Configuration.AppSettings.Settings("TenThuKy_Font_Size").Value = txtSize.Text
            Configuration.AppSettings.Settings("TenThuKy_Font_Bold").Value = chkBold.Checked.ToString
            Configuration.AppSettings.Settings("TenThuKy_Font_Italic").Value = chkItalic.Checked.ToString

            Configuration.Save(ConfigurationSaveMode.Full, True)
            ConfigurationManager.RefreshSection("appSettings")
            MsgBox("Thành công")
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Close()
        End Try

    End Sub


    Private Sub txtSample_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSample.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub lstFont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFont.SelectedIndexChanged

    End Sub
End Class