<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QRcode
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Location = New System.Drawing.Point(3, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 213)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(123, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Dán vào văn bản"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(168, 213)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Lưu vào bộ nhớ tạm"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.AllowDrop = True
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(3, 3)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(288, 175)
        Me.TextBox1.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.BackgroundImage = Global.Project2.My.Resources.Resources.qr_code__2_
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Location = New System.Drawing.Point(263, 150)
        Me.Button3.Margin = New System.Windows.Forms.Padding(2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(28, 28)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "QR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'QRcode
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "QRcode"
        Me.Size = New System.Drawing.Size(300, 259)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Button2 As Windows.Forms.Button
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents TextBox1 As Windows.Forms.TextBox
    Friend WithEvents Button3 As Windows.Forms.Button
End Class
