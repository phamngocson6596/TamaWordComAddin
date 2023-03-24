<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ChuKyForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TenThuKyTextbox = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSize = New System.Windows.Forms.ComboBox()
        Me.lstFont = New System.Windows.Forms.ComboBox()
        Me.txtSample = New System.Windows.Forms.TextBox()
        Me.chkBold = New System.Windows.Forms.CheckBox()
        Me.chkItalic = New System.Windows.Forms.CheckBox()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CancleButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TenThuKyTextbox
        '
        Me.TenThuKyTextbox.Location = New System.Drawing.Point(77, 12)
        Me.TenThuKyTextbox.Name = "TenThuKyTextbox"
        Me.TenThuKyTextbox.Size = New System.Drawing.Size(173, 20)
        Me.TenThuKyTextbox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Tên thư ký"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Kiểu dáng"
        '
        'txtSize
        '
        Me.txtSize.FormattingEnabled = True
        Me.txtSize.Items.AddRange(New Object() {"3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15"})
        Me.txtSize.Location = New System.Drawing.Point(208, 37)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(42, 21)
        Me.txtSize.TabIndex = 2
        Me.txtSize.Text = "10"
        '
        'lstFont
        '
        Me.lstFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.lstFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.lstFont.FormattingEnabled = True
        Me.lstFont.Location = New System.Drawing.Point(77, 37)
        Me.lstFont.Name = "lstFont"
        Me.lstFont.Size = New System.Drawing.Size(130, 21)
        Me.lstFont.TabIndex = 3
        '
        'txtSample
        '
        Me.txtSample.Location = New System.Drawing.Point(266, 12)
        Me.txtSample.Multiline = True
        Me.txtSample.Name = "txtSample"
        Me.txtSample.ReadOnly = True
        Me.txtSample.Size = New System.Drawing.Size(75, 46)
        Me.txtSample.TabIndex = 5
        Me.txtSample.TabStop = False
        Me.txtSample.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkBold
        '
        Me.chkBold.AutoSize = True
        Me.chkBold.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBold.Location = New System.Drawing.Point(77, 64)
        Me.chkBold.Name = "chkBold"
        Me.chkBold.Size = New System.Drawing.Size(51, 17)
        Me.chkBold.TabIndex = 6
        Me.chkBold.Text = "Đậm"
        Me.chkBold.UseVisualStyleBackColor = True
        '
        'chkItalic
        '
        Me.chkItalic.AutoSize = True
        Me.chkItalic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkItalic.Location = New System.Drawing.Point(134, 64)
        Me.chkItalic.Name = "chkItalic"
        Me.chkItalic.Size = New System.Drawing.Size(66, 17)
        Me.chkItalic.TabIndex = 6
        Me.chkItalic.Text = "Nghiêng"
        Me.chkItalic.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Location = New System.Drawing.Point(77, 87)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(53, 21)
        Me.OkButton.TabIndex = 7
        Me.OkButton.Text = "OK"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CancleButton
        '
        Me.CancleButton.Location = New System.Drawing.Point(147, 88)
        Me.CancleButton.Name = "CancleButton"
        Me.CancleButton.Size = New System.Drawing.Size(53, 21)
        Me.CancleButton.TabIndex = 7
        Me.CancleButton.Text = "Cancle"
        Me.CancleButton.UseVisualStyleBackColor = True
        '
        'ChuKyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 121)
        Me.Controls.Add(Me.CancleButton)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.chkItalic)
        Me.Controls.Add(Me.chkBold)
        Me.Controls.Add(Me.txtSample)
        Me.Controls.Add(Me.lstFont)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TenThuKyTextbox)
        Me.Name = "ChuKyForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Thiết kế chữ ký"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TenThuKyTextbox As Windows.Forms.TextBox
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents txtSize As Windows.Forms.ComboBox
    Friend WithEvents lstFont As Windows.Forms.ComboBox
    Friend WithEvents txtSample As Windows.Forms.TextBox
    Friend WithEvents chkBold As Windows.Forms.CheckBox
    Friend WithEvents chkItalic As Windows.Forms.CheckBox
    Friend WithEvents OkButton As Windows.Forms.Button
    Friend WithEvents CancleButton As Windows.Forms.Button
End Class
