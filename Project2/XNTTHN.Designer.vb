<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XNTTHN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(XNTTHN))
        Me.TenTextbox = New System.Windows.Forms.TextBox()
        Me.UbndTextbox = New System.Windows.Forms.TextBox()
        Me.FindButton = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.InfoLabel = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.Panel2.SuspendLayout()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TenTextbox
        '
        Me.TenTextbox.Location = New System.Drawing.Point(39, 12)
        Me.TenTextbox.Name = "TenTextbox"
        Me.TenTextbox.Size = New System.Drawing.Size(264, 20)
        Me.TenTextbox.TabIndex = 1
        '
        'UbndTextbox
        '
        Me.UbndTextbox.Location = New System.Drawing.Point(39, 38)
        Me.UbndTextbox.Name = "UbndTextbox"
        Me.UbndTextbox.Size = New System.Drawing.Size(264, 20)
        Me.UbndTextbox.TabIndex = 2
        '
        'FindButton
        '
        Me.FindButton.Location = New System.Drawing.Point(39, 64)
        Me.FindButton.Name = "FindButton"
        Me.FindButton.Size = New System.Drawing.Size(75, 23)
        Me.FindButton.TabIndex = 2
        Me.FindButton.Text = "Tìm"
        Me.FindButton.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.InfoLabel)
        Me.Panel2.Location = New System.Drawing.Point(39, 144)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(264, 124)
        Me.Panel2.TabIndex = 4
        '
        'InfoLabel
        '
        Me.InfoLabel.Dock = System.Windows.Forms.DockStyle.Top
        Me.InfoLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InfoLabel.Location = New System.Drawing.Point(0, 0)
        Me.InfoLabel.Name = "InfoLabel"
        Me.InfoLabel.Size = New System.Drawing.Size(262, 65)
        Me.InfoLabel.TabIndex = 0
        Me.InfoLabel.Text = "Kết quả"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(43, 288)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(397, 12)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(391, 426)
        Me.AxAcroPDF1.TabIndex = 6
        '
        'XNTTHN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.AxAcroPDF1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.FindButton)
        Me.Controls.Add(Me.UbndTextbox)
        Me.Controls.Add(Me.TenTextbox)
        Me.Name = "XNTTHN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "XNTTHN"
        Me.Panel2.ResumeLayout(False)
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TenTextbox As Windows.Forms.TextBox
    Friend WithEvents UbndTextbox As Windows.Forms.TextBox
    Friend WithEvents FindButton As Windows.Forms.Button
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents InfoLabel As Windows.Forms.Label
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
End Class
