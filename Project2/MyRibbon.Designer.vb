Partial Class MyRibbon
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyRibbon))
        Me.Tab1 = Me.Factory.CreateRibbonTab
        Me.Group1 = Me.Factory.CreateRibbonGroup
        Me.NgayloichungButton = Me.Factory.CreateRibbonSplitButton
        Me.ChuaNgayButton = Me.Factory.CreateRibbonButton
        Me.MoneyButton = Me.Factory.CreateRibbonButton
        Me.AuthorityButton = Me.Factory.CreateRibbonButton
        Me.CcvGroup = Me.Factory.CreateRibbonGallery
        Me.DPHKButton = Me.Factory.CreateRibbonButton
        Me.DBTButton = Me.Factory.CreateRibbonButton
        Me.CcvBlandButton = Me.Factory.CreateRibbonButton
        Me.Group2 = Me.Factory.CreateRibbonGroup
        Me.DayMonthButton = Me.Factory.CreateRibbonSplitButton
        Me.DayMonthButton1 = Me.Factory.CreateRibbonButton
        Me.DayMonthButton2 = Me.Factory.CreateRibbonButton
        Me.PageNumButton = Me.Factory.CreateRibbonButton
        Me.SoQuyenButton = Me.Factory.CreateRibbonButton
        Me.LeMenu = Me.Factory.CreateRibbonMenu
        Me.LeBigButton = Me.Factory.CreateRibbonButton
        Me.LeSmallButton = Me.Factory.CreateRibbonButton
        Me.LeMiniButton = Me.Factory.CreateRibbonButton
        Me.BlackNWhiteButton = Me.Factory.CreateRibbonButton
        Me.OngBaButton = Me.Factory.CreateRibbonButton
        Me.SotoSotrangButton = Me.Factory.CreateRibbonButton
        Me.Group3 = Me.Factory.CreateRibbonGroup
        Me.DsFindButton = Me.Factory.CreateRibbonButton
        Me.Separator2 = Me.Factory.CreateRibbonSeparator
        Me.DsAnalyzeButton = Me.Factory.CreateRibbonButton
        Me.Group4 = Me.Factory.CreateRibbonGroup
        Me.SignButton = Me.Factory.CreateRibbonButton
        Me.AutoDateButton = Me.Factory.CreateRibbonButton
        Me.SettingGroup = Me.Factory.CreateRibbonGallery
        Me.DataLocationButton = Me.Factory.CreateRibbonButton
        Me.ScoutNameButton = Me.Factory.CreateRibbonButton
        Me.LsCheck = Me.Factory.CreateRibbonButton
        Me.DatabaseLink = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = Me.Factory.CreateRibbonLabel
        Me.DropDown1 = Me.Factory.CreateRibbonDropDown
        Me.Tab1.SuspendLayout()
        Me.Group1.SuspendLayout()
        Me.Group2.SuspendLayout()
        Me.Group3.SuspendLayout()
        Me.Group4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tab1
        '
        Me.Tab1.Groups.Add(Me.Group1)
        Me.Tab1.Groups.Add(Me.Group2)
        Me.Tab1.Groups.Add(Me.Group3)
        Me.Tab1.Groups.Add(Me.Group4)
        Me.Tab1.Label = "NotaryBeta"
        Me.Tab1.Name = "Tab1"
        '
        'Group1
        '
        Me.Group1.Items.Add(Me.NgayloichungButton)
        Me.Group1.Items.Add(Me.MoneyButton)
        Me.Group1.Items.Add(Me.AuthorityButton)
        Me.Group1.Items.Add(Me.CcvGroup)
        Me.Group1.Label = "Hay xài"
        Me.Group1.Name = "Group1"
        '
        'NgayloichungButton
        '
        Me.NgayloichungButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.NgayloichungButton.Image = Global.Project2.My.Resources.Resources.Calendar_icon
        Me.NgayloichungButton.Items.Add(Me.ChuaNgayButton)
        Me.NgayloichungButton.Label = "Ngày lời chứng"
        Me.NgayloichungButton.Name = "NgayloichungButton"
        '
        'ChuaNgayButton
        '
        Me.ChuaNgayButton.Label = "Chừa ngày"
        Me.ChuaNgayButton.Name = "ChuaNgayButton"
        Me.ChuaNgayButton.ShowImage = True
        '
        'MoneyButton
        '
        Me.MoneyButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.MoneyButton.Image = Global.Project2.My.Resources.Resources.dollar_icon
        Me.MoneyButton.Label = "Tiền số thành chữ"
        Me.MoneyButton.Name = "MoneyButton"
        Me.MoneyButton.ShowImage = True
        '
        'AuthorityButton
        '
        Me.AuthorityButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.AuthorityButton.Image = Global.Project2.My.Resources.Resources.Mimetypes_application_pgp_signature_icon__1_
        Me.AuthorityButton.Label = "Ký tên"
        Me.AuthorityButton.Name = "AuthorityButton"
        Me.AuthorityButton.ShowImage = True
        '
        'CcvGroup
        '
        Me.CcvGroup.Buttons.Add(Me.DPHKButton)
        Me.CcvGroup.Buttons.Add(Me.DBTButton)
        Me.CcvGroup.Buttons.Add(Me.CcvBlandButton)
        Me.CcvGroup.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.CcvGroup.Image = Global.Project2.My.Resources.Resources.User_icon
        Me.CcvGroup.Label = "Công chứng viên"
        Me.CcvGroup.Name = "CcvGroup"
        Me.CcvGroup.ShowImage = True
        '
        'DPHKButton
        '
        Me.DPHKButton.Label = "Dương Phước Hoàng Khánh"
        Me.DPHKButton.Name = "DPHKButton"
        '
        'DBTButton
        '
        Me.DBTButton.Label = "Dương Bích Tuyền"
        Me.DBTButton.Name = "DBTButton"
        '
        'CcvBlandButton
        '
        Me.CcvBlandButton.Label = "Chừa trống"
        Me.CcvBlandButton.Name = "CcvBlandButton"
        '
        'Group2
        '
        Me.Group2.Items.Add(Me.DayMonthButton)
        Me.Group2.Items.Add(Me.PageNumButton)
        Me.Group2.Items.Add(Me.SoQuyenButton)
        Me.Group2.Items.Add(Me.LeMenu)
        Me.Group2.Items.Add(Me.BlackNWhiteButton)
        Me.Group2.Items.Add(Me.OngBaButton)
        Me.Group2.Items.Add(Me.SotoSotrangButton)
        Me.Group2.Label = "Phụ"
        Me.Group2.Name = "Group2"
        '
        'DayMonthButton
        '
        Me.DayMonthButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.DayMonthButton.Image = Global.Project2.My.Resources.Resources.Calendar_icon__2_
        Me.DayMonthButton.Items.Add(Me.DayMonthButton1)
        Me.DayMonthButton.Items.Add(Me.DayMonthButton2)
        Me.DayMonthButton.Label = "D/M/Y"
        Me.DayMonthButton.Name = "DayMonthButton"
        '
        'DayMonthButton1
        '
        Me.DayMonthButton1.Label = "Ngày/Tháng/Năm"
        Me.DayMonthButton1.Name = "DayMonthButton1"
        Me.DayMonthButton1.ShowImage = True
        '
        'DayMonthButton2
        '
        Me.DayMonthButton2.Label = "Ngày Tháng Năm"
        Me.DayMonthButton2.Name = "DayMonthButton2"
        Me.DayMonthButton2.ShowImage = True
        '
        'PageNumButton
        '
        Me.PageNumButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.PageNumButton.Image = Global.Project2.My.Resources.Resources.Pages_icon
        Me.PageNumButton.Label = "Đánh số trang"
        Me.PageNumButton.Name = "PageNumButton"
        Me.PageNumButton.ShowImage = True
        '
        'SoQuyenButton
        '
        Me.SoQuyenButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.SoQuyenButton.Image = Global.Project2.My.Resources.Resources._62873_bookmark_icon
        Me.SoQuyenButton.Label = "Đánh số quyển"
        Me.SoQuyenButton.Name = "SoQuyenButton"
        Me.SoQuyenButton.ShowImage = True
        '
        'LeMenu
        '
        Me.LeMenu.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.LeMenu.Image = Global.Project2.My.Resources.Resources.document_margins_icon
        Me.LeMenu.Items.Add(Me.LeBigButton)
        Me.LeMenu.Items.Add(Me.LeSmallButton)
        Me.LeMenu.Items.Add(Me.LeMiniButton)
        Me.LeMenu.ItemSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.LeMenu.Label = "Căn lề"
        Me.LeMenu.Name = "LeMenu"
        Me.LeMenu.ShowImage = True
        '
        'LeBigButton
        '
        Me.LeBigButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.LeBigButton.Image = Global.Project2.My.Resources.Resources._1_Documents_icon
        Me.LeBigButton.Label = "Lề to"
        Me.LeBigButton.Name = "LeBigButton"
        Me.LeBigButton.ShowImage = True
        '
        'LeSmallButton
        '
        Me.LeSmallButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.LeSmallButton.Image = Global.Project2.My.Resources.Resources._2_Documents_icon
        Me.LeSmallButton.Label = "Lề nhỏ"
        Me.LeSmallButton.Name = "LeSmallButton"
        Me.LeSmallButton.ShowImage = True
        '
        'LeMiniButton
        '
        Me.LeMiniButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.LeMiniButton.Image = Global.Project2.My.Resources.Resources.write_paper_ink_icon
        Me.LeMiniButton.Label = "Lề mini"
        Me.LeMiniButton.Name = "LeMiniButton"
        Me.LeMiniButton.ShowImage = True
        '
        'BlackNWhiteButton
        '
        Me.BlackNWhiteButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.BlackNWhiteButton.Image = Global.Project2.My.Resources.Resources.Black_Documents_icon
        Me.BlackNWhiteButton.Label = "Xóa màu"
        Me.BlackNWhiteButton.Name = "BlackNWhiteButton"
        Me.BlackNWhiteButton.ShowImage = True
        '
        'OngBaButton
        '
        Me.OngBaButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.OngBaButton.Image = Global.Project2.My.Resources.Resources.name_card_icon
        Me.OngBaButton.Label = "Khung ông/bà"
        Me.OngBaButton.Name = "OngBaButton"
        Me.OngBaButton.ShowImage = True
        '
        'SotoSotrangButton
        '
        Me.SotoSotrangButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.SotoSotrangButton.Image = Global.Project2.My.Resources.Resources.Printing_One_Page_icon
        Me.SotoSotrangButton.Label = "Số tờ sô trang"
        Me.SotoSotrangButton.Name = "SotoSotrangButton"
        Me.SotoSotrangButton.ShowImage = True
        '
        'Group3
        '
        Me.Group3.Items.Add(Me.DsFindButton)
        Me.Group3.Items.Add(Me.Separator2)
        Me.Group3.Items.Add(Me.DsAnalyzeButton)
        Me.Group3.Label = "Khách quen"
        Me.Group3.Name = "Group3"
        '
        'DsFindButton
        '
        Me.DsFindButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.DsFindButton.Image = Global.Project2.My.Resources.Resources.users_icon
        Me.DsFindButton.Label = "Khách hàng"
        Me.DsFindButton.Name = "DsFindButton"
        Me.DsFindButton.ShowImage = True
        '
        'Separator2
        '
        Me.Separator2.Name = "Separator2"
        '
        'DsAnalyzeButton
        '
        Me.DsAnalyzeButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.DsAnalyzeButton.Image = Global.Project2.My.Resources.Resources.miniDSaddIcon
        Me.DsAnalyzeButton.Label = "Ghi"
        Me.DsAnalyzeButton.Name = "DsAnalyzeButton"
        Me.DsAnalyzeButton.ShowImage = True
        '
        'Group4
        '
        Me.Group4.Items.Add(Me.SignButton)
        Me.Group4.Items.Add(Me.AutoDateButton)
        Me.Group4.Items.Add(Me.SettingGroup)
        Me.Group4.Label = "Misc"
        Me.Group4.Name = "Group4"
        '
        'SignButton
        '
        Me.SignButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.SignButton.Image = Global.Project2.My.Resources.Resources.Firstline1_Movie_Mega_Pack_4_The_Bank_Job
        Me.SignButton.Label = "Đăng ký chữ ký"
        Me.SignButton.Name = "SignButton"
        Me.SignButton.ShowImage = True
        '
        'AutoDateButton
        '
        Me.AutoDateButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.AutoDateButton.Image = CType(resources.GetObject("AutoDateButton.Image"), System.Drawing.Image)
        Me.AutoDateButton.Label = "Tomato"
        Me.AutoDateButton.Name = "AutoDateButton"
        Me.AutoDateButton.ShowImage = True
        '
        'SettingGroup
        '
        Me.SettingGroup.Buttons.Add(Me.DataLocationButton)
        Me.SettingGroup.Buttons.Add(Me.ScoutNameButton)
        Me.SettingGroup.Buttons.Add(Me.LsCheck)
        Me.SettingGroup.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.SettingGroup.Image = Global.Project2.My.Resources.Resources.settings_icon
        Me.SettingGroup.Label = "Cài đặt"
        Me.SettingGroup.Name = "SettingGroup"
        Me.SettingGroup.ShowImage = True
        '
        'DataLocationButton
        '
        Me.DataLocationButton.Label = "Đặt lại đường dẫn khách quen"
        Me.DataLocationButton.Name = "DataLocationButton"
        '
        'ScoutNameButton
        '
        Me.ScoutNameButton.Label = "Đặt lại tên thư ký"
        Me.ScoutNameButton.Name = "ScoutNameButton"
        '
        'LsCheck
        '
        Me.LsCheck.Label = "LsCheck"
        Me.LsCheck.Name = "LsCheck"
        '
        'DatabaseLink
        '
        Me.DatabaseLink.Filter = "MsAccess|*.accdb"
        '
        'Label1
        '
        Me.Label1.Label = "Label1"
        Me.Label1.Name = "Label1"
        '
        'DropDown1
        '
        Me.DropDown1.Label = "DropDown1"
        Me.DropDown1.Name = "DropDown1"
        '
        'MyRibbon
        '
        Me.Name = "MyRibbon"
        Me.RibbonType = "Microsoft.Word.Document"
        Me.Tabs.Add(Me.Tab1)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Group1.ResumeLayout(False)
        Me.Group1.PerformLayout()
        Me.Group2.ResumeLayout(False)
        Me.Group2.PerformLayout()
        Me.Group3.ResumeLayout(False)
        Me.Group3.PerformLayout()
        Me.Group4.ResumeLayout(False)
        Me.Group4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Tab1 As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents Group1 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents AutoDateButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Group2 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents MoneyButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents PageNumButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents DayMonthButton As Microsoft.Office.Tools.Ribbon.RibbonSplitButton
    Friend WithEvents DayMonthButton1 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents DayMonthButton2 As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Group3 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents NgayloichungButton As Microsoft.Office.Tools.Ribbon.RibbonSplitButton
    Friend WithEvents ChuaNgayButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents SoQuyenButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Group4 As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents CcvGroup As Microsoft.Office.Tools.Ribbon.RibbonGallery
    Friend WithEvents DPHKButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents DBTButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents CcvBlandButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents DsFindButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents DsAnalyzeButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Separator2 As Microsoft.Office.Tools.Ribbon.RibbonSeparator
    Friend WithEvents SettingGroup As Microsoft.Office.Tools.Ribbon.RibbonGallery
    Friend WithEvents DataLocationButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents ScoutNameButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents DatabaseLink As Windows.Forms.OpenFileDialog
    Friend WithEvents LeMenu As Microsoft.Office.Tools.Ribbon.RibbonMenu
    Friend WithEvents LeSmallButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents LeBigButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents Label1 As Microsoft.Office.Tools.Ribbon.RibbonLabel
    Friend WithEvents LeMiniButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents BlackNWhiteButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents OngBaButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents SignButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents SotoSotrangButton As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents DropDown1 As Microsoft.Office.Tools.Ribbon.RibbonDropDown
    Friend WithEvents LsCheck As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents AuthorityButton As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property MyRibbon() As MyRibbon
        Get
            Return Me.GetRibbon(Of MyRibbon)()
        End Get
    End Property
End Class
