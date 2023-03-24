<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DsFind
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.FindDsFrame = New System.Windows.Forms.Panel()
        Me.PYCButton = New System.Windows.Forms.Button()
        Me.DsListview = New System.Windows.Forms.ListView()
        Me.TenColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SnColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CmtColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FindButton = New System.Windows.Forms.Button()
        Me.ExportButton = New System.Windows.Forms.Button()
        Me.TenTextboxFind = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CmtTextbox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RightClickMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewDetailButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListUpdateButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListDeleteButton = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FocusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FindDsFrame.SuspendLayout()
        Me.RightClickMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'FindDsFrame
        '
        Me.FindDsFrame.Controls.Add(Me.PYCButton)
        Me.FindDsFrame.Controls.Add(Me.DsListview)
        Me.FindDsFrame.Controls.Add(Me.FindButton)
        Me.FindDsFrame.Controls.Add(Me.ExportButton)
        Me.FindDsFrame.Controls.Add(Me.TenTextboxFind)
        Me.FindDsFrame.Controls.Add(Me.Label4)
        Me.FindDsFrame.Controls.Add(Me.CmtTextbox)
        Me.FindDsFrame.Controls.Add(Me.Label3)
        Me.FindDsFrame.Location = New System.Drawing.Point(2, 2)
        Me.FindDsFrame.Margin = New System.Windows.Forms.Padding(2)
        Me.FindDsFrame.Name = "FindDsFrame"
        Me.FindDsFrame.Size = New System.Drawing.Size(310, 335)
        Me.FindDsFrame.TabIndex = 11
        '
        'PYCButton
        '
        Me.PYCButton.Location = New System.Drawing.Point(219, 250)
        Me.PYCButton.Name = "PYCButton"
        Me.PYCButton.Size = New System.Drawing.Size(54, 23)
        Me.PYCButton.TabIndex = 9
        Me.PYCButton.Text = "PYC"
        Me.PYCButton.UseVisualStyleBackColor = True
        '
        'DsListview
        '
        Me.DsListview.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.TenColumn, Me.SnColumn, Me.CmtColumn})
        Me.DsListview.FullRowSelect = True
        Me.DsListview.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.DsListview.HideSelection = False
        Me.DsListview.Location = New System.Drawing.Point(11, 57)
        Me.DsListview.Margin = New System.Windows.Forms.Padding(2)
        Me.DsListview.MultiSelect = False
        Me.DsListview.Name = "DsListview"
        Me.DsListview.Size = New System.Drawing.Size(286, 189)
        Me.DsListview.TabIndex = 8
        Me.DsListview.UseCompatibleStateImageBehavior = False
        Me.DsListview.View = System.Windows.Forms.View.Details
        '
        'TenColumn
        '
        Me.TenColumn.Text = "Tên"
        Me.TenColumn.Width = 123
        '
        'SnColumn
        '
        Me.SnColumn.Text = "Sn"
        Me.SnColumn.Width = 38
        '
        'CmtColumn
        '
        Me.CmtColumn.Text = "CMT"
        Me.CmtColumn.Width = 116
        '
        'FindButton
        '
        Me.FindButton.Location = New System.Drawing.Point(41, 250)
        Me.FindButton.Margin = New System.Windows.Forms.Padding(2)
        Me.FindButton.Name = "FindButton"
        Me.FindButton.Size = New System.Drawing.Size(52, 24)
        Me.FindButton.TabIndex = 4
        Me.FindButton.Text = "Tìm"
        Me.FindButton.UseVisualStyleBackColor = True
        '
        'ExportButton
        '
        Me.ExportButton.Location = New System.Drawing.Point(117, 250)
        Me.ExportButton.Margin = New System.Windows.Forms.Padding(2)
        Me.ExportButton.Name = "ExportButton"
        Me.ExportButton.Size = New System.Drawing.Size(52, 24)
        Me.ExportButton.TabIndex = 4
        Me.ExportButton.Text = "Xuất"
        Me.ExportButton.UseVisualStyleBackColor = True
        '
        'TenTextboxFind
        '
        Me.TenTextboxFind.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TenTextboxFind.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TenTextboxFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.TenTextboxFind.Location = New System.Drawing.Point(53, 9)
        Me.TenTextboxFind.Margin = New System.Windows.Forms.Padding(2)
        Me.TenTextboxFind.Name = "TenTextboxFind"
        Me.TenTextboxFind.Size = New System.Drawing.Size(168, 23)
        Me.TenTextboxFind.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 33)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "CMT"
        '
        'CmtTextbox
        '
        Me.CmtTextbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmtTextbox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CmtTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(163, Byte))
        Me.CmtTextbox.Location = New System.Drawing.Point(53, 33)
        Me.CmtTextbox.Margin = New System.Windows.Forms.Padding(2)
        Me.CmtTextbox.Name = "CmtTextbox"
        Me.CmtTextbox.Size = New System.Drawing.Size(168, 23)
        Me.CmtTextbox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 12)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Tên"
        '
        'RightClickMenu
        '
        Me.RightClickMenu.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.RightClickMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewDetailButton, Me.ListUpdateButton, Me.ListDeleteButton})
        Me.RightClickMenu.Name = "RightClickMenu"
        Me.RightClickMenu.Size = New System.Drawing.Size(155, 82)
        '
        'ViewDetailButton
        '
        Me.ViewDetailButton.Image = Global.Project2.My.Resources.Resources.picture_icon
        Me.ViewDetailButton.Name = "ViewDetailButton"
        Me.ViewDetailButton.Size = New System.Drawing.Size(154, 26)
        Me.ViewDetailButton.Text = "Xem thông tin"
        '
        'ListUpdateButton
        '
        Me.ListUpdateButton.Image = Global.Project2.My.Resources.Resources.miniUpdate
        Me.ListUpdateButton.Name = "ListUpdateButton"
        Me.ListUpdateButton.Size = New System.Drawing.Size(154, 26)
        Me.ListUpdateButton.Text = "Cập nhật"
        '
        'ListDeleteButton
        '
        Me.ListDeleteButton.Image = Global.Project2.My.Resources.Resources.miniDelete
        Me.ListDeleteButton.Name = "ListDeleteButton"
        Me.ListDeleteButton.Size = New System.Drawing.Size(154, 26)
        Me.ListDeleteButton.Text = "Xóa"
        '
        'SearchTimer
        '
        Me.SearchTimer.Interval = 150
        '
        'FocusTimer
        '
        '
        'DsFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.FindDsFrame)
        Me.Name = "DsFind"
        Me.Size = New System.Drawing.Size(316, 341)
        Me.FindDsFrame.ResumeLayout(False)
        Me.FindDsFrame.PerformLayout()
        Me.RightClickMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents FindDsFrame As Windows.Forms.Panel
    Friend WithEvents PYCButton As Windows.Forms.Button
    Friend WithEvents DsListview As Windows.Forms.ListView
    Friend WithEvents TenColumn As Windows.Forms.ColumnHeader
    Friend WithEvents SnColumn As Windows.Forms.ColumnHeader
    Friend WithEvents CmtColumn As Windows.Forms.ColumnHeader
    Friend WithEvents FindButton As Windows.Forms.Button
    Friend WithEvents ExportButton As Windows.Forms.Button
    Friend WithEvents TenTextboxFind As Windows.Forms.TextBox
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents CmtTextbox As Windows.Forms.TextBox
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents RightClickMenu As Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewDetailButton As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListUpdateButton As Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListDeleteButton As Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchTimer As Windows.Forms.Timer
    Friend WithEvents FocusTimer As Windows.Forms.Timer
End Class
