<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PYC
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.NoidungPYCTextbox = New System.Windows.Forms.TextBox()
        Me.SdtPYCTextbox = New System.Windows.Forms.TextBox()
        Me.DcPYCTextbox = New System.Windows.Forms.TextBox()
        Me.TenPYCTextbox = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.FocusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(87, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "in"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 30)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Yêu cầu công chứng về"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "SĐT"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(29, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Địa chỉ"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(83, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(166, 24)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "PHIẾU YÊU CẦU"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(29, 43)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "Tên"
        '
        'NoidungPYCTextbox
        '
        Me.NoidungPYCTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NoidungPYCTextbox.Location = New System.Drawing.Point(87, 124)
        Me.NoidungPYCTextbox.Name = "NoidungPYCTextbox"
        Me.NoidungPYCTextbox.Size = New System.Drawing.Size(211, 22)
        Me.NoidungPYCTextbox.TabIndex = 1
        '
        'SdtPYCTextbox
        '
        Me.SdtPYCTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SdtPYCTextbox.Location = New System.Drawing.Point(87, 92)
        Me.SdtPYCTextbox.Name = "SdtPYCTextbox"
        Me.SdtPYCTextbox.Size = New System.Drawing.Size(211, 22)
        Me.SdtPYCTextbox.TabIndex = 17
        '
        'DcPYCTextbox
        '
        Me.DcPYCTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DcPYCTextbox.Location = New System.Drawing.Point(87, 66)
        Me.DcPYCTextbox.Name = "DcPYCTextbox"
        Me.DcPYCTextbox.Size = New System.Drawing.Size(211, 22)
        Me.DcPYCTextbox.TabIndex = 18
        '
        'TenPYCTextbox
        '
        Me.TenPYCTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TenPYCTextbox.Location = New System.Drawing.Point(87, 40)
        Me.TenPYCTextbox.Name = "TenPYCTextbox"
        Me.TenPYCTextbox.Size = New System.Drawing.Size(211, 22)
        Me.TenPYCTextbox.TabIndex = 19
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Image = Global.Project2.My.Resources.Resources.miniDelete
        Me.Button2.Location = New System.Drawing.Point(288, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(19, 19)
        Me.Button2.TabIndex = 26
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PYC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.NoidungPYCTextbox)
        Me.Controls.Add(Me.SdtPYCTextbox)
        Me.Controls.Add(Me.DcPYCTextbox)
        Me.Controls.Add(Me.TenPYCTextbox)
        Me.Name = "PYC"
        Me.Size = New System.Drawing.Size(307, 193)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents NoidungPYCTextbox As Windows.Forms.TextBox
    Friend WithEvents SdtPYCTextbox As Windows.Forms.TextBox
    Friend WithEvents DcPYCTextbox As Windows.Forms.TextBox
    Friend WithEvents TenPYCTextbox As Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As ComponentModel.BackgroundWorker
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents FocusTimer As Windows.Forms.Timer
End Class
